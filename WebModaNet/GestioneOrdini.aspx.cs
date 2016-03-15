using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class GestioneOrdini : AdminPage
	{
		protected Literal TitoloLiteral;

		protected Literal FiltriOrdiniLiteral;

		protected Label StatoOrdineLabel;

		protected DropDownList StatiOrdineList;

		protected Label DataInizioLabel;

		protected TextBox DataInizioTextBox;

		protected HtmlGenericControl messaggioSuccesso;

		protected Literal MessaggioSuccessoLiteral;

		protected HtmlGenericControl nessunOrdineTrovato;

		protected Literal NessunOrdineTrovatoLiteral;

		protected GridView OrdiniGridView;

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
				return this.ViewState["SortExpression"] as string ?? "Agente";
			}
			set
			{
				this.ViewState["SortExpression"] = value;
			}
		}

		public GestioneOrdini()
		{
		}

		private void CaricaOrdini()
		{
			IList<Ordine> ordini;
			List<Expression<Func<Ordine, bool>>> predicates = new List<Expression<Func<Ordine, bool>>>();
			string selectedValue = this.StatiOrdineList.SelectedValue;
			if (!string.IsNullOrEmpty(selectedValue))
			{
				predicates.Add((Ordine o) => o.Stato.Codice == selectedValue);
			}
			DateTime minValue = DateTime.MinValue;
			if ((string.IsNullOrEmpty(this.DataInizioTextBox.Text) ? false : DateTime.TryParseExact(this.DataInizioTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out minValue)))
			{
				predicates.Add((Ordine o) => o.Data >= minValue);
			}
			Expression<Func<Ordine, object>> orderByClause = null;
			string sortExpression = this.SortExpression;
			if (sortExpression != null)
			{
				switch (sortExpression)
				{
					case "TipoOrdine":
					{
						orderByClause = (Ordine o) => o.Tipo.Descrizione;
						break;
					}
					case "Stato":
					{
						orderByClause = (Ordine o) => o.Stato.Descrizione;
						break;
					}
					case "Data":
					{
						orderByClause = (Ordine o) => (object)o.Data;
						break;
					}
					case "NumeroOrdine":
					{
						orderByClause = (Ordine o) => (object)o.NumeroOrdine;
						break;
					}
					case "Cliente":
					{
						orderByClause = (Ordine o) => o.Cliente;
						break;
					}
					case "NumeroCapi":
					{
						orderByClause = (Ordine o) => (object)o.NumeroCapi;
						break;
					}
					case "Valuta":
					{
						orderByClause = (Ordine o) => o.Valuta.Descrizione;
						break;
					}
					case "Valore":
					{
						orderByClause = (Ordine o) => (object)o.Totale;
						break;
					}
					default:
					{
						orderByClause = (Ordine o) => o.Agente;
						ordini = base.OrdineRepository.FindAll(!this.Descending, orderByClause, predicates.ToArray());
						if (ordini.Count <= 0)
						{
							this.OrdiniGridView.Visible = false;
							this.nessunOrdineTrovato.Visible = true;
						}
						else
						{
							this.OrdiniGridView.Visible = true;
							this.OrdiniGridView.DataSource = ordini;
							this.OrdiniGridView.DataBind();
						}
						return;
					}
				}
			}
			else
			{
				orderByClause = (Ordine o) => o.Agente;
				ordini = base.OrdineRepository.FindAll(!this.Descending, orderByClause, predicates.ToArray());
				if (ordini.Count <= 0)
				{
					this.OrdiniGridView.Visible = false;
					this.nessunOrdineTrovato.Visible = true;
				}
				else
				{
					this.OrdiniGridView.Visible = true;
					this.OrdiniGridView.DataSource = ordini;
					this.OrdiniGridView.DataBind();
				}
				return;
			}
			ordini = base.OrdineRepository.FindAll(!this.Descending, orderByClause, predicates.ToArray());
			if (ordini.Count <= 0)
			{
				this.OrdiniGridView.Visible = false;
				this.nessunOrdineTrovato.Visible = true;
			}
			else
			{
				this.OrdiniGridView.Visible = true;
				this.OrdiniGridView.DataSource = ordini;
				this.OrdiniGridView.DataBind();
			}
		}

		private void CaricaStatiOrdine()
		{
			IList<StatoOrdine> stati = base.StatoOrdineRepository.FindAll(true, (StatoOrdine s) => s.Descrizione, new Expression<Func<StatoOrdine, bool>>[0]);
			this.StatiOrdineList.DataSource = 
				from s in stati
				select new { Codice = s.Codice, Descrizione = s.Descrizione.ToSafeTranslation() };
			this.StatiOrdineList.DataBind();
		}

		protected void DataInizioTextBox_TextChanged(object sender, EventArgs e)
		{
			this.CaricaOrdini();
		}

		private void EliminaOrdine(Ordine ordine)
		{
			ordine.Stato = base.StatoOrdineRepository.Find(WebConfigSettings.CodiceStatoOrdineEliminato);
			base.OrdineRepository.Save(ordine);
			base.SuccessMessage = string.Format(Resources.MessaggioOrdineEliminato, ordine.NumeroOrdineVisibile);
			this.ShowSuccessMessage();
			this.CaricaOrdini();
		}

		protected void OrdiniGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			this.OrdiniGridView.PageIndex = e.NewPageIndex;
			this.CaricaOrdini();
		}

		protected void OrdiniGridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandArgument != null)
			{
				string codiceOrdine = e.CommandArgument.ToString();
				Ordine ordine = base.OrdineRepository.GetById(codiceOrdine);
				if (ordine != null)
				{
					string commandName = e.CommandName;
					if (commandName != null)
					{
						if (commandName == "RipristinaOrdine")
						{
							this.RipristinaOrdine(ordine);
						}
						else if (commandName == "EliminaOrdine")
						{
							this.EliminaOrdine(ordine);
						}
					}
				}
			}
		}

		protected void OrdiniGridView_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			GridViewRow row = e.Row;
			if (row.RowType == DataControlRowType.DataRow)
			{
				Ordine ordine = row.DataItem as Ordine;
				ImageButton ripristinaButton = row.FindControl("RipristinaOrdineButton") as ImageButton;
				ImageButton eliminaButton = row.FindControl("EliminaOrdineButton") as ImageButton;
				Literal totaleScontatoLiteral = row.FindControl("TotaleScontatoLiteral") as Literal;
				HyperLink allegatoLink = row.FindControl("AllegatoLink") as HyperLink;
				if ((ordine == null || ripristinaButton == null || eliminaButton == null || totaleScontatoLiteral == null ? false : allegatoLink != null))
				{
					ripristinaButton.Visible = (ordine.Stato.Codice == WebConfigSettings.CodiceStatoOrdineAnnullato ? true : ordine.Stato.Codice == WebConfigSettings.CodiceStatoOrdineEliminato);
					eliminaButton.Visible = (ordine.Stato.Codice == WebConfigSettings.CodiceStatoOrdineTemporaneo || ordine.Stato.Codice == WebConfigSettings.CodiceStatoOrdineSospeso ? true : ordine.Stato.Codice == WebConfigSettings.CodiceStatoOrdineAnnullato);
					totaleScontatoLiteral.Text = Utils.FormatNumber(ordine.TotaleScontato, base.AgenteAutenticato);
					if (string.IsNullOrEmpty(ordine.NomeFileAllegato))
					{
						allegatoLink.Visible = false;
					}
					else
					{
						allegatoLink.NavigateUrl = string.Concat(WebConfigSettings.CartellaAllegati, "/", ordine.NomeFileAllegato);
					}
				}
			}
		}

		protected void OrdiniGridView_Sorting(object sender, GridViewSortEventArgs e)
		{
			this.Descending = !this.Descending;
			this.SortExpression = e.SortExpression;
			this.CaricaOrdini();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				TextBox dataInizioTextBox = this.DataInizioTextBox;
				DateTime now = DateTime.Now;
				dataInizioTextBox.Text = string.Format("{0:dd/MM/yyyy}", now.AddDays(-14));
				this.CaricaStatiOrdine();
				this.CaricaOrdini();
			}
		}

		private void RipristinaOrdine(Ordine ordine)
		{
			ordine.Stato = base.StatoOrdineRepository.GetById(WebConfigSettings.CodiceStatoOrdineSospeso);
			ordine.DataInserimento = DateTime.Now;
			base.OrdineRepository.Save(ordine);
			base.SuccessMessage = string.Format(Resources.MessaggioOrdineRipristinato, ordine.NumeroOrdineVisibile);
			this.ShowSuccessMessage();
			this.CaricaOrdini();
		}

		private void ShowSuccessMessage()
		{
			if (!string.IsNullOrEmpty(base.SuccessMessage))
			{
				this.messaggioSuccesso.Visible = true;
				this.MessaggioSuccessoLiteral.Text = base.SuccessMessage;
			}
		}

		protected void StatiOrdineList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CaricaOrdini();
		}
	}
}