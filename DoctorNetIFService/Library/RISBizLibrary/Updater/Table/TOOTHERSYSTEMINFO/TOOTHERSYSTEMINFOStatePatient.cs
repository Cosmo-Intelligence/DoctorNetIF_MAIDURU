using RISBizLibrary.Data;
using RISBizLibrary.Download.Data;
using RISBizLibrary.Updater.Table.TOOTHERSYSTEMINFO;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.OrderInfo;
using RISCommonLibrary.Lib.Msg.Common.Patient;

namespace RISBizLibrary.Updater.Table.TOSYNAPSEINFO
{
	public class TOOTHERSYSTEMINFOStatePatient : TOOTHERSYSTEMINFOState
	{
		public override string GetRIS_ID()
		{
			return "";
		}

		public TOOTHERSYSTEMINFOStatePatient(BaseMsgData data)
			: base(data)
		{

		}

		public override string GetMESSAGETYPE()
		{
			PatientAggregate d = ((IPatient)(Data.Request.Body)).Patient;
			if (d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_PATIENT)
			{
				return RQRISDBConst.FROMHISINFO_MESSAGETYPE_PATIENT;
			}
			return "";
		}

		public override string GetDeleteMESSAGETYPE()
		{
			string[] value = new string[]
				{
					"'" + RQRISDBConst.FROMHISINFO_MESSAGETYPE_PATIENT + "'"
				};
			return string.Join(",", value);
		}

		public override string GetREQUESTUSER()
		{
			return "RIS_PAT";
		}

		public override string GetREQUESTTERMINALID()
		{
			return "RISSERVER";
		}
		public override string GetMESSAGEID1()
		{
			PatientAggregate d = ((IPatient)(Data.Request.Body)).Patient;
			return d.PT_ID.TrimData;
		}

		public override string GetMESSAGEID2()
		{
			return "";
		}

	}
}
