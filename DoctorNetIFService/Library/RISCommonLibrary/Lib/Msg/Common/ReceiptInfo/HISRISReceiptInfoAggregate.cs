
namespace RISCommonLibrary.Lib.Msg.Common.ReceiptInfo
{
	public class HISRISReceiptInfoAggregate : AggregateNode
	{
		#region header-property

		/// <summary>
		/// 電文種別
		/// </summary>
		public DataNode DENBUN_SYBT
		{
			get;
			set;
		}

		/// <summary>
		/// 作成日
		/// </summary>
		public DataNode SAKUSEI_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 作成時刻
		/// </summary>
		public DataNode SAKUSEI_TIME
		{
			get;
			set;
		}

		/// <summary>
		/// 送信側システムコード
		/// </summary>
		public DataNode S_SYS_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 受信側システムコード
		/// </summary>
		public DataNode R_SYS_CD
		{
			get;
			set;
		}

		/// <summary>
		/// システム間共通ヘッダ件数
		/// </summary>
		public DataNode HEADER_CNT
		{
			get;
			set;
		}

		/// <summary>
		/// 処理区分
		/// </summary>
		public DataNode SYORI_KBN
		{
			get;
			set;
		}

		/// <summary>
		/// 処理日
		/// </summary>
		public DataNode SYORI_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 処理時刻
		/// </summary>
		public DataNode SYORI_TIME
		{
			get;
			set;
		}

		#endregion

		#region property

		/// <summary>
		///  患者ID 
		/// </summary>
		public DataNode PT_ID
		{
			get;
			set;
		}

		/// <summary>
		///  発生日 
		/// </summary>
		public DataNode HASSEI_DATE
		{
			get;
			set;
		}

		/// <summary>
		///  SEQ番号 
		/// </summary>
		public DataNode SEQ_NO
		{
			get;
			set;
		}

		/// <summary>
		///  WS番号 
		/// </summary>
		public DataNode WS_NO
		{
			get;
			set;
		}

		/// <summary>
		///  INDEX区分 
		/// </summary>
		public DataNode INDEX_KBN
		{
			get;
			set;
		}

		/// <summary>
		///  XX区分 
		/// </summary>
		public DataNode XX_KBN
		{
			get;
			set;
		}

		/// <summary>
		///  XX種別 
		/// </summary>
		public DataNode XX_SYBT
		{
			get;
			set;
		}

		/// <summary>
		///  XX-SEQ 
		/// </summary>
		public DataNode XX_SEQ
		{
			get;
			set;
		}

		/// <summary>
		///  ORDER番号 
		/// </summary>
		public DataNode ORDER_NO
		{
			get;
			set;
		}

		/// <summary>
		///  FILLER 
		/// </summary>
		public DataNode FILLER
		{
			get;
			set;
		}

		/// <summary>
		///  処理種別(検査種別) 
		/// </summary>
		public DataNode PROC_SYBT
		{
			get;
			set;
		}

		/// <summary>
		///  受付ｽﾃｰﾀｽ(部門受付区分)
		/// </summary>
		public DataNode YK_KJ_ST4
		{
			get;
			set;
		}

		/// <summary>
		///  中止理由 
		/// </summary>
		public DataNode CNCL_RSN
		{
			get;
			set;
		}

		/// <summary>
		///  処理日付(作成日付) 
		/// </summary>
		public DataNode YK_CR_DT
		{
			get;
			set;
		}

		/// <summary>
		///  予備 
		/// </summary>
		public DataNode RESERVE
		{
			get;
			set;
		}



		#endregion

		#region constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public HISRISReceiptInfoAggregate()
			: base(HISRISReceiptInfoNodeInfo.H2RRECEIPT_ROOT)
		{
			DENBUN_SYBT = AddChildNode(new DataNode(HeaderNodeInfo.HEADER_DENBUN_SYBT));
			SAKUSEI_DATE = AddChildNode(new DataNode(HeaderNodeInfo.HEADER_SAKUSEI_DATE));
			SAKUSEI_TIME = AddChildNode(new DataNode(HeaderNodeInfo.HEADER_SAKUSEI_TIME));
			S_SYS_CD = AddChildNode(new DataNode(HeaderNodeInfo.HEADER_S_SYS_CD));
			R_SYS_CD = AddChildNode(new DataNode(HeaderNodeInfo.HEADER_R_SYS_CD));
			HEADER_CNT = AddChildNode(new DataNode(HeaderNodeInfo.HEADER_HEADER_CNT));
			SYORI_KBN = AddChildNode(new DataNode(HeaderNodeInfo.HEADER_SYORI_KBN));
			SYORI_DATE = AddChildNode(new DataNode(HeaderNodeInfo.HEADER_SYORI_DATE));
			SYORI_TIME = AddChildNode(new DataNode(HeaderNodeInfo.HEADER_SYORI_TIME));

			PT_ID = AddChildNode(new DataNode(HISRISReceiptInfoNodeInfo.H2RRECEIPT_PT_ID));
			HASSEI_DATE = AddChildNode(new DataNode(HISRISReceiptInfoNodeInfo.H2RRECEIPT_HASSEI_DATE));
			SEQ_NO = AddChildNode(new DataNode(HISRISReceiptInfoNodeInfo.H2RRECEIPT_SEQ_NO));
			WS_NO = AddChildNode(new DataNode(HISRISReceiptInfoNodeInfo.H2RRECEIPT_WS_NO));
			INDEX_KBN = AddChildNode(new DataNode(HISRISReceiptInfoNodeInfo.H2RRECEIPT_INDEX_KBN));
			XX_KBN = AddChildNode(new DataNode(HISRISReceiptInfoNodeInfo.H2RRECEIPT_XX_KBN));
			XX_SYBT = AddChildNode(new DataNode(HISRISReceiptInfoNodeInfo.H2RRECEIPT_XX_SYBT));
			XX_SEQ = AddChildNode(new DataNode(HISRISReceiptInfoNodeInfo.H2RRECEIPT_XX_SEQ));
			ORDER_NO = AddChildNode(new DataNode(HISRISReceiptInfoNodeInfo.H2RRECEIPT_ORDER_NO));
			FILLER = AddChildNode(new DataNode(HISRISReceiptInfoNodeInfo.H2RRECEIPT_FILLER));
			PROC_SYBT = AddChildNode(new DataNode(HISRISReceiptInfoNodeInfo.H2RRECEIPT_PROC_SYBT));
			YK_KJ_ST4 = AddChildNode(new DataNode(HISRISReceiptInfoNodeInfo.H2RRECEIPT_YK_KJ_ST4));
			CNCL_RSN = AddChildNode(new DataNode(HISRISReceiptInfoNodeInfo.H2RRECEIPT_CNCL_RSN));
			YK_CR_DT = AddChildNode(new DataNode(HISRISReceiptInfoNodeInfo.H2RRECEIPT_YK_CR_DT));
			RESERVE = AddChildNode(new DataNode(HISRISReceiptInfoNodeInfo.H2RRECEIPT_RESERVE));

		}
		//private void AddEventHandler(object sender, AddEventArgs aea)
		//{
		//	FUNC_SUMM.Data = aea.ChangedData;
		//}
		#endregion

	}
}
