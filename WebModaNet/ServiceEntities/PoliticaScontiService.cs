using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class PoliticaScontiService
	{
		public virtual string Codice
		{
			get;
			set;
		}

		public virtual int Criterio
		{
			get;
			set;
		}

		public virtual DateTime DataDecorrenza
		{
			get;
			set;
		}

		public virtual bool FlagCodiceArticolo
		{
			get;
			set;
		}

		public virtual bool FlagCodiceCategoriaCliente
		{
			get;
			set;
		}

		public virtual bool FlagCodiceClasseLogistica
		{
			get;
			set;
		}

		public virtual bool FlagCodiceClasseMerceologica
		{
			get;
			set;
		}

		public virtual bool FlagCodiceCliente
		{
			get;
			set;
		}

		public virtual bool FlagCodiceFamiglia
		{
			get;
			set;
		}

		public virtual bool FlagCodiceListino
		{
			get;
			set;
		}

		public virtual bool FlagCodiceMarchio
		{
			get;
			set;
		}

		public virtual bool FlagCodiceMetodoPagamento
		{
			get;
			set;
		}

		public virtual bool FlagCodiceTipologiaCommerciale
		{
			get;
			set;
		}

		public virtual bool FlagCodiceZona
		{
			get;
			set;
		}

		public virtual int Id
		{
			get;
			set;
		}

		public virtual int Priorita
		{
			get;
			set;
		}

		public PoliticaScontiService()
		{
		}
	}
}