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
	public class NHibernateLineaRepository : NHibernateBaseRepository<Linea, string>, ILineaRepository, IRepository<Linea, string>
	{
		public NHibernateLineaRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public IList<Linea> GetFromStagione(string codiceStagione)
		{
			return this.GetFromStagione(null, codiceStagione);
		}

		public IList<Linea> GetFromStagione(string codiceMarchio, string codiceStagione)
		{
			var linee = 
				from l in base.CurrentSession.Query<Linea>()
				join a in base.CurrentSession.Query<Articolo>() on l equals a.Linea
				select new { Linea = l, Articolo = a };
			if (!string.IsNullOrEmpty(codiceMarchio))
			{
				linee = 
					from o in linee
					where o.Articolo.Marchio.Codice == codiceMarchio
					select o;
			}
			if (!string.IsNullOrEmpty(codiceStagione))
			{
				linee = 
					from o in linee
					where o.Articolo.Stagione.Codice == codiceStagione
					select o;
			}
			return (
				from o in linee
				select o.Linea into l
				orderby l.Codice
				select l).Distinct<Linea>().ToList<Linea>();
		}
	}
}