using RISBizLibrary.Download.Model;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Hospitalize;

namespace RISBizLibrary.Download.Model
{
	class MessageHandlerHospital : MessageHandler
	{

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MessageHandlerHospital(): base()
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
			_log.Info("入院情報を受信しました");
			HospitalMsgDBSetter dbsetter = new HospitalMsgDBSetter();
			return dbsetter.SetDataToDatabase(msg);
		}
	
		/// <summary>
		/// メッセージファクトリに登録する
		/// </summary>
		protected override void RegistFactory()
		{
			MsgFactory.Instance.RegistMsg(typeof(HospitalizeMsg));
		}

		public override string[] GetDenbunSybt()
		{
			return new[]
			{
				MsgConst.DENBUN_SYBT_HOSPITALIZE,
				MsgConst.DENBUN_SYBT_HOSPITALIZE_CANCEL
			};
		}

	}
}
