using EW.WebModaNet.Code;
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace EW.WebModaNet
{
	public class Site : MasterPage
	{
		public Site()
		{
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			string cssFileName = string.Concat("site.", WebConfigSettings.Release, ".css").ToLower();
			string cssVirtualPath = string.Concat("~/Styles/", cssFileName);
			if (File.Exists(base.Server.MapPath(cssVirtualPath)))
			{
				HtmlLink linkElement = new HtmlLink()
				{
					Href = cssVirtualPath
				};
				linkElement.Attributes["rel"] = "stylesheet";
				linkElement.Attributes["type"] = "text/css";
				this.Page.Header.Controls.Add(linkElement);
			}
			string script = string.Format("var webModaRelease = {0};", HttpUtility.JavaScriptStringEncode(WebConfigSettings.Release, true));
			this.Page.ClientScript.RegisterStartupScript(typeof(BasePage), "releaseScript", script, true);
		}
	}
}