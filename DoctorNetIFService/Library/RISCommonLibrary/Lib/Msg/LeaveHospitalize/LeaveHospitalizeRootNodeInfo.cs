namespace RISCommonLibrary.Lib.Msg.LeaveHospitalize
{
	/// <summary>
	/// 退院情報のノード定義
	/// </summary>
	class LeaveHospitalizeRootNodeInfo
	{
		public static NodeInfo H2RLH_ROOT = new NodeInfo("LH", "退院情報ﾃﾞｰﾀ", NodeTypeEnum.ntAggregate, -1);
	}
}
