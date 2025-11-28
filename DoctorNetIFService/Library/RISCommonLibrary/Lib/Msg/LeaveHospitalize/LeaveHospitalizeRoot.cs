using RISCommonLibrary.Lib.Msg.Common;
using RISCommonLibrary.Lib.Msg.Common.LeaveHospitalize;

namespace RISCommonLibrary.Lib.Msg.LeaveHospitalize
{
	/// <summary>
	/// 退院情報メッセージルート
	/// </summary>
	public class LeaveHospitalizeRoot : BaseRootNode, ILeaveHospitalize
	{
		#region field
		
		#endregion

		#region property
		
		/// <summary>
		/// 患者属性部
		/// </summary>
		public LeaveHospitalizeAggregate LeaveHospitalize
		{
			get;
			set;
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public LeaveHospitalizeRoot()
			: base(LeaveHospitalizeNodeInfo.H2RLH_ROOT)
		{

			LeaveHospitalize = new LeaveHospitalizeAggregate();
			Add(LeaveHospitalize);
		}
		#endregion

	}
}
