using System;
using System.Resources;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.Code
{
	public static class StringExtensions
	{
		public static string ToSafeTranslation(this string key)
		{
			string str;
			if (!string.IsNullOrEmpty(key))
			{
				string translation = key;
				try
				{
					translation = Resources.ResourceManager.GetString(key);
				}
				catch (Exception exception)
				{
					translation = key;
				}
				str = translation;
			}
			else
			{
				str = key;
			}
			return str;
		}
	}
}