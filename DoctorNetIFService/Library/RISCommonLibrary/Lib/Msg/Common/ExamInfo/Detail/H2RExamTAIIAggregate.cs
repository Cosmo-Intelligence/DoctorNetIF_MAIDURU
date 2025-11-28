using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.ExamInfo.Detail
{
	public class H2RExamTAIIAggregate : AggregateNode
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
		public H2RExamTAIIAggregate()
			: base(HISRISExamInfoNodeInfo.H2REXAM_TAII_LIST)
		{
			TAII_CD = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_TAII_CD));
			HOKO_CD = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_HOKO_CD));
		}
	}
}
