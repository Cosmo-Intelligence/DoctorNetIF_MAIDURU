using System;

namespace RISCommonLibrary.Lib.Msg.Common.OrderInfo.Detail
{
	public class H2ROrderCOMMENTArray : ArrayNode
	{
		#region property

		/// <summary>
		/// インデクサ
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public new H2ROrderCOMMENTAggregate this[int index]
		{
			get
			{
				return (H2ROrderCOMMENTAggregate)base[index];
			}
		}

		#endregion

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2ROrderCOMMENTArray()
			: base(HISRISOrderInfoNodeInfo.H2RORDER_COMMENT_SUMM)
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
			return typeof(H2ROrderCOMMENTAggregate);
		}

		#endregion

	}
}
