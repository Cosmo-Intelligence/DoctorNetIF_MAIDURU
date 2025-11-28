using RISCommonLibrary.Lib.Msg.Common.ExamInfo.Detail;

namespace RISCommonLibrary.Lib.Msg.Common.ExamInfo
{
	public class HISRISExamInfoAggregate : AggregateNode
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
		/// 患者ID
		/// </summary>
		public DataNode PT_ID
		{
			get;
			set;
		}

		/// <summary>
		/// 発生日
		/// </summary>
		public DataNode HASSEI_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// SEQ番号
		/// </summary>
		public DataNode SEQ_NO
		{
			get;
			set;
		}

		/// <summary>
		/// WS番号
		/// </summary>
		public DataNode WS_NO
		{
			get;
			set;
		}

		/// <summary>
		/// INDEX区分
		/// </summary>
		public DataNode INDEX_KBN
		{
			get;
			set;
		}

		/// <summary>
		/// XX区分
		/// </summary>
		public DataNode XX_KBN
		{
			get;
			set;
		}

		/// <summary>
		/// XX種別
		/// </summary>
		public DataNode XX_SYBT
		{
			get;
			set;
		}

		/// <summary>
		/// XX-SEQ
		/// </summary>
		public DataNode XX_SEQ
		{
			get;
			set;
		}

		/// <summary>
		/// オーダ番号
		/// </summary>
		public DataNode ORDER_NO
		{
			get;
			set;
		}

		/// <summary>
		/// 中止区分
		/// </summary>
		public DataNode CANCEL_KBN
		{
			get;
			set;
		}

		/// <summary>
		/// FILLER
		/// </summary>
		public DataNode FILLER
		{
			get;
			set;
		}

		/// <summary>
		/// 処理種別(検査種別)
		/// </summary>
		public DataNode KNS_SYBT
		{
			get;
			set;
		}

		/// <summary>
		/// サブオーダ総数(XX-SUM)
		/// </summary>
		public DataNode XX_SUM
		{
			get;
			set;
		}

		/// <summary>
		/// オーダー番号 
		/// </summary>
		public DataNode ACCESSION_NO
		{
			get;
			set;
		}

		/// <summary>
		/// 事後入力区分
		/// </summary>
		public DataNode JIGO_KBN
		{
			get;
			set;
		}

		/// <summary>
		/// FILLER1
		/// </summary>
		public DataNode FILLER1
		{
			get;
			set;
		}

		/// <summary>
		/// FILLER2
		/// </summary>
		public DataNode FILLER2
		{
			get;
			set;
		}

		/// <summary>
		/// FILLER3
		/// </summary>
		public DataNode FILLER3
		{
			get;
			set;
		}

		/// <summary>
		/// 検査室コード
		/// </summary>
		public DataNode FREE_COMMENT1
		{
			get;
			set;
		}

		/// <summary>
		/// 検査実施日
		/// </summary>
		public DataNode JISSI_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 検査実施時刻
		/// </summary>
		public DataNode JISSI_TIME
		{
			get;
			set;
		}

		/// <summary>
		/// 検査医1
		/// </summary>
		public DataNode KNS_DR1
		{
			get;
			set;
		}

		/// <summary>
		/// 検査医2
		/// </summary>
		public DataNode KNS_DR2
		{
			get;
			set;
		}

		/// <summary>
		/// 検査医3
		/// </summary>
		public DataNode KNS_DR3
		{
			get;
			set;
		}

		/// <summary>
		/// 検査技師1
		/// </summary>
		public DataNode KNS_GISI1
		{
			get;
			set;
		}

		/// <summary>
		/// 検査技師2
		/// </summary>
		public DataNode KNS_GISI2
		{
			get;
			set;
		}

		/// <summary>
		/// 検査技師3
		/// </summary>
		public DataNode KNS_GISI3
		{
			get;
			set;
		}

		/// <summary>
		/// 撮影室ｺｰﾄﾞ
		/// </summary>
		public DataNode ROOM_CD1
		{
			get;
			set;
		}

		/// <summary>
		/// 機能検査数
		/// </summary>
		public H2RExamFUNCArray FUNC_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 明細行繰返し回数(FUNC)
		/// </summary>
		public DataNode H2REXAM_FUNC_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// RIS→HISコメント
		/// </summary>
		public DataNode JISSI_COMMENT
		{
			get;
			set;
		}


		/// <summary>
		/// 部位数
		/// </summary>
		public H2RExamBUIArray BUI_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 明細行繰返し回数(BUI)
		/// </summary>
		public DataNode H2REXAM_BUI_SUMM
		{
			get;
			set;
		}
		/// <summary>
		/// 使用薬剤数
		/// </summary>
		public H2RExamDRUGArray DRUG_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 明細行繰返し回数(DRUG)
		/// </summary>
		public DataNode H2REXAM_DRUG_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 使用器材数
		/// </summary>
		public H2RExamKZIArray KZI_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 明細行繰返し回数(KZI)
		/// </summary>
		public DataNode H2REXAM_KZI_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 使用放射線医薬品数
		/// </summary>
		public H2RExamISOArray ISO_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 明細行繰返し回数(ISO)
		/// </summary>
		public DataNode H2REXAM_ISO_SUMM
		{
			get;
			set;
		}
		
		#endregion

		#region constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public HISRISExamInfoAggregate()
			: base(HISRISExamInfoNodeInfo.H2REXAM_ROOT)
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

			PT_ID = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_PT_ID));
			HASSEI_DATE = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_HASSEI_DATE));
			SEQ_NO = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_SEQ_NO));
			WS_NO = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_WS_NO));
			INDEX_KBN = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_INDEX_KBN));
			XX_KBN = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_XX_KBN));
			XX_SYBT = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_XX_SYBT));
			XX_SEQ = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_XX_SEQ));
			ORDER_NO = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_ORDER_NO));
			CANCEL_KBN = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_CANCEL_KBN));
			FILLER = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_FILLER));
			KNS_SYBT = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_KNS_SYBT));
			XX_SUM = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_XX_SUM));
			ACCESSION_NO = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_ACCESSION_NO));
			JIGO_KBN = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_JIGO_KBN));
			FILLER1 = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_FILLER1));
			FILLER2 = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_FILLER2));
			FILLER3 = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_FILLER3));
			FREE_COMMENT1 = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_FREE_COMMENT1));
			JISSI_DATE = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_JISSI_DATE));
			JISSI_TIME = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_JISSI_TIME));
			KNS_DR1 = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_KNS_DR1));
			KNS_DR2 = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_KNS_DR2));
			KNS_DR3 = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_KNS_DR3));
			KNS_GISI1 = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_KNS_GISI1));
			KNS_GISI2 = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_KNS_GISI2));
			KNS_GISI3 = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_KNS_GISI3));
			ROOM_CD1 = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_ROOM_CD1));

			FUNC_SUMM = new H2RExamFUNCArray();
			Add(FUNC_SUMM);

			JISSI_COMMENT = AddChildNode(new DataNode(HISRISExamInfoNodeInfo.H2REXAM_JISSI_COMMENT));

			BUI_SUMM = new H2RExamBUIArray();
			Add(BUI_SUMM);

			DRUG_SUMM = new H2RExamDRUGArray();
			Add(DRUG_SUMM);

			KZI_SUMM = new H2RExamKZIArray();
			Add(KZI_SUMM);

			ISO_SUMM = new H2RExamISOArray();
			Add(ISO_SUMM);

		}
		private void AddEventHandler(object sender, AddEventArgs aea)
		{
			FUNC_SUMM.Data = aea.ChangedData;
		}
		#endregion

	}
}
