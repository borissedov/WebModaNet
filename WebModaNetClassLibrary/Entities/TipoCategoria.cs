using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class TipoCategoria
	{
		public virtual string Descrizione
		{
			get;
			set;
		}

		public virtual int Id
		{
			get;
			set;
		}

		public TipoCategoria()
		{
		}
	}
}