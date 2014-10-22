using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Infrastructure.Common.Caching
{
	public class NoCacheStorage : ICacheStorage
	{
		public void Remove(string key)
		{}

		public void Store(string key, object data)
		{}

		public void Store(string key, object data, DateTime absoluteExpiration, TimeSpan slidingExpiration)
		{}

		public T Retrieve<T>(string key)
		{
			return default(T);
		}
	}
}
