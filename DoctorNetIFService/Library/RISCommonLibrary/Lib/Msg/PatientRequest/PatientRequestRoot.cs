using RISCommonLibrary.Lib.Msg.Common;
using RISCommonLibrary.Lib.Msg.Common.PatientRequest;

namespace RISCommonLibrary.Lib.Msg.PatientRequest
{
	/// <summary>
	/// 患者情報要求メッセージルート
	/// </summary>
	public class PatientRequestRoot : BaseRootNode, IPatientRequestAttribute
	{
		#region field
		
		#endregion

		#region property

		/// <summary>
		/// 患者属性部
		/// </summary>
		public PatientRequestAttributeAggregate PatientRequestAttribute
		{
			get;
			set;
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public PatientRequestRoot()
			: base(PatientRequestRootNodeInfo.REQUEST_PATIENT_ROOT)
		{
			PatientRequestAttribute = new PatientRequestAttributeAggregate();
			Add(PatientRequestAttribute);
		}
		#endregion

	}
}
