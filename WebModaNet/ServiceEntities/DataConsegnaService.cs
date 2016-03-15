using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class DataConsegnaService
	{
		public string CodiceLinea
		{
			get;
			set;
		}

		public string CodiceMarchio
		{
			get;
			set;
		}

		public string CodiceStagione
		{
			get;
			set;
		}

		public int? CodiceTipoOrdine
		{
			get;
			set;
		}

		public DateTime? DataConsegna
		{
			get;
			set;
		}

		public DateTime? DataDecorrenza
		{
			get;
			set;
		}

		public DateTime DataFineOrdine
		{
			get;
			set;
		}

		public DateTime DataInizioOrdine
		{
			get;
			set;
		}

		public DateTime? DataUltimaConsegna
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}

		public DataConsegnaService()
		{
		}
	}
}