using RISBizLibrary.Data;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.LeaveHospitalize;

namespace RISBizLibrary.Updater.Table.FROMHISINFO
{
	public class FROMHISINFOStateLeaveHospitalize : FROMHISINFOState
	{

		public FROMHISINFOStateLeaveHospitalize(BaseMsgData data)
			: base(data)
		{

		}

		public override string GetRIS_ID()
		{
			return "";
		}

		public override string GetMESSAGETYPE()
		{
			LeaveHospitalizeAggregate d = ((ILeaveHospitalize)(Data.Request.Body)).LeaveHospitalize;
			if (d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_LEAVE_HOSPITAL)
			{
				return RQRISDBConst.FROMHISINFO_MESSAGETYPE_LEAVE_HOSPITAL;
			}
			if (d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_LEAVE_HOSPITAL_CANCEL)
			{
				return RQRISDBConst.FROMHISINFO_MESSAGETYPE_LEAVE_HOSPITAL_CANCEL;
			}
			return "";
		}

		public override string GetDeleteMESSAGETYPE()
		{
			string[] value = new string[]
				{
					"'" + RQRISDBConst.FROMHISINFO_MESSAGETYPE_LEAVE_HOSPITAL + "'",
					"'" + RQRISDBConst.FROMHISINFO_MESSAGETYPE_LEAVE_HOSPITAL_CANCEL + "'"
				};
			return string.Join(",", value);
		}

		public override string GetMESSAGEID1()
		{
			if (Data == null)
			{
				return "";
			}

			LeaveHospitalizeAggregate hospital = ((ILeaveHospitalize)(Data.Request.Body)).LeaveHospitalize;
			return hospital.PT_ID.TrimData;
		}

		public override string GetMESSAGEID2()
		{
			return "";
		}

	}
}
