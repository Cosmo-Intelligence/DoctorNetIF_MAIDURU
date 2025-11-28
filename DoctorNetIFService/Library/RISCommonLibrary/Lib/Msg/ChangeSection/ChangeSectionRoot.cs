using RISCommonLibrary.Lib.Msg.Common;
using RISCommonLibrary.Lib.Msg.Common.ChangeSection;

namespace RISCommonLibrary.Lib.Msg.ChangeSection
{
	/// <summary>
	/// 転科情報メッセージルート
	/// </summary>
	public class ChangeSectionRoot : BaseRootNode, IChangeSection
	{
		#region field
		
		#endregion

		#region property
		
		/// <summary>
		/// 患者属性部
		/// </summary>
		public ChangeSectionAggregate ChangeSection
		{
			get;
			set;
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ChangeSectionRoot()
			: base(ChangeSectionNodeInfo.H2RCB_ROOT)
		{

			ChangeSection = new ChangeSectionAggregate();
			Add(ChangeSection);
		}
		#endregion

	}
}
