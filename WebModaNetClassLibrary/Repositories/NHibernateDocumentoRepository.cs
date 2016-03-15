using EW.WebModaNetClassLibrary.Entities;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public class NHibernateDocumentoRepository : NHibernateBaseRepository<Documento, int>, IDocumentoRepository, IRepository<Documento, int>
	{
		public NHibernateDocumentoRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public IList<string> GetTipiDocumento()
		{
			return (
				from d in base.CurrentSession.Query<Documento>()
				select d.Tipo into t
				orderby t
				select t).Distinct<string>().ToList<string>();
		}
	}
}