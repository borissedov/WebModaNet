using System;
using System.Web;
using System.Web.UI;

namespace EW.WebModaNet.Code
{
	public class OfflinePage : ProtectedPage
	{
		public OfflinePage()
		{
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			if (WebConfigSettings.IsOnline)
			{
				base.Response.Redirect("~/Errors/AccessoNegato.aspx");
			}
		}
	}
}