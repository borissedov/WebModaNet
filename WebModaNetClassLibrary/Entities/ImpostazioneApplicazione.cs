using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class ImpostazioneApplicazione
	{
		public virtual string Chiave
		{
			get;
			set;
		}

		public virtual string Valore
		{
			get;
			set;
		}

		public ImpostazioneApplicazione()
		{
		}

		public ImpostazioneApplicazione(string chiave, string valore)
		{
			if (string.IsNullOrEmpty(chiave))
			{
				throw new ArgumentException("La chiave non può essere nulla.", "chiave");
			}
			this.Chiave = chiave;
			this.Valore = valore;
		}
	}
}