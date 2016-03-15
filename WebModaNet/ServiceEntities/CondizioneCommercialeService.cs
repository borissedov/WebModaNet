using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class CondizioneCommercialeService
	{
		public int CodiceAgente
		{
			get;
			set;
		}

		public string CodiceCliente
		{
			get;
			set;
		}

		public string CodiceListino
		{
			get;
			set;
		}

		public string CodiceMarchio
		{
			get;
			set;
		}

		public string CodiceMetodoPagamento
		{
			get;
			set;
		}

		public string CodicePoliticaSconti
		{
			get;
			set;
		}

		public DateTime DataDecorrenza
		{
			get;
			set;
		}

		public DateTime DataScadenza
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}

		public CondizioneCommercialeService()
		{
		}
	}
}