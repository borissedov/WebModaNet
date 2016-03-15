using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class CategoriaService
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

		public virtual int IdTIpoCategoria
		{
			get;
			set;
		}

		public CategoriaService()
		{
		}
	}
}