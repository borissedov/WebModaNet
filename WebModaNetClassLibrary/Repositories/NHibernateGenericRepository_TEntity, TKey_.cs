using NHibernate;
using System;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public class NHibernateGenericRepository<TEntity, TKey> : NHibernateBaseRepository<TEntity, TKey>, IRepository<TEntity, TKey>
	{
		public NHibernateGenericRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}
	}
}