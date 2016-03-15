using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class Default : ProtectedPage
	{
		protected Literal RagioneSocialeLiteral;

		protected Panel OrdineTemporaneoPanel;

		protected Literal OrdineTemporaneoLiteral;

		protected HyperLink OrdineTemporaneoLink;

		protected Panel NuovoOrdinePanel;

		protected HyperLink NuovoOrdineLink;

		protected HyperLink lnkPromozione1;

		protected Image imgPromozione1;

		protected HyperLink lnkPromozione2;

		protected Image imgPromozione2;

		protected HyperLink lnkPromozione3;

		protected Image imgPromozione3;

		protected HyperLink lnkPromozione4;

		protected Image imgPromozione4;

		protected HyperLink lnkPromozione5;

		protected Image imgPromozione5;

		protected HyperLink lnkPromozione6;

		protected Image imgPromozione6;

		protected HyperLink lnkPromozione7;

		protected Image imgPromozione7;

		protected HyperLink lnkPromozione8;

		protected Image imgPromozione8;

		protected HyperLink lnkPromozione9;

		protected Image imgPromozione9;

		protected HyperLink lnkPromozione10;

		protected Image imgPromozione10;

		protected HyperLink lnkPromozione11;

		protected Image imgPromozione11;

		protected HyperLink lnkPromozione12;

		protected Image imgPromozione12;

		protected HyperLink lnkPromozione13;

		protected Image imgPromozione13;

		protected HyperLink lnkPromozione14;

		protected Image imgPromozione14;

		protected HyperLink lnkPromozione15;

		protected Image imgPromozione15;

		protected HyperLink lnkPromozione16;

		protected Image imgPromozione16;

		protected HyperLink lnkPromozione17;

		protected Image imgPromozione17;

		protected HyperLink lnkPromozione18;

		protected Image imgPromozione18;

		protected HyperLink lnkPromozione19;

		protected Image imgPromozione19;

		protected HyperLink lnkPromozione20;

		protected Image imgPromozione20;

		protected HyperLink lnkPromozione21;

		protected Image imgPromozione21;

		protected HyperLink lnkPromozione22;

		protected Image imgPromozione22;

		protected HyperLink lnkPromozione23;

		protected Image imgPromozione23;

		protected HyperLink lnkPromozione24;

		protected Image imgPromozione24;

		protected HyperLink lnkPromozione25;

		protected Image imgPromozione25;

		protected HyperLink lnkPromozione26;

		protected Image imgPromozione26;

		protected HyperLink lnkPromozione27;

		protected Image imgPromozione27;

		protected HyperLink lnkPromozione28;

		protected Image imgPromozione28;

		protected HyperLink lnkPromozione29;

		protected Image imgPromozione29;

		protected HyperLink lnkPromozione30;

		protected Image imgPromozione30;

		protected HtmlGenericControl divContatto;

		protected Image ContattoImage;

		protected Literal ContattoRagioneSocialeLiteral;

		protected Literal ContattoCapCittaLiteral;

		protected HyperLink ContattoEmailLink;

		protected HyperLink ContattoTelefonoLink;

		protected HyperLink ContattoTelefono2Link;

		protected HyperLink lnkPromozione31;

		protected Image imgPromozione31;

		protected HyperLink lnkPromozione32;

		protected Image imgPromozione32;

		protected HyperLink lnkPromozione33;

		protected Image imgPromozione33;

		protected HyperLink lnkPromozione34;

		protected Image imgPromozione34;

		protected HyperLink lnkPromozione35;

		protected Image imgPromozione35;

		protected HyperLink lnkPromozione36;

		protected Image imgPromozione36;

		protected HyperLink lnkPromozione37;

		protected Image imgPromozione37;

		protected HyperLink lnkPromozione38;

		protected Image imgPromozione38;

		protected HyperLink lnkPromozione39;

		protected Image imgPromozione39;

		protected HyperLink lnkPromozione40;

		protected Image imgPromozione40;

		public Default()
		{
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			object[] cartellaImmaginiContatti;
			if (!base.IsPostBack)
			{
				if (!WebConfigSettings.ShowHomePage)
				{
					if (!base.IsAgenteAutenticatoAmministratore())
					{
						base.Response.Redirect("~/Ordini.aspx");
					}
					else
					{
						base.Response.Redirect("~/GestioneOrdini.aspx");
					}
				}
				string[] allowedExtensions = WebConfigSettings.AllowedImageExtensions;
				this.Page.Title = base.ImpostazioniGenerali.NomeApplicazione;
				this.RagioneSocialeLiteral.Text = base.AgenteAutenticato.RagioneSociale;
				Cliente cliente = base.ClienteRepository.GetClienteForAgenteCliente(base.AgenteAutenticato);
				if (cliente != null)
				{
					this.ContattoRagioneSocialeLiteral.Text = cliente.DescrizioneCommerciale;
					if (!string.IsNullOrEmpty(cliente.EmailCommerciale))
					{
						this.ContattoEmailLink.Text = string.Concat("email: ", cliente.EmailCommerciale);
						this.ContattoEmailLink.NavigateUrl = string.Concat("mailto:", cliente.EmailCommerciale);
					}
					if (!string.IsNullOrEmpty(cliente.TelCommerciale))
					{
						this.ContattoTelefonoLink.Text = cliente.TelCommerciale;
						this.ContattoTelefonoLink.NavigateUrl = string.Concat("callto://", cliente.TelCommerciale);
					}
					if (!string.IsNullOrEmpty(cliente.TelCommerciale2))
					{
						this.ContattoTelefono2Link.Text = cliente.TelCommerciale2;
						this.ContattoTelefono2Link.NavigateUrl = string.Concat("callto://", cliente.TelCommerciale2);
					}
					if (cliente.IdCommerciale > 0)
					{
						string[] strArrays = allowedExtensions;
						int num = 0;
						while (num < (int)strArrays.Length)
						{
							string extension = strArrays[num];
							cartellaImmaginiContatti = new object[] { base.Server.MapPath(WebConfigSettings.CartellaImmaginiContatti), Path.DirectorySeparatorChar, cliente.IdCommerciale, extension };
							if (!File.Exists(string.Concat(cartellaImmaginiContatti)))
							{
								num++;
							}
							else
							{
								this.ContattoImage.Visible = true;
								Image contattoImage = this.ContattoImage;
								cartellaImmaginiContatti = new object[] { WebConfigSettings.CartellaImmaginiContatti, "\\", cliente.IdCommerciale, extension };
								contattoImage.ImageUrl = string.Concat(cartellaImmaginiContatti);
								break;
							}
						}
					}
					this.divContatto.Visible = (!string.IsNullOrEmpty(cliente.DescrizioneCommerciale) || !string.IsNullOrEmpty(cliente.EmailCommerciale) || !string.IsNullOrEmpty(cliente.TelCommerciale) || !string.IsNullOrEmpty(cliente.TelCommerciale2) ? true : this.ContattoImage.Visible);
				}
				string codiceOrdineTemporaneo = string.Empty;
				IList<Ordine> ordiniTemporanei = base.OrdineRepository.GetOrdiniForAgenteByStato(WebConfigSettings.CodiceStatoOrdineTemporaneo, base.AgenteAutenticato);
				if (ordiniTemporanei.Count > 0)
				{
					if (ordiniTemporanei.Count > 1)
					{
						throw new Exception(Resources.ErroreOrdiniTemporanei);
					}
					Ordine ordineTemporaneo = ordiniTemporanei[0];
					codiceOrdineTemporaneo = base.Server.UrlEncode(ordineTemporaneo.Codice);
					this.OrdineTemporaneoPanel.Visible = true;
					this.OrdineTemporaneoLiteral.Text = string.Format(Resources.MessaggioOrdineTemporaneo, ordineTemporaneo.NumeroOrdineVisibile, ordineTemporaneo.Data);
					this.OrdineTemporaneoLink.NavigateUrl = (WebConfigSettings.TestataOrdineDefault ? string.Concat("~/ModificaOrdine.aspx?codiceOrdine=", codiceOrdineTemporaneo) : string.Concat("~/InserisciModificaTestata.aspx?codiceOrdine=", codiceOrdineTemporaneo));
				}
				else if (WebConfigSettings.TestataOrdineDefault)
				{
					this.NuovoOrdinePanel.Visible = true;
				}
				List<Expression<Func<Promozione, bool>>> filtriPromozioni = new List<Expression<Func<Promozione, bool>>>();
				DateTime date = DateTime.Now.Date;
				filtriPromozioni.Add((Promozione p) => (p.DataInizioValidita <= date) && (p.DataFineValidita >= date));
				IList<Promozione> listaPromozioni = base.PromozioneRepository.GetAll(filtriPromozioni.ToArray());
				Control mainContent = this.Page.Form.FindControl("MainContent");
				foreach (Promozione promozione in listaPromozioni)
				{
					string path = base.Server.MapPath(WebConfigSettings.CartellaImmaginiPromozioni);
					HyperLink lnk = (HyperLink)mainContent.FindControl(string.Concat("lnkPromozione", promozione.Posizione));
					Image img = (Image)mainContent.FindControl(string.Concat("imgPromozione", promozione.Posizione));
					if ((img == null ? false : lnk != null))
					{
						lnk.Visible = true;
						if (!(promozione.IdTipoCategoria <= 0 ? true : string.IsNullOrEmpty(promozione.CodiceCategoria)))
						{
							cartellaImmaginiContatti = new object[] { WebConfigSettings.CodiceOrdineQueryStringKey, codiceOrdineTemporaneo, promozione.IdTipoCategoria, promozione.CodiceCategoria };
							lnk.NavigateUrl = string.Format("~/ModificaOrdine.aspx?{0}={1}&tc={2}&cc={3}", cartellaImmaginiContatti);
						}
						else if (!string.IsNullOrEmpty(promozione.Url))
						{
							lnk.NavigateUrl = promozione.Url;
							lnk.Target = "_blank";
						}
						if (File.Exists(string.Concat(path, Path.DirectorySeparatorChar, promozione.NomeImmagine)))
						{
							img.Visible = true;
							img.ImageUrl = string.Concat(WebConfigSettings.CartellaImmaginiPromozioni, "\\", promozione.NomeImmagine);
						}
					}
				}
			}
		}
	}
}