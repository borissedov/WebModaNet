using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class RiepilogoOrdine
	{
		public string CodiciSegnataglie
		{
			get;
			set;
		}

		public List<DettaglioOrdineRiepilogo> DettagliRiepilogo
		{
			get;
			set;
		}

		public decimal MarkupMedio
		{
			get;
			set;
		}

		public int NumeroCapi
		{
			get;
			set;
		}

		public int NumeroMassimoColonne
		{
			get;
			set;
		}

		public decimal Sconto
		{
			get;
			set;
		}

		public string[] Taglie
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

		public decimal TotaleScontato
		{
			get;
			set;
		}

		public RiepilogoOrdine()
		{
		}
	}
}