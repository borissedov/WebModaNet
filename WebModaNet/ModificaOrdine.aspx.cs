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
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class ModificaOrdine : ProtectedPage
	{
		private Ordine ordineInModifica = null;

		private bool warningDisponibilita = false;

		protected Literal ModificaOrdineLiteral;

		protected HyperLink ModificaTestataLink;

		protected HyperLink ImpostazioniOrdineLink;

		protected HyperLink RiepilogoLink;

		protected Literal ImpostazioniOrdineLiteral;

		protected HtmlGenericControl divImpostazioniStaticheOrdine;

		protected Literal TipoOrdineLabelLiteral;

		protected Literal TipoOrdineLiteral;

		protected Literal MarchioLabelLiteral;

		protected Literal MarchioLiteral;

		protected Literal CodiceListinoLabelLiteral;

		protected Literal CodiceListinoLiteral;

		protected Label StagioneLabel;

		protected DropDownList StagioniList;

		protected Label LineaLabel;

		protected DropDownList LineeList;

		protected HtmlGenericControl divGruppo;

		protected Label GruppoLabel;

		protected DropDownList GruppiList;

		protected Label FamigliaLabel;

		protected DropDownList FamiglieList;

		protected HtmlGenericControl divTessuto;

		protected Label TessutoLabel;

		protected DropDownList TessutiList;

		protected HtmlGenericControl divGeneri;

		protected Label GenereLabel;

		protected DropDownList GeneriList;

		protected HtmlGenericControl divBanner1;

		protected Label lblBanner1;

		protected DropDownList Banner1List;

		protected HtmlGenericControl divBanner2;

		protected Label lblBanner2;

		protected DropDownList Banner2List;

		protected Panel DateConsegnaPanel;

		protected Literal DateConsegnaLiteral;

		protected Label DataConsegnaLabel;

		protected RequiredFieldValidator DataConsegnaValidator;

		protected CustomValidator DataConsegnaCustomValidator;

		protected TextBox DataConsegnaTextBox;

		protected HtmlGenericControl divDataUltimaConsegna;

		protected Label DataUltimaConsegnaLabel;

		protected RequiredFieldValidator DataUltimaConsegnaValidator;

		protected CustomValidator DataUltimaConsegnaCustomValidator;

		protected TextBox DataUltimaConsegnaTextBox;

		protected HtmlGenericControl divDataDecorrenza;

		protected Label DataDecorrenzaLabel;

		protected RequiredFieldValidator DataDecorrenzaValidator;

		protected CustomValidator DataDecorrenzaCustomValidator;

		protected TextBox DataDecorrenzaTextBox;

		protected Panel ArticoliPanel;

		protected Literal ArticoliLiteral;

		protected HtmlGenericControl nessunArticolo;

		protected Literal ArticoloNonTrovatoLiteral;

		protected Label CodiceArticoloLabel;

		protected TextBox CodiceArticoloTextBox;

		protected Button CercaPerCodiceButton;

		protected CheckBox NascondiQuantitaZeroCheckBox;

		protected Panel ListaArticoliPanel;

		protected Label ArticoloLabel;

		protected DropDownList ArticoliList;

		protected Panel ImmaginiPanel;

		protected HtmlGenericControl divMostraNascondiImmagini;

		protected LinkButton MostraNascondiImmaginiButton;

		protected HtmlGenericControl nessunaImmagineTrovata;

		protected Literal NessunaImmagineTrovataLiteral;

		protected HtmlGenericControl troppiArticoli;

		protected Literal TroppiArticoloLiteral;

		protected Repeater ImmaginiRepeater;

		protected HtmlGenericControl erroreListino;

		protected Literal ErroreListinoLiteral;

		protected HtmlGenericControl messaggioSuperamentoDisponibilita;

		protected Literal messaggioSuperamentoDisponibilitaLiteral;

		protected HtmlGenericControl messaggioConfermaInserimento;

		protected Literal MessaggioConfermaInserimentoLiteral;

		protected Panel DettaglioArticoloPanel;

		protected Literal ArticoloLiteral;

		protected Panel PdfArticoloPanel;

		protected HyperLink PdfArticoloLink;

		protected HiddenField CodiceArticoloHiddenField;

		protected Literal IntestazionePrezzoAcquistoLiteral;

		protected Literal IntestazionePrezzoConsigliatoLiteral;

		protected Repeater PrezziRepeater;

		protected HtmlGenericControl messaggioQuantitaConfezione;

		protected Button ConfermaUpButton;

		protected CustomValidator ConfermaQuantitaValidator;

		protected CustomValidator ImballiCustomValidator;

		protected Literal IntestazioneVarianteLiteral;

		protected Literal IntestazioneDuplicaLiteral;

		protected HtmlTableCell intestazioneCodiceImballo;

		protected Literal IntestazioneCodiceImballoLiteral;

		protected HtmlTableCell intestazioneQuantitaImballo;

		protected Literal IntestazioneQuantitaImballoLiteral;

		protected Repeater IntestazioniTaglieRepeater;

		protected Literal CopiaIncollaLiteral;

		protected Repeater VariantiRepeater;

		protected Button ConfermaButton;

		protected Panel RiepilogoPanel;

		protected Literal RiepilogoLiteral;

		protected HtmlGenericControl messaggioAnnullamento;

		protected Literal MessaggioAnnullamentoLiteral;

		protected HtmlGenericControl messaggioValoreMinimoOrdine;

		protected HtmlGenericControl ordineVuoto;

		protected Literal OrdineVuotoLiteral;

		protected Label MetodoPagamentoLabel;

		protected Literal MetodoPagamentoLiteral;

		protected Label PortoLabel;

		protected Literal PortoLiteral;

		protected Label TrasportoLabel;

		protected Literal TrasportoLiteral;

		protected Label VettoreLabel;

		protected Literal VettoreLiteral;

		protected HtmlGenericControl nessunArticoloInserito;

		protected Literal NessunArticoloInseritoLiteral;

		protected Panel TabellaRiepilogoPanel;

		protected Literal OperazioniLiteral;

		protected Literal ArticoloRiepilogoLiteral;

		protected Literal VarianteRiepilogoLiteral;

		protected Literal CodiciSegnataglieLiteral;

		protected Repeater IntestazioniTaglieRiepilogoRepeater;

		protected Literal NumeroCapiLiteral;

		protected Literal PrezzoAcquistoLiteral;

		protected Literal litValutaOrdinePR1;

		protected Literal ScontoIntestazioneRiepilogoLiteral;

		protected Literal PrezzoNettoIntestazioneRiepilogoLiteral;

		protected Literal litValutaOrdinePR2;

		protected Literal ImportoLiteral;

		protected Literal litValutaOrdinePR3;

		protected Repeater RiepilogoRepeater;

		protected HtmlTableCell totale;

		protected Literal TotaleOrdineLiteral;

		protected Literal NumeroCapiOrdineLiteral;

		protected Literal litValutaOrdinePR4;

		protected Literal TotaleAcquistoLiteral;

		protected HtmlTableRow rigaSconto;

		protected HtmlTableCell sconto;

		protected Literal ScontoLiteral;

		protected Literal ImportoScontoLiteral;

		protected HtmlTableCell totaleNetto;

		protected Literal TotaleOrdineNettoLiteral;

		protected Literal litValutaOrdinePR5;

		protected Literal TotaleAcquistoNettoLiteral;

		protected Label IndirizzoConsegnaLabel;

		protected DropDownList IndirizziConsegnaDropDownList;

		protected LinkButton EliminaOrdineButton;

		protected LinkButton ChiudiOrdineButton;

		protected CheckBox SospendiOrdineCheckBox;

		private bool _mostraDisponibilitaIcona
		{
			get
			{
				return (bool)this.ViewState["MOSTRA_DISP_ICONA"];
			}
			set
			{
				this.ViewState["MOSTRA_DISP_ICONA"] = value;
			}
		}

		private int _numeroDecimali
		{
			get
			{
				return (int)this.ViewState["NUMERI_DECIMALI"];
			}
			set
			{
				this.ViewState["NUMERI_DECIMALI"] = value;
			}
		}

		private bool AlmenoUnImballo
		{
			get
			{
				object item = this.ViewState["AlmenoUnImballo"];
				if (item == null)
				{
					item = false;
				}
				return (bool)item;
			}
			set
			{
				this.ViewState["AlmenoUnImballo"] = value;
			}
		}

		private string CodiceListino
		{
			get
			{
				return this.ViewState["CodiceListino"] as string ?? string.Empty;
			}
			set
			{
				this.ViewState["CodiceListino"] = value;
			}
		}

		private string codiceOrdine
		{
			get
			{
				return this.ViewState["CODICE_ORDINE"].ToString();
			}
			set
			{
				if (value != null)
				{
					this.ViewState["CODICE_ORDINE"] = value;
				}
				else
				{
					this.ViewState["CODICE_ORDINE"] = string.Empty;
				}
			}
		}

		private bool DisponibilitaAttivata
		{
			get
			{
				object item = this.ViewState["DisponibilitaAttivata"];
				if (item == null)
				{
					item = false;
				}
				return (bool)item;
			}
			set
			{
				this.ViewState["DisponibilitaAttivata"] = value;
			}
		}

		public string HiddenClassName
		{
			get;
			private set;
		}

		private List<ListinoVariante> ListiniVariante
		{
			get
			{
				return this.ViewState["LISTINI_VAR"] as List<ListinoVariante>;
			}
			set
			{
				this.ViewState["LISTINI_VAR"] = value;
			}
		}

		protected bool MostraImmagini
		{
			get
			{
				return (bool)(this.ViewState["MostraImmagini"] ?? base.ImpostazioniGenerali.MostraGalleriaImmagini);
			}
			set
			{
				this.ViewState["MostraImmagini"] = value;
			}
		}

		protected string MostraNascondiImmaginiLabel
		{
			get
			{
				return (!this.MostraImmagini ? Resources.MostraImmagini : Resources.NascondiImmagini);
			}
		}

		private PrezzoLista[] PrezziAcquistoLista
		{
			get
			{
				return this.ViewState["PrezziAcquistoLista"] as PrezzoLista[] ?? new PrezzoLista[0];
			}
			set
			{
				this.ViewState["PrezziAcquistoLista"] = value;
			}
		}

		private List<decimal> ScontiDaPoliticheSconto
		{
			get
			{
				return this.ViewState["SCONTI_POL"] as List<decimal>;
			}
			set
			{
				this.ViewState["SCONTI_POL"] = value;
			}
		}

		public ModificaOrdine()
		{
		}

		private void applicaImpostazioni()
		{
			this.divImpostazioniStaticheOrdine.Visible = WebConfigSettings.OpzioneVisualizzaImpostazioniStaticheOrdine;
			this.divDataUltimaConsegna.Visible = WebConfigSettings.OpzioneVisualizzaDataUltimaConsegna;
			this.divDataDecorrenza.Visible = WebConfigSettings.OpzioneVisualizzaDataDecorrenza;
			this.divMostraNascondiImmagini.Visible = WebConfigSettings.OpzioneMostraTastoNascondiImmagini;
		}

		protected void ArticoliList_OnPreRender(object sender, EventArgs e)
		{
			for (int d = 0; d < this.ArticoliList.Items.Count; d++)
			{
				this.ArticoliList.Items[d].Attributes.Add("title", this.ArticoliList.Items[d].Text);
			}
		}

		protected void ArticoliList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CaricaDettaglioArticolo(this.GetArticoloListaSelezionato());
		}

		protected void BannerList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CodiceArticoloTextBox.Text = string.Empty;
			this.CaricaArticoli();
		}

		private void CaricaArticoli()
		{
			Func<Variante, bool> func = null;
			Func<int, bool> func1 = null;
			List<Expression<Func<Articolo, bool>>> filtri = new List<Expression<Func<Articolo, bool>>>();
			string selectedValue = this.StagioniList.SelectedValue;
			if (!string.IsNullOrEmpty(selectedValue))
			{
				filtri.Add((Articolo a) => a.Stagione.Codice == selectedValue);
			}
			string str = this.LineeList.SelectedValue;
			if (!string.IsNullOrEmpty(str))
			{
				filtri.Add((Articolo a) => a.Linea.Codice == str);
			}
			string selectedValue1 = this.GruppiList.SelectedValue;
			if (!string.IsNullOrEmpty(selectedValue1))
			{
				filtri.Add((Articolo a) => a.Categorie.Any<Categoria>((Categoria c) => (c.Codice == selectedValue1) && c.Tipo.Id == WebConfigSettings.IDTipoCategoriaGruppo));
			}
			string str1 = this.FamiglieList.SelectedValue;
			if (!string.IsNullOrEmpty(str1))
			{
				filtri.Add((Articolo a) => a.Famiglia.Codice == str1);
			}
			string selectedValue2 = this.TessutiList.SelectedValue;
			if (!string.IsNullOrEmpty(selectedValue2))
			{
				filtri.Add((Articolo a) => a.Categorie.Any<Categoria>((Categoria c) => (c.Codice == selectedValue2) && c.Tipo.Id == WebConfigSettings.IDTipoCategoriaTessuto));
			}
			string str2 = this.GeneriList.SelectedValue;
			if (!string.IsNullOrEmpty(str2))
			{
				filtri.Add((Articolo a) => a.Categorie.Any<Categoria>((Categoria c) => (c.Codice == str2) && c.Tipo.Id == WebConfigSettings.IDTipoCategoriaGenere));
			}
			string selectedValue3 = this.Banner1List.SelectedValue;
			if (!string.IsNullOrEmpty(selectedValue3))
			{
				filtri.Add((Articolo a) => a.Categorie.Any<Categoria>((Categoria c) => (c.Codice == selectedValue3) && c.Tipo.Id == WebConfigSettings.IDTipoCategoriaBanner1));
			}
			string str3 = this.Banner2List.SelectedValue;
			if (!string.IsNullOrEmpty(str3))
			{
				filtri.Add((Articolo a) => a.Categorie.Any<Categoria>((Categoria c) => (c.Codice == str3) && c.Tipo.Id == WebConfigSettings.IDTipoCategoriaBanner2));
			}
			string text = this.CodiceArticoloTextBox.Text;
			bool isFiltroCodice = false;
			if (!string.IsNullOrEmpty(text))
			{
				isFiltroCodice = true;
				filtri.Clear();
				CodiceABarre byId = base.CodiceABarreRepository.GetById(text);
				if ((byId == null || byId.Variante == null ? true : byId.Variante.Articolo == null))
				{
					filtri.Add((Articolo a) => a.Codice == text);
				}
				else
				{
					filtri.Add((Articolo a) => a.Codice == byId.Variante.Articolo.Codice);
				}
			}
			Ordine ordineInModifica = this.GetOrdineInModifica();
			filtri.Add((Articolo a) => a.Marchio.Codice == ordineInModifica.Marchio.Codice);
			IList<Stagione> all = base.StagioneRepository.GetAll(base.AgenteAutenticato, ordineInModifica.Marchio, ordineInModifica.Tipo, ordineInModifica.Data);
			filtri.Add((Articolo a) => all.Contains(a.Stagione));
			IList<Articolo> articoli = base.ArticoloRepository.GetAll(filtri.ToArray());
			if (this.NascondiQuantitaZeroCheckBox.Checked)
			{
				IList<Stagione> list = (
					from i in base.AgenteAutenticato.ImpostazioniStagione
					where i.Disponibilita
					select i.Stagione).Distinct<Stagione>().ToList<Stagione>();
				if (list.Count > 0)
				{
					articoli = articoli.Where<Articolo>((Articolo a) => {
						bool flag;
						if (!list.Contains(a.Stagione))
						{
							flag = true;
						}
						else
						{
							IList<Variante> varianti = a.Varianti;
							if (func == null)
							{
								func = (Variante v) => {
									int[] quantita = v.Quantita;
									if (func1 == null)
									{
										func1 = (int q) => q > 0;
									}
									return ((IEnumerable<int>)quantita).Any<int>(func1);
								};
							}
							flag = varianti.Any<Variante>(func);
						}
						return flag;
					}).ToList<Articolo>();
				}
			}
			if (!(articoli.Count <= 0 ? true : articoli.Count > WebConfigSettings.MaxArticoliCaricabili))
			{
				this.nessunArticolo.Visible = false;
				this.troppiArticoli.Visible = false;
				this.ListaArticoliPanel.Visible = true;
				if (!isFiltroCodice)
				{
					Articolo defaultItem = new Articolo()
					{
						Codice = string.Empty
					};
					articoli.Insert(0, defaultItem);
				}
				this.ArticoliList.Items.Clear();
				this.ArticoliList.DataSource = articoli;
				this.ArticoliList.DataBind();
				this.ArticoliList.SelectedValue = articoli[0].Codice;
				if (isFiltroCodice)
				{
					this.CaricaDettaglioArticolo(articoli[0]);
				}
			}
			else if (articoli.Count != 0)
			{
				articoli = new List<Articolo>();
				this.nessunArticolo.Visible = false;
				this.troppiArticoli.Visible = true;
				this.ListaArticoliPanel.Visible = false;
				this.DettaglioArticoloPanel.Visible = false;
			}
			else
			{
				this.nessunArticolo.Visible = true;
				this.troppiArticoli.Visible = false;
				this.ListaArticoliPanel.Visible = false;
				this.DettaglioArticoloPanel.Visible = false;
			}
			this.CaricaImmagini(articoli);
		}

		private void CaricaBlocchi()
		{
			if (base.AgenteAutenticato.BloccoDateConsegna)
			{
				this.DataConsegnaTextBox.Enabled = false;
				this.DataUltimaConsegnaTextBox.Enabled = false;
				this.DataDecorrenzaTextBox.Enabled = false;
			}
		}

		private DateTime CaricaDateConsegna(string codiceStagione)
		{
			DateTime data;
			bool flag;
			bool flag1;
			bool flag2;
			bool flag3;
			DataConsegnaOrdine dataConsegnaOrdine = null;
			DateTime dataConsegna = DateTime.Now;
			DateTime dataDecorrenza = DateTime.Now;
			DateTime dataUltimaConsegna = DateTime.Now;
			Ordine ordineInModifica = this.GetOrdineInModifica();
			Marchio marchio = ordineInModifica.Marchio;
			TipoOrdine tipo = ordineInModifica.Tipo;
			List<Expression<Func<DataConsegnaOrdine, bool>>> predicates = new List<Expression<Func<DataConsegnaOrdine, bool>>>()
			{
				(DataConsegnaOrdine d) => d.Marchio == marchio,
				(DataConsegnaOrdine d) => d.TipoOrdine == tipo,
				(DataConsegnaOrdine d) => d.Stagione.Codice == codiceStagione,
				(DataConsegnaOrdine d) => (d.DataInizioOrdine <= ordineInModifica.Data) && (d.DataFineOrdine >= ordineInModifica.Data)
			};
			dataConsegnaOrdine = base.DataConsegnaOrdineRepository.GetAll(predicates.ToArray()).FirstOrDefault<DataConsegnaOrdine>();
			if (dataConsegnaOrdine == null)
			{
				predicates.Clear();
				predicates.Add((DataConsegnaOrdine d) => d.TipoOrdine == tipo);
				predicates.Add((DataConsegnaOrdine d) => d.Stagione.Codice == codiceStagione);
				predicates.Add((DataConsegnaOrdine d) => (d.DataInizioOrdine <= ordineInModifica.Data) && (d.DataFineOrdine >= ordineInModifica.Data));
				dataConsegnaOrdine = base.DataConsegnaOrdineRepository.GetAll(predicates.ToArray()).FirstOrDefault<DataConsegnaOrdine>();
			}
			if (dataConsegnaOrdine == null)
			{
				throw new Exception(Resources.ErroreDateConsegna);
			}
			DateTime? dataConsegnaManuale = dataConsegnaOrdine.DataConsegna;
			if (!dataConsegnaManuale.HasValue)
			{
				flag = false;
			}
			else
			{
				dataConsegnaManuale = dataConsegnaOrdine.DataConsegna;
				data = ordineInModifica.Data;
				flag = (dataConsegnaManuale.HasValue ? (int)(dataConsegnaManuale.GetValueOrDefault() < data) : 0) == 0;
			}
			if (flag)
			{
				dataConsegnaManuale = dataConsegnaOrdine.DataConsegna;
				dataConsegna = dataConsegnaManuale.Value;
			}
			else
			{
				dataConsegna = DateTime.Now;
			}
			dataConsegnaManuale = dataConsegnaOrdine.DataUltimaConsegna;
			if (!dataConsegnaManuale.HasValue)
			{
				flag1 = false;
			}
			else
			{
				dataConsegnaManuale = dataConsegnaOrdine.DataUltimaConsegna;
				data = ordineInModifica.Data;
				flag1 = (dataConsegnaManuale.HasValue ? (int)(dataConsegnaManuale.GetValueOrDefault() < data) : 0) == 0;
			}
			if (flag1)
			{
				dataConsegnaManuale = dataConsegnaOrdine.DataUltimaConsegna;
				dataUltimaConsegna = dataConsegnaManuale.Value;
			}
			else
			{
				data = DateTime.Now;
				dataUltimaConsegna = data.AddMonths(1);
			}
			dataConsegnaManuale = dataConsegnaOrdine.DataDecorrenza;
			if (!dataConsegnaManuale.HasValue)
			{
				flag2 = false;
			}
			else
			{
				dataConsegnaManuale = dataConsegnaOrdine.DataDecorrenza;
				data = ordineInModifica.Data;
				flag2 = (dataConsegnaManuale.HasValue ? (int)(dataConsegnaManuale.GetValueOrDefault() < data) : 0) == 0;
			}
			if (flag2)
			{
				dataConsegnaManuale = dataConsegnaOrdine.DataDecorrenza;
				dataDecorrenza = dataConsegnaManuale.Value;
			}
			else
			{
				DateTime today = DateTime.Today;
				data = new DateTime(today.Year, today.Month, 1);
				data = data.AddMonths(1);
				dataDecorrenza = data.AddDays(-1);
			}
			dataConsegnaManuale = ordineInModifica.DataConsegnaManuale;
			if (!dataConsegnaManuale.HasValue)
			{
				flag3 = true;
			}
			else
			{
				dataConsegnaManuale = dataConsegnaOrdine.DataConsegna;
				if (!dataConsegnaManuale.HasValue)
				{
					flag3 = false;
				}
				else
				{
					dataConsegnaManuale = dataConsegnaOrdine.DataConsegna;
					data = ordineInModifica.Data;
					flag3 = (dataConsegnaManuale.HasValue ? (int)(dataConsegnaManuale.GetValueOrDefault() < data) : 0) == 0;
				}
			}
			if (!flag3)
			{
				dataConsegnaManuale = ordineInModifica.DataConsegnaManuale;
				dataConsegna = dataConsegnaManuale.Value;
				dataConsegnaManuale = ordineInModifica.DataConsegnaManuale;
				data = dataConsegnaManuale.Value;
				dataUltimaConsegna = data.AddMonths(1);
				dataConsegnaManuale = ordineInModifica.DataConsegnaManuale;
				data = dataConsegnaManuale.Value;
				DateTime todayManuale = data.Date;
				data = new DateTime(todayManuale.Year, todayManuale.Month, 1);
				data = data.AddMonths(1);
				dataDecorrenza = data.AddDays(-1);
			}
			this.DataConsegnaTextBox.Text = string.Format("{0:dd/MM/yyyy}", dataConsegna);
			this.DataUltimaConsegnaTextBox.Text = string.Format("{0:dd/MM/yyyy}", dataUltimaConsegna);
			this.DataDecorrenzaTextBox.Text = string.Format("{0:dd/MM/yyyy}", dataDecorrenza);
			return dataConsegna;
		}

		private void CaricaDettaglioArticolo(Articolo articolo)
		{
			decimal[] prezzi;
			decimal[] sconti;
			ListinoVariante listinoVariante;
			decimal sconto;
			ModificaOrdine.<>c__DisplayClass31 variable;
			string[] strArrays;
			decimal[] numArray;
			int num;
			string codiceVariante;
			if (articolo != null)
			{
				this.CodiceArticoloHiddenField.Value = articolo.Codice;
				Ordine ordineInModifica = this.GetOrdineInModifica();
				DateTime dateTime = this.CaricaDateConsegna(articolo.Stagione.Codice);
				IList<VarianteImballo> listaVariantiCompleta = null;
				if (!WebConfigSettings.ImballiAttivi)
				{
					this.ImballiCustomValidator.Enabled = false;
					listaVariantiCompleta = (
						from v in articolo.Varianti
						where (v.DataInizioValidita > dateTime ? false : v.DataFineValidita >= dateTime)
						select new VarianteImballo(v, null)).ToList<VarianteImballo>();
					this.AlmenoUnImballo = false;
				}
				else
				{
					this.ImballiCustomValidator.Enabled = false;
					IList<VarianteImballo> list = (
						from v in articolo.Varianti
						where (v.DataInizioValidita > dateTime ? false : v.DataFineValidita >= dateTime)
						from i in v.Imballi
						select new VarianteImballo(v, i)).ToList<VarianteImballo>();
					IList<VarianteImballo> variantiSenzaImballi = (
						from v in articolo.Varianti
						where (v.DataInizioValidita > dateTime ? false : v.DataFineValidita >= dateTime)
						select v).Where<Variante>((Variante v) => return !list.Any<VarianteImballo>((VarianteImballo vi) => vi.variante == v)).Select<Variante, VarianteImballo>((Variante v) => new VarianteImballo(v, null)).ToList<VarianteImballo>();
					listaVariantiCompleta = list.Union<VarianteImballo>(variantiSenzaImballi).ToList<VarianteImballo>();
					this.AlmenoUnImballo = list.Count > 0;
				}
				IEnumerable<Variante> variantiValide = 
					from v in articolo.Varianti
					where (v.DataInizioValidita > dateTime ? false : v.DataFineValidita >= dateTime)
					select v;
				int tipoOrdineSpeciale = base.ImpostazioniGenerali.OrdineSpecialeTipo;
				string str = (
					from i in base.AgenteAutenticato.ImpostazioniOrdine
					where (i.Marchio != ordineInModifica.Marchio ? false : i.TipoOrdine == ordineInModifica.Tipo)
					select i.CodiceListinoConsigliato).FirstOrDefault<string>();
				this.ListiniVariante = new List<ListinoVariante>();
				this.ScontiDaPoliticheSconto = new List<decimal>();
				string empty = string.Empty;
				foreach (Variante variante in variantiValide)
				{
					IList<ListinoCliente> listiniCliente = new List<ListinoCliente>();
					if ((!WebConfigSettings.ListiniClienteAttivi ? false : ordineInModifica.Tipo.Id != tipoOrdineSpeciale))
					{
						List<Expression<Func<ListinoCliente, bool>>> filtriListinoCliente = new List<Expression<Func<ListinoCliente, bool>>>()
						{
							(ListinoCliente l) => l.Cliente == ordineInModifica.Cliente,
							(ListinoCliente l) => l.Articolo == articolo,
							(ListinoCliente l) => l.CodiceVariante == variante.Codice,
							(ListinoCliente l) => (l.DataInizioValidita <= dateTime) && (l.DataFineValidita >= dateTime)
						};
						IRepository<ListinoCliente, int> listinoClienteRepository = base.ListinoClienteRepository;
						Expression<Func<ListinoCliente, bool>>[] array = filtriListinoCliente.ToArray();
						strArrays = new string[] { "DataInizioValidita desc" };
						listiniCliente = listinoClienteRepository.GetAll(array, strArrays);
						if (listiniCliente.Count == 0)
						{
							filtriListinoCliente = new List<Expression<Func<ListinoCliente, bool>>>()
							{
								(ListinoCliente l) => l.Cliente == ordineInModifica.Cliente,
								(ListinoCliente l) => l.Articolo == articolo,
								(ListinoCliente l) => l.CodiceVariante == null || (l.CodiceVariante == string.Empty),
								(ListinoCliente l) => (l.DataInizioValidita <= dateTime) && (l.DataFineValidita >= dateTime)
							};
							IRepository<ListinoCliente, int> repository = base.ListinoClienteRepository;
							Expression<Func<ListinoCliente, bool>>[] expressionArray = filtriListinoCliente.ToArray();
							strArrays = new string[] { "DataInizioValidita desc" };
							listiniCliente = repository.GetAll(expressionArray, strArrays);
						}
					}
					if (listiniCliente.Count > 0)
					{
						ListinoCliente listinoCliente = listiniCliente.First<ListinoCliente>();
						if ((empty == string.Empty ? true : !(empty != "0")))
						{
							empty = "0";
							codiceVariante = listinoCliente.CodiceVariante;
							prezzi = listinoCliente.Prezzi;
							sconti = listinoCliente.Sconti;
						}
						else
						{
							this.erroreListino.Visible = true;
							this.ErroreListinoLiteral.Text = Resources.ErroreListinoVarianti;
							this.DettaglioArticoloPanel.Visible = false;
							return;
						}
					}
					else if ((empty == string.Empty ? true : !(empty == "0")))
					{
						empty = ordineInModifica.CodiceListino;
						IList<Listino> listini = new List<Listino>();
						List<Expression<Func<Listino, bool>>> filtriListino = new List<Expression<Func<Listino, bool>>>();
						if (WebConfigSettings.ListiniPerVarianteAttivi)
						{
							filtriListino = new List<Expression<Func<Listino, bool>>>()
							{
								(Listino l) => l.Codice == empty,
								(Listino l) => l.Articolo == articolo,
								(Listino l) => l.CodiceVariante == variante.Codice,
								(Listino l) => (l.DataInizioValidita <= dateTime) && (l.DataFineValidita >= dateTime)
							};
							IListinoRepository listinoRepository = base.ListinoRepository;
							Expression<Func<Listino, bool>>[] array1 = filtriListino.ToArray();
							strArrays = new string[] { "DataInizioValidita desc" };
							listini = listinoRepository.GetAll(array1, strArrays);
						}
						if (listini.Count == 0)
						{
							filtriListino = new List<Expression<Func<Listino, bool>>>()
							{
								(Listino l) => l.Codice == empty,
								(Listino l) => l.Articolo == articolo,
								(Listino l) => l.CodiceVariante == null || (l.CodiceVariante == string.Empty),
								(Listino l) => (l.DataInizioValidita <= dateTime) && (l.DataFineValidita >= dateTime)
							};
							IListinoRepository listinoRepository1 = base.ListinoRepository;
							Expression<Func<Listino, bool>>[] expressionArray1 = filtriListino.ToArray();
							strArrays = new string[] { "DataInizioValidita desc" };
							listini = listinoRepository1.GetAll(expressionArray1, strArrays);
						}
						if (!(listini.Count != 0 ? true : WebConfigSettings.OpzioneForzaListiniMancanti))
						{
							this.erroreListino.Visible = true;
							this.ErroreListinoLiteral.Text = Resources.ErroreListinoNonTrovato;
							this.DettaglioArticoloPanel.Visible = false;
							return;
						}
						else if (listini.Count != 0)
						{
							Listino listino = listini[0];
							codiceVariante = listino.CodiceVariante;
							prezzi = listino.Prezzi;
							sconti = listino.Sconti;
						}
						else
						{
							codiceVariante = variante.Codice;
							prezzi = new decimal[30];
							sconti = new decimal[5];
						}
					}
					else
					{
						this.erroreListino.Visible = true;
						this.ErroreListinoLiteral.Text = Resources.ErroreListinoVarianti;
						this.DettaglioArticoloPanel.Visible = false;
						return;
					}
					this.CodiceListino = empty;
					IList<Listino> listiniConsigliati = null;
					if (WebConfigSettings.OpzioneMostraListinoConsigliato)
					{
						List<Expression<Func<Listino, bool>>> filtriListinoConsigliato = new List<Expression<Func<Listino, bool>>>()
						{
							(Listino l) => l.Codice == str,
							(Listino l) => l.Articolo == articolo,
							(Listino l) => l.CodiceVariante == codiceVariante,
							(Listino l) => (l.DataInizioValidita <= dateTime) && (l.DataFineValidita >= dateTime)
						};
						IListinoRepository listinoRepository2 = base.ListinoRepository;
						Expression<Func<Listino, bool>>[] array2 = filtriListinoConsigliato.ToArray();
						strArrays = new string[] { "DataInizioValidita desc" };
						listiniConsigliati = listinoRepository2.GetAll(array2, strArrays);
					}
					if (!this.ListiniVariante.Any<ListinoVariante>((ListinoVariante v) => v.CodiceVariante == codiceVariante))
					{
						listinoVariante = new ListinoVariante()
						{
							CodiceVariante = codiceVariante,
							PrezziAcquisto = prezzi
						};
						if ((listiniConsigliati == null ? true : listiniConsigliati.Count <= 0))
						{
							listinoVariante.PrezziConsigliati = new decimal[0];
						}
						else
						{
							listinoVariante.PrezziConsigliati = listiniConsigliati[0].Prezzi;
						}
						numArray = sconti;
						for (num = 0; num < (int)numArray.Length; num++)
						{
							sconto = numArray[num];
							if (sconto > new decimal(0))
							{
								listinoVariante.Sconti.Add(sconto);
							}
						}
						this.ListiniVariante.Add(listinoVariante);
					}
				}
				if (WebConfigSettings.PoliticheScontoAttive)
				{
					string codicePoliticaSconti = ordineInModifica.CodicePoliticaSconti;
					if ((string.IsNullOrEmpty(codicePoliticaSconti) ? false : this.CodiceListino != "0"))
					{
						List<Expression<Func<PoliticaSconti, bool>>> filtriPoliticheSconti = new List<Expression<Func<PoliticaSconti, bool>>>()
						{
							(PoliticaSconti p) => (p.Codice == codicePoliticaSconti) && (p.DataDecorrenza <= dateTime)
						};
						IRepository<PoliticaSconti, int> politicaScontiRepository = base.PoliticaScontiRepository;
						Expression<Func<PoliticaSconti, bool>>[] expressionArray2 = filtriPoliticheSconti.ToArray();
						strArrays = new string[] { "Priorita asc" };
						IList<PoliticaSconti> politicheSconti = politicaScontiRepository.GetAll(expressionArray2, strArrays);
						if (politicheSconti.Count > 0)
						{
							foreach (PoliticaSconti politicaSconti in politicheSconti)
							{
								List<Expression<Func<DettaglioPoliticaSconti, bool>>> filtriDettagliPoliticaSconti = new List<Expression<Func<DettaglioPoliticaSconti, bool>>>();
								if (politicaSconti.FlagCodiceArticolo)
								{
									filtriDettagliPoliticaSconti.Add((DettaglioPoliticaSconti d) => d.CodiceArticolo == articolo.Codice);
								}
								if (politicaSconti.FlagCodiceFamiglia)
								{
									filtriDettagliPoliticaSconti.Add((DettaglioPoliticaSconti d) => d.CodiceFamiglia == articolo.Famiglia.Codice);
								}
								if (politicaSconti.FlagCodiceMarchio)
								{
									filtriDettagliPoliticaSconti.Add((DettaglioPoliticaSconti d) => d.CodiceMarchio == articolo.Marchio.Codice);
								}
								if (politicaSconti.FlagCodiceTipologiaCommerciale)
								{
									filtriDettagliPoliticaSconti.Add((DettaglioPoliticaSconti d) => d.CodiceTipologiaCommerciale == ordineInModifica.Cliente.CodiceTipologiaCommerciale);
								}
								if (politicaSconti.FlagCodiceCliente)
								{
									filtriDettagliPoliticaSconti.Add((DettaglioPoliticaSconti d) => d.CodiceCliente == ordineInModifica.Cliente.Codice);
								}
								if (politicaSconti.FlagCodiceCategoriaCliente)
								{
									filtriDettagliPoliticaSconti.Add((DettaglioPoliticaSconti d) => d.CodiceCategoriaCliente == ordineInModifica.Cliente.CodiceCategoria);
								}
								if (politicaSconti.FlagCodiceZona)
								{
									filtriDettagliPoliticaSconti.Add((DettaglioPoliticaSconti d) => d.CodiceZona == ordineInModifica.Cliente.CodiceZona);
								}
								if (politicaSconti.FlagCodiceMetodoPagamento)
								{
									filtriDettagliPoliticaSconti.Add((DettaglioPoliticaSconti d) => d.CodiceMetodoPagamento == ordineInModifica.MetodoPagamento.Codice);
								}
								if (politicaSconti.FlagCodiceListino)
								{
									filtriDettagliPoliticaSconti.Add((DettaglioPoliticaSconti d) => d.CodiceListino == this.CodiceListino);
								}
								if (politicaSconti.FlagCodiceClasseMerceologica)
								{
									filtriDettagliPoliticaSconti.Add((DettaglioPoliticaSconti d) => d.CodiceClasseMerceologica == articolo.CodiceClasseMerceologica);
								}
								if (politicaSconti.FlagCodiceClasseLogistica)
								{
									filtriDettagliPoliticaSconti.Add((DettaglioPoliticaSconti d) => d.CodiceClasseLogistica == articolo.CodiceClasseLogistica);
								}
								filtriDettagliPoliticaSconti.Add((DettaglioPoliticaSconti d) => (d.DataDecorrenza <= dateTime) && (d.DataScadenza >= dateTime));
								filtriDettagliPoliticaSconti.Add((DettaglioPoliticaSconti d) => d.Codice == politicaSconti.Codice);
								filtriDettagliPoliticaSconti.Add((DettaglioPoliticaSconti d) => d.Priorita == politicaSconti.Priorita);
								IRepository<DettaglioPoliticaSconti, int> dettaglioPoliticaScontiRepository = base.DettaglioPoliticaScontiRepository;
								Expression<Func<DettaglioPoliticaSconti, bool>>[] array3 = filtriDettagliPoliticaSconti.ToArray();
								strArrays = new string[] { "Priorita asc" };
								IList<DettaglioPoliticaSconti> dettagliPoliticaSconti = dettaglioPoliticaScontiRepository.GetAll(array3, strArrays);
								if (dettagliPoliticaSconti.Count > 0)
								{
									numArray = dettagliPoliticaSconti.First<DettaglioPoliticaSconti>().Sconti;
									for (num = 0; num < (int)numArray.Length; num++)
									{
										sconto = numArray[num];
										if (sconto > new decimal(0))
										{
											this.ScontiDaPoliticheSconto.Add(sconto);
										}
									}
									break;
								}
							}
						}
					}
				}
				this.DettaglioArticoloPanel.Visible = true;
				this.ArticoloLiteral.Text = articolo.ToString();
				if (!base.ImpostazioniGenerali.MostraPdfArticoli)
				{
					this.PdfArticoloPanel.Visible = false;
				}
				else
				{
					this.PdfArticoloPanel.Visible = true;
					string virtualDirPath = base.ImpostazioniGenerali.CartellaPdfArticoli.TrimEnd(new char[] { '/' });
					string physicalDirPath = base.Server.MapPath(virtualDirPath);
					string fileName = string.Concat(articolo.Codice, ".pdf");
					string virtualFilePath = string.Concat(virtualDirPath, "/", fileName);
					if (!File.Exists(Path.Combine(physicalDirPath, fileName)))
					{
						this.PdfArticoloPanel.Visible = false;
					}
					else
					{
						this.PdfArticoloLink.NavigateUrl = virtualFilePath;
					}
				}
				List<PrezzoLista> prezziLista = new List<PrezzoLista>();
				string[] taglie = articolo.Segnataglie.Taglie;
				int indiceClasse = 1;
				foreach (ListinoVariante listinoVariante in this.ListiniVariante)
				{
					int num1 = 0;
					while (true)
					{
						if ((num1 >= (int)listinoVariante.PrezziAcquisto.Length ? true : num1 >= (int)taglie.Length))
						{
							break;
						}
						if ((!articolo.TaglieValide[num1] ? false : !string.IsNullOrWhiteSpace(taglie[num1])))
						{
							PrezzoLista prezzoListum = new PrezzoLista()
							{
								PrezzoAcquisto = listinoVariante.PrezziAcquisto[num1]
							};
							if (num1 >= (int)listinoVariante.PrezziConsigliati.Length)
							{
								prezzoListum.PrezzoConsigliato = new decimal(0);
							}
							else
							{
								prezzoListum.PrezzoConsigliato = listinoVariante.PrezziConsigliati[num1];
							}
							if ((prezzoListum.PrezzoAcquisto <= new decimal(0) ? true : !(prezzoListum.PrezzoConsigliato > new decimal(0))))
							{
								prezzoListum.Markup = new decimal(0);
							}
							else
							{
								prezzoListum.Markup = prezzoListum.PrezzoConsigliato / prezzoListum.PrezzoAcquisto;
							}
							if (!prezziLista.Any<PrezzoLista>((PrezzoLista p) => p.PrezzoAcquisto == prezzoListum.PrezzoAcquisto))
							{
								prezzoListum.ClasseCssAcquisto = string.Concat("prezzoAcquisto", indiceClasse);
								prezzoListum.ClasseCssConsigliato = (WebConfigSettings.OpzioneMostraListinoConsigliato ? string.Concat("prezzoConsigliato", indiceClasse) : "nascosto");
								prezziLista.Add(prezzoListum);
								indiceClasse++;
							}
							prezzoListum.PrezzoAcquistoFormattato = Utils.FormatNumber(prezzoListum.PrezzoAcquisto, base.AgenteAutenticato);
							prezzoListum.PrezzoConsigliatoFormattato = Utils.FormatNumber(prezzoListum.PrezzoConsigliato, base.AgenteAutenticato);
						}
						num1++;
					}
				}
				prezziLista = (
					from p in prezziLista
					group p by p.PrezzoAcquisto into g
					select g.First<PrezzoLista>()).ToList<PrezzoLista>();
				this.PrezziRepeater.DataSource = prezziLista;
				this.PrezziRepeater.DataBind();
				this.PrezziAcquistoLista = prezziLista.ToArray();
				this.IntestazioniTaglieRepeater.DataSource = articolo.GetTaglie();
				this.IntestazioniTaglieRepeater.DataBind();
				this.DisponibilitaAttivata = (
					from i in base.AgenteAutenticato.ImpostazioniStagione
					where i.Stagione == articolo.Stagione
					select i.Disponibilita).FirstOrDefault<bool>();
				if (articolo.QuantitaConfezione <= 1)
				{
					this.messaggioQuantitaConfezione.Visible = false;
				}
				else
				{
					this.messaggioQuantitaConfezione.Visible = true;
					this.messaggioQuantitaConfezione.InnerHtml = string.Format(Resources.MessaggioQuantitaConfezione, articolo.QuantitaConfezione);
				}
				if (!this.AlmenoUnImballo)
				{
					this.intestazioneCodiceImballo.Visible = false;
					this.intestazioneQuantitaImballo.Visible = false;
				}
				else
				{
					this.intestazioneCodiceImballo.Visible = true;
					this.intestazioneQuantitaImballo.Visible = true;
				}
				this.VariantiRepeater.DataSource = listaVariantiCompleta;
				this.VariantiRepeater.DataBind();
				this.SetSelectedClass(articolo.Codice);
			}
			else
			{
				this.DettaglioArticoloPanel.Visible = false;
			}
		}

		private void CaricaFamiglie()
		{
			string codiceMarchio = this.GetOrdineInModifica().Marchio.Codice;
			string codiceStagione = this.StagioniList.SelectedValue;
			string codiceLinea = this.LineeList.SelectedValue;
			string codiceGruppo = this.GruppiList.SelectedValue;
			TipoCategoria tipoCategoriaGruppo = base.TipoCategoriaRepository.GetById(WebConfigSettings.IDTipoCategoriaGruppo);
			IList<Famiglia> famiglie = base.FamigliaRepository.GetFromStagioneAndLineaAndGruppo(codiceStagione, codiceLinea, codiceGruppo, tipoCategoriaGruppo, codiceMarchio);
			this.FamiglieList.ClearSelection();
			this.FamiglieList.Items.Clear();
			this.FamiglieList.Items.Add(new ListItem(Resources.TutteLista, string.Empty));
			this.FamiglieList.DataSource = famiglie;
			this.FamiglieList.DataBind();
		}

		private void CaricaGeneri()
		{
			if (WebConfigSettings.IDTipoCategoriaGenere == 0)
			{
				this.divGeneri.Visible = false;
			}
			else
			{
				string codiceMarchio = this.GetOrdineInModifica().Marchio.Codice;
				string codiceStagione = this.StagioniList.SelectedValue;
				TipoCategoria tipoCategoriaGenere = base.TipoCategoriaRepository.GetById(WebConfigSettings.IDTipoCategoriaGenere);
				IList<Categoria> generi = base.CategoriaRepository.GetFromTipoAndStagione(tipoCategoriaGenere, codiceStagione, codiceMarchio);
				this.GeneriList.ClearSelection();
				this.GeneriList.Items.Clear();
				this.GeneriList.Items.Add(new ListItem(Resources.TuttiLista, string.Empty));
				this.GeneriList.DataSource = generi;
				this.GeneriList.DataBind();
			}
		}

		private void CaricaGruppi()
		{
			if (WebConfigSettings.IDTipoCategoriaGruppo == 0)
			{
				this.divGruppo.Visible = false;
			}
			else
			{
				string codiceMarchio = this.GetOrdineInModifica().Marchio.Codice;
				string codiceStagione = this.StagioniList.SelectedValue;
				string codiceLinea = this.LineeList.SelectedValue;
				TipoCategoria tipoCategoriaGruppo = base.TipoCategoriaRepository.GetById(WebConfigSettings.IDTipoCategoriaGruppo);
				IList<Categoria> gruppi = base.CategoriaRepository.GetFromTipoAndStagioneAndLinea(tipoCategoriaGruppo, codiceStagione, codiceLinea, codiceMarchio);
				this.GruppiList.ClearSelection();
				this.GruppiList.Items.Clear();
				this.GruppiList.Items.Add(new ListItem(Resources.TuttiLista, string.Empty));
				this.GruppiList.DataSource = gruppi;
				this.GruppiList.DataBind();
			}
		}

		private void CaricaImmagini(IList<Articolo> articoli)
		{
			if (this.MostraImmagini)
			{
				List<ImmagineArticolo> immagini = new List<ImmagineArticolo>();
				string path = base.Server.MapPath(WebConfigSettings.CartellaImmaginiArticoli);
				string[] allowedExtensions = WebConfigSettings.AllowedImageExtensions;
				int contaImmagini = 0;
				foreach (Articolo a in articoli)
				{
					bool imageFound = false;
					string[] strArrays = allowedExtensions;
					int num = 0;
					while (num < (int)strArrays.Length)
					{
						string extension = strArrays[num];
						string imageName = string.Concat(a.Codice, WebConfigSettings.ImageSuffix, extension);
						string imageZoomName = string.Concat(a.Codice, WebConfigSettings.ZoomSuffix, extension);
						string imagePath = string.Concat(path, Path.DirectorySeparatorChar, imageName);
						string imageZoomPath = string.Concat(path, Path.DirectorySeparatorChar, imageZoomName);
						if (!File.Exists(imagePath))
						{
							num++;
						}
						else
						{
							ImmagineArticolo image = new ImmagineArticolo()
							{
								CodiceArticolo = a.Codice,
								ImageUrl = string.Concat(WebConfigSettings.CartellaImmaginiArticoli, "\\", imageName)
							};
							if (string.IsNullOrEmpty(a.DescrizioneImmagine))
							{
								image.AlternateText = a.ToString();
							}
							else
							{
								image.AlternateText = a.DescrizioneImmagine.ToString();
							}
							if (!File.Exists(imageZoomPath))
							{
								image.ZoomUrl = string.Concat(WebConfigSettings.CartellaImmaginiArticoli, "\\", imageName);
							}
							else
							{
								image.ZoomUrl = string.Concat(WebConfigSettings.CartellaImmaginiArticoli, "\\", imageZoomName);
							}
							immagini.Add(image);
							contaImmagini++;
							imageFound = true;
							break;
						}
					}
					if ((imageFound ? false : base.ImpostazioniGenerali.MostraImmaginiNonTrovate))
					{
						ImmagineArticolo emptyImage = new ImmagineArticolo()
						{
							CodiceArticolo = a.Codice,
							ImageUrl = string.Concat(WebConfigSettings.CartellaImmaginiArticoli, "\\", WebConfigSettings.EmptyImageName),
							ZoomUrl = string.Concat(WebConfigSettings.CartellaImmaginiArticoli, "\\", WebConfigSettings.EmptyImageName),
							AlternateText = a.ToString()
						};
						immagini.Add(emptyImage);
						contaImmagini++;
					}
					if (contaImmagini > WebConfigSettings.MaxGalleryImages)
					{
						break;
					}
				}
				if (immagini.Count <= 0)
				{
					this.nessunaImmagineTrovata.Visible = !this.troppiArticoli.Visible;
					this.ImmaginiRepeater.Visible = false;
				}
				else
				{
					this.nessunaImmagineTrovata.Visible = false;
					this.ImmaginiRepeater.Visible = true;
					this.ImmaginiRepeater.DataSource = immagini;
					this.ImmaginiRepeater.DataBind();
				}
			}
			else
			{
				this.nessunaImmagineTrovata.Visible = false;
				this.ImmaginiRepeater.Visible = false;
			}
		}

		public void CaricaInfoStaticheOrdine()
		{
			Ordine ordine = this.GetOrdineInModifica();
			System.Web.UI.Page page = this.Page;
			Literal modificaOrdineLiteral = this.ModificaOrdineLiteral;
			string str = string.Format(Resources.ModificaOrdineTitolo, ordine.NumeroOrdineVisibile);
			string str1 = str;
			modificaOrdineLiteral.Text = str;
			page.Title = str1;
			this.ModificaTestataLink.NavigateUrl = string.Concat("~/InserisciModificaTestata.aspx?", WebConfigSettings.CodiceOrdineQueryStringKey, "=", base.Server.UrlEncode(ordine.Codice));
			this.TipoOrdineLiteral.Text = ordine.Tipo.Descrizione;
			this.MarchioLiteral.Text = ordine.Marchio.Descrizione;
			this.CodiceListinoLiteral.Text = ordine.CodiceListino;
			string codiceMarchio = ordine.Marchio.Descrizione;
		}

		private void CaricaLinee()
		{
			string codiceMarchio = this.GetOrdineInModifica().Marchio.Codice;
			string codiceStagione = this.StagioniList.SelectedValue;
			IList<Linea> linee = base.LineaRepository.GetFromStagione(codiceMarchio, codiceStagione);
			this.LineeList.ClearSelection();
			this.LineeList.Items.Clear();
			this.LineeList.Items.Add(new ListItem(Resources.TutteLista, string.Empty));
			this.LineeList.DataSource = linee;
			this.LineeList.DataBind();
		}

		private void CaricaRiepilogo()
		{
			int id;
			Ordine ordineInModifica = this.GetOrdineInModifica();
			this.MetodoPagamentoLiteral.Text = ordineInModifica.MetodoPagamento.ToString();
			this.PortoLiteral.Text = ordineInModifica.Porto.Descrizione;
			this.TrasportoLiteral.Text = ordineInModifica.Trasporto.Descrizione;
			this.VettoreLiteral.Text = ordineInModifica.Vettore.Descrizione;
			this.litValutaOrdinePR1.Text = string.Concat("(", ordineInModifica.Valuta.Descrizione, ")");
			this.litValutaOrdinePR2.Text = string.Concat("(", ordineInModifica.Valuta.Descrizione, ")");
			this.litValutaOrdinePR3.Text = string.Concat("(", ordineInModifica.Valuta.Descrizione, ")");
			this.litValutaOrdinePR4.Text = string.Concat("(", ordineInModifica.Valuta.Descrizione, ")");
			this.litValutaOrdinePR5.Text = string.Concat("(", ordineInModifica.Valuta.Descrizione, ")");
			IList<DettaglioOrdine> dettagliOrdine = ordineInModifica.Dettagli;
			if (!base.ImpostazioniGenerali.IdTipiOrdineAnnullamento.Contains<int>(ordineInModifica.Tipo.Id))
			{
				this.messaggioAnnullamento.Visible = false;
			}
			else
			{
				this.messaggioAnnullamento.Visible = true;
				this.MessaggioAnnullamentoLiteral.Text = string.Format(Resources.MessaggioAnnullamento, base.ImpostazioniGenerali.NumeroGiorniAnnullamentoOrdiniSospesi);
			}
			decimal valoreMinimoOrdine = (
				from i in base.AgenteAutenticato.ImpostazioniOrdine
				where (i.Marchio != ordineInModifica.Marchio ? false : i.TipoOrdine == ordineInModifica.Tipo)
				select i.ValoreMinimoOrdine).FirstOrDefault<decimal>();
			decimal totaleOrdine = ordineInModifica.TotaleScontato;
			if (!(valoreMinimoOrdine > new decimal(0)))
			{
				this.messaggioValoreMinimoOrdine.Visible = false;
				this.SospendiOrdineCheckBox.Enabled = true;
			}
			else if (!(totaleOrdine < valoreMinimoOrdine))
			{
				this.messaggioValoreMinimoOrdine.Visible = false;
				this.SospendiOrdineCheckBox.Enabled = true;
				this.SospendiOrdineCheckBox.Checked = false;
			}
			else
			{
				this.messaggioValoreMinimoOrdine.Visible = true;
				this.messaggioValoreMinimoOrdine.InnerHtml = string.Format(Resources.MessaggioValoreMinimoOrdine, ordineInModifica.Valuta.Descrizione, valoreMinimoOrdine);
				this.SospendiOrdineCheckBox.Checked = true;
				this.SospendiOrdineCheckBox.Enabled = false;
			}
			if (dettagliOrdine.Count <= 0)
			{
				this.nessunArticoloInserito.Visible = true;
				this.TabellaRiepilogoPanel.Visible = false;
			}
			else
			{
				this.nessunArticoloInserito.Visible = false;
				this.TabellaRiepilogoPanel.Visible = true;
				RiepilogoOrdine riepilogo = this.GetRiepilogoOrdine(ordineInModifica);
				this.CodiciSegnataglieLiteral.Text = riepilogo.CodiciSegnataglie;
				this.IntestazioniTaglieRiepilogoRepeater.DataSource = riepilogo.Taglie;
				this.IntestazioniTaglieRiepilogoRepeater.DataBind();
				this.RiepilogoRepeater.DataSource = riepilogo.DettagliRiepilogo;
				this.RiepilogoRepeater.DataBind();
				int colspan = 4 + riepilogo.NumeroMassimoColonne;
				this.totale.ColSpan = colspan;
				this.sconto.ColSpan = colspan;
				this.totaleNetto.ColSpan = colspan;
				this.NumeroCapiOrdineLiteral.Text = riepilogo.NumeroCapi.ToString();
				this.TotaleAcquistoLiteral.Text = Utils.FormatNumber(riepilogo.Totale, base.AgenteAutenticato);
				if (!(riepilogo.Sconto > new decimal(0)))
				{
					this.rigaSconto.Visible = false;
				}
				else
				{
					this.rigaSconto.Visible = true;
					this.ScontoLiteral.Text = string.Format("{0:0}%", riepilogo.Sconto);
				}
				this.ImportoScontoLiteral.Text = Utils.FormatNumber((riepilogo.Totale * riepilogo.Sconto) / new decimal(100), base.AgenteAutenticato);
				this.TotaleAcquistoNettoLiteral.Text = Utils.FormatNumber(riepilogo.TotaleScontato, base.AgenteAutenticato);
			}
			Cliente cliente = ordineInModifica.Cliente;
			this.IndirizziConsegnaDropDownList.Items.Clear();
			List<ListItem> indirizzi = new List<ListItem>();
			foreach (Indirizzo indirizzo in cliente.Indirizzi)
			{
				string str = indirizzo.ToString();
				id = indirizzo.Id;
				indirizzi.Add(new ListItem(str, id.ToString()));
			}
			indirizzi.Add(new ListItem(cliente.GetIndirizzoSedeLegale().ToString(), "0"));
			this.IndirizziConsegnaDropDownList.Items.AddRange(indirizzi.ToArray());
			DropDownList indirizziConsegnaDropDownList = this.IndirizziConsegnaDropDownList;
			id = ordineInModifica.IdIndirizzoConsegna;
			indirizziConsegnaDropDownList.SelectedValue = id.ToString();
		}

		private void CaricaStagioni()
		{
			Ordine ordine = this.GetOrdineInModifica();
			IList<Stagione> stagioni = base.StagioneRepository.GetAll(base.AgenteAutenticato, ordine.Marchio, ordine.Tipo, ordine.Data);
			this.StagioniList.DataSource = stagioni;
			this.StagioniList.DataBind();
		}

		private void CaricaTessuti()
		{
			if (WebConfigSettings.IDTipoCategoriaTessuto == 0)
			{
				this.divTessuto.Visible = false;
			}
			else
			{
				string codiceMarchio = this.GetOrdineInModifica().Marchio.Codice;
				string codiceStagione = this.StagioniList.SelectedValue;
				string codiceLinea = this.LineeList.SelectedValue;
				string codiceFamiglia = this.FamiglieList.SelectedValue;
				TipoCategoria tipoCategoriaTessuto = base.TipoCategoriaRepository.GetById(WebConfigSettings.IDTipoCategoriaTessuto);
				IList<Categoria> tessuti = base.CategoriaRepository.GetFromTipoAndStagioneAndLineaAndFamiglia(tipoCategoriaTessuto, codiceStagione, codiceLinea, codiceFamiglia, codiceMarchio);
				this.TessutiList.ClearSelection();
				this.TessutiList.Items.Clear();
				this.TessutiList.Items.Add(new ListItem(Resources.TuttiLista, string.Empty));
				this.TessutiList.DataSource = tessuti;
				this.TessutiList.DataBind();
			}
		}

		protected void CercaPerCodiceButton_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
				this.ClearSelections();
				this.CaricaArticoli();
			}
		}

		private bool CheckQuantitaArticoli()
		{
			bool flag;
			RepeaterItemCollection variantiItems = this.VariantiRepeater.Items;
			bool found = false;
			foreach (RepeaterItem varianteItem in variantiItems)
			{
				if ((varianteItem.ItemType == ListItemType.Item ? true : varianteItem.ItemType == ListItemType.AlternatingItem))
				{
					Repeater quantitaRepeater = varianteItem.FindControl("QuantitaRepeater") as Repeater;
					if (quantitaRepeater != null)
					{
						foreach (RepeaterItem quantitaItem in quantitaRepeater.Items)
						{
							if (!quantitaItem.Visible)
							{
								flag = true;
							}
							else
							{
								flag = (quantitaItem.ItemType == ListItemType.Item ? false : quantitaItem.ItemType != ListItemType.AlternatingItem);
							}
							if (!flag)
							{
								TextBox quantitaTextBox = quantitaItem.FindControl("QuantitaTextBox") as TextBox;
								if (quantitaTextBox != null)
								{
									int quantita = 0;
									int.TryParse(quantitaTextBox.Text, out quantita);
									if (quantita > 0)
									{
										found = true;
										break;
									}
								}
							}
						}
						if (found)
						{
							break;
						}
					}
				}
			}
			return found;
		}

		private bool CheckQuantitaImballi()
		{
			RepeaterItemCollection variantiItems = this.VariantiRepeater.Items;
			bool quantitaImballiCorrette = true;
			foreach (RepeaterItem varianteItem in variantiItems)
			{
				if ((varianteItem.ItemType == ListItemType.Item ? true : varianteItem.ItemType == ListItemType.AlternatingItem))
				{
					TextBox quantitaImballoTextBox = varianteItem.FindControl("QuantitaImballoTextBox") as TextBox;
					HtmlTableCell cellaCodiceImballo = varianteItem.FindControl("cellaCodiceImballo") as HtmlTableCell;
					Label codiceImballoLabel = varianteItem.FindControl("CodiceImballoLabel") as Label;
					Repeater quantitaRepeater = varianteItem.FindControl("QuantitaRepeater") as Repeater;
					if ((quantitaImballoTextBox == null || cellaCodiceImballo == null || codiceImballoLabel == null ? false : quantitaRepeater != null))
					{
						if (!(quantitaImballoTextBox.Text == string.Empty ? false : !(quantitaImballoTextBox.Text == "0")))
						{
							continue;
						}
						else if ((!cellaCodiceImballo.Visible ? false : codiceImballoLabel.Visible))
						{
							Imballo imballo = base.ImballoRepository.Find(codiceImballoLabel.Text);
							int[] quantitaImballo = (imballo != null ? imballo.Quantita : new int[99]);
							RepeaterItemCollection quantitaItems = quantitaRepeater.Items;
							int index = 0;
							foreach (RepeaterItem quantitaItem in quantitaItems)
							{
								if ((quantitaItem.ItemType == ListItemType.Item ? true : quantitaItem.ItemType == ListItemType.AlternatingItem))
								{
									if (quantitaItem.Visible)
									{
										TextBox quantitaTextBox = quantitaItem.FindControl("QuantitaTextBox") as TextBox;
										if (quantitaTextBox != null)
										{
											int quantita = 0;
											int.TryParse(quantitaTextBox.Text, out quantita);
											if (quantita == 0)
											{
												if (quantitaImballo[index] != 0)
												{
													quantitaImballiCorrette = false;
													break;
												}
											}
											else if (quantita < 0)
											{
												quantitaImballiCorrette = false;
												break;
											}
											else if ((quantitaImballo[index] == 0 ? true : quantita % quantitaImballo[index] != 0))
											{
												quantitaImballiCorrette = false;
												break;
											}
										}
									}
									index++;
								}
							}
							if (!quantitaImballiCorrette)
							{
								break;
							}
						}
						else
						{
							continue;
						}
					}
				}
			}
			return quantitaImballiCorrette;
		}

		private void ChiudiOrdine(Ordine ordine)
		{
			IList<DettaglioOrdine> dettagliOrdine = ordine.Dettagli;
			string messaggio = string.Empty;
			if (!this.SospendiOrdineCheckBox.Checked)
			{
				ordine.Stato = base.StatoOrdineRepository.GetById(WebConfigSettings.CodiceStatoOrdineChiuso);
				messaggio = string.Format(Resources.MessaggioOrdineChiuso, ordine.NumeroOrdineVisibile);
			}
			else
			{
				ordine.Stato = base.StatoOrdineRepository.GetById(WebConfigSettings.CodiceStatoOrdineSospeso);
				messaggio = string.Format(Resources.MessaggioOrdineSospeso, ordine.NumeroOrdineVisibile);
			}
			ordine.NumeroCapi = dettagliOrdine.Sum<DettaglioOrdine>((DettaglioOrdine d) => d.NumeroCapi);
			ordine.Totale = dettagliOrdine.Sum<DettaglioOrdine>((DettaglioOrdine d) => d.Totale);
			ordine.DataConsegna = dettagliOrdine[0].DataConsegna;
			ordine.DataUltimaConsegna = dettagliOrdine[0].DataUltimaConsegna;
			ordine.DataDecorrenza = dettagliOrdine[0].DataDecorrenza;
			ordine.IdIndirizzoConsegna = Convert.ToInt32(this.IndirizziConsegnaDropDownList.SelectedValue);
			base.OrdineRepository.Save(ordine);
			base.SuccessMessage = messaggio;
			base.Response.Redirect("~/Ordini.aspx");
		}

		protected void ChiudiOrdineButton_Click(object sender, EventArgs e)
		{
			Ordine ordine = this.GetOrdineInModifica();
			if (ordine.Dettagli.Count <= 0)
			{
				this.ordineVuoto.Visible = true;
			}
			else
			{
				this.ordineVuoto.Visible = false;
				this.ChiudiOrdine(ordine);
			}
		}

		private void ClearSelections()
		{
			this.StagioniList.ClearSelection();
			this.LineeList.ClearSelection();
			this.GruppiList.ClearSelection();
			this.FamiglieList.ClearSelection();
			this.TessutiList.ClearSelection();
			this.GeneriList.ClearSelection();
			this.Banner1List.ClearSelection();
			this.Banner2List.ClearSelection();
		}

		protected void ConfermaButton_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
				this.SalvaDettagliOrdine();
				this.DettaglioArticoloPanel.Visible = false;
				this.CaricaRiepilogo();
			}
		}

		protected void ConfermaQuantitaValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			args.IsValid = this.CheckQuantitaArticoli();
		}

		private Ordine CreaOrdineDefault()
		{
			Cliente cliente = base.ClienteRepository.GetClienteForAgenteCliente(base.AgenteAutenticato);
			if (cliente == null)
			{
				throw new Exception(string.Format(Resources.ErroreClienteCliente, base.AgenteAutenticato.CodiceUtente));
			}
			DateTime data = DateTime.Now;
			int idIndirizzo = 0;
			Marchio marchio = base.AgenteAutenticato.GetMarchi()[0];
			IList<TipoOrdine> tipiOrdine = base.AgenteAutenticato.GetTipiOrdine(marchio);
			if (tipiOrdine.Count == 0)
			{
				throw new Exception(string.Format(Resources.ErroreNessunTipoOrdine, marchio.Descrizione));
			}
			TipoOrdine tipoOrdine = tipiOrdine[0];
			Valuta valuta = null;
			if (base.AgenteAutenticato.ValutaPredefinita != null)
			{
				valuta = base.AgenteAutenticato.ValutaPredefinita;
			}
			else if (base.AgenteAutenticato.Valute.Count > 0)
			{
				valuta = base.AgenteAutenticato.Valute[0];
			}
			if (valuta == null)
			{
				throw new Exception(string.Format(Resources.ErroreValutaDefault, new object[0]));
			}
			MetodoPagamento metodoPagamento = cliente.MetodoPagamentoPredefinito;
			string codiceListino = cliente.CodiceListinoPredefinito;
			if (cliente.PortoPredefinito == null)
			{
				throw new Exception(string.Format(Resources.ErroreNessunPorto, cliente.Descrizione));
			}
			Porto porto = cliente.PortoPredefinito;
			if (cliente.TrasportoPredefinito == null)
			{
				throw new Exception(string.Format(Resources.ErroreNessunTrasporto, cliente.Descrizione));
			}
			Trasporto trasporto = cliente.TrasportoPredefinito;
			if (cliente.VettorePredefinito == null)
			{
				throw new Exception(string.Format(Resources.ErroreNessunVettore, cliente.Descrizione));
			}
			Vettore vettore = cliente.VettorePredefinito;
			base.StatoOrdineRepository.GetById(WebConfigSettings.CodiceStatoOrdineTemporaneo);
			string codicePoliticaSconti = cliente.CodicePoliticaSconti;
			string banca = cliente.Banca;
			Ordine ordine = base.creaModificaOrdine(null, marchio, tipoOrdine, DateTime.Now, new DateTime?(DateTime.Now), cliente, idIndirizzo, valuta, banca, porto, trasporto, vettore, string.Empty, string.Empty, string.Empty);
			return ordine;
		}

		protected void DataCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			DateTime data = DateTime.MinValue;
			args.IsValid = DateTime.TryParseExact(args.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data);
		}

		protected void DisponibilitaCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			int quantitaInserita = 0;
			int.TryParse(args.Value, out quantitaInserita);
			if (quantitaInserita != 0)
			{
				CustomValidator validator = (CustomValidator)source;
				Label disponibilitaLabel = (Label)validator.Parent.FindControl("DisponibilitaLabel");
				Image DisponibilitaImg = (Image)validator.Parent.FindControl("DisponibilitaImg");
				if ((disponibilitaLabel.Visible ? true : DisponibilitaImg.Visible))
				{
					int quantitaDisponibile = 0;
					int.TryParse(disponibilitaLabel.Text, out quantitaDisponibile);
					validator.ErrorMessage = Resources.ErroreQuantitaDisponibile;
					if (!WebConfigSettings.OpzioneBloccaDisponibilita)
					{
						args.IsValid = true;
						if (quantitaInserita > quantitaDisponibile)
						{
							this.warningDisponibilita = true;
						}
					}
					else
					{
						args.IsValid = quantitaInserita <= quantitaDisponibile;
					}
				}
				else
				{
					args.IsValid = true;
				}
			}
			else
			{
				args.IsValid = true;
			}
		}

		private void EliminaDettaglio(DettaglioOrdine dettaglioOrdine)
		{
			Ordine ordine = this.GetOrdineInModifica();
			base.DettaglioOrdineRepository.Delete(dettaglioOrdine);
			ordine.NumeroCapi = ordine.Dettagli.Sum<DettaglioOrdine>((DettaglioOrdine d) => d.NumeroCapi);
			ordine.Totale = ordine.Dettagli.Sum<DettaglioOrdine>((DettaglioOrdine d) => d.Totale);
			base.OrdineRepository.Save(ordine);
			this.CaricaDettaglioArticolo(this.GetArticoloListaSelezionato());
			this.CaricaRiepilogo();
		}

		private void EliminaOrdine(Ordine ordine)
		{
			base.OrdineRepository.Delete(ordine);
			if (!string.IsNullOrEmpty(ordine.Allegato))
			{
				File.Delete(string.Concat(base.Server.MapPath(WebConfigSettings.CartellaAllegati), Path.DirectorySeparatorChar, ordine.NomeFileAllegato));
			}
			base.SuccessMessage = string.Format(Resources.MessaggioOrdineEliminato, ordine.NumeroOrdineVisibile);
			base.Response.Redirect("~/Ordini.aspx");
		}

		protected void EliminaOrdineButton_Click(object sender, EventArgs e)
		{
			this.EliminaOrdine(this.GetOrdineInModifica());
		}

		protected void FamiglieList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CodiceArticoloTextBox.Text = string.Empty;
			this.CaricaTessuti();
			this.CaricaArticoli();
		}

		protected void GeneriList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CodiceArticoloTextBox.Text = string.Empty;
			this.CaricaArticoli();
		}

		private void GestisciTendineBanner()
		{
			if (WebConfigSettings.IDTipoCategoriaBanner1 == 0)
			{
				this.divBanner1.Visible = false;
			}
			else
			{
				TipoCategoria tipoCategoria1 = base.TipoCategoriaRepository.GetById(WebConfigSettings.IDTipoCategoriaBanner1);
				this.lblBanner1.Text = tipoCategoria1.Descrizione;
				IList<Categoria> listaElementi1 = base.CategoriaRepository.GetFromTipo(tipoCategoria1);
				this.Banner1List.ClearSelection();
				this.Banner1List.Items.Clear();
				this.Banner1List.Items.Add(new ListItem(Resources.TuttiLista, string.Empty));
				this.Banner1List.DataSource = listaElementi1;
				this.Banner1List.DataBind();
			}
			if (WebConfigSettings.IDTipoCategoriaBanner2 == 0)
			{
				this.divBanner2.Visible = false;
			}
			else
			{
				TipoCategoria tipoCategoria2 = base.TipoCategoriaRepository.GetById(WebConfigSettings.IDTipoCategoriaBanner2);
				this.lblBanner2.Text = tipoCategoria2.Descrizione;
				IList<Categoria> listaElementi2 = base.CategoriaRepository.GetFromTipo(tipoCategoria2);
				this.Banner2List.ClearSelection();
				this.Banner2List.Items.Clear();
				this.Banner2List.Items.Add(new ListItem(Resources.TuttiLista, string.Empty));
				this.Banner2List.DataSource = listaElementi2;
				this.Banner2List.DataBind();
			}
			string tipoCategoriaBanner = base.Request.QueryString["tc"];
			string codiceCategoriaBanner = base.Request.QueryString["cc"];
			if (tipoCategoriaBanner == WebConfigSettings.IDTipoCategoriaBanner1.ToString())
			{
				this.Banner1List.SelectedValue = codiceCategoriaBanner;
			}
			else if (tipoCategoriaBanner == WebConfigSettings.IDTipoCategoriaBanner2.ToString())
			{
				this.Banner2List.SelectedValue = codiceCategoriaBanner;
			}
			else if (tipoCategoriaBanner == "91")
			{
				this.StagioniList.SelectedValue = codiceCategoriaBanner;
			}
			else if (tipoCategoriaBanner == "92")
			{
				this.LineeList.SelectedValue = codiceCategoriaBanner;
			}
			else if (tipoCategoriaBanner == "93")
			{
				this.GruppiList.SelectedValue = codiceCategoriaBanner;
			}
		}

		private Articolo GetArticoloListaSelezionato()
		{
			return base.ArticoloRepository.GetById(this.ArticoliList.SelectedValue);
		}

		private Ordine GetOrdineInModifica()
		{
			Ordine ordine;
			if (this.ordineInModifica == null)
			{
				if (!string.IsNullOrEmpty(this.codiceOrdine))
				{
					this.ordineInModifica = base.OrdineRepository.GetOrdineForAgente(this.codiceOrdine, base.AgenteAutenticato);
				}
				else
				{
					if (!WebConfigSettings.TestataOrdineDefault)
					{
						throw new Exception(Resources.ErroreCodiceOrdineNonTrovato);
					}
					IList<Ordine> ordiniTemporanei = base.OrdineRepository.GetOrdiniForAgenteByStato(WebConfigSettings.CodiceStatoOrdineTemporaneo, base.AgenteAutenticato);
					if (ordiniTemporanei.Count <= 0)
					{
						this.ordineInModifica = this.CreaOrdineDefault();
						this.ordineInModifica.Dettagli = new List<DettaglioOrdine>();
						this.codiceOrdine = this.ordineInModifica.Codice;
					}
					else
					{
						if (ordiniTemporanei.Count > 1)
						{
							throw new Exception(Resources.ErroreOrdiniTemporanei);
						}
						this.ordineInModifica = ordiniTemporanei[0];
					}
				}
				if (this.ordineInModifica == null)
				{
					throw new Exception(string.Format(Resources.ErroreOrdineNonTrovato, this.codiceOrdine));
				}
				if (this.ordineInModifica.Stato.Codice != WebConfigSettings.CodiceStatoOrdineTemporaneo)
				{
					throw new Exception(string.Format(Resources.ErroreModificaOrdineNonTemporaneo, this.codiceOrdine, this.ordineInModifica.Stato.Descrizione));
				}
				ordine = this.ordineInModifica;
			}
			else
			{
				ordine = this.ordineInModifica;
			}
			return ordine;
		}

		public RiepilogoOrdine GetRiepilogoOrdine(Ordine ordine)
		{
			Segnataglie segnataglie;
			int num;
			int j;
			string[] strArrays;
			IntPtr intPtr;
			RiepilogoOrdine riepilogoOrdine = new RiepilogoOrdine();
			IList<DettaglioOrdine> dettagliOrdine = base.DettaglioOrdineRepository.GetDettagliOrdineFromOrdine(ordine);
			Dictionary<string, string[]> mappaTaglie = new Dictionary<string, string[]>();
			foreach (DettaglioOrdine dettaglioOrdine in dettagliOrdine)
			{
				segnataglie = dettaglioOrdine.Segnataglie;
				string codiceSegnataglie = segnataglie.Codice;
				string[] taglieSegnataglie = segnataglie.Taglie;
				int numeroTaglie = (int)taglieSegnataglie.Length;
				bool[] taglieValide = dettaglioOrdine.Variante.Articolo.TaglieValide;
				if (!mappaTaglie.ContainsKey(codiceSegnataglie))
				{
					mappaTaglie.Add(codiceSegnataglie, new string[numeroTaglie]);
				}
				for (num = 0; num < numeroTaglie; num++)
				{
					if ((!taglieValide[num] ? false : !string.IsNullOrWhiteSpace(taglieSegnataglie[num])))
					{
						mappaTaglie[codiceSegnataglie][num] = taglieSegnataglie[num];
					}
				}
			}
			int numeroMassimoColonne = mappaTaglie.Max<KeyValuePair<string, string[]>>((KeyValuePair<string, string[]> d) => d.Value.Count<string>((string s) => !string.IsNullOrWhiteSpace(s)));
			riepilogoOrdine.NumeroMassimoColonne = numeroMassimoColonne;
			string[] taglieIntestazione = new string[riepilogoOrdine.NumeroMassimoColonne];
			IList<string[]> listaSegnataglie = (
				from d in mappaTaglie
				select d.Value).ToList<string[]>();
			foreach (string[] segnataglie in listaSegnataglie)
			{
				string[] taglieValide = (
					from s in segnataglie
					where !string.IsNullOrWhiteSpace(s)
					select s).ToArray<string>();
				for (num = 0; num < numeroMassimoColonne; num++)
				{
					if (num >= (int)taglieValide.Length)
					{
						string[] strArrays1 = taglieIntestazione;
						strArrays = strArrays1;
						int num1 = num;
						intPtr = (IntPtr)num1;
						strArrays1[num1] = string.Concat(strArrays[intPtr], "&nbsp;<br />");
					}
					else
					{
						string[] strArrays2 = taglieIntestazione;
						strArrays = strArrays2;
						int num2 = num;
						intPtr = (IntPtr)num2;
						strArrays2[num2] = string.Concat(strArrays[intPtr], taglieValide[num], "<br />");
					}
				}
			}
			taglieIntestazione = (
				from i in taglieIntestazione
				select Regex.Replace(i, "<br />$", string.Empty)).ToArray<string>();
			riepilogoOrdine.Taglie = taglieIntestazione;
			string str = (
				from i in base.AgenteAutenticato.ImpostazioniOrdine
				where (i.Marchio != ordine.Marchio ? false : i.TipoOrdine == ordine.Tipo)
				select i.CodiceListinoConsigliato).FirstOrDefault<string>();
			IList<Listino> listiniConsigliati = base.ListinoRepository.GetListiniConsigliatiFromOrdine(str, ordine);
			List<DettaglioOrdineRiepilogo> dettagliRiepilogo = new List<DettaglioOrdineRiepilogo>();
			foreach (DettaglioOrdine dettaglioOrdine1 in dettagliOrdine)
			{
				decimal[] prezzi = dettaglioOrdine1.Prezzi;
				decimal[] prezziDistinti = prezzi.Distinct<decimal>().ToArray<decimal>();
				int[] quantita = dettaglioOrdine1.Quantita;
				segnataglie = dettaglioOrdine1.Segnataglie;
				int numeroTaglieSegnataglie = (int)segnataglie.Taglie.Length;
				string[] taglieValideSegnataglie = mappaTaglie[segnataglie.Codice];
				decimal[] prezziConsigliati = new decimal[(int)prezzi.Length];
				Listino listinoConsigliato = listiniConsigliati.FirstOrDefault<Listino>((Listino l) => l.Articolo == dettaglioOrdine1.Variante.Articolo);
				if (listinoConsigliato != null)
				{
					prezziConsigliati = listinoConsigliato.Prezzi;
				}
				for (num = 0; num < (int)prezziDistinti.Length; num++)
				{
					List<int> quantitaRiepilogo = new List<int>();
					int numeroCapi = 0;
					List<decimal> prezziConsigliatiRiepilogo = new List<decimal>();
					for (j = 0; j < numeroTaglieSegnataglie; j++)
					{
						if (!string.IsNullOrWhiteSpace(taglieValideSegnataglie[j]))
						{
							if (!(prezziDistinti[num] == prezzi[j]))
							{
								quantitaRiepilogo.Add(0);
							}
							else
							{
								quantitaRiepilogo.Add(quantita[j]);
								numeroCapi = numeroCapi + quantita[j];
								prezziConsigliatiRiepilogo.Add(prezziConsigliati[j]);
							}
						}
					}
					int numeroColonneQuantitaRiepilogo = quantitaRiepilogo.Count;
					if (numeroColonneQuantitaRiepilogo < numeroMassimoColonne)
					{
						for (j = 0; j < numeroMassimoColonne - numeroColonneQuantitaRiepilogo; j++)
						{
							quantitaRiepilogo.Add(0);
						}
					}
					if (numeroCapi > 0)
					{
						DettaglioOrdineRiepilogo dettaglioRiepilogo = new DettaglioOrdineRiepilogo()
						{
							CodiceArticolo = dettaglioOrdine1.Variante.Articolo.Codice,
							DescrizioneArticolo = dettaglioOrdine1.Variante.Articolo.ToString(),
							CodiceVariante = dettaglioOrdine1.Variante.Codice,
							DescrizioneVariante = dettaglioOrdine1.Variante.ToString(),
							CodiceSegnataglie = segnataglie.Codice,
							Quantita = quantitaRiepilogo.ToArray(),
							NumeroCapi = numeroCapi,
							PrezzoAcquistoSingolo = prezziDistinti[num]
						};
						decimal frazionePrezzo = new decimal(1);
						for (j = 0; j < WebConfigSettings.NumeroMassimoScontiDettaglioOrdine; j++)
						{
							frazionePrezzo = frazionePrezzo * (new decimal(1) - (dettaglioOrdine1.Sconti[j] / new decimal(100)));
						}
						dettaglioRiepilogo.PrezzoNettoSingolo = dettaglioRiepilogo.PrezzoAcquistoSingolo * frazionePrezzo;
						dettaglioRiepilogo.Sconto = new decimal(1) - frazionePrezzo;
						dettaglioRiepilogo.PrezzoConsigliatoSingolo = prezziConsigliatiRiepilogo.FirstOrDefault<decimal>();
						if ((dettaglioRiepilogo.PrezzoConsigliatoSingolo <= new decimal(0) ? true : !(dettaglioRiepilogo.PrezzoAcquistoSingolo > new decimal(0))))
						{
							dettaglioRiepilogo.Markup = new decimal(0);
						}
						else
						{
							dettaglioRiepilogo.Markup = dettaglioRiepilogo.PrezzoConsigliatoSingolo / dettaglioRiepilogo.PrezzoAcquistoSingolo;
						}
						decimal totale = dettaglioRiepilogo.NumeroCapi * dettaglioRiepilogo.PrezzoAcquistoSingolo;
						for (j = 0; j < WebConfigSettings.NumeroMassimoScontiDettaglioOrdine; j++)
						{
							if (dettaglioOrdine1.Sconti[j] > new decimal(0))
							{
								totale = totale - ((totale * dettaglioOrdine1.Sconti[j]) / new decimal(100));
							}
						}
						dettaglioRiepilogo.Totale = Math.Round(totale, base.ImpostazioniGenerali.NumeroDecimali, MidpointRounding.AwayFromZero);
						dettaglioRiepilogo.TotaleConsigliato = dettaglioRiepilogo.NumeroCapi * dettaglioRiepilogo.PrezzoConsigliatoSingolo;
						dettaglioRiepilogo.IdDettaglio = dettaglioOrdine1.Id;
						dettagliRiepilogo.Add(dettaglioRiepilogo);
					}
				}
			}
			dettagliRiepilogo = (
				from d in dettagliRiepilogo
				orderby d.CodiceArticolo, d.CodiceVariante
				select d).ToList<DettaglioOrdineRiepilogo>();
			RiepilogoOrdine riepilogoOrdine1 = riepilogoOrdine;
			riepilogoOrdine1.CodiciSegnataglie = string.Concat(riepilogoOrdine1.CodiciSegnataglie, string.Join("<br />", (
				from d in dettagliRiepilogo
				select d.CodiceSegnataglie).Distinct<string>()));
			riepilogoOrdine.NumeroCapi = dettagliRiepilogo.Sum<DettaglioOrdineRiepilogo>((DettaglioOrdineRiepilogo d) => d.NumeroCapi);
			riepilogoOrdine.TotaleConsigliato = dettagliRiepilogo.Sum<DettaglioOrdineRiepilogo>((DettaglioOrdineRiepilogo d) => d.TotaleConsigliato);
			riepilogoOrdine.Totale = dettagliRiepilogo.Sum<DettaglioOrdineRiepilogo>((DettaglioOrdineRiepilogo d) => d.Totale);
			riepilogoOrdine.Sconto = ordine.ScontoMetodoPagamento;
			riepilogoOrdine.TotaleScontato = riepilogoOrdine.Totale - ((riepilogoOrdine.Totale * riepilogoOrdine.Sconto) / new decimal(100));
			riepilogoOrdine.DettagliRiepilogo = dettagliRiepilogo;
			riepilogoOrdine.MarkupMedio = (
				from d in riepilogoOrdine.DettagliRiepilogo
				where d.Markup > new decimal(0)
				select d.Markup).DefaultIfEmpty<decimal>(new decimal(0)).Average<decimal>((decimal d) => d);
			return riepilogoOrdine;
		}

		protected void GruppiList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CodiceArticoloTextBox.Text = string.Empty;
			this.CaricaFamiglie();
			this.CaricaTessuti();
			this.CaricaArticoli();
		}

		protected void ImballiCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			args.IsValid = this.CheckQuantitaImballi();
		}

		protected void ImmaginiRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			string codiceArticolo = e.CommandArgument as string;
			if (!string.IsNullOrEmpty(codiceArticolo))
			{
				this.ArticoliList.SelectedValue = codiceArticolo;
				this.CaricaDettaglioArticolo(base.ArticoloRepository.GetById(codiceArticolo));
			}
		}

		protected void IntestazioniTaglieRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			TagliaInfo taglia = item.DataItem as TagliaInfo;
			if (taglia != null)
			{
				item.Visible = (!taglia.Valida ? false : !string.IsNullOrWhiteSpace(taglia.Descrizione));
			}
		}

		protected void LineeList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CodiceArticoloTextBox.Text = string.Empty;
			this.CaricaGruppi();
			this.CaricaFamiglie();
			this.CaricaTessuti();
			this.CaricaArticoli();
		}

		protected void MostraNascondiImmaginiButton_Click(object sender, EventArgs e)
		{
			if (!this.MostraImmagini)
			{
				this.MostraNascondiImmaginiButton.RemoveCssClass("mostra");
				this.MostraNascondiImmaginiButton.AddCssClass("nascondi");
				this.MostraImmagini = !this.MostraImmagini;
				this.CaricaArticoli();
			}
			else
			{
				this.MostraNascondiImmaginiButton.RemoveCssClass("nascondi");
				this.MostraNascondiImmaginiButton.AddCssClass("mostra");
				this.MostraImmagini = !this.MostraImmagini;
				this.nessunaImmagineTrovata.Visible = false;
				this.ImmaginiRepeater.Visible = false;
			}
		}

		protected void MostraNascondiImmaginiButton_PreRender(object sender, EventArgs e)
		{
			this.MostraNascondiImmaginiButton.Text = this.MostraNascondiImmaginiLabel;
		}

		protected void NascondiQuantitaZeroCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			this.CaricaArticoli();
		}

		protected override void OnPreRender(EventArgs e)
		{
			if (!WebConfigSettings.OpzioneMostraListinoConsigliato)
			{
				this.HiddenClassName = "nascosto";
			}
			base.OnPreRender(e);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.codiceOrdine = base.Request.QueryString[WebConfigSettings.CodiceOrdineQueryStringKey];
				this._numeroDecimali = base.AgenteAutenticato.NumeroDecimali;
				this._mostraDisponibilitaIcona = base.AgenteAutenticato.MostraDisponibilitaIcona;
				this.SetValidationMessages();
				this.applicaImpostazioni();
				this.CaricaInfoStaticheOrdine();
				this.CaricaBlocchi();
				this.CaricaStagioni();
				this.PopolaSottoListe();
				this.GestisciTendineBanner();
				this.CaricaArticoli();
				this.CaricaRiepilogo();
			}
		}

		private void PopolaSottoListe()
		{
			this.CaricaLinee();
			this.CaricaGruppi();
			this.CaricaFamiglie();
			this.CaricaTessuti();
			this.CaricaGeneri();
		}

		protected void QuantitaConfezioneCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			int quantitaInserita = 0;
			int.TryParse(args.Value, out quantitaInserita);
			if (quantitaInserita != 0)
			{
				CustomValidator validator = (CustomValidator)source;
				HtmlInputHidden quantitaConfezioneField = (HtmlInputHidden)validator.Parent.FindControl("quantitaConfezioneHiddenField");
				int quantitaConfezione = 0;
				int.TryParse(quantitaConfezioneField.Value, out quantitaConfezione);
				validator.ErrorMessage = string.Format(Resources.ErroreQuantitaConfezione, quantitaConfezione);
				args.IsValid = quantitaInserita % quantitaConfezione == 0;
			}
			else
			{
				args.IsValid = true;
			}
		}

		protected void QuantitaRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			TagliaInfo taglia = item.DataItem as TagliaInfo;
			TextBox quantitaTextBox = item.FindControl("QuantitaTextBox") as TextBox;
			HtmlGenericControl boxPulsanti = item.FindControl("boxPulsanti") as HtmlGenericControl;
			Panel notaAltreDisponibilitaPanel = item.FindControl("NotaAltreDisponibilitaPanel") as Panel;
			Panel dispEtichettaPanel = item.FindControl("DispEtichettaPanel") as Panel;
			Label disponibilitaLabel = item.FindControl("DisponibilitaLabel") as Label;
			Label NotaLabel = item.FindControl("NotaLabel") as Label;
			Image disponibilitaImg = item.FindControl("disponibilitaImg") as Image;
			HtmlInputHidden quantitaDisponibileHiddenField = item.FindControl("quantitaDisponibileHiddenField") as HtmlInputHidden;
			HtmlInputHidden quantitaConfezioneHiddenField = item.FindControl("quantitaConfezioneHiddenField") as HtmlInputHidden;
			if ((taglia == null || quantitaTextBox == null || boxPulsanti == null || disponibilitaLabel == null || disponibilitaImg == null || quantitaDisponibileHiddenField == null ? false : quantitaConfezioneHiddenField != null))
			{
				this.GetOrdineInModifica();
				for (int i = 0; i < (int)this.PrezziAcquistoLista.Length; i++)
				{
					if (taglia.PrezzoAcquisto == this.PrezziAcquistoLista[i].PrezzoAcquisto)
					{
						quantitaTextBox.AddCssClass(this.PrezziAcquistoLista[i].ClasseCssAcquisto);
					}
				}
				item.Visible = (!taglia.Valida ? false : !string.IsNullOrWhiteSpace(taglia.Descrizione));
				if ((!WebConfigSettings.DisponibilitaAttivate ? true : !taglia.DisponibilitaAttivata))
				{
					notaAltreDisponibilitaPanel.Visible = false;
					dispEtichettaPanel.Visible = false;
					disponibilitaLabel.Visible = false;
					disponibilitaImg.Visible = false;
					quantitaDisponibileHiddenField.Value = "999999";
				}
				else
				{
					int quantitaDisponibile = (taglia.QuantitaDisponibile > 0 ? taglia.QuantitaDisponibile : 0);
					dispEtichettaPanel.Visible = !this._mostraDisponibilitaIcona;
					disponibilitaLabel.Visible = !this._mostraDisponibilitaIcona;
					disponibilitaImg.Visible = this._mostraDisponibilitaIcona;
					disponibilitaLabel.Text = quantitaDisponibile.ToString();
					if (quantitaDisponibile <= base.ImpostazioniGenerali.DisponibilitaLimiteInferiore)
					{
						if ((!WebConfigSettings.OpzioneVarianteinEsaurimento ? true : !taglia.VarianteInEsaurimento))
						{
							disponibilitaImg.ImageUrl = WebConfigSettings.ImmagineDisponibilitaMin;
							disponibilitaImg.ToolTip = Resources.DisponibilitaMin;
						}
						else
						{
							disponibilitaImg.ImageUrl = WebConfigSettings.ImmagineDisponibilitaInEsaurimento;
							disponibilitaImg.ToolTip = Resources.DisponibilitaInEsaurimento;
						}
					}
					else if (quantitaDisponibile > base.ImpostazioniGenerali.DisponibilitaLimiteSuperiore)
					{
						disponibilitaImg.ImageUrl = WebConfigSettings.ImmagineDisponibilitaMax;
						disponibilitaImg.ToolTip = Resources.DisponibilitaMax;
					}
					else
					{
						disponibilitaImg.ImageUrl = WebConfigSettings.ImmagineDisponibilitaMed;
						disponibilitaImg.ToolTip = Resources.DisponibilitaMed;
					}
					if (WebConfigSettings.OpzioneBloccaDisponibilita)
					{
						quantitaDisponibileHiddenField.Value = quantitaDisponibile.ToString();
					}
				}
				NotaLabel.Text = taglia.Nota;
				quantitaConfezioneHiddenField.Value = taglia.QuantitaConfezione.ToString();
				if (taglia.ImballiAttivati)
				{
					quantitaTextBox.Attributes["readonly"] = "readonly";
					boxPulsanti.Visible = false;
				}
			}
		}

		protected void RiepilogoRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
		{
			int id = Convert.ToInt32(e.CommandArgument);
			DettaglioOrdine dettaglioOrdine = base.DettaglioOrdineRepository.GetById(id);
			string commandName = e.CommandName;
			if (commandName != null)
			{
				if (commandName == "EliminaDettaglio")
				{
					this.EliminaDettaglio(dettaglioOrdine);
				}
				else if (commandName == "ModificaDettaglio")
				{
					this.CodiceArticoloTextBox.Text = string.Empty;
					this.ClearSelections();
					this.CaricaArticoli();
					this.ArticoliList.SelectedValue = dettaglioOrdine.Variante.Articolo.Codice;
					this.CaricaDettaglioArticolo(dettaglioOrdine.Variante.Articolo);
				}
			}
		}

		protected void RiepilogoRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			DettaglioOrdineRiepilogo dettaglioRiepilogo = item.DataItem as DettaglioOrdineRiepilogo;
			Repeater quantitaRepeater = item.FindControl("QuantitaRepeater") as Repeater;
			Literal prezzoAcquistoLiteral = item.FindControl("PrezzoAcquistoLiteral") as Literal;
			Literal prezzoNettoLiteral = item.FindControl("PrezzoNettoLiteral") as Literal;
			Literal importoLiteral = item.FindControl("ImportoLiteral") as Literal;
			if ((dettaglioRiepilogo == null ? false : quantitaRepeater != null))
			{
				quantitaRepeater.DataSource = dettaglioRiepilogo.Quantita;
				quantitaRepeater.DataBind();
				prezzoAcquistoLiteral.Text = Utils.FormatNumber(dettaglioRiepilogo.PrezzoAcquistoSingolo, this._numeroDecimali);
				prezzoNettoLiteral.Text = Utils.FormatNumber(dettaglioRiepilogo.PrezzoNettoSingolo, this._numeroDecimali);
				importoLiteral.Text = Utils.FormatNumber(dettaglioRiepilogo.Totale, this._numeroDecimali);
			}
		}

		private void SalvaDettagliOrdine()
		{
			decimal sconto = new decimal();
			Ordine ordine = this.GetOrdineInModifica();
			RepeaterItemCollection variantiItems = this.VariantiRepeater.Items;
			string messaggioInserimento = string.Empty;
			string codiceArticolo = this.CodiceArticoloHiddenField.Value;
			Articolo articolo = base.ArticoloRepository.GetById(codiceArticolo);
			foreach (RepeaterItem varianteitem in variantiItems)
			{
				if ((varianteitem.ItemType == ListItemType.Item ? true : varianteitem.ItemType == ListItemType.AlternatingItem))
				{
					HiddenField codiceVarianteHiddenField = varianteitem.FindControl("CodiceVarianteHiddenField") as HiddenField;
					Label codiceImballoLabel = varianteitem.FindControl("CodiceImballoLabel") as Label;
					TextBox quantitaImballoTextBox = varianteitem.FindControl("QuantitaImballoTextBox") as TextBox;
					Repeater quantitaRepeater = varianteitem.FindControl("QuantitaRepeater") as Repeater;
					if ((codiceVarianteHiddenField == null || codiceImballoLabel == null || quantitaImballoTextBox == null ? false : quantitaRepeater != null))
					{
						IRepository<Variante, object> varianteRepository = base.VarianteRepository;
						Variante variante = new Variante()
						{
							Codice = codiceVarianteHiddenField.Value,
							Articolo = articolo
						};
						Variante byId = varianteRepository.GetById(variante);
						Imballo imballo = null;
						int numeroImballi = 0;
						if ((!codiceImballoLabel.Visible ? false : !string.IsNullOrEmpty(codiceImballoLabel.Text)))
						{
							imballo = base.ImballoRepository.Find(codiceImballoLabel.Text);
							int.TryParse(quantitaImballoTextBox.Text, out numeroImballi);
						}
						ListinoVariante listino = (
							from l in this.ListiniVariante
							where l.CodiceVariante == byId.Codice
							select l).FirstOrDefault<ListinoVariante>();
						if (listino == null)
						{
							listino = (
								from l in this.ListiniVariante
								where l.CodiceVariante == string.Empty
								select l).FirstOrDefault<ListinoVariante>();
						}
						List<int> quantita = new List<int>();
						List<decimal> prezzi = new List<decimal>();
						RepeaterItemCollection quantitaItems = quantitaRepeater.Items;
						int numeroCapiRiga = 0;
						Dictionary<decimal, int> prezziQuantita = new Dictionary<decimal, int>();
						for (int i = 0; i < quantitaItems.Count; i++)
						{
							RepeaterItem quantitaItem = quantitaItems[i];
							if (!quantitaItem.Visible)
							{
								quantita.Add(0);
								prezzi.Add(listino.PrezziAcquisto[i]);
							}
							else
							{
								TextBox quantitaTextBox = quantitaItem.FindControl("QuantitaTextBox") as TextBox;
								if (quantitaTextBox == null)
								{
									quantita.Add(0);
									prezzi.Add(listino.PrezziAcquisto[i]);
								}
								else
								{
									int quantitaInserita = 0;
									int.TryParse(quantitaTextBox.Text, out quantitaInserita);
									quantita.Add(quantitaInserita);
									numeroCapiRiga = numeroCapiRiga + quantitaInserita;
									prezzi.Add(listino.PrezziAcquisto[i]);
									if (quantitaInserita > 0)
									{
										if (!prezziQuantita.ContainsKey(listino.PrezziAcquisto[i]))
										{
											prezziQuantita.Add(listino.PrezziAcquisto[i], quantitaInserita);
										}
										else
										{
											Dictionary<decimal, int> item = prezziQuantita;
											Dictionary<decimal, int> nums = item;
											decimal prezziAcquisto = listino.PrezziAcquisto[i];
											item[prezziAcquisto] = nums[prezziAcquisto] + quantitaInserita;
										}
									}
								}
							}
						}
						DettaglioOrdine dettaglioOrdine = base.DettaglioOrdineRepository.GetDettaglioOrdineFromVarianteImballo(ordine, byId, imballo);
						if (numeroCapiRiga > 0)
						{
							if (dettaglioOrdine == null)
							{
								dettaglioOrdine = new DettaglioOrdine()
								{
									Ordine = ordine,
									Variante = byId,
									Segnataglie = articolo.Segnataglie,
									Progressivo = base.DettaglioOrdineRepository.GetProgressivo(ordine)
								};
							}
							dettaglioOrdine.SetQuantita(quantita.ToArray());
							dettaglioOrdine.SetPrezzi(prezzi.ToArray());
							dettaglioOrdine.SetSconti(listino.Sconti, this.ScontiDaPoliticheSconto, WebConfigSettings.NumeroMassimoScontiDettaglioOrdine);
							dettaglioOrdine.CodiceListino = this.CodiceListino;
							dettaglioOrdine.NumeroCapi = numeroCapiRiga;
							decimal totaleRiga = new decimal(0);
							foreach (KeyValuePair<decimal, int> pair in prezziQuantita)
							{
								decimal totalePerPrezzo = pair.Key * pair.Value;
								int contaSconti = 0;
								foreach (decimal sconto in listino.Sconti)
								{
									if (contaSconti != WebConfigSettings.NumeroMassimoScontiDettaglioOrdine)
									{
										totalePerPrezzo = totalePerPrezzo - ((totalePerPrezzo * sconto) / new decimal(100));
										contaSconti++;
									}
									else
									{
										break;
									}
								}
								foreach (decimal scontiDaPoliticheSconto in this.ScontiDaPoliticheSconto)
								{
									if (contaSconti != WebConfigSettings.NumeroMassimoScontiDettaglioOrdine)
									{
										totalePerPrezzo = totalePerPrezzo - ((totalePerPrezzo * scontiDaPoliticheSconto) / new decimal(100));
										contaSconti++;
									}
									else
									{
										break;
									}
								}
								totaleRiga = totaleRiga + Math.Round(totalePerPrezzo, base.ImpostazioniGenerali.NumeroDecimali, MidpointRounding.AwayFromZero);
							}
							dettaglioOrdine.Totale = totaleRiga;
							dettaglioOrdine.DataConsegna = DateTime.ParseExact(this.DataConsegnaTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
							dettaglioOrdine.DataUltimaConsegna = DateTime.ParseExact(this.DataUltimaConsegnaTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
							dettaglioOrdine.DataDecorrenza = DateTime.ParseExact(this.DataDecorrenzaTextBox.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
							dettaglioOrdine.Imballo = imballo;
							dettaglioOrdine.NumeroImballi = numeroImballi;
							base.DettaglioOrdineRepository.Save(dettaglioOrdine);
							messaggioInserimento = string.Concat(messaggioInserimento, string.Format(Resources.MessaggioConfermaInserimento, dettaglioOrdine.NumeroCapi, dettaglioOrdine.Variante.ToString(), dettaglioOrdine.Variante.Articolo.ToString()), "<br />");
						}
						else if (dettaglioOrdine != null)
						{
							base.DettaglioOrdineRepository.Delete(dettaglioOrdine);
						}
					}
				}
			}
			ordine.NumeroCapi = ordine.Dettagli.Sum<DettaglioOrdine>((DettaglioOrdine d) => d.NumeroCapi);
			ordine.Totale = ordine.Dettagli.Sum<DettaglioOrdine>((DettaglioOrdine d) => d.Totale);
			base.OrdineRepository.Save(ordine);
			if (this.warningDisponibilita)
			{
				this.messaggioSuperamentoDisponibilita.Visible = true;
			}
			if (!string.IsNullOrEmpty(messaggioInserimento))
			{
				this.messaggioConfermaInserimento.Visible = true;
				this.MessaggioConfermaInserimentoLiteral.Text = Regex.Replace(messaggioInserimento, "<br />$", string.Empty);
			}
		}

		private void SetSelectedClass(string codiceArticolo)
		{
			foreach (RepeaterItem item in this.ImmaginiRepeater.Items)
			{
				HtmlGenericControl listItem = item.FindControl("immagineListItem") as HtmlGenericControl;
				HiddenField codice = item.FindControl("CodiceHiddenField") as HiddenField;
				LinkButton link = item.FindControl("ImmagineArticoloButton") as LinkButton;
				if ((listItem == null || codice == null ? false : link != null))
				{
					if (!codice.Value.Equals(codiceArticolo, StringComparison.OrdinalIgnoreCase))
					{
						listItem.Attributes["class"] = null;
						link.RemoveCssClass("selected");
					}
					else
					{
						listItem.Attributes["class"] = "selected";
						link.AddCssClass("selected");
					}
				}
			}
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
			this.DataConsegnaCustomValidator.ErrorMessage = ValidationUtils.Date(this.DataConsegnaLabel.Text);
			this.DataConsegnaCustomValidator.Text = "*";
			this.DataUltimaConsegnaCustomValidator.ErrorMessage = ValidationUtils.Date(this.DataUltimaConsegnaLabel.Text);
			this.DataUltimaConsegnaCustomValidator.Text = "*";
			this.DataDecorrenzaCustomValidator.ErrorMessage = ValidationUtils.Date(this.DataDecorrenzaLabel.Text);
			this.DataDecorrenzaCustomValidator.Text = "*";
		}

		protected void StagioniList_SelectedIndexChanged(object sender, EventArgs e)
		{
			string codiceStagione = this.StagioniList.SelectedValue;
			if (!string.IsNullOrEmpty(codiceStagione))
			{
				this.CaricaDateConsegna(codiceStagione);
			}
			this.CodiceArticoloTextBox.Text = string.Empty;
			this.PopolaSottoListe();
			this.CaricaArticoli();
		}

		protected void TessutiList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CodiceArticoloTextBox.Text = string.Empty;
			this.CaricaArticoli();
		}

		protected void VariantiRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			string extension;
			string imageName;
			string imagePath;
			int i;
			string[] cartellaImmaginiVarianti;
			RepeaterItem item = e.Item;
			VarianteImballo varianteImballo = item.DataItem as VarianteImballo;
			Variante variante = varianteImballo.variante;
			Image immagineVarianteImage = item.FindControl("ImmagineVarianteImage") as Image;
			HtmlTableCell cellaCodiceImballo = item.FindControl("cellaCodiceImballo") as HtmlTableCell;
			Label codiceImballoLabel = item.FindControl("CodiceImballoLabel") as Label;
			HtmlTableCell cellaQuantitaImballo = item.FindControl("cellaQuantitaImballo") as HtmlTableCell;
			PlaceHolder quantitaImballoPlaceHolder = item.FindControl("QuantitaImballoPlaceHolder") as PlaceHolder;
			TextBox quantitaImballoTextBox = item.FindControl("QuantitaImballoTextBox") as TextBox;
			HiddenField sviluppoImballoHiddenField = item.FindControl("SviluppoImballoHiddenField") as HiddenField;
			Repeater quantitaRepeater = item.FindControl("QuantitaRepeater") as Repeater;
			HtmlInputImage pasteButton = item.FindControl("pasteButton") as HtmlInputImage;
			string path = base.Server.MapPath(WebConfigSettings.CartellaImmaginiVarianti);
			string[] allowedExtensions = WebConfigSettings.AllowedImageExtensions;
			if ((variante == null || immagineVarianteImage == null || cellaCodiceImballo == null || quantitaImballoPlaceHolder == null || codiceImballoLabel == null || cellaQuantitaImballo == null || quantitaImballoTextBox == null || sviluppoImballoHiddenField == null || quantitaRepeater == null ? false : pasteButton != null))
			{
				Articolo articolo = variante.Articolo;
				(item.FindControl("CodiceVarianteHiddenField") as HiddenField).Value = variante.Codice;
				(item.FindControl("DescrizioneCompletaLiteral") as Literal).Text = variante.DescrizioneCompleta;
				string[] taglieTesto = articolo.Segnataglie.Taglie;
				bool imageFound = false;
				immagineVarianteImage.AlternateText = variante.ToString();
				string[] strArrays = allowedExtensions;
				int num = 0;
				while (num < (int)strArrays.Length)
				{
					extension = strArrays[num];
					imageName = string.Concat(articolo.Codice, "_", variante.Codice, extension);
					object[] directorySeparatorChar = new object[] { path, Path.DirectorySeparatorChar, articolo.CodiceClasseLogistica, Path.DirectorySeparatorChar, imageName };
					imagePath = string.Concat(directorySeparatorChar);
					if (!File.Exists(imagePath))
					{
						imageName = string.Concat(variante.Codice, extension);
						directorySeparatorChar = new object[] { path, Path.DirectorySeparatorChar, articolo.CodiceClasseLogistica, Path.DirectorySeparatorChar, imageName };
						imagePath = string.Concat(directorySeparatorChar);
					}
					if (!File.Exists(imagePath))
					{
						num++;
					}
					else
					{
						cartellaImmaginiVarianti = new string[] { WebConfigSettings.CartellaImmaginiVarianti, "\\", articolo.CodiceClasseLogistica, "\\", imageName };
						immagineVarianteImage.ImageUrl = string.Concat(cartellaImmaginiVarianti);
						immagineVarianteImage.Style["width"] = "150px";
						imageFound = true;
						break;
					}
				}
				if (!imageFound)
				{
					strArrays = allowedExtensions;
					num = 0;
					while (num < (int)strArrays.Length)
					{
						extension = strArrays[num];
						imageName = string.Concat(variante.Codice, extension);
						imagePath = string.Concat(path, Path.DirectorySeparatorChar, imageName);
						if (!File.Exists(imagePath))
						{
							num++;
						}
						else
						{
							immagineVarianteImage.ImageUrl = string.Concat(WebConfigSettings.CartellaImmaginiVarianti, "\\", imageName);
							immagineVarianteImage.Style["width"] = "150px";
							imageFound = true;
							break;
						}
					}
				}
				if (!imageFound)
				{
					immagineVarianteImage.ImageUrl = WebConfigSettings.ImmagineVarianteNonTrovata;
				}
				bool imballiAttivati = varianteImballo.imballo != null;
				if (imballiAttivati)
				{
					codiceImballoLabel.Text = varianteImballo.imballo.Codice;
					List<int> quantitaValide = new List<int>();
					bool[] taglieValide = articolo.TaglieValide;
					i = 0;
					while (true)
					{
						if ((i >= (int)taglieValide.Length ? true : i >= (int)taglieTesto.Length))
						{
							break;
						}
						if ((!taglieValide[i] ? false : !string.IsNullOrWhiteSpace(taglieTesto[i])))
						{
							quantitaValide.Add(varianteImballo.imballo.Quantita[i]);
						}
						i++;
					}
					string sviluppoTaglie = string.Join<int>("-", quantitaValide);
					sviluppoImballoHiddenField.Value = sviluppoTaglie;
					quantitaImballoPlaceHolder.Visible = true;
					codiceImballoLabel.ToolTip = sviluppoTaglie;
					quantitaImballoTextBox.Visible = true;
					pasteButton.Visible = false;
				}
				else if (!this.AlmenoUnImballo)
				{
					cellaCodiceImballo.Visible = false;
					cellaQuantitaImballo.Visible = false;
				}
				else
				{
					quantitaImballoPlaceHolder.Visible = false;
					codiceImballoLabel.Visible = false;
				}
				Ordine ordine = this.GetOrdineInModifica();
				Variante variante1 = variante;
				bool disponibilitaAttivata = this.DisponibilitaAttivata;
				IArticoloRepository articoloRepository = base.ArticoloRepository;
				cartellaImmaginiVarianti = new string[] { WebConfigSettings.CodiceStatoOrdineElaborato, WebConfigSettings.CodiceStatoOrdineAnnullato, WebConfigSettings.CodiceStatoOrdineEliminato };
				IList<TagliaInfo> taglie = articolo.GetTaglieForVariante(variante1, disponibilitaAttivata, imballiAttivati, articoloRepository, ordine, cartellaImmaginiVarianti);
				DettaglioOrdine dettaglioOrdine = base.DettaglioOrdineRepository.GetDettaglioOrdineFromVarianteImballo(ordine, variante, varianteImballo.imballo);
				if (dettaglioOrdine != null)
				{
					for (i = 0; i < taglie.Count; i++)
					{
						taglie[i].QuantitaInserita = dettaglioOrdine.Quantita[i];
					}
					quantitaImballoTextBox.Text = dettaglioOrdine.NumeroImballi.ToString();
					this.DataConsegnaTextBox.Text = string.Format("{0:dd/MM/yyyy}", dettaglioOrdine.DataConsegna);
					this.DataUltimaConsegnaTextBox.Text = string.Format("{0:dd/MM/yyyy}", dettaglioOrdine.DataUltimaConsegna);
					this.DataDecorrenzaTextBox.Text = string.Format("{0:dd/MM/yyyy}", dettaglioOrdine.DataDecorrenza);
				}
				ListinoVariante listino = (
					from l in this.ListiniVariante
					where l.CodiceVariante == variante.Codice
					select l).FirstOrDefault<ListinoVariante>();
				if (listino == null)
				{
					listino = (
						from l in this.ListiniVariante
						where l.CodiceVariante == string.Empty
						select l).FirstOrDefault<ListinoVariante>();
				}
				for (i = 0; i < taglie.Count; i++)
				{
					taglie[i].PrezzoAcquisto = listino.PrezziAcquisto[i];
					if (i >= (int)listino.PrezziConsigliati.Length)
					{
						taglie[i].PrezzoConsigliato = new decimal(0);
					}
					else
					{
						taglie[i].PrezzoConsigliato = listino.PrezziConsigliati[i];
					}
				}
				quantitaRepeater.DataSource = taglie;
				quantitaRepeater.DataBind();
			}
		}
	}
}