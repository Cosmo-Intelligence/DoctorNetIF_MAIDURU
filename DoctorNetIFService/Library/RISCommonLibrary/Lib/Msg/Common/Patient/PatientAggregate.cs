namespace RISCommonLibrary.Lib.Msg.Common.Patient
{
	/// <summary>
	/// 患者情報
	/// </summary>
	public class PatientAggregate : AggregateNode
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
		/// 患者氏名（カナ）
		/// </summary>
		public DataNode PT_KN_NAME
		{
			get;
			set;
		}

		/// <summary>
		/// 患者氏名（漢字）
		/// </summary>
		public DataNode PT_KJ_NAME
		{
			get;
			set;
		}

		/// <summary>
		/// 性別
		/// </summary>
		public DataNode PT_SEX
		{
			get;
			set;
		}

		/// <summary>
		/// 生年月日
		/// </summary>
		public DataNode PT_BIRTH
		{
			get;
			set;
		}

		/// <summary>
		/// 患者状態
		/// </summary>
		public DataNode PT_STATUS
		{
			get;
			set;
		}

		/// <summary>
		/// 病室コード
		/// </summary>
		public DataNode ROOM_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 病室名称
		/// </summary>
		public DataNode ROOM_NAME
		{
			get;
			set;
		}

		/// <summary>
		/// 郵便番号
		/// </summary>
		public DataNode PT_ZIP
		{
			get;
			set;
		}

		/// <summary>
		/// 住所
		/// </summary>
		public DataNode PT_ADDR
		{
			get;
			set;
		}

		/// <summary>
		/// 住所コード
		/// </summary>
		public DataNode PT_ADDR_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 電話番号
		/// </summary>
		public DataNode PT_TEL
		{
			get;
			set;
		}

		/// <summary>
		/// 患者フラグ1
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
		/// FILLER4
		/// </summary>
		public DataNode FILLER4
		{
			get;
			set;
		}

		/// <summary>
		/// ABO式
		/// </summary>
		public DataNode BLOOD_ABO
		{
			get;
			set;
		}

		/// <summary>
		/// RH式
		/// </summary>
		public DataNode BLOOD_RH
		{
			get;
			set;
		}

		/// <summary>
		/// 身長
		/// </summary>
		public DataNode PT_HEIGHT
		{
			get;
			set;
		}

		/// <summary>
		/// 体重
		/// </summary>
		public DataNode PT_WEIGHT
		{
			get;
			set;
		}

		/// <summary>
		/// 体重単位
		/// </summary>
		public DataNode PT_WEIGHT_T
		{
			get;
			set;
		}

		/// <summary>
		/// FILLER5
		/// </summary>
		public DataNode FILLER5
		{
			get;
			set;
		}

		/// <summary>
		/// 造影剤アレルギー
		/// </summary>
		public DataNode CONT_MED_ALGY1
		{
			get;
			set;
		}

		/// <summary>
		/// 薬物アレルギーフラグ
		/// </summary>
		public DataNode ALGY_DRAG_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 食物アレルギーフラグ
		/// </summary>
		public DataNode ALGY_FLOOD_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 抗コリン剤筋注
		/// </summary>
		public DataNode KORIN_IJ_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// グルカゴン静注
		/// </summary>
		public DataNode GRUK_IJ_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// アレルギーコメント
		/// </summary>
		public DataNode ALGY_COMMENT
		{
			get;
			set;
		}

		/// <summary>
		/// ヨード造影剤アレルギー
		/// </summary>
		public DataNode CONT_MED_ALGY2
		{
			get;
			set;
		}

		/// <summary>
		/// FILLER6
		/// </summary>
		public DataNode FILLER6
		{
			get;
			set;
		}

		/// <summary>
		/// 四肢障害フラグ
		/// </summary>
		public DataNode LIMBS_SG_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 視覚障害フラグ
		/// </summary>
		public DataNode VISION_SG_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 聴覚障害フラグ
		/// </summary>
		public DataNode AUDITORY_SG_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 言語障害フラグ
		/// </summary>
		public DataNode SPEECH_SG_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 精神障害フラグ
		/// </summary>
		public DataNode MIND_SG_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 排泄障害フラグ
		/// </summary>
		public DataNode ECXCRETION_SG_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 移動レベル
		/// </summary>
		public DataNode IDO_KBN
		{
			get;
			set;
		}

		/// <summary>
		/// FILLER7
		/// </summary>
		public DataNode FILLER7
		{
			get;
			set;
		}

		/// <summary>
		/// HEART_FLG
		/// </summary>
		public DataNode HEART_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// BPH_FLG
		/// </summary>
		public DataNode BPH_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// DM_FLG
		/// </summary>
		public DataNode DM_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// KOJSEN_FLG
		/// </summary>
		public DataNode KOJSEN_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// GLAUCOMA_FLG
		/// </summary>
		public DataNode GLAUCOMA_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// PREGNANT_FLG
		/// </summary>
		public DataNode PREGNANT_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// LIVER_FLG
		/// </summary>
		public DataNode LIVER_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// RENEAL_FLG
		/// </summary>
		public DataNode RENEAL_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// ASTHMA_FLG
		/// </summary>
		public DataNode ASTHMA_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// LUNG_FLG
		/// </summary>
		public DataNode LUNG_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// HYPER_FLG
		/// </summary>
		public DataNode HYPER_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// BLEED_FLG
		/// </summary>
		public DataNode BLEED_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// PLATELET_FLG
		/// </summary>
		public DataNode PLATELET_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// FILLER8
		/// </summary>
		public DataNode FILLER8
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA1
		/// </summary>
		public DataNode KEKKA1
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA1_DATE
		/// </summary>
		public DataNode KEKKA1_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA2
		/// </summary>
		public DataNode KEKKA2
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA2_DATE
		/// </summary>
		public DataNode KEKKA2_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA3
		/// </summary>
		public DataNode KEKKA3
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA3_DATE
		/// </summary>
		public DataNode KEKKA3_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA4
		/// </summary>
		public DataNode KEKKA4
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA4_DATE
		/// </summary>
		public DataNode KEKKA4_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA5
		/// </summary>
		public DataNode KEKKA5
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA5_DATE
		/// </summary>
		public DataNode KEKKA5_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA6
		/// </summary>
		public DataNode KEKKA6
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA6_DATE
		/// </summary>
		public DataNode KEKKA6_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA7
		/// </summary>
		public DataNode KEKKA7
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA7_DATE
		/// </summary>
		public DataNode KEKKA7_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA8
		/// </summary>
		public DataNode KEKKA8
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA8_DATE
		/// </summary>
		public DataNode KEKKA8_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA9
		/// </summary>
		public DataNode KEKKA9
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA9_DATE
		/// </summary>
		public DataNode KEKKA9_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA10
		/// </summary>
		public DataNode KEKKA10
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA10_DATE
		/// </summary>
		public DataNode KEKKA10_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA11
		/// </summary>
		public DataNode KEKKA11
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA11_DATE
		/// </summary>
		public DataNode KEKKA11_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA12
		/// </summary>
		public DataNode KEKKA12
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA12_DATE
		/// </summary>
		public DataNode KEKKA12_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA13
		/// </summary>
		public DataNode KEKKA13
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA13_DATE
		/// </summary>
		public DataNode KEKKA13_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA14
		/// </summary>
		public DataNode KEKKA14
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA14_DATE
		/// </summary>
		public DataNode KEKKA14_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA15
		/// </summary>
		public DataNode KEKKA15
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA15_DATE
		/// </summary>
		public DataNode KEKKA15_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA16
		/// </summary>
		public DataNode KEKKA16
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA16_DATE
		/// </summary>
		public DataNode KEKKA16_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA17
		/// </summary>
		public DataNode KEKKA17
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA17_DATE
		/// </summary>
		public DataNode KEKKA17_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA18
		/// </summary>
		public DataNode KEKKA18
		{
			get;
			set;
		}

		/// <summary>
		/// KEKKA18_DATE
		/// </summary>
		public DataNode KEKKA18_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// MRSA
		/// </summary>
		public DataNode MRSA
		{
			get;
			set;
		}

		/// <summary>
		/// HB
		/// </summary>
		public DataNode HB
		{
			get;
			set;
		}

		/// <summary>
		/// HC
		/// </summary>
		public DataNode HC
		{
			get;
			set;
		}

		/// <summary>
		/// HIV
		/// </summary>
		public DataNode HIV
		{
			get;
			set;
		}

		/// <summary>
		/// RPR
		/// </summary>
		public DataNode RPR
		{
			get;
			set;
		}

		/// <summary>
		/// PS
		/// </summary>
		public DataNode PS
		{
			get;
			set;
		}

		/// <summary>
		/// ATLV
		/// </summary>
		public DataNode ATLV
		{
			get;
			set;
		}

		/// <summary>
		/// TP
		/// </summary>
		public DataNode TP
		{
			get;
			set;
		}

		/// <summary>
		/// GBS
		/// </summary>
		public DataNode GBS
		{
			get;
			set;
		}

		/// <summary>
		/// LTBI
		/// </summary>
		public DataNode LTBI
		{
			get;
			set;
		}

		/// <summary>
		/// KN_OTHER_NM
		/// </summary>
		public DataNode KN_OTHER_NM
		{
			get;
			set;
		}

		/// <summary>
		/// KN_OTHER
		/// </summary>
		public DataNode KN_OTHER
		{
			get;
			set;
		}
		#endregion

		#region constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public PatientAggregate()
			: base(PatientNodeInfo.H2RPATIENT_ROOT)
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

			// 患者属性
			PT_ID = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_PT_ID));
			PT_KN_NAME = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_PT_KN_NAME));
			PT_KJ_NAME = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_PT_KJ_NAME));
			PT_SEX = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_PT_SEX));
			PT_BIRTH = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_PT_BIRTH));
			PT_STATUS = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_PT_STATUS));
			ROOM_CD = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_ROOM_CD));
			ROOM_NAME = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_ROOM_NAME));
			PT_ZIP = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_PT_ZIP));
			PT_ADDR = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_PT_ADDR));
			PT_ADDR_CD = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_PT_ADDR_CD));
			PT_TEL = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_PT_TEL));
			FILLER1 = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_FILLER1));
			FILLER2 = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_FILLER2));
			FILLER3 = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_FILLER3));
			FILLER4 = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_FILLER4));

			// 患者身体情報
			BLOOD_ABO = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_BLOOD_ABO));
			BLOOD_RH = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_BLOOD_RH));
			PT_HEIGHT = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_PT_HEIGHT));
			PT_WEIGHT = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_PT_WEIGHT));
			PT_WEIGHT_T = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_PT_WEIGHT_T));
			FILLER5 = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_FILLER5));

			// アレルギー情報
			CONT_MED_ALGY1 = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_CONT_MED_ALGY1));
			ALGY_DRAG_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_ALGY_DRAG_FLG));
			ALGY_FLOOD_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_ALGY_FLOOD_FLG));
			KORIN_IJ_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_KORIN_IJ_FLG));
			GRUK_IJ_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_GRUK_IJ_FLG));
			ALGY_COMMENT = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_ALGY_COMMENT));
			CONT_MED_ALGY2 = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_CONT_MED_ALGY2));
			FILLER6 = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_FILLER6));

			// 障害情報
			LIMBS_SG_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_LIMBS_SG_FLG));
			VISION_SG_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_VISION_SG_FLG));
			AUDITORY_SG_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_AUDITORY_SG_FLG));
			SPEECH_SG_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_SPEECH_SG_FLG));
			MIND_SG_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_MIND_SG_FLG));
			ECXCRETION_SG_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_ECXCRETION_SG_FLG));
			IDO_KBN = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_IDO_KBN));
			FILLER7 = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_FILLER7));

			//疾患情報
			HEART_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_HEART_FLG));
			BPH_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_BPH_FLG));
			DM_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_DM_FLG));
			KOJSEN_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_KOJSEN_FLG));
			GLAUCOMA_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_GLAUCOMA_FLG));
			PREGNANT_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_PREGNANT_FLG));
			LIVER_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_LIVER_FLG));
			RENEAL_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_RENEAL_FLG));
			ASTHMA_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_ASTHMA_FLG));
			LUNG_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_LUNG_FLG));
			HYPER_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_HYPER_FLG));
			BLEED_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_BLEED_FLG));
			PLATELET_FLG = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_PLATELET_FLG));
			FILLER8 = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_FILLER8));

			//検査結果情報
			KEKKA1 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA1));
			KEKKA1_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA1_DATE));
			KEKKA2 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA2));
			KEKKA2_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA2_DATE));
			KEKKA3 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA3));
			KEKKA3_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA3_DATE));
			KEKKA4 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA4));
			KEKKA4_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA4_DATE));
			KEKKA5 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA5));
			KEKKA5_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA5_DATE));
			KEKKA6 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA6));
			KEKKA6_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA6_DATE));
			KEKKA7 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA7));
			KEKKA7_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA7_DATE));
			KEKKA8 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA8));
			KEKKA8_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA8_DATE));
			KEKKA9 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA9));
			KEKKA9_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA9_DATE));
			KEKKA10 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA10));
			KEKKA10_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA10_DATE));
			KEKKA11 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA11));
			KEKKA11_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA11_DATE));
			KEKKA12 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA12));
			KEKKA12_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA12_DATE));
			KEKKA13 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA13));
			KEKKA13_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA13_DATE));
			KEKKA14 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA14));
			KEKKA14_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA14_DATE));
			KEKKA15 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA15));
			KEKKA15_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA15_DATE));
			KEKKA16 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA16));
			KEKKA16_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA16_DATE));
			KEKKA17 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA17));
			KEKKA17_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA17_DATE));
			KEKKA18 = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA18));
			KEKKA18_DATE = AddChildNode(new DataNode(PatientNodeInfo.H2RORDER_KEKKA18_DATE));

			//感染症情報
			MRSA = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_MRSA));
			HB = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_HB));
			HC = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_HC));
			HIV = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_HIV));
			RPR = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_RPR));
			PS = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_PS));
			ATLV = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_ATLV));
			TP = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_TP));
			GBS = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_GBS));
			LTBI = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_LTBI));
			KN_OTHER_NM = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_KN_OTHER_NM));
			KN_OTHER = AddChildNode(new DataNode(PatientNodeInfo.H2RPATIENT_KN_OTHER));

		}
		#endregion
	}
}
