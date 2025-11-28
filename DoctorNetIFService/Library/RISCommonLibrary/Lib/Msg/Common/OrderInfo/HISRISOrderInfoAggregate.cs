using RISCommonLibrary.Lib.Msg.Common.OrderInfo.Detail;
using System.Data;

namespace RISCommonLibrary.Lib.Msg.Common.OrderInfo
{
	public class HISRISOrderInfoAggregate : AggregateNode
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
		public DataNode PT_ID1
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
		/// 入外区分 
		/// </summary>
		public DataNode NYUGAI_KBN
		{
			get;
			set;
		}

		/// <summary>
		/// 診療科コード 
		/// </summary>
		public DataNode KA_CD1
		{
			get;
			set;
		}

		/// <summary>
		/// 診療科名 
		/// </summary>
		public DataNode KA_NAME
		{
			get;
			set;
		}

		/// <summary>
		/// 病棟コード 
		/// </summary>
		public DataNode BYOTO_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 病棟名 
		/// </summary>
		public DataNode BYOTO_NAME
		{
			get;
			set;
		}

		/// <summary>
		/// 医師ID 
		/// </summary>
		public DataNode DR_ID1
		{
			get;
			set;
		}

		/// <summary>
		/// カナ氏名 
		/// </summary>
		public DataNode SH_KANA_NAME
		{
			get;
			set;
		}

		/// <summary>
		/// 職員名 
		/// </summary>
		public DataNode SH_NAME
		{
			get;
			set;
		}

		/// <summary>
		/// 依頼医師連絡先PHS番号 
		/// </summary>
		public DataNode PHS
		{
			get;
			set;
		}

		/// <summary>
		/// 依頼日 
		/// </summary>
		public DataNode IN_DATE1
		{
			get;
			set;
		}

		/// <summary>
		/// 中止日 
		/// </summary>
		public DataNode STOP_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 中止理由フラグ 
		/// </summary>
		public DataNode STOP_RSN_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 患者ID 
		/// </summary>
		public DataNode PT_ID2
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
		/// MR造影剤（Gd系） 
		/// </summary>
		//public DataNode MRI_MED_FLG
		//{
		//	get;
		//	set;
		//}

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
		/// ヨードおよびヨード造影剤アレルギー 
		/// </summary>
		public DataNode CONT_MED_ALGY
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
		/// 心臓ペースメーカー 
		/// </summary>
		public DataNode ETC_FLG1
		{
			get;
			set;
		}

		/// <summary>
		/// 脳動脈瘤クリップ 
		/// </summary>
		public DataNode ETC_FLG2
		{
			get;
			set;
		}

		/// <summary>
		/// 動脈クリップ 
		/// </summary>
		public DataNode ETC_FLG3
		{
			get;
			set;
		}

		/// <summary>
		/// シャントチューブ 
		/// </summary>
		public DataNode ETC_FLG4
		{
			get;
			set;
		}

		/// <summary>
		/// 心電図計、電極 
		/// </summary>
		public DataNode ETC_FLG5
		{
			get;
			set;
		}

		/// <summary>
		/// 心臓人工弁 
		/// </summary>
		public DataNode ETC_FLG6
		{
			get;
			set;
		}

		/// <summary>
		/// 神経刺激器 
		/// </summary>
		public DataNode ETC_FLG7
		{
			get;
			set;
		}

		/// <summary>
		/// 補聴器,埋め込み式 
		/// </summary>
		public DataNode ETC_FLG8
		{
			get;
			set;
		}

		/// <summary>
		/// 人工器官,義眼等 
		/// </summary>
		public DataNode ETC_FLG9
		{
			get;
			set;
		}

		/// <summary>
		/// 眼球内金属粉塵 
		/// </summary>
		public DataNode ETC_FLG10
		{
			get;
			set;
		}

		/// <summary>
		/// 歯列矯正ワイヤ 
		/// </summary>
		public DataNode ETC_FLG11
		{
			get;
			set;
		}

		/// <summary>
		/// 義歯,入れ歯、差し歯 
		/// </summary>
		public DataNode ETC_FLG12
		{
			get;
			set;
		}

		/// <summary>
		/// 消化器手術クリップ 
		/// </summary>
		public DataNode ETC_FLG13
		{
			get;
			set;
		}

		/// <summary>
		/// インスリンポンプ 
		/// </summary>
		public DataNode ETC_FLG14
		{
			get;
			set;
		}

		/// <summary>
		/// 輸液ポンプ、シリンジポンプ 
		/// </summary>
		public DataNode ETC_FLG15
		{
			get;
			set;
		}

		/// <summary>
		/// 人工関節 
		/// </summary>
		public DataNode ETC_FLG16
		{
			get;
			set;
		}

		/// <summary>
		/// (ワイヤ,針金)縫合 
		/// </summary>
		public DataNode ETC_FLG17
		{
			get;
			set;
		}

		/// <summary>
		/// 骨折接合用金属,(ネジ、ピン等) 
		/// </summary>
		public DataNode ETC_FLG18
		{
			get;
			set;
		}

		/// <summary>
		/// 入れ墨 
		/// </summary>
		public DataNode ETC_FLG19
		{
			get;
			set;
		}

		/// <summary>
		/// 流散弾片 
		/// </summary>
		public DataNode ETC_FLG20
		{
			get;
			set;
		}

		/// <summary>
		/// 避妊器具,リング 
		/// </summary>
		public DataNode ETC_FLG21
		{
			get;
			set;
		}

		/// <summary>
		/// ニトロダーム等の貼付剤 
		/// </summary>
		public DataNode ETC_FLG22
		{
			get;
			set;
		}

		/// <summary>
		/// カラーコンタクトレンズ 
		/// </summary>
		public DataNode ETC_FLG23
		{
			get;
			set;
		}

		/// <summary>
		/// アイライナー、マスカラ、その他金属を含む化粧品 
		/// </summary>
		public DataNode ETC_FLG24
		{
			get;
			set;
		}

		/// <summary>
		/// その他身に付けている金属、器具、義肢など 
		/// </summary>
		public DataNode ETC_FLG25
		{
			get;
			set;
		}

		/// <summary>
		/// その他身に付けている金属、器具、義肢など 
		/// </summary>
		public DataNode ETC_FLG26
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
		/// 心疾患 
		/// </summary>
		public DataNode HEART_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 前立腺肥大 
		/// </summary>
		public DataNode BPH_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 糖尿病 
		/// </summary>
		public DataNode DM_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 甲状腺疾患 
		/// </summary>
		public DataNode KOJSEN_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 緑内障 
		/// </summary>
		public DataNode GLAUCOMA_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 妊娠フラグ 
		/// </summary>
		public DataNode PREGNANT_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 肝機能障害 
		/// </summary>
		public DataNode LIVER_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 腎機能障害 
		/// </summary>
		public DataNode RENEAL_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 気管支喘息 
		/// </summary>
		public DataNode ASTHMA_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 肺疾患 
		/// </summary>
		public DataNode LUNG_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 高血圧 
		/// </summary>
		public DataNode HYPER_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 出血傾向 
		/// </summary>
		public DataNode BLEED_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// 抗凝固血小板療法 
		/// </summary>
		public DataNode PLATELET_FLG
		{
			get;
			set;
		}

		/// <summary>
		/// FILLER9 
		/// </summary>
		public DataNode FILLER9
		{
			get;
			set;
		}

		/// <summary>
		/// ( クレアチニン,結果数値) 
		/// </summary>
		public DataNode KEKKA1
		{
			get;
			set;
		}

		/// <summary>
		/// ( クレアチニン,検査日) 
		/// </summary>
		public DataNode KEKKA1_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// ( ヘモグロビン,結果数値) 
		/// </summary>
		public DataNode KEKKA2
		{
			get;
			set;
		}

		/// <summary>
		/// ( ヘモグロビン,検査日) 
		/// </summary>
		public DataNode KEKKA2_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA3
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA3_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA4
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA4_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA5
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA5_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA6
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA6_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA7
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA7_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA8
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA8_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA9
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA9_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA10
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA10_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA11
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA11_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA12
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA12_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA13
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA13_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA14
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA14_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA15
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA15_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA16
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA16_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA17
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA17_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
		/// </summary>
		public DataNode KEKKA18
		{
			get;
			set;
		}

		/// <summary>
		/// 未使用 
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
		/// HBS抗原 
		/// </summary>
		public DataNode HB
		{
			get;
			set;
		}

		/// <summary>
		/// HCV抗体 
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
		/// 緑膿菌 
		/// </summary>
		public DataNode PS
		{
			get;
			set;
		}

		/// <summary>
		/// ATLV抗体 
		/// </summary>
		public DataNode ATLV
		{
			get;
			set;
		}

		/// <summary>
		/// TP抗体 
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
		/// ツ反 
		/// </summary>
		public DataNode LTBI
		{
			get;
			set;
		}

		/// <summary>
		/// 感染症フリー入力項目名称 
		/// </summary>
		public DataNode KN_OTHER_NM
		{
			get;
			set;
		}

		/// <summary>
		/// 感染症フリー入力項目ステータス 
		/// </summary>
		public DataNode KN_OTHER
		{
			get;
			set;
		}

		/// <summary>
		/// 救護区分 
		/// </summary>
		public DataNode KYUGO_KBN
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
		/// C-SCAN番号 
		/// </summary>
		public DataNode CSCAN_NO
		{
			get;
			set;
		}

		/// <summary>
		/// FILLER10 
		/// </summary>
		public DataNode FILLER10
		{
			get;
			set;
		}

		/// <summary>
		/// 処理種別検査種別 
		/// </summary>
		public DataNode KNS_SYBT1
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
		/// 診療科コード 
		/// </summary>
		public DataNode KA_CD2
		{
			get;
			set;
		}

		/// <summary>
		/// 医師ID 
		/// </summary>
		public DataNode DR_ID2
		{
			get;
			set;
		}

		/// <summary>
		/// 医師名 
		/// </summary>
		public DataNode DR_NAME
		{
			get;
			set;
		}

		/// <summary>
		/// オペレータID 
		/// </summary>
		public DataNode OP_ID
		{
			get;
			set;
		}

		/// <summary>
		/// オーダ登録日付(入力日) 
		/// </summary>
		public DataNode IN_DATE2
		{
			get;
			set;
		}

		/// <summary>
		/// オーダ登録時刻(入力時刻) 
		/// </summary>
		public DataNode IN_TIME
		{
			get;
			set;
		}

		/// <summary>
		/// 依頼場所名 
		/// </summary>
		public DataNode IRAI_BASYO
		{
			get;
			set;
		}

		/// <summary>
		/// 検査種別 
		/// </summary>
		public DataNode KNS_SYBT2
		{
			get;
			set;
		}

		/// <summary>
		/// 依頼区分 
		/// </summary>
		public DataNode IRAI_KBN
		{
			get;
			set;
		}

		/// <summary>
		/// フィルム要否 
		/// </summary>
		public DataNode FILM
		{
			get;
			set;
		}

		/// <summary>
		/// フィルム要否 
		/// </summary>
		public DataNode REPORT_KBN
		{
			get;
			set;
		}

		/// <summary>
		/// 依頼病名 
		/// </summary>
		public DataNode IRAI_BYOMEI
		{
			get;
			set;
		}

		/// <summary>
		/// 検査目的 
		/// </summary>
		public DataNode KNS_PURPOSE
		{
			get;
			set;
		}

		/// <summary>
		/// 補足コメント 
		/// </summary>
		public DataNode ODR_COMMENT
		{
			get;
			set;
		}

		/// <summary>
		/// 開始日 
		/// </summary>
		public DataNode START_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 終了日 
		/// </summary>
		public DataNode END_DATE
		{
			get;
			set;
		}

		/// <summary>
		/// 実施時刻 
		/// </summary>
		public DataNode EXEC_TIME
		{
			get;
			set;
		}

		/// <summary>
		/// オーダーモード 
		/// </summary>
		public DataNode ORDER_MODE
		{
			get;
			set;
		}

		/// <summary>
		/// 検査前投薬 
		/// </summary>
		public DataNode PRE_MED
		{
			get;
			set;
		}

		/// <summary>
		/// 出棟先区分 
		/// </summary>
		public DataNode PORTABLE_KBN
		{
			get;
			set;
		}

		/// <summary>
		/// 出棟先コード 
		/// </summary>
		public DataNode PORTABLE_CD
		{
			get;
			set;
		}

		/// <summary>
		/// 同意書フラグ 
		/// </summary>
		public DataNode ORD_FLG1
		{
			get;
			set;
		}


		/// <summary>
		/// 前投与薬個数 
		/// </summary>
		public H2ROrderYKHArray YKH_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 明細行繰返し回数(YKH) 
		/// </summary>
		public DataNode H2RORDER_YKH_SUMM
		{
			get;
			set;
		}


		/// <summary>
		/// 予約数 
		/// </summary>
		public H2ROrderYKArray YK_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 明細行繰返し回数(YK) 
		/// </summary>
		public DataNode H2RORDER_YK_SUMM
		{
			get;
			set;
		}


		/// <summary>
		/// 部位数 
		/// </summary>
		public H2ROrderBUIArray BUI_SUMM
		{
			get;
			set;
		}

		/// <summary>
		/// 明細行繰返し回数(BUI) 
		/// </summary>
		public DataNode H2RORDER_BUI_SUMM
		{
			get;
			set;
		}

		// 2020.07.21 add start cosmo@nishihara EXMAINTABLE取得処理追加
		/// <summary>
		/// EXMAINTABLEのSELECT結果 
		/// </summary>
		public DataRow SELECT_EXMAIN
		{
			get;
			set;
		}
		// 2020.07.21 add end cosmo@nishihara EXMAINTABLE取得処理追加

		#endregion

		#region constructor

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public HISRISOrderInfoAggregate()
			: base(HISRISOrderInfoNodeInfo.H2RORDER_ROOT)
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

			PT_ID1  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PT_ID1));
			HASSEI_DATE = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_HASSEI_DATE));
			SEQ_NO  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_SEQ_NO));
			WS_NO  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_WS_NO));
			INDEX_KBN  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_INDEX_KBN));
			XX_KBN  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_XX_KBN));
			XX_SYBT  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_XX_SYBT));
			XX_SEQ  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_XX_SEQ));
			NYUGAI_KBN  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_NYUGAI_KBN));
			KA_CD1  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KA_CD1));
			KA_NAME  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KA_NAME));
			BYOTO_CD  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BYOTO_CD));
			BYOTO_NAME  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BYOTO_NAME));
			DR_ID1  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_DR_ID1));
			SH_KANA_NAME = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_SH_KANA_NAME));
			SH_NAME  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_SH_NAME));
			PHS  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PHS));
			IN_DATE1  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_IN_DATE1));
			STOP_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_STOP_DATE));
			STOP_RSN_FLG = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_STOP_RSN_FLG));
			PT_ID2  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PT_ID2));
			PT_KN_NAME  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PT_KN_NAME));
			PT_KJ_NAME  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PT_KJ_NAME));
			PT_SEX  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PT_SEX));
			PT_BIRTH  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PT_BIRTH));
			PT_STATUS  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PT_STATUS));
			ROOM_CD  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ROOM_CD));
			ROOM_NAME  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ROOM_NAME));
			PT_ZIP  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PT_ZIP));
			PT_ADDR  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PT_ADDR));
			PT_ADDR_CD  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PT_ADDR_CD));
			PT_TEL  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PT_TEL));
			FILLER1  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_FILLER1));
			FILLER2  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_FILLER2));
			FILLER3  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_FILLER3));
			FILLER4  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_FILLER4));
			BLOOD_ABO  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BLOOD_ABO));
			BLOOD_RH  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BLOOD_RH));
			PT_HEIGHT  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PT_HEIGHT));
			PT_WEIGHT  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PT_WEIGHT));
			PT_WEIGHT_T = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PT_WEIGHT_T));
			FILLER5  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_FILLER5));
			//MRI_MED_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_MRI_MED_FLG));
			CONT_MED_ALGY1  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_CONT_MED_ALGY1));
			ALGY_DRAG_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ALGY_DRAG_FLG));
			ALGY_FLOOD_FLG = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ALGY_FLOOD_FLG));
			KORIN_IJ_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KORIN_IJ_FLG));
			GRUK_IJ_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_GRUK_IJ_FLG));
			ALGY_COMMENT  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ALGY_COMMENT));
			CONT_MED_ALGY  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_CONT_MED_ALGY));
			FILLER6  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_FILLER6));
			LIMBS_SG_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_LIMBS_SG_FLG));
			VISION_SG_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_VISION_SG_FLG));
			AUDITORY_SG_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_AUDITORY_SG_FLG));
			SPEECH_SG_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_SPEECH_SG_FLG));
			MIND_SG_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_MIND_SG_FLG));
			ECXCRETION_SG_FLG = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ECXCRETION_SG_FLG));
			IDO_KBN  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_IDO_KBN));
			FILLER7  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_FILLER7));
			ETC_FLG1  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG1));
			ETC_FLG2  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG2));
			ETC_FLG3  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG3));
			ETC_FLG4  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG4));
			ETC_FLG5  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG5));
			ETC_FLG6  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG6));
			ETC_FLG7  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG7));
			ETC_FLG8  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG8));
			ETC_FLG9  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG9));
			ETC_FLG10  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG10));
			ETC_FLG11  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG11));
			ETC_FLG12  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG12));
			ETC_FLG13  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG13));
			ETC_FLG14  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG14));
			ETC_FLG15  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG15));
			ETC_FLG16  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG16));
			ETC_FLG17  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG17));
			ETC_FLG18  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG18));
			ETC_FLG19  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG19));
			ETC_FLG20  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG20));
			ETC_FLG21  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG21));
			ETC_FLG22  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG22));
			ETC_FLG23  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG23));
			ETC_FLG24  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG24));
			ETC_FLG25  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG25));
			ETC_FLG26  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ETC_FLG26));
			FILLER8  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_FILLER8));
			HEART_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_HEART_FLG));
			BPH_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BPH_FLG));
			DM_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_DM_FLG));
			KOJSEN_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KOJSEN_FLG));
			GLAUCOMA_FLG = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_GLAUCOMA_FLG));
			PREGNANT_FLG = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PREGNANT_FLG));
			LIVER_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_LIVER_FLG));
			RENEAL_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_RENEAL_FLG));
			ASTHMA_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ASTHMA_FLG));
			LUNG_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_LUNG_FLG));
			HYPER_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_HYPER_FLG));
			BLEED_FLG  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_BLEED_FLG));
			PLATELET_FLG = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PLATELET_FLG));
			FILLER9  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_FILLER9));
			KEKKA1  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA1));
			KEKKA1_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA1_DATE));
			KEKKA2  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA2));
			KEKKA2_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA2_DATE));
			KEKKA3  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA3));
			KEKKA3_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA3_DATE));
			KEKKA4  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA4));
			KEKKA4_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA4_DATE));
			KEKKA5  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA5));
			KEKKA5_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA5_DATE));
			KEKKA6  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA6));
			KEKKA6_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA6_DATE));
			KEKKA7  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA7));
			KEKKA7_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA7_DATE));
			KEKKA8  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA8));
			KEKKA8_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA8_DATE));
			KEKKA9  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA9));
			KEKKA9_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA9_DATE));
			KEKKA10  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA10));
			KEKKA10_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA10_DATE));
			KEKKA11  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA11));
			KEKKA11_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA11_DATE));
			KEKKA12  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA12));
			KEKKA12_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA12_DATE));
			KEKKA13  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA13));
			KEKKA13_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA13_DATE));
			KEKKA14  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA14));
			KEKKA14_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA14_DATE));
			KEKKA15  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA15));
			KEKKA15_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA15_DATE));
			KEKKA16  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA16));
			KEKKA16_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA16_DATE));
			KEKKA17  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA17));
			KEKKA17_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA17_DATE));
			KEKKA18  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA18));
			KEKKA18_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KEKKA18_DATE));
			MRSA  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_MRSA));
			HB  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_HB));
			HC  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_HC));
			HIV  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_HIV));
			RPR  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_RPR));
			PS  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PS));
			ATLV  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ATLV));
			TP  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_TP));
			GBS  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_GBS));
			LTBI  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_LTBI));
			KN_OTHER_NM = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KN_OTHER_NM));
			KN_OTHER  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KN_OTHER));
			KYUGO_KBN = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KYUGO_KBN));
			ORDER_NO  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ORDER_NO));
			CSCAN_NO  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_CSCAN_NO));
			FILLER10  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_FILLER10));
			KNS_SYBT1 = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KNS_SYBT1));
			XX_SUM  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_XX_SUM));
			KA_CD2  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KA_CD2));
			DR_ID2  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_DR_ID2));
			DR_NAME  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_DR_NAME));
			OP_ID  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_OP_ID));
			IN_DATE2  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_IN_DATE2));
			IN_TIME  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_IN_TIME));
			IRAI_BASYO = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_IRAI_BASYO));
			KNS_SYBT2  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KNS_SYBT2));
			IRAI_KBN  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_IRAI_KBN));
			FILM  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_FILM));
			REPORT_KBN  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_REPORT_KBN));
			IRAI_BYOMEI  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_IRAI_BYOMEI));
			KNS_PURPOSE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_KNS_PURPOSE));
			ODR_COMMENT  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ODR_COMMENT));
			START_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_START_DATE));
			END_DATE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_END_DATE));
			EXEC_TIME  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_EXEC_TIME));
			ORDER_MODE  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ORDER_MODE));
			PRE_MED  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PRE_MED));
			PORTABLE_KBN = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PORTABLE_KBN));
			PORTABLE_CD  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_PORTABLE_CD));
			ORD_FLG1  = AddChildNode(new DataNode(HISRISOrderInfoNodeInfo.H2RORDER_ORD_FLG1));

			YKH_SUMM  = new H2ROrderYKHArray();
			Add(YKH_SUMM);

			YK_SUMM  = new H2ROrderYKArray();
			Add(YK_SUMM);

			BUI_SUMM  = new H2ROrderBUIArray();
			Add(BUI_SUMM);


		}
		private void AddEventHandler(object sender, AddEventArgs aea)
		{
			YKH_SUMM.Data = aea.ChangedData;
		}
		#endregion

	}
}
