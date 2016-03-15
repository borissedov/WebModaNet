using EW.WebModaNetClassLibrary.Entities;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public class NHibernateCondizioneCommercialeRepository : NHibernateBaseRepository<CondizioneCommerciale, int>, ICondizioneCommercialeRepository, IRepository<CondizioneCommerciale, int>
	{
		public NHibernateCondizioneCommercialeRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public CondizioneCommerciale Get(Cliente cliente, DateTime dataOrdine, Marchio marchio)
		{
			CondizioneCommerciale condizioneCommerciale = (
				from c in base.CurrentSession.Query<CondizioneCommerciale>()
				where c.Cliente == cliente && (c.DataDecorrenza <= dataOrdine) && (c.DataScadenza >= dataOrdine) && c.Marchio == marchio
				orderby c.DataDecorrenza descending
				select c).FirstOrDefault<CondizioneCommerciale>() ?? (
				from c in base.CurrentSession.Query<CondizioneCommerciale>()
				where c.Cliente == cliente && (c.DataDecorrenza <= dataOrdine) && (c.DataScadenza >= dataOrdine)
				orderby c.DataDecorrenza descending
				select c).FirstOrDefault<CondizioneCommerciale>();
			return condizioneCommerciale;
		}
	}
}