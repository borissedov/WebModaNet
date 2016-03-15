using EW.WebModaNetClassLibrary.Entities;
using System;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface IAgenteRepository : IRepository<Agente, string>
	{
		Agente AuthenticateAgente(string userName, string password);

		Agente GetFromUserName(string userName);
	}
}