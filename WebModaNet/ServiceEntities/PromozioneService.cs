using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class PromozioneService
	{
		public string CodiceCategoria
		{
			get;
			set;
		}

		public DateTime DataFineValidita
		{
			get;
			set;
		}

		public DateTime DataInizioValidita
		{
			get;
			set;
		}

		public string DescrizioneBreve
		{
			get;
			set;
		}

		public string DescrizioneEstesa
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}

		public int IdTipoCategoria
		{
			get;
			set;
		}

		public string NomeImmagine
		{
			get;
			set;
		}

		public int Posizione
		{
			get;
			set;
		}

		public string Url
		{
			get;
			set;
		}

		public PromozioneService()
		{
		}
	}
}