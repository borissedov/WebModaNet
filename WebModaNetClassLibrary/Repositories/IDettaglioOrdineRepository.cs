using EW.WebModaNetClassLibrary.Entities;
using System;
using System.Collections.Generic;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface IDettaglioOrdineRepository : IRepository<DettaglioOrdine, int>
	{
		void DeleteAndUpdateOrdine(DettaglioOrdine dettaglioOrdine, IOrdineRepository ordineRepository);

		DettaglioOrdine GetDettaglioOrdineFromVariante(Ordine ordine, Variante variante);

		DettaglioOrdine GetDettaglioOrdineFromVarianteImballo(Ordine ordine, Variante variante, Imballo imballo);

		IList<DettaglioOrdine> GetDettagliOrdineFromOrdine(Ordine ordine);

		int GetProgressivo(Ordine ordine);
	}
}