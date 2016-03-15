using System;
using System.Collections.Specialized;
using System.Web.Configuration;

namespace EW.WebModaNet.Code
{
	internal static class WebConfigUtils
	{
		public static bool GetBool(string key)
		{
			bool returnValue = false;
			bool.TryParse(WebConfigUtils.GetString(key), out returnValue);
			return returnValue;
		}

		public static int GetInt(string key)
		{
			int returnValue = 0;
			int.TryParse(WebConfigUtils.GetString(key), out returnValue);
			return returnValue;
		}

		public static string GetString(string key)
		{
			string returnValue = string.Empty;
			if (WebConfigurationManager.AppSettings.Get(key) != null)
			{
				returnValue = WebConfigurationManager.AppSettings.Get(key);
			}
			return returnValue;
		}
	}
}