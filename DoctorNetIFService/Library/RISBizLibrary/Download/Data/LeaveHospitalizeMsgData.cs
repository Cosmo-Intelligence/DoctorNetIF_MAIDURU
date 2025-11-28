using RISBizLibrary.Data;
using RISCommonLibrary.Lib.Msg.LeaveHospitalize;

namespace RISBizLibrary.Download.Data
{
	public class LeaveHospitalizeMsgData : BaseMsgData
	{

		#region メッセージ

		/// <summary>
		/// 退院メッセージ
		/// </summary>
		public new LeaveHospitalizeMsg Request
		{
			get
			{
				return base.Request as LeaveHospitalizeMsg;
			}
			set
			{
				base.Request = value;
			}
		}

		#endregion

		#region メッセージから取得

		#endregion
	}
}
