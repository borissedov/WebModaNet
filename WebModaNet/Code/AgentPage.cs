using EW.WebModaNetClassLibrary.Entities;
using System;
using System.Web;
using System.Web.UI;

namespace EW.WebModaNet.Code
{
	public class AgentPage : ProtectedPage
	{
		public AgentPage()
		{
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			if (base.AgenteAutenticato.Tipo.Codice == WebConfigSettings.CodiceTipoAgenteCliente)
			{
				base.Response.Redirect("~/Errors/AccessoNegato.aspx");
			}
		}
	}
}