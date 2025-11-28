using RISBizLibrary.Data;
using RISBizLibrary.Updater.Table.TOSYNAPSEINFO;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.OrderInfo;

namespace RISBizLibrary.Updater.Table
{
	internal class TOSYNAPSEINFOUpdaterOrderInfo : TOSYNAPSEINFOUpdater
	{
		protected override TOSYNAPSEINFOState GetState(BaseMsgData data)
		{
			HISRISOrderInfoAggregate d = ((HISRISIOrderInfo)(data.Request.Body)).OrderInfo;
			if (d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_ORDER_RIS
				|| d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_ORDERCANCEL_RIS)
			{
				return new TOSYNAPSEINFOStateOrderInfo(data as BaseMsgData);
			}
			throw new MsgAnomalyException(string.Format(
				"想定していない電文種別を受信しました。電文種別={0}",
					d.DENBUN_SYBT.TrimData));
		}
	}
}
