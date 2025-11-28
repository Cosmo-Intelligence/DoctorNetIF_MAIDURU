using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.OrderInfo.Detail
{
	public class H2ROrderYKAggregate : AggregateNode
	{

		/// <summary>
		/// 開始日 
		/// </summary>
		public DataNode YK_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 検査開始予定時刻 
		/// </summary>
		public DataNode YK_TIME
		{
			get;
			set;
		}

		/// <summary>
		/// 検査終了予定時刻 
		/// </summary>
		public DataNode YK_ED_TIME
		{
			get;
			set;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2ROrderYKAggregate()
			: base(HISRISOrderInfoNodeInfo.H2RORDER_YK_LIST)
		{
			YK_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_YK_DATE));
			YK_TIME  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_YK_TIME));
			YK_ED_TIME = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_YK_ED_TIME));
		}
	}
}
