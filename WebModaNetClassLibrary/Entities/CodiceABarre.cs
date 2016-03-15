using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class CodiceABarre
	{
		public virtual string Codice
		{
			get;
			set;
		}

		public virtual string Taglia
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Variante Variante
		{
			get;
			set;
		}

		public CodiceABarre()
		{
		}
	}
}