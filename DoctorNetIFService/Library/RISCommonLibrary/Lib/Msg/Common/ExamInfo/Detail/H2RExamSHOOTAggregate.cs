using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.ExamInfo.Detail
{
	public class H2RExamSHOOTAggregate : AggregateNode
	{

		/// <summary>
		/// 撮影部位コード
		/// </summary>
		public DataNode SHOOT_BUI_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 撮影コマ数
		/// </summary>
		public DataNode SHOOT_CNT
		{
			get;
			set;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2RExamSHOOTAggregate()
			: base(HISRISExamInfoNodeInfo.H2REXAM_SHOOT_LIST)
		{
			SHOOT_BUI_CD = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_SHOOT_BUI_CD));
			SHOOT_CNT = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_SHOOT_CNT));
		}
	}
}
