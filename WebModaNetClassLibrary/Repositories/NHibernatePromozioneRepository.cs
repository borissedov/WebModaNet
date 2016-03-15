using EW.WebModaNetClassLibrary.Entities;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public class NHibernatePromozioneRepository : NHibernateBaseRepository<Promozione, string>, IPromozioneRepository, IRepository<Promozione, string>
	{
		public NHibernatePromozioneRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public Promozione FindByPosizione(int posizione)
		{
			return (
				from p in base.CurrentSession.Query<Promozione>()
				where p.Posizione == posizione
				select p).SingleOrDefault<Promozione>();
		}
	}
}