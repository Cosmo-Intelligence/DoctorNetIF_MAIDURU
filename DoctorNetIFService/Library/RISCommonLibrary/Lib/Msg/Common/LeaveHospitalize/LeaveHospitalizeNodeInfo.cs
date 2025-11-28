namespace RISCommonLibrary.Lib.Msg.Common.LeaveHospitalize
{
	/// <summary>
	/// 退院情報部のノード定義
	/// </summary>
	class LeaveHospitalizeNodeInfo
	{
		public static NodeInfo H2RLH_ROOT = new NodeInfo("LH", "退院情報ﾃﾞｰﾀ", NodeTypeEnum.ntAggregate, -1);

		public static NodeInfo H2RLH_PT_ID = new NodeInfo("PT_ID", "患者ID", NodeTypeEnum.ntData, 10);
		public static NodeInfo H2RLH_NYUGAI_KBN = new NodeInfo("NYUGAI_KBN", "入外区分", NodeTypeEnum.ntData, 1);
		public static NodeInfo H2RLH_OUT_DATE = new NodeInfo("OUT_DATE", "退室日", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RLH_LVE_REASON_CD = new NodeInfo("LVE_REASON_CD", "退院理由コード", NodeTypeEnum.ntData, 4);
		public static NodeInfo H2RLH_BYOTO_CD = new NodeInfo("BYOTO_CD", "退院病棟コード", NodeTypeEnum.ntData, 3);
		public static NodeInfo H2RLH_ROOM_CD = new NodeInfo("ROOM_CD", "退院病室コード", NodeTypeEnum.ntData, 4);
		public static NodeInfo H2RLH_FILLER = new NodeInfo("FILLER", "FILLER", NodeTypeEnum.ntData, 20);
	}
}
