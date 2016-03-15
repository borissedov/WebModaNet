using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class Marchio
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

		public virtual string DescrizioneCompleta
		{
			get
			{
				return this.ToString();
			}
		}

		public Marchio()
		{
		}

		public override string ToString()
		{
			return string.Concat(this.Codice, " - ", this.Descrizione);
		}
	}
}