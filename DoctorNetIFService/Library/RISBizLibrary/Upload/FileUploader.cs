using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using RISBizLibrary.Data;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.MessageLog;
using RISCommonLibrary.Lib.Utils;
using RISODPLibrary.Lib.Utils;

namespace RISBizLibrary.Upload
{
	internal class FileUploader : IDisposable
	{
		private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		//アップロードディレクトリ名
		private const string DIR_INDEX = "INDEX";
		private const string DIR_DATA = "DATA";
		private const string DIR_LOG = "LOG";

		#region コンストラクタ

		public FileUploader()
		{
			InitMessageLogger();
		}

		#endregion

		#region IDisposable メンバ

		public void Dispose()
		{
		}

		#endregion

		// 2020.08.28 Mod H.Taira@COSMO Start
		//public void SendRecv(BaseMsgData msgData)
		public void SendRecv(BaseMsgData msgData, IDbConnection connection)
		// 2020.08.28 Mod H.Taira@COSMO End
		{
			const string LOG_UPLOAD_FORMAT = "メッセージ送信処理が正常終了しました。 DIR: {0}; FILE: {1}";
			const string WARNING_FORMAT = "処理中に例外({0}:{1})が発生しました。リトライします";

			string basePath = ConfigurationManager.AppSettings["Gateway"].StringToString();
			// 2020.08.28 Mod H.Taira@COSMO Start
			//string _MsgFileName = GetFileName(msgData);
			string _MsgFileName = GetFileName(msgData, connection);
			// 2020.08.28 Mod H.Taira@COSMO End

			DateTime logDateTime = DateTime.Now; //電文ログ日時
			String sendFileLogName = GetGWLogFileName(msgData, logDateTime);
			MessageLogger.Instance.RootDir = Path.Combine(Path.Combine(basePath, msgData.Request.DirName), DIR_LOG);
			//MessageLogger.Instance.UpdateCurrentDir(logDateTime);
			_log.InfoFormat("GW電文ログファイル名={0}", sendFileLogName);

			//GWへのファイルアップロード中エラーは無限リトライする
			//while (true)
			//{
			try
			{
				CreateDataFile(basePath, _MsgFileName, msgData);
				CreateIndexFile(basePath, _MsgFileName, msgData);

				//ここでGATEWAYログ出力の予定
				_log.InfoFormat(string.Format(LOG_UPLOAD_FORMAT, msgData.Request.DirName, _MsgFileName));
				MessageLogger.Instance.WriteLog(sendFileLogName, "INFO", "[" + _MsgFileName + "]を正常に送信しました");
				//break;

			}
			catch (Exception e)
			{
				_log.WarnFormat(string.Format(WARNING_FORMAT, e.Source, e.Message));
				MessageLogger.Instance.WriteLog(sendFileLogName, "ERROR", "[" + _MsgFileName + "]送信中にエラーが発生しました " + e.Message);
				throw e;
			}
			//}
		}

		// 2020.08.28 Mod H.Taira@COSMO Start
		//private string GetFileName(BaseMsgData msgData)
		private string GetFileName(BaseMsgData msgData, IDbConnection connection)
		// 2020.08.28 Mod H.Taira@COSMO End
		{
			const string FILE_NAME_FORMAT = "H{0}{1}{2}{3}{4:d4}.dat";

			return string.Format(
					FILE_NAME_FORMAT,
					msgData.Request.SrcSysCode,
					msgData.Request.DstSysCode,
					msgData.Request.ControlCode,
					DateTime.Now.ToString("yyyyMMdd"),
					// 2020.08.28 Mod H.Taira@COSMO Start
					//GetFileSeq(msgData.Request.RequestType)
					GetFileSeq(msgData.Request.RequestType, connection)
					// 2020.08.28 Mod H.Taira@COSMO End
					);
		}

		/// <summary>
		/// 電文ログファイル名取得
		/// </summary>
		/// <param name="logDateTime"></param>
		/// <param name="telegraphKind"></param>
		/// <param name="sendOrRecv"></param>
		/// <returns></returns>
		private String GetGWLogFileName(BaseMsgData msgData, DateTime logDateTime)
		{
			const string LOG_FILENAME_FORMAT = "HS{0}{1}{2:yyyyMMdd}.log";
			return String.Format(
					LOG_FILENAME_FORMAT,
					msgData.Request.SrcSysCode,
					msgData.Request.DstSysCode,
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

		private void CreateFile(string pBasePath, string pDirName, string pFileName, string pText)
		{
			string fullDir = Path.Combine(pBasePath, pDirName);

			if (!Directory.Exists(fullDir))
			{
				Directory.CreateDirectory(fullDir);
				if (!Directory.Exists(fullDir))
				{
					new Exception("ディレクトリの作成に失敗しました。" + fullDir);
				}
			}

			string fileFullName = Path.Combine(fullDir, pFileName);
			using (StreamWriter sw = new StreamWriter(fileFullName, false, MessageLogger.Instance.Enc))
			{
				sw.Write(pText);
			}
		}

		private void CreateIndexFile(string pBasePath, string pFileName, BaseMsgData msgData)
		{
			CreateFile(
				pBasePath,
				Path.Combine(msgData.Request.DirName, DIR_INDEX),
				pFileName,
				string.Empty
			);
		}

		private void CreateDataFile(string pBasePath, string pFileName, BaseMsgData msgData)
		{
			CreateFile(
				pBasePath,
				Path.Combine(msgData.Request.DirName, DIR_DATA),
				pFileName,
				msgData.Request.TextMessage
			);
		}

		// 2020.08.28 Mod H.Taira@COSMO Start
		//private int GetFileSeq(string pRequestType)
		private int GetFileSeq(string pRequestType, IDbConnection connection)
		// 2020.08.28 Mod H.Taira@COSMO End
		{
			// 初期化
			// 2020.08.28 Del H.Taira@COSMO Start
			//int _Cnt = 0;
			// 2020.08.28 Del H.Taira@COSMO End
			int seq = 0;
			string appNameSeq = string.Empty;

			// 予約・予約変更・予約取消
			if (pRequestType == RQRISDBConst.REQUEST_TYPE_RESERVE
					|| pRequestType == RQRISDBConst.REQUEST_TYPE_RESERVE_UPDATE
					|| pRequestType == RQRISDBConst.REQUEST_TYPE_RESERVE_CANCEL)
			{
				appNameSeq = "FILESEQ_RTORDER";
			}

			// 受付・受付キャンセル
			if (pRequestType == RQRISDBConst.REQUEST_TYPE_RECEIPT
					|| pRequestType == RQRISDBConst.REQUEST_TYPE_RECEIPT_CANCEL)
			{
				appNameSeq = "FILESEQ_CHECKIN";
			}

			// 実施・実施変更・実施中止
			if (pRequestType == RQRISDBConst.REQUEST_TYPE_EXAM
					|| pRequestType == RQRISDBConst.REQUEST_TYPE_EXAM_UPDATE
					|| pRequestType == RQRISDBConst.REQUEST_TYPE_EXAM_CANCEL)
			{
				appNameSeq = "FILESEQ_COST";
			}

			// 患者情報要求
			if (pRequestType == RQRISDBConst.REQUEST_TYPE_PATIENT_REQUEST)
			{
				appNameSeq = "FILESEQ_PATIENTREQ";
			}

			// 受付・受付キャンセル
			if (pRequestType == RQRISDBConst.REQUEST_TYPE_RECEIPT_RIS
					|| pRequestType == RQRISDBConst.REQUEST_TYPE_RECEIPT_CANCEL_RIS)
			{
				appNameSeq = "FILESEQ_CHECKIN_RIS";
			}

			// 実施・実施変更・実施中止
			if (pRequestType == RQRISDBConst.REQUEST_TYPE_EXAM_RIS
					|| pRequestType == RQRISDBConst.REQUEST_TYPE_EXAM_UPDATE_RIS
					|| pRequestType == RQRISDBConst.REQUEST_TYPE_EXAM_CANCEL_RIS)
			{
				appNameSeq = "FILESEQ_COST_RIS";
			}

			// 依頼再送
			if (pRequestType == RQRISDBConst.REQUEST_TYPE_ORDER_REQUEST_RIS)
			{
				appNameSeq = "FILESEQ_ORDERREQ_RIS";
			}

			// 2020.08.28 Del H.Taira@COSMO Start
			//seq = ConfigurationManager.AppSettings[appNameSeq].StringToInt32();
			//_Cnt = seq;

			//if (seq >= 9999)
			//{
			//	_Cnt = 1;
			//}
			//else
			//{
			//	_Cnt++;
			//}

			//Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			//config.AppSettings.Settings[appNameSeq].Value = _Cnt.ToString();
			//config.Save();

			//ConfigurationManager.RefreshSection("appSettings");
			// 2020.08.28 Del H.Taira@COSMO End
			// 2020.08.28 Add H.Taira@COSMO Start
			seq = GetSEQUENCE(connection, appNameSeq);
			// 2020.08.28 Add H.Taira@COSMO End
			return seq;
		}

		// 2020.08.28 Add H.Taira@COSMO Start
		/// <summary>
		/// シーケンス取得
		/// </summary>
		/// <returns></returns>
		/// <remarks></remarks>
		private int GetSEQUENCE(IDbConnection cn, string seqName)
		{
			string SQL_SELECT = "select " + seqName + ".Nextval AS SEQ from dual ";

			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.CommandText = SQL_SELECT;
				MiscUtils.WriteDbCommandLogForLog4net(command, _log);

				IDataReader reader = command.ExecuteReader();
				try
				{
					if (!reader.Read())
					{
						throw new MsgAnomalyException(string.Format(
						"シーケンス取得処理でSQLのエラーが発生しました"));
					}

					MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

					int seq = reader.GetStringByDBInt32("SEQ").StringToInt32();

					return seq;
				}
				finally
				{
					reader.Close();

				}
			}
			// 2020.08.28 Add H.Taira@COSMO End
		}
	}
}
