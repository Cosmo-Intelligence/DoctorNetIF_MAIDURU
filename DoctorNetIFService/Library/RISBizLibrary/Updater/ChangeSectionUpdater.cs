using System;
using System.Configuration;
using System.Data;
using RISBizLibrary.Data;
using RISBizLibrary.Updater.Table;
using RISCommonLibrary.Lib.Utils;
using RISODPLibrary.Lib.Utils;

namespace RISBizLibrary.Updater
{
	/// <summary>
	/// 入院電文から更新する
	/// </summary>
	public class ChangeSectionUpdater
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
		public void InsertOrUpdate(BaseMsgData data, IDbConnection cn)
		{
			_log.Debug("InsertOrUpdate開始します");
			IDbTransaction tr = cn.BeginTransaction();
			_log.Debug("BeginTransactionしました");
			try
			{
				InsertOrUpdateWithTran(data, cn, tr);
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
		private void InsertOrUpdateWithTran(BaseMsgData data, IDbConnection cn, IDbTransaction tr)
		{
			_log.Debug("InsertOrUpdateWithTran開始します");
			_log.Debug("転科更新処理を行います");
			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.Transaction = tr;

				_log.Debug("PATIENTINFO更新処理を行います");
				PATIENTINFOUpdaterChangeSection patientInfoUpdater = new PATIENTINFOUpdaterChangeSection();
				patientInfoUpdater.Execute(data, command);

				_log.Debug("FROMHISINFO削除処理を行います");
				FROMHISINFOUpdater fromHisInfoUpdater = new FROMHISINFOUpdaterChangeSection();
				fromHisInfoUpdater.Delete(data, command);
				_log.Debug("FROMHISINFO更新処理を行います");
				fromHisInfoUpdater.Execute(data, command);
			}
			_log.Debug("InsertOrUpdateWithTran終了しました");
		}
		
		#endregion

		#endregion
	}
}
