using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.UI.WebControls;

namespace EW.WebModaNet.Code
{
	public static class ExtensionMethods
	{
		public static void AddCssClass(this WebControl control, string cssClass)
		{
			if (!control.HasCssClass(cssClass))
			{
				string str = control.CssClass;
				char[] chrArray = new char[] { ' ' };
				List<string> newClasses = str.Split(chrArray).ToList<string>();
				newClasses.Add(cssClass);
				control.CssClass = string.Join(" ", newClasses);
			}
		}

		public static void Clear(this TextBox control)
		{
			control.Text = string.Empty;
		}

		public static string[] GetSelectedValues(this ListControl control)
		{
			List<string> selectedValues = new List<string>();
			foreach (ListItem item in control.Items)
			{
				if (item.Selected)
				{
					selectedValues.Add(item.Value);
				}
			}
			return selectedValues.ToArray();
		}

		public static bool HasCssClass(this WebControl control, string cssClass)
		{
			bool flag;
			string[] strArrays = control.CssClass.Split(new char[] { ' ' });
			int num = 0;
			while (true)
			{
				if (num >= (int)strArrays.Length)
				{
					flag = false;
					break;
				}
				else if (!strArrays[num].Equals(cssClass, StringComparison.OrdinalIgnoreCase))
				{
					num++;
				}
				else
				{
					flag = true;
					break;
				}
			}
			return flag;
		}

		public static IOrderedEnumerable<T> OrderByRandom<T>(this IEnumerable<T> source)
		{
			IOrderedEnumerable<T> ts = 
				from o in source
				orderby Guid.NewGuid()
				select o;
			return ts;
		}

		public static T RandomElement<T>(this IEnumerable<T> source)
		{
			return source.OrderByRandom<T>().FirstOrDefault<T>();
		}

		public static void RemoveCssClass(this WebControl control, string cssClass)
		{
			if (control.HasCssClass(cssClass))
			{
				string[] classes = control.CssClass.Split(new char[] { ' ' });
				List<string> newClasses = new List<string>();
				string[] strArrays = classes;
				for (int i = 0; i < (int)strArrays.Length; i++)
				{
					string c = strArrays[i];
					if (!c.Equals(cssClass, StringComparison.OrdinalIgnoreCase))
					{
						newClasses.Add(c);
					}
				}
				control.CssClass = string.Join(" ", newClasses);
			}
		}
	}
}