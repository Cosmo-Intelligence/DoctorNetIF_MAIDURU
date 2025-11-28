using RISCommonLibrary.Lib.Msg.Common.OrderInfo;

namespace RISCommonLibrary.Lib.Msg.OrderInfo
{
	public class HISRISOrderRoot : BaseRootNode, HISRISIOrderInfo
	{
		#region field

		#endregion

		#region property

		/// <summary>
		/// 実施情報部
		/// </summary>
		public HISRISOrderInfoAggregate OrderInfo
		{
			get;
			set;
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public HISRISOrderRoot()
			: base(HISRISOrderRootNodeInfo.H2REXAM_ROOT)
		{

			OrderInfo = new HISRISOrderInfoAggregate();
			Add(OrderInfo);
		}
		#endregion
	}
}
