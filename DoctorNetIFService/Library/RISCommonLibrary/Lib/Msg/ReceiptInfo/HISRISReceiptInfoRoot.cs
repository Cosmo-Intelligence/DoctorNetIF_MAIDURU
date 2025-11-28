using System;
using RISCommonLibrary.Lib.Msg.Common;
using RISCommonLibrary.Lib.Msg.Common.ReceiptInfo;

namespace RISCommonLibrary.Lib.Msg.ReceiptInfo
{
	public class HISRISReceiptInfoRoot : BaseRootNode, HISRISIReceiptInfo
	{
		#region field

		#endregion

		#region property

		/// <summary>
		/// 実施情報部
		/// </summary>
		public HISRISReceiptInfoAggregate ReceiptInfoRIS
		{
			get;
			set;
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public HISRISReceiptInfoRoot()
			: base(HISRISReceiptInfoRootNodeInfo.H2RRECEIPT_ROOT)
		{

			ReceiptInfoRIS = new HISRISReceiptInfoAggregate();
			Add(ReceiptInfoRIS);
		}
		#endregion
	}
}
