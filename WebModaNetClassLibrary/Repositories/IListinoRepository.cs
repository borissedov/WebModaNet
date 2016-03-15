using EW.WebModaNetClassLibrary.Entities;
using System;
using System.Collections.Generic;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface IListinoRepository : IRepository<Listino, string>
	{
		IList<string> GetCodiciListino();

		IList<Listino> GetListiniConsigliatiFromOrdine(string codiceListinoConsigliato, Ordine ordine);
	}
}