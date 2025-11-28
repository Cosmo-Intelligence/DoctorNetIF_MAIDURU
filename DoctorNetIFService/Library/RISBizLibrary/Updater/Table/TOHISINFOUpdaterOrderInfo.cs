using RISBizLibrary.Data;
using RISBizLibrary.Updater.Table.TOHISINFO;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.Hospitalize;
using RISCommonLibrary.Lib.Msg.Common.OrderInfo;

namespace RISBizLibrary.Updater.Table
{
	internal class TOHISINFOUpdaterOrderInfo : TOHISINFOUpdater
	{
		protected override TOHISINFOState GetState(BaseMsgData data)
		{
			HISRISOrderInfoAggregate d = ((HISRISIOrderInfo)(data.Request.Body)).OrderInfo;
			return new TOHISINFOStateOrderInfo(data as BaseMsgData);
		}
	}
}
