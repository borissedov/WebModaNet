using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class AgenteValutaService
	{
		public string CodiceUtente
		{
			get;
			set;
		}

		public string CodiceValuta
		{
			get;
			set;
		}

		public AgenteValutaService()
		{
		}
	}
}