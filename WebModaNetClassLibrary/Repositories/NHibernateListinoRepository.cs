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
	public class NHibernateListinoRepository : NHibernateBaseRepository<Listino, string>, IListinoRepository, IRepository<Listino, string>
	{
		public NHibernateListinoRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public IList<string> GetCodiciListino()
		{
			return (
				from l in base.CurrentSession.Query<Listino>()
				select l.Codice into l
				orderby l
				select l).Distinct<string>().ToList<string>();
		}

		public IList<Listino> GetListiniConsigliatiFromOrdine(string codiceListinoConsigliato, Ordine ordine)
		{
			IList<Listino> listinos;
			using (ITransaction transaction = base.CurrentSession.BeginTransaction())
			{
				IQueryable<Listino> listiniConsigliati = (
					from d in base.CurrentSession.Query<DettaglioOrdine>()
					join o in base.CurrentSession.Query<Ordine>() on d.Ordine equals o
					select new { DettaglioOrdine = d, Ordine = o } into o
					join a in base.CurrentSession.Query<Articolo>() on o.DettaglioOrdine.Variante.Articolo equals a
					select new { DettaglioOrdine = o.DettaglioOrdine, Ordine = o.Ordine, Articolo = a } into o
					join l in base.CurrentSession.Query<Listino>() on o.Articolo equals l.Articolo
					select new { DettaglioOrdine = o.DettaglioOrdine, Ordine = o.Ordine, Articolo = o.Articolo, Listino = l } into o
					where o.Ordine == ordine
					where o.Listino.Codice == codiceListinoConsigliato
					where (o.Listino.DataInizioValidita <= ordine.Data) && (o.Listino.DataFineValidita >= ordine.Data)
					select o.Listino into l
					orderby l.DataInizioValidita descending
					select l).Distinct<Listino>();
				List<Listino> listiniConsigliatiList = listiniConsigliati.ToList<Listino>();
				transaction.Commit();
				listinos = listiniConsigliatiList;
			}
			return listinos;
		}
	}
}