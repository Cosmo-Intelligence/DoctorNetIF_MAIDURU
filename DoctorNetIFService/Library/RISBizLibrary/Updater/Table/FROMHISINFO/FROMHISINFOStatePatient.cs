using RISBizLibrary.Data;
using RISBizLibrary.Updater.Table.FROMHISINFO;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.Patient;

namespace RISBizLibrary.Updater.Table.FROMHISINFO
{
	public class FROMHISINFOStatePatient : FROMHISINFOState
	{

		public FROMHISINFOStatePatient(BaseMsgData data)
			: base(data)
		{

		}

		public override string GetRIS_ID()
		{
			return "";
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

		public override string GetMESSAGEID1()
		{
			if (Data == null)
			{
				return "";
			}

			PatientAggregate d = ((IPatient)(Data.Request.Body)).Patient;
			return d.PT_ID.TrimData;
		}

		public override string GetMESSAGEID2()
		{
			return "";
		}

	}
}
