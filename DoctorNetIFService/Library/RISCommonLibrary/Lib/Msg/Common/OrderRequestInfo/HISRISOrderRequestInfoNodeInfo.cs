using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.OrderRequestInfo
{
	class HISRISOrderRequestInfoNodeInfo
	{
		public static NodeInfo H2RREQUEST_ROOT = new NodeInfo ("REQUEST" , "依頼再送要求ﾃﾞｰﾀ" , NodeTypeEnum.ntAggregate , -1);
		//【KEY情報】
		public static NodeInfo H2RREQUEST_PT_ID = new NodeInfo ("PT_ID" , "患者ID" , NodeTypeEnum.ntData , 10);
		//【依頼再送要求情報】
		public static NodeInfo H2RREQUEST_XX_KBN = new NodeInfo ("XX_KBN" , "XX区分" , NodeTypeEnum.ntData , 2);
		public static NodeInfo H2RREQUEST_XX_SYBT = new NodeInfo ("XX_SYBT" , "XX種別" , NodeTypeEnum.ntData , 3);
		public static NodeInfo H2RREQUEST_YK_DATE = new NodeInfo ("YK_DATE" , "予約日" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RREQUEST_FILLER = new NodeInfo ("FILLER" , "FILLER" , NodeTypeEnum.ntData , 27);
	}
}
