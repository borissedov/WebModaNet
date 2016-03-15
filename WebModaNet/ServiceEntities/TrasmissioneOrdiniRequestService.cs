using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	public class TrasmissioneOrdiniRequestService
	{
		public List<ClienteService> Clienti
		{
			get;
			set;
		}

		public string CodiceUtente
		{
			get;
			set;
		}

		public string Hash
		{
			get;
			set;
		}

		public List<OrdineService> Ordini
		{
			get;
			set;
		}

		public TrasmissioneOrdiniRequestService()
		{
		}
	}
}