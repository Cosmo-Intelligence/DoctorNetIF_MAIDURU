using RISBizLibrary.Data;
using RISBizLibrary.Updater.Table.FROMHISINFO;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.LeaveHospitalize;

namespace RISBizLibrary.Updater.Table
{
	internal class FROMHISINFOUpdaterLeaveHospital : FROMHISINFOUpdater
	{
		protected override FROMHISINFOState GetState(BaseMsgData data)
		{
			LeaveHospitalizeAggregate d = ((ILeaveHospitalize)(data.Request.Body)).LeaveHospitalize;
			if (d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_LEAVE_HOSPITAL
				|| d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_LEAVE_HOSPITAL_CANCEL)
			{
				return new FROMHISINFOStateLeaveHospitalize(data as BaseMsgData);
			}
			throw new MsgAnomalyException(string.Format(
				"想定していない電文種別を受信しました。電文種別={0}",
					d.DENBUN_SYBT.TrimData));
		}
	}
}
