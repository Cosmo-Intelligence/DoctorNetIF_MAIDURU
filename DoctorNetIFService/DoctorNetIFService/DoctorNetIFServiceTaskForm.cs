using System;
using System.Configuration;
using System.Windows.Forms;
using RISCommonLibrary.Lib.Debugger;
using RISCommonLibrary.Lib.Utils;
using DoctorNetIFService.Model;
using System.Net;
using System.Threading;

namespace DoctorNetIFService
{
    public partial class DoctorNetIFServiceTaskForm : Form
    {
        #region field
        /// <summary>
        /// ログフォーム
        /// </summary>
        private LogForm _logForm;

        /// <summary>
        /// log4netインスタンス
        /// </summary>
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// ループスレッド
        /// </summary>
        private Thread _loopThread = null;

        /// <summary>
        /// 
        /// </summary>
        private TableInfoWatcher _watcher = new TableInfoWatcher();

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DoctorNetIFServiceTaskForm()
        {
            InitializeComponent();

            System.Diagnostics.FileVersionInfo ver =
                    System.Diagnostics.FileVersionInfo.GetVersionInfo(
                System.Reflection.Assembly.GetExecutingAssembly().Location);
            _log.InfoFormat("サービスを開始します。ファイルバージョン={0}", ver.FileVersion);

            _watcher = new TableInfoWatcher();

            _loopThread = new Thread(new ThreadStart(_watcher.Execute));
            _loopThread.Start();

            _log.Info("サービスを開始しました");
        }

        #endregion

        #region 各イベント

        /// <summary>
        /// 常駐アイコン右クリックメニュー
        /// </summary>
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // タスクトレイアイコンを非表示にする。
            notifyIcon1.Visible = false;

            // タスクトレイアイコンが残らないようにする
            notifyIcon1.Dispose();

            _watcher.StopLoop();

            Application.Exit();
        }

        #endregion

    }
}
