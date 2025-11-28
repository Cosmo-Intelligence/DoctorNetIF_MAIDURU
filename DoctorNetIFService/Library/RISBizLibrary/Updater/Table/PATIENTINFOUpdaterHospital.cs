using RISBizLibrary.Data;
using RISBizLibrary.Download.Data;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.Hospitalize;

namespace RISBizLibrary.Updater.Table
{
	public class PATIENTINFOUpdaterHospital : BaseUpdater
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
				":KANJA_NYUGAIKBN KANJA_NYUGAIKBN, " +
				":SECTION_ID SECTION_ID, " +
				":BYOUTOU_ID BYOUTOU_ID, " +
				":BYOUSITU_ID BYOUSITU_ID, " +
				"SYSDATE HIS_UPDATEDATE " +
			"FROM " +
				"DUAL " +
		") pn " +
		"ON " +
		"( p.kanja_id = pn.kanja_id) " +
		"WHEN MATCHED THEN " + //-- 既存レコードの更新
			"UPDATE SET " +
				"KANJA_NYUGAIKBN = pn.KANJA_NYUGAIKBN, " +
				"SECTION_ID = pn.SECTION_ID, " +
				"BYOUTOU_ID = pn.BYOUTOU_ID, " +
				"BYOUSITU_ID = pn.BYOUSITU_ID, " +
				"HIS_UPDATEDATE = pn.HIS_UPDATEDATE " +
		//"WHEN NOT MATCHED THEN " + //新規レコードの作成
		//	"INSERT " +
		//	"( " +
		//		"KANJA_ID, " +
		//		"KANJA_NYUGAIKBN, " +
		//		"SECTION_ID, " +
		//		"BYOUTOU_ID, " +
		//		"BYOUSITU_ID, " +
		//		"HIS_UPDATEDATE " +
		//	") " +
		//	"VALUES " +
		//	"( " +
		//		"pn.KANJA_ID, " +
		//		"pn.KANJA_NYUGAIKBN, " +
		//		"pn.SECTION_ID, " +
		//		"pn.BYOUTOU_ID, " +
		//		"pn.BYOUSITU_ID, " +
		//		"pn.HIS_UPDATEDATE " +
		//	") " +
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
			HospitalMsgData targetData = (HospitalMsgData)data;
			HospitalizeAggregate root = targetData.Request.MsgBody.Hospitalize;

			SetStringToCommand(PARAM_NAME_KANJA_ID, root.PT_ID.TrimData, command);

			// 入院
			if (root.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_HOSPITALIZE)
			{
				SetStringToCommand(PARAM_NAME_KANJA_NYUGAIKBN, RQRISDBConst.PATIENTINFO_KANJA_NYUGAIKBN_ADMISSION, command);
				SetStringToCommand(PARAM_NAME_SECTION_ID, root.KA_CD.TrimData, command);
				SetStringToCommand(PARAM_NAME_BYOUTOU_ID, root.BYOTO_CD.TrimData, command);
				SetStringToCommand(PARAM_NAME_BYOUSITU_ID, root.ROOM_CD.TrimData, command);
				//SetStringToCommand(PARAM_NAME_HIS_UPDATEDATE, PARAM_NAME_SYSDATE, command);
			}

			// 入院キャンセル
			if (root.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_HOSPITALIZE_CANCEL)
			{
				SetStringToCommand(PARAM_NAME_KANJA_NYUGAIKBN, RQRISDBConst.PATIENTINFO_KANJA_NYUGAIKBN_CLINIC, command);
				SetStringToCommand(PARAM_NAME_SECTION_ID, string.Empty, command);
				SetStringToCommand(PARAM_NAME_BYOUTOU_ID, string.Empty, command);
				SetStringToCommand(PARAM_NAME_BYOUSITU_ID, string.Empty, command);
				//SetStringToCommand(PARAM_NAME_HIS_UPDATEDATE, PARAM_NAME_SYSDATE, command);
			}
		}
	}
}
