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
	public class NHibernateClienteRepository : NHibernateBaseRepository<Cliente, string>, IClienteRepository, IRepository<Cliente, string>
	{
		public NHibernateClienteRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		[Obsolete]
		public IList<Cliente> __GetClientiAttiviForAgente(Agente agente)
		{
			IQueryable<Cliente> clienti = 
				from c in base.CurrentSession.Query<Cliente>()
				where c.Agente == agente && c.CodiceGestionale == null || this.CurrentSession.Query<VisibilitaCliente>().Any<VisibilitaCliente>((VisibilitaCliente v) => v.Cliente == c && v.CodiceAgente == agente.CodiceAgente)
				select c;
			return clienti.ToList<Cliente>();
		}

		public Cliente GetClienteForAgenteCliente(Agente agente)
		{
			if (agente == null)
			{
				throw new ArgumentNullException("agente");
			}
			string str = agente.CodiceAgente.ToString();
			return (
				from c in base.CurrentSession.Query<Cliente>()
				where c.Codice == str
				select c).SingleOrDefault<Cliente>();
		}

		public Cliente GetClientePerStampa(Ordine ordine)
		{
			if (ordine == null)
			{
				throw new ArgumentNullException("ordine");
			}
			Cliente cliente = ordine.Cliente;
			string codiceGestionale = cliente.CodiceGestionale;
			if (!string.IsNullOrEmpty(codiceGestionale) && cliente.Codice != codiceGestionale)
			{
				Cliente clienteGestionale = base.CurrentSession.Query<Cliente>().SingleOrDefault<Cliente>((Cliente c) => c.Codice == codiceGestionale);
				if (clienteGestionale != null)
				{
					return clienteGestionale;
				}
			}
			return cliente;
		}

		public IList<Cliente> GetClientiAttiviForAgente(Agente agente)
		{
			return this.GetClientiAttiviForAgente(agente, null, false, false);
		}

		public IList<Cliente> GetClientiAttiviForAgente(Agente agente, Expression<Func<Cliente, object>> orderByClause, bool descending, bool includeDetails)
		{
			IList<Cliente> clientes;
			using (ITransaction transaction = base.CurrentSession.BeginTransaction())
			{
				IQueryable<Cliente> clienti = 
					from c in base.CurrentSession.Query<Cliente>()
					where c.Agente == agente && c.CodiceGestionale == null || this.CurrentSession.Query<VisibilitaCliente>().Any<VisibilitaCliente>((VisibilitaCliente v) => v.Cliente == c && v.CodiceAgente == agente.CodiceAgente)
					select c;
				if (orderByClause != null)
				{
					clienti = (!descending ? clienti.OrderBy<Cliente, object>(orderByClause) : clienti.OrderByDescending<Cliente, object>(orderByClause));
				}
				if (includeDetails)
				{
					clienti = clienti.FetchMany<Cliente, Indirizzo>((Cliente c) => c.Indirizzi).ThenFetch<Cliente, Indirizzo, Provincia>((Indirizzo i) => i.Provincia);
				}
				List<Cliente> returnValue = clienti.ToList<Cliente>();
				transaction.Commit();
				clientes = returnValue;
			}
			return clientes;
		}

		public IList<Cliente> GetClientiDaTrasmettere(string codiceStatoCliente, Agente agente)
		{
			IQueryable<Cliente> clientiNuovi = 
				from o in base.CurrentSession.Query<Ordine>()
				where o.Agente == agente && o.CodiceAgente == agente.CodiceAgente
				join c in base.CurrentSession.Query<Cliente>() on o.Cliente equals c
				select c into c
				where c.Stato.Codice == codiceStatoCliente
				select c;
			return clientiNuovi.ToList<Cliente>();
		}

		public IList<Cliente> GetClientiNonAgenti(Agente agente, bool ascending, params Expression<Func<Cliente, object>>[] orderByClauses)
		{
			IQueryable<Cliente> clienti = 
				from c in base.CurrentSession.Query<Cliente>()
				join v in base.CurrentSession.Query<VisibilitaCliente>() on c equals v.Cliente
				select new { Cliente = c, VisibilitaCliente = v } into o
				where o.VisibilitaCliente.CodiceAgente == agente.CodiceAgente
				select o into c
				select c.Cliente into c
				where !this.CurrentSession.Query<Agente>().Any<Agente>((Agente a) => a.CodiceUtente == ("CL" + c.Codice))
				select c;
			if (orderByClauses != null && (int)orderByClauses.Length > 0)
			{
				Expression<Func<Cliente, object>>[] expressionArray = orderByClauses;
				for (int i = 0; i < (int)expressionArray.Length; i++)
				{
					Expression<Func<Cliente, object>> clause = expressionArray[i];
					clienti = (!ascending ? clienti.OrderByDescending<Cliente, object>(clause) : clienti.OrderBy<Cliente, object>(clause));
				}
			}
			return clienti.ToList<Cliente>();
		}

		public string GetNewCodice(bool isOnline, Agente agente)
		{
			string nuovoCodice = string.Empty;
			nuovoCodice = (!isOnline ? string.Concat(nuovoCodice, "F") : string.Concat(nuovoCodice, "O"));
			nuovoCodice = string.Concat(nuovoCodice, agente.CodiceUtente);
			nuovoCodice = string.Concat(nuovoCodice, string.Format("{0:yyyyMMddhhmmss}", DateTime.Now));
			return nuovoCodice;
		}

		public void SaveNuovoCliente(Cliente cliente)
		{
			using (ITransaction transaction = base.CurrentSession.BeginTransaction())
			{
				base.CurrentSession.Save(cliente);
				transaction.Commit();
			}
		}
	}
}