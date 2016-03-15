using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;
using EW.WebModaNetClassLibrary.Utils;
using NHibernate;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class Login : BasePage
	{
		protected Panel MessaggioHomePanel;

		protected Literal MessaggioHomeLiteral;

		protected HtmlGenericControl aggiornaDatabase;

		protected Literal AggiornaDatabaseLiteral;

		protected HtmlGenericControl warningSospensione;

		protected Literal WarningSospensioneLiteral;

		protected System.Web.UI.WebControls.Login LoginPanel;

		protected HtmlGenericControl divRichiediUtenza;

		protected HyperLink lnkRichiediPassword;

		protected Image imgRichiediPassword;

		public Login()
		{
		}

		private void GestioneAnnullamentoOrdiniSospesi()
		{
			StatoOrdine statoOrdineTemporaneo = base.StatoOrdineRepository.GetById(WebConfigSettings.CodiceStatoOrdineTemporaneo);
			StatoOrdine statoOrdineSospeso = base.StatoOrdineRepository.GetById(WebConfigSettings.CodiceStatoOrdineSospeso);
			StatoOrdine statoOrdineAnnullato = base.StatoOrdineRepository.GetById(WebConfigSettings.CodiceStatoOrdineAnnullato);
			base.OrdineRepository.AnnullaOrdiniSospesi(base.AgenteAutenticato, base.ImpostazioniGenerali.IdTipiOrdineAnnullamento, statoOrdineTemporaneo, statoOrdineSospeso, base.ImpostazioniGenerali.NumeroGiorniAnnullamentoOrdiniSospesi, statoOrdineAnnullato);
		}

		private void GestioneOrdiniCorrotti()
		{
			base.StatoOrdineRepository.GetById(WebConfigSettings.CodiceStatoOrdineTemporaneo);
			base.StatoOrdineRepository.GetById(WebConfigSettings.CodiceStatoOrdineSospeso);
			IOrdineRepository ordineRepository = base.OrdineRepository;
			Agente agenteAutenticato = base.AgenteAutenticato;
			string[] codiceStatoOrdineTemporaneo = new string[] { WebConfigSettings.CodiceStatoOrdineTemporaneo, WebConfigSettings.CodiceStatoOrdineSospeso };
			IList<Ordine> ordini = ordineRepository.GetOrdiniForAgenteByStato(agenteAutenticato, codiceStatoOrdineTemporaneo);
			List<DettaglioOrdine> dettagliOrdineCorrotti = new List<DettaglioOrdine>();
			foreach (Ordine ordine in ordini)
			{
				foreach (DettaglioOrdine dettaglioOrdine in ordine.Dettagli)
				{
					try
					{
						string codiceVariante = dettaglioOrdine.Variante.Codice;
					}
					catch (ObjectNotFoundException objectNotFoundException)
					{
						ObjectNotFoundException ex = objectNotFoundException;
						LogUtils.Warn(string.Format("Individuato un dettaglio ordine corrotto.\nCodice ordine: {0}, \n eccezione: {2}\nID dettaglio: {1}", ordine.Codice, dettaglioOrdine.Id, ex.Message));
						dettagliOrdineCorrotti.Add(dettaglioOrdine);
					}
				}
			}
			foreach (DettaglioOrdine dettaglioOrdineCorrotto in dettagliOrdineCorrotti)
			{
				base.DettaglioOrdineRepository.DeleteAndUpdateOrdine(dettaglioOrdineCorrotto, base.OrdineRepository);
			}
		}

		protected void LoginPanel_Authenticate(object sender, AuthenticateEventArgs e)
		{
			Agente agente = base.AgenteRepository.AuthenticateAgente(this.LoginPanel.UserName, this.LoginPanel.Password);
			if (agente == null)
			{
				e.Authenticated = false;
				this.LoginPanel.FailureText = Resources.ErroreLogin;
			}
			else if (!agente.Attivo)
			{
				e.Authenticated = false;
				this.LoginPanel.FailureText = Resources.ErroreAgenteNonAttivo;
			}
			else if (!(!base.ImpostazioniGenerali.IsApplicazioneSospesa ? true : agente.IsAmministratore(WebConfigSettings.CodiciTipoAgenteAmministratore)))
			{
				e.Authenticated = false;
				this.LoginPanel.FailureText = Resources.ErroreLoginSospensione;
			}
			else if (!agente.IsCliente(WebConfigSettings.CodiceTipoAgenteCliente))
			{
				e.Authenticated = true;
				this.Session["CurrentLanguage"] = agente.Lingua.Codice;
			}
			else
			{
				Cliente cliente = base.ClienteRepository.GetClienteForAgenteCliente(agente);
				if (cliente == null)
				{
					throw new Exception(string.Format(Resources.ErroreClienteCliente, base.AgenteAutenticato.CodiceUtente));
				}
				if (!cliente.IsBloccato())
				{
					e.Authenticated = true;
					this.Session["CurrentLanguage"] = agente.Lingua.Codice;
				}
				else
				{
					e.Authenticated = false;
					this.LoginPanel.FailureText = Resources.ErroreLoginClienteBloccato;
				}
			}
		}

		protected void LoginPanel_LoggedIn(object sender, EventArgs e)
		{
			Agente agente = base.AgenteRepository.GetFromUserName(this.LoginPanel.UserName);
			base.SetAgenteAutenticato(agente);
			base.SetStatoOnlineAgenteAutenticato(true);
			base.SetDataUltimoAccesso(DateTime.Now);
			base.SetDataUltimaOperazione(DateTime.Now);
			this.GestioneOrdiniCorrotti();
			this.GestioneAnnullamentoOrdiniSospesi();
			object item = base.RouteData.Values["loginNeutro"];
			if (item == null)
			{
				item = false;
			}
			bool isLoginNeutro = (bool)item;
			if ((WebConfigSettings.Release != "TShirtMakers" ? false : isLoginNeutro))
			{
				base.Response.Redirect("~/Default.aspx");
			}
		}

		protected void LoginPanel_LoginError(object sender, EventArgs e)
		{
			((HtmlGenericControl)this.LoginPanel.FindControl("erroreLogin")).Visible = true;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				if (!WebConfigSettings.IsOnline)
				{
					if (string.IsNullOrEmpty(Utils.GetCodiceUtenteDefault()))
					{
						base.Response.Redirect("~/InserisciNomeUtente.aspx");
					}
				}
				this.divRichiediUtenza.Visible = WebConfigSettings.OpzioneMostraRichiediUtenza;
				this.VerificaAggiornamentoDatabase();
				this.warningSospensione.Visible = base.ImpostazioniGenerali.IsApplicazioneSospesa;
				this.MessaggioHomeLiteral.Text = base.ImpostazioniGenerali.MessaggioHome;
				object item = base.RouteData.Values["loginNeutro"];
				if (item == null)
				{
					item = false;
				}
				bool isLoginNeutro = (bool)item;
				if ((WebConfigSettings.Release != "TShirtMakers" ? false : isLoginNeutro))
				{
					this.divRichiediUtenza.Visible = false;
				}
			}
		}

		private void VerificaAggiornamentoDatabase()
		{
			if (!WebConfigSettings.IsOnline)
			{
				IAgenteRepository agenteRepository = base.AgenteRepository;
				Expression<Func<Agente, bool>>[] expressionArray = new Expression<Func<Agente, bool>>[1];
				ParameterExpression parameterExpression = Expression.Parameter(typeof(Agente), "a");
				BinaryExpression binaryExpression = Expression.OrElse(Expression.OrElse(Expression.Equal(Expression.Property(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_Tipo").MethodHandle)), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceTipoAgenteAgente").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Equality", new Type[] { typeof(string), typeof(string) }).MethodHandle)), Expression.Equal(Expression.Property(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_Tipo").MethodHandle)), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceTipoAgenteCapoArea").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Equality", new Type[] { typeof(string), typeof(string) }).MethodHandle))), Expression.Equal(Expression.Property(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_Tipo").MethodHandle)), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceTipoAgenteCliente").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Equality", new Type[] { typeof(string), typeof(string) }).MethodHandle)));
				ParameterExpression[] parameterExpressionArray = new ParameterExpression[] { parameterExpression };
				expressionArray[0] = Expression.Lambda<Func<Agente, bool>>(binaryExpression, parameterExpressionArray);
				if (agenteRepository.CountAll(expressionArray) == 0)
				{
					this.aggiornaDatabase.Visible = true;
					this.AggiornaDatabaseLiteral.Text = string.Format(Resources.IstruzioniAggiornaDatabase, VirtualPathUtility.ToAbsolute("~/AggiornaDatabase.aspx"));
				}
			}
		}
	}
}