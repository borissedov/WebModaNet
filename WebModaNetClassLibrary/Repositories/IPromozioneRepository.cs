using EW.WebModaNetClassLibrary.Entities;
using System;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface IPromozioneRepository : IRepository<Promozione, string>
	{
		Promozione FindByPosizione(int posizione);
	}
}