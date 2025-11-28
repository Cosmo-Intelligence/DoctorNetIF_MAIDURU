using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Patient;

namespace RISBizLibrary.Download.Model
{
	class MessageHandlerPatient : MessageHandler
	{

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MessageHandlerPatient(): base()
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
			_log.Info("患者情報を受信しました");
			PatientInfoMsgDBSetter dbsetter = new PatientInfoMsgDBSetter();
			return dbsetter.SetDataToDatabase(msg);
		}
	
		/// <summary>
		/// メッセージファクトリに登録する
		/// </summary>
		protected override void RegistFactory()
		{
			MsgFactory.Instance.RegistMsg(typeof(PatientMsg));
		}

		public override string[] GetDenbunSybt()
		{
			return new[]
			{
				MsgConst.DENBUN_SYBT_PATIENT
			};
		}

	}
}
