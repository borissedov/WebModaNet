using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class ArticoloCategoria
	{
		public virtual EW.WebModaNetClassLibrary.Entities.Articolo Articolo
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Categoria Categoria
		{
			get;
			set;
		}

		public ArticoloCategoria()
		{
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			ArticoloCategoria articoloCategoria = obj as ArticoloCategoria;
			if (articoloCategoria == null)
			{
				return false;
			}
			if (this.Articolo == articoloCategoria.Articolo && this.Categoria == articoloCategoria.Categoria)
			{
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			int hash = 0;
			if (this.Articolo != null)
			{
				hash = hash + this.Articolo.GetHashCode();
			}
			if (this.Categoria != null)
			{
				hash = hash + this.Categoria.GetHashCode();
			}
			return hash;
		}
	}
}