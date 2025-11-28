namespace RISCommonLibrary.Lib.Msg.Common.PatientRequest
{
	/// <summary>
	/// 患者情報要求のノード定義
	/// </summary>
	class HISRTPatientRequestInfo
	{
		public static NodeInfo REQUEST_PATIENT_ROOT = new NodeInfo("REQUEST_PATIENT_ROOT", "患者情報要求", NodeTypeEnum.ntAggregate, -1);
		public static NodeInfo H2RREQUEST_PT_ID = new NodeInfo("PT_ID", "患者ID", NodeTypeEnum.ntData, 10);

	}
}
