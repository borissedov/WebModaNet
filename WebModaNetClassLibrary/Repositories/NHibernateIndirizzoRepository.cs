using EW.WebModaNetClassLibrary.Entities;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public class NHibernateIndirizzoRepository : NHibernateBaseRepository<Indirizzo, string>, IIndirizzoRepository, IRepository<Indirizzo, string>
	{
		public NHibernateIndirizzoRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public Indirizzo GetIndirizzoForCliente(int idIndirizzo, Cliente cliente)
		{
			if (cliente == null)
			{
				throw new ArgumentNullException("cliente");
			}
			return (
				from i in base.CurrentSession.Query<Indirizzo>()
				where i.Id == idIndirizzo && i.Cliente == cliente
				select i).SingleOrDefault<Indirizzo>();
		}

		public Indirizzo GetIndirizzoPredefinitoForCliente(Cliente cliente)
		{
			if (cliente == null)
			{
				throw new ArgumentNullException("cliente");
			}
			Indirizzo indirizzo = (
				from i in base.CurrentSession.Query<Indirizzo>()
				where i.Cliente == cliente && i.Predefinito
				select i).FirstOrDefault<Indirizzo>();
			if (indirizzo != null)
			{
				return indirizzo;
			}
			return cliente.GetIndirizzoSedeLegale();
		}

		public int GetNuovoNumeroIndirizzo(Cliente cliente)
		{
			int maxId = 0;
			if (cliente == null)
			{
				throw new ArgumentNullException("cliente");
			}
			if ((
				from i in base.CurrentSession.Query<Indirizzo>()
				where i.Cliente == cliente
				select i).Count<Indirizzo>() > 0)
			{
				maxId = (
					from i in base.CurrentSession.Query<Indirizzo>()
					where i.Cliente == cliente
					select i.Id).Max<int>();
			}
			return maxId + 1 + 500;
		}
	}
}