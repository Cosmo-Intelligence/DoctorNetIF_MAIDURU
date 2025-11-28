using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.ExamInfo.Detail
{
	public class H2RExamBUIAggregate : AggregateNode
	{

		/// <summary>
		/// 部位番号
		/// </summary>
		public DataNode BUI_SEQ
		{
			get;
			set;
		}

		/// <summary>
		/// 部位コード
		/// </summary>
		public DataNode BUI_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 撮影室
		/// </summary>
		public DataNode ROOM_CD2
		{
			get;
			set;
		}

		/// <summary>
		/// 撮影機器コード
		/// </summary>
		public DataNode MAC_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 撮影条件（ｋｖ）
		/// </summary>
		public DataNode KV
		{
			get;
			set;
		}

		/// <summary>
		/// 撮影条件（ｍａ）
		/// </summary>
		public DataNode MA
		{
			get;
			set;
		}

		/// <summary>
		/// 撮影条件（ｓｅｃ）
		/// </summary>
		public DataNode SEC
		{
			get;
			set;
		}

		/// <summary>
		/// 撮影条件（ｃｍ）
		/// </summary>
		public DataNode LENG
		{
			get;
			set;
		}

		/// <summary>
		/// コメント数
		/// </summary>
		public H2RExamCOMMENTArray COMMENT_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 明細行繰返し回数(COMMENT)
		/// </summary>
		public DataNode H2REXAM_COMMENT_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 体位方向数
		/// </summary>
		public H2RExamTAIIArray TAII_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 明細行繰返し回数(TAII)
		/// </summary>
		public DataNode H2REXAM_TAII_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// フィルム数
		/// </summary>
		public H2RExamFILMArray FILM_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 明細行繰返し回数(FILM)
		/// </summary>
		public DataNode H2REXAM_FILM_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 撮影部位数
		/// </summary>
		public H2RExamSHOOTArray SHOOT_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 明細行繰返し回数(SHOOT)
		/// </summary>
		public DataNode H2REXAM_SHOOT_SUMM
		{
			get;
			set;
		}


		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2RExamBUIAggregate()
			: base(HISRISExamInfoNodeInfo.H2REXAM_BUI_LIST)
		{
			BUI_SEQ = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_BUI_SEQ));
			BUI_CD = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_BUI_CD));
			MAC_CD = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_MAC_CD));
			ROOM_CD2 = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_ROOM_CD2));
			KV = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_KV));
			MA = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_MA));
			SEC = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_SEC));
			LENG = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_LENG));

			COMMENT_SUMM = new H2RExamCOMMENTArray();
			Add(COMMENT_SUMM);

			TAII_SUMM = new H2RExamTAIIArray();
			Add(TAII_SUMM);

			FILM_SUMM = new H2RExamFILMArray();
			Add(FILM_SUMM);

			SHOOT_SUMM = new H2RExamSHOOTArray();
			Add(SHOOT_SUMM);
		}
	}
}
