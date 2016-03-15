using EW.WebModaNetClassLibrary.Entities;
using System;
using System.Collections.Generic;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface ILineaRepository : IRepository<Linea, string>
	{
		IList<Linea> GetFromStagione(string codiceStagione);

		IList<Linea> GetFromStagione(string codiceMarchio, string codiceStagione);
	}
}