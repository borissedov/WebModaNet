using EW.WebModaNetClassLibrary.Entities;
using System;
using System.Collections.Generic;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface ICategoriaRepository : IRepository<Categoria, object>
	{
		IList<Categoria> GetFromTipo(TipoCategoria tipoCategoria);

		IList<Categoria> GetFromTipoAndStagione(TipoCategoria tipoCategoria, string codiceStagione);

		IList<Categoria> GetFromTipoAndStagione(TipoCategoria tipoCategoria, string codiceStagione, string codiceMarchio);

		IList<Categoria> GetFromTipoAndStagioneAndLinea(TipoCategoria tipoCategoria, string codiceStagione, string codiceLinea);

		IList<Categoria> GetFromTipoAndStagioneAndLinea(TipoCategoria tipoCategoria, string codiceStagione, string codiceLinea, string codiceMarchio);

		IList<Categoria> GetFromTipoAndStagioneAndLineaAndFamiglia(TipoCategoria tipoCategoria, string codiceStagione, string codiceLinea, string codiceFamiglia);

		IList<Categoria> GetFromTipoAndStagioneAndLineaAndFamiglia(TipoCategoria tipoCategoria, string codiceStagione, string codiceLinea, string codiceFamiglia, string codiceMarchio);
	}
}