using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class Famiglia
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

		public Famiglia()
		{
		}
	}
}