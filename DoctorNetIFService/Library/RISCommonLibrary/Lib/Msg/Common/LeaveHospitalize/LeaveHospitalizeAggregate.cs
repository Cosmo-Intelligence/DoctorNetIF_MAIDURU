namespace RISCommonLibrary.Lib.Msg.Common.LeaveHospitalize
{
	/// <summary>
	/// 退院情報部
	/// </summary>
	public class LeaveHospitalizeAggregate : AggregateNode
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
		/// 入外区分
		/// </summary>
		public DataNode NYUGAI_KBN
		{
			get;
			set;
		}

		/// <summary>
		/// 退院日
		/// </summary>
		public DataNode OUT_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 退院理由コード
		/// </summary>
		public DataNode LVE_REASON_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 退院病棟コード
		/// </summary>
		public DataNode BYOTO_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 退院病室コード
		/// </summary>
		public DataNode ROOM_CD
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

		#endregion

		#region constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public LeaveHospitalizeAggregate()
			: base(LeaveHospitalizeNodeInfo.H2RLH_ROOT)
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

			PT_ID = AddChildNode(new DataNode(LeaveHospitalizeNodeInfo.H2RLH_PT_ID));
			NYUGAI_KBN = AddChildNode(new DataNode(LeaveHospitalizeNodeInfo.H2RLH_NYUGAI_KBN));
			OUT_DATE = AddChildNode(new DataNode(LeaveHospitalizeNodeInfo.H2RLH_OUT_DATE));
			LVE_REASON_CD = AddChildNode(new DataNode(LeaveHospitalizeNodeInfo.H2RLH_LVE_REASON_CD));
			BYOTO_CD = AddChildNode(new DataNode(LeaveHospitalizeNodeInfo.H2RLH_BYOTO_CD));
			ROOM_CD = AddChildNode(new DataNode(LeaveHospitalizeNodeInfo.H2RLH_ROOM_CD));
			FILLER = AddChildNode(new DataNode(LeaveHospitalizeNodeInfo.H2RLH_FILLER));
		}
		#endregion
	}
}
