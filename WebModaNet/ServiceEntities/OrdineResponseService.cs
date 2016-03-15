using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	public class OrdineResponseService
	{
		public string Codice
		{
			get;
			set;
		}

		public StatoTrasmissioneService Stato
		{
			get;
			set;
		}

		public OrdineResponseService()
		{
		}
	}
}