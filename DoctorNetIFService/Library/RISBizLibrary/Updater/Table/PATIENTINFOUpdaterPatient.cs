using System;
using System.Configuration;
using RISBizLibrary.Data;
using RISBizLibrary.Download.Data;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.Patient;
using RISCommonLibrary.Lib.Utils;

namespace RISBizLibrary.Updater.Table
{
	public class PATIENTINFOUpdaterPatient : BaseUpdater
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
				":KANJA_ID KANJA_ID, " +
				":KANASIMEI KANASIMEI, " +
				":ROMASIMEI ROMASIMEI, " +
				":KANJISIMEI KANJISIMEI, " +
				":SEX SEX, " +
				":BIRTHDAY BIRTHDAY, " +
				":JUSYO1 JUSYO1, " +
				":JUSYO2 JUSYO2, " +
				":JUSYO3 JUSYO3, " +
				":KANJA_NYUGAIKBN KANJA_NYUGAIKBN, " +
				":BYOUSITU_ID BYOUSITU_ID, " +
				":BLOOD BLOOD, " +
				":TALL TALL, " +
				":WEIGHT WEIGHT, " +
				":ALLERGYMARK ALLERGYMARK, " +
				":ALLERGY ALLERGY, " +
				":HANDICAPPEDMARK HANDICAPPEDMARK, " +
				":HANDICAPPED HANDICAPPED, " +
				":TRANSPORTTYPE TRANSPORTTYPE, " +
				":PREGNANCYMARK PREGNANCYMARK, " +
				":PREGNANCY PREGNANCY, " +
				":INFECTIONMARK INFECTIONMARK, " +
				":INFECTION INFECTION, " +
				":CONTRAINDICATIONMARK CONTRAINDICATIONMARK, " +
				":CONTRAINDICATION CONTRAINDICATION, " +
				":EXAMDATA EXAMDATA, " +
				":CREATININERESULT CREATININERESULT, " +
				"TO_DATE(:CREATININEUPDATEDATE) CREATININEUPDATEDATE, " +
				"SYSDATE HIS_UPDATEDATE " +
			"FROM " +
				"DUAL " +
		") pn " +
		"ON " +
		"( p.kanja_id = pn.kanja_id) " +
		"WHEN MATCHED THEN " + //-- 既存レコードの更新
			"UPDATE SET " +
				"KANASIMEI = pn.KANASIMEI, " +
				"ROMASIMEI = pn.ROMASIMEI, " +
				"KANJISIMEI = pn.KANJISIMEI, " +
				"SEX = pn.SEX, " +
				"BIRTHDAY = pn.BIRTHDAY, " +
				"JUSYO1 = pn.JUSYO1, " +
				"JUSYO2 = pn.JUSYO2, " +
				"JUSYO3 = pn.JUSYO3, " +
				"KANJA_NYUGAIKBN = pn.KANJA_NYUGAIKBN, " +
				"BYOUSITU_ID = pn.BYOUSITU_ID, " +
				"BLOOD = pn.BLOOD, " +
				"TALL = pn.TALL, " +
				"WEIGHT = pn.WEIGHT, " +
				"ALLERGYMARK = pn.ALLERGYMARK, " +
				"ALLERGY = pn.ALLERGY, " +
				"HANDICAPPEDMARK = pn.HANDICAPPEDMARK, " +
				"HANDICAPPED = pn.HANDICAPPED, " +
				"TRANSPORTTYPE = pn.TRANSPORTTYPE, " +
				"PREGNANCYMARK = pn.PREGNANCYMARK, " +
				"PREGNANCY = pn.PREGNANCY, " +
				"INFECTIONMARK = pn.INFECTIONMARK, " +
				"INFECTION = pn.INFECTION, " +
				"CONTRAINDICATIONMARK = pn.CONTRAINDICATIONMARK, " +
				"CONTRAINDICATION = pn.CONTRAINDICATION, " +
				"EXAMDATA = pn.EXAMDATA, " +
				"CREATININERESULT = pn.CREATININERESULT, " +
				"CREATININEUPDATEDATE = pn.CREATININEUPDATEDATE, " +
				"HIS_UPDATEDATE  = pn.HIS_UPDATEDATE " +
		"WHEN NOT MATCHED THEN " + //新規レコードの作成
			"INSERT " +
			"( " +
				"KANJA_ID, " +
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
				"pn.CONTRAINDICATIONMARK, " +
				"pn.CONTRAINDICATION, " +
				"pn.EXAMDATA, " +
				"pn.CREATININERESULT, " +
				"pn.CREATININEUPDATEDATE, " +
				"pn.HIS_UPDATEDATE " +
			") ";

		#endregion
		#endregion

		#region param

		/// <summary>
		/// KANJA_ID
		/// </summary>
		private const string PARAM_NAME_KANJA_ID = "KANJA_ID";

		/// <summary>
		/// KANASIMEI
		/// </summary>
		private const string PARAM_NAME_KANASIMEI = "KANASIMEI";

		/// <summary>
		/// ROMASIMEI
		/// </summary>
		private const string PARAM_NAME_ROMASIMEI = "ROMASIMEI";

		/// <summary>
		/// KANJISIMEI
		/// </summary>
		private const string PARAM_NAME_KANJISIMEI = "KANJISIMEI";

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
		/// CREATININERESULT
		/// </summary>
		private const string PARAM_NAME_CREATININERESULT = "CREATININERESULT";

		/// <summary>
		/// CREATININEUPDATEDATE
		/// </summary>
		private const string PARAM_NAME_CREATININEUPDATEDATE = "CREATININEUPDATEDATE";

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
			PatientInfoMsgData patientData = (PatientInfoMsgData)data;
			PatientAggregate patient = patientData.Request.MsgBody.Patient;
			string _AllergyMark;
			string _Allergy;
			string _HandicappedMark;
			string _Handicapped;
			string _TransportType;
			string _PregnancyMark;
			string _Pregnancy;
			string _InfectionMark;
			string _Infection;
			string _ContraindicationMark;
			string _Contraindication;
			string _ExamData;
			// 2020.08.28 Mod H.Taira@COSMO Start
			//string markerCharacter = ConfigurationManager.AppSettings["MARKERCHARACTER"].StringToString();
			string markerCharacter = "\r\n";
			// 2020.08.28 Mod H.Taira@COSMO End

			// カナローマ変換
			KanaRomaConvert kanaRomaConvert = new KanaRomaConvert();

			SetStringToCommand(PARAM_NAME_KANJA_ID, patient.PT_ID.TrimData, command);
			SetStringToCommand(PARAM_NAME_KANASIMEI, patient.PT_KN_NAME.TrimData, command);
			//患者ローマ字氏名（変換）
			SetStringToCommand(PARAM_NAME_ROMASIMEI, kanaRomaConvert.GetRomaConvert(patient.PT_KN_NAME.TrimData), command);
			SetStringToCommand(PARAM_NAME_KANJISIMEI, patient.PT_KJ_NAME.TrimData, command);
			SetStringToCommand(PARAM_NAME_SEX, GetSex(patient.PT_SEX.TrimData), command);
			SetStringToCommand(PARAM_NAME_BIRTHDAY, patient.PT_BIRTH.TrimData, command);
			SetStringToCommand(PARAM_NAME_JUSYO1, patient.PT_ZIP.TrimData, command);
			SetStringToCommand(PARAM_NAME_JUSYO2, patient.PT_ADDR.TrimData, command);
			SetStringToCommand(PARAM_NAME_JUSYO3, patient.PT_TEL.TrimData, command);


			SetStringToCommand(PARAM_NAME_KANJA_NYUGAIKBN, HISPTSTATUS2RISNYUGAIKBN(patient.PT_STATUS.TrimData), command);
			SetStringToCommand(PARAM_NAME_BYOUSITU_ID, patient.ROOM_CD.TrimData, command);


			SetStringToCommand(PARAM_NAME_BLOOD, patient.BLOOD_ABO.TrimData +
										patient.BLOOD_RH.TrimData, command);

			if (patient.PT_HEIGHT.TrimData == "")
			{
				SetStringToCommand(PARAM_NAME_TALL, string.Empty, command);
			}
			else
			{
				SetStringToCommand(PARAM_NAME_TALL, StrToFloatToStr(patient.PT_HEIGHT.TrimData), command);
			}

			if (patient.PT_WEIGHT.TrimData == "")
			{
				SetStringToCommand(PARAM_NAME_WEIGHT, string.Empty, command);
			}
			else
			{
				SetStringToCommand(PARAM_NAME_WEIGHT, GetPatientWeight(patient.PT_WEIGHT.TrimData,
															  patient.PT_WEIGHT_T.TrimData), command);
			}

			// アレルギー情報識別子
			if (StringUtils.GetFlag(PARAM_NAME_ALLERGYMARK,
					new DataNode[] {
						patient.ALGY_DRAG_FLG,
						patient.CONT_MED_ALGY1,
						patient.ALGY_FLOOD_FLG
					}))
			{
				_AllergyMark = "1";
			}
			else
			{
				_AllergyMark = "0";
			}
			SetIntToCommand(PARAM_NAME_ALLERGYMARK, _AllergyMark, command);

			// アレルギー情報
			_Allergy = StringUtils.GetNameValueStr(PARAM_NAME_ALLERGY,
										new DataNode[]
										{
											patient.ALGY_DRAG_FLG,
											patient.CONT_MED_ALGY1,
											patient.ALGY_FLOOD_FLG
										},
										markerCharacter
										);

			if (patient.ALGY_COMMENT.TrimData != "")
			{
				if (_AllergyMark == "1")
				{
					// 2020.08.28 Mod H.Taira@COSMO Start
					//_Allergy  = _Allergy + "|";
					_Allergy  = _Allergy + "\r\n";
					// 2020.08.28 Mod H.Taira@COSMO End
				}
				_Allergy  = _Allergy + "【造影剤コメント】";
				_Allergy  = _Allergy + patient.ALGY_COMMENT.TrimData;
			}
			SetStringToCommand(PARAM_NAME_ALLERGY, _Allergy, command);

			// 障害情報識別子
			if (StringUtils.GetFlag(PARAM_NAME_HANDICAPPEDMARK, 
							new DataNode[]
							{
								patient.LIMBS_SG_FLG,
								patient.VISION_SG_FLG,
								patient.AUDITORY_SG_FLG,
								patient.SPEECH_SG_FLG,
								patient.ECXCRETION_SG_FLG
							}
							))
			{
				_HandicappedMark  = "1";
			}
			else
			{
				_HandicappedMark = "0";
			}
			SetStringToCommand(PARAM_NAME_HANDICAPPEDMARK, _HandicappedMark, command);

			// 障害情報
			_Handicapped = StringUtils.GetNameValueStr(PARAM_NAME_HANDICAPPED,
								new DataNode[] {
									patient.LIMBS_SG_FLG,
									patient.VISION_SG_FLG,
									patient.AUDITORY_SG_FLG,
									patient.SPEECH_SG_FLG,
									patient.ECXCRETION_SG_FLG
								},
								markerCharacter
								);

			SetStringToCommand(PARAM_NAME_HANDICAPPED, _Handicapped, command);

			// 患者移動情報
			_TransportType  = ConfigurationManager.AppSettings[PARAM_NAME_TRANSPORTTYPE + "_" + patient.IDO_KBN.TrimData].StringToString();
			SetStringToCommand(PARAM_NAME_TRANSPORTTYPE, _TransportType, command);

			// 妊娠識別子
			_PregnancyMark = ConfigurationManager.AppSettings[PARAM_NAME_PREGNANCYMARK + "_" + patient.PREGNANT_FLG.TrimData].StringToString();
			SetStringToCommand(PARAM_NAME_PREGNANCYMARK, _PregnancyMark, command);

			// 妊娠情報
			_Pregnancy = ConfigurationManager.AppSettings[PARAM_NAME_PREGNANCY + "_" + patient.PREGNANT_FLG.TrimData].StringToString();
			SetStringToCommand(PARAM_NAME_PREGNANCY, _Pregnancy, command);

			// 感染情報識別子
			if (StringUtils.GetFlag(PARAM_NAME_INFECTIONMARK,
						new DataNode[] {
							patient.MRSA,
							patient.HB,
							patient.HC,
							patient.HIV,
							patient.RPR,
							patient.PS,
							patient.ATLV,
							patient.TP,
							patient.GBS,
							patient.LTBI,
							patient.KN_OTHER
						}
						))
			{
				_InfectionMark  = "1";
			}
			else
			{
				_InfectionMark = "0";
			}

			SetStringToCommand(PARAM_NAME_INFECTIONMARK, _InfectionMark, command);

			// 感染情報
			_Infection = StringUtils.GetNameValueStr(PARAM_NAME_INFECTION,
								new DataNode[] {
									patient.MRSA,
									patient.HB,
									patient.HC,
									patient.HIV,
									patient.RPR,
									patient.PS,
									patient.ATLV,
									patient.TP,
									patient.GBS,
									patient.LTBI,
								},
								markerCharacter
								);

			if (StringUtils.GetFlag(PARAM_NAME_INFECTIONMARK,
						new DataNode[] {
							patient.KN_OTHER
						}
						))
			{
				// 2020.08.28 Mod H.Taira@COSMO Start
				//_Infection = _Infection + "|" + "【" + patient.KN_OTHER_NM.TrimData + "】★あり";
				_Infection = _Infection + "\r\n" + "【" + patient.KN_OTHER_NM.TrimData + "】★あり";
				// 2020.08.28 Mod H.Taira@COSMO End
			}
			SetStringToCommand(PARAM_NAME_INFECTION, _Infection, command);

			// 禁忌情報識別子
			if (StringUtils.GetFlag("CONTRAINDICATIONMARK",
					new DataNode[] {
						patient.HEART_FLG,
						patient.BPH_FLG,
						patient.KOJSEN_FLG,
						patient.GLAUCOMA_FLG,
						patient.RENEAL_FLG,
						patient.ASTHMA_FLG,
						patient.BLEED_FLG
					}
					))
			{
				_ContraindicationMark  = "1";
			}
			else
			{
				_ContraindicationMark = "0";
			}

			SetStringToCommand(PARAM_NAME_CONTRAINDICATIONMARK, _ContraindicationMark, command);

			// 禁忌情報
			_Contraindication = StringUtils.GetNameValueStr(PARAM_NAME_CONTRAINDICATION,
								new DataNode[] {
									patient.HEART_FLG,
									patient.BPH_FLG,
									patient.KOJSEN_FLG,
									patient.GLAUCOMA_FLG,
									patient.RENEAL_FLG,
									patient.ASTHMA_FLG,
									patient.BLEED_FLG
								},
								markerCharacter
								);

			SetStringToCommand(PARAM_NAME_CONTRAINDICATION, _Contraindication, command);

			// 検査データ情報
			_ExamData  = "";
			if (patient.KEKKA1.TrimData != "") //クレアチニン
			{
				_ExamData  = _ExamData + ConfigurationManager.AppSettings[PARAM_NAME_EXAMDATA + "_" + patient.KEKKA1.TrimData].StringToString();
				_ExamData  = _ExamData + " ";
				_ExamData  = _ExamData + patient.KEKKA1.TrimData + "mg/dl";
				_ExamData  = _ExamData + " ";
				_ExamData  = _ExamData + patient.KEKKA1_DATE.TrimData;
			}

			SetStringToCommand(PARAM_NAME_EXAMDATA, _ExamData, command);

			//クレアチニン値
			if (!string.IsNullOrEmpty(patient.KEKKA1.TrimData))
			{
				// 2020.09.10 Mod Nishihara@COSMO Start クレアチニン値格納内容修正
				//SetStringToCommand(PARAM_NAME_CREATININERESULT, patient.KEKKA1_DATE.TrimData, command);
				SetStringToCommand(PARAM_NAME_CREATININERESULT, patient.KEKKA1.TrimData, command);
				// 2020.09.10 Mod Nishihara@COSMO End クレアチニン値格納内容修正
			}
			else
			{
				SetStringToCommand(PARAM_NAME_CREATININERESULT, string.Empty, command);
			}

			//クレアチニン検査日
			if (!string.IsNullOrEmpty(patient.KEKKA1_DATE.TrimData))
			{
				SetStringToCommand(PARAM_NAME_CREATININEUPDATEDATE, patient.KEKKA1_DATE.TrimData, command);
			}
			else
			{
				SetStringToCommand(PARAM_NAME_CREATININEUPDATEDATE, string.Empty, command);
			}

			//SetStringToCommand(PARAM_NAME_HIS_UPDATEDATE, PARAM_NAME_SYSDATE, command);
		}

		// HISのPT_STATUSをRISのKANJA_NYUGAIKBNに変換する
		public string HISPTSTATUS2RISNYUGAIKBN(string pPTSTATUS)
		{
			string Result;
			if (pPTSTATUS == "1") // HISの入院=1
			{
				Result = "2"; //INOUT_HOSPITALIZATION;
			}
			else
			{
				Result = "1";//INOUT_OUTPATIENT;
			}
			return Result;
		}

		public string StrToFloatToStr(string pValue)
		{
			float Result = 0;
			if (float.TryParse(pValue, out Result))
			{
				Result = float.Parse(pValue);
			}
			return Result.ToString();
		}

		/// <summary>
		/// GetSex
		/// </summary>
		/// <param name="pSex"></param>
		/// <returns></returns>
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

		//------------------------------------------------------------------------------
		//GetPatientWeight（体重取得）
		//------------------------------------------------------------------------------
		public string GetPatientWeight(string pWeight, string pUnit)
		{
			double _FloatWeight;
			string Result;
			try
			{
				if (pUnit == WEIGHT_T_KG)
				{
					_FloatWeight = double.Parse(pWeight);
				}
				else if (pUnit == WEIGHT_T_G)
				{
					_FloatWeight = double.Parse(pWeight) / 1000;
				}
				else
				{
					//raise Exception.Create('単位が不正です');
					_FloatWeight = double.Parse(pWeight);
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
			catch (Exception ex)
			{
				Result = "0";
			}
			return Result;
		}
	}
}
