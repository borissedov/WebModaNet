using EW.WebModaNetClassLibrary.Entities;
using System;
using System.Collections.Generic;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface IImballoRepository : IRepository<Imballo, string>
	{
		IList<Imballo> FindByVariante(Variante variante);
	}
}