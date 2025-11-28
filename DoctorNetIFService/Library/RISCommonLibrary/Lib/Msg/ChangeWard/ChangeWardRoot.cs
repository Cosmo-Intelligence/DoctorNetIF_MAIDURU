using RISCommonLibrary.Lib.Msg.Common;
using RISCommonLibrary.Lib.Msg.Common.ChangeWard;

namespace RISCommonLibrary.Lib.Msg.ChangeWard
{
	/// <summary>
	/// 転棟情報メッセージルート
	/// </summary>
	public class ChangeWardRoot : BaseRootNode, IChangeWard
	{
		#region field
		
		#endregion

		#region property
		
		/// <summary>
		/// 患者属性部
		/// </summary>
		public ChangeWardAggregate ChangeWard
		{
			get;
			set;
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ChangeWardRoot()
			: base(ChangeWardNodeInfo.H2RCB_ROOT)
		{

			ChangeWard = new ChangeWardAggregate();
			Add(ChangeWard);
		}
		#endregion

	}
}
