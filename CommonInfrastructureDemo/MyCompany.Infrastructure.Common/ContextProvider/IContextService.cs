using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.ContextProvider
{
	public interface IContextService
	{
		string GetContextualFullFilePath(string fileName);
		string GetUserName();
		ContextProperties GetContextProperties();
	}
}
