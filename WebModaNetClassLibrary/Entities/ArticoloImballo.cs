using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class ArticoloImballo
	{
		public virtual int Id
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Imballo Imballo
		{
			get;
			set;
		}

		public virtual bool Predefinito
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Variante Variante
		{
			get;
			set;
		}

		public ArticoloImballo()
		{
		}
	}
}