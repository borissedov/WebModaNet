using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class TrasportoService
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

		public TrasportoService()
		{
		}
	}
}