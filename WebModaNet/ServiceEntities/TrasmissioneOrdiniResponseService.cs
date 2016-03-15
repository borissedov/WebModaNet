using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	public class TrasmissioneOrdiniResponseService
	{
		public List<ClienteResponseService> Clienti
		{
			get;
			set;
		}

		public EsitoTrasmissioneService Esito
		{
			get;
			set;
		}

		public string Messaggio
		{
			get;
			set;
		}

		public List<OrdineResponseService> Ordini
		{
			get;
			set;
		}

		public TrasmissioneOrdiniResponseService()
		{
		}
	}
}