using EW.WebModaNetClassLibrary.Entities;
using System;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface IAggiornamentoDatabaseRepository : IRepository<AggiornamentoDatabase, object>
	{
		AggiornamentoDatabase Generate(Agente agente, int[] idTipoOrdineOffline, bool filtraDateConsegna);
	}
}