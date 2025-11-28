using System;
using System.Data;
using log4net;
using RISBizLibrary.Data;
using RISBizLibrary.Upload.Data;
using RISCommonLibrary.Lib.Msg;

namespace RISBizLibrary.Upload.MessageCreator
{
	internal abstract class BaseMsgCreator: IMessageCreator, IDisposable
	{
		#region field

		/// <summary>
		/// tcpクライアントクラス
		/// </summary>
		private FileUploader _fileUploader;

		/// <summary>
		/// ログ
		/// </summary>
		protected static readonly log4net.ILog _log = log4net.LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#region delegate

		/// <summary>
		/// 接続・切断要求のためのメッセージデータ作成
		/// </summary>
		/// <returns></returns>
		public delegate BaseMsgData CreateMsgDataForConnection();
		
		#endregion

		#endregion

		#region property

		/// <summary>
		/// ログ出力用名前
		/// </summary>
		public abstract string NameForLog
		{
			get;
		}

		protected ILog Log4NetLog
		{
			get
			{
				return _log;
			}
		}

		#region IMessageCreator メンバ

		#endregion

		#endregion

		#region constractor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public BaseMsgCreator()
		{
			_fileUploader = new FileUploader();
		}
		#endregion

		#region method
		
		#region IMessageCreator メンバ

		public abstract string[] GetRequestTypes();

		public abstract BaseMsg CreateMsg(ToHisInfo toHisInfo, IDbConnection cnRis, string pRISID, string pAllRisId);

		public abstract BaseMsgData CreateMsgData();

		// 2020.08.28 Mod H.Taira@COSMO Start
		//public void Send(BaseMsgData msgData )
		//{
		//	//if (_fileUploader == null)
		//	//{
		//	//	throw new RISIfSocketException("ソケット未接続です");
		//	//}
		//	_fileUploader.SendRecv(msgData);
		//}

		public void Send(BaseMsgData msgData, IDbConnection connection)
		{
			//if (_fileUploader == null)
			//{
			//	throw new RISIfSocketException("ソケット未接続です");
			//}
			_fileUploader.SendRecv(msgData, connection);
		}
		// 2020.08.28 Mod H.Taira@COSMO End

		#region private
		
		#endregion

		#endregion

		#endregion

		#region IDisposable メンバ

		public void Dispose()
		{
			((IDisposable)this).Dispose();
		}

		#endregion

		#region IDisposable メンバ

		void IDisposable.Dispose()
		{
		}

		#endregion
	}
}
