using System;
using System.Configuration;
using RISBizLibrary.Data;
using RISBizLibrary.Download.Data;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.OrderInfo;
using RISCommonLibrary.Lib.Utils;

namespace RISBizLibrary.Updater.Table
{
	public class PATIENTINFOUpdaterOrderInfo : BaseUpdater
	{
		#region const

		/// <summary>
		/// 小数点位置
		/// </summary>
		private const int INDEX_POINT = 3;

		#region InsertSQL

		/// <summary>
		/// InsertSQL
		/// </summary>
		private const string INSERT_SQL =
		"MERGE INTO patientinfo p " +
		"USING " +
		"( " +
			"SELECT " +
				":SECTION_ID               SECTION_ID, " +
				":BYOUTOU_ID               BYOUTOU_ID, " +
				":KANJA_ID                 KANJA_ID, " +
				":KANASIMEI                KANASIMEI, " +
				":ROMASIMEI                ROMASIMEI, " +
				":KANJISIMEI               KANJISIMEI, " +
				":SEX                      SEX, " +
				":BIRTHDAY                 BIRTHDAY, " +
				":JUSYO1                   JUSYO1, " +
				":JUSYO2                   JUSYO2, " +
				":JUSYO3                   JUSYO3, " +
				":KANJA_NYUGAIKBN          KANJA_NYUGAIKBN, " +
				":BYOUSITU_ID              BYOUSITU_ID, " +
				":BLOOD                    BLOOD, " +
				":TALL                     TALL, " +
				":WEIGHT                   WEIGHT, " +
				":ALLERGYMARK              ALLERGYMARK, " +
				":ALLERGY                  ALLERGY, " +
				":HANDICAPPEDMARK          HANDICAPPEDMARK, " +
				":HANDICAPPED              HANDICAPPED, " +
				":TRANSPORTTYPE            TRANSPORTTYPE, " +
				":PREGNANCYMARK            PREGNANCYMARK, " +
				":PREGNANCY                PREGNANCY, " +
				":INFECTIONMARK            INFECTIONMARK, " +
				":INFECTION                INFECTION, " +
				":NOTESMARK                NOTESMARK, " +
				":NOTES                    NOTES, " +
				":CONTRAINDICATIONMARK     CONTRAINDICATIONMARK, " +
				":CONTRAINDICATION         CONTRAINDICATION, " +
				":EXAMDATA                 EXAMDATA, " +
				":CREATININERESULT         CREATININERESULT, " +
				"TO_DATE(:CREATININEUPDATEDATE, 'YYYY/MM/DD')     CREATININEUPDATEDATE, " +
				"SYSDATE           HIS_UPDATEDATE " +
			"FROM " +
				"DUAL " +
		") pn " +
		"ON " +
		"( p.kanja_id = pn.kanja_id) " +
		//"WHEN MATCHED THEN " + //-- 既存レコードの更新
		//	"UPDATE SET " +
		//		"SECTION_ID               = pn.SECTION_ID, " +
		//		"BYOUTOU_ID               = pn.BYOUTOU_ID, " +
		//		"KANASIMEI                = pn.KANASIMEI, " +
		//		"ROMASIMEI                = pn.ROMASIMEI, " +
		//		"KANJISIMEI               = pn.KANJISIMEI, " +
		//		"SEX                      = pn.SEX, " +
		//		"BIRTHDAY                 = pn.BIRTHDAY, " +
		//		"JUSYO1                   = pn.JUSYO1, " +
		//		"JUSYO2                   = pn.JUSYO2, " +
		//		"JUSYO3                   = pn.JUSYO3, " +
		//		"KANJA_NYUGAIKBN          = pn.KANJA_NYUGAIKBN, " +
		//		"BYOUSITU_ID              = pn.BYOUSITU_ID, " +
		//		"BLOOD                    = pn.BLOOD, " +
		//		"TALL                     = pn.TALL, " +
		//		"WEIGHT                   = pn.WEIGHT, " +
		//		"ALLERGYMARK              = pn.ALLERGYMARK, " +
		//		"ALLERGY                  = pn.ALLERGY, " +
		//		"HANDICAPPEDMARK          = pn.HANDICAPPEDMARK, " +
		//		"HANDICAPPED              = pn.HANDICAPPED, " +
		//		"TRANSPORTTYPE            = pn.TRANSPORTTYPE, " +
		//		"PREGNANCYMARK            = pn.PREGNANCYMARK, " +
		//		"PREGNANCY                = pn.PREGNANCY, " +
		//		"INFECTIONMARK            = pn.INFECTIONMARK, " +
		//		"INFECTION                = pn.INFECTION, " +
		//		"NOTESMARK                = pn.NOTESMARK, " +
		//		"NOTES                    = pn.NOTES, " +
		//		"CONTRAINDICATIONMARK     = pn.CONTRAINDICATIONMARK, " +
		//		"CONTRAINDICATION         = pn.CONTRAINDICATION, " +
		//		"EXAMDATA                 = pn.EXAMDATA, " +
		//		"CREATININERESULT         = pn.CREATININERESULT, " +
		//		"CREATININEUPDATEDATE     = pn.CREATININEUPDATEDATE, " +
		//		"HIS_UPDATEDATE           = pn.HIS_UPDATEDATE " +
		"WHEN NOT MATCHED THEN " + //新規レコードの作成
			"INSERT " +
			"( " +
				"KANJA_ID, " +
				"SECTION_ID, " +
				"BYOUTOU_ID, " +
				"KANASIMEI, " +
				"ROMASIMEI, " +
				"KANJISIMEI, " +
				"SEX, " +
				"BIRTHDAY, " +
				"JUSYO1, " +
				"JUSYO2, " +
				"JUSYO3, " +
				"KANJA_NYUGAIKBN, " +
				"BYOUSITU_ID, " +
				"BLOOD, " +
				"TALL, " +
				"WEIGHT, " +
				"ALLERGYMARK, " +
				"ALLERGY, " +
				"HANDICAPPEDMARK, " +
				"HANDICAPPED, " +
				"TRANSPORTTYPE, " +
				"PREGNANCYMARK, " +
				"PREGNANCY, " +
				"INFECTIONMARK, " +
				"INFECTION, " +
				"NOTESMARK, " +
				"NOTES, " +
				"CONTRAINDICATIONMARK, " +
				"CONTRAINDICATION, " +
				"EXAMDATA, " +
				"CREATININERESULT, " +
				"CREATININEUPDATEDATE, " +
				"HIS_UPDATEDATE " +
			") " +
			"VALUES " +
			"( " +
				"pn.KANJA_ID, " +
				"pn.SECTION_ID, " +
				"pn.BYOUTOU_ID, " +
				"pn.KANASIMEI, " +
				"pn.ROMASIMEI, " +
				"pn.KANJISIMEI, " +
				"pn.SEX, " +
				"pn.BIRTHDAY, " +
				"pn.JUSYO1, " +
				"pn.JUSYO2, " +
				"pn.JUSYO3, " +
				"pn.KANJA_NYUGAIKBN, " +
				"pn.BYOUSITU_ID, " +
				"pn.BLOOD, " +
				"pn.TALL, " +
				"pn.WEIGHT, " +
				"pn.ALLERGYMARK, " +
				"pn.ALLERGY, " +
				"pn.HANDICAPPEDMARK, " +
				"pn.HANDICAPPED, " +
				"pn.TRANSPORTTYPE, " +
				"pn.PREGNANCYMARK, " +
				"pn.PREGNANCY, " +
				"pn.INFECTIONMARK, " +
				"pn.INFECTION, " +
				"pn.NOTESMARK, " +
				"pn.NOTES, " +
				"pn.CONTRAINDICATIONMARK, " +
				"pn.CONTRAINDICATION, " +
				"pn.EXAMDATA, " +
				"pn.CREATININERESULT, " +
				"pn.CREATININEUPDATEDATE, " +
				"pn.HIS_UPDATEDATE" +
			") " +
			"";

		#endregion

		#endregion

		#region param

		/// <summary>
		/// SECTION_ID
		/// </summary>
		private const string PARAM_NAME_SECTION_ID = "SECTION_ID";

		/// <summary>
		/// BYOUTOU_ID
		/// </summary>
		private const string PARAM_NAME_BYOUTOU_ID = "BYOUTOU_ID";

		/// <summary>
		/// KANJA_ID
		/// </summary>
		private const string PARAM_NAME_KANJA_ID = "KANJA_ID";

		/// <summary>
		/// KANASIMEI
		/// </summary>
		private const string PARAM_NAME_KANASIMEI = "KANASIMEI";

		/// <summary>
		/// KANJISIMEI
		/// </summary>
		private const string PARAM_NAME_KANJISIMEI = "KANJISIMEI";

		/// <summary>
		/// KANJISIMEI
		/// </summary>
		private const string PARAM_NAME_ROMASIMEI = "ROMASIMEI";

		/// <summary>
		/// SEX
		/// </summary>
		private const string PARAM_NAME_SEX = "SEX";

		/// <summary>
		/// BIRTHDAY
		/// </summary>
		private const string PARAM_NAME_BIRTHDAY = "BIRTHDAY";

		/// <summary>
		/// JUSYO1
		/// </summary>
		private const string PARAM_NAME_JUSYO1 = "JUSYO1";

		/// <summary>
		/// JUSYO2
		/// </summary>
		private const string PARAM_NAME_JUSYO2 = "JUSYO2";

		/// <summary>
		/// JUSYO3
		/// </summary>
		private const string PARAM_NAME_JUSYO3 = "JUSYO3";

		/// <summary>
		/// KANJA_NYUGAIKBN
		/// </summary>
		private const string PARAM_NAME_KANJA_NYUGAIKBN = "KANJA_NYUGAIKBN";

		/// <summary>
		/// BYOUSITU_ID
		/// </summary>
		private const string PARAM_NAME_BYOUSITU_ID = "BYOUSITU_ID";

		/// <summary>
		/// BLOOD
		/// </summary>
		private const string PARAM_NAME_BLOOD = "BLOOD";

		/// <summary>
		/// TALL
		/// </summary>
		private const string PARAM_NAME_TALL = "TALL";

		/// <summary>
		/// WEIGHT
		/// </summary>
		private const string PARAM_NAME_WEIGHT = "WEIGHT";

		/// <summary>
		/// ALLERGYMARK
		/// </summary>
		private const string PARAM_NAME_ALLERGYMARK = "ALLERGYMARK";

		/// <summary>
		/// ALLERGY
		/// </summary>
		private const string PARAM_NAME_ALLERGY = "ALLERGY";

		/// <summary>
		/// HANDICAPPEDMARK
		/// </summary>
		private const string PARAM_NAME_HANDICAPPEDMARK = "HANDICAPPEDMARK";

		/// <summary>
		/// HANDICAPPED
		/// </summary>
		private const string PARAM_NAME_HANDICAPPED = "HANDICAPPED";

		/// <summary>
		/// TRANSPORTTYPE
		/// </summary>
		private const string PARAM_NAME_TRANSPORTTYPE = "TRANSPORTTYPE";

		/// <summary>
		/// PREGNANCYMARK
		/// </summary>
		private const string PARAM_NAME_PREGNANCYMARK = "PREGNANCYMARK";

		/// <summary>
		/// PREGNANCY
		/// </summary>
		private const string PARAM_NAME_PREGNANCY = "PREGNANCY";

		/// <summary>
		/// INFECTIONMARK
		/// </summary>
		private const string PARAM_NAME_INFECTIONMARK = "INFECTIONMARK";

		/// <summary>
		/// INFECTION
		/// </summary>
		private const string PARAM_NAME_INFECTION = "INFECTION";

		/// <summary>
		/// NOTESMARK
		/// </summary>
		private const string PARAM_NAME_NOTESMARK = "NOTESMARK";

		/// <summary>
		/// NOTES
		/// </summary>
		private const string PARAM_NAME_NOTES = "NOTES";

		/// <summary>
		/// CONTRAINDICATIONMARK
		/// </summary>
		private const string PARAM_NAME_CONTRAINDICATIONMARK = "CONTRAINDICATIONMARK";

		/// <summary>
		/// CONTRAINDICATION
		/// </summary>
		private const string PARAM_NAME_CONTRAINDICATION = "CONTRAINDICATION";

		/// <summary>
		/// EXAMDATA
		/// </summary>
		private const string PARAM_NAME_EXAMDATA = "EXAMDATA";

		/// <summary>
		/// HIS_UPDATEDATE
		/// </summary>
		private const string PARAM_NAME_HIS_UPDATEDATE = "HIS_UPDATEDATE";

		#endregion

		/// <summary>
		/// SYSDATE
		/// </summary>
		private const string PARAM_NAME_SYSDATE = "SYSDATE";

		/// <summary>
		/// MAX_WEIGHT
		/// </summary>
		private const double MAX_WEIGHT = 9999.99;

		/// <summary>
		/// WEIGHT_T_KG
		/// </summary>
		private const string WEIGHT_T_KG = "1";

		/// <summary>
		/// WEIGHT_T_G
		/// </summary>
		private const string WEIGHT_T_G = "2";


		/// <summary>
		/// CREATININERESULT
		/// </summary>
		private const string PARAM_NAME_CREATININERESULT = "CREATININERESULT";

		/// <summary>
		/// CREATININEUPDATEDATE
		/// </summary>
		private const string PARAM_NAME_CREATININEUPDATEDATE = "CREATININEUPDATEDATE";
		

		#region field
		#endregion

		public override string TargetSQL
		{
			get
			{
				return INSERT_SQL;
			}
		}

		public override void SetParams(BaseMsgData data, System.Data.IDbCommand command)
		{

			command.Parameters.Clear();
			OrderInfoMsgData orderData = (OrderInfoMsgData)data;
			HISRISOrderInfoAggregate order = orderData.Request.MsgBody.OrderInfo;
			SetDataPatientToSQL(orderData, order, command);
		}

		//------------------------------------------------------------------------------
		//PatientInfo作成用SQL項目設定
		//[引数]
		//  pSQL: TSQLCreator;
		//------------------------------------------------------------------------------
		public void SetDataPatientToSQL(OrderInfoMsgData orderData, HISRISOrderInfoAggregate order, System.Data.IDbCommand command)
		{
			int _AllergyMark;
			string _Allergy = "";
			int _HandicappedMark;
			string _Handicapped;
			string _TransportType;
			int _PregnancyMark;
			string _Pregnancy;
			int _InfectionMark;
			string _Infection;
			int _NotesMark;
			string _Notes = "";
			int _ContraindicationMark;
			string _Contraindication = "";
			string _ExamData;
			// 2020.08.28 Mod H.Taira@COSMO Start
			//string markerCharacter = ConfigurationManager.AppSettings["MARKERCHARACTER"].StringToString();
			string markerCharacter = "\r\n";
			// 2020.08.28 Mod H.Taira@COSMO End

			//ｶﾅ→Roma変換
			KanaRomaConvert kanaRomaConv = new KanaRomaConvert();

			SetStringToCommand(PARAM_NAME_SECTION_ID, order.KA_CD1.TrimData, command);
			SetStringToCommand(PARAM_NAME_BYOUTOU_ID, order.BYOTO_CD.TrimData, command);
			SetStringToCommand(PARAM_NAME_KANJA_ID, order.PT_ID2.TrimData, command);
			SetStringToCommand(PARAM_NAME_KANASIMEI, order.PT_KN_NAME.TrimData, command);
			//患者ローマ字氏名（変換）未設定
			SetStringToCommand(PARAM_NAME_ROMASIMEI, kanaRomaConv.GetRomaConvert(order.PT_KN_NAME.Data), command);
			SetStringToCommand(PARAM_NAME_KANJISIMEI, order.PT_KJ_NAME.TrimData, command);
			SetStringToCommand(PARAM_NAME_SEX, GetSex(order.PT_SEX.TrimData), command);
			SetStringToCommand(PARAM_NAME_BIRTHDAY, order.PT_BIRTH.TrimData, command);
			SetStringToCommand(PARAM_NAME_JUSYO1, order.PT_ZIP.TrimData, command);
			SetStringToCommand(PARAM_NAME_JUSYO2, order.PT_ADDR.TrimData, command);
			SetStringToCommand(PARAM_NAME_JUSYO3, order.PT_TEL.TrimData, command);

			SetStringToCommand(PARAM_NAME_KANJA_NYUGAIKBN, HISPTSTATUS2RISNYUGAIKBN(order.PT_STATUS.TrimData), command);
			SetStringToCommand(PARAM_NAME_BYOUSITU_ID, order.ROOM_CD.TrimData, command);
			SetStringToCommand(PARAM_NAME_BLOOD, order.BLOOD_ABO.TrimData + order.BLOOD_RH.TrimData, command);
			if (order.PT_HEIGHT.TrimData == "")
			{
				SetStringToCommand(PARAM_NAME_TALL, string.Empty, command);
			}
			else
			{
				SetStringToCommand(PARAM_NAME_TALL, float.Parse(order.PT_HEIGHT.TrimData.ToString()).ToString(), command);
			}

			if (order.PT_WEIGHT.TrimData == "")
			{
				SetStringToCommand(PARAM_NAME_WEIGHT, string.Empty, command);
			}
			else
			{
				SetStringToCommand(PARAM_NAME_WEIGHT, GetPatientWeight(order.PT_WEIGHT.TrimData,
															order.PT_WEIGHT_T.TrimData), command);
			}

			// アレルギー情報識別子
			//DataNode[] array = {
			//					order.MRI_MED_FLG,
			//					order.ALGY_DRAG_FLG,
			//					order.ALGY_FLOOD_FLG
			//				};
			DataNode[] array = {
								order.CONT_MED_ALGY1,
								order.ALGY_DRAG_FLG,
								order.ALGY_FLOOD_FLG
							};
			if (StringUtils.GetFlag(PARAM_NAME_ALLERGYMARK, array))
			{
				_AllergyMark  = 1;
			}
			else
			{
				_AllergyMark = 0;
			}

			SetStringToCommand(PARAM_NAME_ALLERGYMARK, _AllergyMark.ToString(), command);

			// アレルギー情報
			//_Allergy = StringUtils.GetNameValueStr(PARAM_NAME_ALLERGY,
			//					new DataNode[] {
			//						order.MRI_MED_FLG,
			//						order.ALGY_DRAG_FLG,
			//						order.ALGY_FLOOD_FLG
			//					},
			//					markerCharacter
			//					);
			_Allergy = StringUtils.GetNameValueStr(PARAM_NAME_ALLERGY,
					new DataNode[] {
						order.CONT_MED_ALGY1,
						order.ALGY_DRAG_FLG,
						order.ALGY_FLOOD_FLG
					},
					markerCharacter
					);

			if (order.ALGY_COMMENT.TrimData != "")
			{
				if (_AllergyMark == 1)
				{
					// 2020.08.28 Mod H.Taira@COSMO Start
					//_Allergy  = _Allergy + "|";
					_Allergy  = _Allergy + "\r\n";
					// 2020.08.28 Mod H.Taira@COSMO End
				}
				_Allergy  = _Allergy + "【造影剤コメント】";
				_Allergy  = _Allergy + order.ALGY_COMMENT.TrimData;
			}

			SetStringToCommand(PARAM_NAME_ALLERGY, _Allergy, command);
			/*DONE:デリミタ取得方法考慮*/

			// 障害情報識別子
			DataNode[] array2 = {
								order.LIMBS_SG_FLG,
								order.VISION_SG_FLG,
								order.AUDITORY_SG_FLG,
								order.SPEECH_SG_FLG,
								order.ECXCRETION_SG_FLG
							};

			if (StringUtils.GetFlag("HANDICAPPEDMARK",array2))
			{
				_HandicappedMark  = 1;
			}
			else
			{
				_HandicappedMark = 0;
			}

			SetStringToCommand(PARAM_NAME_HANDICAPPEDMARK, _HandicappedMark.ToString(), command);

			// 障害情報
			_Handicapped = StringUtils.GetNameValueStr(PARAM_NAME_HANDICAPPED,
								new DataNode[] {
									order.LIMBS_SG_FLG,
									order.VISION_SG_FLG,
									order.AUDITORY_SG_FLG,
									order.SPEECH_SG_FLG,
									order.ECXCRETION_SG_FLG
								},
								markerCharacter
								);

			SetStringToCommand(PARAM_NAME_HANDICAPPED, _Handicapped, command);
			/*DONE:デリミタ取得方法考慮*/

			// 患者移動情報
			_TransportType  = ConfigurationManager.AppSettings[PARAM_NAME_TRANSPORTTYPE + "_" + order.IDO_KBN.TrimData].StringToString();
			SetStringToCommand(PARAM_NAME_TRANSPORTTYPE, _TransportType, command);

			// 妊娠識別子
			int def;
			if (int.TryParse(ConfigurationManager.AppSettings[PARAM_NAME_PREGNANCYMARK + "_" + order.PREGNANT_FLG.TrimData].StringToString(), out def))
			{
				_PregnancyMark = def;
			}
			else
			{
				_PregnancyMark = 0;
			}

			SetStringToCommand(PARAM_NAME_PREGNANCYMARK, _PregnancyMark.ToString(), command);

			// 妊娠情報
			_Pregnancy  = ConfigurationManager.AppSettings[PARAM_NAME_PREGNANCY + "_" + order.PREGNANT_FLG.TrimData].StringToString();
			SetStringToCommand(PARAM_NAME_PREGNANCY, _Pregnancy, command);

			// 感染情報識別子
			DataNode[] array3 = { order.MRSA,
								order.HB,
								order.HC,
								order.HIV,
								order.RPR,
								order.PS,
								order.ATLV,
								order.TP,
								order.GBS,
								order.LTBI,
								order.KN_OTHER};
			if (StringUtils.GetFlag("INFECTIONMARK",array3))
			{
				_InfectionMark  = 1;
			}
			else
			{
				_InfectionMark = 0;
			}

			SetStringToCommand(PARAM_NAME_INFECTIONMARK, _InfectionMark.ToString(), command);

			// 感染情報
			_Infection = StringUtils.GetNameValueStr(PARAM_NAME_INFECTION,
								new DataNode[] {
									order.MRSA,
									order.HB,
									order.HC,
									order.HIV,
									order.RPR,
									order.PS,
									order.ATLV,
									order.TP,
									order.GBS,
									order.LTBI
								},
								markerCharacter
								);

			if (StringUtils.GetFlag(PARAM_NAME_INFECTIONMARK,
					new DataNode[] {
							order.KN_OTHER
					}
					))
			{
				// 2020.08.28 Mod H.Taira@COSMO Start
				//_Infection = _Infection + "|" + "【" + order.KN_OTHER_NM.TrimData + "】★あり";
				_Infection = _Infection + "\r\n" + "【" + order.KN_OTHER_NM.TrimData + "】★あり";
				// 2020.08.28 Mod H.Taira@COSMO End
			}

			SetStringToCommand(PARAM_NAME_INFECTION, _Infection, command);

			// その他注意事項識別子
			DataNode[] array4 = { order.ETC_FLG1,
								order.ETC_FLG2,
								order.ETC_FLG3,
								order.ETC_FLG4,
								order.ETC_FLG5,
								order.ETC_FLG6,
								order.ETC_FLG7,
								order.ETC_FLG8,
								order.ETC_FLG9,
								order.ETC_FLG10,
								order.ETC_FLG11,
								order.ETC_FLG12,
								order.ETC_FLG13,
								order.ETC_FLG14,
								order.ETC_FLG15,
								order.ETC_FLG16,
								order.ETC_FLG17,
								order.ETC_FLG18,
								order.ETC_FLG19,
								order.ETC_FLG20,
								order.ETC_FLG21,
								order.ETC_FLG22,
								order.ETC_FLG23,
								order.ETC_FLG24,
								order.ETC_FLG25
								};
			if (StringUtils.GetFlag("NOTESMARK", array4))
			{
				_NotesMark  = 1;
			}
			else
			{
				_NotesMark = 0;
			}

			SetStringToCommand(PARAM_NAME_NOTESMARK, _NotesMark.ToString(), command);

			// その他注意事項
			_Notes = StringUtils.GetNameValueStr(PARAM_NAME_NOTES,
								new DataNode[] {
									order.ETC_FLG1,
									order.ETC_FLG1,
									order.ETC_FLG2,
									order.ETC_FLG3,
									order.ETC_FLG4,
									order.ETC_FLG5,
									order.ETC_FLG6,
									order.ETC_FLG7,
									order.ETC_FLG8,
									order.ETC_FLG9,
									order.ETC_FLG10,
									order.ETC_FLG11,
									order.ETC_FLG12,
									order.ETC_FLG13,
									order.ETC_FLG14,
									order.ETC_FLG15,
									order.ETC_FLG16,
									order.ETC_FLG17,
									order.ETC_FLG18,
									order.ETC_FLG19,
									order.ETC_FLG20,
									order.ETC_FLG21,
									order.ETC_FLG22,
									order.ETC_FLG23,
									order.ETC_FLG24,
									order.ETC_FLG25
								},
								markerCharacter
								);


			/*DONE:デリミタ取得方法考慮*/
			if (order.ETC_FLG26.TrimData != "")
			{
				if (_NotesMark == 0)
				{
					_Notes  = _Notes + "(フリーコメント)";
				}
				else
				{
					// 2020.08.28 Mod H.Taira@COSMO Start
					//_Notes = _Notes + "|" + "(フリーコメント)";
					_Notes = _Notes + "\r\n" + "(フリーコメント)";
					// 2020.08.28 Mod H.Taira@COSMO End
				}
				_Notes  = _Notes + order.ETC_FLG26.TrimData;

			}

			//2014.8.5 cosmo add ---------------------------------------------------- start
			if (order.FILLER8.TrimData == "0")
			{
				if (_Notes!= "")
				{
					// 2020.08.28 Mod H.Taira@COSMO Start
					//_Notes  = _Notes + "|";
					_Notes  = _Notes + "\r\n";
					// 2020.08.28 Mod H.Taira@COSMO End
				}
				_Notes  = _Notes + "MRI検査不可";
			}
			else if (order.FILLER8.TrimData == "1")
			{
				if (_Notes != "")
				{
					// 2020.08.28 Mod H.Taira@COSMO Start
					//_Notes  = _Notes + "|";
					_Notes  = _Notes + "\r\n";
					// 2020.08.28 Mod H.Taira@COSMO End
				}
				_Notes = _Notes + "MRI検査可";
				
			}

			SetStringToCommand(PARAM_NAME_NOTES, _Notes, command);

			/*DONE:デリミタ取得方法考慮*/
			DataNode[] array5 = {  order.HEART_FLG,
								order.BPH_FLG,
								order.KOJSEN_FLG,
								order.GLAUCOMA_FLG,
								order.RENEAL_FLG,
								order.ASTHMA_FLG,
								order.BLEED_FLG
							};

			// 禁忌情報識別子
			if (StringUtils.GetFlag("CONTRAINDICATIONMARK", array5))
			{
				_ContraindicationMark  = 1;
			}
			else
			{
				_ContraindicationMark = 0;
			}

			SetStringToCommand(PARAM_NAME_CONTRAINDICATIONMARK, _ContraindicationMark.ToString(), command);

			// 禁忌情報
			_Contraindication = StringUtils.GetNameValueStr(PARAM_NAME_CONTRAINDICATION,
								new DataNode[] {
									order.HEART_FLG,
									order.BPH_FLG,
									order.KOJSEN_FLG,
									order.GLAUCOMA_FLG,
									order.RENEAL_FLG,
									order.ASTHMA_FLG,
									order.BLEED_FLG
								},
								markerCharacter
								);

			/*DONE:デリミタ取得方法考慮*/
			SetStringToCommand(PARAM_NAME_CONTRAINDICATION, _Contraindication, command);

			// 検査データ情報
			_ExamData  = "";
			if (order.KEKKA1.TrimData != "") //クレアチニン
			{
				_ExamData  = _ExamData + ConfigurationManager.AppSettings[PARAM_NAME_EXAMDATA + "_" + order.KEKKA1.TrimData].StringToString();
				_ExamData  = _ExamData + " ";
				_ExamData  = _ExamData + order.KEKKA1.TrimData + "mg/dl";
				_ExamData  = _ExamData + " ";
				_ExamData  = _ExamData + order.KEKKA1_DATE.TrimData;
			}

			SetStringToCommand(PARAM_NAME_EXAMDATA, _ExamData, command);

			//2014.8.13 cosmo add -------------------------------------------------- start
			//クレアチニン値
			if (order.KEKKA1.TrimData != "") //クレアチニン
			{
				SetStringToCommand(PARAM_NAME_CREATININERESULT, order.KEKKA1.TrimData, command);
			}
			else
			{
				SetStringToCommand(PARAM_NAME_CREATININERESULT, string.Empty, command);
			}
			//クレアチニン検査日
			if (order.KEKKA1_DATE.TrimData != "") //クレアチニン
			{
				//SetStringToCommand(PARAM_NAME_CREATININEUPDATEDATE, "TO_DATE(" + order.KEKKA1_DATE.TrimData + ")");
				//SetDateTimeToCommand(PARAM_NAME_CREATININEUPDATEDATE, order.KEKKA1_DATE.TrimData, command);
				SetStringToCommand(PARAM_NAME_CREATININEUPDATEDATE, order.KEKKA1_DATE.TrimData, command);
			}
			else
			{
				SetStringToCommand(PARAM_NAME_CREATININEUPDATEDATE, string.Empty, command);
			}

			//2014.8.13 cosmo add -------------------------------------------------- end

			//SetStringToCommand(PARAM_NAME_HIS_UPDATEDATE, "SYSDATE", command);
		}

		//------------------------------------------------------------------------------
		//GetSex
		//------------------------------------------------------------------------------
		public string GetSex(string pSex)
		{
			string Result;
			if (pSex == "M")
			{
				Result = RQRISDBConst.PATIENTINFO_SEX_MALE;
			}
			else if (pSex == "F")
			{
				Result = RQRISDBConst.PATIENTINFO_SEX_FEMALE;
			}
			else
			{
				Result = RQRISDBConst.PATIENTINFO_SEX_OTHER;
			}
			return Result;
		}

		public string HISPTSTATUS2RISNYUGAIKBN(string pPTSTATUS)
		{
			string INOUT_HOSPITALIZATION = "2";  //入院
			string INOUT_OUTPATIENT = "1";  //外来
			string Result;
			if (pPTSTATUS == "1") // HISの入院=1
			{
				Result = INOUT_HOSPITALIZATION;
			}
			else
			{
				Result =  INOUT_OUTPATIENT;
			}
			return Result;
		}


		//------------------------------------------------------------------------------
		//GetPatientWeight（体重取得）
		//------------------------------------------------------------------------------
		public string GetPatientWeight(string pWeight, string pUnit)
		{
			string Result;
			double MAX_WEIGHT = 9999.99;
			string WEIGHT_T_KG = "1";
			string WEIGHT_T_G = "2";
			double _FloatWeight;

			try
			{
				if (pUnit == WEIGHT_T_KG)
				{
					_FloatWeight = float.Parse(pWeight);
				}
				else if (pUnit == WEIGHT_T_G)
				{
					_FloatWeight = float.Parse(pWeight) / 1000;
				}
				else
				{
					//raise Exception.Create("単位が不正です");
					_FloatWeight = float.Parse(pWeight);
				}

				if (_FloatWeight < MAX_WEIGHT)
				{
					Result = _FloatWeight.ToString();
				}
				else
				{
					Result = MAX_WEIGHT.ToString();
				}
			}
			catch (Exception)
			{
				Result = "0";
				return Result;
			}
			return Result;
			
		}
	}
}
