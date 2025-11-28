using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.ReceiptInfo
{
	class HISRISReceiptInfoNodeInfo
	{
		public static NodeInfo H2RRECEIPT_ROOT = new NodeInfo ("RECEIPT" , "受付ﾃﾞｰﾀ" , NodeTypeEnum.ntAggregate, -1);
		//【KEY情報】
		public static NodeInfo H2RRECEIPT_PT_ID = new NodeInfo ("PT_ID" , "患者ID" , NodeTypeEnum.ntData, 10);
		//【受付情報】
		public static NodeInfo H2RRECEIPT_HASSEI_DATE= new NodeInfo ("HASSEI_DATE", "発生日" , NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RRECEIPT_SEQ_NO = new NodeInfo ("SEQ_NO" , "SEQ番号" , NodeTypeEnum.ntData, 6);
		public static NodeInfo H2RRECEIPT_WS_NO = new NodeInfo ("WS_NO" , "WS番号" , NodeTypeEnum.ntData, 4);
		public static NodeInfo H2RRECEIPT_INDEX_KBN = new NodeInfo ("INDEX_KBN" , "INDEX区分" , NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RRECEIPT_XX_KBN = new NodeInfo ("XX_KBN" , "XX区分" , NodeTypeEnum.ntData, 2);
		public static NodeInfo H2RRECEIPT_XX_SYBT = new NodeInfo ("XX_SYBT" , "XX種別" , NodeTypeEnum.ntData, 3);
		public static NodeInfo H2RRECEIPT_XX_SEQ = new NodeInfo ("XX_SEQ" , "XX-SEQ" , NodeTypeEnum.ntData, 5);
		public static NodeInfo H2RRECEIPT_ORDER_NO = new NodeInfo ("ORDER_NO" , "ORDER番号" , NodeTypeEnum.ntData, 16);
		public static NodeInfo H2RRECEIPT_FILLER = new NodeInfo ("FILLER" , "FILLER" , NodeTypeEnum.ntData, 6);
		public static NodeInfo H2RRECEIPT_PROC_SYBT = new NodeInfo ("PROC_SYBT " , "処理種別(検査種別)" , NodeTypeEnum.ntData, 2);
		public static NodeInfo H2RRECEIPT_YK_KJ_ST4 = new NodeInfo ("YK_KJ_ST4" , "受付ｽﾃｰﾀｽ(部門受付区分)", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RRECEIPT_CNCL_RSN = new NodeInfo ("CNCL_RSN" , "中止理由" , NodeTypeEnum.ntData, 2);
		public static NodeInfo H2RRECEIPT_YK_CR_DT = new NodeInfo ("YK_CR_DT" , "処理日付(作成日付)" , NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RRECEIPT_RESERVE = new NodeInfo ("RESERVE" , "予備" , NodeTypeEnum.ntData, 15);
	}
}
