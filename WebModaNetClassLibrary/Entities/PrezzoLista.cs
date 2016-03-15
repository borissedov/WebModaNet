using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	[Serializable]
	public class PrezzoLista
	{
		public string ClasseCssAcquisto
		{
			get;
			set;
		}

		public string ClasseCssConsigliato
		{
			get;
			set;
		}

		public decimal Markup
		{
			get;
			set;
		}

		public decimal PrezzoAcquisto
		{
			get;
			set;
		}

		public string PrezzoAcquistoFormattato
		{
			get;
			set;
		}

		public decimal PrezzoConsigliato
		{
			get;
			set;
		}

		public string PrezzoConsigliatoFormattato
		{
			get;
			set;
		}

		public PrezzoLista()
		{
		}
	}
}