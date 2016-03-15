using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class Promozione
	{
		public virtual string CodiceCategoria
		{
			get;
			set;
		}

		public virtual DateTime DataFineValidita
		{
			get;
			set;
		}

		public virtual DateTime DataInizioValidita
		{
			get;
			set;
		}

		public virtual string DescrizioneBreve
		{
			get;
			set;
		}

		public virtual string DescrizioneEstesa
		{
			get;
			set;
		}

		public virtual int Id
		{
			get;
			set;
		}

		public virtual int IdTipoCategoria
		{
			get;
			set;
		}

		public virtual string NomeImmagine
		{
			get;
			set;
		}

		public virtual int Posizione
		{
			get;
			set;
		}

		public virtual string Url
		{
			get;
			set;
		}

		public Promozione()
		{
		}
	}
}