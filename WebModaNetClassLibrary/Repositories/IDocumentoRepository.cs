using EW.WebModaNetClassLibrary.Entities;
using System;
using System.Collections.Generic;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface IDocumentoRepository : IRepository<Documento, int>
	{
		IList<string> GetTipiDocumento();
	}
}