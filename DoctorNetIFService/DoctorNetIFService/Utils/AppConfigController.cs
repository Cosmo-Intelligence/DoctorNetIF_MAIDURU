using System.Collections;

namespace RISReportService.util
{
    /// <summary>
    /// APの設定ファイル管理クラス
    /// </summary>
    class AppConfigController
    {
        // 設定ファイルテーブル
        private Hashtable appConfigTable = new Hashtable();

        // このクラスのインスタンス
        private static AppConfigController instance = new AppConfigController();

        // ロックオブジェクト
        private static object rock = new object();

        /// <summary>
        /// 設定ファイルの各項目を設定する
        /// </summary>
        /// <param name="table"></param>
        public void SetAppConfigTable(Hashtable table)
        {
            this.appConfigTable = table;
        }

        /// <summary>
        /// このクラスのインスタンスを取得
        /// </summary>
        /// <returns>インスタンス</returns>
        static public AppConfigController GetInstance()
        {
            lock (rock)
            {
                if (instance == null)
                {
                    instance = new AppConfigController();
                }
            }
            return instance;
        }

        /// <summary>
        /// APの設定値を取得
        /// </summary>
        /// <param name="key">キー</param>
        /// <returns>各設定値</returns>
        public string GetValueString(string key)
        {
            // 初期化
            string ret = "";

            if ((this.appConfigTable != null)
                    && (this.appConfigTable.Contains(key)))
            {
                // 設定値の取得
                ret = this.appConfigTable[key].ToString();
            }
            return ret;
        }
    }
}
