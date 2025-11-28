using RISBizLibrary.Data;
using RISBizLibrary.Updater.Table.FROMHISINFO;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.ChangeWard;

namespace RISBizLibrary.Updater.Table
{
	internal class FROMHISINFOUpdaterChangeWard : FROMHISINFOUpdater
	{
		protected override FROMHISINFOState GetState(BaseMsgData data)
		{
			ChangeWardAggregate d = ((IChangeWard)(data.Request.Body)).ChangeWard;

			if (d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_CHANGEWARD)
			{
				return new FROMHISINFOStateChangeWard(data as BaseMsgData);
			}
			throw new MsgAnomalyException(string.Format(
				"想定していない電文種別を受信しました。電文種別={0}",
					d.DENBUN_SYBT.TrimData));
		}
	}
}
