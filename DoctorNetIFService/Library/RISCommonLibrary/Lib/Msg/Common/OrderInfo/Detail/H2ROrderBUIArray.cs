using System;

namespace RISCommonLibrary.Lib.Msg.Common.OrderInfo.Detail
{
	public class H2ROrderBUIArray : ArrayNode
	{
		#region property

		/// <summary>
		/// インデクサ
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public new H2ROrderBUIAggregate this[int index]
		{
			get
			{
				return (H2ROrderBUIAggregate)base[index];
			}
		}

		#endregion

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2ROrderBUIArray()
			: base(HISRISOrderInfoNodeInfo.H2RORDER_BUI_SUMM)
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
			return typeof(H2ROrderBUIAggregate);
		}

		#endregion

	}
}
