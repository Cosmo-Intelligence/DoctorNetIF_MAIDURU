using System;
using System.Configuration;
using System.Data;
using RISBizLibrary.Download.Data;
using RISBizLibrary.Updater.Table;
using RISCommonLibrary.Lib.Msg;
using RISCommonLibrary.Lib.Msg.Common.OrderInfo;
using RISCommonLibrary.Lib.Utils;
using RISODPLibrary.Lib.Utils;

namespace RISBizLibrary.Updater
{
	/// <summary>
	/// 患者系のみ更新する
	/// </summary>
	public class OrderInfoUpdater
	{
		#region field

		/// <summary>
		/// log4netインスタンス
		/// </summary>
		private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#endregion

		#region method

		/// <summary>
		/// 新規か更新
		/// </summary>
		/// <param name="data"></param>
		/// <param name="cn"></param>
		public void InsertOrUpdate(OrderInfoMsgData data, IDbConnection cnRis)
		{
			_log.Debug("InsertOrUpdate開始します");
			IDbTransaction tr = cnRis.BeginTransaction();
			_log.Debug("BeginTransactionしました");
			try
			{
				InsertOrUpdateWithTran(data, cnRis, tr);
				tr.Commit();
				_log.Debug("Commitしました");
			}
			catch (Exception)
			{
				_log.DebugFormat("InsertOrUpdate処理でエラーが発生しました。");
				tr.Rollback();
				_log.Debug("Rollbackしました");
				throw;
			}
			_log.Debug("InsertOrUpdate終了しました");
		}

		#region insert

		/// <summary>
		/// InsertOrUpdateWithTran
		/// </summary>
		/// <param name="data"></param>
		/// <param name="cn"></param>
		/// <param name="tr"></param>
		private void InsertOrUpdateWithTran(OrderInfoMsgData data, IDbConnection cn, IDbTransaction tr)
		{
			HISRISOrderInfoAggregate order = data.Request.MsgBody.OrderInfo;
			string que_setting = null;
			que_setting = ConfigurationManager.AppSettings["QUE_SETTING"].StringToString();

			// 2020.08.14 add start cosmo@taira
			string tohisinfo_que_setting = null;
			tohisinfo_que_setting = ConfigurationManager.AppSettings["TOHISINFO_QUE_SETTING"].StringToString();
			// 2020.08.14 add end   cosmo@taira

			_log.Debug("InsertOrUpdateWithTran開始します");
			_log.Debug("放射線ｵｰﾀﾞ更新処理を行います");
			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.Transaction = tr;

				if (order.DENBUN_SYBT.TrimData == MsgConst.DENBUN_SYBT_ORDER_RIS)
				{
					_log.Debug("ORDERMAINTABLE更新処理を行います");
					ORDERMAINTABLEUpdaterOrderInfo orderMainTableUpdater = new ORDERMAINTABLEUpdaterOrderInfo();
					orderMainTableUpdater.SetConnection(cn);
					orderMainTableUpdater.Execute(data, command);

					_log.Debug("EXTENDORDERINFO更新処理を行います");
					EXTENDORDERINFOUpdaterOrderInfo extendOrderInfoUpdater = new EXTENDORDERINFOUpdaterOrderInfo();
					extendOrderInfoUpdater.SetConnection(cn);
					extendOrderInfoUpdater.Execute(data, command);					

					_log.Debug("ORDERINDICATETABLE更新処理を行います");
					ORDERINDICATETABLEUpdaterOrderInfo orderIndicateTableUpdater = new ORDERINDICATETABLEUpdaterOrderInfo();
					orderIndicateTableUpdater.SetConnection(cn);
					orderIndicateTableUpdater.Execute(data, command);

					_log.Debug("ORDERBUITABLE更新処理を行います");
					ORDERBUITABLEUpdaterOrderInfo orderBuiTableUpdater = new ORDERBUITABLEUpdaterOrderInfo();
					orderBuiTableUpdater.SetConnection(cn);
					orderBuiTableUpdater.Execute(data, command);

					_log.Debug("PATIENTINFO更新処理を行います");
					PATIENTINFOUpdaterOrderInfo patientInfoUpdater = new PATIENTINFOUpdaterOrderInfo();
					patientInfoUpdater.Execute(data, command);

					// 2020.07.17 add start cosmo@nishihara PATIENTCOMMENTS処理追加
					_log.Debug("PATIENTCOMMENTS更新処理を行います");
					PATIENTCOMMENTSUpdaterOrderInfo patientCommentsUpdater = new PATIENTCOMMENTSUpdaterOrderInfo();
					patientCommentsUpdater.Execute(data, command);
					// 2020.07.17 add end cosmo@nishihara PATIENTCOMMENTS処理追加
				}

				_log.Debug("EXMAINTABLE更新処理を行います");
				EXMAINTABLEUpdaterOrderInfo exMainTableUpdater = new EXMAINTABLEUpdaterOrderInfo();
				// 2020.07.21 add start cosmo@nishihara SELECT処理追加
				DataRow select_exmain = exMainTableUpdater.GetExMainData(order, command);
				//SELECT文で取得した各値をセッターに詰めてSetParamsメソッドで使用
				order.SELECT_EXMAIN = select_exmain;
				// 2020.07.21 add end cosmo@nishihara SELECT処理追加
				exMainTableUpdater.SetConnection(cn);
				exMainTableUpdater.Execute(data, command);

				_log.Debug("FROMHISINFO削除処理を行います");
				FROMHISINFOUpdaterOrderInfo fromHisInfoUpdater = new FROMHISINFOUpdaterOrderInfo();
				fromHisInfoUpdater.Delete(data, command);
				_log.Debug("FROMHISINFO更新処理を行います");
				fromHisInfoUpdater.Execute(data, command);

				_log.Debug("TOREPORTINFO削除処理を行います");
				TOREPORTINFOUpdaterOrderInfo toReportInfoUpdater = new TOREPORTINFOUpdaterOrderInfo();
				toReportInfoUpdater.Delete(data, command);
				_log.Debug("TOREPORTINFO更新処理を行います");
				toReportInfoUpdater.Execute(data, command);

				_log.Debug("TOOTHERSYSTEMINFO削除処理を行います");
				TOOTHERSYSTEMINFOUpdaterOrderInfo toOtherSystemInfoUpdater = new TOOTHERSYSTEMINFOUpdaterOrderInfo();
				toOtherSystemInfoUpdater.Delete(data, command);
				// 2020.07.29 add start cosmo@nishihara TOOTHERSYSTEMINFO,TOSYNAPSEINFO更新制御処理追加
				if ("Y" == que_setting)
				{
					_log.Debug("TOOTHERSYSTEMINFO更新処理を行います");
					toOtherSystemInfoUpdater.Execute(data, command);
				}
				// 2020.08.14 del start cosmo@taira TOSYNAPSEINFO処理コメントアウト
				//_log.Debug("TOSYNAPSEINFO削除処理を行います");
				//TOSYNAPSEINFOUpdaterOrderInfo toSynapseInfoUpdater = new TOSYNAPSEINFOUpdaterOrderInfo();
				//toSynapseInfoUpdater.Delete(data, command);

				//if ("Y" == que_setting)
				//{
				//	_log.Debug("TOSYNAPSEINFO更新処理を行います");
				//	toSynapseInfoUpdater.Execute(data, command);
				//}
				// 2020.08.14 del end cosmo@taira TOSYNAPSEINFO処理コメントアウト
				// 2020.07.29 add end cosmo@nishihara TOOTHERSYSTEMINFO,TOSYNAPSEINFO更新制御処理追加

				// 2020.08.14 add start cosmo@taira
				if ("Y" == tohisinfo_que_setting)
				{
					_log.Debug("TOHISINFO更新処理を行います");
					TOHISINFOUpdater toHisInfoUpdater = new TOHISINFOUpdaterOrderInfo();
					toHisInfoUpdater.Execute(data, command);
				}
				// 2020.08.14 add end cosmo@taira
			}
			_log.Debug("InsertOrUpdateWithTran終了しました");
		}

		#endregion

		#endregion
	}
}
