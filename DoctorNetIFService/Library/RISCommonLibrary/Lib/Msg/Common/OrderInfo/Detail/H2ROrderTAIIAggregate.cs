using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.OrderInfo.Detail
{
	public class H2ROrderTAIIAggregate : AggregateNode
	{

		/// <summary>
		/// 体位 
		/// </summary>
		public DataNode TAII_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 方向 
		/// </summary>
		public DataNode HOKO_CD
		{
			get;
			set;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2ROrderTAIIAggregate()
			: base(HISRISOrderInfoNodeInfo.H2RORDER_TAII_LIST)
		{
			TAII_CD  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_TAII_CD));
			HOKO_CD  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_HOKO_CD));
		}
	}
}
