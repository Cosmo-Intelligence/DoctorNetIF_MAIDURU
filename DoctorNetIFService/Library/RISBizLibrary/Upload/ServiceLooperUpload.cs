using System;
using System.Configuration;
using System.Data;
using System.Threading;
using RISBizLibrary.Config;
using RISBizLibrary.Upload.Data;
using RISCommonLibrary.Lib.Utils;
using RISODPLibrary.Lib.Utils;

namespace RISBizLibrary.Upload
{
	/// <summary>
	/// キューテーブルからデータ取得し、処理を行う
	/// </summary>
	public class ServiceLooperUpload : IDisposable
	{
		/// <summary>
		/// log4netインスタンス
		/// </summary>
		private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// 送信処理クラス
		/// </summary>
		private ToHisInfoSender _toHisInfoSender = new ToHisInfoSender();

		/// <summary>
		/// ループ処理続行フラグ
		/// </summary>
		private bool _isContinue = true;

		/// <summary>
		/// 同期オブジェクト
		/// </summary>
		private Object _thisLock = new Object();

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
			catch (Exception ex)
			{
				_log.ErrorFormat("未補足の例外が発生しました。{0}", ex);
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
					int sleepTime = ConfigurationManager.AppSettings["ThreadSleepTime"].StringToInt32();
					#region コメントをループ時減らす
					//_log.DebugFormat("スリープします={0}", sleepTime);
					#endregion
					Thread.Sleep(sleepTime);
				}
			}
			catch (Exception ex)
			{
				_log.ErrorFormat("未補足の例外が発生しました。{0}", ex);
				throw;
			}
		}

		public void ExcecuteOne()
		{
			try
			{
				#region コメントをループ時減らす
				//_log.Info("Upload処理を開始します");
				#endregion

				string connectionStringRis = (string)SettingsAdapter.Instance.GetValue("ConnectionString");
				#region コメントをループ時減らす
				//_log.DebugFormat("接続文字列取得しました。{0}",
				//    OracleClientUtils.GetConnectionStringWithoutPassword(connectionString));
				//_log.Debug("DB接続します");
				#endregion
				IDbConnection connectionRis = ODPConnectionUtils.Connect(connectionStringRis);

				ToHisInfo toHisInfo;
				try
				{
					//ToHisInfo削除
					ToHisInfoHelper.Delete(connectionRis);
					//ToHisInfo取得
					toHisInfo = ToHisInfoHelper.GetDataFromDB(connectionRis);
					if (toHisInfo == null)
					{
						#region コメントをループ時減らす
						//const string MSG_CUE_TABLE_NO_RECORD = "Upload処理を終了します。TOHISINFOテーブルに未送信のレコードはありませんでした";
						//_log.Info(MSG_CUE_TABLE_NO_RECORD);
						#endregion
						return;
					}
					_toHisInfoSender.Send(toHisInfo, connectionRis);
				}
				finally
				{
					#region コメントをループ時減らす
					//_log.Debug("DB切断します");
					#endregion
					connectionRis.Close();
				}
				#region コメントをループ時減らす
				//_log.Info("Upload処理を終了します");
				#endregion
			}
			catch (Exception ex)
			{
				_log.Error("致命的なエラーが発生しました。");
				_log.Error(ex.ToString());
			}
		}

		#region IDisposable メンバ

		public void Dispose()
		{
			if (_toHisInfoSender != null)
			{
				_toHisInfoSender.Dispose();
				_toHisInfoSender = null;
			}
		}

		#endregion
	}
}
