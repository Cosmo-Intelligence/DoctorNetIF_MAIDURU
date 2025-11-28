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
	public class EXTENDORDERINFOUpdaterOrderInfo : BaseUpdater
	{
		#region const
		private const string XX_KBN_RI        = "17";

		#region InsertSQL

		/// <summary>
		/// InsertSQL
		/// </summary>
		private const string INSERT_SQL =
		"MERGE INTO EXTENDORDERINFO p " +
		"USING " +
		"( " +
			"SELECT " +
				":RIS_ID RIS_ID, " +
				//"TO_DATE(:ORDER_DATE) ORDER_DATE, " +
				"TO_DATE(:ORDER_DATE, 'YYYY/MM/DD') ORDER_DATE, " +
				":UPDATEDATE UPDATEDATE, " +
				":UPDATETIME UPDATETIME, " +
				"TO_DATE(:HIS_HAKKO_DATE, 'YYYY/MM/DD HH24:MI:SS') HIS_HAKKO_DATE, " +
				":HIS_HAKKO_TERMINAL HIS_HAKKO_TERMINAL, " +
				"TO_DATE(:HIS_UPDATE_DATE, 'YYYY/MM/DD HH24:MI:SS') HIS_UPDATE_DATE, " +
				":RI_ORDER_FLG RI_ORDER_FLG, " +
				":YOTEIKAIKEI_FLG YOTEIKAIKEI_FLG, " +
				":SIKYU_FLG SIKYU_FLG, " +
				":ISITATIAI_FLG ISITATIAI_FLG, " +
				":PORTABLE_FLG PORTABLE_FLG, " +
				":KANJA_SYOKAI_FLG KANJA_SYOKAI_FLG, " +
				":SEISAN_FLG SEISAN_FLG, " +
				":ADDENDUM01 ADDENDUM01, " +
				":ADDENDUM02 ADDENDUM02, " +
				":ADDENDUM03 ADDENDUM03, " +
				":ADDENDUM04 ADDENDUM04, " +
				":ADDENDUM05 ADDENDUM05, " +
				":ADDENDUM06 ADDENDUM06, " +
				":ADDENDUM07 ADDENDUM07, " +
				":ADDENDUM08 ADDENDUM08, " +
				":ADDENDUM09 ADDENDUM09, " +
				":ADDENDUM10 ADDENDUM10, " +
				":ADDENDUM11 ADDENDUM11, " +
				":ADDENDUM12 ADDENDUM12, " +
				":DOUISHO_FLG DOUISHO_FLG, " +
				":SHEMAURL SHEMAURL, " +
				":ADDENDUM13 ADDENDUM13, " +
				":ADDENDUM14 ADDENDUM14 " +
			"FROM " +
				"DUAL " +
		") pn " +
		"ON " +
		"( p.RIS_ID = pn.RIS_ID) " +
		//"WHEN MATCHED THEN " + //-- 既存レコードの更新
		//	"UPDATE SET " +
		//		"ORDER_DATE= pn.ORDER_DATE, " +
		//		"UPDATEDATE= pn.UPDATEDATE, " +
		//		"UPDATETIME= pn.UPDATETIME, " +
		//		"HIS_HAKKO_DATE= pn.HIS_HAKKO_DATE, " +
		//		"HIS_HAKKO_TERMINAL= pn.HIS_HAKKO_TERMINAL, " +
		//		"HIS_UPDATE_DATE= pn.HIS_UPDATE_DATE, " +
		//		"RI_ORDER_FLG= pn.RI_ORDER_FLG, " +
		//		"YOTEIKAIKEI_FLG= pn.YOTEIKAIKEI_FLG, " +
		//		"SIKYU_FLG= pn.SIKYU_FLG, " +
		//		"ISITATIAI_FLG= pn.ISITATIAI_FLG, " +
		//		"PORTABLE_FLG= pn.PORTABLE_FLG, " +
		//		"KANJA_SYOKAI_FLG= pn.KANJA_SYOKAI_FLG, " +
		//		"SEISAN_FLG= pn.SEISAN_FLG, " +
		//		"ADDENDUM01= pn.ADDENDUM01, " +
		//		"ADDENDUM02= pn.ADDENDUM02, " +
		//		"ADDENDUM03= pn.ADDENDUM03, " +
		//		"ADDENDUM04= pn.ADDENDUM04, " +
		//		"ADDENDUM05= pn.ADDENDUM05, " +
		//		"ADDENDUM06= pn.ADDENDUM06, " +
		//		"ADDENDUM07= pn.ADDENDUM07, " +
		//		"ADDENDUM08= pn.ADDENDUM08, " +
		//		"ADDENDUM09= pn.ADDENDUM09, " +
		//		"ADDENDUM10= pn.ADDENDUM10, " +
		//		"ADDENDUM11= pn.ADDENDUM11, " +
		//		"ADDENDUM12= pn.ADDENDUM12, " +
		//		"DOUISHO_FLG= pn.DOUISHO_FLG, " +
		//		"SHEMAURL= pn.SHEMAURL, " +
		//		"ADDENDUM13= pn.ADDENDUM13, " +
		//		"ADDENDUM14= pn.ADDENDUM14 " +
		"WHEN NOT MATCHED THEN " + //新規レコードの作成
			"INSERT " +
			"( " +
				"RIS_ID, " +
				"ORDER_DATE, " +
				"UPDATEDATE, " +
				"UPDATETIME, " +
				"HIS_HAKKO_DATE, " +
				"HIS_HAKKO_TERMINAL, " +
				"HIS_UPDATE_DATE, " +
				"RI_ORDER_FLG, " +
				"YOTEIKAIKEI_FLG, " +
				"SIKYU_FLG, " +
				"ISITATIAI_FLG, " +
				"PORTABLE_FLG, " +
				"KANJA_SYOKAI_FLG, " +
				"SEISAN_FLG, " +
				"ADDENDUM01, " +
				"ADDENDUM02, " +
				"ADDENDUM03, " +
				"ADDENDUM04, " +
				"ADDENDUM05, " +
				"ADDENDUM06, " +
				"ADDENDUM07, " +
				"ADDENDUM08, " +
				"ADDENDUM09, " +
				"ADDENDUM10, " +
				"ADDENDUM11, " +
				"ADDENDUM12, " +
				"DOUISHO_FLG, " +
				"SHEMAURL, " +
				"ADDENDUM13, " +
				"ADDENDUM14 " +
			") " +
			"VALUES " +
			"( " +
				"pn.RIS_ID, " +
				"pn.ORDER_DATE, " +
				"pn.UPDATEDATE, " +
				"pn.UPDATETIME, " +
				"pn.HIS_HAKKO_DATE, " +
				"pn.HIS_HAKKO_TERMINAL, " +
				"pn.HIS_UPDATE_DATE, " +
				"pn.RI_ORDER_FLG, " +
				"pn.YOTEIKAIKEI_FLG, " +
				"pn.SIKYU_FLG, " +
				"pn.ISITATIAI_FLG, " +
				"pn.PORTABLE_FLG, " +
				"pn.KANJA_SYOKAI_FLG, " +
				"pn.SEISAN_FLG, " +
				"pn.ADDENDUM01, " +
				"pn.ADDENDUM02, " +
				"pn.ADDENDUM03, " +
				"pn.ADDENDUM04, " +
				"pn.ADDENDUM05, " +
				"pn.ADDENDUM06, " +
				"pn.ADDENDUM07, " +
				"pn.ADDENDUM08, " +
				"pn.ADDENDUM09, " +
				"pn.ADDENDUM10, " +
				"pn.ADDENDUM11, " +
				"pn.ADDENDUM12, " +
				"pn.DOUISHO_FLG, " +
				"pn.SHEMAURL, " +
				"pn.ADDENDUM13, " +
				"pn.ADDENDUM14 " +
			") ";

		#endregion
		#endregion

		#region param
		/// <summary>
		/// RIS_ID
		/// </summary>
		private const string PARAM_NAME_RIS_ID = "RIS_ID";

		/// <summary>
		/// ORDER_DATE
		/// </summary>
		private const string PARAM_NAME_ORDER_DATE = "ORDER_DATE";

		/// <summary>
		/// UPDATEDATE
		/// </summary>
		private const string PARAM_NAME_UPDATEDATE = "UPDATEDATE";

		/// <summary>
		/// UPDATETIME
		/// </summary>
		private const string PARAM_NAME_UPDATETIME = "UPDATETIME";

		/// <summary>
		/// HIS_HAKKO_DATE
		/// </summary>
		private const string PARAM_NAME_HIS_HAKKO_DATE = "HIS_HAKKO_DATE";

		/// <summary>
		/// HIS_HAKKO_TERMINAL
		/// </summary>
		private const string PARAM_NAME_HIS_HAKKO_TERMINAL = "HIS_HAKKO_TERMINAL";

		/// <summary>
		/// HIS_UPDATE_DATE
		/// </summary>
		private const string PARAM_NAME_HIS_UPDATE_DATE = "HIS_UPDATE_DATE";

		/// <summary>
		/// RI_ORDER_FLG
		/// </summary>
		private const string PARAM_NAME_RI_ORDER_FLG = "RI_ORDER_FLG";

		/// <summary>
		/// YOTEIKAIKEI_FLG
		/// </summary>
		private const string PARAM_NAME_YOTEIKAIKEI_FLG = "YOTEIKAIKEI_FLG";

		/// <summary>
		/// SIKYU_FLG
		/// </summary>
		private const string PARAM_NAME_SIKYU_FLG = "SIKYU_FLG";

		/// <summary>
		/// ISITATIAI_FLG
		/// </summary>
		private const string PARAM_NAME_ISITATIAI_FLG = "ISITATIAI_FLG";

		/// <summary>
		/// PORTABLE_FLG
		/// </summary>
		private const string PARAM_NAME_PORTABLE_FLG = "PORTABLE_FLG";

		/// <summary>
		/// KANJA_SYOKAI_FLG
		/// </summary>
		private const string PARAM_NAME_KANJA_SYOKAI_FLG = "KANJA_SYOKAI_FLG";

		/// <summary>
		/// SEISAN_FLG
		/// </summary>
		private const string PARAM_NAME_SEISAN_FLG = "SEISAN_FLG";

		/// <summary>
		/// DOUISHO_FLG
		/// </summary>
		private const string PARAM_NAME_DOUISHO_FLG = "DOUISHO_FLG";

		/// <summary>
		/// ADDENDUM01
		/// </summary>
		private const string PARAM_NAME_ADDENDUM01 = "ADDENDUM01";

		/// <summary>
		/// ADDENDUM02
		/// </summary>
		private const string PARAM_NAME_ADDENDUM02 = "ADDENDUM02";

		/// <summary>
		/// ADDENDUM03
		/// </summary>
		private const string PARAM_NAME_ADDENDUM03 = "ADDENDUM03";

		/// <summary>
		/// ADDENDUM04
		/// </summary>
		private const string PARAM_NAME_ADDENDUM04 = "ADDENDUM04";

		/// <summary>
		/// ADDENDUM05
		/// </summary>
		private const string PARAM_NAME_ADDENDUM05 = "ADDENDUM05";

		/// <summary>
		/// ADDENDUM06
		/// </summary>
		private const string PARAM_NAME_ADDENDUM06 = "ADDENDUM06";

		/// <summary>
		/// ADDENDUM07
		/// </summary>
		private const string PARAM_NAME_ADDENDUM07 = "ADDENDUM07";

		/// <summary>
		/// ADDENDUM08
		/// </summary>
		private const string PARAM_NAME_ADDENDUM08 = "ADDENDUM08";

		/// <summary>
		/// ADDENDUM09
		/// </summary>
		private const string PARAM_NAME_ADDENDUM09 = "ADDENDUM09";

		/// <summary>
		/// ADDENDUM10
		/// </summary>
		private const string PARAM_NAME_ADDENDUM10 = "ADDENDUM10";

		/// <summary>
		/// ADDENDUM11
		/// </summary>
		private const string PARAM_NAME_ADDENDUM11 = "ADDENDUM11";

		/// <summary>
		/// ADDENDUM12
		/// </summary>
		private const string PARAM_NAME_ADDENDUM12 = "ADDENDUM12";

		/// <summary>
		/// SHEMAURL
		/// </summary>
		private const string PARAM_NAME_SHEMAURL = "SHEMAURL";

		/// <summary>
		/// ADDENDUM13
		/// </summary>
		private const string PARAM_NAME_ADDENDUM13 = "ADDENDUM13";

		/// <summary>
		/// ADDENDUM14
		/// </summary>
		private const string PARAM_NAME_ADDENDUM14 = "ADDENDUM14";




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

		public override void SetParams(BaseMsgData data, System.Data.IDbCommand command)
		{
			command.Parameters.Clear();
			OrderInfoMsgData orderData = (OrderInfoMsgData)data;
			HISRISOrderInfoAggregate order = orderData.Request.MsgBody.OrderInfo;
			string ChkStr = "";
			string SikyuChkFlg = "";
			SetStringToCommand(PARAM_NAME_RIS_ID, orderData.RIS_ID, command);
			//SetDateTimeToCommand(PARAM_NAME_ORDER_DATE, order.HASSEI_DATE.TrimData, command);
			SetStringToCommand(PARAM_NAME_ORDER_DATE, order.HASSEI_DATE.TrimData, command);
			SetStringToCommand(PARAM_NAME_UPDATEDATE, order.IN_DATE2.TrimData, command);
			SetStringToCommand(PARAM_NAME_UPDATETIME, order.IN_TIME.TrimData, command);
			//SetDateTimeToCommand(PARAM_NAME_HIS_HAKKO_DATE, order.HASSEI_DATE.TrimData +
			//									   order.SEQ_NO.TrimData, command);
			SetStringToCommand(PARAM_NAME_HIS_HAKKO_DATE, order.HASSEI_DATE.TrimData +
												   order.SEQ_NO.TrimData, command);
			SetStringToCommand(PARAM_NAME_HIS_HAKKO_TERMINAL, order.WS_NO.TrimData, command);
			//SetDateTimeToCommand(PARAM_NAME_HIS_UPDATE_DATE, order.HASSEI_DATE.TrimData +
			//									   order.SEQ_NO.TrimData, command);
			SetStringToCommand(PARAM_NAME_HIS_UPDATE_DATE, order.HASSEI_DATE.TrimData +
												   order.SEQ_NO.TrimData, command);
			SetStringToCommand(PARAM_NAME_RI_ORDER_FLG, GetRI_ORDER_FLG(0, order), command);
			SetStringToCommand(PARAM_NAME_YOTEIKAIKEI_FLG, "1", command);

			IraiKbn_Check(order, ref ChkStr, ref SikyuChkFlg);
			SetStringToCommand(PARAM_NAME_SIKYU_FLG, ChkStr, command);

			if (GetCNT_ISITATIAI_FLG(order, 0) > 0)
			{
				SetStringToCommand(PARAM_NAME_ISITATIAI_FLG, "1", command);
			}
			else if (GetCNT_ISITATIAI_FLG(order, 0) == 0)
			{
				SetStringToCommand(PARAM_NAME_ISITATIAI_FLG, "0", command);
			}

			SetStringToCommand(PARAM_NAME_PORTABLE_FLG, GetPORTABLE_FLG(order, 0), command);
			SetStringToCommand(PARAM_NAME_KANJA_SYOKAI_FLG, "0", command);
			SetStringToCommand(PARAM_NAME_SEISAN_FLG, "0", command);

			SetStringToCommand(PARAM_NAME_ADDENDUM01, order.HASSEI_DATE.TrimData, command);
			SetStringToCommand(PARAM_NAME_ADDENDUM02, order.SEQ_NO.TrimData, command);
			SetStringToCommand(PARAM_NAME_ADDENDUM03, order.WS_NO.TrimData, command);
			SetStringToCommand(PARAM_NAME_ADDENDUM04, order.INDEX_KBN.TrimData, command);
			SetStringToCommand(PARAM_NAME_ADDENDUM05, order.XX_KBN.TrimData, command);
			SetStringToCommand(PARAM_NAME_ADDENDUM06, order.XX_SYBT.TrimData, command);
			SetStringToCommand(PARAM_NAME_ADDENDUM07, order.XX_SEQ.TrimData, command);
			SetStringToCommand(PARAM_NAME_ADDENDUM08, order.FILLER1.TrimData, command);
			SetStringToCommand(PARAM_NAME_ADDENDUM09, order.XX_SUM.TrimData, command);
			SetStringToCommand(PARAM_NAME_ADDENDUM10, order.OP_ID.TrimData, command);
			SetStringToCommand(PARAM_NAME_ADDENDUM11, order.END_DATE.TrimData, command);
			SetStringToCommand(PARAM_NAME_ADDENDUM12, order.ORDER_MODE.TrimData, command);
			SetStringToCommand(PARAM_NAME_DOUISHO_FLG, order.FILM.TrimData, command);
			SetStringToCommand(PARAM_NAME_SHEMAURL, order.CSCAN_NO.TrimData, command);

			if (order.XX_KBN.TrimData == XX_KBN_RI)
			{
				if (order.YK_SUMM.Count > 1)
				{
					SetStringToCommand(PARAM_NAME_ADDENDUM13, order.YK_SUMM[1].YK_DATE.TrimData, command);
					SetStringToCommand(PARAM_NAME_ADDENDUM14, order.YK_SUMM[1].YK_TIME.TrimData, command);
				}
			}
			else
			{
				SetStringToCommand(PARAM_NAME_ADDENDUM13, string.Empty, command);
				SetStringToCommand(PARAM_NAME_ADDENDUM14, string.Empty, command);
			}
		}


		//------------------------------------------------------------------------------
		//部位要素のインデックスを指定してRI_ORDER_FLGを取得する
		//[引数]
		//  pBUIIdx: integer; 部位インデックス
		//[戻り値]
		//  Result: string; RI_ORDER_FLG
		//------------------------------------------------------------------------------
		public string GetRI_ORDER_FLG(int pBUIIdx, HISRISOrderInfoAggregate order)
		{
			string SQL_GET_RI_ORDER_FLG = "select RI_ORDER_FLG from BUIMASTER where BUI_ID = :BUI_ID";
			DataTable _Results = new DataTable();
			string _PartID;

			//_PartID  = (order.BUI_SUMM[pBUIIdx].BUI_CD.Data);
			_PartID  = (order.BUI_SUMM[pBUIIdx].BUI_CD.Data).Replace(" ", "").Replace("　", "");

			string Result = "";

			try
			{
				using (IDbCommand command = connection.CreateCommand())
				{
					command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
					command.CommandText = SQL_GET_RI_ORDER_FLG;

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


		public void IraiKbn_Check(HISRISOrderInfoAggregate order, ref string pStr, ref string SikyuChkFlg)
		{
			pStr  = "";
			SikyuChkFlg = "";//20070219 NSK ADD
			if (order.IRAI_KBN.Data != "")
			{
				string His_Tujo;
				string His_Sikyu;
				string His_Kinkyu;
				string Ris_Tujo;
				string Ris_Sikyu;
				string Ris_Kinkyu;

				//_ini = TIniFile.Create(ExtractFilePath(Application.ExeName) + "DownstreamSvr.ini");
				try
				{
					ConfigurationManager.AppSettings["HIS_TUJO"].StringToString();
					His_Tujo = ConfigurationManager.AppSettings["HIS_TUJO"].StringToString();
					His_Sikyu = ConfigurationManager.AppSettings["HIS_SIKYU"].StringToString();
					His_Kinkyu = ConfigurationManager.AppSettings["HIS_KINKYU"].StringToString();
					Ris_Tujo = ConfigurationManager.AppSettings["RIS_TUJO"].StringToString();
					Ris_Sikyu = ConfigurationManager.AppSettings["RIS_SIKYU"].StringToString();
					Ris_Kinkyu = ConfigurationManager.AppSettings["RIS_KINKYU"].StringToString();
				}
				finally
				{
				}

				if (order.IRAI_KBN.Data == His_Tujo)
				{
					pStr = Ris_Tujo;
				}
				else if (order.IRAI_KBN.Data == His_Sikyu)
				{
					pStr = Ris_Sikyu;
					SikyuChkFlg = "1";
				}
				else if (order.IRAI_KBN.Data == His_Kinkyu)
				{
					pStr = Ris_Kinkyu;
				}
			}
		}

		//------------------------------------------------------------------------------
		//BUIMASTER.ISITATIAI_FLG='1'のレコード件数
		//[引数]
		//  pBUIIdx: integer; 部位インデックス
		//[戻り値]
		//  Result: integer; 件数
		//------------------------------------------------------------------------------
		public int GetCNT_ISITATIAI_FLG(HISRISOrderInfoAggregate order, int pBUIIdx)
		{
			string SQL_GET_CNT = "select count(ISITATIAI_FLG) from BUIMASTER where BUI_ID = :BUI_ID and ISITATIAI_FLG = '1'";
			DataTable _Results = new DataTable();
			string _PartID;

			//_PartID  = order.BUI_SUMM[pBUIIdx].BUI_CD.Data;
			_PartID  = order.BUI_SUMM[pBUIIdx].BUI_CD.Data.Replace(" ", "").Replace("　", "");

			int Result;

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


		//------------------------------------------------------------------------------
		//部位要素のインデックスを指定してPORTABLE_FLGを取得する
		//[引数]
		//  pBUIIdx: integer; 部位インデックス
		//[戻り値]
		//  Result: string; PORTABLE_FLG
		//------------------------------------------------------------------------------
		public string GetPORTABLE_FLG(HISRISOrderInfoAggregate order, int pBUIIdx)
		{
			string SQL_GET_PORTABLEFLAG = "select PORTABLEFLAG from BUIMASTER where BUI_ID = :BUI_ID";

			DataTable _Results = new DataTable();
			string _PartID;

			//_PartID = order.BUI_SUMM[pBUIIdx].BUI_CD.Data;
			_PartID = order.BUI_SUMM[pBUIIdx].BUI_CD.Data.Replace(" ", "").Replace("　", "");

			string Result = "";

			try
			{
				using (IDbCommand command = connection.CreateCommand())
				{
					command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
					command.CommandText = SQL_GET_PORTABLEFLAG;

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
	}
}
