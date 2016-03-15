using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class TipoOrdineService
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

		public TipoOrdineService()
		{
		}
	}
}