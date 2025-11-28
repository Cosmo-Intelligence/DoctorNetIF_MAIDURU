using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.ExamInfo.Detail
{
	public class H2RExamTAIIArray : ArrayNode
	{
		#region property

		/// <summary>
		/// インデクサ
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public new H2RExamTAIIAggregate this[int index]
		{
			get
			{
				return (H2RExamTAIIAggregate)base[index];
			}
		}

		#endregion

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2RExamTAIIArray()
			: base(HISRISExamInfoNodeInfo.H2REXAM_TAII_SUMM)
		{

		}
		#endregion

		#region method

		/// <summary>
		/// 繰り返すListクラス
		/// </summary>
		/// <returns></returns>
		public override Type GetElementClass()
		{
			return typeof(H2RExamTAIIAggregate);
		}

		#endregion

	}
}
