using DoctorNetIFService.Data;
using DoctorNetIFService.Properties;
using DoctorNetIFService.Utils;
using RISCommonLibrary.Lib.Utils;
using RISODPLibrary.Lib.Utils;
using RISReportService.util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorNetIFService.Model
{
    internal class TableInfoWatcher
    {
        /// <summary>
		/// log4netインスタンス
		/// </summary>
		private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// ToOtherSystemInfo処理クラス
        /// </summary>
        private TableInfoManager _tootherSystemInfoManager = new TableInfoManager();

        /// <summary>
        /// 古いログ削除クラス
        /// </summary>
        private DeleteOldLogHelper _deleteOldLogHelper = new DeleteOldLogHelper();

        /// <summary>
        /// ループ処理続行フラグ
        /// </summary>
        private bool _isContinue = true;

        /// <summary>
        /// 同期オブジェクト
        /// </summary>
        private Object _thisLock = new Object();

        /// <summary>
        /// TCPリスナー
        /// </summary>
        private TcpListenerHandler tcpHandler = null;

        /// <summary>
        /// ループ処理を続けるか？
        /// </summary>
        public bool IsContinue
        {
            get
            {
                return _isContinue;
            }
            private set
            {
                lock (_thisLock)
                {
                    _isContinue = value;
                }
            }
        }

        public void StopLoop()
        {
            try
            {
                if (!IsContinue)
                {
                    return;
                }
                _log.Debug("プログラムへ停止指示します");
                IsContinue = false;
            }
            catch (Exception e)
            {
                _log.ErrorFormat("未補足の例外が発生しました。{0}", e);
                throw;
            }
        }

        public void Execute()
        {
            Execute(null);
        }

        public void Execute(Action func)
        {
            try
            {
                IsContinue = true;
                while (IsContinue)
                {
                    ExcecuteOne();

                    if (func != null)
                    {
                        func();
                    }
                    int sleepTime = AppConfigController.GetInstance().GetValueString(AppConfigParameter.threadSleepTime).StringToInt32();
                    Thread.Sleep(sleepTime);
                }
            }
            catch (Exception e)
            {
                _log.ErrorFormat("未補足の例外が発生しました。{0}", e);
                throw;
            }
        }

        public void ExcecuteOne()
        {
            try
            {
                string connectionStringRISDB = Settings.Default.ConnectionStringRISDB;
                IDbConnection cnRISDB = ODPConnectionUtils.Connect(connectionStringRISDB);

                int recordcount = 0;

                if (!int.TryParse(AppConfigController.GetInstance().GetValueString(AppConfigParameter.recordCount), out recordcount))
                {
                    recordcount = 10;
                }

                string requesttype = AppConfigController.GetInstance().GetValueString(AppConfigParameter.targetRequestType);
                int systemno = AppConfigController.GetInstance().GetValueString(AppConfigParameter.targetSystemNo).StringToInt32();

                _log.Debug("古いログファイルを削除します");
                _deleteOldLogHelper.DeleteOldLog();

                try
                {

                    ToOtherSystemInfo[] tosArray = null;

                    // TOOTHERSYSTEMINFOの各値取得
                    tosArray = TableInfoHelper.GetDataToOtherSystemInfo(cnRISDB, requesttype, systemno, recordcount);

                    // TOOTHERSYSTEMINFO該当する内容が0件なら
                    if (tosArray == null)
                    {
                        _log.Info("該当件数：0件");
                        return;
                    }

                    _log.Debug("処理を開始します。");


                    // 取得した件数分処理を行う
                    _log.Debug("処理対象件数：" + tosArray.Length.ToString() + "件");
                    foreach (ToOtherSystemInfo tootherSystemInfo in tosArray)
                    {

                        _tootherSystemInfoManager.Execute(cnRISDB, tootherSystemInfo);
                    }
                }
                catch (Exception ex)
                {
                    _log.Error(ex.ToString());
                }
                finally
                {
                    cnRISDB.Close();

                    if (tcpHandler != null)
                    {
                        tcpHandler.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error("致命的なエラーが発生しました。");
                _log.Error(ex.ToString());
            }
        }
    }
}
