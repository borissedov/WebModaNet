using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class VisibilitaClienteService
	{
		public virtual int CodiceAgente
		{
			get;
			set;
		}

		public virtual string CodiceCliente
		{
			get;
			set;
		}

		public VisibilitaClienteService()
		{
		}
	}
}