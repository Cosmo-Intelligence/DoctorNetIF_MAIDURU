using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.ExamInfo.Detail
{
	public class H2RExamFUNCAggregate : AggregateNode
	{
		/// <summary>
		/// 機能検査区分
		/// </summary>
		public DataNode FUNC_KBN
		{
			get;
			set;
		}

		/// <summary>
		/// 機能検査コード
		/// </summary>
		public DataNode FUNC_CD
		{
			get;
			set;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2RExamFUNCAggregate()
			: base(HISRISExamInfoNodeInfo.H2REXAM_FUNC_LIST)
		{
			FUNC_KBN = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_FUNC_KBN));
			FUNC_CD = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_FUNC_CD));
		}
	}
}
