using RISBizLibrary.Data;
using RISBizLibrary.Updater.Table.FROMHISINFO;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.ChangeSection;

namespace RISBizLibrary.Updater.Table
{
	internal class FROMHISINFOUpdaterChangeSection : FROMHISINFOUpdater
	{
		protected override FROMHISINFOState GetState(BaseMsgData data)
		{
			ChangeSectionAggregate d = ((IChangeSection)(data.Request.Body)).ChangeSection;

			if (d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_CHANGESECTION)
			{
				return new FROMHISINFOStateChangeSection(data as BaseMsgData);
			}
			throw new MsgAnomalyException(string.Format(
				"想定していない電文種別を受信しました。電文種別={0}",
					d.DENBUN_SYBT.TrimData));
		}
	}
}
