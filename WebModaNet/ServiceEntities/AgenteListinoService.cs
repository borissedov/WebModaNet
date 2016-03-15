using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class AgenteListinoService
	{
		public string CodiceListino
		{
			get;
			set;
		}

		public string CodiceUtente
		{
			get;
			set;
		}

		public AgenteListinoService()
		{
		}
	}
}