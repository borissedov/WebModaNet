using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class ProvinciaService
	{
		public string Codice
		{
			get;
			set;
		}

		public string CodiceNazione
		{
			get;
			set;
		}

		public string Descrizione
		{
			get;
			set;
		}

		public ProvinciaService()
		{
		}
	}
}