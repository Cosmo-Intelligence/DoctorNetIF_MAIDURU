using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.ExamInfo.Detail
{
	public class H2RExamFILMAggregate : AggregateNode
	{

		/// <summary>
		/// フィルムコード
		/// </summary>
		public DataNode FILM_CD
		{
			get;
			set;
		}

		/// <summary>
		/// フィルム枚数
		/// </summary>
		public DataNode FILM_CNT
		{
			get;
			set;
		}

		/// <summary>
		/// 分画数
		/// </summary>
		public DataNode KAKU_CNT
		{
			get;
			set;
		}

		/// <summary>
		/// 照射回数
		/// </summary>
		public DataNode SATU_CNT
		{
			get;
			set;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2RExamFILMAggregate()
			: base(HISRISExamInfoNodeInfo.H2REXAM_FILM_LIST)
		{
			FILM_CD = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_FILM_CD));
			FILM_CNT = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_FILM_CNT));
			KAKU_CNT = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_KAKU_CNT));
			SATU_CNT = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_SATU_CNT));
		}
	}
}
