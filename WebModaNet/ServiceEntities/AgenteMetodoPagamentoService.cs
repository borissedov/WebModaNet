using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class AgenteMetodoPagamentoService
	{
		public string CodiceMetodoPagamento
		{
			get;
			set;
		}

		public string CodiceUtente
		{
			get;
			set;
		}

		public AgenteMetodoPagamentoService()
		{
		}
	}
}