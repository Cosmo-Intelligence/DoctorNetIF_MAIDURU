using System;
using System.Configuration;
using System.Data;
using RISBizLibrary.Data;
using RISBizLibrary.Download.Data;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.Msg.Common.OrderInfo;
using RISCommonLibrary.Lib.Utils;
using RISODPLibrary.Lib.Utils;

namespace RISBizLibrary.Updater.Table
{
	public class ORDERMAINTABLEUpdaterOrderInfo : BaseUpdater
	{
		#region const

		private const string CST_STUDYINSTANCEUID_FIXED = "1.2.392.200045.6960.4.7.";
		private const string XX_KBN_RI        = "17"; 
		private const string XX_KBN_RADIOLOGY        = "16";
		private const string LENGTH_AGE_YEAR = "3";
		#region InsertSQL

		/// <summary>
		/// InsertSQL
		/// </summary>
		private const string INSERT_SQL =
		"MERGE INTO ORDERMAINTABLE p " +
		"USING " +
		"( " +
			"SELECT " +
				":RIS_ID RIS_ID, " +
				":SYSTEMKBN SYSTEMKBN, " +
				":STUDYINSTANCEUID STUDYINSTANCEUID, " +
				":ORDERNO ORDERNO, " +
				":ACCESSIONNO ACCESSIONNO, " +
				":KENSA_DATE KENSA_DATE, " +
				":KENSA_STARTTIME KENSA_STARTTIME, " +
				":KENSATYPE_ID KENSATYPE_ID, " +
				":KENSASITU_ID KENSASITU_ID, " +
				":KENSAKIKI_ID KENSAKIKI_ID, " +
				":SYOTISITU_FLG SYOTISITU_FLG, " +
				":KANJA_ID KANJA_ID, " +
				":KENSA_DATE_AGE KENSA_DATE_AGE, " +
				":DENPYO_NYUGAIKBN DENPYO_NYUGAIKBN, " +
				":DENPYO_BYOUTOU_ID DENPYO_BYOUTOU_ID, " +
				":DENPYO_BYOSITU_ID DENPYO_BYOSITU_ID, " +
				":IRAI_SECTION_ID IRAI_SECTION_ID, " +
				":IRAI_DOCTOR_NO IRAI_DOCTOR_NO, " +
				":IRAI_DOCTOR_NAME IRAI_DOCTOR_NAME, " +
				":IRAI_DOCTOR_RENRAKU IRAI_DOCTOR_RENRAKU, " +
				":DOKUEI_FLG DOKUEI_FLG " +	
			"FROM " +
				"DUAL " +
		") pn " +
		"ON " +
		"( p.RIS_ID = pn.RIS_ID) " +
		//"WHEN MATCHED THEN " + //-- 既存レコードの更新
		//	"UPDATE SET " +
		//		"SYSTEMKBN = pn.SYSTEMKBN, " +
		//		"STUDYINSTANCEUID = pn.STUDYINSTANCEUID, " +
		//		"ORDERNO = pn.ORDERNO, " +
		//		"ACCESSIONNO = pn.ACCESSIONNO, " +
		//		"KENSA_DATE = pn.KENSA_DATE, " +
		//		"KENSA_STARTTIME = pn.KENSA_STARTTIME, " +
		//		"KENSATYPE_ID = pn.KENSATYPE_ID, " +
		//		"KENSASITU_ID = pn.KENSASITU_ID, " +
		//		"KENSAKIKI_ID = pn.KENSAKIKI_ID, " +
		//		"SYOTISITU_FLG = pn.SYOTISITU_FLG, " +
		//		"KANJA_ID = pn.KANJA_ID, " +
		//		"KENSA_DATE_AGE = pn.KENSA_DATE_AGE, " +
		//		"DENPYO_NYUGAIKBN = pn.DENPYO_NYUGAIKBN, " +
		//		"DENPYO_BYOUTOU_ID = pn.DENPYO_BYOUTOU_ID, " +
		//		"DENPYO_BYOSITU_ID = pn.DENPYO_BYOSITU_ID, " +
		//		"IRAI_SECTION_ID = pn.IRAI_SECTION_ID, " +
		//		"IRAI_DOCTOR_NO = pn.IRAI_DOCTOR_NO, " +
		//		"IRAI_DOCTOR_NAME = pn.IRAI_DOCTOR_NAME, " +
		//		"IRAI_DOCTOR_RENRAKU = pn.IRAI_DOCTOR_RENRAKU, " +
		//		"DOKUEI_FLG = pn.DOKUEI_FLG " +
		"WHEN NOT MATCHED THEN " + //新規レコードの作成
			"INSERT " +
			"( " +
				"RIS_ID, " +
				"SYSTEMKBN, " +
				"STUDYINSTANCEUID, " +
				"ORDERNO, " +
				"ACCESSIONNO, " +
				"KENSA_DATE, " +
				"KENSA_STARTTIME, " +
				"KENSATYPE_ID, " +
				"KENSASITU_ID, " +
				"KENSAKIKI_ID, " +
				"SYOTISITU_FLG, " +
				"KANJA_ID, " +
				"KENSA_DATE_AGE, " +
				"DENPYO_NYUGAIKBN, " +
				"DENPYO_BYOUTOU_ID, " +
				"DENPYO_BYOSITU_ID, " +
				"IRAI_SECTION_ID, " +
				"IRAI_DOCTOR_NO, " +
				"IRAI_DOCTOR_NAME, " +
				"IRAI_DOCTOR_RENRAKU, " +
				"DOKUEI_FLG " +
			") " +
			"VALUES " +
			"( " +
				"pn.RIS_ID, " +
				"pn.SYSTEMKBN, " +
				"pn.STUDYINSTANCEUID, " +
				"pn.ORDERNO, " +
				"pn.ACCESSIONNO, " +
				"pn.KENSA_DATE, " +
				"pn.KENSA_STARTTIME, " +
				"pn.KENSATYPE_ID, " +
				"pn.KENSASITU_ID, " +
				"pn.KENSAKIKI_ID, " +
				"pn.SYOTISITU_FLG, " +
				"pn.KANJA_ID, " +
				"pn.KENSA_DATE_AGE, " +
				"pn.DENPYO_NYUGAIKBN, " +
				"pn.DENPYO_BYOUTOU_ID, " +
				"pn.DENPYO_BYOSITU_ID, " +
				"pn.IRAI_SECTION_ID, " +
				"pn.IRAI_DOCTOR_NO, " +
				"pn.IRAI_DOCTOR_NAME, " +
				"pn.IRAI_DOCTOR_RENRAKU, " +
				"pn.DOKUEI_FLG " +
			") ";

		#endregion
		#endregion

		#region param

		/// <summary>
		/// RIS_ID
		/// </summary>
		private const string PARAM_NAME_RIS_ID = "RIS_ID";

		/// <summary>
		/// SYSTEMKBN
		/// </summary>
		private const string PARAM_NAME_SYSTEMKBN = "SYSTEMKBN";

		/// <summary>
		/// STUDYINSTANCEUID
		/// </summary>
		private const string PARAM_NAME_STUDYINSTANCEUID = "STUDYINSTANCEUID";

		/// <summary>
		/// ORDERNO
		/// </summary>
		private const string PARAM_NAME_ORDERNO = "ORDERNO";

		/// <summary>
		/// ACCESSIONNO
		/// </summary>
		private const string PARAM_NAME_ACCESSIONNO = "ACCESSIONNO";

		/// <summary>
		/// KENSA_DATE
		/// </summary>
		private const string PARAM_NAME_KENSA_DATE = "KENSA_DATE";

		/// <summary>
		/// KENSA_STARTTIME
		/// </summary>
		private const string PARAM_NAME_KENSA_STARTTIME = "KENSA_STARTTIME";

		/// <summary>
		/// KENSATYPE_ID
		/// </summary>
		private const string PARAM_NAME_KENSATYPE_ID = "KENSATYPE_ID";

		/// <summary>
		/// KENSASITU_ID
		/// </summary>
		private const string PARAM_NAME_KENSASITU_ID = "KENSASITU_ID";

		/// <summary>
		/// KENSAKIKI_ID
		/// </summary>
		private const string PARAM_NAME_KENSAKIKI_ID = "KENSAKIKI_ID";

		/// <summary>
		/// SYOTISITU_FLG
		/// </summary>
		private const string PARAM_NAME_SYOTISITU_FLG = "SYOTISITU_FLG";

		/// <summary>
		/// KANJA_ID
		/// </summary>
		private const string PARAM_NAME_KANJA_ID = "KANJA_ID";

		/// <summary>
		/// KENSA_DATE_AGE
		/// </summary>
		private const string PARAM_NAME_KENSA_DATE_AGE = "KENSA_DATE_AGE";

		/// <summary>
		/// DENPYO_NYUGAIKBN
		/// </summary>
		private const string PARAM_NAME_DENPYO_NYUGAIKBN = "DENPYO_NYUGAIKBN";

		/// <summary>
		/// DENPYO_BYOUTOU_ID
		/// </summary>
		private const string PARAM_NAME_DENPYO_BYOUTOU_ID = "DENPYO_BYOUTOU_ID";

		/// <summary>
		/// DENPYO_BYOSITU_ID
		/// </summary>
		private const string PARAM_NAME_DENPYO_BYOSITU_ID = "DENPYO_BYOSITU_ID";

		/// <summary>
		/// IRAI_SECTION_ID
		/// </summary>
		private const string PARAM_NAME_IRAI_SECTION_ID = "IRAI_SECTION_ID";

		/// <summary>
		/// IRAI_DOCTOR_NO
		/// </summary>
		private const string PARAM_NAME_IRAI_DOCTOR_NO = "IRAI_DOCTOR_NO";

		/// <summary>
		/// IRAI_DOCTOR_NAME
		/// </summary>
		private const string PARAM_NAME_IRAI_DOCTOR_NAME = "IRAI_DOCTOR_NAME";

		/// <summary>
		/// IRAI_DOCTOR_RENRAKU
		/// </summary>
		private const string PARAM_NAME_IRAI_DOCTOR_RENRAKU = "IRAI_DOCTOR_RENRAKU";

		/// <summary>
		/// DOKUEI_FLG
		/// </summary>
		private const string PARAM_NAME_DOKUEI_FLG = "DOKUEI_FLG";



		/// <summary>
		/// BUI_ID
		/// </summary>
		private const string PARAM_NAME_BUI_ID = "BUI_ID";

		#endregion


		#region field
		#endregion

		public override string TargetSQL
		{
			get
			{
				return INSERT_SQL;
			}
		}

		//------------------------------------------------------------------------------
		//オーダーメインテーブルにレコードを挿入するSQLをリストに追加する
		//[引数]
		//  pSQLs: TStrings; SQLリスト
		//  pRIS_ID; RIS識別ID
		//  pIndex: integer; 検査予約情報配列のインデックス
		//  pDelegateExamInfo: TExamInfoOrder; 代表検査情報
		//------------------------------------------------------------------------------
		public override void SetParams(BaseMsgData data, System.Data.IDbCommand command)
		{
			command.Parameters.Clear();
			OrderInfoMsgData orderData = (OrderInfoMsgData)data;
			HISRISOrderInfoAggregate order = orderData.Request.MsgBody.OrderInfo;

			DateTime _Birthday = DateTime.Now;
			DateTime _ScheduledDate = DateTime.Now;
			string chkStr = "";

			SetStringToCommand(PARAM_NAME_RIS_ID, orderData.RIS_ID, command);
			SetStringToCommand(PARAM_NAME_SYSTEMKBN, "0", command);
			SetStringToCommand(PARAM_NAME_STUDYINSTANCEUID, func_Get_StudyInstanceUID() + orderData.RIS_ID, command);
			SetStringToCommand(PARAM_NAME_ORDERNO, order.ORDER_NO.TrimData, command);
			SetStringToCommand(PARAM_NAME_ACCESSIONNO, order.ORDER_NO.TrimData, command);

			if (order.XX_KBN.TrimData == XX_KBN_RI)
			{
				SetStringToCommand(PARAM_NAME_KENSA_DATE, order.YK_SUMM[0].YK_DATE.TrimData, command);
				SetStringToCommand(PARAM_NAME_KENSA_STARTTIME, order.YK_SUMM[0].YK_TIME.TrimData, command);
			}
			else if (order.XX_KBN.TrimData == XX_KBN_RADIOLOGY)
			{
				SetStringToCommand(PARAM_NAME_KENSA_DATE, order.START_DATE.TrimData, command);
				SetStringToCommand(PARAM_NAME_KENSA_STARTTIME, order.EXEC_TIME.TrimData, command);
			}

			SetStringToCommand(PARAM_NAME_KENSATYPE_ID, order.KNS_SYBT1.TrimData, command);
			SetStringToCommand(PARAM_NAME_KENSASITU_ID, GetEXAMROOM_ID(order, 0), command);
			SetStringToCommand(PARAM_NAME_KENSAKIKI_ID, GetKENSAKIKI_ID(order, 0), command);
			if (GetCNT_SYOTISITU_FLG(order, 0) > 0)
			{
				SetStringToCommand(PARAM_NAME_SYOTISITU_FLG, "1", command);
			}
			else if (GetCNT_SYOTISITU_FLG(order, 0) == 0)
			{
				SetStringToCommand(PARAM_NAME_SYOTISITU_FLG, "0", command);
			}

			SetStringToCommand(PARAM_NAME_KANJA_ID, order.PT_ID1.TrimData, command);

			if (TryYYYYMMDDToDate(order.PT_BIRTH.Data, ref _Birthday))
			{
				TryYYYYMMDDToDate(order.START_DATE.Data, ref _ScheduledDate);
				SetStringToCommand(PARAM_NAME_KENSA_DATE_AGE, GetCalculateAge(_Birthday, _ScheduledDate), command);
			}
			else
			{
				// 2020.07.21 mod start cosmo@nishihara 計算できない場合は"999"をいれるように修正
				//SetStringToCommand(PARAM_NAME_KENSA_DATE_AGE, string.Empty, command);
				SetStringToCommand(PARAM_NAME_KENSA_DATE_AGE, "999", command);
				// 2020.07.21 mod end cosmo@nishihara 計算できない場合は"999"をいれるように修正
			}

			SetStringToCommand(PARAM_NAME_DENPYO_NYUGAIKBN, order.NYUGAI_KBN.TrimData, command);
			SetStringToCommand(PARAM_NAME_DENPYO_BYOUTOU_ID, order.BYOTO_CD.TrimData, command);
			//2014.8.16 cosmo add ------------------------------------------------------- start
			SetStringToCommand(PARAM_NAME_DENPYO_BYOSITU_ID, order.ROOM_CD.TrimData, command);
			//2014.8.16 cosmo add ------------------------------------------------------- end
			SetStringToCommand(PARAM_NAME_IRAI_SECTION_ID, order.KA_CD1.TrimData, command);
			SetStringToCommand(PARAM_NAME_IRAI_DOCTOR_NO, order.DR_ID1.TrimData, command);
			SetStringToCommand(PARAM_NAME_IRAI_DOCTOR_NAME, order.SH_NAME.TrimData, command);
			SetStringToCommand(PARAM_NAME_IRAI_DOCTOR_RENRAKU, order.PHS.TrimData, command);
			ReportFlgCheck(order, command, ref chkStr);
			SetStringToCommand(PARAM_NAME_DOKUEI_FLG, chkStr, command);
		}

		public bool TryYYYYMMDDToDate(string pYYYYMMDD, ref DateTime pDate)
		{
			/*YYYYMMDD形式の文字列をTDateTime型に変換する*/
			string _Year;
			string _Month;
			string _Day;

			bool Result = false;
			try
			{
				_Year = StringUtils.Mid(pYYYYMMDD, 1, 4);
				_Month = StringUtils.Mid(pYYYYMMDD, 5, 2);
				_Day = StringUtils.Mid(pYYYYMMDD, 7, 2);
				// 2020.07.28 mod start cosmo@nishihara
				//pDate = DateTime.Parse(_Year z+ _Month + _Day);
				pDate = DateTime.Parse(_Year + "/" + _Month + "/" + _Day);
				// 2020.07.28 mod end cosmo@nishihara
			}
			catch (Exception)
			{
				return false;
			}
			
			Result = true;
			return Result;
		}

		//------------------------------------------------------------------------------
		//STUDYINSTANCEUID固定部取得
		//------------------------------------------------------------------------------
		public string func_Get_StudyInstanceUID()
		{

			string _SQL;
			string _license_no;
			DataTable _Resultset = new DataTable();

			string Result  = "";
			_SQL = "";
			_SQL = "SELECT LICENSENO FROM SYSTEMDEFINE";
			//_Resultset = TRecordList.Create;
			try
			{
				//TDBMgr.GetDBMgr.OpenSQL(_SQL, nil, _ResultSet);
				using (IDbCommand command = connection.CreateCommand())
				{
					command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
					command.CommandText = _SQL;

					//IDataParameter param = command.CreateParameter();
					//param.SetInputString(PARAM_NAME_BUI_ID, "'" + pBui_cd + "'");
					//command.Parameters.Add(param);

					MiscUtils.WriteDbCommandLogForLog4net(command, _log);

					IDataReader reader = command.ExecuteReader();
					try
					{
						_Resultset.Load(reader);
						if (_Resultset.Rows.Count == 0)
						{
							//throw new DataNotFoundException(string.Format(
							//	"データが見つかりませんでした。"));
						}

						//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

					}
					finally
					{
						reader.Close();
					}
				}

				_license_no = _Resultset.Rows[0]["LICENSENO"].ToString();
			}
			finally
			{
				_Resultset = null;
			}
			Result = CST_STUDYINSTANCEUID_FIXED + _license_no;
			return Result;
		}


		//------------------------------------------------------------------------------
		//BUIMASTER.EXAMROOM_ID取得
		//[引数]
		//  pBUIIdx: integer; 部位インデックス
		//[戻り値]
		//  Result; EXAMROOM_ID
		//------------------------------------------------------------------------------
		public string GetEXAMROOM_ID(HISRISOrderInfoAggregate order, int pBUIIdx)
		{
			string SQL_GET_EXAMROOM_ID = "select EXAMROOM_ID from BUIMASTER where BUI_ID = :BUI_ID";
			DataTable _Results = new DataTable();
			string _PartID = "";

			//_PartID  = order.BUI_SUMM[pBUIIdx].BUI_CD.Data;
			_PartID  = order.BUI_SUMM[pBUIIdx].BUI_CD.Data.Replace(" ", "").Replace("　", "");

			string Result = "";

			try
			{
				using (IDbCommand command = connection.CreateCommand())
				{
					command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
					command.CommandText = SQL_GET_EXAMROOM_ID;

					IDataParameter param = command.CreateParameter();
					param.SetInputString(PARAM_NAME_BUI_ID, _PartID);
					command.Parameters.Add(param);

					MiscUtils.WriteDbCommandLogForLog4net(command, _log);

					IDataReader reader = command.ExecuteReader();
					try
					{
						_Results.Load(reader);
						if (_Results.Rows.Count == 0)
						{
							//throw new DataNotFoundException(string.Format(
							//	"データが見つかりませんでした。"));
						}

						//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

					}
					finally
					{
						reader.Close();
					}
				}

				if (_Results.Rows.Count == 0)
				{
					_log.Error("BUIMASTERに対象レコードなし：部位ID=" + _PartID);
					return Result;
				}

				Result = _Results.Rows[0][0].ToString();
			}
			finally
			{
				_Results = null;
			}
			return Result;
		}

		//------------------------------------------------------------------------------
		//BUIMASTER.KENSAKIKI_ID取得
		//[引数]
		//  pBUIIdx: integer; 部位インデックス
		//[戻り値]
		//  Result; KENSAKIKI_ID
		//------------------------------------------------------------------------------
		public string GetKENSAKIKI_ID(HISRISOrderInfoAggregate order, int pBUIIdx)
		{
			string SQL_GET_KENSAKIKI_ID = "select KENSAKIKI_ID from BUIMASTER where BUI_ID = :BUI_ID";
			DataTable _Results = new DataTable();
			string _PartID;

			//_PartID  = (order.BUI_SUMM[pBUIIdx].BUI_CD.Data);
			_PartID = (order.BUI_SUMM[pBUIIdx].BUI_CD.Data).Replace(" ", "").Replace("　", "");

			string Result = "";

			try
			{
				using (IDbCommand command = connection.CreateCommand())
				{
					command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
					command.CommandText = SQL_GET_KENSAKIKI_ID;

					IDataParameter param = command.CreateParameter();
					param.SetInputString(PARAM_NAME_BUI_ID, _PartID);
					command.Parameters.Add(param);

					MiscUtils.WriteDbCommandLogForLog4net(command, _log);

					IDataReader reader = command.ExecuteReader();
					try
					{
						_Results.Load(reader);
						if (_Results.Rows.Count == 0)
						{
							//throw new DataNotFoundException(string.Format(
							//	"データが見つかりませんでした。"));
						}

						//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

					}
					finally
					{
						reader.Close();
					}
				}
				if (_Results.Rows.Count == 0)
				{
					_log.Error("BUIMASTERに対象レコードなし：部位ID=" + _PartID);
					return Result;
				}

				Result = _Results.Rows[0][0].ToString();
			}
			finally
			{
				_Results =null;
			}
			return Result;
		}


		//------------------------------------------------------------------------------
		//BUIMASTER.SYOTISITU_FLG='1'のレコード件数
		//[引数]
		//  pBUIIdx: integer; 部位インデックス
		//[戻り値]
		//  Result: integer; 件数
		//------------------------------------------------------------------------------
		public int GetCNT_SYOTISITU_FLG(HISRISOrderInfoAggregate order, int pBUIIdx)
		{
			string SQL_GET_CNT = "select count(SYOTISITU_FLG) from BUIMASTER where BUI_ID = :BUI_ID and SYOTISITU_FLG = '1'";
			DataTable _Results = new DataTable();
			string _PartID;
			int Result;
			 //_PartID  = order.BUI_SUMM[pBUIIdx].BUI_CD.Data;
			 _PartID  = order.BUI_SUMM[pBUIIdx].BUI_CD.Data.Replace(" ", "").Replace("　", "");

			try
			{
				using (IDbCommand command = connection.CreateCommand())
				{
					command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
					command.CommandText = SQL_GET_CNT;

					IDataParameter param = command.CreateParameter();
					param.SetInputString(PARAM_NAME_BUI_ID, _PartID);
					command.Parameters.Add(param);

					MiscUtils.WriteDbCommandLogForLog4net(command, _log);

					IDataReader reader = command.ExecuteReader();
					try
					{
						_Results.Load(reader);
						if (_Results.Rows.Count == 0)
						{
							//throw new DataNotFoundException(string.Format(
							//	"データが見つかりませんでした。"));
						}

						//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);

					}
					finally
					{
						reader.Close();
					}
				}
				Result = _Results.Rows.Count;
				if (_Results.Rows.Count == 0)
				{
					_log.Error("BUIMASTERに対象レコードなし：部位ID=" + _PartID);
				}

			}
			finally
			{
				_Results = null;
			}
			return Result;
		}

		//---------------------------------------------------
		//生年月日と起算日から計算時年齢を求める
		//[引数]
		//	pBirthday: TDateTime; 生年月日
		//	pCalcDate: TDateTime; 起算日
		//[戻り値]
		//	Result; 計算時年齢 [000]年齢[00]月
		//---------------------------------------------------
		public string GetCalculateAge(DateTime pBirthday, DateTime pCalcDate)
		{
			//string FORMAT_EXAM_AGE = "%" + LENGTH_AGE_YEAR + "d%";
			int _YAge;

			string Result  = "";
			_YAge = CalcAgeYear(pBirthday, pCalcDate);

			Result = _YAge.ToString("000");
			return Result;
		}

		//---------------------------------------------------
		//生年月日と起算日から年齢を求める
		//[引数]
		//	pBirthday: TDateTime; 生年月日
		//	pCalcDate: TDateTime; 起算日
		//[戻り値]
		//	Result: integer; 年齢
		//---------------------------------------------------
		public int CalcAgeYear(DateTime pBirthday, DateTime pCalcDate)
		{
			int _By, _Bm, _Bd;
			int _Cy, _Cm, _Cd;
			int Result;

			_By = pBirthday.Year;
			_Bm = pBirthday.Month;
			_Bd = pBirthday.Day;

			_Cy = pCalcDate.Year;
			_Cm = pCalcDate.Month;
			_Cd = pCalcDate.Day;

			Result = _Cy - _By;

			//誕生月を迎えていない、もしくは
			//誕生月で誕生日を迎えていなければ、年齢から１引く
			if ((_Bm > _Cm) ||((_Bm == _Cm) && (_Bd > _Cd)))
			{
				Result = Result -1;
			}
			return Result;
		}


		//------------------------------------------------------------------------------
		//読影フラグ解析
		//[引数]
		//  pStr;
		//------------------------------------------------------------------------------
		public void ReportFlgCheck(HISRISOrderInfoAggregate order, IDbCommand command, ref string pStr)
		{
			
			string His_Rep_Fuyo;
			string His_Rep_Yo;
			string His_Rep_Sumi;
			string Ris_Rep_Fuyo;
			string Ris_Rep_Yo;
			string Ris_Rep_Sumi;
			string SikyuChkFlg = "";
			//TIniFile _ini;
			ConfigurationManager.AppSettings["Gateway"].StringToString();

			pStr = "";
			if (order.REPORT_KBN.Data != "")
			{
				//_ini = TIniFile.Create(ExtractFilePath(Application.ExeName) + "DownstreamSvr.ini");
				try
				{
					// 2020.07.28 mod start cosmo@nishihara 設定ファイルのkey名称修正
					//His_Rep_Fuyo = ConfigurationManager.AppSettings["HIS_REP_FUYO"].StringToString();
					//His_Rep_Yo = ConfigurationManager.AppSettings["HIS_REP_YO"].StringToString();
					//His_Rep_Sumi = ConfigurationManager.AppSettings["HIS_REP_SUMI"].StringToString();
					//Ris_Rep_Fuyo = ConfigurationManager.AppSettings["RIS_REP_FUYO"].StringToString();
					//Ris_Rep_Yo = ConfigurationManager.AppSettings["RIS_REP_YO"].StringToString();
					//Ris_Rep_Sumi = ConfigurationManager.AppSettings["RIS_REP_SUMI"].StringToString();
					His_Rep_Fuyo = ConfigurationManager.AppSettings["REPORTKBN_HIS_REP_FUYO"].StringToString();
					His_Rep_Yo = ConfigurationManager.AppSettings["REPORTKBN_HIS_REP_YO"].StringToString();
					His_Rep_Sumi = ConfigurationManager.AppSettings["REPORTKBN_HIS_REP_SUMI"].StringToString();
					Ris_Rep_Fuyo = ConfigurationManager.AppSettings["REPORTKBN_RIS_REP_FUYO"].StringToString();
					Ris_Rep_Yo = ConfigurationManager.AppSettings["REPORTKBN_RIS_REP_YO"].StringToString();
					Ris_Rep_Sumi = ConfigurationManager.AppSettings["REPORTKBN_RIS_REP_SUMI"].StringToString();
					// 2020.07.28 mod end cosmo@nishihara 設定ファイルのkey名称修正
				}
				finally
				{
					//_ini = null;
				}

				if (order.IRAI_KBN.TrimData == "1")
				{
					if (order.REPORT_KBN.Data == His_Rep_Yo && SikyuChkFlg == "1")
					{
						pStr = "3";
					}
					else
					{
						if (order.REPORT_KBN.Data == His_Rep_Fuyo)
						{
							pStr = Ris_Rep_Fuyo;
						}
						else if (order.REPORT_KBN.Data == His_Rep_Yo)
						{
							pStr = Ris_Rep_Yo;
						}
						else if (order.REPORT_KBN.Data == His_Rep_Sumi)
						{
							pStr = Ris_Rep_Sumi;
						}
					}
				}
				else
				{
					if (order.REPORT_KBN.Data == His_Rep_Fuyo)
					{
						pStr = Ris_Rep_Fuyo;
					}
					else if (order.REPORT_KBN.Data == His_Rep_Yo)
					{
						pStr = Ris_Rep_Yo;
					}
					else if (order.REPORT_KBN.Data == His_Rep_Sumi)
					{
						pStr = Ris_Rep_Sumi;
					}
				}
			}
		}
	}
}
