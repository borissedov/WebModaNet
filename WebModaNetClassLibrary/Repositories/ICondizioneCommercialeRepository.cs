using EW.WebModaNetClassLibrary.Entities;
using System;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface ICondizioneCommercialeRepository : IRepository<CondizioneCommerciale, int>
	{
		CondizioneCommerciale Get(Cliente cliente, DateTime dataOrdine, Marchio marchio);
	}
}