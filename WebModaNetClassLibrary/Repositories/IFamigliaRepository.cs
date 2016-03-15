using EW.WebModaNetClassLibrary.Entities;
using System;
using System.Collections.Generic;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface IFamigliaRepository : IRepository<Famiglia, string>
	{
		IList<Famiglia> GetFromStagione(string codiceStagione);

		IList<Famiglia> GetFromStagioneAndLineaAndGruppo(string codiceStagione, string codiceLinea, string codiceGruppo, TipoCategoria tipoGruppo);

		IList<Famiglia> GetFromStagioneAndLineaAndGruppo(string codiceStagione, string codiceLinea, string codiceGruppo, TipoCategoria tipoGruppo, string codiceMarchio);
	}
}