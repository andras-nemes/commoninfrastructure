using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.ContextProvider
{
	public class ThreadContextService : IContextService
	{
		public string GetContextualFullFilePath(string fileName)
		{
			string dir = Directory.GetCurrentDirectory();
			FileInfo resourceFileInfo = new FileInfo(Path.Combine(dir, fileName));
			return resourceFileInfo.FullName;
		}

		public string GetUserName()
		{
			string userName = "<null>";
			try
			{
				if (Thread.CurrentPrincipal != null)
				{
					userName = (Thread.CurrentPrincipal.Identity.IsAuthenticated
									? Thread.CurrentPrincipal.Identity.Name
									: "<null>");
				}
			}
			catch
			{
			}
			return userName;
		}

		public ContextProperties GetContextProperties()
		{
			return new ContextProperties();
		}
	}
}
