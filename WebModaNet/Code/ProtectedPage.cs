using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace EW.WebModaNet.Code
{
	public class ProtectedPage : BasePage
	{
		public ProtectedPage()
		{
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			if (base.AgenteAutenticato == null)
			{
				FormsAuthentication.SignOut();
				FormsAuthentication.RedirectToLoginPage();
				base.Response.End();
			}
		}
	}
}