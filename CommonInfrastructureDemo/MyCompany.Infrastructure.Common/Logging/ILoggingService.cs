using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Logging
{
	public interface ILoggingService
	{
		void LogInfo(object logSource, string message, Exception exception = null);
		void LogWarning(object logSource, string message, Exception exception = null);
		void LogError(object logSource, string message, Exception exception = null);
		void LogFatal(object logSource, string message, Exception exception = null);
	}
}
