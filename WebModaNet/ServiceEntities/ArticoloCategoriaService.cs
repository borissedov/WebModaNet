using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class ArticoloCategoriaService
	{
		public string CodiceArticolo
		{
			get;
			set;
		}

		public string CodiceCategoria
		{
			get;
			set;
		}

		public int IDTipoCategoria
		{
			get;
			set;
		}

		public ArticoloCategoriaService()
		{
		}
	}
}