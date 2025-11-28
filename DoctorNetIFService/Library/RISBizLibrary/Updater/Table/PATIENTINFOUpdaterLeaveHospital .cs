using RISBizLibrary.Data;
using RISBizLibrary.Download.Data;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.LeaveHospitalize;

namespace RISBizLibrary.Updater.Table
{
	public class PATIENTINFOUpdaterLeaveHospital : BaseUpdater
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
				"BYOUTOU_ID = pn.BYOUTOU_ID, " +
				"BYOUSITU_ID = pn.BYOUSITU_ID, " +
				"SECTION_ID = case pn.KANJA_NYUGAIKBN " +
				"               when '1' then null " +
				"               else SECTION_ID end, " +
				"HIS_UPDATEDATE = pn.HIS_UPDATEDATE " +
		//"WHEN NOT MATCHED THEN " + //新規レコードの作成
		//	"INSERT " +
		//	"( " +
		//		"KANJA_ID, " +
		//		"KANJA_NYUGAIKBN, " +
		//		"BYOUTOU_ID, " +
		//		"BYOUSITU_ID, " +
		//		"SECTION_ID " +
		//		"HIS_UPDATEDATE " +
		//	") " +
		//	"VALUES " +
		//	"( " +
		//		"pn.KANJA_NYUGAIKBN, " +
		//		"pn.KANJA_ID, " +
		//		"pn.BYOUTOU_ID, " +
		//		"pn.BYOUSITU_ID, " +
		//		"pn.SECTION_ID " +
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
			LeaveHospitalizeMsgData targetData = (LeaveHospitalizeMsgData)data;
			LeaveHospitalizeAggregate root = targetData.Request.MsgBody.LeaveHospitalize;

			SetStringToCommand(PARAM_NAME_KANJA_ID, root.PT_ID.TrimData, command);

			// 退院
			if (root.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_LEAVE_HOSPITAL)
			{
				SetStringToCommand(PARAM_NAME_KANJA_NYUGAIKBN, RQRISDBConst.PATIENTINFO_KANJA_NYUGAIKBN_CLINIC, command);
				SetStringToCommand(PARAM_NAME_BYOUTOU_ID, string.Empty, command);
				SetStringToCommand(PARAM_NAME_BYOUSITU_ID, string.Empty, command);
				//SetStringToCommand(PARAM_NAME_SECTION_ID, string.Empty, command);
				//SetStringToCommand(PARAM_NAME_HIS_UPDATEDATE, PARAM_NAME_SYSDATE, command);
			}

			// 退院キャンセル
			if (root.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_LEAVE_HOSPITAL_CANCEL)
			{
				SetStringToCommand(PARAM_NAME_KANJA_NYUGAIKBN, RQRISDBConst.PATIENTINFO_KANJA_NYUGAIKBN_ADMISSION, command);
				SetStringToCommand(PARAM_NAME_BYOUTOU_ID, root.BYOTO_CD.TrimData, command);
				SetStringToCommand(PARAM_NAME_BYOUSITU_ID, root.ROOM_CD.TrimData, command);
				//SetStringToCommand(PARAM_NAME_HIS_UPDATEDATE, PARAM_NAME_SYSDATE, command);
			}
		}
	}
}
