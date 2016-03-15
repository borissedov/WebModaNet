using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	public class DettaglioOrdineService
	{
		public string CodiceArticolo
		{
			get;
			set;
		}

		public string CodiceImballo
		{
			get;
			set;
		}

		public string CodiceListino
		{
			get;
			set;
		}

		public string CodiceOrdine
		{
			get;
			set;
		}

		public string CodiceSegnataglie
		{
			get;
			set;
		}

		public string CodiceVariante
		{
			get;
			set;
		}

		public DateTime DataConsegna
		{
			get;
			set;
		}

		public DateTime DataDecorrenza
		{
			get;
			set;
		}

		public DateTime DataUltimaConsegna
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}

		public string Note
		{
			get;
			set;
		}

		public int NumeroCapi
		{
			get;
			set;
		}

		public int NumeroImballi
		{
			get;
			set;
		}

		public decimal[] Prezzi
		{
			get;
			set;
		}

		public int Progressivo
		{
			get;
			set;
		}

		public int[] Quantita
		{
			get;
			set;
		}

		public decimal[] Sconti
		{
			get;
			set;
		}

		public decimal Totale
		{
			get;
			set;
		}

		public string UnitaMisura
		{
			get;
			set;
		}

		public DettaglioOrdineService()
		{
		}
	}
}