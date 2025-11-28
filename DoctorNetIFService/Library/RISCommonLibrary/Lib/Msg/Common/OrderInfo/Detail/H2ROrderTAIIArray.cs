using System;

namespace RISCommonLibrary.Lib.Msg.Common.OrderInfo.Detail
{
	public class H2ROrderTAIIArray : ArrayNode
	{
		#region property

		/// <summary>
		/// インデクサ
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public new H2ROrderTAIIAggregate this[int index]
		{
			get
			{
				return (H2ROrderTAIIAggregate)base[index];
			}
		}

		#endregion

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2ROrderTAIIArray()
			: base(HISRISOrderInfoNodeInfo.H2RORDER_TAII_SUMM)
		{

		}
		#endregion

		#region method

		/// <summary>
		/// 繰り返すListクラス
		/// </summary>
		/// <returns></returns>
		public override Type GetElementClass()
		{
			return typeof(H2ROrderTAIIAggregate);
		}

		#endregion

	}
}
