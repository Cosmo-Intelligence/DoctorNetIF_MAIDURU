using System;
using System.Configuration;
using System.Data;
using RISBizLibrary.Updater;
using RISBizLibrary.Data;
using RISBizLibrary.Download.Data;
using RISCommonLibrary.Lib.Exceptions;
using RISCommonLibrary.Lib.Utils;
using RISODPLibrary.Lib.Utils;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.OrderInfo;

namespace RISBizLibrary.Download.Model
{
	/// <summary>
	/// メッセージからDBへ更新する
	/// </summary>
	public class OrderInfoMsgDBSetter : BaseMsgDBSetter
	{

		#region field

		#endregion

		#region property

		#endregion

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public OrderInfoMsgDBSetter()
			: base()
		{

		}

		#endregion

		#region method

		/// <summary>
		/// メッセージデータ保持クラス生成
		/// </summary>
		/// <returns></returns>
		protected override BaseMsgData CreateMsgData()
		{
			return new OrderInfoMsgData();
		}

		/// <summary>
		/// 内部処理
		/// </summary>
		/// <param name="msgData"></param>
		/// <param name="cn"></param>
		/// <returns></returns>
		protected override bool SetDataToDatabaseInner(BaseMsgData msgData, IDbConnection cnRis)
		{
			OrderInfoMsgData orderInfoMsgData = (OrderInfoMsgData)msgData;
			HISRISOrderInfoAggregate order = orderInfoMsgData.Request.MsgBody.OrderInfo;

			// RIS_IDを取得
			string risId = GetRIS_IDFromOrderMain(order, cnRis);

			if (order.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_ORDER_RIS)
			{
				if (ExistOrder(order, cnRis))
				{
					_log.Info("-----新規オーダ-----");
					_log.Info("レコードあり");
					_log.Info("ORDERNO =【" + order.ORDER_NO.TrimData + "】");
					_log.Info("RIS_ID  =【" + risId + "】");

					if (IsStartOrder(risId, cnRis))
					{
						throw new Exception("受付済み以降のオーダが既に存在します");
					}
					else
					{
						throw new Exception("未受付のオーダが既に存在します");
					}
				}

				orderInfoMsgData.RIS_ID = GetRIS_ID(orderInfoMsgData, cnRis);

				_log.Info("-----新規オーダ-----");
				_log.Info("レコードなし");
				_log.Info("ORDERNO =【" + order.ORDER_NO.TrimData + "】");
				_log.Info("RIS_ID  =【" + orderInfoMsgData.RIS_ID + "】");
			}

			if (order.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_ORDERCANCEL_RIS)
			{
				_log.Info("-----オーダ取消-----");
				_log.Info("ORDERNO =【" + order.ORDER_NO.TrimData + "】");
				_log.Info("RIS_ID  =【" + risId + "】");

				if (!ExistOrder(order, cnRis))
				{
					throw new Exception("オーダが存在しません");
				}
				if (IsStartOrder(risId, cnRis))
				{
					throw new Exception("受付済み以降のオーダが既に存在します");
				}

				orderInfoMsgData.RIS_ID = risId;
			}

			ValidateMaster(orderInfoMsgData, cnRis);
			OrderInfoUpdater updater = new OrderInfoUpdater();
			updater.InsertOrUpdate(orderInfoMsgData, cnRis);
			return true;
		}

		/// <summary>
		/// RIS_ID取得
		/// </summary>
		private string GetRIS_IDFromOrderMain(HISRISOrderInfoAggregate order, IDbConnection cn)
		{
			string retStr = string.Empty;
			const string SQL_SELECT =
			"select RIS_ID from ORDERMAINTABLE where ORDERNO = :ORDERNO ";

			const string PARAM_NAME_ORDERNO = "ORDERNO";

			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.CommandText = string.Format(SQL_SELECT);

				IDataParameter param = command.CreateParameter();
				param.SetInputString(PARAM_NAME_ORDERNO, order.ORDER_NO.TrimData);
				command.Parameters.Add(param);

				MiscUtils.WriteDbCommandLogForLog4net(command, _log);
				IDataReader reader = command.ExecuteReader();
				try
				{
					if (!reader.Read())
					{
						//throw new MsgAnomalyException(string.Format(
						//	"RIS_ID取得処理でSQLのエラーが発生しました"));
						return retStr;
					}
					MiscUtils.WriteDataReaderLogForLog4net(reader, _log);
					retStr = reader.GetStringByDBString("RIS_ID");
				}
				finally
				{
					reader.Close();
				}
			}
			return retStr;
		}

		/// <summary>
		/// OrderNoキーでオーダの存在チェックを行う
		/// </summary>
		private bool ExistOrder(HISRISOrderInfoAggregate order, IDbConnection cn)
		{
			const string SQL_SELECT =
			"SELECT ex.RIS_ID FROM ORDERMAINTABLE ORD,EXMAINTABLE EX WHERE ORD.ORDERNO = :ORDERNO AND EX.RIS_ID = ORD.RIS_ID AND EX.STATUS <> -9 ";

			const string PARAM_NAME_ORDERNO = "ORDERNO";

			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.CommandText = string.Format(SQL_SELECT);

				IDataParameter param = command.CreateParameter();
				param.SetInputString(PARAM_NAME_ORDERNO, order.ORDER_NO.TrimData);
				command.Parameters.Add(param);

				MiscUtils.WriteDbCommandLogForLog4net(command, _log);
				IDataReader reader = command.ExecuteReader();
				try
				{
					if (!reader.Read())
					{
						//throw new MsgAnomalyException(string.Format(
						//	"RIS_ID取得処理でSQLのエラーが発生しました"));
						return false;
					}
					MiscUtils.WriteDataReaderLogForLog4net(reader, _log);
				}
				finally
				{
					reader.Close();
				}
			}
			return true;
		}

		/// <summary>
		/// オーダが処理されているか
		/// 未受付ならFalse、受付済み以降ならTrueを返す
		/// </summary>
		private bool IsStartOrder(string risId, IDbConnection cn)
		{
			bool ret = false;
			;
			const string SQL_SELECT =
			"SELECT STATUS FROM EXMAINTABLE WHERE RIS_ID = :RIS_ID ";

			const string PARAM_NAME_RIS_ID = "RIS_ID";

			DataTable _Results = new DataTable();
			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.CommandText = string.Format(SQL_SELECT);

				IDataParameter param = command.CreateParameter();
				param.SetInputString(PARAM_NAME_RIS_ID, risId);
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
					}
					//MiscUtils.WriteDataReaderLogForLog4net(reader, _log);
				}
				finally
				{
					reader.Close();
				}
			}

			for (int _Idx = 0; _Idx < _Results.Rows.Count; _Idx++)
			{
				if (_Results.Rows[_Idx]["STATUS"].ToString() == "0")          //未受付
				{
					ret = false;
				}
				else if (_Results.Rows[_Idx]["STATUS"].ToString() == "1")     //遅刻
				{
					ret = false;
				}
				else if (_Results.Rows[_Idx]["STATUS"].ToString() == "2")      //呼出
				{
					ret = false;
				}
				else
				{
					ret = true;
				}
			}

			return ret;
		}

		/// <summary>
		/// RIS_ID取得
		/// </summary>
		/// <returns></returns>
		/// <remarks>RIS_IDがすでに存在する場合はそれを返し、無かった場合は新規に発番する</remarks>
		private string GetRIS_ID(OrderInfoMsgData msgData, IDbConnection cn)
		{
			const string SQL_SELECT =
			"select RISIDSEQUENCE.Nextval AS RISIDSEQUENCE from dual ";

			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.CommandText = string.Format(SQL_SELECT);

				//IDataParameter param = command.CreateParameter();
				//param.SetInputString(PARAM_NAME, msgData.);
				//command.Parameters.Add(param);

				_log.Debug("RIS_ID取得します");
				MiscUtils.WriteDbCommandLogForLog4net(command, _log);
				IDataReader reader = command.ExecuteReader();
				try
				{
					if (!reader.Read())
					{
						throw new MsgAnomalyException(string.Format(
							"RIS_ID取得処理でSQLのエラーが発生しました"));
					}
					MiscUtils.WriteDataReaderLogForLog4net(reader, _log);
					string r = reader.GetStringByDBInt32("RISIDSEQUENCE");

					DateTime _now = DateTime.Now;
					string _nowAfter = _now.ToString("yyyyMMdd");
					string _RISID = _nowAfter + r;
					_log.DebugFormat("RIS_ID={0}", _RISID);

					return _RISID;
				}
				finally
				{
					reader.Close();
				}
			}
		}

		/// <summary>
		/// マスタチェック
		/// </summary>
		/// <param name="omsg"></param>
		private void ValidateMaster(OrderInfoMsgData msgData, IDbConnection cn)
		{
			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());

				#region 患者情報部
				//ValidatePatient(msgData.Request.MsgBody.PatientAttribute, command);
				#endregion
			}
		}

		#endregion
	}
}
