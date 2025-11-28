using RISCommonLibrary.Lib.Msg.ChangeSection;
using RISCommonLibrary.Lib.Msg.ChangeWard;
using RISCommonLibrary.Lib.Msg.ExamInfo;
using RISCommonLibrary.Lib.Msg.Hospitalize;
using RISCommonLibrary.Lib.Msg.LeaveHospitalize;
using RISCommonLibrary.Lib.Msg.OrderInfo;
using RISCommonLibrary.Lib.Msg.OrderRequestInfo;
using RISCommonLibrary.Lib.Msg.Patient;
using RISCommonLibrary.Lib.Msg.PatientRequest;
using RISCommonLibrary.Lib.Msg.ReceiptInfo;

namespace RISCommonLibrary.Lib.Msg
{
	/// <summary>
	/// 電文ファクトリに登録
	/// </summary>
	public class RegistMsgToFactory
	{
		/// <summary>
		/// 電文ファクトリに登録
		/// </summary>
		public static void Regist()
		{
			MsgFactory.Instance.RegistMsg(typeof(HospitalizeMsg));
			MsgFactory.Instance.RegistMsg(typeof(ChangeWardMsg));
			MsgFactory.Instance.RegistMsg(typeof(ChangeSectionMsg));
			MsgFactory.Instance.RegistMsg(typeof(LeaveHospitalizeMsg));

			MsgFactory.Instance.RegistMsg(typeof(PatientRequestMsg));
			MsgFactory.Instance.RegistMsg(typeof(PatientMsg));

			MsgFactory.Instance.RegistMsg(typeof(HISRISReceiptInfoMsg));
			MsgFactory.Instance.RegistMsg(typeof(HISRISExamMsg));

			MsgFactory.Instance.RegistMsg(typeof(HISRISOrderMsg));

			MsgFactory.Instance.RegistMsg(typeof(HISRISOrderRequestMsg));
		}
	}
}
