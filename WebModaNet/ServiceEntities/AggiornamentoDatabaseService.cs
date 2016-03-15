using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class AggiornamentoDatabaseService
	{
		public List<AgenteService> Agenti
		{
			get;
			set;
		}

		public List<AgenteListinoService> AgentiListini
		{
			get;
			set;
		}

		public List<AgenteMetodoPagamentoService> AgentiMetodiPagamento
		{
			get;
			set;
		}

		public List<AgenteValutaService> AgentiValute
		{
			get;
			set;
		}

		public List<ArticoloService> Articoli
		{
			get;
			set;
		}

		public List<ArticoloCategoriaService> ArticoliCategorie
		{
			get;
			set;
		}

		public List<ArticoloImballoService> ArticoliImballi
		{
			get;
			set;
		}

		public List<CategoriaService> Categorie
		{
			get;
			set;
		}

		public List<ClienteService> Clienti
		{
			get;
			set;
		}

		public List<CodiceABarreService> CodiciABarre
		{
			get;
			set;
		}

		public List<CondizioneCommercialeService> CondizioniCommerciali
		{
			get;
			set;
		}

		public List<DataConsegnaService> DateConsegna
		{
			get;
			set;
		}

		public List<DettaglioPoliticaScontiService> DettagliPoliticaSconti
		{
			get;
			set;
		}

		public List<FamigliaService> Famiglie
		{
			get;
			set;
		}

		public List<ImballoService> Imballi
		{
			get;
			set;
		}

		public List<ImpostazioneApplicazioneService> ImpostazioniApplicazione
		{
			get;
			set;
		}

		public List<ImpostazioneOrdineService> ImpostazioniOrdine
		{
			get;
			set;
		}

		public List<ImpostazioneStagioneService> ImpostazioniStagione
		{
			get;
			set;
		}

		public List<IndirizzoService> Indirizzi
		{
			get;
			set;
		}

		public List<LineaService> Linee
		{
			get;
			set;
		}

		public List<LinguaService> Lingue
		{
			get;
			set;
		}

		public List<ListinoService> Listini
		{
			get;
			set;
		}

		public List<ListinoClienteService> ListiniCliente
		{
			get;
			set;
		}

		public List<MarchioService> Marchi
		{
			get;
			set;
		}

		public List<MetodoPagamentoService> MetodiPagamento
		{
			get;
			set;
		}

		public List<NazioneService> Nazioni
		{
			get;
			set;
		}

		public List<PoliticaScontiService> PoliticheSconti
		{
			get;
			set;
		}

		public List<PortoService> Porti
		{
			get;
			set;
		}

		public List<PromozioneService> Promozioni
		{
			get;
			set;
		}

		public List<ProvinciaService> Province
		{
			get;
			set;
		}

		public List<SegnataglieService> Segnataglie
		{
			get;
			set;
		}

		public List<StagioneService> Stagioni
		{
			get;
			set;
		}

		public List<StatoClienteService> StatiCliente
		{
			get;
			set;
		}

		public List<StatoOrdineService> StatiOrdine
		{
			get;
			set;
		}

		public List<TipoAgenteService> TipiAgente
		{
			get;
			set;
		}

		public List<TipoCategoriaService> TipiCategoria
		{
			get;
			set;
		}

		public List<TipoOrdineService> TipiOrdine
		{
			get;
			set;
		}

		public List<TrasportoService> Trasporti
		{
			get;
			set;
		}

		public List<ValutaService> Valute
		{
			get;
			set;
		}

		public List<VarianteService> Varianti
		{
			get;
			set;
		}

		public List<VettoreService> Vettori
		{
			get;
			set;
		}

		public List<VisibilitaClienteService> VisibilitaClienti
		{
			get;
			set;
		}

		public AggiornamentoDatabaseService()
		{
		}
	}
}