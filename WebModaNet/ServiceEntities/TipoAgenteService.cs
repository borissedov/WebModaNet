using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class TipoAgenteService
	{
		public string Codice
		{
			get;
			set;
		}

		public string Descrizione
		{
			get;
			set;
		}

		public TipoAgenteService()
		{
		}
	}
}