using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class NuoviIndirizzi : ProtectedPage
	{
		protected Literal TitoloLiteral;

		protected Panel RicercaClientePanel;

		protected Literal RicercaClienteLiteral;

		protected Label RagioneSocialeLabel;

		protected TextBox RagioneSocialeTextBox;

		protected Label ClienteLabel;

		protected DropDownList ClientiList;

		protected HtmlGenericControl clienteNonTrovato;

		protected Literal ErroreClienteNonTrovatoLiteral;

		protected ValidationSummary IndirizziValidationSummary;

		protected Panel IndirizziPanel;

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

		protected Button AggiungiIndirizzoButton;

		protected Repeater IndirizziRepeater;

		public Cliente cliente
		{
			get;
			set;
		}

		public NuoviIndirizzi()
		{
		}

		protected void AggiungiIndirizzoButton_Click(object sender, EventArgs e)
		{
			Provincia byId;
			if (this.Page.IsValid)
			{
				Cliente cliente = base.ClienteRepository.GetById(this.ClientiList.SelectedValue);
				int newId = base.IndirizzoRepository.GetNuovoNumeroIndirizzo(cliente);
				Indirizzo indirizzo = new Indirizzo()
				{
					Id = newId,
					Cliente = cliente,
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
				indirizzo.Nuovo = new bool?(true);
				base.IndirizzoRepository.Save(indirizzo);
				this.ResetFormIndirizzo();
				this.CaricaIndirizzi(cliente);
			}
		}

		private void CaricaClienti()
		{
			IList<Cliente> clienti = base.ClienteRepository.GetClientiAttiviForAgente(base.AgenteAutenticato, (Cliente c) => c.RagioneSociale1, false, false);
			this.ClientiList.DataSource = clienti;
			this.ClientiList.DataBind();
		}

		private void CaricaDettaglioCliente(string codiceCliente)
		{
			Cliente cliente = base.ClienteRepository.GetById(codiceCliente);
			if (cliente == null)
			{
				this.clienteNonTrovato.Visible = true;
				this.ErroreClienteNonTrovatoLiteral.Text = string.Format(Resources.ErroreClienteNonTrovato, codiceCliente);
				this.IndirizziPanel.Visible = false;
			}
			else
			{
				this.IndirizziPanel.Visible = true;
				if (!base.IsPostBack)
				{
					this.SetValidationMessages();
				}
				this.PopolaListe();
				this.CaricaIndirizzi(cliente);
			}
		}

		private void CaricaIndirizzi(Cliente cliente)
		{
			if (cliente.Indirizzi.Count <= 0)
			{
				this.IndirizziRepeater.Visible = false;
			}
			else
			{
				this.IndirizziRepeater.Visible = true;
				this.IndirizziRepeater.DataSource = cliente.Indirizzi;
				this.IndirizziRepeater.DataBind();
			}
		}

		private void CaricaNazioni()
		{
			DropDownList nazioniList = this.NazioniList;
			IRepository<Nazione, string> nazioneRepository = base.NazioneRepository;
			string[] strArrays = new string[] { "Descrizione" };
			nazioniList.DataSource = nazioneRepository.GetAll(strArrays);
			this.NazioniList.DataBind();
		}

		private void CaricaProvince()
		{
			DropDownList provinceList = this.ProvinceList;
			IRepository<Provincia, string> provinciaRepository = base.ProvinciaRepository;
			string[] strArrays = new string[] { "Descrizione" };
			provinceList.DataSource = provinciaRepository.GetAll(strArrays);
			this.ProvinceList.DataBind();
		}

		protected void ClientiList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CaricaDettaglioCliente(this.ClientiList.SelectedValue);
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

		protected void Page_Load(object sender, EventArgs e)
		{
			if (base.ImpostazioniGenerali.BloccoIndirizziNuoviClientiVecchi)
			{
				base.Response.Redirect("~/Errors/AccessoNegato.aspx");
			}
			if (!base.IsPostBack)
			{
				this.CaricaClienti();
				string codiceCliente = base.Request.QueryString["codiceCliente"];
				if (!string.IsNullOrEmpty(codiceCliente))
				{
					if (codiceCliente != null)
					{
						this.ClientiList.SelectedValue = codiceCliente;
					}
					this.CaricaDettaglioCliente(codiceCliente);
				}
			}
		}

		private void PopolaListe()
		{
			this.CaricaProvince();
			this.CaricaNazioni();
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
		}
	}
}