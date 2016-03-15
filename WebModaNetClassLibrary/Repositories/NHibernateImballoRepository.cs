using EW.WebModaNetClassLibrary.Entities;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public class NHibernateImballoRepository : NHibernateBaseRepository<Imballo, string>, IImballoRepository, IRepository<Imballo, string>
	{
		public NHibernateImballoRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public IList<Imballo> FindByVariante(Variante variante)
		{
			IList<Imballo> imballos;
			using (ITransaction transaction = base.CurrentSession.BeginTransaction())
			{
				string hql = "select i\r\n                               from Variante v\r\n                               inner join v.Imballi as i\r\n                               where v = :variante\r\n                                order by predefinito desc";
				IList<Imballo> imballi = base.CurrentSession.CreateQuery(hql).SetEntity("variante", variante).List<Imballo>();
				transaction.Commit();
				imballos = imballi;
			}
			return imballos;
		}
	}
}