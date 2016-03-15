using System;
using System.Web;
using System.Web.UI;

namespace EW.WebModaNet.Code
{
	public class AdminPage : ProtectedPage
	{
		public AdminPage()
		{
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			if (!base.IsAgenteAutenticatoAmministratore())
			{
				base.Response.Redirect("~/Errors/AccessoNegato.aspx");
			}
		}
	}
}