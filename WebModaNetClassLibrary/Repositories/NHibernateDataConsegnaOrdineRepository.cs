using EW.WebModaNetClassLibrary.Entities;
using NHibernate;
using System;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public class NHibernateDataConsegnaOrdineRepository : NHibernateBaseRepository<DataConsegnaOrdine, int>, IDataConsegnaOrdineRepository, IRepository<DataConsegnaOrdine, int>
	{
		public NHibernateDataConsegnaOrdineRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}
	}
}