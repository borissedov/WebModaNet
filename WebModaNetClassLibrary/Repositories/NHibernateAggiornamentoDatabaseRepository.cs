using EW.WebModaNetClassLibrary.Entities;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public class NHibernateAggiornamentoDatabaseRepository : NHibernateBaseRepository<AggiornamentoDatabase, object>, IAggiornamentoDatabaseRepository, IRepository<AggiornamentoDatabase, object>
	{
		public NHibernateAggiornamentoDatabaseRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public AggiornamentoDatabase Generate(Agente agente, int[] idTipoOrdineOffline, bool filtraDateConsegna)
		{
			AggiornamentoDatabase aggiornamentoDatabase = new AggiornamentoDatabase();
			int num = -4;
			int num1 = 4;
			aggiornamentoDatabase.Agenti = new List<Agente>()
			{
				agente
			};
			var articoli = 
				from art in base.CurrentSession.Query<Articolo>()
				join sta in base.CurrentSession.Query<Stagione>() on art.Stagione equals sta
				select new { Articolo = art, Stagione = sta } into obj
				join imo in base.CurrentSession.Query<ImpostazioneOrdine>() on obj.Articolo.Marchio equals imo.Marchio
				select new { Articolo = obj.Articolo, Stagione = obj.Stagione, ImpostazioneOrdine = imo } into obj
				join ims in base.CurrentSession.Query<ImpostazioneStagione>() on obj.Articolo.Stagione equals ims.Stagione
				select new { Articolo = obj.Articolo, Stagione = obj.Stagione, ImpostazioneOrdine = obj.ImpostazioneOrdine, ImpostazioneStagione = ims } into obj
				join dco in base.CurrentSession.Query<DataConsegnaOrdine>() on obj.Stagione equals dco.Stagione
				select new { Articolo = obj.Articolo, Stagione = obj.Stagione, ImpostazioneOrdine = obj.ImpostazioneOrdine, ImpostazioneStagione = obj.ImpostazioneStagione, DataConsegnaOrdine = dco } into obj
				where obj.ImpostazioneOrdine.Agente == agente
				where obj.ImpostazioneStagione.Agente == agente
				where idTipoOrdineOffline.Contains<int>(obj.DataConsegnaOrdine.TipoOrdine.Id)
				select obj;
			if (filtraDateConsegna)
			{
				articoli = 
					from obj in articoli
					where obj.DataConsegnaOrdine.DataInizioOrdine <= DateTime.Now.AddMonths(num1)
					where obj.DataConsegnaOrdine.DataFineOrdine >= DateTime.Now.AddMonths(num)
					select obj;
			}
			aggiornamentoDatabase.Articoli = (
				from o in articoli
				select o.Articolo).Distinct<Articolo>().ToList<Articolo>();
			aggiornamentoDatabase.Categorie = base.CurrentSession.Query<Categoria>().ToList<Categoria>();
			IQueryable<Cliente> clienti = 
				from c in base.CurrentSession.Query<Cliente>()
				where c.Agente == agente || this.CurrentSession.Query<VisibilitaCliente>().Any<VisibilitaCliente>((VisibilitaCliente v) => v.Cliente == c && v.CodiceAgente == agente.CodiceAgente)
				select c;
			aggiornamentoDatabase.Clienti = clienti.ToList<Cliente>();
			IQueryable<CodiceABarre> codiciABarre = (
				from o in articoli
				join c in base.CurrentSession.Query<CodiceABarre>() on o.Articolo equals c.Variante.Articolo
				select c).Distinct<CodiceABarre>();
			aggiornamentoDatabase.CodiciABarre = codiciABarre.ToList<CodiceABarre>();
			aggiornamentoDatabase.CondizioniCommerciali = (
				from c in clienti
				join cc in base.CurrentSession.Query<CondizioneCommerciale>() on c equals cc.Cliente
				select cc).ToList<CondizioneCommerciale>();
			aggiornamentoDatabase.DateConsegna = base.CurrentSession.Query<DataConsegnaOrdine>().ToList<DataConsegnaOrdine>();
			aggiornamentoDatabase.DettagliPoliticaSconti = base.CurrentSession.Query<DettaglioPoliticaSconti>().ToList<DettaglioPoliticaSconti>();
			aggiornamentoDatabase.Famiglie = base.CurrentSession.Query<Famiglia>().ToList<Famiglia>();
			aggiornamentoDatabase.Imballi = base.CurrentSession.Query<Imballo>().ToList<Imballo>();
			aggiornamentoDatabase.ImpostazioniApplicazione = base.CurrentSession.Query<ImpostazioneApplicazione>().ToList<ImpostazioneApplicazione>();
			aggiornamentoDatabase.Linee = base.CurrentSession.Query<Linea>().ToList<Linea>();
			aggiornamentoDatabase.Lingue = base.CurrentSession.Query<Lingua>().ToList<Lingua>();
			IQueryable<Listino> listini = (
				from o in articoli
				join l in base.CurrentSession.Query<Listino>() on o.Articolo equals l.Articolo
				select l).Distinct<Listino>();
			aggiornamentoDatabase.Listini = listini.ToList<Listino>();
			aggiornamentoDatabase.ListiniCliente = base.CurrentSession.Query<ListinoCliente>().ToList<ListinoCliente>();
			aggiornamentoDatabase.Marchi = base.CurrentSession.Query<Marchio>().ToList<Marchio>();
			aggiornamentoDatabase.MetodiPagamento = base.CurrentSession.Query<MetodoPagamento>().ToList<MetodoPagamento>();
			aggiornamentoDatabase.Nazioni = base.CurrentSession.Query<Nazione>().ToList<Nazione>();
			aggiornamentoDatabase.PoliticheSconti = base.CurrentSession.Query<PoliticaSconti>().ToList<PoliticaSconti>();
			aggiornamentoDatabase.Porti = base.CurrentSession.Query<Porto>().ToList<Porto>();
			aggiornamentoDatabase.Promozioni = base.CurrentSession.Query<Promozione>().ToList<Promozione>();
			aggiornamentoDatabase.Province = base.CurrentSession.Query<Provincia>().ToList<Provincia>();
			aggiornamentoDatabase.Segnataglie = base.CurrentSession.Query<Segnataglie>().ToList<Segnataglie>();
			aggiornamentoDatabase.Stagioni = base.CurrentSession.Query<Stagione>().ToList<Stagione>();
			aggiornamentoDatabase.StatiCliente = base.CurrentSession.Query<StatoCliente>().ToList<StatoCliente>();
			aggiornamentoDatabase.StatiOrdine = base.CurrentSession.Query<StatoOrdine>().ToList<StatoOrdine>();
			aggiornamentoDatabase.TipiAgente = base.CurrentSession.Query<TipoAgente>().ToList<TipoAgente>();
			aggiornamentoDatabase.TipiCategoria = base.CurrentSession.Query<TipoCategoria>().ToList<TipoCategoria>();
			aggiornamentoDatabase.TipiOrdine = base.CurrentSession.Query<TipoOrdine>().ToList<TipoOrdine>();
			aggiornamentoDatabase.Trasporti = base.CurrentSession.Query<Trasporto>().ToList<Trasporto>();
			aggiornamentoDatabase.Valute = base.CurrentSession.Query<Valuta>().ToList<Valuta>();
			aggiornamentoDatabase.Vettori = base.CurrentSession.Query<Vettore>().ToList<Vettore>();
			IQueryable<Variante> varianti = (
				from o in articoli
				join v in base.CurrentSession.Query<Variante>() on o.Articolo equals v.Articolo
				select v).Distinct<Variante>();
			aggiornamentoDatabase.Varianti = varianti.ToList<Variante>();
			aggiornamentoDatabase.VisibilitaClienti = (
				from v in base.CurrentSession.Query<VisibilitaCliente>()
				where v.CodiceAgente == agente.CodiceAgente
				select v).ToList<VisibilitaCliente>();
			return aggiornamentoDatabase;
		}
	}
}