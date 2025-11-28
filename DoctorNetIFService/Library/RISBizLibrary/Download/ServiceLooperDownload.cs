using System;
using System.Configuration;
using System.Threading;
using RISBizLibrary.Utils;
using RISCommonLibrary.Lib.Utils;

namespace RISBizLibrary.Download
{
	/// <summary>
	/// キューテーブルからデータ取得し、処理を行う
	/// </summary>
	public class ServiceLooperDownload : IDisposable
	{
		/// <summary>
		/// log4netインスタンス
		/// </summary>
		private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(
			System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// 処理クラス
		/// </summary>
		private FileDownload _fileHandler = new FileDownload();

		/// <summary>
		/// 古いログ削除ヘルパー
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

				_log.Debug("古いログファイルを削除します");
				_deleteOldLogHelper.DeleteOldLog();

				_fileHandler.Download();

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
		}

		#endregion
	}
}
