using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.ExamInfo.Detail
{
	public class H2RExamKZIAggregate : AggregateNode
	{

		/// <summary>
		/// 器材コード
		/// </summary>
		public DataNode KZI_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 器材使用量
		/// </summary>
		public DataNode KZI_CNT
		{
			get;
			set;
		}

		/// <summary>
		/// 器材単位コード
		/// </summary>
		public DataNode KZI_STD_CD
		{
			get;
			set;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2RExamKZIAggregate()
			: base(HISRISExamInfoNodeInfo.H2REXAM_KZI_LIST)
		{
			KZI_CD = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_KZI_CD));
			KZI_CNT = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_KZI_CNT));
			KZI_STD_CD = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_KZI_STD_CD));
		}
	}
}
