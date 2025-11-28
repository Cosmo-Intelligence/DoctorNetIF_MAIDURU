using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.ExamInfo.Detail
{
	public class H2RExamISOAggregate : AggregateNode
	{

		/// <summary>
		/// 放射線医薬品コード
		/// </summary>
		public DataNode ISO_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 放射線医薬品使用量
		/// </summary>
		public DataNode ISO_CNT
		{
			get;
			set;
		}

		/// <summary>
		/// 放射線医薬品単位コード
		/// </summary>
		public DataNode ISO_STD_CD
		{
			get;
			set;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2RExamISOAggregate()
			: base(HISRISExamInfoNodeInfo.H2REXAM_ISO_LIST)
		{
			ISO_CD = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_ISO_CD));
			ISO_CNT = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_ISO_CNT));
			ISO_STD_CD = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_ISO_STD_CD));
		}
	}
}
