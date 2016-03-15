using EW.WebModaNet.Code;
using EW.WebModaNet.ServiceEntities;
using EW.WebModaNet.TrasmissioneOrdiniReference;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Utils;
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace EW.WebModaNet
{
	public class AggiornaDatabase : BasePage
	{
		protected Literal TitoloLiteral;

		protected HtmlGenericControl databaseGiaAggiornato;

		protected Literal DatabaseGiaAggiornatoLiteral;

		protected Panel DownloadPanel;

		protected Literal IstruzioniDownloadLiteral;

		protected UpdatePanel DownloadUpdatePanel;

		protected Button DownloadButton;

		protected HtmlGenericControl downloadInfoMessage;

		protected Literal DownloadInfoMessageLiteral;

		protected HtmlGenericControl downloadSuccessMessage;

		protected Literal DownloadSuccessMessageLiteral;

		protected HtmlGenericControl downloadErrorMessage;

		protected Literal DownloadErrorMessageLiteral;

		protected UpdateProgress DownloadUpdateProgress;

		protected Panel RipetiDownloadPanel;

		protected Literal RipetiDownloadLiteral;

		protected Button RipetiDownloadButton;

		protected Panel InstallazionePanel;

		protected HtmlGenericControl installazioneInfoMessage;

		protected Literal IstruzioniInstallazioneLiteral;

		protected Button InstallaButton;

		protected HtmlGenericControl installazioneSuccessMessage;

		protected Literal InstallazioneSuccessMessageLiteral;

		protected HtmlGenericControl installazionErrorMessage;

		protected Literal InstallazionErrorMessageLiteral;

		private string UpdateDBZipPath
		{
			get
			{
				return this.ViewState[WebConfigSettings.UpdateDBPathViewStateKey] as string ?? string.Empty;
			}
			set
			{
				this.ViewState[WebConfigSettings.UpdateDBPathViewStateKey] = value;
			}
		}

		public AggiornaDatabase()
		{
		}

		private void DownloadAggiornamentiDB()
		{
			string codiceUtente = Utils.GetCodiceUtenteDefault();
			if (base.AgenteAutenticato != null)
			{
				codiceUtente = base.AgenteAutenticato.CodiceUtente;
			}
			string sourceUrl = string.Format(WebConfigSettings.UpdateDBUrl, base.Server.UrlEncode(codiceUtente));
			LogUtils.Info(string.Format("Inizio download dalla URL \"{0}\".", sourceUrl));
			Utils.DownloadFile(sourceUrl, this.UpdateDBZipPath);
			string currHash = Utils.GetMD5File(this.UpdateDBZipPath);
			string originalHash = (new EW.WebModaNet.TrasmissioneOrdiniReference.TrasmissioneOrdiniWebService()).GetMD5DB(codiceUtente);
			if (!currHash.Equals(originalHash, StringComparison.OrdinalIgnoreCase))
			{
				LogUtils.Error(string.Format("Errore, i codici di controllo dei file non corrispondono.\nCodice utente: {0}\nCurrent hash: {1}\nOriginal hash: {2}.", codiceUtente, currHash, originalHash));
				throw new Exception(Resources.DatiCorrotti);
			}
			LogUtils.Debug(string.Format("Download degli aggiornamenti del database per l'utente \"{0}\" completato.", codiceUtente));
		}

		protected void DownloadButton_Click(object sender, EventArgs e)
		{
			try
			{
				LogUtils.Info("Avvio del download degli aggiornamenti del database.");
				this.DownloadAggiornamentiDB();
				this.downloadSuccessMessage.Visible = true;
				this.DownloadSuccessMessageLiteral.Text = string.Format(Resources.DownloadCompletato, base.Request.Url.ToString());
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				if (File.Exists(this.UpdateDBZipPath))
				{
					File.Delete(this.UpdateDBZipPath);
				}
				if (!exception.Message.Contains("404"))
				{
					LogUtils.Error("Errore durante il download degli aggiornamenti del database.", exception);
					this.downloadErrorMessage.Visible = true;
					this.DownloadErrorMessageLiteral.Text = string.Format(Resources.ErroreDownload, exception.Message);
				}
				else
				{
					this.downloadInfoMessage.Visible = true;
				}
			}
		}

		private void InstallaAggiornamentiDB()
		{
			if (!File.Exists(this.UpdateDBZipPath))
			{
				throw new Exception("File non trovato.");
			}
			LogUtils.Info(string.Format("Decompressione del file \"{0}\".", this.UpdateDBZipPath));
			string destFolder = Path.GetDirectoryName(this.UpdateDBZipPath);
			Utils.UnzipFile(this.UpdateDBZipPath, destFolder);
			AggiornamentoDatabaseService aggiornamentoDatabase = null;
			XmlSerializer serializer = new XmlSerializer(typeof(AggiornamentoDatabaseService));
			string codiceUtente = Utils.GetCodiceUtenteDefault();
			if (base.AgenteAutenticato != null)
			{
				codiceUtente = base.AgenteAutenticato.CodiceUtente;
			}
			string xmlFileName = string.Format(WebConfigSettings.UpdateDBXmlFileName, codiceUtente);
			string xmlFilePath = Path.Combine(destFolder, xmlFileName);
			LogUtils.Info(string.Format("Deserializzazione del file \"{0}\".", xmlFilePath));
			FileStream fileStream = File.OpenRead(xmlFilePath);
			try
			{
				aggiornamentoDatabase = (AggiornamentoDatabaseService)serializer.Deserialize(fileStream);
			}
			finally
			{
				if (fileStream != null)
				{
					((IDisposable)fileStream).Dispose();
				}
			}
			if (aggiornamentoDatabase != null)
			{
				UpdateUtils.AggiornaDB(aggiornamentoDatabase, WebConfigSettings.SqlServerCeConnectionString);
			}
			string zipFileName = string.Format(WebConfigSettings.LastUpdateDBZipFileName, codiceUtente);
			string lastUpdateAppZipPath = Path.Combine(base.Server.MapPath(WebConfigSettings.ClientUpdateDirectory), zipFileName);
			if (File.Exists(lastUpdateAppZipPath))
			{
				File.Delete(lastUpdateAppZipPath);
			}
			File.Move(this.UpdateDBZipPath, lastUpdateAppZipPath);
			File.Delete(xmlFilePath);
		}

		protected void InstallaButton_Click(object sender, EventArgs e)
		{
			try
			{
				LogUtils.Info("Avvio dell'installazione degli aggiornamenti del database.");
				this.InstallaAggiornamentiDB();
				Panel downloadPanel = this.DownloadPanel;
				int num = 0;
				bool flag = num != 0;
				this.RipetiDownloadPanel.Visible = num != 0;
				downloadPanel.Visible = flag;
				HtmlGenericControl htmlGenericControl = this.installazioneInfoMessage;
				int num1 = 0;
				flag = num1 != 0;
				this.InstallaButton.Visible = num1 != 0;
				htmlGenericControl.Visible = flag;
				this.installazioneSuccessMessage.Visible = true;
				this.InstallazioneSuccessMessageLiteral.Text = Resources.InstallazioneCompletata;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				LogUtils.Error("Errore durante l'installazione degli aggiornamenti del database.", exception);
				this.installazionErrorMessage.Visible = true;
				this.InstallazionErrorMessageLiteral.Text = string.Format(Resources.ErroreInstallazione, exception.Message);
			}
		}

		private bool IsDatabaseUpToDate(string codiceUtente)
		{
			bool flag;
			string zipFileName = string.Format(WebConfigSettings.LastUpdateDBZipFileName, codiceUtente);
			string lastUpdateDBZipPath = Path.Combine(base.Server.MapPath(WebConfigSettings.ClientUpdateDirectory), zipFileName);
			if (File.Exists(lastUpdateDBZipPath))
			{
				string currHash = Utils.GetMD5File(lastUpdateDBZipPath);
				EW.WebModaNet.TrasmissioneOrdiniReference.TrasmissioneOrdiniWebService client = new EW.WebModaNet.TrasmissioneOrdiniReference.TrasmissioneOrdiniWebService();
				flag = currHash.Equals(client.GetMD5DB(codiceUtente), StringComparison.OrdinalIgnoreCase);
			}
			else
			{
				flag = false;
			}
			return flag;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.Page.IsPostBack)
			{
				string codiceUtente = Utils.GetCodiceUtenteDefault();
				if (base.AgenteAutenticato != null)
				{
					codiceUtente = base.AgenteAutenticato.CodiceUtente;
				}
				AggiornaDatabase aggiornaDatabase = this;
				aggiornaDatabase.Title = string.Concat(aggiornaDatabase.Title, " - ", codiceUtente);
				Literal titoloLiteral = this.TitoloLiteral;
				titoloLiteral.Text = string.Concat(titoloLiteral.Text, " - ", codiceUtente);
				bool isUpToDate = false;
				try
				{
					isUpToDate = this.IsDatabaseUpToDate(codiceUtente);
				}
				catch
				{
				}
				if (!isUpToDate)
				{
					string zipFileName = string.Format(WebConfigSettings.UpdateDBZipFileName, codiceUtente);
					this.UpdateDBZipPath = Path.Combine(base.Server.MapPath(WebConfigSettings.ClientUpdateDirectory), zipFileName);
					if (!File.Exists(this.UpdateDBZipPath))
					{
						this.DownloadPanel.Visible = true;
						this.RipetiDownloadPanel.Visible = false;
						this.InstallazionePanel.Visible = false;
					}
					else
					{
						this.DownloadPanel.Visible = false;
						this.RipetiDownloadPanel.Visible = true;
						this.InstallazionePanel.Visible = true;
					}
				}
				else
				{
					this.databaseGiaAggiornato.Visible = true;
					this.DownloadPanel.Visible = false;
					this.RipetiDownloadPanel.Visible = false;
					this.InstallazionePanel.Visible = false;
				}
			}
		}

		protected void RipetiDownloadButton_Click(object sender, EventArgs e)
		{
			if (File.Exists(this.UpdateDBZipPath))
			{
				File.Delete(this.UpdateDBZipPath);
			}
			base.Response.Redirect("~/AggiornaDatabase.aspx");
		}
	}
}