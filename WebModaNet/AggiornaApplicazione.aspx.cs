using EW.WebModaNet.Code;
using EW.WebModaNet.TrasmissioneOrdiniReference;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Utils;
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class AggiornaApplicazione : BasePage
	{
		protected Literal TitoloLiteral;

		protected HtmlGenericControl applicazioneGiaAggiornata;

		protected Literal ApplicazioneGiaAggiornataLiteral;

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

		protected HtmlGenericControl installazioneWarningMessage;

		protected Literal InstallazioneWarningMessageLiteral;

		protected Button InstallaButton;

		protected HtmlGenericControl installazioneSuccessMessage;

		protected Literal InstallazioneSuccessMessageLiteral;

		protected HtmlGenericControl installazionErrorMessage;

		protected Literal InstallazionErrorMessageLiteral;

		private string UpdateAppZipPath
		{
			get
			{
				return this.ViewState[WebConfigSettings.UpdateAppPathViewStateKey] as string ?? string.Empty;
			}
			set
			{
				this.ViewState[WebConfigSettings.UpdateAppPathViewStateKey] = value;
			}
		}

		public AggiornaApplicazione()
		{
		}

		private void DownloadAggiornamentiApp()
		{
			string codiceUtente = Utils.GetCodiceUtenteDefault();
			if (base.AgenteAutenticato != null)
			{
				codiceUtente = base.AgenteAutenticato.CodiceUtente;
			}
			string sourceUrl = string.Format(WebConfigSettings.UpdateAppUrl, base.Server.UrlEncode(codiceUtente));
			Utils.DownloadFile(sourceUrl, this.UpdateAppZipPath);
			if (!Utils.GetMD5File(this.UpdateAppZipPath).Equals((new EW.WebModaNet.TrasmissioneOrdiniReference.TrasmissioneOrdiniWebService()).GetMD5App(), StringComparison.OrdinalIgnoreCase))
			{
				throw new Exception(Resources.DatiCorrotti);
			}
			LogUtils.Debug(string.Format("Download degli aggiornamenti dell'applicazione per l'utente \"{0}\" completato.", codiceUtente));
		}

		protected void DownloadButton_Click(object sender, EventArgs e)
		{
			try
			{
				LogUtils.Info("Avvio del download degli aggiornamenti dell'applicazione.");
				this.DownloadAggiornamentiApp();
				this.downloadSuccessMessage.Visible = true;
				this.DownloadSuccessMessageLiteral.Text = string.Format(Resources.DownloadCompletato, base.Request.Url.ToString());
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				if (File.Exists(this.UpdateAppZipPath))
				{
					File.Delete(this.UpdateAppZipPath);
				}
				if (!exception.Message.Contains("404"))
				{
					LogUtils.Error("Errore durante il download degli aggiornamenti dell'applicazione.", exception);
					this.downloadErrorMessage.Visible = true;
					this.DownloadErrorMessageLiteral.Text = string.Format(Resources.ErroreDownload, exception.Message);
				}
				else
				{
					this.downloadInfoMessage.Visible = true;
				}
			}
		}

		private void InstallaAggiornamentiApp()
		{
			if (!File.Exists(this.UpdateAppZipPath))
			{
				throw new Exception("File non trovato.");
			}
			string destFolder = base.Server.MapPath("~");
			Utils.UnzipFile(this.UpdateAppZipPath, destFolder);
			string lastUpdateAppZipPath = Path.Combine(base.Server.MapPath(WebConfigSettings.ClientUpdateDirectory), WebConfigSettings.LastUpdateAppZipFileName);
			if (File.Exists(lastUpdateAppZipPath))
			{
				File.Delete(lastUpdateAppZipPath);
			}
			File.Move(this.UpdateAppZipPath, lastUpdateAppZipPath);
		}

		protected void InstallaButton_Click(object sender, EventArgs e)
		{
			try
			{
				this.InstallaAggiornamentiApp();
				Panel downloadPanel = this.DownloadPanel;
				int num = 0;
				bool flag = num != 0;
				this.RipetiDownloadPanel.Visible = num != 0;
				downloadPanel.Visible = flag;
				HtmlGenericControl htmlGenericControl = this.installazioneInfoMessage;
				HtmlGenericControl htmlGenericControl1 = this.installazioneWarningMessage;
				int num1 = 0;
				flag = num1 != 0;
				this.InstallaButton.Visible = num1 != 0;
				bool flag1 = flag;
				flag = flag1;
				htmlGenericControl1.Visible = flag1;
				htmlGenericControl.Visible = flag;
				this.installazioneSuccessMessage.Visible = true;
				this.InstallazioneSuccessMessageLiteral.Text = Resources.InstallazioneCompletata;
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				LogUtils.Error("Errore durante l'installazione degli aggiornamenti dell'applicazione.", exception);
				this.installazionErrorMessage.Visible = true;
				this.InstallazionErrorMessageLiteral.Text = string.Format(Resources.ErroreInstallazione, exception.Message);
			}
		}

		private bool IsUpToDate()
		{
			bool flag;
			string lastUpdateAppZipPath = Path.Combine(base.Server.MapPath(WebConfigSettings.ClientUpdateDirectory), WebConfigSettings.LastUpdateAppZipFileName);
			if (File.Exists(lastUpdateAppZipPath))
			{
				try
				{
					if (Utils.GetMD5File(lastUpdateAppZipPath).Equals((new EW.WebModaNet.TrasmissioneOrdiniReference.TrasmissioneOrdiniWebService()).GetMD5App(), StringComparison.OrdinalIgnoreCase))
					{
						flag = true;
						return flag;
					}
				}
				catch
				{
				}
				flag = false;
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
				if (!this.IsUpToDate())
				{
					this.UpdateAppZipPath = Path.Combine(base.Server.MapPath(WebConfigSettings.ClientUpdateDirectory), WebConfigSettings.UpdateAppZipFileName);
					if (!File.Exists(this.UpdateAppZipPath))
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
					this.applicazioneGiaAggiornata.Visible = true;
					this.DownloadPanel.Visible = false;
					this.RipetiDownloadPanel.Visible = false;
					this.InstallazionePanel.Visible = false;
				}
			}
		}

		protected void RipetiDownloadButton_Click(object sender, EventArgs e)
		{
			if (File.Exists(this.UpdateAppZipPath))
			{
				File.Delete(this.UpdateAppZipPath);
			}
			base.Response.Redirect("~/AggiornaApplicazione.aspx");
		}
	}
}