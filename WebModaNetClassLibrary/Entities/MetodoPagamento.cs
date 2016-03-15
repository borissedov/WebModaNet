using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class MetodoPagamento
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

		public virtual bool FineMese
		{
			get;
			set;
		}

		public virtual decimal Sconto
		{
			get;
			set;
		}

		public MetodoPagamento()
		{
		}

		public override string ToString()
		{
			return string.Concat(this.Codice, " - ", this.Descrizione);
		}
	}
}