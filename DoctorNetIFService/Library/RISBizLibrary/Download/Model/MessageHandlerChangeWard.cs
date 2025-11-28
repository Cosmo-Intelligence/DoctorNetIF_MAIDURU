using RISBizLibrary.Download.Model;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.ChangeWard;

namespace RISBizLibrary.Download.Model
{
	class MessageHandlerChangeWard : MessageHandler
	{

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MessageHandlerChangeWard(): base()
		{

		}

		#endregion

		#region method

		#endregion

		/// <summary>
		/// DB処理を任せるクラスを生成する
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
		protected override bool SetDBSetter(BaseMsg msg)
		{
			_log.Info("転棟情報を受信しました");
			ChangeWardMsgDBSetter dbsetter = new ChangeWardMsgDBSetter();
			return dbsetter.SetDataToDatabase(msg);
		}
	
		/// <summary>
		/// メッセージファクトリに登録する
		/// </summary>
		protected override void RegistFactory()
		{
			MsgFactory.Instance.RegistMsg(typeof(ChangeWardMsg));
		}

		public override string[] GetDenbunSybt()
		{
			return new[]
			{
				MsgConst.DENBUN_SYBT_CHANGEWARD
			};
		}

	}
}
