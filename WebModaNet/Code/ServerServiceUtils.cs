using EW.WebModaNet.ServiceEntities;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.Code
{
	public class ServerServiceUtils
	{
		public ServerServiceUtils()
		{
		}

		public static AgenteService ConvertAgenteToAgenteService(Agente agente)
		{
			string codice;
			string str;
			string codice1;
			string str1;
			string codice2;
			AgenteService agenteService = new AgenteService()
			{
				CodiceUtente = agente.CodiceUtente,
				CodiceAgente = agente.CodiceAgente,
				RagioneSociale = agente.RagioneSociale,
				Password = agente.Password
			};
			AgenteService agenteService1 = agenteService;
			if (agente.Tipo == null)
			{
				codice = null;
			}
			else
			{
				codice = agente.Tipo.Codice;
			}
			agenteService1.CodiceTipoAgente = codice;
			agenteService.Attivo = agente.Attivo;
			agenteService.Online = agente.Online;
			agenteService.DataUltimoAccesso = agente.DataUltimoAccesso;
			agenteService.DataUltimaOperazione = agente.DataUltimaOperazione;
			AgenteService agenteService2 = agenteService;
			if (agente.Nazione == null)
			{
				str = null;
			}
			else
			{
				str = agente.Nazione.Codice;
			}
			agenteService2.CodiceNazione = str;
			AgenteService agenteService3 = agenteService;
			if (agente.Lingua == null)
			{
				codice1 = null;
			}
			else
			{
				codice1 = agente.Lingua.Codice;
			}
			agenteService3.CodiceLingua = codice1;
			agenteService.CodiceListinoPredefinito = agente.CodiceListinoPredefinito;
			AgenteService agenteService4 = agenteService;
			if (agente.MetodoPagamentoPredefinito == null)
			{
				str1 = null;
			}
			else
			{
				str1 = agente.MetodoPagamentoPredefinito.Codice;
			}
			agenteService4.CodiceMetodoPagamentoPredefinito = str1;
			AgenteService agenteService5 = agenteService;
			if (agente.ValutaPredefinita == null)
			{
				codice2 = null;
			}
			else
			{
				codice2 = agente.ValutaPredefinita.Codice;
			}
			agenteService5.CodiceValutaPredefinita = codice2;
			agenteService.NumeroDecimali = agente.NumeroDecimali;
			agenteService.CodicePoliticaSconti = agente.CodicePoliticaSconti;
			agenteService.UtilizzaOffline = agente.UtilizzaOffline;
			agenteService.BloccoMetodoPagamento = agente.BloccoMetodoPagamento;
			agenteService.BloccoBanca = agente.BloccoBanca;
			agenteService.BloccoValuta = agente.BloccoValuta;
			agenteService.BloccoPorto = agente.BloccoPorto;
			agenteService.BloccoTrasporto = agente.BloccoTrasporto;
			agenteService.BloccoVettore = agente.BloccoVettore;
			agenteService.BloccoDataOrdine = agente.BloccoDataOrdine;
			agenteService.BloccoDateConsegna = agente.BloccoDateConsegna;
			return agenteService;
		}

		public static AggiornamentoDatabaseService ConvertAggiornamentoDatabaseToAggiornamentoDatabaseService(AggiornamentoDatabase aggiornamentoDatabase)
		{
			AggiornamentoDatabaseService aggiornamentoDatabaseService = new AggiornamentoDatabaseService()
			{
				Agenti = (
					from o in aggiornamentoDatabase.Agenti
					select ServerServiceUtils.ConvertAgenteToAgenteService(o)).ToList<AgenteService>(),
				AgentiListini = (
					from a in aggiornamentoDatabase.Agenti
					from l in a.CodiciListino
					select new AgenteListinoService()
					{
						CodiceUtente = a.CodiceUtente,
						CodiceListino = l
					}).Distinct<AgenteListinoService>().ToList<AgenteListinoService>(),
				AgentiMetodiPagamento = (
					from a in aggiornamentoDatabase.Agenti
					from m in a.MetodiPagamento
					select new AgenteMetodoPagamentoService()
					{
						CodiceUtente = a.CodiceUtente,
						CodiceMetodoPagamento = m.Codice
					}).Distinct<AgenteMetodoPagamentoService>().ToList<AgenteMetodoPagamentoService>(),
				AgentiValute = (
					from a in aggiornamentoDatabase.Agenti
					from v in a.Valute
					select new AgenteValutaService()
					{
						CodiceUtente = a.CodiceUtente,
						CodiceValuta = v.Codice
					}).Distinct<AgenteValutaService>().ToList<AgenteValutaService>(),
				Articoli = (
					from o in aggiornamentoDatabase.Articoli
					select ServerServiceUtils.ConvertEntity<Articolo, ArticoloService>(o, new string[] { "CodiceStagione", "CodiceLinea", "CodiceFamiglia", "CodiceMarchio", "CodiceSegnataglie" }, new Func<Articolo, object>[] { new Func<Articolo, object>((Articolo x) => (x.Stagione == null ? null : x.Stagione.Codice)), new Func<Articolo, object>((Articolo x) => (x.Linea == null ? null : x.Linea.Codice)), new Func<Articolo, object>((Articolo x) => (x.Famiglia == null ? null : x.Famiglia.Codice)), new Func<Articolo, object>((Articolo x) => (x.Marchio == null ? null : x.Marchio.Codice)), new Func<Articolo, object>((Articolo x) => (x.Segnataglie == null ? null : x.Segnataglie.Codice)) })).ToList<ArticoloService>(),
				ArticoliCategorie = (
					from a in aggiornamentoDatabase.Articoli
					from c in a.Categorie
					select new ArticoloCategoriaService()
					{
						CodiceArticolo = a.Codice,
						CodiceCategoria = c.Codice,
						IDTipoCategoria = c.Tipo.Id
					}).Distinct<ArticoloCategoriaService>().ToList<ArticoloCategoriaService>(),
				ArticoliImballi = (
					from a in aggiornamentoDatabase.Varianti
					from i in a.Imballi
					select new ArticoloImballoService()
					{
						CodiceVariante = a.Codice,
						CodiceArticolo = a.Articolo.Codice,
						CodiceImballo = i.Codice,
						Predefinito = false
					}).Distinct<ArticoloImballoService>().ToList<ArticoloImballoService>(),
				Categorie = (
					from o in aggiornamentoDatabase.Categorie
					select ServerServiceUtils.ConvertEntity<Categoria, CategoriaService>(o, new string[] { "IdTIpoCategoria" }, new Func<Categoria, object>[] { new Func<Categoria, object>((Categoria x) => x.Tipo.Id) })).ToList<CategoriaService>(),
				Clienti = (
					from o in aggiornamentoDatabase.Clienti
					select ServerServiceUtils.ConvertClienteToClienteService(o)).ToList<ClienteService>(),
				CodiciABarre = (
					from o in aggiornamentoDatabase.CodiciABarre
					select ServerServiceUtils.ConvertEntity<CodiceABarre, CodiceABarreService>(o, new string[] { "CodiceVariante", "CodiceArticolo" }, new Func<CodiceABarre, object>[] { new Func<CodiceABarre, object>((CodiceABarre x) => (x.Variante == null ? null : x.Variante.Codice)), new Func<CodiceABarre, object>((CodiceABarre x) => (x.Variante == null ? null : x.Variante.Articolo.Codice)) })).ToList<CodiceABarreService>(),
				CondizioniCommerciali = (
					from o in aggiornamentoDatabase.CondizioniCommerciali
					select ServerServiceUtils.ConvertEntity<CondizioneCommerciale, CondizioneCommercialeService>(o, new string[] { "CodiceCliente", "CodiceMarchio", "CodiceMetodoPagamento" }, new Func<CondizioneCommerciale, object>[] { new Func<CondizioneCommerciale, object>((CondizioneCommerciale x) => (x.Cliente == null ? null : x.Cliente.Codice)), new Func<CondizioneCommerciale, object>((CondizioneCommerciale x) => (x.Marchio == null ? null : x.Marchio.Codice)), new Func<CondizioneCommerciale, object>((CondizioneCommerciale x) => (x.MetodoPagamento == null ? null : x.MetodoPagamento.Codice)), new Func<CondizioneCommerciale, object>((CondizioneCommerciale x) => (x.MetodoPagamento == null ? null : x.MetodoPagamento.Codice)) })).ToList<CondizioneCommercialeService>(),
				DateConsegna = (
					from o in aggiornamentoDatabase.DateConsegna
					select ServerServiceUtils.ConvertEntity<DataConsegnaOrdine, DataConsegnaService>(o, new string[] { "CodiceMarchio", "CodiceTipoOrdine", "CodiceStagione", "CodiceLinea" }, new Func<DataConsegnaOrdine, object>[] { new Func<DataConsegnaOrdine, object>((DataConsegnaOrdine x) => (x.Marchio == null ? null : x.Marchio.Codice)), new Func<DataConsegnaOrdine, object>((DataConsegnaOrdine x) => (x.TipoOrdine == null ? null : new int?(x.TipoOrdine.Id))), new Func<DataConsegnaOrdine, object>((DataConsegnaOrdine x) => (x.Stagione == null ? null : x.Stagione.Codice)), new Func<DataConsegnaOrdine, object>((DataConsegnaOrdine x) => (x.Linea == null ? null : x.Linea.Codice)) })).ToList<DataConsegnaService>(),
				DettagliPoliticaSconti = (
					from o in aggiornamentoDatabase.DettagliPoliticaSconti
					select ServerServiceUtils.ConvertEntity<DettaglioPoliticaSconti, DettaglioPoliticaScontiService>(o)).ToList<DettaglioPoliticaScontiService>(),
				Famiglie = (
					from o in aggiornamentoDatabase.Famiglie
					select ServerServiceUtils.ConvertEntity<Famiglia, FamigliaService>(o)).ToList<FamigliaService>(),
				Imballi = (
					from o in aggiornamentoDatabase.Imballi
					select ServerServiceUtils.ConvertEntity<Imballo, ImballoService>(o, new string[] { "CodiceSegnataglie" }, new Func<Imballo, object>[] { new Func<Imballo, object>((Imballo x) => (x.Segnataglie == null ? null : x.Segnataglie.Codice)) })).ToList<ImballoService>(),
				ImpostazioniApplicazione = (
					from o in aggiornamentoDatabase.ImpostazioniApplicazione
					select ServerServiceUtils.ConvertEntity<ImpostazioneApplicazione, ImpostazioneApplicazioneService>(o)).ToList<ImpostazioneApplicazioneService>(),
				ImpostazioniOrdine = (
					from a in aggiornamentoDatabase.Agenti
					from i in a.ImpostazioniOrdine
					select new ImpostazioneOrdineService()
					{
						Id = i.Id,
						CodiceUtente = (i.Agente == null ? null : i.Agente.CodiceUtente),
						IdTipoOrdine = (i.TipoOrdine == null ? null : new int?(i.TipoOrdine.Id)),
						CodiceMarchio = (i.Marchio == null ? null : i.Marchio.Codice),
						ValoreMinimoOrdine = i.ValoreMinimoOrdine,
						CodiceListinoConsigliato = i.CodiceListinoConsigliato
					}).Distinct<ImpostazioneOrdineService>().ToList<ImpostazioneOrdineService>(),
				ImpostazioniStagione = (
					from a in aggiornamentoDatabase.Agenti
					from i in a.ImpostazioniStagione
					select new ImpostazioneStagioneService()
					{
						Id = i.Id,
						CodiceUtente = (i.Agente == null ? null : i.Agente.CodiceUtente),
						CodiceStagione = (i.Stagione == null ? null : i.Stagione.Codice),
						Disponibilita = i.Disponibilita
					}).Distinct<ImpostazioneStagioneService>().ToList<ImpostazioneStagioneService>(),
				Indirizzi = (
					from c in aggiornamentoDatabase.Clienti
					from i in c.Indirizzi
					select new IndirizzoService()
					{
						Id = i.Id,
						CodiceCliente = (i.Cliente == null ? null : i.Cliente.Codice),
						RagioneSociale1 = i.RagioneSociale1,
						RagioneSociale2 = i.RagioneSociale2,
						Via1 = i.Via1,
						Via2 = i.Via2,
						Cap = i.Cap,
						Citta1 = i.Citta1,
						Citta2 = i.Citta2,
						CodiceProvincia = (i.Provincia == null ? null : i.Provincia.Codice),
						CodiceNazione = (i.Nazione == null ? null : i.Nazione.Codice),
						Predefinito = i.Predefinito
					}).Distinct<IndirizzoService>().ToList<IndirizzoService>(),
				Linee = (
					from o in aggiornamentoDatabase.Linee
					select ServerServiceUtils.ConvertEntity<Linea, LineaService>(o)).ToList<LineaService>(),
				Lingue = (
					from o in aggiornamentoDatabase.Lingue
					select ServerServiceUtils.ConvertEntity<Lingua, LinguaService>(o)).ToList<LinguaService>(),
				Listini = (
					from o in aggiornamentoDatabase.Listini
					select ServerServiceUtils.ConvertEntity<Listino, ListinoService>(o, new string[] { "CodiceArticolo" }, new Func<Listino, object>[] { new Func<Listino, object>((Listino x) => (x.Articolo == null ? null : x.Articolo.Codice)) })).ToList<ListinoService>(),
				ListiniCliente = (
					from o in aggiornamentoDatabase.ListiniCliente
					select ServerServiceUtils.ConvertEntity<ListinoCliente, ListinoClienteService>(o, new string[] { "CodiceCliente", "CodiceArticolo" }, new Func<ListinoCliente, object>[] { new Func<ListinoCliente, object>((ListinoCliente x) => (x.Cliente == null ? null : x.Cliente.Codice)), new Func<ListinoCliente, object>((ListinoCliente x) => (x.Articolo == null ? null : x.Articolo.Codice)) })).ToList<ListinoClienteService>(),
				Marchi = (
					from o in aggiornamentoDatabase.Marchi
					select ServerServiceUtils.ConvertEntity<Marchio, MarchioService>(o)).ToList<MarchioService>(),
				MetodiPagamento = (
					from o in aggiornamentoDatabase.MetodiPagamento
					select ServerServiceUtils.ConvertEntity<MetodoPagamento, MetodoPagamentoService>(o)).ToList<MetodoPagamentoService>(),
				Nazioni = (
					from o in aggiornamentoDatabase.Nazioni
					select ServerServiceUtils.ConvertEntity<Nazione, NazioneService>(o)).ToList<NazioneService>(),
				PoliticheSconti = (
					from o in aggiornamentoDatabase.PoliticheSconti
					select ServerServiceUtils.ConvertEntity<PoliticaSconti, PoliticaScontiService>(o)).ToList<PoliticaScontiService>(),
				Promozioni = (
					from o in aggiornamentoDatabase.Promozioni
					select ServerServiceUtils.ConvertEntity<Promozione, PromozioneService>(o)).ToList<PromozioneService>(),
				Porti = (
					from o in aggiornamentoDatabase.Porti
					select ServerServiceUtils.ConvertEntity<Porto, PortoService>(o)).ToList<PortoService>(),
				Province = (
					from o in aggiornamentoDatabase.Province
					select ServerServiceUtils.ConvertEntity<Provincia, ProvinciaService>(o, new string[] { "CodiceNazione" }, new Func<Provincia, object>[] { new Func<Provincia, object>((Provincia x) => (x.Nazione == null ? null : x.Nazione.Codice)) })).ToList<ProvinciaService>(),
				Segnataglie = (
					from o in aggiornamentoDatabase.Segnataglie
					select ServerServiceUtils.ConvertEntity<Segnataglie, SegnataglieService>(o)).ToList<SegnataglieService>(),
				Stagioni = (
					from o in aggiornamentoDatabase.Stagioni
					select ServerServiceUtils.ConvertEntity<Stagione, StagioneService>(o)).ToList<StagioneService>(),
				StatiCliente = (
					from o in aggiornamentoDatabase.StatiCliente
					select ServerServiceUtils.ConvertEntity<StatoCliente, StatoClienteService>(o)).ToList<StatoClienteService>(),
				StatiOrdine = (
					from o in aggiornamentoDatabase.StatiOrdine
					select ServerServiceUtils.ConvertEntity<StatoOrdine, StatoOrdineService>(o)).ToList<StatoOrdineService>(),
				TipiAgente = (
					from o in aggiornamentoDatabase.TipiAgente
					select ServerServiceUtils.ConvertEntity<TipoAgente, TipoAgenteService>(o)).ToList<TipoAgenteService>(),
				TipiCategoria = (
					from o in aggiornamentoDatabase.TipiCategoria
					select ServerServiceUtils.ConvertEntity<TipoCategoria, TipoCategoriaService>(o)).ToList<TipoCategoriaService>(),
				TipiOrdine = (
					from o in aggiornamentoDatabase.TipiOrdine
					select ServerServiceUtils.ConvertEntity<TipoOrdine, TipoOrdineService>(o)).ToList<TipoOrdineService>(),
				Trasporti = (
					from o in aggiornamentoDatabase.Trasporti
					select ServerServiceUtils.ConvertEntity<Trasporto, TrasportoService>(o)).ToList<TrasportoService>(),
				Valute = (
					from o in aggiornamentoDatabase.Valute
					select ServerServiceUtils.ConvertEntity<Valuta, ValutaService>(o)).ToList<ValutaService>(),
				Varianti = (
					from o in aggiornamentoDatabase.Varianti
					select ServerServiceUtils.ConvertEntity<Variante, VarianteService>(o, new string[] { "CodiceArticolo" }, new Func<Variante, object>[] { new Func<Variante, object>((Variante x) => (x.Articolo == null ? null : x.Articolo.Codice)) })).ToList<VarianteService>(),
				Vettori = (
					from o in aggiornamentoDatabase.Vettori
					select ServerServiceUtils.ConvertEntity<Vettore, VettoreService>(o)).ToList<VettoreService>(),
				VisibilitaClienti = (
					from o in aggiornamentoDatabase.VisibilitaClienti
					select ServerServiceUtils.ConvertEntity<VisibilitaCliente, VisibilitaClienteService>(o, new string[] { "CodiceCliente" }, new Func<VisibilitaCliente, object>[] { new Func<VisibilitaCliente, object>((VisibilitaCliente x) => (x.Cliente == null ? null : x.Cliente.Codice)) })).ToList<VisibilitaClienteService>()
			};
			return aggiornamentoDatabaseService;
		}

		public static Cliente ConvertClienteServiceToCliente(ClienteService clienteRequest)
		{
			int? idPortoPredefinito;
			Agente byId;
			StatoCliente statoCliente;
			MetodoPagamento metodoPagamento;
			Valuta valutum;
			Porto porto;
			Trasporto trasporto;
			Vettore vettore;
			Provincia provincium;
			Nazione nazione;
			Cliente cliente = new Cliente()
			{
				Codice = clienteRequest.Codice
			};
			Cliente cliente1 = cliente;
			if (clienteRequest.CodiceUtente == null)
			{
				byId = null;
			}
			else
			{
				byId = ServiceLocator.Current.GetInstance<IAgenteRepository>().GetById(clienteRequest.CodiceUtente);
			}
			cliente1.Agente = byId;
			cliente.CodiceAgente = clienteRequest.CodiceAgente;
			cliente.RagioneSociale1 = clienteRequest.RagioneSociale1;
			cliente.RagioneSociale2 = clienteRequest.RagioneSociale2;
			cliente.PartitaIva = clienteRequest.PartitaIva;
			cliente.CodiceFiscale = clienteRequest.CodiceFiscale;
			cliente.Attivo = clienteRequest.Attivo;
			Cliente cliente2 = cliente;
			if (clienteRequest.CodiceStatoCliente == null)
			{
				statoCliente = null;
			}
			else
			{
				statoCliente = ServiceLocator.Current.GetInstance<IRepository<StatoCliente, string>>().GetById(clienteRequest.CodiceStatoCliente);
			}
			cliente2.Stato = statoCliente;
			cliente.Rating = clienteRequest.Rating;
			cliente.Insoluto = clienteRequest.Insoluto;
			cliente.Telefono = clienteRequest.Telefono;
			cliente.Cellulare = clienteRequest.Cellulare;
			cliente.Fax = clienteRequest.Fax;
			cliente.Email = clienteRequest.Email;
			cliente.Referente = clienteRequest.Referente;
			cliente.Banca = clienteRequest.Banca;
			cliente.Abi = clienteRequest.Abi;
			cliente.Cab = clienteRequest.Cab;
			cliente.Iban = clienteRequest.Iban;
			Cliente cliente3 = cliente;
			if (clienteRequest.CodiceMetodoPagamentoPredefinito == null)
			{
				metodoPagamento = null;
			}
			else
			{
				metodoPagamento = ServiceLocator.Current.GetInstance<IRepository<MetodoPagamento, string>>().GetById(clienteRequest.CodiceMetodoPagamentoPredefinito);
			}
			cliente3.MetodoPagamentoPredefinito = metodoPagamento;
			Cliente cliente4 = cliente;
			if (clienteRequest.CodiceValutaPredefinita == null)
			{
				valutum = null;
			}
			else
			{
				valutum = ServiceLocator.Current.GetInstance<IRepository<Valuta, string>>().GetById(clienteRequest.CodiceValutaPredefinita);
			}
			cliente4.ValutaPredefinita = valutum;
			Cliente cliente5 = cliente;
			if (!clienteRequest.IdPortoPredefinito.HasValue)
			{
				porto = null;
			}
			else
			{
				IRepository<Porto, int> instance = ServiceLocator.Current.GetInstance<IRepository<Porto, int>>();
				idPortoPredefinito = clienteRequest.IdPortoPredefinito;
				porto = instance.GetById(idPortoPredefinito.Value);
			}
			cliente5.PortoPredefinito = porto;
			Cliente cliente6 = cliente;
			if (!clienteRequest.IdTrasportoPredefinito.HasValue)
			{
				trasporto = null;
			}
			else
			{
				IRepository<Trasporto, int> repository = ServiceLocator.Current.GetInstance<IRepository<Trasporto, int>>();
				idPortoPredefinito = clienteRequest.IdTrasportoPredefinito;
				trasporto = repository.GetById(idPortoPredefinito.Value);
			}
			cliente6.TrasportoPredefinito = trasporto;
			Cliente cliente7 = cliente;
			if (!clienteRequest.IdVettorePredefinito.HasValue)
			{
				vettore = null;
			}
			else
			{
				IRepository<Vettore, int> instance1 = ServiceLocator.Current.GetInstance<IRepository<Vettore, int>>();
				idPortoPredefinito = clienteRequest.IdVettorePredefinito;
				vettore = instance1.GetById(idPortoPredefinito.Value);
			}
			cliente7.VettorePredefinito = vettore;
			cliente.CodiceListinoPredefinito = clienteRequest.CodiceListinoPredefinito;
			cliente.CodicePoliticaSconti = clienteRequest.CodicePoliticaSconti;
			cliente.CodiceTipologiaCommerciale = clienteRequest.CodiceTipologiaCommerciale;
			cliente.CodiceCategoria = clienteRequest.CodiceCategoria;
			cliente.CodiceZona = clienteRequest.CodiceZona;
			cliente.ViaSedeLegale1 = clienteRequest.ViaSedeLegale1;
			cliente.ViaSedeLegale2 = clienteRequest.ViaSedeLegale2;
			cliente.CapSedeLegale = clienteRequest.CapSedeLegale;
			cliente.CittaSedeLegale1 = clienteRequest.CittaSedeLegale1;
			cliente.CittaSedeLegale2 = clienteRequest.CittaSedeLegale2;
			Cliente cliente8 = cliente;
			if (clienteRequest.CodiceProvinciaSedeLegale == null)
			{
				provincium = null;
			}
			else
			{
				provincium = ServiceLocator.Current.GetInstance<IRepository<Provincia, string>>().GetById(clienteRequest.CodiceProvinciaSedeLegale);
			}
			cliente8.ProvinciaSedeLegale = provincium;
			Cliente cliente9 = cliente;
			if (clienteRequest.NazioneSedeLegale == null)
			{
				nazione = null;
			}
			else
			{
				nazione = ServiceLocator.Current.GetInstance<IRepository<Nazione, string>>().GetById(clienteRequest.NazioneSedeLegale);
			}
			cliente9.NazioneSedeLegale = nazione;
			cliente.CodiceSituazione = clienteRequest.CodiceSituazione;
			cliente.IdCommerciale = clienteRequest.IdCommerciale;
			cliente.DescrizioneCommerciale = clienteRequest.DescrizioneCommerciale;
			cliente.EmailCommerciale = clienteRequest.EmailCommerciale;
			cliente.TelCommerciale = clienteRequest.TelCommerciale;
			cliente.TelCommerciale2 = clienteRequest.TelCommerciale2;
			List<Indirizzo> indirizzi = new List<Indirizzo>();
			IndirizzoService[] indirizzoServiceArray = clienteRequest.Indirizzi;
			for (int i = 0; i < (int)indirizzoServiceArray.Length; i++)
			{
				indirizzi.Add(ServerServiceUtils.ConvertIndirizzoServiceToIndirizzo(indirizzoServiceArray[i], cliente));
			}
			cliente.Indirizzi = indirizzi;
			return cliente;
		}

		public static ClienteService ConvertClienteToClienteService(Cliente source)
		{
			int? nullable;
			string codiceUtente;
			string codice;
			string str;
			string codice1;
			int? nullable1;
			int? nullable2;
			int? nullable3;
			string str1;
			string codice2;
			ClienteService destination = new ClienteService()
			{
				Codice = source.Codice
			};
			ClienteService clienteService = destination;
			if (source.Agente == null)
			{
				codiceUtente = null;
			}
			else
			{
				codiceUtente = source.Agente.CodiceUtente;
			}
			clienteService.CodiceUtente = codiceUtente;
			destination.CodiceAgente = source.CodiceAgente;
			destination.RagioneSociale1 = source.RagioneSociale1;
			destination.RagioneSociale2 = source.RagioneSociale2;
			destination.PartitaIva = source.PartitaIva;
			destination.CodiceFiscale = source.CodiceFiscale;
			destination.Attivo = source.Attivo;
			ClienteService clienteService1 = destination;
			if (source.Stato == null)
			{
				codice = null;
			}
			else
			{
				codice = source.Stato.Codice;
			}
			clienteService1.CodiceStatoCliente = codice;
			destination.Rating = source.Rating;
			destination.Insoluto = source.Insoluto;
			destination.Telefono = source.Telefono;
			destination.Cellulare = source.Cellulare;
			destination.Fax = source.Fax;
			destination.Email = source.Email;
			destination.Referente = source.Referente;
			destination.Banca = source.Banca;
			destination.Abi = source.Abi;
			destination.Cab = source.Cab;
			destination.Iban = source.Iban;
			ClienteService clienteService2 = destination;
			if (source.MetodoPagamentoPredefinito == null)
			{
				str = null;
			}
			else
			{
				str = source.MetodoPagamentoPredefinito.Codice;
			}
			clienteService2.CodiceMetodoPagamentoPredefinito = str;
			ClienteService clienteService3 = destination;
			if (source.ValutaPredefinita == null)
			{
				codice1 = null;
			}
			else
			{
				codice1 = source.ValutaPredefinita.Codice;
			}
			clienteService3.CodiceValutaPredefinita = codice1;
			ClienteService clienteService4 = destination;
			if (source.PortoPredefinito == null)
			{
				nullable = null;
				nullable1 = nullable;
			}
			else
			{
				nullable1 = new int?(source.PortoPredefinito.Id);
			}
			clienteService4.IdPortoPredefinito = nullable1;
			ClienteService clienteService5 = destination;
			if (source.TrasportoPredefinito == null)
			{
				nullable = null;
				nullable2 = nullable;
			}
			else
			{
				nullable2 = new int?(source.TrasportoPredefinito.Id);
			}
			clienteService5.IdTrasportoPredefinito = nullable2;
			ClienteService clienteService6 = destination;
			if (source.VettorePredefinito == null)
			{
				nullable = null;
				nullable3 = nullable;
			}
			else
			{
				nullable3 = new int?(source.VettorePredefinito.Id);
			}
			clienteService6.IdVettorePredefinito = nullable3;
			destination.CodiceListinoPredefinito = source.CodiceListinoPredefinito;
			destination.CodicePoliticaSconti = source.CodicePoliticaSconti;
			destination.CodiceTipologiaCommerciale = source.CodiceTipologiaCommerciale;
			destination.CodiceCategoria = source.CodiceCategoria;
			destination.CodiceZona = source.CodiceZona;
			destination.ViaSedeLegale1 = source.ViaSedeLegale1;
			destination.ViaSedeLegale2 = source.ViaSedeLegale2;
			destination.CapSedeLegale = source.CapSedeLegale;
			destination.CittaSedeLegale1 = source.CittaSedeLegale1;
			ClienteService clienteService7 = destination;
			if (source.ProvinciaSedeLegale == null)
			{
				str1 = null;
			}
			else
			{
				str1 = source.ProvinciaSedeLegale.Codice;
			}
			clienteService7.CodiceProvinciaSedeLegale = str1;
			ClienteService clienteService8 = destination;
			if (source.NazioneSedeLegale == null)
			{
				codice2 = null;
			}
			else
			{
				codice2 = source.NazioneSedeLegale.Codice;
			}
			clienteService8.NazioneSedeLegale = codice2;
			destination.CodiceSituazione = source.CodiceSituazione;
			destination.IdCommerciale = source.IdCommerciale;
			destination.DescrizioneCommerciale = source.DescrizioneCommerciale;
			destination.EmailCommerciale = source.EmailCommerciale;
			destination.TelCommerciale = source.TelCommerciale;
			destination.TelCommerciale2 = source.TelCommerciale2;
			return destination;
		}

		public static DettaglioOrdine ConvertDettaglioOrdineServiceToDettaglioOrdine(DettaglioOrdineService dettaglioOrdineService, Ordine ordine)
		{
			Articolo byId;
			Variante variante;
			Imballo imballo;
			DettaglioOrdine dettaglioOrdine = new DettaglioOrdine()
			{
				Progressivo = dettaglioOrdineService.Progressivo,
				Ordine = ordine
			};
			if (dettaglioOrdineService.CodiceArticolo == null)
			{
				byId = null;
			}
			else
			{
				byId = ServiceLocator.Current.GetInstance<IArticoloRepository>().GetById(dettaglioOrdineService.CodiceArticolo);
			}
			Articolo articolo = byId;
			DettaglioOrdine dettaglioOrdine1 = dettaglioOrdine;
			if (dettaglioOrdineService.CodiceVariante == null)
			{
				variante = null;
			}
			else
			{
				IRepository<Variante, object> instance = ServiceLocator.Current.GetInstance<IRepository<Variante, object>>();
				Variante variante1 = new Variante()
				{
					Codice = dettaglioOrdineService.CodiceVariante,
					Articolo = articolo
				};
				variante = instance.GetById(variante1);
			}
			dettaglioOrdine1.Variante = variante;
			dettaglioOrdine.Segnataglie = ServiceLocator.Current.GetInstance<IRepository<Segnataglie, string>>().GetById(dettaglioOrdineService.CodiceSegnataglie);
			dettaglioOrdine.SetQuantita(dettaglioOrdineService.Quantita);
			dettaglioOrdine.SetPrezzi(dettaglioOrdineService.Prezzi);
			dettaglioOrdine.SetSconti(dettaglioOrdineService.Sconti);
			dettaglioOrdine.CodiceListino = dettaglioOrdineService.CodiceListino;
			dettaglioOrdine.NumeroCapi = dettaglioOrdineService.NumeroCapi;
			dettaglioOrdine.Totale = dettaglioOrdineService.Totale;
			dettaglioOrdine.Note = dettaglioOrdineService.Note;
			dettaglioOrdine.DataConsegna = dettaglioOrdineService.DataConsegna;
			dettaglioOrdine.DataUltimaConsegna = dettaglioOrdineService.DataUltimaConsegna;
			dettaglioOrdine.DataDecorrenza = dettaglioOrdineService.DataDecorrenza;
			DettaglioOrdine dettaglioOrdine2 = dettaglioOrdine;
			if (dettaglioOrdineService.CodiceImballo == null)
			{
				imballo = null;
			}
			else
			{
				imballo = ServiceLocator.Current.GetInstance<IRepository<Imballo, string>>().GetById(dettaglioOrdineService.CodiceImballo);
			}
			dettaglioOrdine2.Imballo = imballo;
			dettaglioOrdine.NumeroImballi = dettaglioOrdineService.NumeroImballi;
			dettaglioOrdine.UnitaMisura = dettaglioOrdineService.UnitaMisura;
			dettaglioOrdine.UnitaMisura = dettaglioOrdineService.UnitaMisura;
			return dettaglioOrdine;
		}

		public static TDestination ConvertEntity<TSource, TDestination>(TSource source)
		where TDestination : new()
		{
			TDestination tDestination;
			TDestination tDestination1 = default(TDestination);
			if (tDestination1 == null)
			{
				tDestination = Activator.CreateInstance<TDestination>();
			}
			else
			{
				tDestination1 = default(TDestination);
				tDestination = tDestination1;
			}
			TDestination destination = tDestination;
			Type destinationType = destination.GetType();
			Type sourceType = source.GetType();
			PropertyInfo[] properties = destinationType.GetProperties();
			for (int i = 0; i < (int)properties.Length; i++)
			{
				PropertyInfo p = properties[i];
				p.SetValue(destination, sourceType.GetProperty(p.Name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(source, null), null);
			}
			return destination;
		}

		public static TDestination ConvertEntity<TSource, TDestination>(TSource source, string[] destSelectors, params Func<TSource, object>[] sourceSelectors)
		where TDestination : new()
		{
			TDestination tDestination;
			TDestination tDestination1 = default(TDestination);
			if (tDestination1 == null)
			{
				tDestination = Activator.CreateInstance<TDestination>();
			}
			else
			{
				tDestination1 = default(TDestination);
				tDestination = tDestination1;
			}
			TDestination destination = tDestination;
			Type destinationType = destination.GetType();
			Type sourceType = source.GetType();
			PropertyInfo[] properties = destinationType.GetProperties();
			for (int i = 0; i < (int)properties.Length; i++)
			{
				string propertyName = properties[i].Name;
				int index = Array.IndexOf<string>(destSelectors, propertyName);
				if (index < 0)
				{
					properties[i].SetValue(destination, sourceType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetValue(source, null), null);
				}
				else
				{
					properties[i].SetValue(destination, sourceSelectors[index](source), null);
				}
			}
			return destination;
		}

		public static FamigliaService ConvertFamigliaToFamigliaService(Famiglia source)
		{
			FamigliaService destination = new FamigliaService()
			{
				Codice = source.Codice,
				Descrizione = source.Descrizione
			};
			return destination;
		}

		public static ImpostazioneApplicazioneService ConvertImpostazioneApplicazioneToImpostazioneApplicazioneService(ImpostazioneApplicazione source)
		{
			ImpostazioneApplicazioneService destination = new ImpostazioneApplicazioneService()
			{
				Chiave = source.Chiave,
				Valore = source.Valore
			};
			return destination;
		}

		private static Indirizzo ConvertIndirizzoServiceToIndirizzo(IndirizzoService indirizzoRequest, Cliente cliente)
		{
			Provincia byId;
			Nazione nazione;
			Indirizzo indirizzo = new Indirizzo()
			{
				Id = indirizzoRequest.Id,
				Cliente = cliente,
				RagioneSociale1 = indirizzoRequest.RagioneSociale1,
				RagioneSociale2 = indirizzoRequest.RagioneSociale2,
				Via1 = indirizzoRequest.Via1,
				Via2 = indirizzoRequest.Via2,
				Cap = indirizzoRequest.Cap,
				Citta1 = indirizzoRequest.Citta1,
				Citta2 = indirizzoRequest.Citta2
			};
			Indirizzo indirizzo1 = indirizzo;
			if (indirizzoRequest.CodiceProvincia == null)
			{
				byId = null;
			}
			else
			{
				byId = ServiceLocator.Current.GetInstance<IRepository<Provincia, string>>().GetById(indirizzoRequest.CodiceProvincia);
			}
			indirizzo1.Provincia = byId;
			Indirizzo indirizzo2 = indirizzo;
			if (indirizzoRequest.CodiceNazione == null)
			{
				nazione = null;
			}
			else
			{
				nazione = ServiceLocator.Current.GetInstance<IRepository<Nazione, string>>().GetById(indirizzoRequest.CodiceNazione);
			}
			indirizzo2.Nazione = nazione;
			indirizzo.Predefinito = indirizzoRequest.Predefinito;
			return indirizzo;
		}

		public static IndirizzoService ConvertIndirizzoToIndirizzoService(Indirizzo source)
		{
			string codice;
			string str;
			string codice1;
			IndirizzoService destination = new IndirizzoService()
			{
				Id = source.Id
			};
			IndirizzoService indirizzoService = destination;
			if (source.Cliente == null)
			{
				codice = null;
			}
			else
			{
				codice = source.Cliente.Codice;
			}
			indirizzoService.CodiceCliente = codice;
			destination.RagioneSociale1 = source.RagioneSociale1;
			destination.RagioneSociale2 = source.RagioneSociale2;
			destination.Via1 = source.Via1;
			destination.Via2 = source.Via2;
			destination.Cap = source.Cap;
			destination.Citta1 = source.Citta1;
			destination.Citta2 = source.Citta2;
			IndirizzoService indirizzoService1 = destination;
			if (source.Provincia == null)
			{
				str = null;
			}
			else
			{
				str = source.Provincia.Codice;
			}
			indirizzoService1.CodiceProvincia = str;
			IndirizzoService indirizzoService2 = destination;
			if (source.Nazione == null)
			{
				codice1 = null;
			}
			else
			{
				codice1 = source.Nazione.Codice;
			}
			indirizzoService2.CodiceNazione = codice1;
			destination.Predefinito = source.Predefinito;
			return destination;
		}

		public static Ordine ConvertOrdineServiceToOrdine(OrdineService ordineRequest)
		{
			int? idTipoOrdine;
			Agente byId;
			Cliente cliente;
			Marchio marchio;
			TipoOrdine tipoOrdine;
			Stagione stagione;
			Linea linea;
			Valuta valutum;
			MetodoPagamento metodoPagamento;
			Porto porto;
			Trasporto trasporto;
			Vettore vettore;
			StatoOrdine statoOrdine;
			Ordine ordine = new Ordine()
			{
				Codice = ordineRequest.Codice,
				CodiceGestionale = ordineRequest.CodiceGestionale
			};
			Ordine ordine1 = ordine;
			if (ordineRequest.CodiceUtente == null)
			{
				byId = null;
			}
			else
			{
				byId = ServiceLocator.Current.GetInstance<IAgenteRepository>().GetById(ordineRequest.CodiceUtente);
			}
			ordine1.Agente = byId;
			ordine.CodiceAgente = ordineRequest.CodiceAgente;
			ordine.NumeroOrdine = ordineRequest.NumeroOrdine;
			ordine.Data = ordineRequest.Data;
			ordine.DataInserimento = ordineRequest.DataInserimento;
			Ordine ordine2 = ordine;
			if (ordineRequest.CodiceCliente == null)
			{
				cliente = null;
			}
			else
			{
				cliente = ServiceLocator.Current.GetInstance<IClienteRepository>().GetById(ordineRequest.CodiceCliente);
			}
			ordine2.Cliente = cliente;
			ordine.IdIndirizzoConsegna = ordineRequest.IdIndirizzoConsegna;
			Ordine ordine3 = ordine;
			if (ordineRequest.CodiceMarchio == null)
			{
				marchio = null;
			}
			else
			{
				marchio = ServiceLocator.Current.GetInstance<IRepository<Marchio, string>>().GetById(ordineRequest.CodiceMarchio);
			}
			ordine3.Marchio = marchio;
			Ordine ordine4 = ordine;
			if (!ordineRequest.IdTipoOrdine.HasValue)
			{
				tipoOrdine = null;
			}
			else
			{
				IRepository<TipoOrdine, int> instance = ServiceLocator.Current.GetInstance<IRepository<TipoOrdine, int>>();
				idTipoOrdine = ordineRequest.IdTipoOrdine;
				tipoOrdine = instance.GetById(idTipoOrdine.Value);
			}
			ordine4.Tipo = tipoOrdine;
			Ordine ordine5 = ordine;
			if (ordineRequest.CodiceStagione == null)
			{
				stagione = null;
			}
			else
			{
				stagione = ServiceLocator.Current.GetInstance<IStagioneRepository>().GetById(ordineRequest.CodiceStagione);
			}
			ordine5.Stagione = stagione;
			Ordine ordine6 = ordine;
			if (ordineRequest.CodiceLinea == null)
			{
				linea = null;
			}
			else
			{
				linea = ServiceLocator.Current.GetInstance<IRepository<Linea, string>>().GetById(ordineRequest.CodiceLinea);
			}
			ordine6.Linea = linea;
			ordine.Banca = ordineRequest.Banca;
			Ordine ordine7 = ordine;
			if (ordineRequest.CodiceValuta == null)
			{
				valutum = null;
			}
			else
			{
				valutum = ServiceLocator.Current.GetInstance<IRepository<Valuta, string>>().GetById(ordineRequest.CodiceValuta);
			}
			ordine7.Valuta = valutum;
			Ordine ordine8 = ordine;
			if (ordineRequest.CodiceMetodoPagamento == null)
			{
				metodoPagamento = null;
			}
			else
			{
				metodoPagamento = ServiceLocator.Current.GetInstance<IRepository<MetodoPagamento, string>>().GetById(ordineRequest.CodiceMetodoPagamento);
			}
			ordine8.MetodoPagamento = metodoPagamento;
			ordine.ScontoMetodoPagamento = ordineRequest.ScontoMetodoPagamento;
			ordine.CodiceListino = ordineRequest.CodiceListino;
			ordine.NumeroCapi = ordineRequest.NumeroCapi;
			ordine.Totale = ordineRequest.Totale;
			Ordine ordine9 = ordine;
			if (!ordineRequest.IdPorto.HasValue)
			{
				porto = null;
			}
			else
			{
				IRepository<Porto, int> repository = ServiceLocator.Current.GetInstance<IRepository<Porto, int>>();
				idTipoOrdine = ordineRequest.IdPorto;
				porto = repository.GetById(idTipoOrdine.Value);
			}
			ordine9.Porto = porto;
			Ordine ordine10 = ordine;
			if (!ordineRequest.IdTrasporto.HasValue)
			{
				trasporto = null;
			}
			else
			{
				IRepository<Trasporto, int> instance1 = ServiceLocator.Current.GetInstance<IRepository<Trasporto, int>>();
				idTipoOrdine = ordineRequest.IdTrasporto;
				trasporto = instance1.GetById(idTipoOrdine.Value);
			}
			ordine10.Trasporto = trasporto;
			Ordine ordine11 = ordine;
			if (!ordineRequest.IdVettore.HasValue)
			{
				vettore = null;
			}
			else
			{
				IRepository<Vettore, int> repository1 = ServiceLocator.Current.GetInstance<IRepository<Vettore, int>>();
				idTipoOrdine = ordineRequest.IdVettore;
				vettore = repository1.GetById(idTipoOrdine.Value);
			}
			ordine11.Vettore = vettore;
			ordine.Note = ordineRequest.Note;
			Ordine ordine12 = ordine;
			if (ordineRequest.CodiceStatoOrdine == null)
			{
				statoOrdine = null;
			}
			else
			{
				statoOrdine = ServiceLocator.Current.GetInstance<IRepository<StatoOrdine, string>>().GetById(ordineRequest.CodiceStatoOrdine);
			}
			ordine12.Stato = statoOrdine;
			ordine.Online = ordineRequest.Online;
			ordine.DataConsegna = ordineRequest.DataConsegna;
			ordine.DataUltimaConsegna = ordineRequest.DataUltimaConsegna;
			ordine.DataDecorrenza = ordineRequest.DataDecorrenza;
			ordine.CodicePoliticaSconti = ordineRequest.CodicePoliticaSconti;
			List<DettaglioOrdine> dettagli = new List<DettaglioOrdine>();
			foreach (DettaglioOrdineService dettaglioRequest in ordineRequest.Dettagli)
			{
				dettagli.Add(ServerServiceUtils.ConvertDettaglioOrdineServiceToDettaglioOrdine(dettaglioRequest, ordine));
			}
			ordine.Dettagli = dettagli;
			return ordine;
		}
	}
}