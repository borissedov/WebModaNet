using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class CodiceABarreService
	{
		public string Codice
		{
			get;
			set;
		}

		public string CodiceArticolo
		{
			get;
			set;
		}

		public string CodiceVariante
		{
			get;
			set;
		}

		public string Taglia
		{
			get;
			set;
		}

		public CodiceABarreService()
		{
		}
	}
}