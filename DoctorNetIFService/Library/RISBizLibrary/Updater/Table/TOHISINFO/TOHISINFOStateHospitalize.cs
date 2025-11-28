using RISBizLibrary.Data;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.Hospitalize;

namespace RISBizLibrary.Updater.Table.TOHISINFO
{
	public class TOHISINFOStateHospitalize : TOHISINFOState
	{

		public TOHISINFOStateHospitalize(BaseMsgData data)
			: base(data)
		{

		}

		public override string GetMESSAGETYPE()
		{
			HospitalizeAggregate d = ((IHospitalize)(Data.Request.Body)).Hospitalize;
			if (d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_HOSPITALIZE)
			{
				return RQRISDBConst.FROMHISINFO_MESSAGETYPE_HOSPITALIZE;
			}
			return "";
		}

		public override string GetDeleteMESSAGETYPE()
		{
			string[] value = new string[]
				{
					"'" + RQRISDBConst.FROMHISINFO_MESSAGETYPE_HOSPITALIZE + "'"
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
			HospitalizeAggregate d = ((IHospitalize)(Data.Request.Body)).Hospitalize;
			return d.PT_ID.TrimData;
		}

	}
}
