using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class NazioneService
	{
		public bool Cee
		{
			get;
			set;
		}

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

		public NazioneService()
		{
		}
	}
}