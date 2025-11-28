using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.ExamInfo.Detail
{
	public class H2RExamDRUGAggregate : AggregateNode
	{

		/// <summary>
		/// 薬品コード
		/// </summary>
		public DataNode DRUG_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 薬品使用量
		/// </summary>
		public DataNode DRUG_CNT
		{
			get;
			set;
		}

		/// <summary>
		/// 薬品単位コード
		/// </summary>
		public DataNode DRUG_STD_CD
		{
			get;
			set;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2RExamDRUGAggregate()
			: base(HISRISExamInfoNodeInfo.H2REXAM_DRUG_LIST)
		{
			DRUG_CD = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_DRUG_CD));
			DRUG_CNT = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_DRUG_CNT));
			DRUG_STD_CD = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_DRUG_STD_CD));
		}
	}
}
