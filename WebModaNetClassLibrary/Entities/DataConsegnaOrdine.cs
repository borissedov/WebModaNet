using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class DataConsegnaOrdine
	{
		public virtual DateTime? DataConsegna
		{
			get;
			set;
		}

		public virtual DateTime? DataDecorrenza
		{
			get;
			set;
		}

		public virtual DateTime DataFineOrdine
		{
			get;
			set;
		}

		public virtual DateTime DataInizioOrdine
		{
			get;
			set;
		}

		public virtual DateTime? DataUltimaConsegna
		{
			get;
			set;
		}

		public virtual int Id
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Linea Linea
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Marchio Marchio
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Stagione Stagione
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.TipoOrdine TipoOrdine
		{
			get;
			set;
		}

		public DataConsegnaOrdine()
		{
		}
	}
}