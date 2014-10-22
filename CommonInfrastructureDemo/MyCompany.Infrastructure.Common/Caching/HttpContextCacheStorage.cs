using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyCompany.Infrastructure.Common.Caching
{
	public class HttpContextCacheStorage : ICacheStorage
	{
		public void Remove(string key)
		{
			HttpContext.Current.Cache.Remove(key);
		}

		public void Store(string key, object data)
		{
			HttpContext.Current.Cache.Insert(key, data);
		}

		public void Store(string key, object data, DateTime absoluteExpiration, TimeSpan slidingExpiration)
		{
			HttpContext.Current.Cache.Insert(key, data, null, absoluteExpiration, slidingExpiration);
		}

		public T Retrieve<T>(string key)
		{
			T itemStored = (T)HttpContext.Current.Cache.Get(key);
			if (itemStored == null)
				itemStored = default(T);

			return itemStored;
		}
	}
}
