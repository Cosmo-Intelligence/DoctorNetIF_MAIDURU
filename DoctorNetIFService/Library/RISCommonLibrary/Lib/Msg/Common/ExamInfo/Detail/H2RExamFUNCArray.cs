using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.ExamInfo.Detail
{
	public class H2RExamFUNCArray : ArrayNode
	{
		#region property

		/// <summary>
		/// インデクサ
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public new H2RExamFUNCAggregate this[int index]
		{
			get
			{
				return (H2RExamFUNCAggregate)base[index];
			}
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2RExamFUNCArray()
			: base(HISRISExamInfoNodeInfo.H2REXAM_FUNC_SUMM)
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
			return typeof(H2RExamFUNCAggregate);
		}

		#endregion

	}
}
