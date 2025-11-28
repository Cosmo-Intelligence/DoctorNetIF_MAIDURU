namespace RISCommonLibrary.Lib.Msg.Common.ChangeSection
{
	/// <summary>
	/// 転科情報部のノード定義
	/// </summary>
	class ChangeSectionNodeInfo
	{
		public static NodeInfo H2RCB_ROOT = new NodeInfo("CB", "転科情報ﾃﾞｰﾀ", NodeTypeEnum.ntAggregate, -1);

		public static NodeInfo H2RCB_PT_ID = new NodeInfo("PT_ID", "患者ID", NodeTypeEnum.ntData, 10);
		public static NodeInfo H2RCB_CHG_DATE = new NodeInfo("CHG_DATE", "変更開始日", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RCB_IDO_KA_CD = new NodeInfo("IDO_KA_CD", "移動先診療科コード", NodeTypeEnum.ntData, 3);
		public static NodeInfo H2RCB_FILLER = new NodeInfo("FILLER", "FILLER", NodeTypeEnum.ntData, 29);
	}
}
