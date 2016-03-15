using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using System;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet.Controls
{
	public class Header : UserControl
	{
		protected HtmlGenericControl pageHeader;

		protected HyperLink HomeLink;

		protected Literal TitoloSitoLiteral;

		protected PlaceHolder LoginPlaceHolder;

		protected Literal WelcomeLiteral;

		protected Literal AgenteLiteral;

		protected HyperLink LogoutLink;

		protected Literal TodayLiteral;

		protected Literal DateLiteral;

		public Header()
		{
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				BasePage basePage = this.Page as BasePage;
				if (basePage != null)
				{
					Agente agenteAutenticato = basePage.AgenteAutenticato;
					if (agenteAutenticato != null)
					{
						this.LoginPlaceHolder.Visible = true;
						this.AgenteLiteral.Text = agenteAutenticato.ToString();
					}
					this.DateLiteral.Text = string.Format("{0:D}", DateTime.Now);
				}
				object item = this.Page.RouteData.Values["loginNeutro"];
				if (item == null)
				{
					item = false;
				}
				bool isLoginNeutro = (bool)item;
				if ((WebConfigSettings.Release != "TShirtMakers" ? false : isLoginNeutro))
				{
					this.pageHeader.Visible = false;
				}
			}
		}
	}
}