using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class TipoOrdine
	{
		public virtual string Descrizione
		{
			get;
			set;
		}

		public virtual string DescrizioneCompleta
		{
			get
			{
				return this.ToString();
			}
		}

		public virtual int Id
		{
			get;
			set;
		}

		public TipoOrdine()
		{
		}

		public override string ToString()
		{
			return string.Concat(this.Id, " - ", this.Descrizione);
		}
	}
}