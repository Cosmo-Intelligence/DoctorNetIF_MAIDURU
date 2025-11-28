using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.OrderInfo.Detail
{
	public class H2ROrderYKHAggregate : AggregateNode
	{

		/// <summary>
		/// 薬品コード 
		/// </summary>
		public DataNode YKH_ID
		{
			get;
			set;
		}

		/// <summary>
		/// 薬品表示名称１ 
		/// </summary>
		public DataNode YKH_HYOUJI_1
		{
			get;
			set;
		}

		/// <summary>
		/// 用量 
		/// </summary>
		public DataNode YOURYO
		{
			get;
			set;
		}

		/// <summary>
		/// 単位コード 
		/// </summary>
		public DataNode TANI_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 表示単位 
		/// </summary>
		public DataNode DSP_TANI
		{
			get;
			set;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2ROrderYKHAggregate()
			: base(HISRISOrderInfoNodeInfo.H2RORDER_YKH_LIST)
		{
			YKH_ID  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_YKH_ID));
			YKH_HYOUJI_1 = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_YKH_HYOUJI_1));
			YOURYO  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_YOURYO));
			TANI_CD  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_TANI_CD));
			DSP_TANI  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_DSP_TANI));
		}
	}
}
