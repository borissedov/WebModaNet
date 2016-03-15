using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class ArticoloImballoService
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

		public string CodiceVariante
		{
			get;
			set;
		}

		public bool Predefinito
		{
			get;
			set;
		}

		public ArticoloImballoService()
		{
		}
	}
}