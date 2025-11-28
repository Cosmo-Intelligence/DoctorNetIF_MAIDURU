using RISBizLibrary.Data;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.Hospitalize;
using RISCommonLibrary.Lib.Msg.Common.OrderInfo;

namespace RISBizLibrary.Updater.Table.TOHISINFO
{
	public class TOHISINFOStateOrderInfo : TOHISINFOState
	{

		public TOHISINFOStateOrderInfo(BaseMsgData data)
			: base(data)
		{

		}

		public override string GetMESSAGETYPE()
		{
			HISRISOrderInfoAggregate d = ((HISRISIOrderInfo)(Data.Request.Body)).OrderInfo;
			if (d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_ORDER_RIS)
			{
				return RQRISDBConst.FROMHISINFO_MESSAGETYPE_ORDER;
			}
			return "";
		}

		public override string GetDeleteMESSAGETYPE()
		{
			string[] value = new string[]
				{
					"'" + RQRISDBConst.FROMHISINFO_MESSAGETYPE_ORDER + "'"
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
			HISRISOrderInfoAggregate d = ((HISRISIOrderInfo)(Data.Request.Body)).OrderInfo;
			return d.PT_ID1.TrimData;
		}

	}
}
