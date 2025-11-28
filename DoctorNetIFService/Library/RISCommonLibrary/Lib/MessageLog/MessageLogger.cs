using System;
using System.IO;
using System.Text;
using RISCommonLibrary.Lib.Utils;

namespace RISCommonLibrary.Lib.MessageLog
{
	/// <summary>
	/// 電文ログクラス
	/// </summary>
	/// <remarks>シングルトン</remarks>
	public class MessageLogger
	{
		#region field

		/// <summary>
		/// インスタンス
		/// </summary>
		private static readonly MessageLogger _instance = new MessageLogger();

		private String rootDir = @".\Log\Message";
		private String currentDir = DateTime.Now.ToString("yyyyMMdd");
		private String targetDirFormat = "yyyyMMdd";
		private Encoding enc = Encoding.GetEncoding(932);

		/// <summary>
		/// 同期オブジェクト
		/// </summary>
		private object _syncObject = new object();
		#endregion

		#region props
		/// <summary>
		/// インスタンスにアクセスするプロパティ
		/// </summary>
		public static MessageLogger Instance
		{
			get
			{
				return _instance;
			}
		}

		public string RootDir
		{
			get
			{
				return rootDir;
			}
			set
			{
				rootDir = value;
			}
		}

		public string CurrentDir
		{
			get
			{
				return currentDir;
			}
			set
			{
				currentDir = value;
			}
		}

		public string TargetDirFormat
		{
			get
			{
				return targetDirFormat;
			}
			set
			{
				targetDirFormat = value;
			}
		}

		public Encoding Enc
		{
			get
			{
				return enc;
			}
			set
			{
				enc = value;
			}
		}
		#endregion


		/// <summary>
		/// コンストラクタ
		/// </summary>
		private MessageLogger()
		{
		}

		public void UpdateCurrentDir(DateTime currentDateTime)
		{
			this.currentDir = currentDateTime.ToString(targetDirFormat);
		}

		public void WriteLog(string fileName, string logtype, string message)
		{
			lock (_syncObject)
			{
				string WriteFileFullPath = GetFileNameFullPath(rootDir, string.Empty, fileName);
				DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(WriteFileFullPath));
				if (!directoryInfo.Exists)
				{
					directoryInfo.Create();
				}

				using (StreamWriter sw = new StreamWriter(WriteFileFullPath, true, enc))
				{
					const string LOG_FORMAT = "{0:yyyy/MM/dd HH:mm:ss.fff} {1} {2}";
					sw.WriteLine(string.Format(LOG_FORMAT, DateTime.Now, logtype, message));
				}
			}
		}

		private String GetFileNameFullPath(String rootDir, String currentDir, String fileName)
		{
			return CombinePaths(rootDir, currentDir, fileName);
		}

		private String CombinePaths(params string[] paths)
		{
			String rt = string.Empty;
			foreach (string item in paths)
			{
				rt = Path.Combine(rt, item);
			}
			return rt;
		}
	}
}
