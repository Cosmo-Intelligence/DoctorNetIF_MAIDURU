using DoctorNetIFService.Model;
using RISReportService.util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace DoctorNetIFService
{
	static class Program
	{
        /// <summary>
        /// log4netインスタンス
        /// </summary>
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        static void Main()
        {
            // 二重起動にならないか確認する
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                _log.Error("アプリケーションを多重起動しようとした為、アプリケーションを強制終了します。");
                return;
            }

            Hashtable appConfigTable = new Hashtable();

            if (!CreateAppConfigParameter(appConfigTable))
            {
                _log.Info("設定ファイル読込処理で問題が発生したため、終了します。");
                return;
            }

            AppConfigController.GetInstance().SetAppConfigTable(appConfigTable);

            string[] args = Environment.GetCommandLineArgs();
            if (IsGuiMode(args))
            {
                if ("task" == args[1])
                {
                    //ThreadExceptionイベントハンドラを追加
                    Application.ThreadException +=
                    new System.Threading.ThreadExceptionEventHandler(
                        Application_ThreadException);

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    using (DoctorNetIFServiceTaskForm form = new DoctorNetIFServiceTaskForm())
                    {
                        Application.Run();
                    }
                }
                else
                {
                    //ThreadExceptionイベントハンドラを追加
                    Application.ThreadException +=
                    new System.Threading.ThreadExceptionEventHandler(
                        Application_ThreadException);

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new DoctorNetIFService());
                }
                return;
            }

            //UnhandledExceptionイベントハンドラを追加
            System.AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new DoctorNetInterfaceService() 
            };
            ServiceBase.Run(ServicesToRun);
        }

        /// <summary>
        /// サービスモードか？GUIモードか？タスク起動モードか？
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <remarks>コマンドラインにguiが設定されてきたらGUIモード</remarks>
        private static bool IsGuiMode(string[] args)
        {
            if (args == null)
            {
                return false;
            }
            if (args.Count() < 2)
            {
                return false;
            }
            //タスク起動
            if ("task" == args[1])
            {
                return true;
            }
            if (string.Compare(args[1], "gui", true) != 0)
            {
                return false;
            }
            return true;
        }

        private static void Application_ThreadException(object sender,
            System.Threading.ThreadExceptionEventArgs e)
        {
            _log.ErrorFormat("未補足の例外が発生しました。{0}", e.Exception);
        }

        //UnhandledExceptionイベントハンドラ
        private static void CurrentDomain_UnhandledException(object sender,
            UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            if (ex == null)
            {
                return;
            }
            _log.ErrorFormat("未補足の例外が発生しました。{0}", ex);
        }

        /// <summary>
        /// 設定値をHashTableに保存
        /// </summary>
        /// <param name="table">設定ファイルテーブル</param>
        /// <returns>false : 不正</returns>
        private static bool CreateAppConfigParameter(Hashtable table)
        {
            if (!CommonUtil.GetAppConfigValue(AppConfigParameter.threadStopTimeout, table, false, null)) { return false; }
            if (!CommonUtil.GetAppConfigValue(AppConfigParameter.clientCloseTimeout, table, false, null)) { return false; }
            if (!CommonUtil.GetAppConfigValue(AppConfigParameter.commandTimeout, table, false, null)) { return false; }
            if (!CommonUtil.GetAppConfigValue(AppConfigParameter.threadSleepTime, table, false, null)) { return false; }
            if (!CommonUtil.GetAppConfigValue(AppConfigParameter.log4netFileDateFormat, table, false, null)) { return false; }
            if (!CommonUtil.GetAppConfigValue(AppConfigParameter.log4netFileRegex, table, false, null)) { return false; }
            if (!CommonUtil.GetAppConfigValue(AppConfigParameter.logStoreTerm, table, false, null)) { return false; }
            if (!CommonUtil.GetAppConfigValue(AppConfigParameter.targetRequestType, table, false, null)) { return false; }
            if (!CommonUtil.GetAppConfigValue(AppConfigParameter.targetSystemNo, table, false, null)) { return false; }
            if (!CommonUtil.GetAppConfigValue(AppConfigParameter.outputFolder, table, false, null)) { return false; }
            if (!CommonUtil.GetAppConfigValue(AppConfigParameter.recordCount, table, false, null)) { return false; }

            return true;
        }
    }
}
