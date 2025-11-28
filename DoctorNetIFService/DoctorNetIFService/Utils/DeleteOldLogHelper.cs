using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RISCommonLibrary.Lib.LogCleaner;
using RISCommonLibrary.Lib.Utils;
using System.IO;
using System.Configuration;
using RISReportService.util;

namespace DoctorNetIFService.Utils
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
				string log4netFileRegex = AppConfigController.GetInstance().GetValueString(AppConfigParameter.log4netFileRegex).StringToString();
				string log4netFileDateFormat = AppConfigController.GetInstance().GetValueString(AppConfigParameter.log4netFileDateFormat).StringToString();
				_logCleanerManager.Regist(new LogCleanerLog4Net("RISIfLog", log4netFileRegex, log4netFileDateFormat, UpdatePropForRISIfLog));
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
			int logStoreTerm = AppConfigController.GetInstance().GetValueString(AppConfigParameter.logStoreTerm).StringToInt32();

			(target as LogCleanerLog4Net).UpdateProp(logTargetDir, logStoreTerm);
		}

	}
}
