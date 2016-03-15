using EW.WebModaNetClassLibrary.Entities;
using System;
using System.Collections.Generic;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface IStagioneRepository : IRepository<Stagione, string>
	{
		IList<Stagione> GetAll(Agente agente, Marchio marchio, TipoOrdine tipoOrdine, DateTime dataOrdine);
	}
}