using RISBizLibrary.Download.Model;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.ChangeSection;

namespace RISBizLibrary.Download.Model
{
	class MessageHandlerChangeSection : MessageHandler
	{

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MessageHandlerChangeSection(): base()
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
			_log.Info("転科情報を受信しました");
			ChangeSectionMsgDBSetter dbsetter = new ChangeSectionMsgDBSetter();
			return dbsetter.SetDataToDatabase(msg);
		}
	
		/// <summary>
		/// メッセージファクトリに登録する
		/// </summary>
		protected override void RegistFactory()
		{
			MsgFactory.Instance.RegistMsg(typeof(ChangeSectionMsg));
		}

		public override string[] GetDenbunSybt()
		{
			return new[]
			{
				MsgConst.DENBUN_SYBT_CHANGESECTION
			};
		}

	}
}
