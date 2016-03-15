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
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class Agenti : AdminPage
	{
		protected Literal TitoloLiteral;

		protected Literal FiltriAgenteLiteral;

		protected Label TipoAgenteLabel;

		protected DropDownList TipiAgenteList;

		protected Label CodiceUtenteLabel;

		protected TextBox CodiceUtenteTextBox;

		protected Button CercaButton;

		protected HtmlGenericControl erroreLicenze;

		protected Literal ErroreLicenzeLiteral;

		protected LinkButton NuovoAgenteButton;

		protected UpdateProgress AgentiUpdateProgress;

		protected UpdatePanel AgentiUpdatePanel;

		protected HtmlGenericControl nessunAgente;

		protected Literal NessunAgenteLiteral;

		protected HtmlGenericControl erroreElimina;

		protected Literal ErroreEliminaLiteral;

		protected HtmlGenericControl agenteEliminato;

		protected Literal AgenteEliminatoLiteral;

		protected GridView AgentiGridView;

		private bool Descending
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

		private string SortExpression
		{
			get
			{
				return this.ViewState["SortExpression"] as string ?? string.Empty;
			}
			set
			{
				this.ViewState["SortExpression"] = value;
			}
		}

		public Agenti()
		{
		}

		protected void AgentiGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			this.AgentiGridView.PageIndex = e.NewPageIndex;
			this.CaricaAgenti();
		}

		protected void AgentiGridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			bool flag;
			string commandArgument = e.CommandArgument as string;
			string commandName = e.CommandName;
			if (string.IsNullOrEmpty(commandArgument))
			{
				flag = true;
			}
			else
			{
				flag = (commandName == "ModificaAgente" ? false : !(commandName == "EliminaAgente"));
			}
			if (!flag)
			{
				Agente agente = base.AgenteRepository.GetById(commandArgument);
				if (agente != null)
				{
					string str = e.CommandName;
					if (str != null)
					{
						if (str == "ModificaAgente")
						{
							base.Response.Redirect(string.Concat("~/InserisciModificaAgente.aspx?codiceAgente=", base.Server.UrlEncode(agente.CodiceUtente)));
						}
						else if (str == "EliminaAgente")
						{
							this.EliminaAgente(agente);
						}
					}
				}
			}
		}

		protected void AgentiGridView_Sorting(object sender, GridViewSortEventArgs e)
		{
			this.SortExpression = e.SortExpression;
			this.Descending = !this.Descending;
			this.CaricaAgenti();
		}

		private void CaricaAgenti()
		{
			string selectedValue = this.TipiAgenteList.SelectedValue;
			string text = this.CodiceUtenteTextBox.Text;
			List<Expression<Func<Agente, bool>>> predicates = new List<Expression<Func<Agente, bool>>>();
			if (!string.IsNullOrEmpty(selectedValue))
			{
				predicates.Add((Agente a) => a.Tipo.Codice == selectedValue);
			}
			if (!string.IsNullOrEmpty(text))
			{
				predicates.Add((Agente a) => a.CodiceUtente.Contains(text));
			}
			predicates.Add((Agente a) => a.Tipo.Codice != WebConfigSettings.CodiceTipoAgenteExpertweb);
			Expression<Func<Agente, object>> orderByClause = (Agente a) => a.CodiceUtente;
			if (!string.IsNullOrEmpty(this.SortExpression))
			{
				string sortExpression = this.SortExpression;
				if (sortExpression != null)
				{
					switch (sortExpression)
					{
						case "Attivo":
						{
							orderByClause = (Agente a) => (object)a.Attivo;
							break;
						}
						case "Tipo":
						{
							orderByClause = (Agente a) => a.Tipo;
							break;
						}
						case "CodiceUtente":
						{
							orderByClause = (Agente a) => a.CodiceUtente;
							break;
						}
						case "CodiceAgente":
						{
							orderByClause = (Agente a) => (object)a.CodiceAgente;
							break;
						}
						case "RagioneSociale":
						{
							orderByClause = (Agente a) => a.RagioneSociale;
							break;
						}
						case "Online":
						{
							orderByClause = (Agente a) => a.RagioneSociale;
							break;
						}
						case "DataUltimaOperazione":
						{
							orderByClause = (Agente a) => (object)a.DataUltimaOperazione;
							break;
						}
					}
				}
			}
			IList<Agente> agenti = base.AgenteRepository.FindAll(!this.Descending, orderByClause, predicates.ToArray());
			if (agenti.Count <= 0)
			{
				this.AgentiGridView.Visible = false;
				this.nessunAgente.Visible = true;
			}
			else
			{
				this.AgentiGridView.Visible = true;
				this.AgentiGridView.DataSource = agenti;
				this.AgentiGridView.DataBind();
			}
		}

		private void CaricaTipiAgenti()
		{
			DropDownList tipiAgenteList = this.TipiAgenteList;
			IRepository<TipoAgente, string> tipoAgenteRepository = base.TipoAgenteRepository;
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TipoAgente), "t");
			MemberExpression memberExpression = Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Descrizione").MethodHandle));
			ParameterExpression[] parameterExpressionArray = new ParameterExpression[] { parameterExpression };
			Expression<Func<TipoAgente, object>> expression = Expression.Lambda<Func<TipoAgente, object>>(memberExpression, parameterExpressionArray);
			Expression<Func<TipoAgente, bool>>[] expressionArray = new Expression<Func<TipoAgente, bool>>[1];
			parameterExpression = Expression.Parameter(typeof(TipoAgente), "t");
			BinaryExpression binaryExpression = Expression.NotEqual(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceTipoAgenteExpertweb").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Inequality", new Type[] { typeof(string), typeof(string) }).MethodHandle));
			parameterExpressionArray = new ParameterExpression[] { parameterExpression };
			expressionArray[0] = Expression.Lambda<Func<TipoAgente, bool>>(binaryExpression, parameterExpressionArray);
			tipiAgenteList.DataSource = tipoAgenteRepository.FindAll(true, expression, expressionArray);
			this.TipiAgenteList.DataBind();
		}

		protected void CercaButton_Click(object sender, EventArgs e)
		{
			this.CaricaAgenti();
		}

		private void EliminaAgente(Agente agente)
		{
			if (agente == null)
			{
				throw new ArgumentNullException("agente");
			}
			if (!WebConfigSettings.CodiciTipoAgenteAmministratore.Contains<string>(agente.Tipo.Codice))
			{
				base.AgenteRepository.Delete(agente);
				this.agenteEliminato.Visible = true;
				this.AgenteEliminatoLiteral.Text = string.Format(Resources.MessaggioAgenteEliminato, agente.RagioneSociale);
				this.CaricaAgenti();
			}
			else
			{
				this.erroreElimina.Visible = true;
			}
		}

		private void ImpostaStatoOffline()
		{
			bool flag;
			IAgenteRepository agenteRepository = base.AgenteRepository;
			Expression<Func<Agente, bool>>[] expressionArray = new Expression<Func<Agente, bool>>[1];
			ParameterExpression parameterExpression = Expression.Parameter(typeof(Agente), "a");
			MemberExpression memberExpression = Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_Online").MethodHandle));
			ParameterExpression[] parameterExpressionArray = new ParameterExpression[] { parameterExpression };
			expressionArray[0] = Expression.Lambda<Func<Agente, bool>>(memberExpression, parameterExpressionArray);
			foreach (Agente agente in agenteRepository.FindAll(expressionArray))
			{
				DateTime? dataUltimaOperazione = agente.DataUltimaOperazione;
				if (!dataUltimaOperazione.HasValue)
				{
					flag = true;
				}
				else
				{
					dataUltimaOperazione = agente.DataUltimaOperazione;
					DateTime now = DateTime.Now;
					now = now.AddMinutes((double)((this.Session.Timeout + 5) * -1));
					flag = (dataUltimaOperazione.HasValue ? (dataUltimaOperazione.GetValueOrDefault() < now) ? 1 : 0 : 0) == 0;
				}
				if (!flag)
				{
					agente.Online = false;
					base.AgenteRepository.Save(agente);
				}
			}
		}

		protected bool IsAttivo(object isAttivo)
		{
			return Convert.ToBoolean(isAttivo);
		}

		protected bool IsOnline(object isOnline)
		{
			return Convert.ToBoolean(isOnline);
		}

		protected void NuovoAgenteButton_Click(object sender, EventArgs e)
		{
			IAgenteRepository agenteRepository = base.AgenteRepository;
			Expression<Func<Agente, bool>>[] expressionArray = new Expression<Func<Agente, bool>>[1];
			ParameterExpression parameterExpression = Expression.Parameter(typeof(Agente), "a");
			BinaryExpression binaryExpression = Expression.OrElse(Expression.OrElse(Expression.OrElse(Expression.Equal(Expression.Property(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_Tipo").MethodHandle)), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceTipoAgenteAmministratore").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Equality", new Type[] { typeof(string), typeof(string) }).MethodHandle)), Expression.Equal(Expression.Property(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_Tipo").MethodHandle)), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceTipoAgenteAgente").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Equality", new Type[] { typeof(string), typeof(string) }).MethodHandle))), Expression.Equal(Expression.Property(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_Tipo").MethodHandle)), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceTipoAgenteCapoArea").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Equality", new Type[] { typeof(string), typeof(string) }).MethodHandle))), Expression.Equal(Expression.Property(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_Tipo").MethodHandle)), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceTipoAgenteCliente").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Equality", new Type[] { typeof(string), typeof(string) }).MethodHandle)));
			ParameterExpression[] parameterExpressionArray = new ParameterExpression[] { parameterExpression };
			expressionArray[0] = Expression.Lambda<Func<Agente, bool>>(binaryExpression, parameterExpressionArray);
			if (agenteRepository.GetAll(expressionArray).Count < base.ImpostazioniGenerali.NumeroMassimoUtenti)
			{
				base.Response.Redirect("~/InserisciModificaAgente.aspx");
			}
			else
			{
				this.erroreLicenze.Visible = true;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.ImpostaStatoOffline();
				this.CaricaTipiAgenti();
				this.CaricaAgenti();
			}
		}

		protected void TipiAgenteList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CaricaAgenti();
		}
	}
}