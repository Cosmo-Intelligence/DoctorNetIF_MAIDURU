using RISCommonLibrary.Lib.Msg.Common;
using RISCommonLibrary.Lib.Msg.Common.Patient;

namespace RISCommonLibrary.Lib.Msg.Patient
{
	/// <summary>
	/// 患者情報メッセージルート
	/// </summary>
	public class PatientRoot : BaseRootNode, IPatient
	{
		#region field
		
		#endregion

		#region property
		
		/// <summary>
		/// 患者属性部
		/// </summary>
		public PatientAggregate Patient
		{
			get;
			set;
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public PatientRoot()
			: base(PatientRootNodeInfo.H2RPATIENT_ROOT)
		{

			Patient = new PatientAggregate();
			Add(Patient);
		}
		#endregion

	}
}
