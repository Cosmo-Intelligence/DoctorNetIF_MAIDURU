using RISBizLibrary.Data;
using RISBizLibrary.Updater.Table.FROMHISINFO;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.Hospitalize;

namespace RISBizLibrary.Updater.Table.FROMHISINFO
{
	public class FROMHISINFOStateHospitalize : FROMHISINFOState
	{

		public FROMHISINFOStateHospitalize(BaseMsgData data)
			: base(data)
		{

		}

		public override string GetRIS_ID()
		{
			return "";
		}

		public override string GetMESSAGETYPE()
		{
			HospitalizeAggregate hospital = ((IHospitalize)(Data.Request.Body)).Hospitalize;
			if (hospital.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_HOSPITALIZE)
			{
				return RQRISDBConst.FROMHISINFO_MESSAGETYPE_HOSPITALIZE;
			}
			if (hospital.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_HOSPITALIZE_CANCEL)
			{
				return RQRISDBConst.FROMHISINFO_MESSAGETYPE_HOSPITALIZE_CANCEL;
			}
			return "";
		}

		public override string GetDeleteMESSAGETYPE()
		{
			string[] value = new string[]
				{
					"'" + RQRISDBConst.FROMHISINFO_MESSAGETYPE_HOSPITALIZE + "'",
					"'" + RQRISDBConst.FROMHISINFO_MESSAGETYPE_HOSPITALIZE_CANCEL + "'"
				};
			return string.Join(",", value);
		}

		public override string GetMESSAGEID1()
		{
			if (Data == null)
			{
				return "";
			}

			HospitalizeAggregate hospital = ((IHospitalize)(Data.Request.Body)).Hospitalize;
			return hospital.PT_ID.TrimData;
		}

		public override string GetMESSAGEID2()
		{
			return "";
		}

	}
}
