namespace RISCommonLibrary.Lib.Msg.Common.LeaveHospitalize
{
	public interface ILeaveHospitalize
	{
		/// <summary>
		/// 退院情報部
		/// </summary>
		LeaveHospitalizeAggregate LeaveHospitalize
		{
			get;
			set;
		}
	}
}
