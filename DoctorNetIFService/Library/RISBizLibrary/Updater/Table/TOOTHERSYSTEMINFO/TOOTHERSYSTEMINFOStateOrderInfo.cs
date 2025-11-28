using RISBizLibrary.Data;
using RISBizLibrary.Download.Data;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.OrderInfo;

namespace RISBizLibrary.Updater.Table.TOOTHERSYSTEMINFO
{
	public class TOOTHERSYSTEMINFOStateOrderInfo : TOOTHERSYSTEMINFOState
	{
		public override string GetRIS_ID()
		{
			OrderInfoMsgData orderData = (OrderInfoMsgData)Data;
			return orderData.RIS_ID;
		}

		public TOOTHERSYSTEMINFOStateOrderInfo(BaseMsgData data)
			: base(data)
		{

		}

		public override string GetMESSAGETYPE()
		{
			HISRISOrderInfoAggregate d = ((HISRISIOrderInfo)(Data.Request.Body)).OrderInfo;
			if (d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_ORDER_RIS)
			{
				if (d.SYORI_KBN.TrimData == "1")
				{
					return RQRISDBConst.FROMHISINFO_MESSAGETYPE_ORDER;
				}
				else if (d.SYORI_KBN.TrimData == "2")
				{
					return RQRISDBConst.FROMHISINFO_MESSAGETYPE_ORDER_CHANGE;
				}
			}
			if (d.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_ORDERCANCEL_RIS)
			{
				return RQRISDBConst.FROMHISINFO_MESSAGETYPE_ORDER_CANCEL;
			}
			return "";
		}

		public override string GetDeleteMESSAGETYPE()
		{
			string[] value = new string[]
				{
					"'" + RQRISDBConst.FROMHISINFO_MESSAGETYPE_ORDER + "'",
					"'" + RQRISDBConst.FROMHISINFO_MESSAGETYPE_ORDER_CHANGE + "'",
					"'" + RQRISDBConst.FROMHISINFO_MESSAGETYPE_ORDER_CANCEL + "'"
				};
			return string.Join(",", value);
		}

		public override string GetREQUESTUSER()
		{
			return "RIS_Down";
		}

		public override string GetREQUESTTERMINALID()
		{
			return "RISSERVER";
		}

		public override string GetMESSAGEID1()
		{
			HISRISOrderInfoAggregate d = ((HISRISIOrderInfo)(Data.Request.Body)).OrderInfo;
			return d.ORDER_NO.TrimData;
		}

		public override string GetMESSAGEID2()
		{
			HISRISOrderInfoAggregate d = ((HISRISIOrderInfo)(Data.Request.Body)).OrderInfo;
			return d.PT_ID1.TrimData;
		}

	}
}
