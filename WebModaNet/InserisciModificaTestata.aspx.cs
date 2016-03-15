using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class InserisciModificaTestata : ProtectedPage
	{
		private Ordine ordineInModifica = null;

		private bool ordineRichiesto = false;

		protected Literal TitoloLiteral;

		protected Panel MessaggioTestataPanel;

		protected Literal MessaggioTestataLiteral;

		protected HyperLink NuovoClienteLink;

		protected Panel RicercaClientePanel;

		protected Literal RicercaClienteLiteral;

		protected Label RagioneSocialeLabel;

		protected TextBox RagioneSocialeTextBox;

		protected Label ClienteLabel;

		protected DropDownList ClientiList;

		protected HtmlGenericControl clienteNonTrovato;

		protected Literal ErroreClienteNonTrovatoLiteral;

		protected HtmlGenericControl clienteBloccato;

		protected Literal ClienteBloccatoLiteral;

		protected Panel TestataPanel;

		protected Literal MessaggioConfermaTestataLiteral;

		protected ValidationSummary MainValidationSummary;

		protected Literal DatiClienteLiteral;

		protected Literal RagioneSocialeEtichettaLiteral;

		protected Literal RagioneSocialeLiteral;

		protected Literal IndirizzoEtichettaLiteral;

		protected Literal IndirizzoLiteral;

		protected Literal ImpostazioniAmministrativeLiteral;

		protected Label BancaLabel;

		protected RequiredFieldValidator BancaValidator;

		protected TextBox BancaTextBox;

		protected Label ValutaLabel;

		protected RequiredFieldValidator ValutaValidator;

		protected DropDownList ValuteList;

		protected Literal ImpostazioniCommercialiLiteral;

		protected Label PortoLabel;

		protected DropDownList PortiList;

		protected RequiredFieldValidator PortoValidator;

		protected Label TrasportoLabel;

		protected DropDownList TrasportiList;

		protected RequiredFieldValidator TrasportoValidator;

		protected Label VettoreLabel;

		protected DropDownList VettoriList;

		protected RequiredFieldValidator VettoreValidator;

		protected Literal ImpostazioniOrdineLiteral;

		protected Label MarchioLabel;

		protected RequiredFieldValidator MarchioValidator;

		protected DropDownList MarchiList;

		protected Label TipoOrdineLabel;

		protected RequiredFieldValidator TipoOrdineValidator;

		protected DropDownList TipiOrdineList;

		protected Label DataLabel;

		protected RequiredFieldValidator DataValidator;

		protected CustomValidator DataCustomValidator;

		protected TextBox DataTextBox;

		protected Label IndirizzoConsegnaLabel;

		protected RequiredFieldValidator IndirizzoConsegnaValidator;

		protected DropDownList IndirizziConsegnaList;

		protected HyperLink InserisciIndirizziNuovi;

		protected Panel DataConsegnaManualePanel;

		protected Label DataConsegnaManualeLabel;

		protected TextBox DataConsegnaManualeTextBox;

		protected Panel NotePanel;

		protected Label NoteLabel;

		protected TextBox NoteTextBox;

		protected Panel AllegatoUploadPanel;

		protected Label AllegatoLabel;

		protected FileUpload AllegatoFileUpload;

		protected RegularExpressionValidator AllegatoFileUploadRegExValidator;

		protected Panel AllegatoPanel;

		protected HyperLink AllegatoLink;

		protected CheckBox EliminaAllegatoCheckBox;

		protected Label EliminaAllegatoLabel;

		protected Label RifOrdineLabel;

		protected TextBox RifOrdineTextBox;

		protected Button ConfermaTestataButton;

		protected string CodiceClienteSelezionato
		{
			get
			{
				return this.ViewState["CodiceClienteSelezionato"] as string;
			}
			set
			{
				this.ViewState["CodiceClienteSelezionato"] = value;
			}
		}

		public InserisciModificaTestata()
		{
		}

		private void CaricaClienti()
		{
			IList<Cliente> clienti = base.ClienteRepository.GetClientiAttiviForAgente(base.AgenteAutenticato, (Cliente c) => c.RagioneSociale1, false, false);
			this.ClientiList.DataSource = clienti;
			this.ClientiList.DataBind();
		}

		private void CaricaDettaglioCliente()
		{
			string codiceCliente = this.ClientiList.SelectedValue;
			Cliente cliente = base.ClienteRepository.GetById(codiceCliente);
			if (cliente == null)
			{
				this.clienteNonTrovato.Visible = true;
				this.ErroreClienteNonTrovatoLiteral.Text = string.Format(Resources.ErroreClienteNonTrovato, codiceCliente);
				this.TestataPanel.Visible = false;
			}
			else if (!cliente.IsBloccato())
			{
				this.TestataPanel.Visible = true;
				this.CodiceClienteSelezionato = cliente.Codice;
				this.CaricaTestata();
			}
			else
			{
				this.clienteBloccato.Visible = true;
				this.ClienteBloccatoLiteral.Text = Resources.ErroreClienteBloccato;
				this.TestataPanel.Visible = false;
			}
		}

		private void CaricaTestata()
		{
			int id;
			Cliente cliente = base.ClienteRepository.GetById(this.CodiceClienteSelezionato);
			Ordine ordine = this.GetOrdineInModifica();
			this.RagioneSocialeLiteral.Text = cliente.RagioneSociale;
			this.IndirizzoLiteral.Text = base.IndirizzoRepository.GetIndirizzoPredefinitoForCliente(cliente).ToString();
			if (ordine == null)
			{
				this.BancaTextBox.Text = cliente.Banca;
			}
			else
			{
				this.BancaTextBox.Text = ordine.Banca;
			}
			if (base.AgenteAutenticato.BloccoBanca)
			{
				this.BancaTextBox.Enabled = false;
			}
			this.ValuteList.DataSource = base.AgenteAutenticato.Valute;
			this.ValuteList.DataBind();
			if (ordine != null)
			{
				this.ValuteList.SelectedValue = ordine.Valuta.Codice;
			}
			else if (base.AgenteAutenticato.ValutaPredefinita != null)
			{
				this.ValuteList.SelectedValue = base.AgenteAutenticato.ValutaPredefinita.Codice;
			}
			if (base.AgenteAutenticato.BloccoValuta)
			{
				this.ValuteList.Enabled = false;
			}
			this.PortiList.DataSource = base.PortoRepository.GetAll();
			this.PortiList.DataBind();
			if (ordine != null)
			{
				DropDownList portiList = this.PortiList;
				id = ordine.Porto.Id;
				portiList.SelectedValue = id.ToString();
			}
			else if (cliente.PortoPredefinito != null)
			{
				DropDownList str = this.PortiList;
				id = cliente.PortoPredefinito.Id;
				str.SelectedValue = id.ToString();
			}
			if (base.AgenteAutenticato.BloccoPorto)
			{
				this.PortiList.Enabled = false;
			}
			this.TrasportiList.DataSource = base.TrasportoRepository.GetAll();
			this.TrasportiList.DataBind();
			if (ordine != null)
			{
				DropDownList trasportiList = this.TrasportiList;
				id = ordine.Trasporto.Id;
				trasportiList.SelectedValue = id.ToString();
			}
			else if (cliente.TrasportoPredefinito != null)
			{
				DropDownList dropDownList = this.TrasportiList;
				id = cliente.TrasportoPredefinito.Id;
				dropDownList.SelectedValue = id.ToString();
			}
			if (base.AgenteAutenticato.BloccoTrasporto)
			{
				this.TrasportiList.Enabled = false;
			}
			this.VettoriList.DataSource = base.VettoreRepository.GetAll();
			this.VettoriList.DataBind();
			if (ordine != null)
			{
				DropDownList vettoriList = this.VettoriList;
				id = ordine.Vettore.Id;
				vettoriList.SelectedValue = id.ToString();
			}
			else if (cliente.VettorePredefinito != null)
			{
				DropDownList vettoriList1 = this.VettoriList;
				id = cliente.VettorePredefinito.Id;
				vettoriList1.SelectedValue = id.ToString();
			}
			if (base.AgenteAutenticato.BloccoVettore)
			{
				this.VettoriList.Enabled = false;
			}
			this.MarchiList.DataSource = base.AgenteAutenticato.GetMarchi();
			this.MarchiList.DataBind();
			if (ordine != null)
			{
				this.MarchiList.SelectedValue = ordine.Marchio.Codice;
				if (ordine.Dettagli.Count > 0)
				{
					this.MarchiList.Enabled = false;
				}
			}
			this.CaricaTipiOrdine();
			if (ordine != null)
			{
				DropDownList tipiOrdineList = this.TipiOrdineList;
				id = ordine.Tipo.Id;
				tipiOrdineList.SelectedValue = id.ToString();
				if (ordine.Dettagli.Count > 0)
				{
					this.TipiOrdineList.Enabled = false;
				}
			}
			if (ordine == null)
			{
				this.DataTextBox.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Now);
				this.DataConsegnaManualeTextBox.Text = null;
			}
			else
			{
				this.DataTextBox.Text = string.Format("{0:dd/MM/yyyy}", ordine.Data);
				if (ordine.DataConsegnaManuale.HasValue)
				{
					this.DataConsegnaManualeTextBox.Text = string.Format("{0:dd/MM/yyyy}", ordine.DataConsegna);
				}
			}
			if (base.AgenteAutenticato.BloccoDataOrdine)
			{
				this.DataTextBox.Enabled = false;
			}
			if (!base.ImpostazioniGenerali.BloccoDataConsegnaManualeTestata)
			{
				this.DataConsegnaManualePanel.Visible = true;
			}
			else
			{
				this.DataConsegnaManualePanel.Visible = false;
			}
			if (!base.AgenteAutenticato.BloccoDateConsegna)
			{
				this.DataConsegnaManualeTextBox.Enabled = true;
			}
			else
			{
				this.DataConsegnaManualeTextBox.Enabled = false;
			}
			this.IndirizziConsegnaList.Items.Clear();
			List<ListItem> indirizzi = new List<ListItem>();
			foreach (Indirizzo indirizzo in cliente.Indirizzi)
			{
				string str1 = indirizzo.ToString();
				id = indirizzo.Id;
				indirizzi.Add(new ListItem(str1, id.ToString()));
			}
			indirizzi.Add(new ListItem(cliente.GetIndirizzoSedeLegale().ToString(), "0"));
			this.IndirizziConsegnaList.Items.AddRange(indirizzi.ToArray());
			if (ordine == null)
			{
				DropDownList indirizziConsegnaList = this.IndirizziConsegnaList;
				id = cliente.GetIndirizzoPredefinito().Id;
				indirizziConsegnaList.SelectedValue = id.ToString();
			}
			else
			{
				this.IndirizziConsegnaList.SelectedValue = ordine.IdIndirizzoConsegna.ToString();
			}
			if (!base.ImpostazioniGenerali.BloccoIndirizziNuoviClientiVecchi)
			{
				this.InserisciIndirizziNuovi.Visible = true;
				this.InserisciIndirizziNuovi.NavigateUrl = string.Concat("~/NuoviIndirizzi.aspx?codiceCliente=", this.CodiceClienteSelezionato);
			}
			else
			{
				this.InserisciIndirizziNuovi.Visible = false;
			}
			if (ordine != null)
			{
				this.NoteTextBox.Text = ordine.Note;
				if (!string.IsNullOrEmpty(ordine.Allegato))
				{
					this.AllegatoPanel.Visible = true;
					this.AllegatoLink.NavigateUrl = string.Concat(WebConfigSettings.CartellaAllegati, "/", ordine.NomeFileAllegato);
					this.AllegatoLink.Text = ordine.Allegato;
				}
			}
			if (ordine != null)
			{
				this.RifOrdineTextBox.Text = ordine.RiferimentoOrdine;
			}
		}

		private void CaricaTipiOrdine()
		{
			string codiceMarchio = this.MarchiList.SelectedValue;
			Marchio marchioSelezionato = base.MarchioRepository.GetById(codiceMarchio);
			this.TipiOrdineList.Items.Clear();
			if (marchioSelezionato == null)
			{
				this.TipiOrdineList.Items.Add(new ListItem(Resources.NessunTipoOrdine, string.Empty));
			}
			else
			{
				IList<TipoOrdine> tipiOrdine = base.AgenteAutenticato.GetTipiOrdine(marchioSelezionato);
				if (!WebConfigSettings.IsOnline)
				{
					tipiOrdine = (
						from t in tipiOrdine
						where WebConfigSettings.IDTipoOrdineOffline.Contains<int>(t.Id)
						select t).ToList<TipoOrdine>();
				}
				if (tipiOrdine.Count <= 0)
				{
					this.TipiOrdineList.Items.Add(new ListItem(Resources.NessunTipoOrdine, string.Empty));
				}
				else
				{
					this.TipiOrdineList.DataSource = tipiOrdine;
					this.TipiOrdineList.DataBind();
				}
			}
			Ordine ordine = this.GetOrdineInModifica();
			if (ordine != null)
			{
				TipoOrdine tipoOrdine = ordine.Tipo;
				foreach (ListItem item in this.TipiOrdineList.Items)
				{
					if (item.Value == tipoOrdine.Id.ToString())
					{
						this.TipiOrdineList.SelectedValue = ordine.Tipo.Id.ToString();
						break;
					}
				}
			}
		}

		protected void ClientiList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CaricaDettaglioCliente();
		}

		protected void ConfermaTestataButton_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
				string codiceOrdine = this.SalvaTestataOrdine();
				string url = string.Format("~/ModificaOrdine.aspx?codiceOrdine={0}", base.Server.UrlEncode(codiceOrdine));
				base.Response.Redirect(url);
			}
		}

		protected void DataCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			DateTime data = DateTime.MinValue;
			args.IsValid = DateTime.TryParseExact(args.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data);
		}

		protected Ordine GetOrdineInModifica()
		{
			Ordine ordine;
			if (!this.ordineRichiesto)
			{
				this.ordineRichiesto = true;
				int numeroOrdiniTemporanei = base.OrdineRepository.GetNumeroOrdiniForAgenteByStato(WebConfigSettings.CodiceStatoOrdineTemporaneo, base.AgenteAutenticato);
				string codiceOrdine = base.Request.QueryString["codiceOrdine"];
				if (!string.IsNullOrEmpty(codiceOrdine))
				{
					this.ordineInModifica = base.OrdineRepository.GetOrdineForAgente(codiceOrdine, base.AgenteAutenticato);
					if (this.ordineInModifica == null)
					{
						throw new Exception(string.Format(Resources.ErroreOrdineNonTrovato, codiceOrdine));
					}
					if (this.ordineInModifica.Stato.Codice != WebConfigSettings.CodiceStatoOrdineTemporaneo)
					{
						throw new Exception(string.Format(Resources.ErroreModificaOrdineNonTemporaneo, codiceOrdine, this.ordineInModifica.Stato.Descrizione));
					}
					ordine = this.ordineInModifica;
				}
				else
				{
					if (numeroOrdiniTemporanei > 0)
					{
						throw new Exception(Resources.ErroreNuovoOrdine);
					}
					ordine = null;
				}
			}
			else
			{
				ordine = this.ordineInModifica;
			}
			return ordine;
		}

		protected void MarchiList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CaricaTipiOrdine();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.SetValidationMessages();
				this.NotePanel.Visible = WebConfigSettings.OpzioneNoteTestata;
				this.AllegatoUploadPanel.Visible = WebConfigSettings.OpzioneAllegatoTestata;
				Ordine ordine = this.GetOrdineInModifica();
				if (ordine == null)
				{
					if (base.IsAgenteAutenticatoCliente())
					{
						this.MessaggioTestataPanel.Visible = false;
						this.RicercaClientePanel.Visible = false;
						this.TestataPanel.Visible = true;
						Cliente cliente = base.ClienteRepository.GetClienteForAgenteCliente(base.AgenteAutenticato);
						if (cliente == null)
						{
							throw new Exception(string.Format(Resources.ErroreClienteCliente, base.AgenteAutenticato.CodiceUtente));
						}
						this.CodiceClienteSelezionato = cliente.Codice;
						this.CaricaTestata();
					}
					this.CaricaClienti();
				}
				else
				{
					Literal titoloLiteral = this.TitoloLiteral;
					string str = string.Format(Resources.ModificaTestataOrdine, ordine.NumeroOrdineVisibile);
					string str1 = str;
					titoloLiteral.Text = str;
					base.Title = str1;
					this.MessaggioTestataPanel.Visible = false;
					this.RicercaClientePanel.Visible = false;
					this.TestataPanel.Visible = true;
					this.CodiceClienteSelezionato = ordine.Cliente.Codice;
					this.CaricaTestata();
				}
			}
		}

		private string SalvaTestataOrdine()
		{
			Cliente cliente = base.ClienteRepository.GetById(this.CodiceClienteSelezionato);
			DateTime data = DateTime.ParseExact(this.DataTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
			DateTime? dataConsegnaManualeTestata = null;
			DateTime placeholder = DateTime.MinValue;
			if (DateTime.TryParseExact(this.DataConsegnaManualeTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out placeholder))
			{
				dataConsegnaManualeTestata = new DateTime?(placeholder);
			}
			int idIndirizzo = 0;
			int.TryParse(this.IndirizziConsegnaList.SelectedValue, out idIndirizzo);
			Marchio marchio = base.MarchioRepository.GetById(this.MarchiList.SelectedValue);
			TipoOrdine tipoOrdine = base.TipoOrdineRepository.GetById(Convert.ToInt32(this.TipiOrdineList.SelectedValue));
			Valuta valuta = base.ValutaRepository.GetById(this.ValuteList.SelectedValue);
			Porto porto = base.PortoRepository.GetById(Convert.ToInt32(this.PortiList.SelectedValue));
			Trasporto trasporto = base.TrasportoRepository.GetById(Convert.ToInt32(this.TrasportiList.SelectedValue));
			Vettore vettore = base.VettoreRepository.GetById(Convert.ToInt32(this.VettoriList.SelectedValue));
			string nomeNuovoFileAllegato = null;
			string extNuovoFile = null;
			HttpPostedFile postedFile = null;
			bool eliminaVecchioFile = false;
			Ordine ordine = this.GetOrdineInModifica();
			string nomeAllegatoDaSalvare = null;
			if (ordine != null)
			{
				nomeAllegatoDaSalvare = ordine.Allegato;
			}
			if (this.AllegatoFileUpload.HasFile)
			{
				postedFile = this.AllegatoFileUpload.PostedFile;
				FileInfo fileInfo = new FileInfo(postedFile.FileName);
				nomeNuovoFileAllegato = fileInfo.Name;
				nomeAllegatoDaSalvare = nomeNuovoFileAllegato;
				extNuovoFile = fileInfo.Extension;
				if ((ordine == null ? false : !string.IsNullOrEmpty(ordine.Allegato)))
				{
					eliminaVecchioFile = true;
				}
			}
			else if (this.EliminaAllegatoCheckBox.Checked)
			{
				nomeAllegatoDaSalvare = null;
				eliminaVecchioFile = true;
			}
			if (eliminaVecchioFile)
			{
				File.Delete(string.Concat(base.Server.MapPath(WebConfigSettings.CartellaAllegati), Path.DirectorySeparatorChar, ordine.NomeFileAllegato));
			}
			ordine = base.creaModificaOrdine(ordine, marchio, tipoOrdine, data, dataConsegnaManualeTestata, cliente, idIndirizzo, valuta, this.BancaTextBox.Text, porto, trasporto, vettore, this.NoteTextBox.Text, nomeAllegatoDaSalvare, this.RifOrdineTextBox.Text);
			if (nomeNuovoFileAllegato != null)
			{
				object[] objArray = new object[] { base.Server.MapPath(WebConfigSettings.CartellaAllegati), Path.DirectorySeparatorChar, ordine.Codice, extNuovoFile };
				string filePath = string.Concat(objArray);
				if (File.Exists(filePath))
				{
					File.Delete(filePath);
				}
				postedFile.SaveAs(filePath);
			}
			return ordine.Codice;
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
			this.DataCustomValidator.ErrorMessage = ValidationUtils.Date(this.DataLabel.Text);
			this.DataCustomValidator.Text = "*";
		}
	}
}