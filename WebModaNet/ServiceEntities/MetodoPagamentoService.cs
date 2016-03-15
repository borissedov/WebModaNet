using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class MetodoPagamentoService
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

		public bool FineMese
		{
			get;
			set;
		}

		public decimal Sconto
		{
			get;
			set;
		}

		public MetodoPagamentoService()
		{
		}
	}
}