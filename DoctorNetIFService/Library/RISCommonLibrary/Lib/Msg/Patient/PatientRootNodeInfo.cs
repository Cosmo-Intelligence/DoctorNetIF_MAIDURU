namespace RISCommonLibrary.Lib.Msg.Patient
{
	/// <summary>
	/// 患者情報のノード定義
	/// </summary>
	class PatientRootNodeInfo
	{
		public static NodeInfo H2RPATIENT_ROOT = new NodeInfo("RECEIPT", "患者情報ﾃﾞｰﾀ", NodeTypeEnum.ntAggregate, -1);
	}
}
