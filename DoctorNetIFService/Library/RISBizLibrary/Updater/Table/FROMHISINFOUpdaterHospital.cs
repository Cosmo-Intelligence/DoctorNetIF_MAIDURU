using RISBizLibrary.Data;
using RISBizLibrary.Updater.Table.FROMHISINFO;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.Hospitalize;

namespace RISBizLibrary.Updater.Table
{
	internal class FROMHISINFOUpdaterHospital : FROMHISINFOUpdater
	{
		protected override FROMHISINFOState GetState(BaseMsgData data)
		{
			HospitalizeAggregate d = ((IHospitalize)(data.Request.Body)).Hospitalize;
			if (d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_HOSPITALIZE
				|| d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_HOSPITALIZE_CANCEL)
			{
				return new FROMHISINFOStateHospitalize(data as BaseMsgData);
			}
			throw new MsgAnomalyException(string.Format(
				"想定していない電文種別を受信しました。電文種別={0}",
					d.DENBUN_SYBT.TrimData));
		}
	}
}
