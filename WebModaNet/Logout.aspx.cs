using EW.WebModaNet.Code;
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace EW.WebModaNet
{
	public class Logout : BasePage
	{
		public Logout()
		{
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			base.SetStatoOnlineAgenteAutenticato(false);
			base.RemoveAgenteAutenticato();
			FormsAuthentication.SignOut();
			base.Response.Redirect("~/Login.aspx");
		}
	}
}