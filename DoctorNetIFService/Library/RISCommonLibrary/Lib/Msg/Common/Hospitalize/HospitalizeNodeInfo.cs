namespace RISCommonLibrary.Lib.Msg.Common.Hospitalize
{
	/// <summary>
	/// 入院情報部のノード定義
	/// </summary>
	class HospitalizeNodeInfo
	{
		public static NodeInfo H2RHSP_ROOT = new NodeInfo("HSP", "入院情報ﾃﾞｰﾀ", NodeTypeEnum.ntAggregate, -1);

		public static NodeInfo H2RHSP_PT_ID = new NodeInfo("PT_ID", "患者ID", NodeTypeEnum.ntData, 10);
		public static NodeInfo H2RHSP_NYUGAI_KBN = new NodeInfo("NYUGAI_KBN", "入外区分", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RHSP_NYUIN_DATE = new NodeInfo("NYUIN_DATE", "入院日", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RHSP_KA_CD = new NodeInfo("KA_CD", "診療科コード", NodeTypeEnum.ntData, 3);
		public static NodeInfo H2RHSP_BYOTO_CD = new NodeInfo("BYOTO_CD", "病棟コード", NodeTypeEnum.ntData, 3);
		public static NodeInfo H2RHSP_ROOM_CD = new NodeInfo("ROOM_CD", "病室コード", NodeTypeEnum.ntData, 4);
		public static NodeInfo H2RHSP_FILLER = new NodeInfo("FILLER", "FILLER", NodeTypeEnum.ntData, 21);
	}
}
