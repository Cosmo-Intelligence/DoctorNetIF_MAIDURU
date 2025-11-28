using System.Configuration;
using System.IO;
using RISCommonLibrary.Lib.LogCleaner;
using RISCommonLibrary.Lib.Utils;

namespace RISBizLibrary.Utils
{
	/// <summary>
	/// 古いログ削除クラス
	/// </summary>
	public class DeleteOldLogHelper
	{
		private LogCleanerManager _logCleanerManager;

		public void DeleteOldLog()
		{
			if (_logCleanerManager == null)
			{
				_logCleanerManager = new LogCleanerManager();
				string log4netFileRegex = ConfigurationManager.AppSettings["log4netFileRegex"].StringToString();
				string log4netFileDateFormat = ConfigurationManager.AppSettings["log4netFileDateFormat"].StringToString();
				_logCleanerManager.Regist(new LogCleanerLog4Net("RISIfLog", log4netFileRegex, log4netFileDateFormat, UpdatePropForRISIfLog));
				//string messageLogWriteDirDateFormat = ConfigurationManager.AppSettings["MessageLogWriteDirDateFormat"].StringToString();
				//_logCleanerManager.Regist(new LogCleanerYYYYMMDDDir("MessageLog", messageLogWriteDirDateFormat, UpdatePropForMessageLog));
			}
			_logCleanerManager.UpdateProp();
			_logCleanerManager.CleanUp();
		}

		private void UpdatePropForRISIfLog(ILogCleaner target)
		{
			log4net.Appender.IAppender appender = log4netUtils.GetLog4netAppender("RollingLogFileAppender");
			log4net.Appender.RollingFileAppender rollingFileAppender = appender as log4net.Appender.RollingFileAppender;
			if (rollingFileAppender == null)
			{
				return;
			}

			string logTargetDir = Path.GetDirectoryName(rollingFileAppender.File);
			int logStoreTerm = ConfigurationManager.AppSettings["LogStoreTerm"].StringToInt32();

			(target as LogCleanerLog4Net).UpdateProp(logTargetDir, logStoreTerm);
		}

		//private void UpdatePropForMessageLog(ILogCleaner target)
		//{
		//	string logRootDir = ConfigurationManager.AppSettings["MessageLogRootDir"].StringToString();
		//	int logStoreTerm = ConfigurationManager.AppSettings["LogStoreTerm"].StringToInt32();

		//	(target as LogCleanerYYYYMMDDDir).UpdateProp(logRootDir, logStoreTerm);
		//}

	}
}
