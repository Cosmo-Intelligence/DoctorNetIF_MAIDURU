using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.OrderInfo
{
	class HISRISOrderInfoNodeInfo
	{
		public static NodeInfo H2RORDER_ROOT = new NodeInfo( "ORDER", "放射線ｵｰﾀﾞﾃﾞｰﾀ", NodeTypeEnum.ntAggregate , -1);

		//【オーダＫＥＹ情報】
		//オーダKEY情報
		public static NodeInfo H2RORDER_PT_ID1 = new NodeInfo( "PT_ID1" , "患者ID" , NodeTypeEnum.ntData , 10);
		public static NodeInfo H2RORDER_HASSEI_DATE = new NodeInfo( "HASSEI_DATE", "発生日" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_SEQ_NO = new NodeInfo( "SEQ_NO" , "SEQ番号" , NodeTypeEnum.ntData , 6);
		public static NodeInfo H2RORDER_WS_NO = new NodeInfo( "WS_NO" , "WS番号" , NodeTypeEnum.ntData , 4);
		public static NodeInfo H2RORDER_INDEX_KBN = new NodeInfo( "INDEX_KBN" , "INDEX区分", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_XX_KBN = new NodeInfo( "XX_KBN" , "XX区分" , NodeTypeEnum.ntData , 2);
		public static NodeInfo H2RORDER_XX_SYBT = new NodeInfo( "XX_SYBT" , "XX種別" , NodeTypeEnum.ntData , 3);
		public static NodeInfo H2RORDER_XX_SEQ = new NodeInfo( "XX_SEQ" , "XX-SEQ" , NodeTypeEnum.ntData , 5);
		//【依頼元情報】
		public static NodeInfo H2RORDER_NYUGAI_KBN = new NodeInfo( "NYUGAI_KBN" , "入外区分" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_KA_CD1 = new NodeInfo( "KA_CD1" , "診療科コード" , NodeTypeEnum.ntData , 3);
		public static NodeInfo H2RORDER_KA_NAME = new NodeInfo( "KA_NAME" , "診療科名" , NodeTypeEnum.ntData , 20);
		public static NodeInfo H2RORDER_BYOTO_CD = new NodeInfo( "BYOTO_CD" , "病棟コード" , NodeTypeEnum.ntData , 3);
		public static NodeInfo H2RORDER_BYOTO_NAME = new NodeInfo( "BYOTO_NAME" , "病棟名" , NodeTypeEnum.ntData , 20);
		public static NodeInfo H2RORDER_DR_ID1 = new NodeInfo( "DR_ID1" , "医師ID" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_SH_KANA_NAME = new NodeInfo( "SH_KANA_NAME", "カナ氏名" , NodeTypeEnum.ntData , 20);
		public static NodeInfo H2RORDER_SH_NAME = new NodeInfo( "SH_NAME" , "職員名" , NodeTypeEnum.ntData , 20);
		public static NodeInfo H2RORDER_PHS = new NodeInfo( "PHS" , "依頼医師連絡先PHS番号", NodeTypeEnum.ntData , 15);
		public static NodeInfo H2RORDER_IN_DATE1 = new NodeInfo( "IN_DATE1" , "依頼日" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_STOP_DATE = new NodeInfo( "STOP_DATE" , "中止日" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_STOP_RSN_FLG = new NodeInfo( "STOP_RSN_FLG", "中止理由フラグ", NodeTypeEnum.ntData , 1);
		//【患者基本情報】
		//患者属性
		public static NodeInfo H2RORDER_PT_ID2 = new NodeInfo( "PT_ID2" , "患者ID" , NodeTypeEnum.ntData , 10);
		public static NodeInfo H2RORDER_PT_KN_NAME = new NodeInfo( "PT_KN_NAME" , "患者氏名（カナ）", NodeTypeEnum.ntData , 23);
		public static NodeInfo H2RORDER_PT_KJ_NAME = new NodeInfo( "PT_KJ_NAME" , "患者氏名（漢字）", NodeTypeEnum.ntData , 20);
		public static NodeInfo H2RORDER_PT_SEX = new NodeInfo( "PT_SEX" , "性別" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_PT_BIRTH = new NodeInfo( "PT_BIRTH" , "生年月日" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_PT_STATUS = new NodeInfo( "PT_STATUS" , "患者状態" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ROOM_CD = new NodeInfo( "ROOM_CD" , "病室コード" , NodeTypeEnum.ntData , 4);
		public static NodeInfo H2RORDER_ROOM_NAME = new NodeInfo( "ROOM_NAME" , "病室名称" , NodeTypeEnum.ntData , 20);
		public static NodeInfo H2RORDER_PT_ZIP = new NodeInfo( "PT_ZIP" , "郵便番号" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_PT_ADDR = new NodeInfo( "PT_ADDR" , "住所" , NodeTypeEnum.ntData , 80);
		public static NodeInfo H2RORDER_PT_ADDR_CD = new NodeInfo( "PT_ADDR_CD" , "住所コード" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_PT_TEL = new NodeInfo( "PT_TEL" , "電話番号" , NodeTypeEnum.ntData , 18);
		public static NodeInfo H2RORDER_FILLER1 = new NodeInfo( "FILLER1" , "患者フラグ1" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_FILLER2 = new NodeInfo( "FILLER2" , "FILLER2" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_FILLER3 = new NodeInfo( "FILLER3" , "FILLER3" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_FILLER4 = new NodeInfo( "FILLER4" , "FILLER4" , NodeTypeEnum.ntData , 20);
		//患者身体情報
		public static NodeInfo H2RORDER_BLOOD_ABO = new NodeInfo( "BLOOD_ABO" , "ABO式" , NodeTypeEnum.ntData , 2);
		public static NodeInfo H2RORDER_BLOOD_RH = new NodeInfo( "BLOOD_RH" , "RH式" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_PT_HEIGHT = new NodeInfo( "PT_HEIGHT" , "身長" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_PT_WEIGHT = new NodeInfo( "PT_WEIGHT" , "体重" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_PT_WEIGHT_T = new NodeInfo( "PT_WEIGHT_T", "体重単位" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_FILLER5 = new NodeInfo( "FILLER5" , "FILLER5" , NodeTypeEnum.ntData , 20);
		//アレルギー情報
		//public static NodeInfo H2RORDER_MRI_MED_FLG = new NodeInfo( "MRI_MED_FLG" , "MR造影剤（Gd系）" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_CONT_MED_ALGY1 = new NodeInfo( "CONT_MED_ALGY1" , "造影剤アレルギー" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ALGY_DRAG_FLG = new NodeInfo( "ALGY_DRAG_FLG" , "薬物アレルギーフラグ", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ALGY_FLOOD_FLG = new NodeInfo( "ALGY_FLOOD_FLG", "食物アレルギーフラグ", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_KORIN_IJ_FLG = new NodeInfo( "KORIN_IJ_FLG" , "抗コリン剤筋注" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_GRUK_IJ_FLG = new NodeInfo( "GRUK_IJ_FLG" , "グルカゴン静注" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ALGY_COMMENT = new NodeInfo( "ALGY_COMMENT" , "アレルギーコメント" , NodeTypeEnum.ntData , 100);
		public static NodeInfo H2RORDER_CONT_MED_ALGY = new NodeInfo( "CONT_MED_ALGY" , "ヨードおよびヨード造影剤アレルギー", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_FILLER6 = new NodeInfo( "FILLER6" , "FILLER6" , NodeTypeEnum.ntData , 7);
		//障害情報
		public static NodeInfo H2RORDER_LIMBS_SG_FLG = new NodeInfo( "LIMBS_SG_FLG" , "四肢障害フラグ", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_VISION_SG_FLG = new NodeInfo( "VISION_SG_FLG" , "視覚障害フラグ", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_AUDITORY_SG_FLG = new NodeInfo( "AUDITORY_SG_FLG" , "聴覚障害フラグ", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_SPEECH_SG_FLG = new NodeInfo( "SPEECH_SG_FLG" , "言語障害フラグ", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_MIND_SG_FLG = new NodeInfo( "MIND_SG_FLG" , "精神障害フラグ", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ECXCRETION_SG_FLG = new NodeInfo( "ECXCRETION_SG_FLG", "排泄障害フラグ", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_IDO_KBN = new NodeInfo( "IDO_KBN" , "移動レベル" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_FILLER7 = new NodeInfo( "FILLER7" , "FILLER7" , NodeTypeEnum.ntData , 8);
		//身体装具情報
		public static NodeInfo H2RORDER_ETC_FLG1 = new NodeInfo( "ETC_FLG1" , "心臓ペースメーカー" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG2 = new NodeInfo( "ETC_FLG2" , "脳動脈瘤クリップ" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG3 = new NodeInfo( "ETC_FLG3" , "動脈クリップ" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG4 = new NodeInfo( "ETC_FLG4" , "シャントチューブ" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG5 = new NodeInfo( "ETC_FLG5" , "心電図計、電極" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG6 = new NodeInfo( "ETC_FLG6" , "心臓人工弁 " , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG7 = new NodeInfo( "ETC_FLG7" , "神経刺激器" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG8 = new NodeInfo( "ETC_FLG8" , "補聴器(埋め込み式)" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG9 = new NodeInfo( "ETC_FLG9" , "人工器官(義眼等)" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG10 = new NodeInfo( "ETC_FLG10" , "眼球内金属粉塵" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG11 = new NodeInfo( "ETC_FLG11" , "歯列矯正ワイヤ" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG12 = new NodeInfo( "ETC_FLG12" , "義歯(入れ歯、差し歯)" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG13 = new NodeInfo( "ETC_FLG13" , "消化器手術クリップ" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG14 = new NodeInfo( "ETC_FLG14" , "インスリンポンプ" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG15 = new NodeInfo( "ETC_FLG15" , "輸液ポンプ、シリンジポンプ" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG16 = new NodeInfo( "ETC_FLG16" , "人工関節" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG17 = new NodeInfo( "ETC_FLG17" , "ワイヤ(針金)縫合" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG18 = new NodeInfo( "ETC_FLG18" , "骨折接合用金属(ネジ、ピン等)" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG19 = new NodeInfo( "ETC_FLG19" , "入れ墨" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG20 = new NodeInfo( "ETC_FLG20" , "流散弾片" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG21 = new NodeInfo( "ETC_FLG21" , "避妊器具(リング)" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG22 = new NodeInfo( "ETC_FLG22" , "ニトロダーム等の貼付剤" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG23 = new NodeInfo( "ETC_FLG23" , "カラーコンタクトレンズ" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG24 = new NodeInfo( "ETC_FLG24" , "アイライナー、マスカラ、その他金属を含む化粧品", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG25 = new NodeInfo( "ETC_FLG25" , "その他身に付けている金属、器具、義肢など" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ETC_FLG26 = new NodeInfo( "ETC_FLG26" , "その他身に付けている金属、器具、義肢など" , NodeTypeEnum.ntData , 100);
		public static NodeInfo H2RORDER_FILLER8 = new NodeInfo( "FILLER8" , "FILLER8" , NodeTypeEnum.ntData , 10);
		//疾患情報
		public static NodeInfo H2RORDER_HEART_FLG = new NodeInfo( "HEART_FLG" , "心疾患" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_BPH_FLG = new NodeInfo( "BPH_FLG" , "前立腺肥大", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_DM_FLG = new NodeInfo( "DM_FLG" , "糖尿病" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_KOJSEN_FLG = new NodeInfo( "KOJSEN_FLG" , "甲状腺疾患", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_GLAUCOMA_FLG = new NodeInfo( "GLAUCOMA_FLG", "緑内障" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_PREGNANT_FLG = new NodeInfo( "PREGNANT_FLG", "妊娠フラグ", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_LIVER_FLG = new NodeInfo( "LIVER_FLG" , "肝機能障害", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_RENEAL_FLG = new NodeInfo( "RENEAL_FLG" , "腎機能障害", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ASTHMA_FLG = new NodeInfo( "ASTHMA_FLG" , "気管支喘息", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_LUNG_FLG = new NodeInfo( "LUNG_FLG" , "肺疾患" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_HYPER_FLG = new NodeInfo( "HYPER_FLG" , "高血圧" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_BLEED_FLG = new NodeInfo( "BLEED_FLG" , "出血傾向" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_PLATELET_FLG = new NodeInfo( "PLATELET_FLG", "抗凝固血小板療法", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RORDER_FILLER9 = new NodeInfo( "FILLER9" , "FILLER9" , NodeTypeEnum.ntData , 7);
		//検査結果情報
		public static NodeInfo H2RORDER_KEKKA1 = new NodeInfo( "KEKKA1" , "クレアチニン(結果数値)", NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA1_DATE = new NodeInfo( "KEKKA1_DATE" , "クレアチニン(検査日)" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA2 = new NodeInfo( "KEKKA2" , "ヘモグロビン(結果数値)", NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA2_DATE = new NodeInfo( "KEKKA2_DATE" , "ヘモグロビン(検査日)" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA3 = new NodeInfo( "KEKKA3" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA3_DATE = new NodeInfo( "KEKKA3_DATE" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA4 = new NodeInfo( "KEKKA4" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA4_DATE = new NodeInfo( "KEKKA4_DATE" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA5 = new NodeInfo( "KEKKA5" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA5_DATE = new NodeInfo( "KEKKA5_DATE" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA6 = new NodeInfo( "KEKKA6" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA6_DATE = new NodeInfo( "KEKKA6_DATE" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA7 = new NodeInfo( "KEKKA7" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA7_DATE = new NodeInfo( "KEKKA7_DATE" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA8 = new NodeInfo( "KEKKA8" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA8_DATE = new NodeInfo( "KEKKA8_DATE" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA9 = new NodeInfo( "KEKKA9" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA9_DATE = new NodeInfo( "KEKKA9_DATE" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA10 = new NodeInfo( "KEKKA10" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA10_DATE = new NodeInfo( "KEKKA10_DATE" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA11 = new NodeInfo( "KEKKA11" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA11_DATE = new NodeInfo( "KEKKA11_DATE" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA12 = new NodeInfo( "KEKKA12" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA12_DATE = new NodeInfo( "KEKKA12_DATE" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA13 = new NodeInfo( "KEKKA13" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA13_DATE = new NodeInfo( "KEKKA13_DATE" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA14 = new NodeInfo( "KEKKA14" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA14_DATE = new NodeInfo( "KEKKA14_DATE" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA15 = new NodeInfo( "KEKKA15" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA15_DATE = new NodeInfo( "KEKKA15_DATE" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA16 = new NodeInfo( "KEKKA16" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA16_DATE = new NodeInfo( "KEKKA16_DATE" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA17 = new NodeInfo( "KEKKA17" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA17_DATE = new NodeInfo( "KEKKA17_DATE" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA18 = new NodeInfo( "KEKKA18" , "未使用" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_KEKKA18_DATE = new NodeInfo( "KEKKA18_DATE" , "未使用" , NodeTypeEnum.ntData , 8);
		//感染症情報
		public static NodeInfo H2RORDER_MRSA = new NodeInfo( "MRSA" , "MRSA" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_HB = new NodeInfo( "HB" , "HBS抗原" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_HC = new NodeInfo( "HC" , "HCV抗体" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_HIV = new NodeInfo( "HIV" , "HIV" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_RPR = new NodeInfo( "RPR" , "RPR" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_PS = new NodeInfo( "PS" , "緑膿菌" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_ATLV = new NodeInfo( "ATLV" , "ATLV抗体" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_TP = new NodeInfo( "TP" , "TP抗体" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_GBS = new NodeInfo( "GBS" , "GBS" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_LTBI = new NodeInfo( "LTBI" , "ツ反" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_KN_OTHER_NM = new NodeInfo( "KN_OTHER_NM", "感染症フリー入力項目名称" , NodeTypeEnum.ntData , 20);
		public static NodeInfo H2RORDER_KN_OTHER = new NodeInfo( "KN_OTHER" , "感染症フリー入力項目ステータス", NodeTypeEnum.ntData , 1);
		//【その他】
		public static NodeInfo H2RORDER_KYUGO_KBN= new NodeInfo( "KYUGO_KBN", "救護区分", NodeTypeEnum.ntData , 1);
		//オーダ基本情報
		//オーダKEY情報
		public static NodeInfo H2RORDER_ORDER_NO = new NodeInfo( "ORDER_NO" , "オーダ番号" , NodeTypeEnum.ntData , 16);
		public static NodeInfo H2RORDER_CSCAN_NO = new NodeInfo( "CSCAN_NO" , "C-SCAN番号" , NodeTypeEnum.ntData , 100);
		public static NodeInfo H2RORDER_FILLER10 = new NodeInfo( "FILLER10" , "FILLER10" , NodeTypeEnum.ntData , 7);
		public static NodeInfo H2RORDER_KNS_SYBT1= new NodeInfo( "KNS_SYBT1", "処理種別(検査種別)", NodeTypeEnum.ntData , 2);
		public static NodeInfo H2RORDER_XX_SUM = new NodeInfo( "XX_SUM" , "サブオーダ総数(XX-SUM)", NodeTypeEnum.ntData , 2);
		//依頼元情報
		public static NodeInfo H2RORDER_KA_CD2 = new NodeInfo( "KA_CD2" , "診療科コード" , NodeTypeEnum.ntData , 3);
		public static NodeInfo H2RORDER_DR_ID2 = new NodeInfo( "DR_ID2" , "医師ID" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_DR_NAME = new NodeInfo( "DR_NAME" , "医師名" , NodeTypeEnum.ntData , 20);
		public static NodeInfo H2RORDER_OP_ID = new NodeInfo( "OP_ID" , "オペレータID" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_IN_DATE2 = new NodeInfo( "IN_DATE2" , "オーダ登録日付(入力日)" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_IN_TIME = new NodeInfo( "IN_TIME" , "オーダ登録時刻(入力時刻)", NodeTypeEnum.ntData , 6);
		public static NodeInfo H2RORDER_IRAI_BASYO= new NodeInfo( "IRAI_BASYO", "依頼場所名" , NodeTypeEnum.ntData , 30);
		//指示情報
		public static NodeInfo H2RORDER_KNS_SYBT2 = new NodeInfo( "KNS_SYBT2" , "検査種別" , NodeTypeEnum.ntData , 2);
		public static NodeInfo H2RORDER_IRAI_KBN = new NodeInfo( "IRAI_KBN" , "依頼区分" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_FILM = new NodeInfo( "FILM" , "フィルム要否" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_REPORT_KBN = new NodeInfo( "REPORT_KBN" , "フィルム要否" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_IRAI_BYOMEI = new NodeInfo( "IRAI_BYOMEI" , "依頼病名" , NodeTypeEnum.ntData , 256);
		public static NodeInfo H2RORDER_KNS_PURPOSE = new NodeInfo( "KNS_PURPOSE" , "検査目的" , NodeTypeEnum.ntData , 256);
		public static NodeInfo H2RORDER_ODR_COMMENT = new NodeInfo( "ODR_COMMENT" , "補足コメント" , NodeTypeEnum.ntData , 1024);
		public static NodeInfo H2RORDER_START_DATE = new NodeInfo( "START_DATE" , "開始日" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_END_DATE = new NodeInfo( "END_DATE" , "終了日" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_EXEC_TIME = new NodeInfo( "EXEC_TIME" , "実施時刻" , NodeTypeEnum.ntData , 6);
		public static NodeInfo H2RORDER_ORDER_MODE = new NodeInfo( "ORDER_MODE" , "オーダーモード", NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_PRE_MED = new NodeInfo( "PRE_MED" , "検査前投薬" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_PORTABLE_KBN= new NodeInfo( "PORTABLE_KBN", "出棟先区分" , NodeTypeEnum.ntData , 1);
		public static NodeInfo H2RORDER_PORTABLE_CD = new NodeInfo( "PORTABLE_CD" , "出棟先コード" , NodeTypeEnum.ntData , 3);
		public static NodeInfo H2RORDER_ORD_FLG1 = new NodeInfo( "ORD_FLG1" , "同意書フラグ" , NodeTypeEnum.ntData , 1);
		//検査前投与薬情報（×ｎ OCCURS）
		public static NodeInfo H2RORDER_YKH_SUMM = new NodeInfo( "YKH_SUMM" , "前投与薬個数" , NodeTypeEnum.ntArray, 2);
		public static NodeInfo H2RORDER_YKH_LIST = new NodeInfo( "YKH_LIST" , "薬品リスト" , NodeTypeEnum.ntAggregate , -1);
		public static NodeInfo H2RORDER_YKH_ID = new NodeInfo( "YKH_ID" , "薬品コード" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_YKH_HYOUJI_1= new NodeInfo( "YKH_HYOUJI_1", "薬品表示名称１", NodeTypeEnum.ntData , 60);
		public static NodeInfo H2RORDER_YOURYO = new NodeInfo( "YOURYO" , "用量" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_TANI_CD = new NodeInfo( "TANI_CD" , "単位コード", NodeTypeEnum.ntData , 2);
		public static NodeInfo H2RORDER_DSP_TANI = new NodeInfo( "DSP_TANI" , "表示単位" , NodeTypeEnum.ntData , 4);
		//検査予約情報（×ｎ OCCURS）
		public static NodeInfo H2RORDER_YK_SUMM = new NodeInfo( "YK_SUMM" , "予約数" , NodeTypeEnum.ntArray, 5);
		public static NodeInfo H2RORDER_YK_LIST = new NodeInfo( "YK_LIST" , "予約リスト" , NodeTypeEnum.ntAggregate , -1);
		public static NodeInfo H2RORDER_YK_DATE = new NodeInfo( "YK_DATE" , "開始日" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_YK_TIME = new NodeInfo( "YK_TIME" , "検査開始予定時刻", NodeTypeEnum.ntData , 6);
		public static NodeInfo H2RORDER_YK_ED_TIME= new NodeInfo( "YK_ED_TIME", "検査終了予定時刻", NodeTypeEnum.ntData , 6);
		//オーダ部位情報
		//部位基本情報（×ｎ OCCURS）
		public static NodeInfo H2RORDER_BUI_SUMM = new NodeInfo( "BUI_SUMM" , "部位数" , NodeTypeEnum.ntArray, 5);
		public static NodeInfo H2RORDER_BUI_LIST = new NodeInfo( "BUI_LIST" , "部位リスト" , NodeTypeEnum.ntAggregate , -1);
		public static NodeInfo H2RORDER_BUI_SEQ = new NodeInfo( "BUI_SEQ" , "部位番号" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI_CD = new NodeInfo( "BUI_CD" , "部位コード" , NodeTypeEnum.ntData , 8);
		public static NodeInfo H2RORDER_BUI_IMG_CD = new NodeInfo( "BUI_IMG_CD" , "部位イメージコード", NodeTypeEnum.ntData , 2);
		public static NodeInfo H2RORDER_BUI_LEFT = new NodeInfo( "BUI_LEFT" , "部位LEFT" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI_TOP = new NodeInfo( "BUI_TOP" , "部位TOP" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI_WIDTH = new NodeInfo( "BUI_WIDTH" , "部位WIDTH" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI_HEIGHT = new NodeInfo( "BUI_HEIGHT" , "部位HEIGHT" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI_SHAPE = new NodeInfo( "BUI_SHAPE" , "部位SHAPE" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI1_C_CD = new NodeInfo( "BUI1_C_CD" , "部位コメントコード1", NodeTypeEnum.ntData , 3);
		public static NodeInfo H2RORDER_BUI1_C = new NodeInfo( "BUI1_C" , "部位コメント1" , NodeTypeEnum.ntData , 60);
		public static NodeInfo H2RORDER_BUI1_LEFT = new NodeInfo( "BUI1_LEFT" , "部位LEFT1" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI1_TOP = new NodeInfo( "BUI1_TOP" , "部位TOP1" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI1_WIDTH = new NodeInfo( "BUI1_WIDTH" , "部位WIDTH1" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI1_HEIGHT= new NodeInfo( "BUI1_HEIGHT", "部位HEIGHT1" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI1_SHAPE = new NodeInfo( "BUI1_SHAPE" , "部位SHAPE1" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI2_C = new NodeInfo( "BUI2_C" , "部位コメント2" , NodeTypeEnum.ntData , 60);
		public static NodeInfo H2RORDER_BUI2_LEFT = new NodeInfo( "BUI2_LEFT" , "部位LEFT2" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI2_TOP = new NodeInfo( "BUI2_TOP" , "部位TOP2" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI2_WIDTH = new NodeInfo( "BUI2_WIDTH" , "部位WIDTH2" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI2_HEIGHT= new NodeInfo( "BUI2_HEIGHT", "部位HEIGHT2" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI2_SHAPE = new NodeInfo( "BUI2_SHAPE" , "部位SHAPE2" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI3_C = new NodeInfo( "BUI3_C" , "部位コメント3" , NodeTypeEnum.ntData , 60);
		public static NodeInfo H2RORDER_BUI3_LEFT = new NodeInfo( "BUI3_LEFT" , "部位LEFT3" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI3_TOP = new NodeInfo( "BUI3_TOP" , "部位TOP3" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI3_WIDTH = new NodeInfo( "BUI3_WIDTH" , "部位WIDTH3" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI3_HEIGHT = new NodeInfo( "BUI3_HEIGHT", "部位HEIGHT3" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_BUI3_SHAPE = new NodeInfo( "BUI3_SHAPE" , "部位SHAPE3" , NodeTypeEnum.ntData , 5);
		public static NodeInfo H2RORDER_FREE_C = new NodeInfo( "FREE_C" , "フリーコメント" , NodeTypeEnum.ntData , 256);
		//部位詳細情報（×ｎ OCCURS）
		public static NodeInfo H2RORDER_COMMENT_SUMM= new NodeInfo( "COMMENT_SUMM" , "コメント数" , NodeTypeEnum.ntArray, 5);
		public static NodeInfo H2RORDER_COMMENT_LIST= new NodeInfo( "COMMENT_LIST" , "コメントリスト" , NodeTypeEnum.ntAggregate , -1);
		public static NodeInfo H2RORDER_COMMENT_KBN = new NodeInfo( "COMMENT_KBN" , "コメント区分" , NodeTypeEnum.ntData , 2);
		public static NodeInfo H2RORDER_COMMENT_CODE= new NodeInfo( "COMMENT_CODE" , "コメントコード" , NodeTypeEnum.ntData , 3);
		//体位方向情報（×ｎ OCCURS）
		public static NodeInfo H2RORDER_TAII_SUMM= new NodeInfo( "TAII_SUMM" , "体位方向数" , NodeTypeEnum.ntArray, 5);
		public static NodeInfo H2RORDER_TAII_LIST= new NodeInfo( "TAII_LIST" , "体位リスト" , NodeTypeEnum.ntAggregate , -1);
		public static NodeInfo H2RORDER_TAII_CD = new NodeInfo( "TAII_CD" , "体位" , NodeTypeEnum.ntData , 3);
		public static NodeInfo H2RORDER_HOKO_CD = new NodeInfo( "HOKO_CD" , "方向" , NodeTypeEnum.ntData , 3);
	}
}
