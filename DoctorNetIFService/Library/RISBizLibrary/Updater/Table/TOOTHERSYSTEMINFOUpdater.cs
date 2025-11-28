using System;
using System.Configuration;
using System.Data;
using RISBizLibrary.Data;
using RISBizLibrary.Download.Data;
using RISBizLibrary.Updater.Table.TOOTHERSYSTEMINFO;
using RISCommonLibrary.Lib.Msg.Common.OrderInfo;
using RISCommonLibrary.Lib.Utils;

namespace RISBizLibrary.Updater.Table
{
	public abstract class TOOTHERSYSTEMINFOUpdater : BaseUpdater
	{

		#region const

		#region InsertSQL

		/// <summary>
		/// InsertSQL
		/// </summary>
		private const string INSERT_SQL =
		"INSERT INTO TOOTHERSYSTEMINFO " +
		"( " +
			"REQUESTID, " +
			"SYSTEMNO, " +
			"REQUESTDATE, " +
			"RIS_ID, " +
			"REQUESTUSER, " +
			"REQUESTTERMINALID, " +
			"REQUESTTYPE, " +
			"MESSAGEID1, " +
			"MESSAGEID2 " +
		") " +
		"VALUES " +
		"( " +
			"FROMRISSEQUENCE.NEXTVAL, " +
			"1, " +
			"SYSDATE, " +
			":RIS_ID, " +
			":REQUESTUSER, " +
			":REQUESTTERMINALID, " +
			":REQUESTTYPE, " +
			":MESSAGEID1, " +
			":MESSAGEID2 " +
		") ";
		#endregion

		#region param
		/// <summary>
		/// RIS_ID
		/// </summary>
		private const string PARAM_NAME_RIS_ID = "RIS_ID";

		/// <summary>
		/// REQUESTUSER
		/// </summary>
		private const string PARAM_NAME_REQUESTUSER = "REQUESTUSER";

		/// <summary>
		/// REQUESTTERMINALID
		/// </summary>
		private const string PARAM_NAME_REQUESTTERMINALID = "REQUESTTERMINALID";

		/// <summary>
		/// REQUESTTYPE
		/// </summary>
		private const string PARAM_NAME_REQUESTTYPE = "REQUESTTYPE";

		/// <summary>
		/// MESSAGEID1
		/// </summary>
		private const string PARAM_NAME_MESSAGEID1 = "MESSAGEID1";

		/// <summary>
		/// MESSAGEID2
		/// </summary>
		private const string PARAM_NAME_MESSAGEID2 = "MESSAGEID2";


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

			TOOTHERSYSTEMINFOState state = GetState(data);

			SetStringToCommand(PARAM_NAME_RIS_ID, state.GetRIS_ID(), command); //RIS識別ID
			SetStringToCommand(PARAM_NAME_REQUESTUSER, state.GetREQUESTUSER(), command);
			SetStringToCommand(PARAM_NAME_REQUESTTERMINALID, state.GetREQUESTTERMINALID(), command);
			SetStringToCommand(PARAM_NAME_REQUESTTYPE, state.GetMESSAGETYPE(), command);
			SetStringToCommand(PARAM_NAME_MESSAGEID1, state.GetMESSAGEID1(), command); //OIXX、ACｘｘ：オーダ番号 PIｘｘ：患者ID
			SetStringToCommand(PARAM_NAME_MESSAGEID2, state.GetMESSAGEID2(), command); //OIXX、ACｘｘ：患者ID PIXX：患者ｶﾅ名
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
			TOOTHERSYSTEMINFOState state = GetState(data);

			string DELETE_SQL =
				"DELETE FROM TOOTHERSYSTEMINFO " +
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
		protected abstract TOOTHERSYSTEMINFOState GetState(BaseMsgData data);

	}
}
