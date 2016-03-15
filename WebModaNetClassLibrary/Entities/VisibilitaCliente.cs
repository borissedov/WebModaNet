using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class VisibilitaCliente
	{
		public virtual EW.WebModaNetClassLibrary.Entities.Cliente Cliente
		{
			get;
			set;
		}

		public virtual int CodiceAgente
		{
			get;
			set;
		}

		public VisibilitaCliente()
		{
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			VisibilitaCliente visibilitaCliente = obj as VisibilitaCliente;
			if (visibilitaCliente == null)
			{
				return false;
			}
			if (this.Cliente == visibilitaCliente.Cliente && this.CodiceAgente == visibilitaCliente.CodiceAgente)
			{
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			int hash = 0;
			if (this.Cliente != null)
			{
				hash = hash + this.Cliente.GetHashCode();
			}
			hash = hash + this.CodiceAgente.GetHashCode();
			return hash;
		}
	}
}