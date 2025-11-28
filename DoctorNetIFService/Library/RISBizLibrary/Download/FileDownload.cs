using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using RISBizLibrary.Data;
using RISBizLibrary.Download.Model;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.MessageLog;
using RISCommonLibrary.Lib.Utils;

namespace RISBizLibrary.Download
{
	internal class FileDownload : IDisposable
	{
		private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// メッセージ処理クラス
		/// </summary>
		private MessageHandler _messageHandler;

		/// <summary>
		/// メッセージ作成クラスファクトリ
		/// </summary>
		private Dictionary<string, MessageHandler> _msgHandlerFactory;

		//アップロードディレクトリ名
		private const string DIR_INDEX = "INDEX";
		private const string DIR_DATA = "DATA";
		private const string DIR_LOG = "LOG";

		//ダウンロードディレクトリ名
		private const string OK_DATA_DIR  = "DATA\\OK_DATA";
		private const string ERR_DATA_DIR  = "DATA\\ERR_DATA";
		private const string OK_INDEX_DIR  = "INDEX\\OK";
		private const string ERR_INDEX_DIR  = "INDEX\\ERR";

		#region コンストラクタ

		public FileDownload()
		{
			InitMessageLogger();
			_msgHandlerFactory = new Dictionary<string, MessageHandler>();
			SetDataMessageHandlerFactory(_msgHandlerFactory);
		}

		#endregion

		#region IDisposable メンバ

		public void Dispose()
		{
		}

		#endregion

		/// <summary>
		/// 電文ログファイル名取得
		/// </summary>
		/// <param name="logDateTime"></param>
		/// <param name="telegraphKind"></param>
		/// <param name="sendOrRecv"></param>
		/// <returns></returns>
		private String GetGWLogFileName(DateTime logDateTime)
		{
			const string LOG_FILENAME_FORMAT = "HRBHAB{0:yyyyMMdd}.log";
			return String.Format(
					LOG_FILENAME_FORMAT,
					logDateTime
					);
		}

		/// <summary>
		/// 電文ログクラス初期化
		/// </summary>
		private void InitMessageLogger()
		{
			//MessageLogger.Instance.RootDir = ConfigurationManager.AppSettings["MessageLogRootDir"].StringToString();
			//MessageLogger.Instance.TargetDirFormat = ConfigurationManager.AppSettings["MessageLogWriteDirDateFormat"].StringToString();
			MessageLogger.Instance.Enc = Encoding.GetEncoding(ConfigurationManager.AppSettings["MessageEncode"].StringToString());
		}

		public void Download()
		{
			try
			{
				string basePath = ConfigurationManager.AppSettings["Gateway"].StringToString();
				string dirName = ConfigurationManager.AppSettings["DirName"].StringToString();
				_log.Debug("ディレクトリ:" + dirName + "を処理します");
				basePath = Path.Combine(basePath, dirName);

				string[] extensionArray = ConfigurationManager.AppSettings["Extension"].StringToString().Split(',');

				DateTime logDateTime = DateTime.Now; //電文ログ日時
				String sendFileLogName = GetGWLogFileName(logDateTime);
				MessageLogger.Instance.RootDir = Path.Combine(basePath, DIR_LOG);
				_log.InfoFormat("GW電文ログファイル名={0}", sendFileLogName);

				try
				{
					foreach (string extension in extensionArray)
					{
						foreach (string indexFile in Directory.GetFiles(Path.Combine(basePath, DIR_INDEX), extension))
						{
							bool isSucceeded = false;

							//情報ファイル処理
							_log.Info("Indexファイルを処理します: " + indexFile);

							string dataPath = Path.Combine(basePath, DIR_DATA);
							string dataFile = Path.Combine(dataPath, Path.GetFileName(indexFile));

							// DATAファイルの存在チェック
							if (!File.Exists(dataFile))
							{
								_log.Error("Dataファイルが存在しませんでした。");
								//異常終了時GWログ出力
								MessageLogger.Instance.WriteLog(sendFileLogName, "ERROR", "[" + Path.GetFileName(indexFile) + "]Dataファイルが存在しませんでした ");
								continue;
							}

							try
							{
								string receivedString = string.Empty;

								using (StreamReader sr = new StreamReader(dataFile, MessageLogger.Instance.Enc))
								{
									receivedString = sr.ReadToEnd();
								}

								_messageHandler = GetMessageHandler(StringUtils.Mid(receivedString, 1, 2));
								_messageHandler.Execute(receivedString);

								//正常終了
								isSucceeded = true;

								//正常終了時GWログ出力
								MessageLogger.Instance.WriteLog(sendFileLogName, "INFO", "[" + Path.GetFileName(indexFile) + "]を正常に処理しました");
							}
							catch (Exception ex)
							{
								_log.Error("ファイル処理中に例外発生:" + ex.Message);
								//異常終了時GWログ出力
								MessageLogger.Instance.WriteLog(sendFileLogName, "ERROR", "[" + Path.GetFileName(indexFile) + "]処理中にエラーが発生しました " + ex.Message);
							}

							//ファイル移動
							MoveIndexFile(isSucceeded, indexFile, basePath, Path.GetFileName(indexFile));
							MoveDataFile(isSucceeded, dataFile, basePath, Path.GetFileName(indexFile));
						}
					}
				}
				catch (Exception ex)
				{
					_log.Error("ディレクトリ処理中に例外発生:" + ex.Message);
					//gJudge.ProcessState := psError;
					//異常終了時GWログ出力
					MessageLogger.Instance.WriteLog(sendFileLogName, "ERROR", "[" + dirName + "]処理中にエラーが発生しました " + ex.Message);
				}
			}
			finally
			{
			}
		}

		/// <summary>
		/// インデックスファイルを移動する
		/// </summary>
		private void MoveIndexFile(bool isSucceeded, string baseFile, string basePath, string filename)
		{
			string _ToFile;

			if (isSucceeded)
			{
				_ToFile = Path.Combine(basePath, OK_INDEX_DIR);
			}
			else
			{
				_ToFile = Path.Combine(basePath, ERR_INDEX_DIR);
			}
			_ToFile = Path.Combine(_ToFile, filename);

			FileSystem.MoveFile(baseFile, _ToFile, true);
			//File.Move(baseFile, _ToFile);
			_log.Info("コピー元: " + baseFile);
			_log.Info("コピー先: " + _ToFile);
		}

		/// <summary>
		/// 情報ファイルを移動する
		/// </summary>
		private void MoveDataFile(bool isSucceeded, string baseFile, string basePath, string filename)
		{
			string _ToFile;

			if (isSucceeded)
			{
				_ToFile = Path.Combine(basePath, OK_DATA_DIR);
			}
			else
			{
				_ToFile = Path.Combine(basePath, ERR_DATA_DIR);
			}
			_ToFile = Path.Combine(_ToFile, filename);

			FileSystem.MoveFile(baseFile, _ToFile, true);
			//File.Move(baseFile, _ToFile);
			_log.Info("コピー元: " + baseFile);
			_log.Info("コピー先: " + _ToFile);
		}

		/// <summary>
		/// TOHISINFO.RequestTypeによって電文作成クラスを返す
		/// </summary>
		/// <param name="requestType"></param>
		/// <returns></returns>
		private MessageHandler GetMessageHandler(string denbunsybt)
		{
			if (!_msgHandlerFactory.ContainsKey(denbunsybt))
			{
				throw new MsgAnomalyException(string.Format(
					"このプログラムでは想定していない電文種別です。電文種別={0}", denbunsybt));
			}
			return _msgHandlerFactory[denbunsybt];
		}

		/// <summary>
		/// メッセージファクトリに登録
		/// </summary>
		/// <param name="factory"></param>
		private void SetDataMessageHandlerFactory(Dictionary<string, MessageHandler> factory)
		{
			MessageHandler hospital = new MessageHandlerHospital();
			foreach (string denbunsybt in hospital.GetDenbunSybt())
			{
				factory.Add(denbunsybt, hospital);
			}

			MessageHandler changeward = new MessageHandlerChangeWard();
			foreach (string denbunsybt in changeward.GetDenbunSybt())
			{
				factory.Add(denbunsybt, changeward);
			}

			MessageHandler changesection = new MessageHandlerChangeSection();
			foreach (string denbunsybt in changesection.GetDenbunSybt())
			{
				factory.Add(denbunsybt, changesection);
			}

			MessageHandler leavehospital = new MessageHandlerLeaveHospital();
			foreach (string denbunsybt in leavehospital.GetDenbunSybt())
			{
				factory.Add(denbunsybt, leavehospital);
			}

			MessageHandler orderinfo = new MessageHandlerOrderInfo();
			foreach (string denbunsybt in orderinfo.GetDenbunSybt())
			{
				factory.Add(denbunsybt, orderinfo);
			}

			MessageHandler patient = new MessageHandlerPatient();
			foreach (string denbunsybt in patient.GetDenbunSybt())
			{
				factory.Add(denbunsybt, patient);
			}
		}
	}
}
