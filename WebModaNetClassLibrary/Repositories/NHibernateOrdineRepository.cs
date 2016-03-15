using EW.WebModaNetClassLibrary.Entities;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public class NHibernateOrdineRepository : NHibernateBaseRepository<Ordine, string>, IOrdineRepository, IRepository<Ordine, string>
	{
		public NHibernateOrdineRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public void AnnullaOrdiniSospesi(Agente agente, int[] idTipiOrdine, StatoOrdine statoOrdineTemporaneo, StatoOrdine statoOrdineSospeso, int numeroGiorni, StatoOrdine statoOrdineAnnullato)
		{
			DateTime now = DateTime.Now;
			DateTime dateTime = now.AddDays((double)(numeroGiorni * -1));
			IQueryable<Ordine> ordiniSospesi = 
				from o in base.CurrentSession.Query<Ordine>()
				where o.Agente == agente
				where idTipiOrdine.Contains<int>(o.Tipo.Id)
				where o.Stato == statoOrdineTemporaneo || o.Stato == statoOrdineSospeso
				where o.DataInserimento < dateTime
				select o;
			foreach (Ordine o in ordiniSospesi)
			{
				o.Stato = statoOrdineAnnullato;
			}
			base.Save(ordiniSospesi);
		}

		public int GetNumeroOrdiniForAgenteByStato(string codiceStatoOrdine, Agente agente)
		{
			if (agente == null)
			{
				throw new ArgumentNullException("agente");
			}
			return this.GetOrdiniForAgente(codiceStatoOrdine, agente).Count<Ordine>();
		}

		public string GetNuovoCodiceOrdine(bool isOnline, Agente agente)
		{
			string codiceOrdine = string.Empty;
			codiceOrdine = (!isOnline ? string.Concat(codiceOrdine, "F") : string.Concat(codiceOrdine, "O"));
			codiceOrdine = string.Concat(codiceOrdine, agente.CodiceUtente);
			codiceOrdine = string.Concat(codiceOrdine, string.Format("{0:yyyyMMddhhmmss}", DateTime.Now));
			return codiceOrdine;
		}

		public int GetNuovoNumeroOrdine(Agente agente)
		{
			int maxId = 0;
			DateTime dateTime = new DateTime(DateTime.Now.Year, 1, 1);
			if ((
				from o in base.CurrentSession.Query<Ordine>()
				where (o.Data >= dateTime) && o.Agente == agente
				select o).Count<Ordine>() > 0)
			{
				maxId = (
					from o in base.CurrentSession.Query<Ordine>()
					where (o.Data >= dateTime) && o.Agente == agente
					select o.NumeroOrdine).Max<int>();
			}
			return maxId + 1;
		}

		public Ordine GetOrdineForAgente(string codiceOrdine, Agente agente)
		{
			if (agente == null)
			{
				throw new ArgumentNullException("agente");
			}
			return (
				from o in base.CurrentSession.Query<Ordine>()
				where (o.Codice == codiceOrdine) && o.Agente == agente && o.CodiceAgente == agente.CodiceAgente
				select o).SingleOrDefault<Ordine>();
		}

		public IList<Ordine> GetOrdiniDaTrasmettere(string codiceStatoOrdine, Agente agente)
		{
			return this.GetOrdiniForAgenteByStato(codiceStatoOrdine, agente);
		}

		private IQueryable<Ordine> GetOrdiniForAgente(string codiceStatoOrdine, Agente agente)
		{
			if (agente == null)
			{
				throw new ArgumentNullException("agente");
			}
			return 
				from o in base.CurrentSession.Query<Ordine>()
				where (o.Stato.Codice == codiceStatoOrdine) && o.Agente == agente && o.CodiceAgente == agente.CodiceAgente
				select o;
		}

		public IList<Ordine> GetOrdiniForAgenteByStato(Agente agente, params string[] codiciStatoOrdine)
		{
			if (agente == null)
			{
				throw new ArgumentNullException("agente");
			}
			return (
				from o in base.CurrentSession.Query<Ordine>()
				where o.Agente == agente && codiciStatoOrdine.Contains<string>(o.Stato.Codice)
				select o).ToList<Ordine>();
		}

		public IList<Ordine> GetOrdiniForAgenteByStato(string codiceStatoOrdine, Agente agente)
		{
			if (agente == null)
			{
				throw new ArgumentNullException("agente");
			}
			return this.GetOrdiniForAgente(codiceStatoOrdine, agente).ToList<Ordine>();
		}

		public void SaveNuovoOrdine(Ordine ordine)
		{
			using (ITransaction transaction = base.CurrentSession.BeginTransaction())
			{
				base.CurrentSession.Save(ordine);
				transaction.Commit();
			}
		}

		public void SaveOrdineTrasmesso(Ordine ordine)
		{
			using (ITransaction transaction = base.CurrentSession.BeginTransaction())
			{
				base.CurrentSession.Save(ordine);
				transaction.Commit();
			}
		}
	}
}