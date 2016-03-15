using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class TagliaInfo
	{
		public string Descrizione
		{
			get;
			set;
		}

		public bool DisponibilitaAttivata
		{
			get;
			set;
		}

		public bool ImballiAttivati
		{
			get;
			set;
		}

		public string Nota
		{
			get;
			set;
		}

		public decimal PrezzoAcquisto
		{
			get;
			set;
		}

		public decimal PrezzoConsigliato
		{
			get;
			set;
		}

		public int QuantitaConfezione
		{
			get;
			set;
		}

		public int QuantitaDisponibile
		{
			get;
			set;
		}

		public int QuantitaInserita
		{
			get;
			set;
		}

		public bool Valida
		{
			get;
			set;
		}

		public bool VarianteInEsaurimento
		{
			get;
			set;
		}

		public TagliaInfo()
		{
		}
	}
}