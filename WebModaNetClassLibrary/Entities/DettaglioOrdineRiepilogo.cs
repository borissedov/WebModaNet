using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class DettaglioOrdineRiepilogo
	{
		public string CodiceArticolo
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

		public string DescrizioneArticolo
		{
			get;
			set;
		}

		public string DescrizioneVariante
		{
			get;
			set;
		}

		public int IdDettaglio
		{
			get;
			set;
		}

		public decimal Markup
		{
			get;
			set;
		}

		public int NumeroCapi
		{
			get;
			set;
		}

		public decimal PrezzoAcquistoSingolo
		{
			get;
			set;
		}

		public decimal PrezzoConsigliatoSingolo
		{
			get;
			set;
		}

		public decimal PrezzoNettoSingolo
		{
			get;
			set;
		}

		public int[] Quantita
		{
			get;
			set;
		}

		public decimal Sconto
		{
			get;
			set;
		}

		public decimal Totale
		{
			get;
			set;
		}

		public decimal TotaleConsigliato
		{
			get;
			set;
		}

		public DettaglioOrdineRiepilogo()
		{
		}
	}
}