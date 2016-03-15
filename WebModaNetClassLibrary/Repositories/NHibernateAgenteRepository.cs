using EW.WebModaNetClassLibrary.Entities;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public class NHibernateAgenteRepository : NHibernateBaseRepository<Agente, string>, IAgenteRepository, IRepository<Agente, string>
	{
		public NHibernateAgenteRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public Agente AuthenticateAgente(string userName, string password)
		{
			Agente agente1;
			using (ITransaction transaction = base.CurrentSession.BeginTransaction())
			{
				Agente agente = (
					from a in base.CurrentSession.Query<Agente>()
					where (a.CodiceUtente == userName) && (a.Password == password)
					select a).SingleOrDefault<Agente>();
				transaction.Commit();
				agente1 = agente;
			}
			return agente1;
		}

		public Agente GetFromUserName(string userName)
		{
			Agente agente1;
			using (ITransaction transaction = base.CurrentSession.BeginTransaction())
			{
				Agente agente = base.CurrentSession.Query<Agente>().SingleOrDefault<Agente>((Agente a) => a.CodiceUtente == userName);
				transaction.Commit();
				agente1 = agente;
			}
			return agente1;
		}
	}
}