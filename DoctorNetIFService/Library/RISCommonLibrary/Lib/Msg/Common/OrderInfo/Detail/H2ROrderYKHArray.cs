using System;

namespace RISCommonLibrary.Lib.Msg.Common.OrderInfo.Detail
{
	public class H2ROrderYKHArray : ArrayNode
	{
		#region property

		/// <summary>
		/// インデクサ
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public new H2ROrderYKHAggregate this[int index]
		{
			get
			{
				return (H2ROrderYKHAggregate)base[index];
			}
		}

		#endregion

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2ROrderYKHArray()
			: base(HISRISOrderInfoNodeInfo.H2RORDER_YKH_SUMM)
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
			return typeof(H2ROrderYKHAggregate);
		}

		#endregion

	}
}
