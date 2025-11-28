namespace RISCommonLibrary.Lib.Msg.Common.ExamInfo.Detail
{
	public class H2RExamCOMMENTAggregate : AggregateNode
	{

		/// <summary>
		/// コメント区分
		/// </summary>
		public DataNode COMMENT_KBN
		{
			get;
			set;
		}

		/// <summary>
		/// コメントコード
		/// </summary>
		public DataNode COMMENT_CODE
		{
			get;
			set;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2RExamCOMMENTAggregate()
			: base(HISRISExamInfoNodeInfo.H2REXAM_COMMENT_LIST)
		{
			COMMENT_KBN = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_COMMENT_KBN));
			COMMENT_CODE = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_COMMENT_CODE));
		}
	}
}
