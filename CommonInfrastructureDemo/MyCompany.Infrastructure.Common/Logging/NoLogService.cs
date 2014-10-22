using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Logging
{
	public class NoLogService : ILoggingService
	{
		public void LogInfo(object logSource, string message, Exception exception = null)
		{}

		public void LogWarning(object logSource, string message, Exception exception = null)
		{}

		public void LogError(object logSource, string message, Exception exception = null)
		{}

		public void LogFatal(object logSource, string message, Exception exception = null)
		{}
	}
}
