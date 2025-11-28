using RISCommonLibrary.Lib.Msg.Common;
using RISCommonLibrary.Lib.Msg.Common.ExamInfo;

namespace RISCommonLibrary.Lib.Msg.ExamInfo
{
	public class HISRISExamRoot : BaseRootNode, HISRISIExam
	{
		#region field

		#endregion

		#region property

		/// <summary>
		/// 実施情報部
		/// </summary>
		public HISRISExamInfoAggregate ExamRIS
		{
			get;
			set;
		}

		#endregion

		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public HISRISExamRoot()
			: base(HISRISExamRootNodeInfo.H2REXAM_ROOT)
		{

			ExamRIS = new HISRISExamInfoAggregate();
			Add(ExamRIS);
		}
		#endregion
	}
}
