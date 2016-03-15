using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class ImpostazioniApplicazione : AdminPage
	{
		protected Literal ImpostazioniApplicazioneLiteral;

		protected HtmlGenericControl impostazioniSalvate;

		protected Literal ImpostazioniSalvateLiteral;

		protected Panel ImpostazioniExpertwebPanel;

		protected Literal ImpostazioniExpertwebLiteral;

		protected ValidationSummary ImpostazioniExpertwebValidationSummary;

		protected Label NumeroMassimoUtentiLabel;

		protected RequiredFieldValidator NumeroMassimoUtentiValidator;

		protected RegularExpressionValidator NumeroMassimoUtentiRegexValidator;

		protected TextBox NumeroMassimoUtentiTextBox;

		protected Button SalvaImpostazioniExpertwebButton;

		protected Literal ImpostazioniSicurezzaLiteral;

		protected ImageButton SospensioneButton;

		protected Label SospensioneLabel;

		protected ValidationSummary ImpostazioniDittaValidationSummary;

		protected Panel ImpostazioniDittaPanel;

		protected Literal ImpostazioniDittaLiteral;

		protected Label CodiceDittaLabel;

		protected RequiredFieldValidator CodiceDittaValidator;

		protected TextBox CodiceDittaTextBox;

		protected Label RagioneSocialeLabel;

		protected RequiredFieldValidator RagioneSocialeValidator;

		protected TextBox RagioneSocialeTextBox;

		protected Label IndirizzoLabel;

		protected RequiredFieldValidator IndirizzoValidator;

		protected TextBox IndirizzoTextBox;

		protected Label CapLabel;

		protected RequiredFieldValidator CapValidator;

		protected TextBox CapTextBox;

		protected Label CittaLabel;

		protected RequiredFieldValidator CittaValidator;

		protected TextBox CittaTextBox;

		protected Label ProvinciaLabel;

		protected DropDownList ProvinciaList;

		protected Label TelefonoLabel;

		protected TextBox TelefonoTextBox;

		protected Label FaxLabel;

		protected TextBox FaxTextBox;

		protected Label EmailLabel;

		protected TextBox EmailTextBox;

		protected Label SitoWebLabel;

		protected TextBox SitoWebTextBox;

		protected Label PartitaIvaLabel;

		protected TextBox PartitaIVATextBox;

		protected Label LogoLabel;

		protected CustomValidator LogoSizeValidator;

		protected CustomValidator LogoExtensionValidator;

		protected FileUpload LogoFileUpload;

		protected Image LogoImage;

		protected Button SalvaImpostazioniDittaButton;

		protected ValidationSummary ImpostazioniGeneraliValidationSummary;

		protected Literal ImpostazioniGeneraliLiteral;

		protected Label TipiOrdineAnnullamentoLabel;

		protected CheckBoxList TipiOrdineAnnullamentoCheckBoxList;

		protected Label NumeroGiorniAnnullamentoOrdiniSospesiLabel;

		protected RequiredFieldValidator NumeroGiorniAnnullamentoOrdiniSospesiValidator;

		protected RegularExpressionValidator NumeroGiorniAnnullamentoOrdiniSospesiRegexValidator;

		protected TextBox NumeroGiorniAnnullamentoOrdiniSospesiTextBox;

		protected Label NumeroDecimaliLabel;

		protected RequiredFieldValidator NumeroDecimaliValidator;

		protected RegularExpressionValidator NumeroDecimaliRegexValidator;

		protected TextBox NumeroDecimaliTextBox;

		protected CheckBox MostraGalleriaImmaginiCheckBox;

		protected CheckBox MostraImmaginiNonTrovateCheckBox;

		protected HtmlGenericControl divLimitiIconeDisponibilita;

		protected Label DisponibilitaIconaLabel;

		protected Label DisponibilitaLimiteInferioreLabel;

		protected TextBox DisponibilitaLimiteInferioreTextBox;

		protected RegularExpressionValidator DisponibilitaLimiteInferioreRegexValidator;

		protected Label DisponibilitaLimiteSuperioreLabel;

		protected TextBox DisponibilitaLimiteSuperioreTextBox;

		protected RegularExpressionValidator DisponibilitaLimiteSuperioreRegexValidator;

		protected CustomValidator LimitiDisponibilitaValidator;

		protected Button SalvaImpostazioniGeneraliButton;

		protected ValidationSummary ImpostazioniTipiOrdineValidationSummary;

		protected CustomValidator ImpostazioniTipiOrdineValidator;

		protected Panel ImpostazioniTipiOrdinePanel;

		protected Literal impostazioniTipiOrdineLiteral;

		protected Literal TipoOrdineLiteral;

		protected Literal ListinoLiteral;

		protected Literal MetodoPagamentoLiteral;

		protected HtmlTableRow rigaImpostazioneOrdine;

		protected DropDownList TipiOrdineList;

		protected DropDownList ListiniList;

		protected DropDownList MetodiPagamentoList;

		protected Button SalvaImpostazioniTipiOrdineButton;

		protected Literal ImpostazioniBlocchiLiteral;

		protected CheckBox BloccoNuoviClientiCheckBox;

		protected CheckBox BloccoIndirizziNuoviClientiVecchiCheckBox;

		protected CheckBox BloccoDataConsegnaManualeTestataCheckBox;

		protected Button SalvaImpostazioniBlocchiButton;

		protected Panel ImpostazioniStampaPanel;

		protected Literal ImpostazioniStampaLiteral;

		protected Label IntestazioneLabel;

		protected TextBox IntestazioneTextBox;

		protected Label PiedeLabel;

		protected TextBox PiedeTextBox;

		protected Label CondizioniVenditaLabel;

		protected TextBox CondizioniVenditaTextBox;

		protected Button SalvaImpostazioniStampaButton;

		protected Panel ImpostazioniMessaggiPanel;

		protected Literal ImpostazioniMessaggiLiteral;

		protected Label MessaggioLabel;

		protected TextBox MessaggioTextBox;

		protected Button SalvaImpostazioniMessaggiButton;

		protected ValidationSummary ImpostazioniAreaDocumentaleValidationSummary;

		protected CheckBox AttivaAreaDocumentaleCheckBox;

		protected TextBox CartellaDocumentiPdfTextBox;

		protected CustomValidator CartellaDocumentiPdfValidator;

		protected Button SalvaImpostazioniAreaDocumentaleButton;

		protected CheckBox PartitaIvaObbligatoriaCheckbox;

		protected CheckBox CodiceFiscaleObbligatorioCheckBox;

		protected CheckBox AbiObbligatorioCheckBox;

		protected CheckBox CabObbligatorioCheckBox;

		protected CheckBox IbanObbligatorioCheckBox;

		protected CheckBox TelefonoObbligatorioCheckBox;

		protected CheckBox CapSedeLegaleObbligatorioCheckBox;

		protected CheckBox CapIndirizzoObbligatorioCheckBox;

		protected Button SalvaImpostazioniNuoviClientiButton;

		protected ValidationSummary ImpostazioniNuoviOrdiniValidationSummary;

		protected CheckBox NascondiScontoCheckBox;

		protected CheckBox MostraPdfArticoliCheckBox;

		protected TextBox CartellaPdfArticoliTextBox;

		protected CustomValidator CartellaPdfArticoliValidator;

		protected Button SalvaImpostazioniNuoviOrdiniButton;

		public ImpostazioniApplicazione()
		{
		}

		protected void ImpostazioniTipiOrdineValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			bool flag;
			bool v1 = this.TipiOrdineList.SelectedValue != string.Empty;
			bool v2 = this.MetodiPagamentoList.SelectedValue != string.Empty;
			bool v3 = this.ListiniList.SelectedValue != string.Empty;
			ServerValidateEventArgs serverValidateEventArg = args;
			if (!v1 || !v2 || !v3)
			{
				flag = (v1 || v2 ? false : !v3);
			}
			else
			{
				flag = true;
			}
			serverValidateEventArg.IsValid = flag;
		}

		protected void LimitiDisponibilitaValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			int inf = 0;
			int sup = 0;
			int.TryParse(this.DisponibilitaLimiteInferioreTextBox.Text, out inf);
			int.TryParse(this.DisponibilitaLimiteSuperioreTextBox.Text, out sup);
			args.IsValid = inf <= sup;
		}

		private void LoadImpostazioniAreaDocumentale()
		{
			this.AttivaAreaDocumentaleCheckBox.Checked = base.ImpostazioniGenerali.AttivaAreaDocumentale;
			this.CartellaDocumentiPdfTextBox.Text = base.ImpostazioniGenerali.CartellaDocumentiPdf;
		}

		private void LoadImpostazioniBlocchi()
		{
			this.BloccoNuoviClientiCheckBox.Checked = base.ImpostazioniGenerali.BloccoNuoviClienti;
			this.BloccoIndirizziNuoviClientiVecchiCheckBox.Checked = base.ImpostazioniGenerali.BloccoIndirizziNuoviClientiVecchi;
			this.BloccoDataConsegnaManualeTestataCheckBox.Checked = base.ImpostazioniGenerali.BloccoDataConsegnaManualeTestata;
		}

		private void LoadImpostazioniDitta()
		{
			this.CodiceDittaTextBox.Text = base.ImpostazioniGenerali.CodiceDitta;
			this.RagioneSocialeTextBox.Text = base.ImpostazioniGenerali.RagioneSocialeDitta;
			this.IndirizzoTextBox.Text = base.ImpostazioniGenerali.IndirizzoDitta;
			this.CapTextBox.Text = base.ImpostazioniGenerali.CapDitta;
			this.CittaTextBox.Text = base.ImpostazioniGenerali.CittaDitta;
			this.ProvinciaList.SelectedValue = base.ImpostazioniGenerali.ProvinciaDitta;
			this.TelefonoTextBox.Text = base.ImpostazioniGenerali.TelefonoDitta;
			this.FaxTextBox.Text = base.ImpostazioniGenerali.FaxDitta;
			this.EmailTextBox.Text = base.ImpostazioniGenerali.EmailDitta;
			this.SitoWebTextBox.Text = base.ImpostazioniGenerali.SitoWebDitta;
			this.PartitaIVATextBox.Text = base.ImpostazioniGenerali.PartitaIVADitta;
			if (string.IsNullOrEmpty(base.ImpostazioniGenerali.LogoDitta))
			{
				this.LogoImage.Visible = false;
			}
			else
			{
				this.LogoImage.Visible = true;
				Image logoImage = this.LogoImage;
				object[] logoImageFolder = new object[] { WebConfigSettings.LogoImageFolder, "/", base.ImpostazioniGenerali.LogoDitta, "?t=", null };
				logoImageFolder[4] = DateTime.Now.Ticks;
				logoImage.ImageUrl = string.Concat(logoImageFolder);
			}
		}

		private void LoadImpostazioniExpertweb()
		{
			this.NumeroMassimoUtentiTextBox.Text = base.ImpostazioniGenerali.NumeroMassimoUtenti.ToString();
		}

		private void LoadImpostazioniGenerali()
		{
			this.MostraGalleriaImmaginiCheckBox.Checked = base.ImpostazioniGenerali.MostraGalleriaImmagini;
			this.MostraImmaginiNonTrovateCheckBox.Checked = base.ImpostazioniGenerali.MostraImmaginiNonTrovate;
			TextBox numeroGiorniAnnullamentoOrdiniSospesiTextBox = this.NumeroGiorniAnnullamentoOrdiniSospesiTextBox;
			int numeroGiorniAnnullamentoOrdiniSospesi = base.ImpostazioniGenerali.NumeroGiorniAnnullamentoOrdiniSospesi;
			numeroGiorniAnnullamentoOrdiniSospesiTextBox.Text = numeroGiorniAnnullamentoOrdiniSospesi.ToString();
			TextBox numeroDecimaliTextBox = this.NumeroDecimaliTextBox;
			numeroGiorniAnnullamentoOrdiniSospesi = base.ImpostazioniGenerali.NumeroDecimali;
			numeroDecimaliTextBox.Text = numeroGiorniAnnullamentoOrdiniSospesi.ToString();
			TextBox disponibilitaLimiteInferioreTextBox = this.DisponibilitaLimiteInferioreTextBox;
			numeroGiorniAnnullamentoOrdiniSospesi = base.ImpostazioniGenerali.DisponibilitaLimiteInferiore;
			disponibilitaLimiteInferioreTextBox.Text = numeroGiorniAnnullamentoOrdiniSospesi.ToString();
			TextBox disponibilitaLimiteSuperioreTextBox = this.DisponibilitaLimiteSuperioreTextBox;
			numeroGiorniAnnullamentoOrdiniSospesi = base.ImpostazioniGenerali.DisponibilitaLimiteSuperiore;
			disponibilitaLimiteSuperioreTextBox.Text = numeroGiorniAnnullamentoOrdiniSospesi.ToString();
			int[] idTipiOrdineAnnullamento = base.ImpostazioniGenerali.IdTipiOrdineAnnullamento;
			for (int i = 0; i < (int)idTipiOrdineAnnullamento.Length; i++)
			{
				int id = idTipiOrdineAnnullamento[i];
				foreach (ListItem item in this.TipiOrdineAnnullamentoCheckBoxList.Items)
				{
					if (item.Value == id.ToString())
					{
						item.Selected = true;
					}
				}
			}
		}

		private void LoadImpostazioniMessaggi()
		{
			this.MessaggioTextBox.Text = base.ImpostazioniGenerali.MessaggioHome;
		}

		private void LoadImpostazioniNuoviClienti()
		{
			this.PartitaIvaObbligatoriaCheckbox.Checked = base.ImpostazioniGenerali.PartitaIvaObbligatoria;
			this.CodiceFiscaleObbligatorioCheckBox.Checked = base.ImpostazioniGenerali.CodiceFiscaleObbligatorio;
			this.AbiObbligatorioCheckBox.Checked = base.ImpostazioniGenerali.AbiObbligatorio;
			this.CabObbligatorioCheckBox.Checked = base.ImpostazioniGenerali.CabObbligatorio;
			this.IbanObbligatorioCheckBox.Checked = base.ImpostazioniGenerali.IbanObbligatorio;
			this.TelefonoObbligatorioCheckBox.Checked = base.ImpostazioniGenerali.TelefonoObbligatorio;
			this.CapSedeLegaleObbligatorioCheckBox.Checked = base.ImpostazioniGenerali.CapSedeLegaleObbligatorio;
			this.CapIndirizzoObbligatorioCheckBox.Checked = base.ImpostazioniGenerali.CapIndirizzoObbligatorio;
		}

		private void LoadImpostazioniNuoviOrdini()
		{
			this.NascondiScontoCheckBox.Checked = base.ImpostazioniGenerali.NascondiSconto;
			this.MostraPdfArticoliCheckBox.Checked = base.ImpostazioniGenerali.MostraPdfArticoli;
			this.CartellaPdfArticoliTextBox.Text = base.ImpostazioniGenerali.CartellaPdfArticoli;
		}

		private void LoadImpostazioniSicurezza()
		{
			if (!base.ImpostazioniGenerali.IsApplicazioneSospesa)
			{
				this.SospensioneButton.ImageUrl = "~/Images/checkbox-empty.png";
				this.SospensioneButton.CssClass = "sospensione";
			}
			else
			{
				this.SospensioneButton.ImageUrl = "~/Images/checkbox-checked.png";
				this.SospensioneButton.CssClass = string.Empty;
			}
		}

		private void LoadImpostazioniStampa()
		{
			this.IntestazioneTextBox.Text = base.ImpostazioniGenerali.IntestazioneStampa;
			this.PiedeTextBox.Text = base.ImpostazioniGenerali.PiedeStampa;
			this.CondizioniVenditaTextBox.Text = base.ImpostazioniGenerali.CondizioniVendita;
		}

		private void LoadImpostazioniTipiOrdine()
		{
			this.TipiOrdineList.SelectedValue = (base.ImpostazioniGenerali.OrdineSpecialeTipo == 0 ? string.Empty : base.ImpostazioniGenerali.OrdineSpecialeTipo.ToString());
			this.ListiniList.SelectedValue = base.ImpostazioniGenerali.OrdineSpecialeListino;
			this.MetodiPagamentoList.SelectedValue = base.ImpostazioniGenerali.OrdineSpecialeMetedoPagamento;
		}

		protected void LogoExtensionValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (!this.LogoFileUpload.HasFile)
			{
				args.IsValid = true;
			}
			else
			{
				string extension = (new FileInfo(this.LogoFileUpload.PostedFile.FileName)).Extension;
				args.IsValid = WebConfigSettings.AllowedImageExtensions.Any<string>((string e) => e.Equals(extension, StringComparison.OrdinalIgnoreCase));
			}
		}

		protected void LogoSizeValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (!this.LogoFileUpload.HasFile)
			{
				args.IsValid = true;
			}
			else
			{
				HttpPostedFile postedFile = this.LogoFileUpload.PostedFile;
				args.IsValid = postedFile.ContentLength <= WebConfigSettings.MaxImageSize;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.SetMessages();
				this.SetValidationMessages();
				this.PopolaListe();
				if (!base.AgenteAutenticato.IsExpertweb(WebConfigSettings.CodiceTipoAgenteExpertweb))
				{
					this.ImpostazioniExpertwebPanel.Visible = false;
				}
				this.divLimitiIconeDisponibilita.Visible = WebConfigSettings.OpzioneIconaDisponibilita;
				this.LoadImpostazioniExpertweb();
				this.LoadImpostazioniSicurezza();
				this.LoadImpostazioniDitta();
				this.LoadImpostazioniGenerali();
				this.LoadImpostazioniBlocchi();
				this.LoadImpostazioniTipiOrdine();
				this.LoadImpostazioniStampa();
				this.LoadImpostazioniMessaggi();
				this.LoadImpostazioniAreaDocumentale();
				this.LoadImpostazioniNuoviClienti();
				this.LoadImpostazioniNuoviOrdini();
			}
		}

		protected void PathValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			string path = args.Value;
			try
			{
				string physicalPath = base.Server.MapPath(path);
				args.IsValid = Directory.Exists(physicalPath);
			}
			catch
			{
				args.IsValid = false;
			}
		}

		private void PopolaListe()
		{
			this.ProvinciaList.DataSource = base.ProvinciaRepository.FindAll(true, (Provincia p) => p.Codice, new Expression<Func<Provincia, bool>>[0]);
			this.ProvinciaList.DataBind();
			this.TipiOrdineAnnullamentoCheckBoxList.DataSource = base.TipoOrdineRepository.FindAll(true, (TipoOrdine t) => t.Descrizione, new Expression<Func<TipoOrdine, bool>>[0]);
			this.TipiOrdineAnnullamentoCheckBoxList.DataBind();
			IList<TipoOrdine> listaTipiOrdine = base.TipoOrdineRepository.FindAll(true, (TipoOrdine t) => t.Descrizione, new Expression<Func<TipoOrdine, bool>>[0]);
			this.TipiOrdineList.DataSource = listaTipiOrdine;
			this.TipiOrdineList.DataBind();
			IList<string> listaListini = base.ListinoRepository.GetCodiciListino().ToList<string>();
			this.ListiniList.DataSource = listaListini;
			this.ListiniList.DataBind();
			IList<MetodoPagamento> listaMetodoPagamento = base.MetodoPagamentoRepository.FindAll(true, (MetodoPagamento m) => m.Codice, new Expression<Func<MetodoPagamento, bool>>[0]);
			this.MetodiPagamentoList.DataSource = listaMetodoPagamento;
			this.MetodiPagamentoList.DataBind();
		}

		protected void SalvaImpostazioniAreaDocumentaleButton_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
				List<ImpostazioneApplicazione> impostazioniApplicazione = new List<ImpostazioneApplicazione>();
				bool @checked = this.AttivaAreaDocumentaleCheckBox.Checked;
				impostazioniApplicazione.Add(new ImpostazioneApplicazione("AttivaAreaDocumentale", @checked.ToString()));
				impostazioniApplicazione.Add(new ImpostazioneApplicazione("CartellaDocumentiPdf", this.CartellaDocumentiPdfTextBox.Text));
				base.ImpostazioniGenerali.Salva(impostazioniApplicazione.ToArray());
				CacheManager.Remove("AttivaAreaDocumentale");
				CacheManager.Remove("CartellaDocumentiPdf");
				this.impostazioniSalvate.Visible = true;
				this.LoadImpostazioniAreaDocumentale();
			}
		}

		protected void SalvaImpostazioniBlocchiButton_Click(object sender, EventArgs e)
		{
			List<ImpostazioneApplicazione> impostazioniApplicazione = new List<ImpostazioneApplicazione>();
			bool @checked = this.BloccoNuoviClientiCheckBox.Checked;
			impostazioniApplicazione.Add(new ImpostazioneApplicazione("BloccoNuoviClienti", @checked.ToString()));
			@checked = this.BloccoIndirizziNuoviClientiVecchiCheckBox.Checked;
			impostazioniApplicazione.Add(new ImpostazioneApplicazione("BloccoIndirizziNuoviClientiVecchi", @checked.ToString()));
			@checked = this.BloccoDataConsegnaManualeTestataCheckBox.Checked;
			impostazioniApplicazione.Add(new ImpostazioneApplicazione("BloccoDataConsegnaManualeTestata", @checked.ToString()));
			base.ImpostazioniGenerali.Salva(impostazioniApplicazione.ToArray());
			CacheManager.Remove("BloccoNuoviClienti");
			CacheManager.Remove("BloccoIndirizziNuoviClientiVecchi");
			CacheManager.Remove("BloccoDataConsegnaManualeTestata");
			this.impostazioniSalvate.Visible = true;
			this.LoadImpostazioniBlocchi();
		}

		protected void SalvaImpostazioniDittaButton_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
				List<ImpostazioneApplicazione> impostazioneApplicaziones = new List<ImpostazioneApplicazione>()
				{
					new ImpostazioneApplicazione("CodiceDitta", this.CodiceDittaTextBox.Text),
					new ImpostazioneApplicazione("RagioneSocialeDitta", this.RagioneSocialeTextBox.Text),
					new ImpostazioneApplicazione("IndirizzoDitta", this.IndirizzoTextBox.Text),
					new ImpostazioneApplicazione("CapDitta", this.CapTextBox.Text),
					new ImpostazioneApplicazione("CittaDitta", this.CittaTextBox.Text),
					new ImpostazioneApplicazione("ProvinciaDitta", this.ProvinciaList.SelectedValue),
					new ImpostazioneApplicazione("TelefonoDitta", this.TelefonoTextBox.Text),
					new ImpostazioneApplicazione("FaxDitta", this.FaxTextBox.Text),
					new ImpostazioneApplicazione("EmailDitta", this.EmailTextBox.Text),
					new ImpostazioneApplicazione("SitoWebDitta", this.SitoWebTextBox.Text),
					new ImpostazioneApplicazione("PartitaIVADitta", this.PartitaIVATextBox.Text)
				};
				List<ImpostazioneApplicazione> impostazioniApplicazione = impostazioneApplicaziones;
				if (this.LogoFileUpload.HasFile)
				{
					HttpPostedFile postedFile = this.LogoFileUpload.PostedFile;
					string extension = (new FileInfo(postedFile.FileName)).Extension;
					string fileName = string.Concat(WebConfigSettings.LogoImageName, extension);
					string filePath = string.Concat(base.Server.MapPath(WebConfigSettings.LogoImageFolder), Path.DirectorySeparatorChar, fileName);
					if (File.Exists(filePath))
					{
						File.Delete(filePath);
					}
					postedFile.SaveAs(filePath);
					impostazioniApplicazione.Add(new ImpostazioneApplicazione("LogoDitta", fileName));
				}
				base.ImpostazioniGenerali.Salva(impostazioniApplicazione.ToArray());
				CacheManager.Remove("CodiceDitta");
				CacheManager.Remove("RagioneSocialeDitta");
				CacheManager.Remove("IndirizzoDitta");
				CacheManager.Remove("CapDitta");
				CacheManager.Remove("CittaDitta");
				CacheManager.Remove("ProvinciaDitta");
				CacheManager.Remove("TelefonoDitta");
				CacheManager.Remove("FaxDitta");
				CacheManager.Remove("EmailDitta");
				CacheManager.Remove("SitoWebDitta");
				CacheManager.Remove("LogoDitta");
				CacheManager.Remove("PartitaIVADitta");
				this.impostazioniSalvate.Visible = true;
				this.LoadImpostazioniDitta();
			}
		}

		protected void SalvaImpostazioniExpertwebButton_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
				base.ImpostazioniGenerali.Salva(new ImpostazioneApplicazione("NumeroMassimoUtenti", this.NumeroMassimoUtentiTextBox.Text));
				CacheManager.Remove("NumeroMassimoUtenti");
				this.impostazioniSalvate.Visible = true;
				this.LoadImpostazioniExpertweb();
			}
		}

		protected void SalvaImpostazioniGeneraliButton_Click(object sender, EventArgs e)
		{
			List<ImpostazioneApplicazione> impostazioniApplicazione = new List<ImpostazioneApplicazione>();
			bool @checked = this.MostraGalleriaImmaginiCheckBox.Checked;
			impostazioniApplicazione.Add(new ImpostazioneApplicazione("MostraGalleriaImmagini", @checked.ToString()));
			@checked = this.MostraImmaginiNonTrovateCheckBox.Checked;
			impostazioniApplicazione.Add(new ImpostazioneApplicazione("MostraImmaginiNonTrovate", @checked.ToString()));
			impostazioniApplicazione.Add(new ImpostazioneApplicazione("NumeroGiorniAnnullamentoOrdiniSospesi", this.NumeroGiorniAnnullamentoOrdiniSospesiTextBox.Text));
			impostazioniApplicazione.Add(new ImpostazioneApplicazione("NumeroDecimali", this.NumeroDecimaliTextBox.Text));
			impostazioniApplicazione.Add(new ImpostazioneApplicazione("DisponibilitaLimiteInferiore", this.DisponibilitaLimiteInferioreTextBox.Text));
			impostazioniApplicazione.Add(new ImpostazioneApplicazione("DisponibilitaLimiteSuperiore", this.DisponibilitaLimiteSuperioreTextBox.Text));
			string idTipiOrdineAnnullamento = string.Empty;
			foreach (ListItem item in this.TipiOrdineAnnullamentoCheckBoxList.Items)
			{
				if (item.Selected)
				{
					idTipiOrdineAnnullamento = string.Concat(idTipiOrdineAnnullamento, item.Value, ", ");
				}
			}
			impostazioniApplicazione.Add(new ImpostazioneApplicazione("IdTipiOrdineAnnullamento", Regex.Replace(idTipiOrdineAnnullamento, ", $", string.Empty)));
			CacheManager.Remove("MostraGalleriaImmagini");
			CacheManager.Remove("MostraImmaginiNonTrovate");
			CacheManager.Remove("NumeroGiorniAnnullamentoOrdiniSospesi");
			CacheManager.Remove("NumeroDecimali");
			CacheManager.Remove("DisponibilitaLimiteInferiore");
			CacheManager.Remove("DisponibilitaLimiteSuperiore");
			CacheManager.Remove("IdTipiOrdineAnnullamento");
			base.ImpostazioniGenerali.Salva(impostazioniApplicazione.ToArray());
			this.impostazioniSalvate.Visible = true;
			this.LoadImpostazioniGenerali();
		}

		protected void SalvaImpostazioniMessaggiButton_Click(object sender, EventArgs e)
		{
			List<ImpostazioneApplicazione> impostazioniApplicazione = new List<ImpostazioneApplicazione>()
			{
				new ImpostazioneApplicazione("MessaggioHome", this.MessaggioTextBox.Text)
			};
			base.ImpostazioniGenerali.Salva(impostazioniApplicazione.ToArray());
			CacheManager.Remove("MessaggioHome");
			this.impostazioniSalvate.Visible = true;
			this.LoadImpostazioniMessaggi();
		}

		protected void SalvaImpostazioniNuoviClientiButton_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
				List<ImpostazioneApplicazione> impostazioniApplicazione = new List<ImpostazioneApplicazione>();
				bool @checked = this.PartitaIvaObbligatoriaCheckbox.Checked;
				impostazioniApplicazione.Add(new ImpostazioneApplicazione("PartitaIvaObbligatoria", @checked.ToString()));
				@checked = this.CodiceFiscaleObbligatorioCheckBox.Checked;
				impostazioniApplicazione.Add(new ImpostazioneApplicazione("CodiceFiscaleObbligatorio", @checked.ToString()));
				@checked = this.AbiObbligatorioCheckBox.Checked;
				impostazioniApplicazione.Add(new ImpostazioneApplicazione("AbiObbligatorio", @checked.ToString()));
				@checked = this.CabObbligatorioCheckBox.Checked;
				impostazioniApplicazione.Add(new ImpostazioneApplicazione("CabObbligatorio", @checked.ToString()));
				@checked = this.IbanObbligatorioCheckBox.Checked;
				impostazioniApplicazione.Add(new ImpostazioneApplicazione("IbanObbligatorio", @checked.ToString()));
				@checked = this.TelefonoObbligatorioCheckBox.Checked;
				impostazioniApplicazione.Add(new ImpostazioneApplicazione("TelefonoObbligatorio", @checked.ToString()));
				@checked = this.CapSedeLegaleObbligatorioCheckBox.Checked;
				impostazioniApplicazione.Add(new ImpostazioneApplicazione("CapSedeLegaleObbligatorio", @checked.ToString()));
				@checked = this.CapIndirizzoObbligatorioCheckBox.Checked;
				impostazioniApplicazione.Add(new ImpostazioneApplicazione("CapIndirizzoObbligatorio", @checked.ToString()));
				base.ImpostazioniGenerali.Salva(impostazioniApplicazione.ToArray());
				CacheManager.Remove("PartitaIvaObbligatoria");
				CacheManager.Remove("CodiceFiscaleObbligatorio");
				CacheManager.Remove("AbiObbligatorio");
				CacheManager.Remove("CabObbligatorio");
				CacheManager.Remove("IbanObbligatorio");
				CacheManager.Remove("TelefonoObbligatorio");
				CacheManager.Remove("CapSedeLegaleObbligatorio");
				CacheManager.Remove("CapIndirizzoObbligatorio");
				this.impostazioniSalvate.Visible = true;
				this.LoadImpostazioniNuoviClienti();
			}
		}

		protected void SalvaImpostazioniNuoviOrdiniButton_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
				List<ImpostazioneApplicazione> impostazioniApplicazione = new List<ImpostazioneApplicazione>();
				bool @checked = this.NascondiScontoCheckBox.Checked;
				impostazioniApplicazione.Add(new ImpostazioneApplicazione("NascondiSconto", @checked.ToString()));
				@checked = this.MostraPdfArticoliCheckBox.Checked;
				impostazioniApplicazione.Add(new ImpostazioneApplicazione("MostraPdfArticoli", @checked.ToString()));
				impostazioniApplicazione.Add(new ImpostazioneApplicazione("CartellaPdfArticoli", this.CartellaPdfArticoliTextBox.Text));
				base.ImpostazioniGenerali.Salva(impostazioniApplicazione.ToArray());
				CacheManager.Remove("NascondiSconto");
				CacheManager.Remove("MostraPdfArticoli");
				CacheManager.Remove("CartellaPdfArticoli");
				this.impostazioniSalvate.Visible = true;
				this.LoadImpostazioniNuoviOrdini();
			}
		}

		protected void SalvaImpostazioniStampaButton_Click(object sender, EventArgs e)
		{
			List<ImpostazioneApplicazione> impostazioniApplicazione = new List<ImpostazioneApplicazione>()
			{
				new ImpostazioneApplicazione("IntestazioneStampa", this.IntestazioneTextBox.Text),
				new ImpostazioneApplicazione("PiedeStampa", this.PiedeTextBox.Text),
				new ImpostazioneApplicazione("CondizioniVendita", this.CondizioniVenditaTextBox.Text)
			};
			base.ImpostazioniGenerali.Salva(impostazioniApplicazione.ToArray());
			CacheManager.Remove("IntestazioneStampa");
			CacheManager.Remove("PiedeStampa");
			CacheManager.Remove("CondizioniVendita");
			this.impostazioniSalvate.Visible = true;
			this.LoadImpostazioniStampa();
		}

		protected void SalvaImpostazioniTipiOrdine_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
				List<ImpostazioneApplicazione> impostazioniApplicazione = new List<ImpostazioneApplicazione>()
				{
					new ImpostazioneApplicazione("OrdineSpecialeTipo", this.TipiOrdineList.SelectedValue),
					new ImpostazioneApplicazione("OrdineSpecialeListino", this.ListiniList.SelectedValue),
					new ImpostazioneApplicazione("OrdineSpecialeMetedoPagamento", this.MetodiPagamentoList.SelectedValue)
				};
				base.ImpostazioniGenerali.Salva(impostazioniApplicazione.ToArray());
				CacheManager.Remove("OrdineSpecialeTipo");
				CacheManager.Remove("OrdineSpecialeListino");
				CacheManager.Remove("OrdineSpecialeMetedoPagamento");
				this.impostazioniSalvate.Visible = true;
				this.LoadImpostazioniTipiOrdine();
			}
		}

		private void SetMessages()
		{
			Label tipiOrdineAnnullamentoLabel = this.TipiOrdineAnnullamentoLabel;
			string text = this.TipiOrdineAnnullamentoLabel.Text;
			int numeroGiorniAnnullamentoOrdiniSospesi = base.ImpostazioniGenerali.NumeroGiorniAnnullamentoOrdiniSospesi;
			tipiOrdineAnnullamentoLabel.Text = string.Format(text, numeroGiorniAnnullamentoOrdiniSospesi.ToString());
		}

		private void SetValidationMessages()
		{
			foreach (object validator in base.Validators)
			{
				RequiredFieldValidator requiredValidator = validator as RequiredFieldValidator;
				if (requiredValidator != null)
				{
					requiredValidator.ErrorMessage = ValidationUtils.Required(requiredValidator.ErrorMessage);
					requiredValidator.Text = "*";
				}
			}
			this.NumeroMassimoUtentiRegexValidator.ErrorMessage = ValidationUtils.Integer(this.NumeroMassimoUtentiLabel.Text);
			this.NumeroMassimoUtentiRegexValidator.Text = "*";
			this.NumeroGiorniAnnullamentoOrdiniSospesiRegexValidator.ErrorMessage = ValidationUtils.Integer(this.NumeroGiorniAnnullamentoOrdiniSospesiLabel.Text);
			this.NumeroGiorniAnnullamentoOrdiniSospesiRegexValidator.Text = "*";
			this.NumeroDecimaliRegexValidator.ErrorMessage = ValidationUtils.Integer(this.NumeroDecimaliLabel.Text);
			this.NumeroDecimaliRegexValidator.Text = "*";
		}

		protected void SospensioneButton_Click(object sender, ImageClickEventArgs e)
		{
			bool isApplicazioneSospesa = !base.ImpostazioniGenerali.IsApplicazioneSospesa;
			base.ImpostazioniGenerali.Salva(new ImpostazioneApplicazione("Sospensione", isApplicazioneSospesa.ToString()));
			CacheManager.Remove("Sospensione");
			this.impostazioniSalvate.Visible = true;
			this.LoadImpostazioniSicurezza();
		}
	}
}