using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class Provincia
	{
		public virtual string Codice
		{
			get;
			set;
		}

		public virtual string Descrizione
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Nazione Nazione
		{
			get;
			set;
		}

		public Provincia()
		{
		}

		public override string ToString()
		{
			return this.Descrizione;
		}
	}
}