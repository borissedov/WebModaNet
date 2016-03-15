using EW.WebModaNet.Code;
using EW.WebModaNet.TrasmissioneOrdiniReference;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;
using EW.WebModaNetClassLibrary.Utils;

using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class TrasmissioneOrdini : OfflinePage
	{
		protected Literal TitoloLiteral;

		protected HtmlGenericControl necessarioAggiornamento;

		protected Literal NecessarioAggiornamentoLiteral;

		protected HtmlGenericControl infoMessage;

		protected Literal InfoMessageLiteral;

		protected HtmlGenericControl connectionErrorMessage;

		protected Literal ConnectionErrorMessageLiteral;

		protected Panel TrasmissioneOrdiniPanel;

		protected UpdatePanel TrasmissioneOrdiniUpdatePanel;

		protected HtmlGenericControl istruzioniTrasmissione;

		protected Literal IstruzioniTrasmissioneOrdiniLiteral;

		protected HtmlGenericControl successMessage;

		protected Literal SuccessMessageLiteral;

		protected HtmlGenericControl errorMessage;

		protected Literal ErrorMessageLiteral;

		protected HtmlGenericControl trasmettiButtonContainer;

		protected Button TrasmettiButton;

		protected HtmlGenericControl ordiniInfo;

		protected Literal OrdiniInfoLiteral;

		protected HtmlGenericControl esitoOrdini;

		protected Literal EsitoOrdiniLiteral;

		protected Repeater OrdiniResponseRepeater;

		protected HtmlGenericControl clientiInfo;

		protected Literal ClientiInfoLiteral;

		protected HtmlGenericControl esitoClienti;

		protected Literal EsitoClientiLiteral;

		protected Repeater ClientiResponseRepeater;

		protected UpdateProgress TrasmissioneOrdiniUpdateProgress;

		protected HyperLink TornaIndietroLink;

		public TrasmissioneOrdini()
		{
		}

		private void HandleClientiSuccess(ClienteResponseService[] clienti)
		{
			List<string> messaggi = new List<string>();
			ClienteResponseService[] clienteResponseServiceArray = clienti;
			for (int i = 0; i < (int)clienteResponseServiceArray.Length; i++)
			{
				ClienteResponseService cliente = clienteResponseServiceArray[i];
				switch (cliente.Stato)
				{
					case StatoTrasmissioneService.Trasmesso:
					{
						this.SetClienteTrasmesso(cliente);
						messaggi.Add(string.Format(Resources.EsitoCliente, cliente.Codice, "trasmesso", Resources.Trasmesso));
						break;
					}
					case StatoTrasmissioneService.NonTrasmesso:
					{
						messaggi.Add(string.Format(Resources.EsitoCliente, cliente.Codice, "nonTrasmesso", Resources.NonTrasmesso));
						break;
					}
					case StatoTrasmissioneService.GiaTrasmesso:
					{
						this.SetClienteTrasmesso(cliente);
						messaggi.Add(string.Format(Resources.EsitoCliente, cliente.Codice, "giaTrasmesso", Resources.GiaTrasmesso));
						break;
					}
				}
			}
			if (messaggi.Count <= 0)
			{
				this.clientiInfo.Visible = true;
				this.ClientiInfoLiteral.Text = Resources.NessunClienteDaTrasmettere;
			}
			else
			{
				this.esitoClienti.Visible = true;
				this.ClientiResponseRepeater.Visible = true;
				this.ClientiResponseRepeater.DataSource = messaggi;
				this.ClientiResponseRepeater.DataBind();
			}
		}

		private void HandleOrdiniSuccess(OrdineResponseService[] ordini)
		{
			List<string> messaggi = new List<string>();
			OrdineResponseService[] ordineResponseServiceArray = ordini;
			for (int i = 0; i < (int)ordineResponseServiceArray.Length; i++)
			{
				OrdineResponseService ordine = ordineResponseServiceArray[i];
				switch (ordine.Stato)
				{
					case StatoTrasmissioneService.Trasmesso:
					{
						this.SetOrdineTrasmesso(ordine);
						messaggi.Add(string.Format(Resources.EsitoOrdine, ordine.Codice, "trasmesso", Resources.Trasmesso));
						break;
					}
					case StatoTrasmissioneService.NonTrasmesso:
					{
						messaggi.Add(string.Format(Resources.EsitoOrdine, ordine.Codice, "nonTrasmesso", Resources.NonTrasmesso));
						break;
					}
					case StatoTrasmissioneService.GiaTrasmesso:
					{
						this.SetOrdineTrasmesso(ordine);
						messaggi.Add(string.Format(Resources.EsitoOrdine, ordine.Codice, "giaTrasmesso", Resources.GiaTrasmesso));
						break;
					}
				}
			}
			if (messaggi.Count <= 0)
			{
				this.ordiniInfo.Visible = true;
				this.OrdiniInfoLiteral.Text = Resources.NessunOrdineDaTrasmettere;
			}
			else
			{
				this.esitoOrdini.Visible = true;
				this.OrdiniResponseRepeater.Visible = true;
				this.OrdiniResponseRepeater.DataSource = messaggi;
				this.OrdiniResponseRepeater.DataBind();
			}
		}

		private void HandleServerResponse(TrasmissioneOrdiniResponseService response)
		{
			switch (response.Esito)
			{
				case EsitoTrasmissioneService.OK:
				{
					this.HandleSuccess(response);
					break;
				}
				case EsitoTrasmissioneService.KO:
				{
					this.errorMessage.Visible = true;
					this.ErrorMessageLiteral.Text = string.Format(Resources.TrasmissioneErrore, response.Messaggio);
					LogUtils.Warn(string.Format("Trasmissione ordini completata con esito negativo. Descrizione tecnica dell'errore: {0}.", response.Messaggio));
					break;
				}
			}
		}

		private void HandleSuccess(TrasmissioneOrdiniResponseService response)
		{
			this.HandleOrdiniSuccess(response.Ordini);
			this.HandleClientiSuccess(response.Clienti);
			this.successMessage.Visible = true;
			this.SuccessMessageLiteral.Text = Resources.TrasmissioneSuccesso;
		}

		private bool IsDatabaseUpToDate()
		{
			bool flag;
			string codiceUtente = base.AgenteAutenticato.CodiceUtente;
			EW.WebModaNet.TrasmissioneOrdiniReference.TrasmissioneOrdiniWebService client = new EW.WebModaNet.TrasmissioneOrdiniReference.TrasmissioneOrdiniWebService();
			string originalHash = string.Empty;
			try
			{
				originalHash = client.GetMD5DB(codiceUtente);
			}
			catch
			{
				throw new Exception(Resources.ErroreConnessioneServer);
			}
			if (!string.IsNullOrEmpty(originalHash))
			{
				string zipFileName = string.Format(WebConfigSettings.LastUpdateDBZipFileName, codiceUtente);
				string lastUpdateDBZipPath = Path.Combine(base.Server.MapPath(WebConfigSettings.ClientUpdateDirectory), zipFileName);
				flag = (File.Exists(lastUpdateDBZipPath) ? Utils.GetMD5File(lastUpdateDBZipPath).Equals(originalHash, StringComparison.OrdinalIgnoreCase) : false);
			}
			else
			{
				flag = true;
			}
			return flag;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				bool isUpToDate = false;
				bool connectionError = false;
				string errorMessage = string.Empty;
				try
				{
					isUpToDate = this.IsDatabaseUpToDate();
				}
				catch (Exception exception1)
				{
					Exception exception = exception1;
					connectionError = true;
					errorMessage = exception.Message;
				}
				if (connectionError)
				{
					this.connectionErrorMessage.Visible = true;
					this.ConnectionErrorMessageLiteral.Text = errorMessage;
					this.TrasmissioneOrdiniPanel.Visible = false;
				}
				else if (!isUpToDate)
				{
					this.necessarioAggiornamento.Visible = true;
					this.NecessarioAggiornamentoLiteral.Text = string.Format(Resources.NecessarioAggiornamento, VirtualPathUtility.ToAbsolute("~/AggiornaDatabase.aspx"));
					this.TrasmissioneOrdiniPanel.Visible = false;
				}
				else
				{
					IList<Ordine> ordiniDaTrasmettere = base.OrdineRepository.GetOrdiniDaTrasmettere(WebConfigSettings.CodiceStatoOrdineChiuso, base.AgenteAutenticato);
					IList<Cliente> clientiDaTrasmettere = base.ClienteRepository.GetClientiDaTrasmettere(WebConfigSettings.CodiceStatoClienteNuovo, base.AgenteAutenticato);
					if ((ordiniDaTrasmettere.Count > 0 ? false : clientiDaTrasmettere.Count <= 0))
					{
						this.TrasmissioneOrdiniPanel.Visible = false;
						this.infoMessage.Visible = true;
						this.InfoMessageLiteral.Text = Resources.OrdiniGiaTrasmessi;
					}
					else
					{
						this.TrasmissioneOrdiniPanel.Visible = true;
						this.IstruzioniTrasmissioneOrdiniLiteral.Text = string.Format(Resources.IstruzioniTrasmissioneOrdini, ordiniDaTrasmettere.Count, clientiDaTrasmettere.Count);
					}
				}
			}
		}

		private void SetClienteTrasmesso(ClienteResponseService cliente)
		{
			Cliente c = base.ClienteRepository.GetById(cliente.Codice);
			c.Stato = base.StatoClienteRepository.GetById(WebConfigSettings.CodiceStatoClienteTrasmesso);
			base.ClienteRepository.Save(c);
		}

		private void SetOrdineTrasmesso(OrdineResponseService ordine)
		{
			Ordine o = base.OrdineRepository.GetById(ordine.Codice);
			if (o != null)
			{
				o.Stato = base.StatoOrdineRepository.GetById(WebConfigSettings.CodiceStatoOrdineTrasmesso);
				base.OrdineRepository.Save(o);
			}
		}

		protected void TrasmettiButton_Click(object sender, EventArgs e)
		{
			TrasmissioneOrdiniRequestService trasmissione = new TrasmissioneOrdiniRequestService()
			{
				CodiceUtente = base.AgenteAutenticato.CodiceUtente,
				Hash = Utils.GetMD5(string.Concat(base.AgenteAutenticato.CodiceUtente, WebConfigSettings.HashKey))
			};
			IList<Ordine> ordiniDaTrasmettere = base.OrdineRepository.GetOrdiniDaTrasmettere(WebConfigSettings.CodiceStatoOrdineChiuso, base.AgenteAutenticato);
			List<OrdineService> ordini = new List<OrdineService>();
			foreach (Ordine o in ordiniDaTrasmettere)
			{
				ordini.Add(ClientServiceUtils.ConvertOrdineToOrdineService(o));
			}
			trasmissione.Ordini = ordini.ToArray();
			IList<Cliente> clientiDaTrasmettere = base.ClienteRepository.GetClientiDaTrasmettere(WebConfigSettings.CodiceStatoClienteNuovo, base.AgenteAutenticato);
			List<ClienteService> clienti = new List<ClienteService>();
			foreach (Cliente c in clientiDaTrasmettere)
			{
				clienti.Add(ClientServiceUtils.ConvertClienteToClienteService(c));
			}
			trasmissione.Clienti = clienti.ToArray();
			try
			{
				LogUtils.Info(string.Format("Inizio della trasmissione ordini. Numero di ordini da trasmettere: {0}, numero di clienti da trasmettere: {1}.", (int)trasmissione.Ordini.Length, (int)trasmissione.Clienti.Length));
				this.HandleServerResponse((new EW.WebModaNet.TrasmissioneOrdiniReference.TrasmissioneOrdiniWebService()).Trasmetti(trasmissione));
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				LogUtils.Error("Errore durante la trasmissione degli ordini.", exception);
				this.errorMessage.Visible = true;
				this.ErrorMessageLiteral.Text = string.Format(Resources.TrasmissioneErrore, exception.Message);
			}
			this.istruzioniTrasmissione.Visible = false;
			this.trasmettiButtonContainer.Visible = false;
		}
	}
}