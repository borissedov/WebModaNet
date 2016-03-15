using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class ValutaService
	{
		public virtual string Codice
		{
			get;
			set;
		}

		public virtual string Descrizione
		{
			get;
			set;
		}

		public virtual string Simbolo
		{
			get;
			set;
		}

		public ValutaService()
		{
		}
	}
}