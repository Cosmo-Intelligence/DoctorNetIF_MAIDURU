using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using RISBizLibrary.Utils;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Utils;
using RISBizLibrary.Data;
using RISBizLibrary.Upload.MessageCreator;
using RISBizLibrary.Upload.Data;

namespace RISBizLibrary.Upload
{
	internal class ToHisInfoSender : IDisposable
	{
		private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// 古いログを削除するクラス
		/// </summary>
		private DeleteOldLogHelper _deleteOldLogHelper = new DeleteOldLogHelper();

		/// <summary>
		/// メッセージ作成クラスファクトリ
		/// </summary>
		private Dictionary<string, MessageCreator.IMessageCreator> _msgCreatorFactory;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ToHisInfoSender()
		{
			_msgCreatorFactory = new Dictionary<string, IMessageCreator>();
			SetDataMessageCreatorFactory(_msgCreatorFactory);
		}

		/// <summary>
		/// ソケット接続
		/// </summary>
		/// <param name="requestType"></param>
		public void ConnectTcp(string requestType)
		{
			IMessageCreator messageCreator = GetMessageCreator(requestType);
			if (messageCreator == null)
			{
				throw new RequestTypeNotDefineException(string.Format("未定義のREQUESTTYPEです={0}", requestType));
			}
			//messageCreator.ConnectTcp();
		}

		/// <summary>
		/// ソケット切断
		/// </summary>
		/// <param name="requestType"></param>
		public void DisConnectTcp(string requestType)
		{
			IMessageCreator messageCreator = GetMessageCreator(requestType);
			if (messageCreator == null)
			{
				throw new RequestTypeNotDefineException(string.Format("未定義のREQUESTTYPEです={0}", requestType));
			}
			//messageCreator.DisConnectTcp();
		}

		/// <summary>
		/// 接続要求電文
		/// </summary>
		public void RequestOpen(string requestType)
		{
			IMessageCreator messageCreator = GetMessageCreator(requestType);
			if (messageCreator == null)
			{
				throw new RequestTypeNotDefineException(string.Format("未定義のREQUESTTYPEです={0}", requestType));
			}
			//messageCreator.RequestOpen();
		}

		/// <summary>
		/// 切断要求電文
		/// </summary>
		/// <param name="requestType"></param>
		public void RequestClose(string requestType)
		{
			IMessageCreator messageCreator = GetMessageCreator(requestType);
			if (messageCreator == null)
			{
				throw new RequestTypeNotDefineException(string.Format("未定義のREQUESTTYPEです={0}", requestType));
			}
			//messageCreator.RequestClose();
		}

		/// <summary>
		/// 送信
		/// </summary>
		/// <param name="target"></param>
		/// <param name="connectionRis"></param>
		/// <param name="connectionRtRis"></param>
		public void Send(ToHisInfo target, IDbConnection connectionRis)
		{
			BaseMsgCreator messageCreator = null;
			BaseSendMsgData msgData = null;
			_log.InfoFormat("IF処理開始します。RequestID={0}", target.RequestID);
			try
			{
				_log.Debug("古いログファイルを削除します");
				_deleteOldLogHelper.DeleteOldLog();

				_log.Debug("電文作成者を作成します");
				messageCreator = GetMessageCreator(target.RequestType) as BaseMsgCreator;
				if (messageCreator == null)
				{
					throw new RequestTypeNotDefineException(string.Format("未定義のREQUESTTYPEです={0}", target.RequestType));
				}

				_log.InfoFormat("電文を作成します。種別={0}", target.RequestType);
				msgData = messageCreator.CreateMsgData() as BaseSendMsgData;
				string risId = string.Empty;
				string allRisId = string.Empty;
				BaseMsg msg = messageCreator.CreateMsg(target, connectionRis, risId, allRisId);
				msgData.Request = msg;

				_log.Info("送信処理を行います");
				SendInner(target, connectionRis, messageCreator, msgData);

				_log.Info("データベース更新処理を行います");
				UpdateDBNormal(target, connectionRis, msgData);
				ToHisInfoHelper.InsertToSynapseInfo(target, connectionRis);
				_log.InfoFormat("IF処理終了します。RequestID={0}", target.RequestID);
			}
			catch (RequestTypeNotDefineException eRequest) //該当のTOHISINFOのRequestTypeが未定義
			{
				_log.Error(eRequest.Message);
				_log.Info("データベース更新処理を行います");
				UpdateDBRequestTypeNotDefine(target, connectionRis);
				_log.InfoFormat("IF処理エラー終了します。RequestID={0}", target.RequestID);
			}
			catch (NodeOparationException eNode) //電文組み立て時エラー
			{
				BaseNode n = eNode.Node;
				_log.Error(GetErrMessageForNodeErr(eNode));
				_log.Info("データベース更新処理を行います");
				UpdateDBNodeOparation(target, connectionRis, msgData);
				_log.InfoFormat("IF処理エラー終了します。RequestID={0}", target.RequestID);
			}
			catch (Exception ex)
			{
				string errMessage = MiscUtils.BuildErrMessage(ex, null);
				_log.ErrorFormat("エラーが発生しました。{0}", errMessage);
				_log.Info("データベース更新処理を行います");
				UpdateDBException(target, connectionRis, msgData);
				DisconectBySysException(ex, messageCreator); //システム例外はソケット切断する
				_log.InfoFormat("IF処理エラー終了します。RequestID={0}", target.RequestID);
			}
		}

		/// <summary>
		/// 送信
		/// </summary>
		/// <param name="target"></param>
		/// <param name="connection"></param>
		public void SendInner(ToHisInfo target, IDbConnection connection,
				BaseMsgCreator messageCreator, BaseSendMsgData msgData)
		{
			int sendRetryCount = ConfigurationManager.AppSettings["SendRetryCount"].StringToInt32();

			int retryCount = 0;
			while (true)
			{
				try
				{
					msgData.Request.RequestType = target.RequestType;
					// 2020.08.28 Mod H.Taira@COSMO Start
					//messageCreator.Send(msgData);
					messageCreator.Send(msgData, connection);
					// 2020.08.28 Mod H.Taira@COSMO End
					//正常終了
					return;
				}
				catch (IOException eIO)
				{
					if (!(eIO.InnerException is SocketException))
					{
						throw;
					}
					string errMessage = MiscUtils.BuildErrMessage(eIO, null);
					_log.ErrorFormat("IOエラーが発生しました。{0}", errMessage);

					retryCount = IncRetryCountAndDisConnect(retryCount, messageCreator);
					if (sendRetryCount < retryCount)
					{
						throw;
					}
					_log.WarnFormat("リトライを行います。{0}回目", retryCount);
				}
			}
		}

		/// <summary>
		/// リトライカウント増加と切断処理
		/// </summary>
		/// <param name="currentRetryCount"></param>
		/// <param name="messageCreator"></param>
		/// <returns></returns>
		private int IncRetryCountAndDisConnect(int currentRetryCount, BaseMsgCreator messageCreator)
		{
			int retrySleep = ConfigurationManager.AppSettings["SendRetrySleep"].StringToInt32();
			_log.DebugFormat("リトライスリープします={0}", retrySleep);
			Thread.Sleep(retrySleep);

			return ++currentRetryCount;
		}

		/// <summary>
		/// TOHISINFO.RequestTypeによって電文作成クラスを返す
		/// </summary>
		/// <param name="requestType"></param>
		/// <returns></returns>
		private IMessageCreator GetMessageCreator(string requestType)
		{
			if (!_msgCreatorFactory.ContainsKey(requestType))
			{
				throw new RequestTypeNotDefineException(String.Format(
					"ToHisInfoテーブルのRequestTypeに想定していない値が設定されています={0}", requestType));
			}
			return _msgCreatorFactory[requestType];
		}

		/// <summary>
		/// メッセージファクトリに登録
		/// </summary>
		/// <param name="factory"></param>
		private void SetDataMessageCreatorFactory(Dictionary<string, MessageCreator.IMessageCreator> factory)
		{
			IMessageCreator patientReqInfoCreator = new PatientReqInfoMsgCreator();
			foreach (string requestType in patientReqInfoCreator.GetRequestTypes())
			{
				factory.Add(requestType, patientReqInfoCreator);
			}

			IMessageCreator receiptCreator = new ReceiptInfoMsgCreator();
			foreach (string requestType in receiptCreator.GetRequestTypes())
			{
				factory.Add(requestType, receiptCreator);
			}

			IMessageCreator examInfoCreator = new ExamInfoMsgCreator();
			foreach (string requestType in examInfoCreator.GetRequestTypes())
			{
				factory.Add(requestType, examInfoCreator);
			}

			IMessageCreator orderReqCreator = new OrderReqInfoMsgCreator();
			foreach (string requestType in orderReqCreator.GetRequestTypes())
			{
				factory.Add(requestType, orderReqCreator);
			}
		}

		#region DB更新

		/// <summary>
		/// 正常更新時
		/// </summary>
		/// <param name="target"></param>
		/// <param name="connection"></param>
		/// <param name="msgData"></param>
		private void UpdateDBNormal(ToHisInfo target, IDbConnection connection, BaseSendMsgData msgData)
		{
			_log.Debug("UpdateDB開始します");
			ToHisInfoHelper.SetDataFromResponseMsg(target, msgData);
			ToHisInfoHelper.UpdateToDB(target, connection, msgData);
			_log.Debug("UpdateDB終了しました");
		}

		/// <summary>
		/// TOHISINFO.RequestType未定義エラー更新時
		/// </summary>
		/// <param name="target"></param>
		/// <param name="connection"></param>
		private void UpdateDBRequestTypeNotDefine(ToHisInfo target, IDbConnection connection)
		{
			_log.Debug("UpdateDBRequestTypeNotDefine開始します");
			ToHisInfoHelper.SetDataFromResponseMsgByRequestTypeNotDefine(target);
			ToHisInfoHelper.UpdateToDBRequestTypeNotDefine(target, connection);
			_log.Debug("UpdateDBRequestTypeNotDefine終了しました");
		}

		/// <summary>
		/// 電文組み立てエラー更新時
		/// </summary>
		/// <param name="target"></param>
		/// <param name="connection"></param>
		/// <param name="msgData"></param>
		private void UpdateDBNodeOparation(ToHisInfo target, IDbConnection connection, BaseSendMsgData msgData)
		{
			_log.Debug("UpdateDBNodeOparation開始します");
			ToHisInfoHelper.SetDataFromResponseMsg(target, msgData);
			ToHisInfoHelper.UpdateToDB(target, connection, msgData);
			_log.Debug("UpdateDBNodeOparation開始します");
		}

		/// <summary>
		/// 想定外例外時DB更新
		/// </summary>
		/// <param name="target"></param>
		/// <param name="connection"></param>
		/// <param name="msgData"></param>
		private void UpdateDBException(ToHisInfo target, IDbConnection connection, BaseSendMsgData msgData)
		{
			_log.Debug("UpdateDBException開始します");
			ToHisInfoHelper.SetDataFromResponseMsgByException(target, msgData);
			ToHisInfoHelper.UpdateToDB(target, connection, msgData);
			_log.Debug("UpdateDBException開始します");
		}
		#endregion

		/// <summary>
		/// 電文組み立てエラーメッセージ取得
		/// </summary>
		/// <param name="eNode"></param>
		/// <returns></returns>
		private string GetErrMessageForNodeErr(NodeOparationException eNode)
		{
			BaseNode n = eNode.Node;
			if (n != null)
			{
				return string.Format("メッセージフォーマットエラーです。{0},StartPos={1},Name={2},Path={3},Size={4}", eNode.Message,
					n.GetStartPos(), n.NameJ, n.Path, n.Size);
			}
			return string.Format("メッセージフォーマットエラーです。{0", eNode.Message);
		}

		/// <summary>
		/// システム例外のときにソケット接続を切断する
		/// </summary>
		/// <param name="e"></param>
		/// <param name="messageCreator"></param>
		private void DisconectBySysException(Exception e, BaseMsgCreator messageCreator)
		{
			if (e is RISIfExceptionUserException) //ユーザ例外はソケット切断しない
			{
				return;
			}
			if (messageCreator == null)
			{
				return;
			}
		}

		#region IDisposable メンバ

		public void Dispose()
		{
			if (_msgCreatorFactory == null)
			{
				return;
			}
			#region ディクショナリの値コレクションから重複しているMessageCreatorを取り除いたリストを作成
			Dictionary<string, IMessageCreator>.ValueCollection vc = _msgCreatorFactory.Values;
			IEnumerable<IMessageCreator> messageCreatorList = from mc in vc
															  group mc by mc into mcGroup
															  select mcGroup.First();
			#endregion
			foreach (IMessageCreator item in messageCreatorList)
			{
				BaseMsgCreator creator = item as BaseMsgCreator;
				if (creator == null)
				{
					continue;
				}
				try
				{
				}
				catch (Exception e)
				{ //例外発生してもここでは握りつぶしておく
					string errMessage = MiscUtils.BuildErrMessage(e, null);
					_log.ErrorFormat("終了処理でエラーが発生しました。{0}", errMessage);
				}
				creator.Dispose();
			}
		}

		#endregion
	}
}
