namespace RISCommonLibrary.Lib.Msg.Common.PatientRequest
{
	/// <summary>
	/// PatientAttribute属性
	/// </summary>
	public interface IPatientRequestAttribute
	{
		PatientRequestAttributeAggregate PatientRequestAttribute
		{
			get;
			set;
		}
	}
}
