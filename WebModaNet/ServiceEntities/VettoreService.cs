using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class VettoreService
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

		public VettoreService()
		{
		}
	}
}