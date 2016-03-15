using EW.WebModaNetClassLibrary.Entities;
using System;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface IArticoloRepository : IRepository<Articolo, string>
	{
		int[] GetQuantitaImpegnateForVariante(Variante variante, Ordine ordineCorrente, params string[] codiciStatoOrdine);
	}
}