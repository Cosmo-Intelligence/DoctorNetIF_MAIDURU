namespace RISCommonLibrary.Lib.Msg.Common.Patient
{
	/// <summary>
	/// 患者情報のノード定義
	/// </summary>
	class PatientNodeInfo
	{
		public static NodeInfo H2RPATIENT_ROOT = new NodeInfo("PATIENT", "患者情報ﾃﾞｰﾀ", NodeTypeEnum.ntAggregate, -1);

		// 患者属性
		public static NodeInfo H2RPATIENT_PT_ID = new NodeInfo("PT_ID", "患者ID", NodeTypeEnum.ntData, 10);
		public static NodeInfo H2RPATIENT_PT_KN_NAME = new NodeInfo("PT_KN_NAME", "患者氏名（カナ）", NodeTypeEnum.ntData, 23);
		public static NodeInfo H2RPATIENT_PT_KJ_NAME = new NodeInfo("PT_KJ_NAME", "患者氏名（漢字）", NodeTypeEnum.ntData, 20);
		public static NodeInfo H2RPATIENT_PT_SEX = new NodeInfo("PT_SEX", "性別", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_PT_BIRTH = new NodeInfo("PT_BIRTH", "生年月日", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RPATIENT_PT_STATUS = new NodeInfo("PT_STATUS", "患者状態", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_ROOM_CD = new NodeInfo("ROOM_CD", "病室コード", NodeTypeEnum.ntData, 4);
		public static NodeInfo H2RPATIENT_ROOM_NAME = new NodeInfo("ROOM_NAME", "病室名称", NodeTypeEnum.ntData, 20);
		public static NodeInfo H2RPATIENT_PT_ZIP = new NodeInfo("PT_ZIP", "郵便番号", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RPATIENT_PT_ADDR = new NodeInfo("PT_ADDR", "住所", NodeTypeEnum.ntData, 80);
		public static NodeInfo H2RPATIENT_PT_ADDR_CD = new NodeInfo("PT_ADDR_CD", "住所コード", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RPATIENT_PT_TEL = new NodeInfo("PT_TEL", "電話番号", NodeTypeEnum.ntData, 18);
		public static NodeInfo H2RPATIENT_FILLER1 = new NodeInfo("FILLER1", "患者フラグ1", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_FILLER2 = new NodeInfo("FILLER2", "FILLER2", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_FILLER3 = new NodeInfo("FILLER3", "FILLER3", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_FILLER4 = new NodeInfo("FILLER4", "FILLER4", NodeTypeEnum.ntData, 20);

		// 患者身体情報
		public static NodeInfo H2RPATIENT_BLOOD_ABO = new NodeInfo("BLOOD_ABO", "ABO式", NodeTypeEnum.ntData, 2);
		public static NodeInfo H2RPATIENT_BLOOD_RH = new NodeInfo("BLOOD_RH", "RH式", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_PT_HEIGHT = new NodeInfo("PT_HEIGHT", "身長", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RPATIENT_PT_WEIGHT = new NodeInfo("PT_WEIGHT", "体重", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RPATIENT_PT_WEIGHT_T = new NodeInfo("PT_WEIGHT_T", "体重単位", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_FILLER5 = new NodeInfo("FILLER5", "FILLER5", NodeTypeEnum.ntData, 20);

		// アレルギー情報
		public static NodeInfo H2RPATIENT_CONT_MED_ALGY1 = new NodeInfo("CONT_MED_ALGY1", "造影剤アレルギー", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_ALGY_DRAG_FLG = new NodeInfo("ALGY_DRAG_FLG", "薬物アレルギーフラグ", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_ALGY_FLOOD_FLG = new NodeInfo("ALGY_FLOOD_FLG", "食物アレルギーフラグ", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_KORIN_IJ_FLG = new NodeInfo("KORIN_IJ_FLG", "抗コリン剤筋注", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_GRUK_IJ_FLG = new NodeInfo("GRUK_IJ_FLG", "グルカゴン静注", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_ALGY_COMMENT = new NodeInfo("ALGY_COMMENT", "アレルギーコメント", NodeTypeEnum.ntData, 100);
		public static NodeInfo H2RPATIENT_CONT_MED_ALGY2 = new NodeInfo("CONT_MED_ALGY2", "ヨード造影剤アレルギー", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_FILLER6 = new NodeInfo("FILLER6", "FILLER6", NodeTypeEnum.ntData, 7);

		// 障害情報
		public static NodeInfo H2RPATIENT_LIMBS_SG_FLG = new NodeInfo("LIMBS_SG_FLG", "四肢障害フラグ", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_VISION_SG_FLG = new NodeInfo("VISION_SG_FLG", "視覚障害フラグ", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_AUDITORY_SG_FLG = new NodeInfo("AUDITORY_SG_FLG", "聴覚障害フラグ", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_SPEECH_SG_FLG = new NodeInfo("SPEECH_SG_FLG", "言語障害フラグ", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_MIND_SG_FLG = new NodeInfo("MIND_SG_FLG", "精神障害フラグ", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_ECXCRETION_SG_FLG = new NodeInfo("ECXCRETION_SG_FLG", "排泄障害フラグ", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_IDO_KBN = new NodeInfo("IDO_KBN", "移動レベル", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_FILLER7 = new NodeInfo("FILLER7", "FILLER7", NodeTypeEnum.ntData, 8);

		// 疾患情報
		public static NodeInfo H2RPATIENT_HEART_FLG = new NodeInfo("HEART_FLG", "心疾患", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_BPH_FLG = new NodeInfo("BPH_FLG", "前立腺肥大", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_DM_FLG = new NodeInfo("DM_FLG", "糖尿病", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_KOJSEN_FLG = new NodeInfo("KOJSEN_FLG", "甲状腺疾患", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_GLAUCOMA_FLG = new NodeInfo("GLAUCOMA_FLG", "緑内障", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_PREGNANT_FLG = new NodeInfo("PREGNANT_FLG", "妊娠フラグ", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_LIVER_FLG = new NodeInfo("LIVER_FLG", "肝機能障害", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_RENEAL_FLG = new NodeInfo("RENEAL_FLG", "腎機能障害", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_ASTHMA_FLG = new NodeInfo("ASTHMA_FLG", "気管支喘息", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_LUNG_FLG = new NodeInfo("LUNG_FLG", "肺疾患", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_HYPER_FLG = new NodeInfo("HYPER_FLG", "高血圧", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_BLEED_FLG = new NodeInfo("BLEED_FLG", "出血傾向", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_PLATELET_FLG = new NodeInfo("PLATELET_FLG", "抗凝固血小板療法", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_FILLER8 = new NodeInfo("FILLER8", "FILLER8", NodeTypeEnum.ntData, 7);

		// 検査結果情報
		public static NodeInfo H2RORDER_KEKKA1 = new NodeInfo("KEKKA1", "クレアチニン(結果数値)", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA1_DATE = new NodeInfo("KEKKA1_DATE", "クレアチニン(検査日)", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA2 = new NodeInfo("KEKKA2", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA2_DATE = new NodeInfo("KEKKA2_DATE", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA3 = new NodeInfo("KEKKA3", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA3_DATE = new NodeInfo("KEKKA3_DATE", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA4 = new NodeInfo("KEKKA4", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA4_DATE = new NodeInfo("KEKKA4_DATE", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA5 = new NodeInfo("KEKKA5", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA5_DATE = new NodeInfo("KEKKA_5DATE", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA6 = new NodeInfo("KEKKA6", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA6_DATE = new NodeInfo("KEKKA6_DATE", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA7 = new NodeInfo("KEKKA7", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA7_DATE = new NodeInfo("KEKKA7_DATE", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA8 = new NodeInfo("KEKKA8", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA8_DATE = new NodeInfo("KEKKA8_DATE", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA9 = new NodeInfo("KEKKA9", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA9_DATE = new NodeInfo("KEKKA9_DATE", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA10 = new NodeInfo("KEKKA10", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA10_DATE = new NodeInfo("KEKKA10_DATE", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA11 = new NodeInfo("KEKKA11", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA11_DATE = new NodeInfo("KEKKA11_DATE", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA12 = new NodeInfo("KEKKA12", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA12_DATE = new NodeInfo("KEKKA12_DATE", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA13 = new NodeInfo("KEKKA13", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA13_DATE = new NodeInfo("KEKKA13_DATE", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA14 = new NodeInfo("KEKKA14", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA14_DATE = new NodeInfo("KEKKA14_DATE", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA15 = new NodeInfo("KEKKA15", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA15_DATE = new NodeInfo("KEKKA_15DATE", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA16 = new NodeInfo("KEKKA16", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA16_DATE = new NodeInfo("KEKKA16_DATE", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA17 = new NodeInfo("KEKKA17", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA17_DATE = new NodeInfo("KEKKA17_DATE", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA18 = new NodeInfo("KEKKA18", "未使用", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RORDER_KEKKA18_DATE = new NodeInfo("KEKKA18_DATE", "未使用", NodeTypeEnum.ntData, 8);

		// 感染症情報
		public static NodeInfo H2RPATIENT_MRSA = new NodeInfo("MRSA", "MRSA", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_HB = new NodeInfo("HB", "HB", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_HC = new NodeInfo("HC", "HC", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_HIV = new NodeInfo("HIV", "HIV", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_RPR = new NodeInfo("RPR", "HIV", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_PS = new NodeInfo("PS", "緑膿菌", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_ATLV = new NodeInfo("ATLV", "ATLV抗体", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_TP = new NodeInfo("TP", "TP抗体", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_GBS = new NodeInfo("GBS", "GBS", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_LTBI = new NodeInfo("LTBI", "ツ反", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RPATIENT_KN_OTHER_NM = new NodeInfo("KN_OTHER_NM", "感染症フリー入力項目名称", NodeTypeEnum.ntData, 20);
		public static NodeInfo H2RPATIENT_KN_OTHER = new NodeInfo("KN_OTHER", "感染症フリー入力項目ステータス", NodeTypeEnum.ntData, 1);

	}
}
