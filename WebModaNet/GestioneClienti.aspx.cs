using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;

using System;
using System.Collections.Generic;
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
	public class GestioneClienti : AdminPage
	{
		protected Literal TitoloLiteral;

		protected Literal IstruzioniGestioneClientiLiteral;

		protected HtmlGenericControl messaggioErrore;

		protected Literal MessaggioErroreLiteral;

		protected Literal FiltriClientiLiteral;

		protected Label CodiceUtenteLabel;

		protected DropDownList CodiciUtentiDropDownList;

		protected HtmlGenericControl messaggioSuccesso;

		protected Literal MessaggioSuccessoLiteral;

		protected HtmlGenericControl nessunClienteTrovato;

		protected Literal NessunClienteTrovatoLiteral;

		protected GridView ClientiGridView;

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

		public GestioneClienti()
		{
		}

		private void CaricaClientiNonAgenti()
		{
			Agente agente = base.AgenteRepository.GetById(this.CodiciUtentiDropDownList.SelectedValue);
			if (agente == null)
			{
				this.ClientiGridView.Visible = false;
				this.nessunClienteTrovato.Visible = true;
			}
			else
			{
				Expression<Func<Cliente, object>> orderByClause = null;
				string sortExpression = this.SortExpression;
				if (sortExpression != null)
				{
					if (sortExpression != "RagioneSociale")
					{
						goto Label2;
					}
					orderByClause = (Cliente o) => o.RagioneSociale1;
					goto Label0;
				}
				orderByClause = (Cliente o) => o.Stato.Descrizione;
			Label0:
				IClienteRepository clienteRepository = base.ClienteRepository;
				Expression<Func<Cliente, object>>[] expressionArray = new Expression<Func<Cliente, object>>[] { orderByClause };
				IList<Cliente> clienti = clienteRepository.GetClientiNonAgenti(agente, !this.Descending, expressionArray);
				if (clienti.Count <= 0)
				{
					this.ClientiGridView.Visible = false;
					this.nessunClienteTrovato.Visible = true;
				}
				else
				{
					this.ClientiGridView.Visible = true;
					this.ClientiGridView.DataSource = clienti;
					this.ClientiGridView.DataBind();
				}
			}
		}

		private void CaricaCodiciUtenti()
		{
			DropDownList codiciUtentiDropDownList = this.CodiciUtentiDropDownList;
			IAgenteRepository agenteRepository = base.AgenteRepository;
			ParameterExpression parameterExpression = Expression.Parameter(typeof(Agente), "a");
			BinaryExpression binaryExpression = Expression.NotEqual(Expression.Property(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_Tipo").MethodHandle)), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceTipoAgenteCliente").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Inequality", new Type[] { typeof(string), typeof(string) }).MethodHandle));
			ParameterExpression[] parameterExpressionArray = new ParameterExpression[] { parameterExpression };
			Expression<Func<Agente, bool>> expression = Expression.Lambda<Func<Agente, bool>>(binaryExpression, parameterExpressionArray);
			Expression<Func<Agente, object>>[] expressionArray = new Expression<Func<Agente, object>>[1];
			parameterExpression = Expression.Parameter(typeof(Agente), "a");
			MemberExpression memberExpression = Expression.Property(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_Tipo").MethodHandle)), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Descrizione").MethodHandle));
			parameterExpressionArray = new ParameterExpression[] { parameterExpression };
			expressionArray[0] = Expression.Lambda<Func<Agente, object>>(memberExpression, parameterExpressionArray);
			codiciUtentiDropDownList.DataSource = 
				from a in agenteRepository.FindAll(expression, true, expressionArray)
				select a.CodiceUtente;
			this.CodiciUtentiDropDownList.DataBind();
		}

		protected void ClientiGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			this.ClientiGridView.PageIndex = e.NewPageIndex;
			this.CaricaClientiNonAgenti();
		}

		protected void ClientiGridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			string commandName = e.CommandName;
			if (commandName != null)
			{
				if (commandName == "CreaProfiloUtente")
				{
					Cliente cliente = base.ClienteRepository.GetById(e.CommandArgument.ToString());
					Agente agente = base.AgenteRepository.GetById(this.CodiciUtentiDropDownList.SelectedValue);
					if ((cliente == null ? false : agente != null))
					{
						try
						{
							string nuovoCodiceUtente = this.CreaProfiloUtente(cliente, agente);
							base.Response.Redirect(string.Concat("~/InserisciModificaAgente.aspx?codiceAgente=", base.Server.UrlEncode(nuovoCodiceUtente)));
						}
						catch (Exception exception1)
						{
							Exception exception = exception1;
							this.messaggioErrore.Visible = true;
							this.MessaggioErroreLiteral.Text = exception.Message;
						}
					}
				}
			}
		}

		protected void ClientiGridView_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			GridViewRow row = e.Row;
			if (row.RowType == DataControlRowType.DataRow)
			{
				Cliente cliente = e.Row.DataItem as Cliente;
				Literal indirizzoLiteral = row.FindControl("IndirizzoLiteral") as Literal;
				Literal cittaLiteral = row.FindControl("CittaLiteral") as Literal;
				Literal provinciaLiteral = row.FindControl("ProvinciaLiteral") as Literal;
				if ((cliente == null || indirizzoLiteral == null || cittaLiteral == null ? false : provinciaLiteral != null))
				{
					Indirizzo indirizzo = base.IndirizzoRepository.GetIndirizzoPredefinitoForCliente(cliente);
					indirizzoLiteral.Text = indirizzo.Via;
					cittaLiteral.Text = indirizzo.Citta;
					provinciaLiteral.Text = (indirizzo.Provincia != null ? indirizzo.Provincia.Descrizione : string.Empty);
				}
			}
		}

		protected void ClientiGridView_Sorting(object sender, GridViewSortEventArgs e)
		{
			this.Descending = !this.Descending;
			this.SortExpression = e.SortExpression;
			this.CaricaClientiNonAgenti();
		}

		protected void CodiciUtentiDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CaricaClientiNonAgenti();
		}

		private string CreaProfiloUtente(Cliente cliente, Agente agente)
		{
			IAgenteRepository agenteRepository = base.AgenteRepository;
			Expression<Func<Agente, bool>>[] expressionArray = new Expression<Func<Agente, bool>>[1];
			ParameterExpression parameterExpression = Expression.Parameter(typeof(Agente), "a");
			BinaryExpression binaryExpression = Expression.NotEqual(Expression.Property(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_Tipo").MethodHandle)), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceTipoAgenteExpertweb").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Inequality", new Type[] { typeof(string), typeof(string) }).MethodHandle));
			ParameterExpression[] parameterExpressionArray = new ParameterExpression[] { parameterExpression };
			expressionArray[0] = Expression.Lambda<Func<Agente, bool>>(binaryExpression, parameterExpressionArray);
			if (agenteRepository.FindAll(expressionArray).Count >= base.ImpostazioniGenerali.NumeroMassimoUtenti)
			{
				throw new Exception(Resources.ErroreLicenze);
			}
			Agente agenteCliente = new Agente()
			{
				CodiceUtente = string.Concat("CL", cliente.Codice)
			};
			int codiceAgente = 0;
			if (!int.TryParse(cliente.Codice, out codiceAgente))
			{
				throw new Exception(string.Format(Resources.ErroreCodiceClienteNumerico, cliente.Codice));
			}
			agenteCliente.CodiceAgente = codiceAgente;
			string p1 = cliente.RagioneSociale.Replace(" ", string.Empty);
			p1 = (p1.Length >= 3 ? p1.Substring(0, 3) : p1);
			string p2 = cliente.Codice;
			p2 = (p2.Length >= 3 ? p2.Substring(p2.Length - 3, 3) : p2);
			agenteCliente.Password = string.Concat(p1, p2);
			agenteCliente.RagioneSociale = cliente.RagioneSociale;
			agenteCliente.Tipo = base.TipoAgenteRepository.GetById(WebConfigSettings.CodiceTipoAgenteCliente);
			agenteCliente.Attivo = true;
			agenteCliente.Nazione = agente.Nazione;
			agenteCliente.Lingua = agente.Lingua;
			List<Valuta> valute = new List<Valuta>();
			valute.AddRange(agente.Valute);
			agenteCliente.Valute = valute;
			IList<ImpostazioneOrdine> impostazioniOrdine = new List<ImpostazioneOrdine>();
			foreach (ImpostazioneOrdine i in agente.ImpostazioniOrdine)
			{
				ImpostazioneOrdine impostazioneOrdine = new ImpostazioneOrdine()
				{
					TipoOrdine = i.TipoOrdine,
					Marchio = i.Marchio,
					ValoreMinimoOrdine = i.ValoreMinimoOrdine,
					CodiceListinoConsigliato = i.CodiceListinoConsigliato
				};
				impostazioniOrdine.Add(impostazioneOrdine);
			}
			agenteCliente.ImpostazioniOrdine = impostazioniOrdine;
			IList<ImpostazioneStagione> impostazioniStagione = new List<ImpostazioneStagione>();
			foreach (ImpostazioneStagione i in agente.ImpostazioniStagione)
			{
				ImpostazioneStagione impostazioneStagione = new ImpostazioneStagione()
				{
					Stagione = i.Stagione,
					Disponibilita = i.Disponibilita
				};
				impostazioniStagione.Add(impostazioneStagione);
			}
			agenteCliente.ImpostazioniStagione = impostazioniStagione;
			agenteCliente.NumeroDecimali = agente.NumeroDecimali;
			agenteCliente.CodicePoliticaSconti = cliente.CodicePoliticaSconti;
			agenteCliente.BloccoMetodoPagamento = agente.BloccoMetodoPagamento;
			agenteCliente.BloccoBanca = agente.BloccoBanca;
			agenteCliente.BloccoValuta = agente.BloccoValuta;
			agenteCliente.BloccoPorto = agente.BloccoPorto;
			agenteCliente.BloccoTrasporto = agente.BloccoTrasporto;
			agenteCliente.BloccoVettore = agente.BloccoVettore;
			agenteCliente.BloccoDataOrdine = agente.BloccoDataOrdine;
			agenteCliente.BloccoDateConsegna = agente.BloccoDateConsegna;
			base.AgenteRepository.Save(agenteCliente);
			return agenteCliente.CodiceUtente;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.CaricaCodiciUtenti();
			}
		}
	}
}