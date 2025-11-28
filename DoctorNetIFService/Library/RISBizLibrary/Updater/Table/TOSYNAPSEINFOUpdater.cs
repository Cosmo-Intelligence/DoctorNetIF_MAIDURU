using System;
using System.Configuration;
using System.Data;
using RISBizLibrary.Data;
using RISBizLibrary.Updater.Table.TOSYNAPSEINFO;
using RISCommonLibrary.Lib.Utils;

namespace RISBizLibrary.Updater.Table
{
	public abstract class TOSYNAPSEINFOUpdater : BaseUpdater
	{

		#region const

		#region InsertSQL

		/// <summary>
		/// InsertSQL
		/// </summary>
		private const string INSERT_SQL =
		"INSERT INTO TOSYNAPSEINFO " +
		"( " +
			"REQUESTID, " +
			"REQUESTDATE, " +
			"REQUESTTYPE, " +
			"REQUESTUSER, " +
			"REQUESTTERMINALID, " +
			"MESSAGEORDERID, " +
			"MESSAGEPATIENTID, " +
			"TRANSFERSTATUS " +
		") " +
		"VALUES " +
		"( " +
			//"TOSYNAPSE_SEQ.NEXTVAL, " +
			"TOSYNAPSESEQUENCE.NEXTVAL, " +
			"SYSDATE, " +
			":REQUESTTYPE, " +
			":REQUESTUSER, " +
			":REQUESTTERMINALID, " +
			":MESSAGEORDERID, " +
			":MESSAGEPATIENTID, " +
			"'00' " +
		") ";
		#endregion

		#region param
		/// <summary>
		/// REQUESTID
		/// </summary>
		private const string PARAM_NAME_REQUESTID = "REQUESTID";

		/// <summary>
		/// REQUESTDATE
		/// </summary>
		private const string PARAM_NAME_REQUESTDATE = "REQUESTDATE";

		/// <summary>
		/// REQUESTTYPE
		/// </summary>
		private const string PARAM_NAME_REQUESTTYPE = "REQUESTTYPE";

		/// <summary>
		/// REQUESTUSER
		/// </summary>
		private const string PARAM_NAME_REQUESTUSER = "REQUESTUSER";

		/// <summary>
		/// REQUESTTERMINALID
		/// </summary>
		private const string PARAM_NAME_REQUESTTERMINALID = "REQUESTTERMINALID";

		/// <summary>
		/// MESSAGEORDERID
		/// </summary>
		private const string PARAM_NAME_MESSAGEORDERID = "MESSAGEORDERID";

		/// <summary>
		/// MESSAGEPATIENTID
		/// </summary>
		private const string PARAM_NAME_MESSAGEPATIENTID = "MESSAGEPATIENTID";

		/// <summary>
		/// TRANSFERSTATUS
		/// </summary>
		private const string PARAM_NAME_TRANSFERSTATUS = "TRANSFERSTATUS";

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

			TOSYNAPSEINFOState state = GetState(data);

			SetStringToCommand(PARAM_NAME_REQUESTTYPE, state.GetMESSAGETYPE(), command);
			SetStringToCommand(PARAM_NAME_REQUESTUSER, state.GetREQUESTUSER(), command);
			SetStringToCommand(PARAM_NAME_REQUESTTERMINALID, state.GetREQUESTTERMINALID(), command);
			SetStringToCommand(PARAM_NAME_MESSAGEORDERID, state.GetMESSAGEORDERID(), command);
			SetStringToCommand(PARAM_NAME_MESSAGEPATIENTID, state.GetMESSAGEPATIENTID(), command);
			#endregion
		}

		#endregion

		#region delete

		/// <summary>
		/// 削除実行
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="ris_id"></param>
		/// <param name="command"></param>
		public void Delete(BaseMsgData data, IDbCommand command)
		{
			TOSYNAPSEINFOState state = GetState(data);

			string DELETE_SQL =
				"DELETE FROM TOSYNAPSEINFO " +
				"WHERE " +
					"REQUESTDATE < (sysdate - :keepday) " +
				"AND " +
					"REQUESTTYPE in (" + state.GetDeleteMESSAGETYPE() + ") " +
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

		/// <summary>
		/// 状態クラスの取得
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		protected abstract TOSYNAPSEINFOState GetState(BaseMsgData data);

	}
}
