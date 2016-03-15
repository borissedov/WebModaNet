using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	public class ClienteResponseService
	{
		public string Codice
		{
			get;
			set;
		}

		public string CodiceGestionale
		{
			get;
			set;
		}

		public StatoTrasmissioneService Stato
		{
			get;
			set;
		}

		public ClienteResponseService()
		{
		}
	}
}