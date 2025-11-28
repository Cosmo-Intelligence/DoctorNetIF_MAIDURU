namespace RISCommonLibrary.Lib.Msg.Common.ChangeWard
{
	/// <summary>
	/// 転棟情報部のノード定義
	/// </summary>
	class ChangeWardNodeInfo
	{
		public static NodeInfo H2RCB_ROOT = new NodeInfo("CB", "転棟情報ﾃﾞｰﾀ", NodeTypeEnum.ntAggregate, -1);

		public static NodeInfo H2RCB_PT_ID = new NodeInfo("PT_ID", "患者ID", NodeTypeEnum.ntData, 10);
		public static NodeInfo H2RCB_CHG_DATE = new NodeInfo("CHG_DATE", "変更開始日", NodeTypeEnum.ntData, 8);
		public static NodeInfo H2RCB_IDO_BYOTO_CD = new NodeInfo("IDO_BYOTO_CD", "移動先病棟コード", NodeTypeEnum.ntData, 3);
		public static NodeInfo H2RCB_IDO_ROOM_CD = new NodeInfo("IDO_ROOM_CD", "移動先病室コード", NodeTypeEnum.ntData, 4);
		public static NodeInfo H2RCB_FILLER = new NodeInfo("FILLER", "FILLER", NodeTypeEnum.ntData, 25);
	}
}
