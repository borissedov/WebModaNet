using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class Clienti : AgentPage
	{
		protected Literal TitoloLiteral;

		protected HtmlGenericControl nessunCliente;

		protected Literal NessunClienteLiteral;

		protected HyperLink NuovoClienteLink1;

		protected HtmlGenericControl successMessage;

		protected Literal SuccessMessageLiteral;

		protected GridView ClientiGridView;

		protected HyperLink NuovoClienteLink2;

		protected bool Descending
		{
			get
			{
				object item = this.ViewState["Descending"];
				if (item == null)
				{
					item = false;
				}
				return (bool)item;
			}
			set
			{
				this.ViewState["Descending"] = value;
			}
		}

		protected string SortExpression
		{
			get
			{
				return this.ViewState["SortExpression"] as string ?? "RagioneSociale";
			}
			set
			{
				this.ViewState["SortExpression"] = value;
			}
		}

		public Clienti()
		{
		}

		private void CaricaClienti()
		{
			IList<Cliente> clienti;
			Expression<Func<Cliente, object>> orderByClause = null;
			string sortExpression = this.SortExpression;
			if (sortExpression != null)
			{
				if (sortExpression != "Codice")
				{
					orderByClause = (Cliente c) => c.RagioneSociale1;
					clienti = base.ClienteRepository.GetClientiAttiviForAgente(base.AgenteAutenticato, orderByClause, this.Descending, true);
					if (clienti.Count <= 0)
					{
						this.ClientiGridView.Visible = false;
						this.nessunCliente.Visible = true;
					}
					else
					{
						this.ClientiGridView.Visible = true;
						this.nessunCliente.Visible = false;
						this.ClientiGridView.DataSource = clienti;
						this.ClientiGridView.DataBind();
					}
					return;
				}
				orderByClause = (Cliente c) => c.Codice;
				clienti = base.ClienteRepository.GetClientiAttiviForAgente(base.AgenteAutenticato, orderByClause, this.Descending, true);
				if (clienti.Count <= 0)
				{
					this.ClientiGridView.Visible = false;
					this.nessunCliente.Visible = true;
				}
				else
				{
					this.ClientiGridView.Visible = true;
					this.nessunCliente.Visible = false;
					this.ClientiGridView.DataSource = clienti;
					this.ClientiGridView.DataBind();
				}
				return;
			}
			orderByClause = (Cliente c) => c.RagioneSociale1;
			clienti = base.ClienteRepository.GetClientiAttiviForAgente(base.AgenteAutenticato, orderByClause, this.Descending, true);
			if (clienti.Count <= 0)
			{
				this.ClientiGridView.Visible = false;
				this.nessunCliente.Visible = true;
			}
			else
			{
				this.ClientiGridView.Visible = true;
				this.nessunCliente.Visible = false;
				this.ClientiGridView.DataSource = clienti;
				this.ClientiGridView.DataBind();
			}
		}

		protected void ClientiGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			this.ClientiGridView.PageIndex = e.NewPageIndex;
			this.CaricaClienti();
		}

		protected void ClientiGridView_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			string str;
			GridViewRow row = e.Row;
			Cliente cliente = e.Row.DataItem as Cliente;
			Literal indirizzoLiteral = row.FindControl("IndirizzoLiteral") as Literal;
			Literal cittaLiteral = row.FindControl("CittaLiteral") as Literal;
			Literal provinciaLiteral = row.FindControl("ProvinciaLiteral") as Literal;
			Image insolutoImage = row.FindControl("InsolutoImage") as Image;
			Image ratingImage = row.FindControl("RatingImage") as Image;
			if ((cliente == null || indirizzoLiteral == null || cittaLiteral == null || provinciaLiteral == null || insolutoImage == null ? false : ratingImage != null))
			{
				Indirizzo indirizzo = cliente.GetIndirizzoPredefinito();
				indirizzoLiteral.Text = indirizzo.Via;
				cittaLiteral.Text = indirizzo.Citta;
				provinciaLiteral.Text = (indirizzo.Provincia != null ? indirizzo.Provincia.Descrizione : string.Empty);
				if (!cliente.Insoluto)
				{
					insolutoImage.ImageUrl = "~/Images/green-circle.png";
					string nonInsoluto = Resources.NonInsoluto;
					str = nonInsoluto;
					insolutoImage.ToolTip = nonInsoluto;
					insolutoImage.AlternateText = str;
				}
				else
				{
					insolutoImage.ImageUrl = "~/Images/red-circle.png";
					string insoluto = Resources.Insoluto;
					str = insoluto;
					insolutoImage.ToolTip = insoluto;
					insolutoImage.AlternateText = str;
				}
				switch (cliente.CodiceSituazione)
				{
					case 0:
					{
						ratingImage.ImageUrl = "~/Images/green-square.png";
						string consegneRegolari = Resources.ConsegneRegolari;
						str = consegneRegolari;
						ratingImage.ToolTip = consegneRegolari;
						ratingImage.AlternateText = str;
						break;
					}
					case 1:
					{
						ratingImage.ImageUrl = "~/Images/blue-square.png";
						string ricezioneOrdiniBloccata = Resources.RicezioneOrdiniBloccata;
						str = ricezioneOrdiniBloccata;
						ratingImage.ToolTip = ricezioneOrdiniBloccata;
						ratingImage.AlternateText = str;
						break;
					}
					case 2:
					{
						ratingImage.ImageUrl = "~/Images/red-square.png";
						string imballoMerceSospesa = Resources.ImballoMerceSospesa;
						str = imballoMerceSospesa;
						ratingImage.ToolTip = imballoMerceSospesa;
						ratingImage.AlternateText = str;
						break;
					}
					case 3:
					{
						ratingImage.ImageUrl = "~/Images/orange-square.png";
						string spedizioneBloccata = Resources.SpedizioneBloccata;
						str = spedizioneBloccata;
						ratingImage.ToolTip = spedizioneBloccata;
						ratingImage.AlternateText = str;
						break;
					}
					case 4:
					case 5:
					{
						ratingImage.ImageUrl = "~/Images/green-square.png";
						string consegneRegolari1 = Resources.ConsegneRegolari;
						str = consegneRegolari1;
						ratingImage.ToolTip = consegneRegolari1;
						ratingImage.AlternateText = str;
						break;
					}
					case 6:
					{
						ratingImage.ImageUrl = "~/Images/black-square.png";
						string praticaLegale = Resources.PraticaLegale;
						str = praticaLegale;
						ratingImage.ToolTip = praticaLegale;
						ratingImage.AlternateText = str;
						break;
					}
					case 7:
					{
						ratingImage.ImageUrl = "~/Images/white-square.png";
						string clienteInattivo = Resources.ClienteInattivo;
						str = clienteInattivo;
						ratingImage.ToolTip = clienteInattivo;
						ratingImage.AlternateText = str;
						break;
					}
					default:
					{
						goto case 5;
					}
				}
			}
		}

		protected void ClientiGridView_Sorting(object sender, GridViewSortEventArgs e)
		{
			this.Descending = !this.Descending;
			this.SortExpression = e.SortExpression;
			this.CaricaClienti();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.WriteSuccessMessage();
				this.CaricaClienti();
			}
		}

		private void WriteSuccessMessage()
		{
			if (!string.IsNullOrEmpty(base.SuccessMessage))
			{
				this.successMessage.Visible = true;
				this.SuccessMessageLiteral.Text = base.SuccessMessage;
			}
		}
	}
}