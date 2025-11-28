using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.ExamInfo
{
	class HISRISExamInfoNodeInfo
	{

		public static NodeInfo H2REXAM_ROOT = new NodeInfo ("EXAM", "放射線実施データ", NodeTypeEnum.ntAggregate , -1);
		//オーダKEY情報
		public static NodeInfo H2REXAM_PT_ID = new NodeInfo ("PT_ID", "患者ID", NodeTypeEnum.ntData, 10);
		public static NodeInfo H2REXAM_HASSEI_DATE = new NodeInfo ("HASSEI_DATE", "発生日", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2REXAM_SEQ_NO = new NodeInfo ("SEQ_NO", "SEQ番号", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2REXAM_WS_NO = new NodeInfo ("WS_NO", "WS番号", NodeTypeEnum.ntData, 4);
		public static NodeInfo H2REXAM_INDEX_KBN = new NodeInfo ("INDEX_KBN", "INDEX区分", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2REXAM_XX_KBN = new NodeInfo ("XX_KBN", "XX区分", NodeTypeEnum.ntData, 2);
		public static NodeInfo H2REXAM_XX_SYBT = new NodeInfo ("XX_SYBT", "XX種別", NodeTypeEnum.ntData, 3);
		public static NodeInfo H2REXAM_XX_SEQ = new NodeInfo ("XX_SEQ", "XX-SEQ", NodeTypeEnum.ntData, 5);
		public static NodeInfo H2REXAM_ORDER_NO = new NodeInfo ("ORDER_NO", "オーダ番号", NodeTypeEnum.ntData, 16);
		public static NodeInfo H2REXAM_CANCEL_KBN = new NodeInfo ("CANCEL_KBN", "中止区分", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2REXAM_FILLER = new NodeInfo("FILLER", "FILLER", NodeTypeEnum.ntData, 6);
		public static NodeInfo H2REXAM_KNS_SYBT = new NodeInfo ("KNS_SYBT", "処理種別(検査種別)", NodeTypeEnum.ntData, 2);
		public static NodeInfo H2REXAM_XX_SUM = new NodeInfo ("XX_SUM", "サブオーダ総数(XX-SUM)", NodeTypeEnum.ntData, 2);
		public static NodeInfo H2REXAM_ACCESSION_NO= new NodeInfo ("ACCESSION_NO", "オーダー番号"              , NodeTypeEnum.ntData, 16);
		//オーダ関連情報
		public static NodeInfo H2REXAM_JIGO_KBN= new NodeInfo ("JIGO_KBN", "事後入力区分", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2REXAM_FILLER1 = new NodeInfo ("FILLER1", "FILLER1", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2REXAM_FILLER2 = new NodeInfo ("FILLER2", "FILLER2", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2REXAM_FILLER3 = new NodeInfo ("FILLER3", "FILLER3", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2REXAM_FREE_COMMENT1 = new NodeInfo ("FREE_COMMENT1", "検査室コード", NodeTypeEnum.ntData, 10);
		//実施ヘッダ情報
		public static NodeInfo H2REXAM_JISSI_DATE= new NodeInfo ("JISSI_DATE", "検査実施日", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2REXAM_JISSI_TIME= new NodeInfo ("JISSI_TIME", "検査実施時刻", NodeTypeEnum.ntData, 6);
		public static NodeInfo H2REXAM_KNS_DR1 = new NodeInfo ("KNS_DR1", "検査医1", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2REXAM_KNS_DR2 = new NodeInfo ("KNS_DR2", "検査医2", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2REXAM_KNS_DR3 = new NodeInfo ("KNS_DR3", "検査医3", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2REXAM_KNS_GISI1 = new NodeInfo ("KNS_GISI1", "検査技師1", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2REXAM_KNS_GISI2 = new NodeInfo ("KNS_GISI2", "検査技師2", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2REXAM_KNS_GISI3 = new NodeInfo ("KNS_GISI3", "検査技師3", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2REXAM_ROOM_CD1 = new NodeInfo ("ROOM_CD1", "撮影室ｺｰﾄﾞ", NodeTypeEnum.ntData, 2);
		//機能検査基本情報（×ｎ OCCURS）
		public static NodeInfo H2REXAM_FUNC_SUMM = new NodeInfo ("FUNC_SUMM", "機能検査数", NodeTypeEnum.ntArray, 5);
		public static NodeInfo H2REXAM_FUNC_LIST = new NodeInfo ("FUNC_LIST", "機能検査リスト", NodeTypeEnum.ntAggregate , -1);
		public static NodeInfo H2REXAM_FUNC_KBN = new NodeInfo ("FUNC_KBN", "機能検査区分", NodeTypeEnum.ntData , 2);
		public static NodeInfo H2REXAM_FUNC_CD = new NodeInfo ("FUNC_CD", "機能検査コード", NodeTypeEnum.ntData , 3);
		//public static NodeInfo H2REXAM_JISSI_COMMENT= new NodeInfo ("JISSI_COMMENT", "RIS→HISコメント", NodeTypeEnum.ntData , 512);
		public static NodeInfo H2REXAM_JISSI_COMMENT= new NodeInfo ("JISSI_COMMENT", "RIS→HISコメント", NodeTypeEnum.ntData , 1024);
		//【実施部位情報】
		//部位基本情報（×ｎ OCCURS）
		public static NodeInfo H2REXAM_BUI_SUMM= new NodeInfo ("BUI_SUMM", "部位数", NodeTypeEnum.ntArray, 5);
		public static NodeInfo H2REXAM_BUI_LIST= new NodeInfo ("BUI_LIST", "部位リスト", NodeTypeEnum.ntAggregate , -1);
		public static NodeInfo H2REXAM_BUI_SEQ = new NodeInfo ("BUI_SEQ", "部位番号", NodeTypeEnum.ntData , 5);
		public static NodeInfo H2REXAM_BUI_CD = new NodeInfo ("BUI_CD", "部位コード", NodeTypeEnum.ntData , 8);
		public static NodeInfo H2REXAM_ROOM_CD2 = new NodeInfo("ROOM_CD2", "撮影室", NodeTypeEnum.ntData , 2);
		public static NodeInfo H2REXAM_MAC_CD = new NodeInfo ("MAC_CD", "撮影機器コード", NodeTypeEnum.ntData , 2);
		public static NodeInfo H2REXAM_KV = new NodeInfo ("KV", "撮影条件（ｋｖ）", NodeTypeEnum.ntData , 4);
		public static NodeInfo H2REXAM_MA = new NodeInfo ("MA", "撮影条件（ｍａ）", NodeTypeEnum.ntData , 4);
		public static NodeInfo H2REXAM_SEC = new NodeInfo ("SEC", "撮影条件（ｓｅｃ）", NodeTypeEnum.ntData , 4);
		public static NodeInfo H2REXAM_LENG = new NodeInfo ("LENG", "撮影条件（ｃｍ）", NodeTypeEnum.ntData , 4);
		//部位詳細情報（×ｎ OCCURS）
		public static NodeInfo H2REXAM_COMMENT_SUMM= new NodeInfo ("COMMENT_SUMM", "コメント数", NodeTypeEnum.ntArray, 5);
		public static NodeInfo H2REXAM_COMMENT_LIST= new NodeInfo ("COMMENT_LIST", "コメントリスト", NodeTypeEnum.ntAggregate , -1);
		public static NodeInfo H2REXAM_COMMENT_KBN = new NodeInfo ("COMMENT_KBN", "コメント区分", NodeTypeEnum.ntData , 2);
		public static NodeInfo H2REXAM_COMMENT_CODE= new NodeInfo ("COMMENT_CODE", "コメントコード", NodeTypeEnum.ntData , 3);
		//体位方向情報（×ｎ OCCURS）
		public static NodeInfo H2REXAM_TAII_SUMM= new NodeInfo ("TAII_SUMM", "体位方向数", NodeTypeEnum.ntArray, 5);
		public static NodeInfo H2REXAM_TAII_LIST= new NodeInfo ("TAII_LIST", "体位方向リスト", NodeTypeEnum.ntAggregate , -1);
		public static NodeInfo H2REXAM_TAII_CD = new NodeInfo ("TAII_CD", "体位", NodeTypeEnum.ntData , 3);
		public static NodeInfo H2REXAM_HOKO_CD = new NodeInfo ("HOKO_CD", "方向", NodeTypeEnum.ntData , 3);
		//フィルム情報（×ｎ OCCURS）
		public static NodeInfo H2REXAM_FILM_SUMM= new NodeInfo ("FILM_SUMM", "フィルム数", NodeTypeEnum.ntArray, 5);
		public static NodeInfo H2REXAM_FILM_LIST= new NodeInfo ("FILM_LIST", "フィルムリスト", NodeTypeEnum.ntAggregate , -1);
		public static NodeInfo H2REXAM_FILM_CD = new NodeInfo ("FILM_CD", "フィルムコード", NodeTypeEnum.ntData , 4);
		public static NodeInfo H2REXAM_FILM_CNT = new NodeInfo ("FILM_CNT", "フィルム枚数", NodeTypeEnum.ntData , 5);
		public static NodeInfo H2REXAM_KAKU_CNT = new NodeInfo ("KAKU_CNT", "分画数", NodeTypeEnum.ntData , 5);
		public static NodeInfo H2REXAM_SATU_CNT = new NodeInfo ("SATU_CNT", "照射回数", NodeTypeEnum.ntData , 5);
		//撮影コマ情報（×ｎ OCCURS）
		public static NodeInfo H2REXAM_SHOOT_SUMM = new NodeInfo ("SHOOT_SUMM", "撮影部位数", NodeTypeEnum.ntArray, 5);
		public static NodeInfo H2REXAM_SHOOT_LIST = new NodeInfo ("SHOOT_LIST", "撮影部位リスト", NodeTypeEnum.ntAggregate , -1);
		public static NodeInfo H2REXAM_SHOOT_BUI_CD= new NodeInfo ("SHOOT_BUI_CD", "撮影部位コード", NodeTypeEnum.ntData , 3);
		public static NodeInfo H2REXAM_SHOOT_CNT = new NodeInfo ("SHOOT_CNT", "撮影コマ数", NodeTypeEnum.ntData , 5);
		//【使用薬剤情報】
		//薬剤基本情報
		public static NodeInfo H2REXAM_DRUG_SUMM = new NodeInfo ("DRUG_SUMM", "使用薬剤数", NodeTypeEnum.ntArray, 5);
		public static NodeInfo H2REXAM_DRUG_LIST = new NodeInfo ("DRUG_LIST", "使用薬剤リスト", NodeTypeEnum.ntAggregate , -1);
		public static NodeInfo H2REXAM_DRUG_CD = new NodeInfo ("DRUG_CD", "薬品コード", NodeTypeEnum.ntData , 8);
		public static NodeInfo H2REXAM_DRUG_CNT = new NodeInfo ("DRUG_CNT", "薬品使用量", NodeTypeEnum.ntData , 5);
		public static NodeInfo H2REXAM_DRUG_STD_CD= new NodeInfo ("DRUG_STD_CD", "薬品単位コード", NodeTypeEnum.ntData , 2);
		//【使用器材情報】
		//器材基本情報
		public static NodeInfo H2REXAM_KZI_SUMM = new NodeInfo ("KZI_SUMM", "使用器材数", NodeTypeEnum.ntArray, 5);
		public static NodeInfo H2REXAM_KZI_LIST = new NodeInfo ("KZI_LIST", "使用器材リスト", NodeTypeEnum.ntAggregate , -1);
		public static NodeInfo H2REXAM_KZI_CD = new NodeInfo ("KZI_CD", "器材コード", NodeTypeEnum.ntData , 8);
		public static NodeInfo H2REXAM_KZI_CNT = new NodeInfo ("KZI_CNT", "器材使用量", NodeTypeEnum.ntData , 5);
		public static NodeInfo H2REXAM_KZI_STD_CD= new NodeInfo ("KZI_STD_CD", "器材単位コード", NodeTypeEnum.ntData , 2);
		//【使用放射性医薬品情報】
		//放射線医薬品基本情報
		public static NodeInfo H2REXAM_ISO_SUMM = new NodeInfo ("ISO_SUMM", "使用放射線医薬品数", NodeTypeEnum.ntArray, 5);
		public static NodeInfo H2REXAM_ISO_LIST = new NodeInfo ("ISO_LIST", "使用放射線医薬品リスト", NodeTypeEnum.ntAggregate , -1);
		public static NodeInfo H2REXAM_ISO_CD = new NodeInfo ("ISO_CD", "放射線医薬品コード", NodeTypeEnum.ntData , 8);
		public static NodeInfo H2REXAM_ISO_CNT = new NodeInfo ("ISO_CNT", "放射線医薬品使用量", NodeTypeEnum.ntData , 5);
		public static NodeInfo H2REXAM_ISO_STD_CD= new NodeInfo ("ISO_STD_CD", "放射線医薬品単位コード", NodeTypeEnum.ntData , 2);
	}
}
