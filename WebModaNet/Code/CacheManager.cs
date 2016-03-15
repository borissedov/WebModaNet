using System;
using System.Web;
using System.Web.Caching;

namespace EW.WebModaNet.Code
{
	public static class CacheManager
	{
		public static void Add(string key, object value)
		{
			HttpContext.Current.Cache[key] = value;
		}

		public static bool Contains(string key)
		{
			return HttpContext.Current.Cache[key] != null;
		}

		public static object Get(string key)
		{
			return HttpContext.Current.Cache[key];
		}

		public static void Remove(string key)
		{
			HttpContext.Current.Cache.Remove(key);
		}
	}
}