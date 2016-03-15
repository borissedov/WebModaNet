using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class InserisciModificaCliente : AgentPage
	{
		protected Literal TitoloLiteral;

		protected HyperLink TornaIndietroLink;

		protected ValidationSummary MainValidationSummary;

		protected Panel ClientePanel;

		protected Literal DatiClienteLiteral;

		protected Label CodiceClienteLabel;

		protected RequiredFieldValidator CodiceClienteValidator;

		protected TextBox CodiceClienteTextBox;

		protected Label RagioneSocialeLabel;

		protected RequiredFieldValidator RagioneSocialeValidator;

		protected TextBox RagioneSociale1TextBox;

		protected TextBox RagioneSociale2TextBox;

		protected Label ReferenteLabel;

		protected TextBox ReferenteTextBox;

		protected Label PartitaIvaLabel;

		protected RequiredFieldValidator PartitaIvaValidator;

		protected CustomValidator PartitaIvaCustomValidator;

		protected TextBox PartitaIvaTextBox;

		protected Label CodiceFiscaleLabel;

		protected RequiredFieldValidator CodiceFiscaleValidator;

		protected TextBox CodiceFiscaleTextBox;

		protected Label ListinoLabel;

		protected RequiredFieldValidator ListinoValidator;

		protected DropDownList ListiniList;

		protected Label ValutaLabel;

		protected RequiredFieldValidator ValutaValidator;

		protected DropDownList ValuteList;

		protected Label MetodoPagamentoLabel;

		protected RequiredFieldValidator MetodoPagamentoValidator;

		protected DropDownList MetodiPagamentoList;

		protected Label AbiLabel;

		protected RequiredFieldValidator AbiValidator;

		protected RegularExpressionValidator AbiRegexValidator;

		protected TextBox AbiTextBox;

		protected Label CabLabel;

		protected RequiredFieldValidator CabValidator;

		protected RegularExpressionValidator CabRegexValidator;

		protected TextBox CabTextBox;

		protected Label IbanLabel;

		protected RequiredFieldValidator IbanValidator;

		protected TextBox IbanTextBox;

		protected Label TelefonoLabel;

		protected RequiredFieldValidator TelefonoValidator;

		protected TextBox TelefonoTextBox;

		protected Label CellulareLabel;

		protected TextBox CellulareTextBox;

		protected Label FaxLabel;

		protected TextBox FaxTextBox;

		protected Label EmailLabel;

		protected RequiredFieldValidator EmailValidator;

		protected RegularExpressionValidator EmailRegexValidator;

		protected TextBox EmailTextBox;

		protected Literal IndirizzoSedeLegaleLiteral;

		protected Label ViaSedeLegaleLabel;

		protected RequiredFieldValidator ViaSedeLegaleValidator;

		protected TextBox ViaSedeLegale1TextBox;

		protected TextBox ViaSedeLegale2TextBox;

		protected Label CapSedeLegaleLabel;

		protected RequiredFieldValidator CapSedeLegaleValidator;

		protected TextBox CapSedeLegaleTextBox;

		protected Label CittaSedeLegaleLabel;

		protected RequiredFieldValidator CittaSedeLegaleValidator;

		protected TextBox CittaSedeLegale1TextBox;

		protected TextBox CittaSedeLegale2TextBox;

		protected Label NazioneSedeLegaleLabel;

		protected RequiredFieldValidator NazioneSedeLegaleLabelValidator;

		protected DropDownList NazioniSedeLegaleList;

		protected Label ProvinciaSedeLegaleLabel;

		protected RequiredFieldValidator ProvinciaSedeLegaleValidator;

		protected DropDownList ProvinceSedeLegaleList;

		protected ValidationSummary IndirizziValidationSummary;

		protected Literal IndirizziClienteLiteral;

		protected Label RagioneSocialeIndirizzoLabel;

		protected RequiredFieldValidator RequiredFieldValidator1;

		protected TextBox RagioneSociale1IndirizzoTextBox;

		protected TextBox RagioneSociale2IndirizzoTextBox;

		protected Label ViaLabel;

		protected RequiredFieldValidator ViaValidator;

		protected TextBox Via1TextBox;

		protected TextBox Via2TextBox;

		protected Label CapLabel;

		protected RequiredFieldValidator CapValidator;

		protected TextBox CapTextBox;

		protected Label CittaLabel;

		protected RequiredFieldValidator CittaValidator;

		protected TextBox Citta1TextBox;

		protected TextBox Citta2TextBox;

		protected Label NazioneLabel;

		protected RequiredFieldValidator NazioneValidator;

		protected DropDownList NazioniList;

		protected Label ProvinciaLabel;

		protected RequiredFieldValidator ProvinciaValidator;

		protected DropDownList ProvinceList;

		protected CheckBox PredefinitoCheckBox;

		protected Button AggiungiIndirizzoButton;

		protected Repeater IndirizziRepeater;

		protected Button InserisciModificaClienteButton;

		protected List<Indirizzo> IndirizziInseriti
		{
			get
			{
				return this.Session["IndirizziInseriti"] as List<Indirizzo> ?? new List<Indirizzo>();
			}
			set
			{
				this.Session["IndirizziInseriti"] = value;
			}
		}

		public InserisciModificaCliente()
		{
		}

		private void AddIndirizzoInserito(Indirizzo indirizzo)
		{
			List<Indirizzo> indirizziInseriti = this.IndirizziInseriti;
			if (indirizzo.Predefinito)
			{
				foreach (Indirizzo indirizzoInserito in indirizziInseriti)
				{
					if (indirizzoInserito.Predefinito)
					{
						indirizzoInserito.Predefinito = false;
					}
				}
			}
			indirizziInseriti.Add(indirizzo);
			this.IndirizziInseriti = indirizziInseriti;
		}

		protected void AggiungiIndirizzoButton_Click(object sender, EventArgs e)
		{
			Provincia byId;
			if (this.Page.IsValid)
			{
				Indirizzo indirizzo = new Indirizzo()
				{
					RagioneSociale1 = this.RagioneSociale1IndirizzoTextBox.Text,
					RagioneSociale2 = this.RagioneSociale2IndirizzoTextBox.Text,
					Via1 = this.Via1TextBox.Text,
					Via2 = this.Via2TextBox.Text,
					Cap = this.CapTextBox.Text,
					Citta1 = this.Citta1TextBox.Text,
					Citta2 = this.Citta2TextBox.Text
				};
				Indirizzo indirizzo1 = indirizzo;
				if (this.ProvinceList.Enabled)
				{
					byId = base.ProvinciaRepository.GetById(this.ProvinceList.SelectedValue);
				}
				else
				{
					byId = null;
				}
				indirizzo1.Provincia = byId;
				indirizzo.Nazione = base.NazioneRepository.GetById(this.NazioniList.SelectedValue);
				indirizzo.Predefinito = this.PredefinitoCheckBox.Checked;
				this.AddIndirizzoInserito(indirizzo);
				this.ResetFormIndirizzo();
				this.CaricaIndirizzi();
			}
		}

		private void CaricaIndirizzi()
		{
			this.IndirizziRepeater.Visible = this.IndirizziInseriti.Count > 0;
			this.IndirizziRepeater.DataSource = this.IndirizziInseriti;
			this.IndirizziRepeater.DataBind();
		}

		private void CaricaListini()
		{
			this.ListiniList.DataSource = 
				from l in base.AgenteAutenticato.CodiciListino.Distinct<string>()
				orderby l
				select l;
			this.ListiniList.DataBind();
			if (!string.IsNullOrEmpty(base.AgenteAutenticato.CodiceListinoPredefinito))
			{
				this.ListiniList.SelectedValue = base.AgenteAutenticato.CodiceListinoPredefinito;
			}
		}

		private void CaricaMetodiPagamento()
		{
			this.MetodiPagamentoList.DataSource = 
				from m in base.AgenteAutenticato.MetodiPagamento
				orderby m.DescrizioneCompleta
				select m;
			this.MetodiPagamentoList.DataBind();
			if (base.AgenteAutenticato.MetodoPagamentoPredefinito != null)
			{
				this.MetodiPagamentoList.SelectedValue = base.AgenteAutenticato.MetodoPagamentoPredefinito.Codice;
			}
		}

		private void CaricaNazioni()
		{
			DropDownList nazioniSedeLegaleList = this.NazioniSedeLegaleList;
			DropDownList nazioniList = this.NazioniList;
			IList<Nazione> all = base.NazioneRepository.GetAll(new string[] { "Descrizione" });
			object obj = all;
			nazioniList.DataSource = all;
			nazioniSedeLegaleList.DataSource = obj;
			this.NazioniList.DataBind();
			this.NazioniSedeLegaleList.DataBind();
		}

		private void CaricaProvince()
		{
			DropDownList provinceSedeLegaleList = this.ProvinceSedeLegaleList;
			DropDownList provinceList = this.ProvinceList;
			IList<Provincia> all = base.ProvinciaRepository.GetAll(new string[] { "Descrizione" });
			object obj = all;
			provinceList.DataSource = all;
			provinceSedeLegaleList.DataSource = obj;
			this.ProvinceList.DataBind();
			this.ProvinceSedeLegaleList.DataBind();
		}

		private void CaricaValute()
		{
			this.ValuteList.DataSource = 
				from v in base.AgenteAutenticato.Valute
				orderby v.Codice
				select v;
			this.ValuteList.DataBind();
			if (base.AgenteAutenticato.ValutaPredefinita != null)
			{
				this.ValuteList.SelectedValue = base.AgenteAutenticato.ValutaPredefinita.Codice;
			}
		}

		private void EnableDisableValidationControls()
		{
			RequiredFieldValidator partitaIvaValidator = this.PartitaIvaValidator;
			CustomValidator partitaIvaCustomValidator = this.PartitaIvaCustomValidator;
			bool partitaIvaObbligatoria = base.ImpostazioniGenerali.PartitaIvaObbligatoria;
			bool flag = partitaIvaObbligatoria;
			partitaIvaCustomValidator.Enabled = partitaIvaObbligatoria;
			partitaIvaValidator.Enabled = flag;
			this.CodiceFiscaleValidator.Enabled = base.ImpostazioniGenerali.CodiceFiscaleObbligatorio;
			RequiredFieldValidator abiValidator = this.AbiValidator;
			RegularExpressionValidator abiRegexValidator = this.AbiRegexValidator;
			bool abiObbligatorio = base.ImpostazioniGenerali.AbiObbligatorio;
			flag = abiObbligatorio;
			abiRegexValidator.Enabled = abiObbligatorio;
			abiValidator.Enabled = flag;
			RequiredFieldValidator cabValidator = this.CabValidator;
			RegularExpressionValidator cabRegexValidator = this.CabRegexValidator;
			bool cabObbligatorio = base.ImpostazioniGenerali.CabObbligatorio;
			flag = cabObbligatorio;
			cabRegexValidator.Enabled = cabObbligatorio;
			cabValidator.Enabled = flag;
			this.IbanValidator.Enabled = base.ImpostazioniGenerali.CabObbligatorio;
			this.TelefonoValidator.Enabled = base.ImpostazioniGenerali.TelefonoObbligatorio;
			this.CapSedeLegaleValidator.Enabled = base.ImpostazioniGenerali.CapSedeLegaleObbligatorio;
			this.CapValidator.Enabled = base.ImpostazioniGenerali.CapIndirizzoObbligatorio;
		}

		protected void InserisciModificaClienteButton_Click(object sender, EventArgs e)
		{
			Provincia byId;
			if (this.Page.IsValid)
			{
				Cliente cliente = new Cliente();
				MetodoPagamento metodoPagamentoPredefinito = base.MetodoPagamentoRepository.GetById(this.MetodiPagamentoList.SelectedValue);
				Valuta valutaPredefinita = base.ValutaRepository.GetById(this.ValuteList.SelectedValue);
				string codiceListinoPredefinito = this.ListiniList.SelectedValue;
				StatoCliente statoClienteNuovo = base.StatoClienteRepository.GetById(WebConfigSettings.CodiceStatoClienteNuovo);
				if (this.ProvinceSedeLegaleList.Enabled)
				{
					byId = base.ProvinciaRepository.GetById(this.ProvinceSedeLegaleList.SelectedValue);
				}
				else
				{
					byId = null;
				}
				Provincia provinciaSedeLegale = byId;
				Nazione nazioneSedeLegale = base.NazioneRepository.GetById(this.NazioniSedeLegaleList.SelectedValue);
				Indirizzo indirizzo = new Indirizzo()
				{
					Via1 = this.ViaSedeLegale1TextBox.Text,
					Via2 = this.ViaSedeLegale2TextBox.Text,
					Cap = this.CapSedeLegaleTextBox.Text,
					Citta1 = this.CittaSedeLegale1TextBox.Text,
					Citta2 = this.CittaSedeLegale2TextBox.Text,
					Provincia = provinciaSedeLegale,
					Nazione = nazioneSedeLegale
				};
				Indirizzo indirizzoSedeLegale = indirizzo;
				cliente.Codice = this.CodiceClienteTextBox.Text;
				cliente.Agente = base.AgenteAutenticato;
				cliente.CodiceAgente = base.AgenteAutenticato.CodiceAgente;
				cliente.RagioneSociale1 = this.RagioneSociale1TextBox.Text;
				cliente.RagioneSociale2 = this.RagioneSociale2TextBox.Text;
				cliente.PartitaIva = this.PartitaIvaTextBox.Text;
				cliente.CodiceFiscale = this.CodiceFiscaleTextBox.Text;
				cliente.Attivo = true;
				cliente.Stato = statoClienteNuovo;
				cliente.Insoluto = false;
				cliente.MetodoPagamentoPredefinito = metodoPagamentoPredefinito;
				cliente.Abi = (!string.IsNullOrEmpty(this.AbiTextBox.Text) ? Convert.ToInt32(this.AbiTextBox.Text) : 0);
				cliente.Cab = (!string.IsNullOrEmpty(this.CabTextBox.Text) ? Convert.ToInt32(this.CabTextBox.Text) : 0);
				cliente.Iban = this.IbanTextBox.Text;
				cliente.ValutaPredefinita = valutaPredefinita;
				cliente.CodiceListinoPredefinito = codiceListinoPredefinito;
				cliente.Email = this.EmailTextBox.Text;
				cliente.Telefono = this.TelefonoTextBox.Text;
				cliente.Fax = this.FaxTextBox.Text;
				cliente.Referente = this.ReferenteTextBox.Text;
				cliente.SetIndirizzoSedeLegale(indirizzoSedeLegale);
				cliente.Indirizzi = new List<Indirizzo>();
				cliente.CodicePoliticaSconti = base.AgenteAutenticato.CodicePoliticaSconti;
				for (int i = 0; i < this.IndirizziInseriti.Count; i++)
				{
					this.IndirizziInseriti[i].Id = i + 1;
					this.IndirizziInseriti[i].Cliente = cliente;
					cliente.Indirizzi.Add(this.IndirizziInseriti[i]);
				}
				base.ClienteRepository.SaveNuovoCliente(cliente);
				base.SuccessMessage = string.Format(Resources.MessaggioClienteInserito, cliente.ToString());
				base.Response.Redirect("~/Clienti.aspx");
			}
		}

		protected void ListaIndirizzi_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			if (e.CommandName == "EliminaIndirizzo")
			{
				if (this.IndirizziInseriti.Count >= e.Item.ItemIndex)
				{
					this.RemoveIndirizzoInserito(e.Item.ItemIndex);
					this.CaricaIndirizzi();
				}
			}
		}

		protected void NazioniList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(this.NazioniList.SelectedValue == WebConfigSettings.CodiceNazioneItalia))
			{
				this.ProvinciaValidator.Enabled = false;
				this.ProvinceList.Enabled = false;
			}
			else
			{
				this.ProvinciaValidator.Enabled = true;
				this.ProvinceList.Enabled = true;
			}
		}

		protected void NazioniSedeLegaleList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(this.NazioniSedeLegaleList.SelectedValue == WebConfigSettings.CodiceNazioneItalia))
			{
				this.ProvinciaSedeLegaleValidator.Enabled = false;
				this.ProvinceSedeLegaleList.Enabled = false;
			}
			else
			{
				this.ProvinciaSedeLegaleValidator.Enabled = true;
				this.ProvinceSedeLegaleList.Enabled = true;
			}
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			if (base.ImpostazioniGenerali.BloccoNuoviClienti)
			{
				base.Response.Redirect("~/Errors/AccessoNegato.aspx");
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Session.Remove("IndirizziInseriti");
				this.EnableDisableValidationControls();
				this.SetValidationMessages();
				this.PopolaListe();
				this.CodiceClienteTextBox.Text = base.ClienteRepository.GetNewCodice(WebConfigSettings.IsOnline, base.AgenteAutenticato);
			}
		}

		protected void PartitaIvaCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			string partitaIva = args.Value;
			bool isValid = false;
			if (this.NazioniSedeLegaleList.SelectedValue.Equals(WebConfigSettings.CodiceNazioneItalia, StringComparison.OrdinalIgnoreCase))
			{
				isValid = Utils.ControllaPartitaIvaItaliana(partitaIva);
			}
			else if (Regex.IsMatch(partitaIva, "^[0-9A-Z]{3,11}$", RegexOptions.IgnoreCase))
			{
				isValid = true;
			}
			args.IsValid = isValid;
		}

		private void PopolaListe()
		{
			this.CaricaMetodiPagamento();
			this.CaricaValute();
			this.CaricaListini();
			this.CaricaProvince();
			this.CaricaNazioni();
		}

		private void RemoveIndirizzoInserito(int index)
		{
			List<Indirizzo> indirizziInseriti = this.IndirizziInseriti;
			indirizziInseriti.RemoveAt(index);
			this.IndirizziInseriti = indirizziInseriti;
		}

		private void ResetFormIndirizzo()
		{
			this.RagioneSociale1IndirizzoTextBox.Text = string.Empty;
			this.RagioneSociale2IndirizzoTextBox.Text = string.Empty;
			this.Via1TextBox.Text = string.Empty;
			this.Via2TextBox.Text = string.Empty;
			this.CapTextBox.Text = string.Empty;
			this.Citta1TextBox.Text = string.Empty;
			this.Citta2TextBox.Text = string.Empty;
			this.ProvinceList.ClearSelection();
			this.NazioniList.ClearSelection();
			this.PredefinitoCheckBox.Checked = false;
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
			this.PartitaIvaCustomValidator.ErrorMessage = ValidationUtils.Vat(this.PartitaIvaLabel.Text);
			this.PartitaIvaCustomValidator.Text = "*";
			this.AbiRegexValidator.ErrorMessage = ValidationUtils.Integer(this.AbiLabel.Text);
			this.AbiRegexValidator.Text = "*";
			this.CabRegexValidator.ErrorMessage = ValidationUtils.Integer(this.CabLabel.Text);
			this.CabRegexValidator.Text = "*";
			this.EmailRegexValidator.ErrorMessage = ValidationUtils.Email(this.EmailLabel.Text);
			this.EmailRegexValidator.Text = "*";
		}
	}
}