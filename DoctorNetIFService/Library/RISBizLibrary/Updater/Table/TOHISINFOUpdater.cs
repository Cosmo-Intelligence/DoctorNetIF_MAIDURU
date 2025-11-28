using System;
using System.Configuration;
using System.Data;
using RISBizLibrary.Data;
using RISBizLibrary.Updater.Table.TOHISINFO;
using RISCommonLibrary.Lib.Utils;

namespace RISBizLibrary.Updater.Table
{
	public abstract class TOHISINFOUpdater : BaseUpdater
	{

		#region const

		#region InsertSQL

		/// <summary>
		/// InsertSQL
		/// </summary>
		private const string INSERT_SQL =
		"INSERT INTO TOHISINFO " +
		"( " +
			"REQUESTID, " +
			"REQUESTDATE, " +
			"REQUESTUSER, " +
			"REQUESTTERMINALID, " +
			"REQUESTTYPE, " +
			"MESSAGEID1, " +
			"TRANSFERSTATUS " +
		") " +
		"VALUES " +
		"( " +
			"FROMRISSEQUENCE.NEXTVAL, " +
			"SYSDATE, " +
			":REQUESTUSER, " +
			":REQUESTTERMINALID, " +
			":REQUESTTYPE, " +
			":MESSAGEID1, " +
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
			// 設定ファイルから対象処理種別を取得
			string RequestType = ConfigurationManager.AppSettings["RequestType"];

			command.Parameters.Clear();
			#region パラメータ

			TOHISINFOState state = GetState(data);

			SetStringToCommand(PARAM_NAME_REQUESTTYPE, RequestType, command);
			SetStringToCommand(PARAM_NAME_REQUESTTERMINALID, state.GetREQUESTTERMINALID(), command);
			SetStringToCommand(PARAM_NAME_REQUESTUSER, state.GetREQUESTUSER(), command);
			SetStringToCommand(PARAM_NAME_MESSAGEID1, state.GetMESSAGEPATIENTID(), command);
			#endregion
		}

		#endregion

		/// <summary>
		/// 状態クラスの取得
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		protected abstract TOHISINFOState GetState(BaseMsgData data);

	}
}
