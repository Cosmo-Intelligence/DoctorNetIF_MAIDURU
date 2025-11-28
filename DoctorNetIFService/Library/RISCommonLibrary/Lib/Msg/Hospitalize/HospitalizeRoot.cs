using RISCommonLibrary.Lib.Msg.Common;
using RISCommonLibrary.Lib.Msg.Common.Hospitalize;

namespace RISCommonLibrary.Lib.Msg.Hospitalize
{
	/// <summary>
	/// 入院情報メッセージルート
	/// </summary>
	public class HospitalizeRoot : BaseRootNode, IHospitalize
	{
		#region field

		#endregion

		#region property

		/// <summary>
		/// 入院情報
		/// </summary>
		public HospitalizeAggregate Hospitalize
		{
			get;
			set;
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public HospitalizeRoot()
			: base(HospitalizeRootNodeInfo.H2RHSP_ROOT)
		{

			Hospitalize = new HospitalizeAggregate();
			Add(Hospitalize);
		}
		#endregion

	}
}
