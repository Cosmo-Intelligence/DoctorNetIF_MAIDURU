using System;

namespace RISCommonLibrary.Lib.Msg.Common.OrderInfo.Detail
{
	public class H2ROrderYKArray : ArrayNode
	{
		#region property

		/// <summary>
		/// インデクサ
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public new H2ROrderYKAggregate this[int index]
		{
			get
			{
				return (H2ROrderYKAggregate)base[index];
			}
		}

		#endregion

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2ROrderYKArray()
			: base(HISRISOrderInfoNodeInfo.H2RORDER_YK_SUMM)
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
			return typeof(H2ROrderYKAggregate);
		}

		#endregion

	}
}
