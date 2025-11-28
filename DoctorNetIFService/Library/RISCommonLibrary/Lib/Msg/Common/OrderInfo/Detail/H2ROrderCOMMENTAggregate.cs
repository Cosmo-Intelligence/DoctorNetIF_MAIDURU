using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.OrderInfo.Detail
{
	public class H2ROrderCOMMENTAggregate : AggregateNode
	{

		/// <summary>
		/// コメント区分 
		/// </summary>
		public DataNode COMMENT_KBN
		{
			get;
			set;
		}

		/// <summary>
		/// コメントコード 
		/// </summary>
		public DataNode COMMENT_CODE
		{
			get;
			set;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2ROrderCOMMENTAggregate()
			: base(HISRISOrderInfoNodeInfo.H2RORDER_COMMENT_LIST)
		{
			COMMENT_KBN  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_COMMENT_KBN));
			COMMENT_CODE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_COMMENT_CODE));
		}
	}
}
