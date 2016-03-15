using EW.WebModaNet.Code;
using EW.WebModaNet.ServiceEntities;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace EW.WebModaNet
{
	public class CreaAggiornamenti : BasePage
	{
		protected Literal CreaAggiornamentiLiteral;

		protected HtmlGenericControl nessunAgente;

		protected Literal NessunAgenteLiteral;

		protected Panel CreaAggiornamentiPanel;

		protected UpdatePanel CreaAggiornamentiUpdatePanel;

		protected HtmlGenericControl creaAggiornamentiInfoMessage;

		protected Literal IstruzioniCreaAggiornamentiLiteral;

		protected Button CreaAggiornamentiButton;

		protected HtmlGenericControl creaAggiornamentiSuccessMessage;

		protected Literal CreaAggiornamentiSuccessMessageLiteral;

		protected HtmlGenericControl creaAggiornamentiErrorMessage;

		protected Literal CreaAggiornamentiErrorMessageLiteral;

		protected UpdateProgress CreaAggiornamentiUpdateProgress;

		public CreaAggiornamenti()
		{
		}

		private bool CheckTaskKey()
		{
			return base.Request.QueryString["key"] == WebConfigSettings.TaskKey;
		}

		private void CreaAggiornamentiAgenti(IList<Agente> agentiDaAggiornare)
		{
			foreach (Agente agente in agentiDaAggiornare)
			{
				AggiornamentoDatabase aggiornamentoDatabase = base.AggiornamentoDatabaseRepository.Generate(agente, WebConfigSettings.IDTipoOrdineOffline, WebConfigSettings.FiltraDateConsegnaOffline);
				AggiornamentoDatabaseService aggiornamentoDatabaseService = ServerServiceUtils.ConvertAggiornamentoDatabaseToAggiornamentoDatabaseService(aggiornamentoDatabase);
				string xmlFileName = string.Format(WebConfigSettings.UpdateDBXmlFileName, base.Server.UrlEncode(agente.CodiceUtente));
				string xmlFilePath = Path.Combine(base.Server.MapPath(WebConfigSettings.ServerUpdateDirectory), xmlFileName);
				if (File.Exists(xmlFilePath))
				{
					File.Delete(xmlFilePath);
				}
				FileStream fileStream = File.OpenWrite(xmlFilePath);
				try
				{
					(new XmlSerializer(typeof(AggiornamentoDatabaseService))).Serialize(fileStream, aggiornamentoDatabaseService);
				}
				finally
				{
					if (fileStream != null)
					{
						((IDisposable)fileStream).Dispose();
					}
				}
				string zipFileName = string.Format(WebConfigSettings.UpdateDBZipFileName, base.Server.UrlEncode(agente.CodiceUtente));
				string zipFilePath = Path.Combine(base.Server.MapPath(WebConfigSettings.ServerUpdateDirectory), zipFileName);
				if (File.Exists(zipFilePath))
				{
					File.Delete(zipFilePath);
				}
				Utils.ZipFile(xmlFilePath, zipFilePath);
				if (File.Exists(xmlFilePath))
				{
					File.Delete(xmlFilePath);
				}
			}
		}

		protected void CreaAggiornamentiButton_Click(object sender, EventArgs e)
		{
			IAgenteRepository agenteRepository = base.AgenteRepository;
			Expression<Func<Agente, bool>>[] expressionArray = new Expression<Func<Agente, bool>>[1];
			ParameterExpression parameterExpression = Expression.Parameter(typeof(Agente), "a");
			MemberExpression memberExpression = Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_UtilizzaOffline").MethodHandle));
			ParameterExpression[] parameterExpressionArray = new ParameterExpression[] { parameterExpression };
			expressionArray[0] = Expression.Lambda<Func<Agente, bool>>(memberExpression, parameterExpressionArray);
			IList<Agente> agentiDaAggiornare = agenteRepository.FindAll(expressionArray);
			try
			{
				this.CreaAggiornamentiAgenti(agentiDaAggiornare);
				this.creaAggiornamentiInfoMessage.Visible = false;
				this.CreaAggiornamentiButton.Visible = false;
				this.creaAggiornamentiSuccessMessage.Visible = true;
				this.CreaAggiornamentiSuccessMessageLiteral.Text = Resources.MessaggioOperazioneCompletata;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				this.creaAggiornamentiErrorMessage.Visible = true;
				this.CreaAggiornamentiErrorMessageLiteral.Text = string.Format(Resources.ErroreGenericoDescrizione, exception.Message);
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				if (!this.CheckTaskKey())
				{
					if (!base.IsAgenteAutenticatoAmministratore())
					{
						base.Response.Redirect("~/Errors/AccessoNegato.aspx");
					}
					IAgenteRepository agenteRepository = base.AgenteRepository;
					Expression<Func<Agente, bool>>[] expressionArray = new Expression<Func<Agente, bool>>[1];
					ParameterExpression parameterExpression = Expression.Parameter(typeof(Agente), "a");
					MemberExpression memberExpression = Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_UtilizzaOffline").MethodHandle));
					ParameterExpression[] parameterExpressionArray = new ParameterExpression[] { parameterExpression };
					expressionArray[0] = Expression.Lambda<Func<Agente, bool>>(memberExpression, parameterExpressionArray);
					IList<Agente> agentiDaAggiornare = agenteRepository.FindAll(expressionArray);
					if (agentiDaAggiornare.Count != 0)
					{
						this.IstruzioniCreaAggiornamentiLiteral.Text = string.Format(Resources.IstruzioniCreaAggiornamenti, agentiDaAggiornare.Count);
					}
					else
					{
						this.nessunAgente.Visible = true;
						this.CreaAggiornamentiPanel.Visible = false;
					}
				}
				else
				{
					this.CreaAggiornamentiButton_Click(null, null);
				}
			}
		}
	}
}