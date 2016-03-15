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
	public class AggiornaImmagini : OfflinePage
	{
		protected Literal AggiornaImmaginiLiteral;

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

		private string UpdateImgZipPath
		{
			get
			{
				return this.ViewState[WebConfigSettings.UpdateImgPathViewStateKey] as string ?? string.Empty;
			}
			set
			{
				this.ViewState[WebConfigSettings.UpdateImgPathViewStateKey] = value;
			}
		}

		public AggiornaImmagini()
		{
		}

		private void DownloadAggiornamentiImg()
		{
			string codiceUtente = Utils.GetCodiceUtenteDefault();
			if (base.AgenteAutenticato != null)
			{
				codiceUtente = base.AgenteAutenticato.CodiceUtente;
			}
			string sourceUrl = string.Format(WebConfigSettings.UpdateImgUrl, base.Server.UrlEncode(codiceUtente));
			Utils.DownloadFile(sourceUrl, this.UpdateImgZipPath);
			if (!Utils.GetMD5File(this.UpdateImgZipPath).Equals((new EW.WebModaNet.TrasmissioneOrdiniReference.TrasmissioneOrdiniWebService()).GetMD5Img(), StringComparison.OrdinalIgnoreCase))
			{
				throw new Exception(Resources.DatiCorrotti);
			}
			LogUtils.Debug(string.Format("Download degli aggiornamenti delle immagini per l'utente \"{0}\" completato.", codiceUtente));
		}

		protected void DownloadButton_Click(object sender, EventArgs e)
		{
			try
			{
				LogUtils.Info("Avvio del download degli aggiornamenti delle immagini.");
				this.DownloadAggiornamentiImg();
				this.downloadSuccessMessage.Visible = true;
				this.DownloadSuccessMessageLiteral.Text = string.Format(Resources.DownloadCompletato, base.Request.Url.ToString());
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				if (File.Exists(this.UpdateImgZipPath))
				{
					File.Delete(this.UpdateImgZipPath);
				}
				if (!exception.Message.Contains("404"))
				{
					LogUtils.Error("Errore durante il download degli aggiornamenti delle immagini .", exception);
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
			if (!File.Exists(this.UpdateImgZipPath))
			{
				throw new Exception("File non trovato.");
			}
			string destFolder = base.Server.MapPath("~/Images");
			Utils.UnzipFile(this.UpdateImgZipPath, destFolder);
			if (File.Exists(this.UpdateImgZipPath))
			{
				File.Delete(this.UpdateImgZipPath);
			}
		}

		protected void InstallaButton_Click(object sender, EventArgs e)
		{
			try
			{
				this.InstallaAggiornamentiApp();
				Panel downloadPanel = this.DownloadPanel;
				int num = 0;
				bool flag = (bool)num;
				this.RipetiDownloadPanel.Visible = (bool)num;
				downloadPanel.Visible = flag;
				HtmlGenericControl htmlGenericControl = this.installazioneInfoMessage;
				HtmlGenericControl htmlGenericControl1 = this.installazioneWarningMessage;
				int num1 = 0;
				flag = (bool)num1;
				this.InstallaButton.Visible = (bool)num1;
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
				LogUtils.Error("Errore durante l'installazione degli aggiornamenti delle immagini.", exception);
				this.installazionErrorMessage.Visible = true;
				this.InstallazionErrorMessageLiteral.Text = string.Format(Resources.ErroreInstallazione, exception.Message);
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.Page.IsPostBack)
			{
				this.UpdateImgZipPath = Path.Combine(base.Server.MapPath(WebConfigSettings.ClientUpdateDirectory), WebConfigSettings.UpdateImgZipFileName);
				if (!File.Exists(this.UpdateImgZipPath))
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
		}

		protected void RipetiDownloadButton_Click(object sender, EventArgs e)
		{
			if (File.Exists(this.UpdateImgZipPath))
			{
				File.Delete(this.UpdateImgZipPath);
			}
			base.Response.Redirect("~/AggiornaImmagini.aspx");
		}
	}
}