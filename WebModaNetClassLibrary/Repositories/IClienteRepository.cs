using EW.WebModaNetClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface IClienteRepository : IRepository<Cliente, string>
	{
		Cliente GetClienteForAgenteCliente(Agente agente);

		Cliente GetClientePerStampa(Ordine ordine);

		IList<Cliente> GetClientiAttiviForAgente(Agente agente);

		IList<Cliente> GetClientiAttiviForAgente(Agente agente, Expression<Func<Cliente, object>> orderByClause, bool descending, bool includeDetails);

		IList<Cliente> GetClientiDaTrasmettere(string codiceStatoCliente, Agente agente);

		IList<Cliente> GetClientiNonAgenti(Agente agente, bool ascending, params Expression<Func<Cliente, object>>[] orderByClauses);

		string GetNewCodice(bool isOnline, Agente agente);

		void SaveNuovoCliente(Cliente cliente);
	}
}