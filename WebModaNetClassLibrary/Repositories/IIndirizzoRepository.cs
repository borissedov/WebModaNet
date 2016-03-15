using EW.WebModaNetClassLibrary.Entities;
using System;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface IIndirizzoRepository : IRepository<Indirizzo, string>
	{
		Indirizzo GetIndirizzoForCliente(int idIndirizzo, Cliente cliente);

		Indirizzo GetIndirizzoPredefinitoForCliente(Cliente cliente);

		int GetNuovoNumeroIndirizzo(Cliente cliente);
	}
}