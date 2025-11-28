using RISBizLibrary.Download.Model;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.LeaveHospitalize;

namespace RISBizLibrary.Download.Model
{
	class MessageHandlerLeaveHospital : MessageHandler
	{

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MessageHandlerLeaveHospital(): base()
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
			_log.Info("退院情報を受信しました");
			LeaveHospitalizeMsgDBSetter dbsetter = new LeaveHospitalizeMsgDBSetter();
			return dbsetter.SetDataToDatabase(msg);
		}
	
		/// <summary>
		/// メッセージファクトリに登録する
		/// </summary>
		protected override void RegistFactory()
		{
			MsgFactory.Instance.RegistMsg(typeof(LeaveHospitalizeMsg));
		}

		public override string[] GetDenbunSybt()
		{
			return new[]
			{
				MsgConst.DENBUN_SYBT_LEAVE_HOSPITAL,
				MsgConst.DENBUN_SYBT_LEAVE_HOSPITAL_CANCEL
			};
		}

	}
}
