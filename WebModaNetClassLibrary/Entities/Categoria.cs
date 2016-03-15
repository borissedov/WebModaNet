using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class Categoria
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

		public virtual TipoCategoria Tipo
		{
			get;
			set;
		}

		public Categoria()
		{
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			Categoria categoria = obj as Categoria;
			if (categoria == null)
			{
				return false;
			}
			if (this.Codice == categoria.Codice && this.Tipo == categoria.Tipo)
			{
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			int hash = 0;
			if (this.Codice != null)
			{
				hash = hash + this.Codice.GetHashCode();
			}
			if (this.Tipo != null)
			{
				hash = hash + this.Tipo.GetHashCode();
			}
			return hash;
		}
	}
}