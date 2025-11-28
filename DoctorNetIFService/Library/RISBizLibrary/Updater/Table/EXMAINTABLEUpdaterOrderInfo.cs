using RISBizLibrary.Data;
using RISBizLibrary.Download.Data;
using RISBizLibrary.Updater.Table;
using RISCommonLibrary.Lib.Msg.Common.OrderInfo;
using RISCommonLibrary.Lib.Utils;
using RISODPLibrary.Lib.Utils;
using System.Configuration;
using System.Data;

namespace RISBizLibrary.Updater.Table
{
	public class EXMAINTABLEUpdaterOrderInfo : BaseUpdater
	{
		#region const
		#region InsertSQL

		///// <summary>
		///// InsertSQL
		///// </summary>
		//private const string INSERT_SQL =
		//"MERGE INTO EXMAINTABLE p " +
		//"USING " +
		//"( " +
		//	"SELECT " +
		//		":RIS_ID RIS_ID, " +
		//		":KENSATYPE_ID KENSATYPE_ID, " +
		//		":KANJA_ID KANJA_ID, " +
		//		":STATUS STATUS " +
		//	"FROM " +
		//		"DUAL " +
		//") pn " +
		//"ON " +
		//"( p.RIS_ID = pn.RIS_ID) " +
		//"WHEN MATCHED THEN " + //-- 既存レコードの更新
		//	"UPDATE SET " +
		//		"STATUS = '-9' " +
		//"WHEN NOT MATCHED THEN " + //新規レコードの作成
		//	"INSERT " +
		//	"( " +
		//		"RIS_ID, " +
		//		"KENSATYPE_ID, " +
		//		"KANJA_ID, " +
		//		"STATUS " +
		//	") " +
		//	"VALUES " +
		//	"( " +
		//		"pn.RIS_ID, " +
		//		"pn.KENSATYPE_ID, " +
		//		"pn.KANJA_ID, " +
		//		"pn.STATUS " +
		//	") ";

		// 2020.07.21 add start cosmo@nishihara 取得したEXMAINTABLEの連絡メモ、連絡メモ2、指示医師ID、指示医師名、指示医師コメントをつめる処理追加
		/// <summary>
		/// InsertSQL
		/// </summary>
		private const string INSERT_SQL =
		"MERGE INTO EXMAINTABLE p " +
		"USING " +
		"( " +
			"SELECT " +
				":RIS_ID RIS_ID, " +
				":KENSATYPE_ID KENSATYPE_ID, " +
				":KANJA_ID KANJA_ID, " +
				":STATUS STATUS, " +
				":RENRAKU_MEMO RENRAKU_MEMO, " +
				":RENRAKU_MEMO2 RENRAKU_MEMO2, " +
				":SIJI_ISI_ID SIJI_ISI_ID, " +
				":SIJI_ISI_NAME SIJI_ISI_NAME, " +
				":SIJI_ISI_COMMENT SIJI_ISI_COMMENT " +
			"FROM " +
				"DUAL " +
		") pn " +
		"ON " +
		"( p.RIS_ID = pn.RIS_ID) " +
		"WHEN MATCHED THEN " + //-- 既存レコードの更新
			"UPDATE SET " +
				"STATUS = '-9' " +
		"WHEN NOT MATCHED THEN " + //新規レコードの作成
			"INSERT " +
			"( " +
				"RIS_ID, " +
				"KENSATYPE_ID, " +
				"KANJA_ID, " +
				"STATUS, " +
				"RENRAKU_MEMO, " +
				"RENRAKU_MEMO2, " +
				"SIJI_ISI_ID, " +
				"SIJI_ISI_NAME, " +
				"SIJI_ISI_COMMENT " +
			") " +
			"VALUES " +
			"( " +
				"pn.RIS_ID, " +
				"pn.KENSATYPE_ID, " +
				"pn.KANJA_ID, " +
				"pn.STATUS, " +
				"pn.RENRAKU_MEMO, " +
				"pn.RENRAKU_MEMO2, " +
				"pn.SIJI_ISI_ID, " +
				"pn.SIJI_ISI_NAME, " +
				"pn.SIJI_ISI_COMMENT " +
			") ";
		// 2020.07.21 add end cosmo@nishihara 取得したEXMAINTABLEの連絡メモ、連絡メモ2、指示医師ID、指示医師名、指示医師コメントをつめる処理追加

		#endregion
		#endregion

		#region param

		/// <summary>
		/// RIS_ID
		/// </summary>
		private const string PARAM_NAME_RIS_ID = "RIS_ID";

		/// <summary>
		/// KENSATYPE_ID
		/// </summary>
		private const string PARAM_NAME_KENSATYPE_ID = "KENSATYPE_ID";

		/// <summary>
		/// KANJA_ID
		/// </summary>
		private const string PARAM_NAME_KANJA_ID = "KANJA_ID";

		/// <summary>
		/// STATUS
		/// </summary>
		private const string PARAM_NAME_STATUS = "STATUS";

		// 2020.07.21 add start cosmo@nishihara 取得したEXMAINTABLEの連絡メモ、連絡メモ2、指示医師ID、指示医師名、指示医師コメントをつめる処理追加
		/// <summary>
		/// PARAM_RENRAKU_MEMO
		/// </summary>
		private const string PARAM_RENRAKU_MEMO = "RENRAKU_MEMO";

		/// <summary>
		/// PARAM_RENRAKU_MEMO2
		/// </summary>
		private const string PARAM_RENRAKU_MEMO2 = "RENRAKU_MEMO2";

		/// <summary>
		/// SIJI_ISI_ID
		/// </summary>
		private const string PARAM_SIJI_ISI_ID = "SIJI_ISI_ID";

		/// <summary>
		/// SIJI_ISI_NAME
		/// </summary>
		private const string PARAM_SIJI_ISI_NAME = "SIJI_ISI_NAME";

		/// <summary>
		/// SIJI_ISI_COMMENT
		/// </summary>
		private const string PARAM_SIJI_ISI_COMMENT = "SIJI_ISI_COMMENT";

		/// <summary>
		/// ORDERNO
		/// </summary>
		private const string PARAM_NAME_ORDERNO = "ORDERNO";
		#endregion
		// 2020.07.21 add end cosmo@nishihara 取得したEXMAINTABLEの連絡メモ、連絡メモ2、指示医師ID、指示医師名、指示医師コメントをつめる処理追加

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
			DataRow exmain = order.SELECT_EXMAIN;

			SetStringToCommand(PARAM_NAME_RIS_ID, orderData.RIS_ID, command);
			SetStringToCommand(PARAM_NAME_KENSATYPE_ID, order.KNS_SYBT1.TrimData, command);
			SetStringToCommand(PARAM_NAME_KANJA_ID, order.PT_ID2.TrimData, command);
			SetStringToCommand(PARAM_NAME_STATUS, "0", command);

			// 2020.07.21 add start cosmo@nishihara 取得したEXMAINTABLEの連絡メモ、連絡メモ2、指示医師ID、指示医師名、指示医師コメントをつめる処理追加
			if (exmain != null)
			{
				SetStringToCommand(PARAM_RENRAKU_MEMO, exmain["RENRAKU_MEMO"].ToString(), command);
				SetStringToCommand(PARAM_RENRAKU_MEMO2, exmain["RENRAKU_MEMO2"].ToString(), command);
				SetStringToCommand(PARAM_SIJI_ISI_ID, exmain["SIJI_ISI_ID"].ToString(), command);
				SetStringToCommand(PARAM_SIJI_ISI_NAME, exmain["SIJI_ISI_NAME"].ToString(), command);
				SetStringToCommand(PARAM_SIJI_ISI_COMMENT, exmain["SIJI_ISI_COMMENT"].ToString(), command);
			}
			else
			{
				SetStringToCommand(PARAM_RENRAKU_MEMO, null, command);
				SetStringToCommand(PARAM_RENRAKU_MEMO2, null, command);
				SetStringToCommand(PARAM_SIJI_ISI_ID, null, command);
				SetStringToCommand(PARAM_SIJI_ISI_NAME, null, command);
				SetStringToCommand(PARAM_SIJI_ISI_COMMENT, null, command);

			}
			// 2020.07.21 add end cosmo@nishihara 取得したEXMAINTABLEの連絡メモ、連絡メモ2、指示医師ID、指示医師名、指示医師コメントをつめる処理追加
		}

		// 2020.07.21 add start cosmo@nishihara EXMAINTABLEの連絡メモ、連絡メモ2、指示医師ID、指示医師名、指示医師コメント取得処理
		/// <summary>
		/// EXMAINTABLEの連絡メモ、連絡メモ2、指示医師ID、指示医師名、指示医師コメントの値取得
		/// </summary>
		public DataRow GetExMainData(HISRISOrderInfoAggregate order, IDbCommand command)
		{
			DataTable _Results = new DataTable();
			const string SQL_SELECT =
			"select em.RENRAKU_MEMO,em.RENRAKU_MEMO2,em.SIJI_ISI_ID,em.SIJI_ISI_NAME,em.SIJI_ISI_COMMENT" +
				" from EXMAINTABLE em, ORDERMAINTABLE om where em.RIS_ID = om.RIS_ID AND om.ORDERNO = :ORDERNO " +
					" AND em.STATUS = -9";

				command.Parameters.Clear();
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.CommandText = string.Format(SQL_SELECT);

				IDataParameter param = command.CreateParameter();
				param.SetInputString(PARAM_NAME_ORDERNO, order.ORDER_NO.TrimData);
				command.Parameters.Add(param);

				MiscUtils.WriteDbCommandLogForLog4net(command, _log);
				IDataReader reader = command.ExecuteReader();
				try
				{
					_Results.Load(reader);
					if (_Results.Rows.Count == 0)
					{
						//throw new MsgAnomalyException(string.Format(
						//	"RIS_ID取得処理でSQLのエラーが発生しました"));
						return null;
					}
					MiscUtils.WriteDataReaderLogForLog4net(reader, _log);
				}
				finally
				{
					reader.Close();
				}
			return _Results.Rows[0];
		}
		// 2020.07.21 add end cosmo@nishihara 連絡メモ、連絡メモ2、指示医師ID、指示医師名、指示医師コメント取得処理
	}
}
