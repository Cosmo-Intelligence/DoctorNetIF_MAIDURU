using RISBizLibrary.Data;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.Patient;

namespace RISBizLibrary.Updater.Table.TOSYNAPSEINFO
{
	public class TOSYNAPSEINFOStatePatient : TOSYNAPSEINFOState
	{

		public TOSYNAPSEINFOStatePatient(BaseMsgData data)
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

		public override string GetMESSAGEORDERID()
		{
			return "";
		}

		public override string GetMESSAGEPATIENTID()
		{
			PatientAggregate d = ((IPatient)(Data.Request.Body)).Patient;
			return d.PT_ID.TrimData;
		}

	}
}
