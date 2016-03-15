using System;
using System.Collections.Generic;

namespace EW.WebModaNetClassLibrary.Entities
{
	[Serializable]
	public class ListinoVariante
	{
		public string CodiceVariante;

		public decimal[] PrezziAcquisto;

		public decimal[] PrezziConsigliati;

		public List<decimal> Sconti;

		public ListinoVariante()
		{
			this.Sconti = new List<decimal>();
		}
	}
}