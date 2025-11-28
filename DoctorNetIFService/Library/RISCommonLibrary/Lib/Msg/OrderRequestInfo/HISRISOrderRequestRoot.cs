using System;
using RISCommonLibrary.Lib.Msg.Common;
using RISCommonLibrary.Lib.Msg.Common.OrderRequestInfo;

namespace RISCommonLibrary.Lib.Msg.OrderRequestInfo
{
	public class HISRISOrderRequestRoot : BaseRootNode, HISRISIOrderRequestInfo
	{
		#region field

		#endregion

		#region property

		/// <summary>
		/// 実施情報部
		/// </summary>
		public HISRISOrderRequestInfoAggregate OrderRequestInfoRIS
		{
			get;
			set;
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public HISRISOrderRequestRoot()
			: base(HISRISOrderRequestRootNodeInfo.H2RREQUEST_ROOT)
		{

			OrderRequestInfoRIS = new HISRISOrderRequestInfoAggregate();
			Add(OrderRequestInfoRIS);
		}
		#endregion
	}
}
