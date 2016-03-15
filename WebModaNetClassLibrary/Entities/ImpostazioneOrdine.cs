using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class ImpostazioneOrdine
	{
		public virtual EW.WebModaNetClassLibrary.Entities.Agente Agente
		{
			get;
			set;
		}

		public virtual string CodiceListinoConsigliato
		{
			get;
			set;
		}

		public virtual int Id
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Marchio Marchio
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.TipoOrdine TipoOrdine
		{
			get;
			set;
		}

		public virtual decimal ValoreMinimoOrdine
		{
			get;
			set;
		}

		public ImpostazioneOrdine()
		{
		}
	}
}