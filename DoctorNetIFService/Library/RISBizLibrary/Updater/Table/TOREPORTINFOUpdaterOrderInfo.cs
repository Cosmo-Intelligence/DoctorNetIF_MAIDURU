using System;
using System.Configuration;
using System.Data;
using RISBizLibrary.Data;
using RISBizLibrary.Download.Data;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.OrderInfo;
using RISCommonLibrary.Lib.Utils;

namespace RISBizLibrary.Updater.Table
{
	internal class TOREPORTINFOUpdaterOrderInfo : BaseUpdater
	{
		#region const

		#region InsertSQL

		/// <summary>
		/// InsertSQL
		/// </summary>
		private const string INSERT_SQL =
		"INSERT INTO toreportinfo " +
		"( " +
			"requestid, " +
			"requestdate, " +
			"ris_id, " +
			"requestuser, " +
			"requestterminalid, " +
			"requesttype, " +
			"messageid1, " +
			"messageid2, " +
			"transferstatus " +
		") " +
		"VALUES " +
		"( " +
			"FROMRISSEQUENCE.NEXTVAL, " +
			"SYSDATE, " +
			":ris_id, " +
			":requestuser, " +
			":requestterminalid, " +
			":requesttype, " +
			":messageid1, " +
			":messageid2, " +
			":transferstatus " +
		") ";
		#endregion

		#region param
		/// <summary>
		/// ris_id
		/// </summary>
		private const string PARAM_NAME_RIS_ID = "ris_id";

		/// <summary>
		/// requestuser
		/// </summary>
		private const string PARAM_NAME_REQUESTUSER = "requestuser";

		/// <summary>
		/// requestterminalid
		/// </summary>
		private const string PARAM_NAME_REQUESTTERMINALID = "requestterminalid";

		/// <summary>
		/// requesttype
		/// </summary>
		private const string PARAM_NAME_REQUESTTYPE = "requesttype";

		/// <summary>
		/// messageid1
		/// </summary>
		private const string PARAM_NAME_MESSAGEID1 = "messageid1";

		/// <summary>
		/// messageid2
		/// </summary>
		private const string PARAM_NAME_MESSAGEID2 = "messageid2";

		/// <summary>
		/// transferstatus
		/// </summary>
		private const string PARAM_NAME_TRANSFERSTATUS = "transferstatus";

		#endregion

		#endregion

		#region ITableUpdater メンバ

		/// <summary>
		/// InsertSQL
		/// </summary>
		public override string TargetSQL
		{
			get
			{
				return INSERT_SQL;
			}
		}

		/// <summary>
		/// パラメータ設定
		/// </summary>
		/// <param name="order"></param>
		/// <param name="command"></param>
		public override void SetParams(BaseMsgData data, System.Data.IDbCommand command)
		{
			command.Parameters.Clear();
			#region パラメータ

			OrderInfoMsgData orderData = (OrderInfoMsgData)data;
			HISRISOrderInfoAggregate order = orderData.Request.MsgBody.OrderInfo;

			SetStringToCommand(PARAM_NAME_RIS_ID, orderData.RIS_ID, command); //RIS識別ID
			SetStringToCommand(PARAM_NAME_REQUESTUSER, GetREQUESTUSER(), command);
			SetStringToCommand(PARAM_NAME_REQUESTTERMINALID, GetREQUESTTERMINALID(), command);
			SetStringToCommand(PARAM_NAME_REQUESTTYPE, GetREQUESTTYPE(orderData), command); //処理タイプ識別子（GGNN）
			SetStringToCommand(PARAM_NAME_MESSAGEID1, order.ORDER_NO.TrimData, command); //OIXX、ACｘｘ：オーダ番号 PIｘｘ：患者ID
			SetStringToCommand(PARAM_NAME_MESSAGEID2, order.PT_ID1.TrimData, command); //OIXX、ACｘｘ：患者ID PIXX：患者ｶﾅ名
			SetStringToCommand(PARAM_NAME_TRANSFERSTATUS, RQRISDBConst.TOREPORTINFO_TRANSFERSTATUS_UNSENT, command); //"送信ｽﾃｰﾀｽ 00：未送信 01：送信済　02：送信対象外"

			#endregion
		}

		/// <summary>
		/// 処理タイプ識別子（GGNN）
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private string GetREQUESTTYPE(OrderInfoMsgData data)
		{
			HISRISOrderInfoAggregate order = data.Request.MsgBody.OrderInfo;
			if (order.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_ORDER_RIS)
			{
				if (order.SYORI_KBN.TrimData == "1")
				{
					return RQRISDBConst.FROMHISINFO_MESSAGETYPE_ORDER;
				}
				else if (order.SYORI_KBN.TrimData == "2")
				{
					return RQRISDBConst.FROMHISINFO_MESSAGETYPE_ORDER_CHANGE;
				}
			}
			if (order.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_ORDERCANCEL_RIS)
			{
				return RQRISDBConst.FROMHISINFO_MESSAGETYPE_ORDER_CANCEL;
			}

			throw new MsgAnomalyException(string.Format(
				"想定していない電文種別を受信しました。電文種別={0}",
					order.DENBUN_SYBT.TrimData));
		}

		private string GetDeleteMESSAGETYPE()
		{
			string[] value = new string[]
				{
					"'" + RQRISDBConst.FROMHISINFO_MESSAGETYPE_ORDER + "'",
					"'" + RQRISDBConst.FROMHISINFO_MESSAGETYPE_ORDER_CHANGE + "'",
					"'" + RQRISDBConst.FROMHISINFO_MESSAGETYPE_ORDER_CANCEL + "'"
				};
			return string.Join(",", value);
		}

		private string GetREQUESTUSER()
		{
			return "RIS_Down";
		}

		private string GetREQUESTTERMINALID()
		{
			return "RISSERVER";
		}

		#endregion

		#region delete

		/// <summary>
		/// 削除実行
		/// </summary>
		public void Delete(BaseMsgData data, IDbCommand command)
		{
			string DELETE_SQL =
				"DELETE FROM TOREPORTINFO " +
				"WHERE " +
					"REQUESTDATE < (sysdate - :keepday) " +
				"AND " +
					"REQUESTTYPE in (" + GetDeleteMESSAGETYPE() +") " +
				" ";

			const string param_keepday = "keepday";

			command.CommandText = DELETE_SQL;

			command.Parameters.Clear();
			IDataParameter param = command.CreateParameter();
			param.SetInputInt32(param_keepday, ConfigurationManager.AppSettings["KeepDate"].StringToInt32());
			command.Parameters.Add(param);

			MiscUtils.WriteDbCommandLogForLog4net(command, _log);
			_log.DebugFormat("Delete実行します");
			int count = Convert.ToInt32(command.ExecuteNonQuery());
			_log.DebugFormat("対象{0}件", count);
		}

		#endregion
	}
}
