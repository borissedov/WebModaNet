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
	public class NHibernateDettaglioOrdineRepository : NHibernateBaseRepository<DettaglioOrdine, int>, IDettaglioOrdineRepository, IRepository<DettaglioOrdine, int>
	{
		public NHibernateDettaglioOrdineRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public void DeleteAndUpdateOrdine(DettaglioOrdine dettaglioOrdine, IOrdineRepository ordineRepository)
		{
			Ordine ordine = dettaglioOrdine.Ordine;
			ordine.Dettagli.Remove(dettaglioOrdine);
			this.Delete(dettaglioOrdine);
			ordine.NumeroCapi = ordine.Dettagli.Sum<DettaglioOrdine>((DettaglioOrdine d) => d.NumeroCapi);
			ordine.Totale = ordine.Dettagli.Sum<DettaglioOrdine>((DettaglioOrdine d) => d.Totale);
			ordineRepository.Save(ordine);
		}

		public DettaglioOrdine GetDettaglioOrdineFromVariante(Ordine ordine, Variante variante)
		{
			if (ordine == null || variante == null)
			{
				return null;
			}
			return (
				from d in base.CurrentSession.Query<DettaglioOrdine>()
				where d.Ordine == ordine && d.Variante == variante
				select d).FirstOrDefault<DettaglioOrdine>();
		}

		public DettaglioOrdine GetDettaglioOrdineFromVarianteImballo(Ordine ordine, Variante variante, Imballo imballo)
		{
			if (ordine == null || variante == null)
			{
				return null;
			}
			if (imballo == null)
			{
				return this.GetDettaglioOrdineFromVariante(ordine, variante);
			}
			return (
				from d in base.CurrentSession.Query<DettaglioOrdine>()
				where d.Ordine == ordine && d.Variante == variante && d.Imballo == imballo
				select d).FirstOrDefault<DettaglioOrdine>();
		}

		public IList<DettaglioOrdine> GetDettagliOrdineFromOrdine(Ordine ordine)
		{
			IList<DettaglioOrdine> dettaglioOrdines;
			using (ITransaction transaction = base.CurrentSession.BeginTransaction())
			{
				INhFetchRequest<DettaglioOrdine, Segnataglie> dettagliOrdine = (
					from d in base.CurrentSession.Query<DettaglioOrdine>()
					join o in base.CurrentSession.Query<Ordine>() on d.Ordine equals o
					select new { DettaglioOrdine = d, Ordine = o } into o
					where o.Ordine == ordine
					select o into d
					select d.DettaglioOrdine).Fetch<DettaglioOrdine, Variante>((DettaglioOrdine d) => d.Variante).ThenFetch<DettaglioOrdine, Variante, Articolo>((Variante v) => v.Articolo).ThenFetch<DettaglioOrdine, Articolo, Segnataglie>((Articolo a) => a.Segnataglie);
				List<DettaglioOrdine> dettagliOrdineList = dettagliOrdine.ToList<DettaglioOrdine>();
				transaction.Commit();
				dettaglioOrdines = dettagliOrdineList;
			}
			return dettaglioOrdines;
		}

		public int GetProgressivo(Ordine ordine)
		{
			DettaglioOrdine dettaglio = (
				from d in base.CurrentSession.Query<DettaglioOrdine>()
				where d.Ordine == ordine
				orderby d.Progressivo descending
				select d).FirstOrDefault<DettaglioOrdine>();
			if (dettaglio == null)
			{
				return 1;
			}
			return dettaglio.Progressivo + 1;
		}
	}
}