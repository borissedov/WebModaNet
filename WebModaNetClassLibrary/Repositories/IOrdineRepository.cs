using EW.WebModaNetClassLibrary.Entities;
using System;
using System.Collections.Generic;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface IOrdineRepository : IRepository<Ordine, string>
	{
		void AnnullaOrdiniSospesi(Agente agente, int[] idTipiOrdine, StatoOrdine statoOrdineTemporaneo, StatoOrdine statoOrdineSospeso, int numeroGiorni, StatoOrdine statoOrdineAnnullato);

		int GetNumeroOrdiniForAgenteByStato(string codiceStatoOrdine, Agente agente);

		string GetNuovoCodiceOrdine(bool isOnline, Agente agente);

		int GetNuovoNumeroOrdine(Agente agente);

		Ordine GetOrdineForAgente(string codiceOrdine, Agente agente);

		IList<Ordine> GetOrdiniDaTrasmettere(string codiceStatoOrdine, Agente agente);

		IList<Ordine> GetOrdiniForAgenteByStato(string codiceStatoOrdine, Agente agente);

		IList<Ordine> GetOrdiniForAgenteByStato(Agente agente, params string[] codiciStatoOrdine);

		void SaveNuovoOrdine(Ordine ordine);

		void SaveOrdineTrasmesso(Ordine ordine);
	}
}