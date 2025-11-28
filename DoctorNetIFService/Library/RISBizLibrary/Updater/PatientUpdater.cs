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
	/// 患者系のみ更新する
	/// </summary>
	public class PatientUpdater
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
		public void InsertOrUpdate(BaseMsgData data, IDbConnection cnRis)
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
		private void InsertOrUpdateWithTran(BaseMsgData data, IDbConnection cn, IDbTransaction tr)
		{
			_log.Debug("InsertOrUpdateWithTran開始します");
			_log.Debug("患者情報更新処理を行います");
			using (IDbCommand command = cn.CreateCommand())
			{
				command.InitCommandODP(ConfigurationManager.AppSettings["CommandTimeout"].StringToInt32());
				command.Transaction = tr;

				_log.Debug("PATIENTINFO更新処理を行います");
				PATIENTINFOUpdaterPatient patientInfoUpdater = new PATIENTINFOUpdaterPatient();
				patientInfoUpdater.Execute(data, command);

				// 2020.07.27 add end cosmo@nishihara TOOTHERSYSTEMINFO追加
				_log.Debug("TOOTHERSYSTEMINFO削除処理を行います");
				TOOTHERSYSTEMINFOUpdaterPatient toOtherSystemInfoUpdater = new TOOTHERSYSTEMINFOUpdaterPatient();
				toOtherSystemInfoUpdater.Delete(data, command);
				_log.Debug("TOOTHERSYSTEMINFO更新処理を行います");
				toOtherSystemInfoUpdater.Execute(data, command);
				// 2020.07.27 add end cosmo@nishihara TOOTHERSYSTEMINFO追加

				// 2020.08.14 del start cosmo@taira TOSYNAPSEINFO処理コメントアウト
				//_log.Debug("TOSYNAPSEINFO削除処理を行います");
				//TOSYNAPSEINFOUpdater toSynapseInfoUpdater = new TOSYNAPSEINFOUpdaterPatient();
				//toSynapseInfoUpdater.Delete(data, command);
				//_log.Debug("TOSYNAPSEINFO更新処理を行います");
				//toSynapseInfoUpdater.Execute(data, command);
				// 2020.08.14 del end cosmo@taira TOSYNAPSEINFO処理コメントアウト

				_log.Debug("FROMHISINFO削除処理を行います");
				FROMHISINFOUpdater fromHisInfoUpdater = new FROMHISINFOUpdaterPatient();
				fromHisInfoUpdater.Delete(data, command);
				_log.Debug("FROMHISINFO更新処理を行います");
				fromHisInfoUpdater.Execute(data, command);

				// 2020.08.14 add start cosmo@taira
				_log.Debug("TOHISINFO更新処理を行います");
				TOHISINFOUpdater toHisInfoUpdater = new TOHISINFOUpdaterrPatient();
				toHisInfoUpdater.Execute(data, command);
				// 2020.08.14 add end   cosmo@taira
			}

			_log.Debug("InsertOrUpdateWithTran終了しました");
		}

		#endregion

		#endregion
	}
}
