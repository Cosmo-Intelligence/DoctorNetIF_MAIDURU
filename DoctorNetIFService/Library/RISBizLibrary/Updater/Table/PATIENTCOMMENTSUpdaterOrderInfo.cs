using RISBizLibrary.Data;
using RISBizLibrary.Download.Data;
using RISCommonLibrary.Lib.Msg.Common.OrderInfo;

namespace RISBizLibrary.Updater.Table
{
	public class PATIENTCOMMENTSUpdaterOrderInfo : BaseUpdater
	{
		#region const

		#region InsertSQL

		/// <summary>
		/// InsertSQL
		/// </summary>
		private const string INSERT_SQL =
		"MERGE INTO PATIENTCOMMENTS p " +
		"USING " +
		"( " +
			"SELECT " +
				":KANJA_ID KANJA_ID, " +
				":KENSATYPE_ID KENSATYPE_ID " +
			"FROM " +
				"DUAL " +
		") pn " +
		"ON " +
		"( p.KANJA_ID = pn.KANJA_ID and p.KENSATYPE_ID = pn.KENSATYPE_ID ) " +
		//"WHEN MATCHED THEN " + //-- 既存レコードの更新
		//	"UPDATE SET " +
		"WHEN NOT MATCHED THEN " + //新規レコードの作成
			"INSERT " +
			"( " +
				"KANJA_ID, " +
				"KENSATYPE_ID " +
			") " +
			"VALUES " +
			"( " +
				"pn.KANJA_ID, " +
				"pn.KENSATYPE_ID " +
			") " +
			" ";

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
		private const string PARAM_NAME_KENSATYPE_ID = "KENSATYPE_ID";

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

			SetStringToCommand(PARAM_NAME_KANJA_ID, order.PT_ID1.TrimData, command);
			SetStringToCommand(PARAM_NAME_KENSATYPE_ID, "COMMON", command);
		}
	}
}
