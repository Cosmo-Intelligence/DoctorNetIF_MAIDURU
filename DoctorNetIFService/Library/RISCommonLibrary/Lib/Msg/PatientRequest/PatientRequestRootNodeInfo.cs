namespace RISCommonLibrary.Lib.Msg.PatientRequest
{
	/// <summary>
	/// 患者情報要求のノード定義
	/// </summary>
	class PatientRequestRootNodeInfo
	{
		public static NodeInfo REQUEST_PATIENT_ROOT = new NodeInfo("REQUEST_PATIENT_ROOT", "患者情報要求", NodeTypeEnum.ntAggregate, -1);
	}
}
