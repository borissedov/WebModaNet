using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class ImpostazioneOrdineService
	{
		public virtual string CodiceListinoConsigliato
		{
			get;
			set;
		}

		public string CodiceMarchio
		{
			get;
			set;
		}

		public string CodiceUtente
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}

		public int? IdTipoOrdine
		{
			get;
			set;
		}

		public virtual decimal ValoreMinimoOrdine
		{
			get;
			set;
		}

		public ImpostazioneOrdineService()
		{
		}
	}
}