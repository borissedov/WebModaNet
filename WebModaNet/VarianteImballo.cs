using EW.WebModaNetClassLibrary.Entities;
using System;

namespace EW.WebModaNet
{
	public class VarianteImballo
	{
		public Variante variante;

		public Imballo imballo;

		public VarianteImballo(Variante v, Imballo i)
		{
			this.variante = v;
			this.imballo = i;
		}
	}
}