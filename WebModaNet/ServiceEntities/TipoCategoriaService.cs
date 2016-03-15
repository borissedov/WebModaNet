using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class TipoCategoriaService
	{
		public string Descrizione
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}

		public TipoCategoriaService()
		{
		}
	}
}