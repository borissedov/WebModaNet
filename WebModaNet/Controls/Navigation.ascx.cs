using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet.Controls
{
	public class Navigation : UserControl
	{
		protected HtmlGenericControl navigation;

		protected HyperLink OrdiniLink;

		protected HyperLink InserisciOrdineLink;

		protected HyperLink ElencoOrdiniLink;

		protected HtmlGenericControl clientiMenu;

		protected HyperLink ClientiLink;

		protected HtmlGenericControl inserisciCliente;

		protected HyperLink InserisciClienteLink;

		protected HyperLink ElencoClientiLink;

		protected HtmlGenericControl areaDocumentaleMenu;

		protected HyperLink AreaDocumentaleLink;

		protected HtmlGenericControl nuoviIndirizziMenu;

		protected HyperLink NuoviIndirizziLink;

		protected HtmlGenericControl offlineMenu;

		protected HyperLink TrasmissioneOrdiniLink1;

		protected HyperLink TrasmissioneOrdiniLink2;

		protected HyperLink AggiornaApplicazioneLink;

		protected HyperLink AggiornaDatabaseLink;

		protected HyperLink AggiornaImmaginiLink;

		protected HtmlGenericControl manualeMenu;

		protected HyperLink ManualeLink;

		protected HtmlGenericControl cataloghiMenu;

		protected HyperLink CataloghiLink;

		protected Repeater rptCartelle;

		protected Repeater rptCataloghi;

		protected HtmlGenericControl adminMenu;

		protected HyperLink AdminLink;

		protected HyperLink ImpostazioniApplicazione;

		protected HyperLink GestioneAgentiLink;

		protected HyperLink CreaAggiornamentiLink;

		protected HyperLink GestioneGeneraleImpostazioniOrdini;

		protected HyperLink GestioneOrdiniLink;

		protected HyperLink GestioneClientiLink;

		public Navigation()
		{
		}

		private void MostraCataloghi()
		{
			if (!string.IsNullOrEmpty(WebConfigSettings.CartellaCataloghi))
			{
				string[] dirs = Directory.GetDirectories(base.Server.MapPath(WebConfigSettings.CartellaCataloghi));
				if ((int)dirs.Length > 0)
				{
					this.rptCartelle.DataSource = dirs;
					this.rptCartelle.DataBind();
				}
				string[] files = Directory.GetFiles(base.Server.MapPath(WebConfigSettings.CartellaCataloghi));
				if ((int)files.Length > 0)
				{
					this.rptCataloghi.DataSource = files;
					this.rptCataloghi.DataBind();
				}
				if (((int)files.Length != 0 ? false : (int)dirs.Length == 0))
				{
					this.cataloghiMenu.Visible = false;
				}
			}
			else
			{
				this.cataloghiMenu.Visible = false;
			}
		}

		private void MostraManuale()
		{
			string[] files = Directory.GetFiles(base.Server.MapPath(WebConfigSettings.CartellaManuali), "*.pdf");
			if ((int)files.Length <= 0)
			{
				this.manualeMenu.Visible = false;
			}
			else
			{
				FileInfo fileInfo = new FileInfo(files[0]);
				this.ManualeLink.NavigateUrl = string.Concat(WebConfigSettings.CartellaManuali, "/", fileInfo.Name);
			}
		}

		protected void onItemDataBoundCataloghi(object Sender, RepeaterItemEventArgs e)
		{
			if ((e.Item.ItemType == ListItemType.Item ? true : e.Item.ItemType == ListItemType.AlternatingItem))
			{
				FileInfo fileInfo = new FileInfo((string)e.Item.DataItem);
				HyperLink unLink = (HyperLink)e.Item.FindControl("itemLink");
				unLink.Text = fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf("."));
				unLink.NavigateUrl = this.Page.ResolveUrl(string.Concat("~/", fileInfo.FullName.Replace(HttpContext.Current.Request.PhysicalApplicationPath, "").Replace("\\\\", "/")));
			}
		}

		protected void onItemDataBoundRptCartelle(object Sender, RepeaterItemEventArgs e)
		{
			if ((e.Item.ItemType == ListItemType.Item ? true : e.Item.ItemType == ListItemType.AlternatingItem))
			{
				string unaDir = (string)e.Item.DataItem;
				DirectoryInfo dirInfo = new DirectoryInfo(unaDir);
				HyperLink unLink = (HyperLink)e.Item.FindControl("itemLink");
				unLink.Text = dirInfo.Name;
				Repeater rpt = (Repeater)e.Item.FindControl("rptCataloghiSub");
				rpt.DataSource = Directory.GetFiles(unaDir);
				rpt.DataBind();
			}
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			BasePage basePage = this.Page as BasePage;
			if (basePage != null)
			{
				Agente agenteAutenticato = basePage.AgenteAutenticato;
				if (agenteAutenticato != null)
				{
					if (!base.IsPostBack)
					{
						this.MostraManuale();
						this.MostraCataloghi();
						this.inserisciCliente.Visible = !basePage.ImpostazioniGenerali.BloccoNuoviClienti;
						this.clientiMenu.Visible = (!WebConfigSettings.OpzioneMostraMenuClienti ? false : !basePage.IsAgenteAutenticatoCliente());
						this.areaDocumentaleMenu.Visible = basePage.ImpostazioniGenerali.AttivaAreaDocumentale;
						this.nuoviIndirizziMenu.Visible = !basePage.ImpostazioniGenerali.BloccoIndirizziNuoviClientiVecchi;
						this.adminMenu.Visible = basePage.IsAgenteAutenticatoAmministratore();
						this.offlineMenu.Visible = !WebConfigSettings.IsOnline;
					}
					int numeroOrdiniTemporanei = basePage.OrdineRepository.GetNumeroOrdiniForAgenteByStato(WebConfigSettings.CodiceStatoOrdineTemporaneo, agenteAutenticato);
					this.InserisciOrdineLink.Visible = numeroOrdiniTemporanei == 0;
				}
				else
				{
					this.navigation.Visible = false;
				}
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.InserisciOrdineLink.NavigateUrl = (WebConfigSettings.TestataOrdineDefault ? "~/ModificaOrdine.aspx" : "~/InserisciModificaTestata.aspx");
		}
	}
}