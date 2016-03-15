using EW.WebModaNetClassLibrary.Entities;
using NHibernate;
using System;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public class NHibernateImpostazioneApplicazioneRepository : NHibernateBaseRepository<ImpostazioneApplicazione, string>, IImpostazioneApplicazioneRepository, IRepository<ImpostazioneApplicazione, string>
	{
		public NHibernateImpostazioneApplicazioneRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}
	}
}