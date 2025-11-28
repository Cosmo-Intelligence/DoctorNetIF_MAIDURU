using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace RISReportService.util
{
    /// <summary>
    /// 共通処理クラス
    /// </summary>
    class CommonUtil
    {
        // ログ
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(MethodBase.
                GetCurrentMethod().DeclaringType);

        // 全ての検索・更新処理でレコードの取得可
        public const int FLOW_RECORD_HIT = 0;

        // 何れかの検索・更新処理でレコードの取得不可
        public const int FLOW_RECORD_WITHOUT = 1;

        // AP実行中に例外の発生
        public const int FLOW_EX = 2;

        // AP実行中にOracle例外の発生
        public const int FLOW_EX_ORACLE = 3;

        public const string STATUS_OK = "01";
        public const string STATUS_NOT = "02";
        public const string STATUS_NG = "03";
        public const string STATUS_NG_ORACLE = "09";
        public const string FLAG_KAKUTEI = "1";
        public const string FLAG_BYOURI = "2";
        public const string RESULT_OK = "OK";
        public const string RESULT_NOT = "処理対象外";
        public const string RESULT_NG = "NG";
        /// <summary>
        /// yyyyMMdd書式
        /// </summary>
        public const string YYYYMMDD = "yyyyMMdd";

        /// <summary>
        /// ReportInterface.exe.configから各設定値の取得
        /// </summary>
        /// <param name="appConfigkey">各設定値のキー</param>
        /// <param name="table">設定ファイルテーブル</param>
        /// <param name="nullable">true:設定値なしを許可</param>
        /// <returns>false : 不正</returns>
        public static bool GetAppConfigValue(string appConfigkey, Hashtable table, bool nullable, string iniVal)
        {
            // 各設定を格納
            string value = ConfigurationManager.AppSettings[appConfigkey].ToString();

            if (string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(iniVal))
            {
                value = iniVal;
            }

            // 各設定のチェック
            if (!nullable && string.IsNullOrEmpty(value))
            {
                string appConfigName = Path.GetFileName(Application.ExecutablePath) + "config";

                log.ErrorFormat("{0}の設定値が未定義です。設定値 : {1}", appConfigName, appConfigkey);

                return false;
            }

            log.DebugFormat("{0}の設定値。設定値 : {1}", appConfigkey, value);

            // 取得できた各設定を追加していく
            table.Add(appConfigkey, value);

            return true;
        }
    }
}