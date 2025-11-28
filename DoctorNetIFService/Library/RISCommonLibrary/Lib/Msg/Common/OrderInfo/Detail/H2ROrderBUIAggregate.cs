using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RISCommonLibrary.Lib.Msg.Common.OrderInfo.Detail
{
	public class H2ROrderBUIAggregate : AggregateNode
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
		/// 部位イメージコード 
		/// </summary>
		public DataNode BUI_IMG_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 部位LEFT 
		/// </summary>
		public DataNode BUI_LEFT
		{
			get;
			set;
		}

		/// <summary>
		/// 部位TOP 
		/// </summary>
		public DataNode BUI_TOP
		{
			get;
			set;
		}

		/// <summary>
		/// 部位WIDTH 
		/// </summary>
		public DataNode BUI_WIDTH
		{
			get;
			set;
		}

		/// <summary>
		/// 部位HEIGHT 
		/// </summary>
		public DataNode BUI_HEIGHT
		{
			get;
			set;
		}

		/// <summary>
		/// 部位SHAPE 
		/// </summary>
		public DataNode BUI_SHAPE
		{
			get;
			set;
		}

		/// <summary>
		/// 部位コメントコード1 
		/// </summary>
		public DataNode BUI1_C_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 部位コメント1 
		/// </summary>
		public DataNode BUI1_C
		{
			get;
			set;
		}

		/// <summary>
		/// 部位LEFT1 
		/// </summary>
		public DataNode BUI1_LEFT
		{
			get;
			set;
		}

		/// <summary>
		/// 部位TOP1 
		/// </summary>
		public DataNode BUI1_TOP
		{
			get;
			set;
		}

		/// <summary>
		/// 部位WIDTH1 
		/// </summary>
		public DataNode BUI1_WIDTH
		{
			get;
			set;
		}

		/// <summary>
		/// 部位HEIGHT1 
		/// </summary>
		public DataNode BUI1_HEIGHT
		{
			get;
			set;
		}

		/// <summary>
		/// 部位SHAPE1 
		/// </summary>
		public DataNode BUI1_SHAPE
		{
			get;
			set;
		}

		/// <summary>
		/// 部位コメント2 
		/// </summary>
		public DataNode BUI2_C
		{
			get;
			set;
		}

		/// <summary>
		/// 部位LEFT2 
		/// </summary>
		public DataNode BUI2_LEFT
		{
			get;
			set;
		}

		/// <summary>
		/// 部位TOP2 
		/// </summary>
		public DataNode BUI2_TOP
		{
			get;
			set;
		}

		/// <summary>
		/// 部位WIDTH2 
		/// </summary>
		public DataNode BUI2_WIDTH
		{
			get;
			set;
		}

		/// <summary>
		/// 部位HEIGHT2 
		/// </summary>
		public DataNode BUI2_HEIGHT
		{
			get;
			set;
		}

		/// <summary>
		/// 部位SHAPE2 
		/// </summary>
		public DataNode BUI2_SHAPE
		{
			get;
			set;
		}

		/// <summary>
		/// 部位コメント3 
		/// </summary>
		public DataNode BUI3_C
		{
			get;
			set;
		}

		/// <summary>
		/// 部位LEFT3 
		/// </summary>
		public DataNode BUI3_LEFT
		{
			get;
			set;
		}

		/// <summary>
		/// 部位TOP3 
		/// </summary>
		public DataNode BUI3_TOP
		{
			get;
			set;
		}

		/// <summary>
		/// 部位WIDTH3 
		/// </summary>
		public DataNode BUI3_WIDTH
		{
			get;
			set;
		}

		/// <summary>
		/// 部位HEIGHT3 
		/// </summary>
		public DataNode BUI3_HEIGHT
		{
			get;
			set;
		}

		/// <summary>
		/// 部位SHAPE3 
		/// </summary>
		public DataNode BUI3_SHAPE
		{
			get;
			set;
		}

		/// <summary>
		/// フリーコメント 
		/// </summary>
		public DataNode FREE_C
		{
			get;
			set;
		}


		/// <summary>
		/// コメント数 
		/// </summary>
		public H2ROrderCOMMENTArray COMMENT_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 明細行繰返し回数(COMMENT) 
		/// </summary>
		public DataNode H2RORDER_COMMENT_SUMM
		{
			get;
			set;
		}


		/// <summary>
		/// 体位方向数 
		/// </summary>
		public H2ROrderTAIIArray TAII_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 明細行繰返し回数(TAII) 
		/// </summary>
		public DataNode H2RORDER_TAII_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public H2ROrderBUIAggregate()
			: base(HISRISOrderInfoNodeInfo.H2RORDER_BUI_LIST)
		{
			BUI_SEQ  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI_SEQ));
			BUI_CD  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI_CD));
			BUI_IMG_CD  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI_IMG_CD));
			BUI_LEFT  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI_LEFT));
			BUI_TOP  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI_TOP));
			BUI_WIDTH  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI_WIDTH));
			BUI_HEIGHT  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI_HEIGHT));
			BUI_SHAPE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI_SHAPE));
			BUI1_C_CD  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI1_C_CD));
			BUI1_C  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI1_C));
			BUI1_LEFT  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI1_LEFT));
			BUI1_TOP  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI1_TOP));
			BUI1_WIDTH  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI1_WIDTH));
			BUI1_HEIGHT = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI1_HEIGHT));
			BUI1_SHAPE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI1_SHAPE));
			BUI2_C  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI2_C));
			BUI2_LEFT  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI2_LEFT));
			BUI2_TOP  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI2_TOP));
			BUI2_WIDTH  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI2_WIDTH));
			BUI2_HEIGHT = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI2_HEIGHT));
			BUI2_SHAPE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI2_SHAPE));
			BUI3_C  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI3_C));
			BUI3_LEFT  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI3_LEFT));
			BUI3_TOP  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI3_TOP));
			BUI3_WIDTH  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI3_WIDTH));
			BUI3_HEIGHT = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI3_HEIGHT));
			BUI3_SHAPE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BUI3_SHAPE));
			FREE_C  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_FREE_C));

			COMMENT_SUMM  = new H2ROrderCOMMENTArray();
			Add(COMMENT_SUMM);

			TAII_SUMM  = new H2ROrderTAIIArray();
			Add(TAII_SUMM);
		}
	}
}
