namespace RISCommonLibrary.Lib.Msg.Hospitalize
{
	/// <summary>
	/// 入院情報ﾃﾞｰﾀのノード定義
	/// </summary>
	class HospitalizeRootNodeInfo
	{
		public static NodeInfo H2RHSP_ROOT = new NodeInfo("HSP", "入院情報ﾃﾞｰﾀ", NodeTypeEnum.ntAggregate, -1);
	}
}
