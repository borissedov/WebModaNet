using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class Ordini : ProtectedPage
	{
		protected Literal TitoloLiteral;

		protected HtmlGenericControl messaggioSuccesso;

		protected Literal MessaggioSuccessoLiteral;

		protected Panel MessaggioOrdineTemporaneoPanel;

		protected Literal MessaggioOrdineTemporaneoLiteral;

		protected HyperLink ModificaLink;

		protected LinkButton FiltriRicercaButton;

		protected Panel FiltriRicercaPanel;

		protected Literal RicercaClienteLiteral;

		protected Label TipoOrdineLabel;

		protected ListBox TipiOrdineList;

		protected Label MarchioLabel;

		protected ListBox MarchiList;

		protected Label StagioneLabel;

		protected ListBox StagioniList;

		protected Label StatoOrdineLabel;

		protected ListBox StatiOrdineList;

		protected Label DataInizioLabel;

		protected TextBox DataInizioTextBox;

		protected Label DataFineLabel;

		protected TextBox DataFineTextBox;

		protected HtmlGenericControl codiceCliente;

		protected Label CodiceClienteLabel;

		protected TextBox CodiceClienteTextBox;

		protected HtmlGenericControl ragioneSocialeCliente;

		protected Label RagioneSocialeClienteLabel;

		protected TextBox RagioneSocialeClienteTextBox;

		protected Label DataConsegnaInizioLabel;

		protected TextBox DataConsegnaInizioTextBox;

		protected Label DataConsegnaFineLabel;

		protected TextBox DataConsegnaFineTextBox;

		protected Button CercaButton;

		protected HtmlGenericControl nessunOrdineTrovato;

		protected Literal NessunOrdineTrovatoLiteral;

		protected Panel LegendaPanel;

		protected Literal LegendaLiteral;

		protected Literal TemporaneoLiteral;

		protected Literal SospesoLiteral;

		protected Literal ChiusoLiteral;

		protected Literal TrasmessoLiteral;

		protected GridView OrdiniGridView;

		private int numeroOrdiniTemporanei;

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
				return this.ViewState["SortExpression"] as string ?? "NumeroOrdine";
			}
			set
			{
				this.ViewState["SortExpression"] = value;
			}
		}

		protected int TotaleCapi
		{
			get
			{
				return (int)(this.ViewState["TotaleCapi"] ?? 0);
			}
			set
			{
				this.ViewState["TotaleCapi"] = value;
			}
		}

		protected decimal TotaleOrdini
		{
			get
			{
				return (decimal)(this.ViewState["TotaleOrdini"] ?? new decimal(0));
			}
			set
			{
				this.ViewState["TotaleOrdini"] = value;
			}
		}

		protected string TotaleOrdiniFormattato
		{
			get
			{
				return Utils.FormatNumber(this.TotaleOrdini, base.AgenteAutenticato);
			}
		}

		public Ordini()
		{
		}

		private void CaricaOrdini()
		{
			IList<Ordine> ordini;
			IList<Ordine> ordines;
			IList<Ordine> ordines1;
			this.ControllaOrdiniTemporanei();
			List<Expression<Func<Ordine, bool>>> filtri = new List<Expression<Func<Ordine, bool>>>()
			{
				(Ordine o) => o.Agente == this.AgenteAutenticato && o.CodiceAgente == this.AgenteAutenticato.CodiceAgente
			};
			DateTime minValue = DateTime.MinValue;
			if ((string.IsNullOrEmpty(this.DataInizioTextBox.Text) ? false : DateTime.TryParseExact(this.DataInizioTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out minValue)))
			{
				filtri.Add((Ordine o) => o.Data >= minValue);
			}
			DateTime dateTime = DateTime.MinValue;
			if ((string.IsNullOrEmpty(this.DataFineTextBox.Text) ? false : DateTime.TryParseExact(this.DataFineTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime)))
			{
				filtri.Add((Ordine o) => o.Data <= dateTime);
			}
			if (!string.IsNullOrEmpty(this.CodiceClienteTextBox.Text))
			{
				filtri.Add((Ordine o) => o.Cliente.Codice.Equals(this.CodiceClienteTextBox.Text));
			}
			if (!string.IsNullOrEmpty(this.RagioneSocialeClienteTextBox.Text))
			{
				filtri.Add((Ordine o) => o.Cliente.RagioneSociale1.Contains(this.RagioneSocialeClienteTextBox.Text) || o.Cliente.RagioneSociale2.Contains(this.RagioneSocialeClienteTextBox.Text));
			}
			if (!string.IsNullOrEmpty(this.TipiOrdineList.SelectedValue))
			{
				int[] array = (
					from v in this.TipiOrdineList.GetSelectedValues()
					select Convert.ToInt32(v)).ToArray<int>();
				filtri.Add((Ordine o) => array.Contains<int>(o.Tipo.Id));
			}
			if (!string.IsNullOrEmpty(this.MarchiList.SelectedValue))
			{
				string[] selectedValues = this.MarchiList.GetSelectedValues();
				filtri.Add((Ordine o) => selectedValues.Contains<string>(o.Marchio.Codice));
			}
			if (!string.IsNullOrEmpty(this.StagioniList.SelectedValue))
			{
				string[] strArrays = this.StagioniList.GetSelectedValues();
				filtri.Add((Ordine o) => o.Dettagli.Any<DettaglioOrdine>((DettaglioOrdine d) => strArrays.Contains<string>(d.Variante.Articolo.Stagione.Codice)));
			}
			if (!string.IsNullOrEmpty(this.StatiOrdineList.SelectedValue))
			{
				string[] selectedValues1 = this.StatiOrdineList.GetSelectedValues();
				filtri.Add((Ordine o) => selectedValues1.Contains<string>(o.Stato.Codice));
			}
			DateTime minValue1 = DateTime.MinValue;
			if ((string.IsNullOrEmpty(this.DataConsegnaInizioTextBox.Text) ? false : DateTime.TryParseExact(this.DataConsegnaInizioTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out minValue1)))
			{
				filtri.Add((Ordine o) => o.DataConsegna >= minValue1);
			}
			DateTime dateTime1 = DateTime.MinValue;
			if ((string.IsNullOrEmpty(this.DataConsegnaFineTextBox.Text) ? false : DateTime.TryParseExact(this.DataConsegnaFineTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime1)))
			{
				filtri.Add((Ordine o) => o.DataConsegna <= dateTime1);
			}
			filtri.Add((Ordine o) => o.Stato.Codice != WebConfigSettings.CodiceStatoOrdineAnnullato);
			filtri.Add((Ordine o) => o.Stato.Codice != WebConfigSettings.CodiceStatoOrdineEliminato);
			Expression<Func<Ordine, object>> keySelector = null;
			string sortExpression = this.SortExpression;
			if (sortExpression != null)
			{
				if (sortExpression == "CodiceGestionale")
				{
					keySelector = (Ordine o) => o.CodiceGestionale;
					ordini = base.OrdineRepository.FindAll(this.Descending, keySelector, filtri.ToArray());
					ordines = ordini;
					this.TotaleCapi = ordines.Sum<Ordine>((Ordine o) => o.NumeroCapi);
					ordines1 = ordini;
					this.TotaleOrdini = ordines1.Sum<Ordine>((Ordine o) => o.TotaleScontato);
					if (ordini.Count <= 0)
					{
						this.OrdiniGridView.Visible = false;
						this.nessunOrdineTrovato.Visible = true;
					}
					else
					{
						this.OrdiniGridView.Visible = true;
						this.nessunOrdineTrovato.Visible = false;
						this.OrdiniGridView.DataSource = ordini;
						this.OrdiniGridView.DataBind();
					}
					return;
				}
				else if (sortExpression == "Data")
				{
					keySelector = (Ordine o) => (object)o.Data;
					ordini = base.OrdineRepository.FindAll(this.Descending, keySelector, filtri.ToArray());
					ordines = ordini;
					this.TotaleCapi = ordines.Sum<Ordine>((Ordine o) => o.NumeroCapi);
					ordines1 = ordini;
					this.TotaleOrdini = ordines1.Sum<Ordine>((Ordine o) => o.TotaleScontato);
					if (ordini.Count <= 0)
					{
						this.OrdiniGridView.Visible = false;
						this.nessunOrdineTrovato.Visible = true;
					}
					else
					{
						this.OrdiniGridView.Visible = true;
						this.nessunOrdineTrovato.Visible = false;
						this.OrdiniGridView.DataSource = ordini;
						this.OrdiniGridView.DataBind();
					}
					return;
				}
				else
				{
					if (sortExpression != "Cliente")
					{
						goto Label2;
					}
					keySelector = (Ordine o) => o.Cliente.RagioneSociale1;
					ordini = base.OrdineRepository.FindAll(this.Descending, keySelector, filtri.ToArray());
					ordines = ordini;
					this.TotaleCapi = ordines.Sum<Ordine>((Ordine o) => o.NumeroCapi);
					ordines1 = ordini;
					this.TotaleOrdini = ordines1.Sum<Ordine>((Ordine o) => o.TotaleScontato);
					if (ordini.Count <= 0)
					{
						this.OrdiniGridView.Visible = false;
						this.nessunOrdineTrovato.Visible = true;
					}
					else
					{
						this.OrdiniGridView.Visible = true;
						this.nessunOrdineTrovato.Visible = false;
						this.OrdiniGridView.DataSource = ordini;
						this.OrdiniGridView.DataBind();
					}
					return;
				}
			}
			keySelector = (Ordine o) => (object)o.NumeroOrdine;
			ordini = base.OrdineRepository.FindAll(this.Descending, keySelector, filtri.ToArray());
			ordines = ordini;
			this.TotaleCapi = ordines.Sum<Ordine>((Ordine o) => o.NumeroCapi);
			ordines1 = ordini;
			this.TotaleOrdini = ordines1.Sum<Ordine>((Ordine o) => o.TotaleScontato);
			if (ordini.Count <= 0)
			{
				this.OrdiniGridView.Visible = false;
				this.nessunOrdineTrovato.Visible = true;
			}
			else
			{
				this.OrdiniGridView.Visible = true;
				this.nessunOrdineTrovato.Visible = false;
				this.OrdiniGridView.DataSource = ordini;
				this.OrdiniGridView.DataBind();
			}
		}

		protected void CercaButton_Click(object sender, EventArgs e)
		{
			this.CaricaOrdini();
		}

		private void ControllaOrdiniTemporanei()
		{
			IList<Ordine> ordiniTemporanei = base.OrdineRepository.GetOrdiniForAgenteByStato(WebConfigSettings.CodiceStatoOrdineTemporaneo, base.AgenteAutenticato);
			this.numeroOrdiniTemporanei = ordiniTemporanei.Count;
			if (this.numeroOrdiniTemporanei <= 0)
			{
				this.MessaggioOrdineTemporaneoPanel.Visible = false;
			}
			else
			{
				this.MessaggioOrdineTemporaneoPanel.Visible = true;
				this.ModificaLink.NavigateUrl = string.Concat("~/InserisciModificaTestata.aspx?codiceOrdine=", ordiniTemporanei[0].Codice);
			}
		}

		private void EliminaOrdine(Ordine ordine)
		{
			base.OrdineRepository.Delete(ordine);
			base.SuccessMessage = string.Format(Resources.MessaggioOrdineEliminato, ordine.NumeroOrdineVisibile);
			this.ShowSuccessMessage();
			this.CaricaOrdini();
		}

		protected void FiltriRicercaButton_Click(object sender, EventArgs e)
		{
			if (this.FiltriRicercaButton.CssClass.Contains("nascondiFiltri"))
			{
				this.FiltriRicercaPanel.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "none";
				this.FiltriRicercaButton.Text = Resources.MostraFiltriRicerca;
				this.FiltriRicercaButton.CssClass = this.FiltriRicercaButton.CssClass.Replace("nascondiFiltri", "mostraFiltri");
			}
			else if (this.FiltriRicercaButton.CssClass.Contains("mostraFiltri"))
			{
				this.FiltriRicercaPanel.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "block";
				this.FiltriRicercaButton.Text = Resources.NascondiFiltriRicerca;
				this.FiltriRicercaButton.CssClass = this.FiltriRicercaButton.CssClass.Replace("mostraFiltri", "nascondiFiltri");
			}
		}

		private void ModificaOrdine(Ordine ordine, bool vaiAlRiepilogo)
		{
			string url = string.Concat("~/InserisciModificaTestata.aspx?", WebConfigSettings.CodiceOrdineQueryStringKey, "=", base.Server.UrlEncode(ordine.Codice));
			if (vaiAlRiepilogo)
			{
				string[] codiceOrdineQueryStringKey = new string[] { "~/ModificaOrdine.aspx?", WebConfigSettings.CodiceOrdineQueryStringKey, "=", base.Server.UrlEncode(ordine.Codice), "#tabs-2" };
				url = string.Concat(codiceOrdineQueryStringKey);
			}
			if ((ordine.Stato.Codice == WebConfigSettings.CodiceStatoOrdineSospeso ? true : ordine.Stato.Codice == WebConfigSettings.CodiceStatoOrdineChiuso))
			{
				if ((!(ordine.Stato.Codice != WebConfigSettings.CodiceStatoOrdineTrasmesso) || !(ordine.Stato.Codice != WebConfigSettings.CodiceStatoOrdineElaborato) ? false : this.numeroOrdiniTemporanei == 0))
				{
					ordine.Stato = base.StatoOrdineRepository.GetById(WebConfigSettings.CodiceStatoOrdineTemporaneo);
					base.OrdineRepository.Save(ordine);
				}
			}
			base.Response.Redirect(url);
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
						if (commandName == "ModificaOrdine")
						{
							this.ModificaOrdine(ordine, false);
						}
						else if (commandName == "Riepilogo")
						{
							this.ModificaOrdine(ordine, true);
						}
						else if (commandName == "EliminaOrdine")
						{
							this.EliminaOrdine(ordine);
						}
						else if (commandName == "DuplicaOrdine")
						{
						}
					}
				}
			}
		}

		protected void OrdiniGridView_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			bool flag;
			GridViewRow row = e.Row;
			if (row.RowType == DataControlRowType.DataRow)
			{
				Ordine ordine = row.DataItem as Ordine;
				HyperLink stampaLink = row.FindControl("StampaLink") as HyperLink;
				ImageButton modificaButton = row.FindControl("ModificaOrdineButton") as ImageButton;
				ImageButton riepilogoButton = row.FindControl("RiepilogoButton") as ImageButton;
				ImageButton eliminaButton = row.FindControl("EliminaOrdineButton") as ImageButton;
				ImageButton duplicaButton = row.FindControl("DuplicaOrdineButton") as ImageButton;
				Literal ragioneSocialeCliente = row.FindControl("RagioneSocialeClienteLiteral") as Literal;
				Literal totaleScontatoLiteral = row.FindControl("TotaleScontatoLiteral") as Literal;
				Literal statoOrdineLiteral = row.FindControl("StatoOrdineLiteral") as Literal;
				if ((ordine == null || stampaLink == null || modificaButton == null || riepilogoButton == null || eliminaButton == null || duplicaButton == null || ragioneSocialeCliente == null || totaleScontatoLiteral == null ? false : statoOrdineLiteral != null))
				{
					bool isTemporaneo = ordine.Stato.Codice == WebConfigSettings.CodiceStatoOrdineTemporaneo;
					bool isSospeso = ordine.Stato.Codice == WebConfigSettings.CodiceStatoOrdineSospeso;
					bool isChiuso = ordine.Stato.Codice == WebConfigSettings.CodiceStatoOrdineChiuso;
					bool isTrasmesso = ordine.Stato.Codice == WebConfigSettings.CodiceStatoOrdineTrasmesso;
					bool isElaborato = ordine.Stato.Codice == WebConfigSettings.CodiceStatoOrdineElaborato;
					stampaLink.NavigateUrl = string.Concat("~/Stampa.aspx?codice=", base.Server.UrlEncode(ordine.Codice));
					stampaLink.Visible = (isSospeso || isChiuso || isTrasmesso ? true : isElaborato);
					ImageButton imageButton = modificaButton;
					ImageButton imageButton1 = riepilogoButton;
					if (isTemporaneo)
					{
						flag = true;
					}
					else
					{
						flag = (isTrasmesso || isElaborato ? false : this.numeroOrdiniTemporanei == 0);
					}
					bool flag1 = flag;
					imageButton1.Visible = flag;
					imageButton.Visible = flag1;
					eliminaButton.Visible = (isTrasmesso ? false : !isElaborato);
					duplicaButton.Visible = false;
					if (isTemporaneo)
					{
						row.CssClass = "temporaneo";
					}
					else if (isSospeso)
					{
						row.CssClass = "sospeso";
					}
					else if (isChiuso)
					{
						row.CssClass = "chiuso";
					}
					else if (isTrasmesso)
					{
						row.CssClass = "trasmesso";
					}
					else if (isElaborato)
					{
						row.CssClass = "elaborato";
					}
					ragioneSocialeCliente.Text = base.ClienteRepository.GetClientePerStampa(ordine).RagioneSociale;
					totaleScontatoLiteral.Text = Utils.FormatNumber(ordine.TotaleScontato, base.AgenteAutenticato);
					statoOrdineLiteral.Text = ordine.Stato.Descrizione.ToSafeTranslation();
				}
			}
			else if (row.RowType == DataControlRowType.Footer)
			{
				if (this.OrdiniGridView.PageIndex != this.OrdiniGridView.PageCount - 1)
				{
					row.Visible = false;
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
				this.ShowSuccessMessage();
				this.PopolaListe();
				if (base.AgenteAutenticato.IsCliente(WebConfigSettings.CodiceTipoAgenteCliente))
				{
					this.codiceCliente.Visible = false;
					this.ragioneSocialeCliente.Visible = false;
				}
				this.CaricaOrdini();
			}
		}

		private void PopolaListe()
		{
			this.TipiOrdineList.DataSource = 
				from t in base.AgenteAutenticato.GetTipiOrdine()
				orderby t.Id
				select t;
			this.TipiOrdineList.DataBind();
			this.MarchiList.DataSource = base.AgenteAutenticato.GetMarchi();
			this.MarchiList.DataBind();
			this.StagioniList.DataSource = 
				from s in base.AgenteAutenticato.GetStagioni()
				orderby s.Codice
				select s;
			this.StagioniList.DataBind();
			IRepository<StatoOrdine, string> statoOrdineRepository = base.StatoOrdineRepository;
			ParameterExpression parameterExpression = Expression.Parameter(typeof(StatoOrdine), "s");
			MemberExpression memberExpression = Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(StatoOrdine).GetMethod("get_Descrizione").MethodHandle));
			ParameterExpression[] parameterExpressionArray = new ParameterExpression[] { parameterExpression };
			Expression<Func<StatoOrdine, object>> expression = Expression.Lambda<Func<StatoOrdine, object>>(memberExpression, parameterExpressionArray);
			Expression<Func<StatoOrdine, bool>>[] expressionArray = new Expression<Func<StatoOrdine, bool>>[1];
			parameterExpression = Expression.Parameter(typeof(StatoOrdine), "s");
			BinaryExpression binaryExpression = Expression.AndAlso(Expression.NotEqual(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(StatoOrdine).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceStatoOrdineAnnullato").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Inequality", new Type[] { typeof(string), typeof(string) }).MethodHandle)), Expression.NotEqual(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(StatoOrdine).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceStatoOrdineEliminato").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Inequality", new Type[] { typeof(string), typeof(string) }).MethodHandle)));
			parameterExpressionArray = new ParameterExpression[] { parameterExpression };
			expressionArray[0] = Expression.Lambda<Func<StatoOrdine, bool>>(binaryExpression, parameterExpressionArray);
			IList<StatoOrdine> statiOrdine = statoOrdineRepository.FindAll(true, expression, expressionArray);
			this.StatiOrdineList.DataSource = 
				from s in statiOrdine
				select new { Codice = s.Codice, Descrizione = s.Descrizione.ToSafeTranslation() };
			this.StatiOrdineList.DataBind();
		}

		private void ShowSuccessMessage()
		{
			if (!string.IsNullOrEmpty(base.SuccessMessage))
			{
				this.messaggioSuccesso.Visible = true;
				this.MessaggioSuccessoLiteral.Text = base.SuccessMessage;
			}
		}
	}
}