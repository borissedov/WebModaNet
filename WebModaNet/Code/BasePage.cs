using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;
using Ninject;
using Ninject.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Web.SessionState;
using System.Web.UI;

namespace EW.WebModaNet.Code
{
	public class BasePage : PageBase
	{
		private string infoMessage;

		private string successMessage;

		private string errorMessage;

		private bool _agenteRichiesto;

		private Agente _agenteAutenticato;

		public Agente AgenteAutenticato
		{
			get
			{
				Agente agente;
				if (!this._agenteRichiesto)
				{
					this._agenteRichiesto = true;
					if (this.Session[WebConfigSettings.CodiceAgenteAutenticatoSessionKey] == null)
					{
						this._agenteAutenticato = null;
					}
					else
					{
						this._agenteAutenticato = this.AgenteRepository.GetById(this.Session[WebConfigSettings.CodiceAgenteAutenticatoSessionKey].ToString());
					}
					agente = this._agenteAutenticato;
				}
				else
				{
					agente = this._agenteAutenticato;
				}
				return agente;
			}
			private set
			{
				this._agenteRichiesto = false;
				this.Session[WebConfigSettings.CodiceAgenteAutenticatoSessionKey] = value.CodiceUtente;
			}
		}

		[Inject]
		public IAgenteRepository AgenteRepository
		{
			get;
			set;
		}

		[Inject]
		public IAggiornamentoDatabaseRepository AggiornamentoDatabaseRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<ArticoloCategoria, object> ArticoloCategoriaRepository
		{
			get;
			set;
		}

		[Inject]
		public IArticoloRepository ArticoloRepository
		{
			get;
			set;
		}

		[Inject]
		public ICategoriaRepository CategoriaRepository
		{
			get;
			set;
		}

		[Inject]
		public IClienteRepository ClienteRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<CodiceABarre, string> CodiceABarreRepository
		{
			get;
			set;
		}

		[Inject]
		public ICondizioneCommercialeRepository CondizioneCommercialeRepository
		{
			get;
			set;
		}

		[Inject]
		public IDataConsegnaOrdineRepository DataConsegnaOrdineRepository
		{
			get;
			set;
		}

		[Inject]
		public IDettaglioOrdineRepository DettaglioOrdineRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<DettaglioPoliticaSconti, int> DettaglioPoliticaScontiRepository
		{
			get;
			set;
		}

		[Inject]
		public IDocumentoRepository DocumentoRepository
		{
			get;
			set;
		}

		public string ErrorMessage
		{
			get
			{
				return this.errorMessage;
			}
			set
			{
				this.Session[WebConfigSettings.ErrorMessageSessionKey] = value;
			}
		}

		[Inject]
		public IFamigliaRepository FamigliaRepository
		{
			get;
			set;
		}

		[Inject]
		public IImballoRepository ImballoRepository
		{
			get;
			set;
		}

		[Inject]
		public IImpostazioneApplicazioneRepository ImpostazioneApplicazioneRepository
		{
			get;
			set;
		}

		public ImpostazioniApplicazioneContainer ImpostazioniGenerali
		{
			get;
			private set;
		}

		[Inject]
		public IIndirizzoRepository IndirizzoRepository
		{
			get;
			set;
		}

		public string InfoMessage
		{
			get
			{
				return this.infoMessage;
			}
			set
			{
				this.Session[WebConfigSettings.InfoMessageSessionKey] = value;
			}
		}

		[Inject]
		public ILineaRepository LineaRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<Lingua, string> LinguaRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<ListinoCliente, int> ListinoClienteRepository
		{
			get;
			set;
		}

		[Inject]
		public IListinoRepository ListinoRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<Marchio, string> MarchioRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<MetodoPagamento, string> MetodoPagamentoRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<Nazione, string> NazioneRepository
		{
			get;
			set;
		}

		[Inject]
		public IOrdineRepository OrdineRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<PoliticaSconti, int> PoliticaScontiRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<Porto, int> PortoRepository
		{
			get;
			set;
		}

		[Inject]
		public IPromozioneRepository PromozioneRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<Provincia, string> ProvinciaRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<Segnataglie, string> SegnataglieRepository
		{
			get;
			set;
		}

		[Inject]
		public IStagioneRepository StagioneRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<StatoCliente, string> StatoClienteRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<StatoOrdine, string> StatoOrdineRepository
		{
			get;
			set;
		}

		public string SuccessMessage
		{
			get
			{
				return this.successMessage;
			}
			set
			{
				this.Session[WebConfigSettings.SuccessMessageSessionKey] = value;
			}
		}

		[Inject]
		public IRepository<TipoAgente, string> TipoAgenteRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<TipoCategoria, int> TipoCategoriaRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<TipoOrdine, int> TipoOrdineRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<Trasporto, int> TrasportoRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<Valuta, string> ValutaRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<Variante, object> VarianteRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<Vettore, int> VettoreRepository
		{
			get;
			set;
		}

		[Inject]
		public IRepository<VisibilitaCliente, object> VisibilitaClienteRepository
		{
			get;
			set;
		}

		public BasePage()
		{
		}

		private void CheckVersioni()
		{
			if (string.IsNullOrEmpty(this.ImpostazioniGenerali.VersioneApplicazione))
			{
				this.ImpostazioniGenerali.Salva(new ImpostazioneApplicazione("VersioneApplicazione", WebConfigSettings.VersioneApplicazione));
			}
			if (string.IsNullOrEmpty(this.ImpostazioniGenerali.VersioneDatabase))
			{
				this.ImpostazioniGenerali.Salva(new ImpostazioneApplicazione("VersioneDatabase", WebConfigSettings.VersioneDatabase));
			}
		}

		protected Ordine creaModificaOrdine(Ordine ordine, Marchio marchio, TipoOrdine tipoOrdine, DateTime data, DateTime? dataConsegnaManualeTestata, Cliente cliente, int idIndirizzo, Valuta valuta, string banca, Porto porto, Trasporto trasporto, Vettore vettore, string note, string nomeFileAllegato, string rifordine)
		{
			DateTime now;
			bool flag;
			bool flag1;
			bool flag2;
			MetodoPagamento metodoPagamento = cliente.MetodoPagamentoPredefinito;
			string codiceListino = cliente.CodiceListinoPredefinito;
			string codicePoliticaSconti = cliente.CodicePoliticaSconti;
			DataConsegnaOrdine dataConsegnaOrdine = null;
			DateTime dataConsegna = DateTime.Now;
			DateTime dataDecorrenza = DateTime.Now;
			DateTime dataUltimaConsegna = DateTime.Now;
			List<Expression<Func<DataConsegnaOrdine, bool>>> predicates = new List<Expression<Func<DataConsegnaOrdine, bool>>>()
			{
				(DataConsegnaOrdine d) => d.Marchio == marchio,
				(DataConsegnaOrdine d) => d.TipoOrdine == tipoOrdine,
				(DataConsegnaOrdine d) => (d.DataInizioOrdine <= data) && (d.DataFineOrdine >= data)
			};
			dataConsegnaOrdine = this.DataConsegnaOrdineRepository.GetAll(predicates.ToArray()).FirstOrDefault<DataConsegnaOrdine>();
			if (dataConsegnaOrdine == null)
			{
				predicates.Clear();
				predicates.Add((DataConsegnaOrdine d) => d.TipoOrdine == tipoOrdine);
				predicates.Add((DataConsegnaOrdine d) => (d.DataInizioOrdine <= data) && (d.DataFineOrdine >= data));
				dataConsegnaOrdine = this.DataConsegnaOrdineRepository.GetAll(predicates.ToArray()).FirstOrDefault<DataConsegnaOrdine>();
			}
			if (dataConsegnaOrdine == null)
			{
				throw new Exception(Resources.ErroreDateConsegna);
			}
			DateTime? nullable = dataConsegnaOrdine.DataConsegna;
			if (!nullable.HasValue)
			{
				flag = false;
			}
			else
			{
				nullable = dataConsegnaOrdine.DataConsegna;
				now = data;
				flag = (nullable.HasValue ? nullable.GetValueOrDefault() < now ? 1 : 0 : 0) == 0;
			}
			if (flag)
			{
				nullable = dataConsegnaOrdine.DataConsegna;
				dataConsegna = nullable.Value;
			}
			else
			{
				dataConsegna = DateTime.Now;
			}
			nullable = dataConsegnaOrdine.DataUltimaConsegna;
			if (!nullable.HasValue)
			{
				flag1 = false;
			}
			else
			{
				nullable = dataConsegnaOrdine.DataUltimaConsegna;
				now = data;
                flag1 = (nullable.HasValue ? (nullable.GetValueOrDefault() < now) ? 1 : 0 : 0) == 0;
			}
			if (flag1)
			{
				nullable = dataConsegnaOrdine.DataUltimaConsegna;
				dataUltimaConsegna = nullable.Value;
			}
			else
			{
				now = DateTime.Now;
				dataUltimaConsegna = now.AddMonths(1);
			}
			nullable = dataConsegnaOrdine.DataDecorrenza;
			if (!nullable.HasValue)
			{
				flag2 = false;
			}
			else
			{
				nullable = dataConsegnaOrdine.DataDecorrenza;
				now = data;
				flag2 = (nullable.HasValue ? (nullable.GetValueOrDefault() < now) ? 1 : 0 : 0) == 0;
			}
			if (flag2)
			{
				nullable = dataConsegnaOrdine.DataDecorrenza;
				dataDecorrenza = nullable.Value;
			}
			else
			{
				DateTime today = DateTime.Today;
				now = new DateTime(today.Year, today.Month, 1);
				now = now.AddMonths(1);
				dataDecorrenza = now.AddDays(-1);
			}
			if (dataConsegnaManualeTestata.HasValue)
			{
				dataConsegna = dataConsegnaManualeTestata.Value;
				now = dataConsegnaManualeTestata.Value;
				dataUltimaConsegna = now.AddMonths(1);
				now = dataConsegnaManualeTestata.Value;
				DateTime todayManuale = now.Date;
				now = new DateTime(todayManuale.Year, todayManuale.Month, 1);
				now = now.AddMonths(1);
				dataDecorrenza = now.AddDays(-1);
			}
			CondizioneCommerciale condizioneCommerciale = this.CondizioneCommercialeRepository.Get(cliente, dataConsegna, marchio);
			if (condizioneCommerciale != null)
			{
				codiceListino = condizioneCommerciale.CodiceListino;
				metodoPagamento = condizioneCommerciale.MetodoPagamento;
				codicePoliticaSconti = condizioneCommerciale.CodicePoliticaSconti;
				if ((string.IsNullOrEmpty(codiceListino) ? true : metodoPagamento == null))
				{
					throw new Exception(Resources.ErroreCondizioneCommerciale);
				}
			}
			int tipoOrdineSpeciale = this.ImpostazioniGenerali.OrdineSpecialeTipo;
			if (tipoOrdine.Id == tipoOrdineSpeciale)
			{
				metodoPagamento = this.MetodoPagamentoRepository.GetById(this.ImpostazioniGenerali.OrdineSpecialeMetedoPagamento);
				codiceListino = this.ImpostazioniGenerali.OrdineSpecialeListino;
			}
			if (string.IsNullOrEmpty(codiceListino))
			{
				throw new Exception(Resources.ErroreListinoOrdine);
			}
			bool isNuovoOrdine = false;
			if (ordine == null)
			{
				isNuovoOrdine = true;
				ordine = new Ordine()
				{
					Codice = this.OrdineRepository.GetNuovoCodiceOrdine(WebConfigSettings.IsOnline, this.AgenteAutenticato),
					Agente = this.AgenteAutenticato,
					CodiceAgente = this.AgenteAutenticato.CodiceAgente,
					NumeroOrdine = this.OrdineRepository.GetNuovoNumeroOrdine(this.AgenteAutenticato),
					DataInserimento = DateTime.Now,
					Cliente = cliente,
					Online = WebConfigSettings.IsOnline
				};
			}
			StatoOrdine statoOrdineTemporaneo = this.StatoOrdineRepository.GetById(WebConfigSettings.CodiceStatoOrdineTemporaneo);
			ordine.Data = data;
			ordine.IdIndirizzoConsegna = idIndirizzo;
			ordine.Marchio = marchio;
			ordine.Tipo = tipoOrdine;
			ordine.Banca = banca;
			ordine.Valuta = valuta;
			ordine.MetodoPagamento = metodoPagamento;
			ordine.ScontoMetodoPagamento = metodoPagamento.Sconto;
			ordine.CodiceListino = codiceListino;
			ordine.Porto = porto;
			ordine.Trasporto = trasporto;
			ordine.Vettore = vettore;
			ordine.Note = note;
			ordine.Allegato = nomeFileAllegato;
			ordine.Stato = statoOrdineTemporaneo;
			ordine.DataConsegna = dataConsegna;
			ordine.DataConsegnaManuale = dataConsegnaManualeTestata;
			ordine.DataDecorrenza = dataDecorrenza;
			ordine.DataUltimaConsegna = dataUltimaConsegna;
			ordine.CodicePoliticaSconti = codicePoliticaSconti;
			ordine.RiferimentoOrdine = rifordine;
			if (!isNuovoOrdine)
			{
				this.OrdineRepository.Save(ordine);
			}
			else
			{
				this.OrdineRepository.SaveNuovoOrdine(ordine);
			}
			return ordine;
		}

		protected override void InitializeCulture()
		{
			base.InitializeCulture();
			object item = this.Session["CurrentLanguage"];
			if (item == null)
			{
				item = string.Empty;
			}
			string language = this.NormalizeLanguage((string)item);
			System.Web.UI.Page page = this.Page;
			string str = language;
			string str1 = str;
			this.Page.UICulture = str;
			page.Culture = str1;
		}

		public bool IsAgenteAutenticatoAmministratore()
		{
			bool flag;
			flag = (this.AgenteAutenticato != null ? this.AgenteAutenticato.IsAmministratore(WebConfigSettings.CodiciTipoAgenteAmministratore) : false);
			return flag;
		}

		public bool IsAgenteAutenticatoCliente()
		{
			bool flag;
			flag = (this.AgenteAutenticato != null ? this.AgenteAutenticato.IsCliente(WebConfigSettings.CodiceTipoAgenteCliente) : false);
			return flag;
		}

		private string NormalizeLanguage(string language)
		{
			string str;
			string italianLanguage = "it-IT";
			if (!string.IsNullOrEmpty(language))
			{
				str = (language.Equals(WebConfigSettings.CodiceLinguaItaliano, StringComparison.OrdinalIgnoreCase) ? italianLanguage : "en-US");
			}
			else
			{
				str = italianLanguage;
			}
			return str;
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			this.ImpostazioniGenerali = new ImpostazioniApplicazioneContainer(this.ImpostazioneApplicazioneRepository);
			this.SetMessages();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			this.SetDataUltimaOperazione(DateTime.Now);
		}

		protected override void OnPreInit(EventArgs e)
		{
			base.OnPreInit(e);
		}

		protected void RemoveAgenteAutenticato()
		{
			this.Session.Remove(WebConfigSettings.CodiceAgenteAutenticatoSessionKey);
		}

		protected void SetAgenteAutenticato(Agente agente)
		{
			if (agente == null)
			{
				throw new ArgumentNullException("agente");
			}
			this.AgenteAutenticato = agente;
		}

		protected void SetDataUltimaOperazione(DateTime dataUltimaOperazione)
		{
			if (this.AgenteAutenticato != null)
			{
				this.AgenteAutenticato.DataUltimaOperazione = new DateTime?(dataUltimaOperazione);
				this.AgenteRepository.Save(this.AgenteAutenticato);
			}
		}

		protected void SetDataUltimoAccesso(DateTime dataUltimoAccesso)
		{
			if (this.AgenteAutenticato != null)
			{
				this.AgenteAutenticato.DataUltimoAccesso = new DateTime?(dataUltimoAccesso);
				this.AgenteRepository.Save(this.AgenteAutenticato);
			}
		}

		private void SetMessages()
		{
			if (this.Session[WebConfigSettings.InfoMessageSessionKey] != null)
			{
				this.infoMessage = this.Session[WebConfigSettings.InfoMessageSessionKey].ToString();
				this.Session.Remove(WebConfigSettings.InfoMessageSessionKey);
			}
			if (this.Session[WebConfigSettings.SuccessMessageSessionKey] != null)
			{
				this.successMessage = this.Session[WebConfigSettings.SuccessMessageSessionKey].ToString();
				this.Session.Remove(WebConfigSettings.SuccessMessageSessionKey);
			}
			if (this.Session[WebConfigSettings.ErrorMessageSessionKey] != null)
			{
				this.errorMessage = this.Session[WebConfigSettings.ErrorMessageSessionKey].ToString();
				this.Session.Remove(WebConfigSettings.ErrorMessageSessionKey);
			}
		}

		protected void SetStatoOnlineAgenteAutenticato(bool online)
		{
			if (this.AgenteAutenticato != null)
			{
				this.AgenteAutenticato.Online = online;
				this.AgenteRepository.Save(this.AgenteAutenticato);
			}
		}
	}
}