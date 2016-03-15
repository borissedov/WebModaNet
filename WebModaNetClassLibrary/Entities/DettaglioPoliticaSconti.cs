using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class DettaglioPoliticaSconti
	{
		public virtual string Codice
		{
			get;
			set;
		}

		public virtual string CodiceArticolo
		{
			get;
			set;
		}

		public virtual string CodiceCategoriaCliente
		{
			get;
			set;
		}

		public virtual string CodiceClasseLogistica
		{
			get;
			set;
		}

		public virtual string CodiceClasseMerceologica
		{
			get;
			set;
		}

		public virtual string CodiceCliente
		{
			get;
			set;
		}

		public virtual string CodiceFamiglia
		{
			get;
			set;
		}

		public virtual string CodiceListino
		{
			get;
			set;
		}

		public virtual string CodiceMarchio
		{
			get;
			set;
		}

		public virtual string CodiceMetodoPagamento
		{
			get;
			set;
		}

		public virtual string CodiceTipologiaCommerciale
		{
			get;
			set;
		}

		public virtual string CodiceZona
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

		public virtual DateTime DataScadenza
		{
			get;
			set;
		}

		public virtual string Descrizione
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

		public virtual int Progressivo
		{
			get;
			set;
		}

		public virtual decimal[] Sconti
		{
			get
			{
				decimal[] sconto1 = new decimal[] { this.Sconto1, this.Sconto2, this.Sconto3, this.Sconto4, this.Sconto5 };
				return sconto1;
			}
		}

		protected virtual decimal Sconto1
		{
			get;
			set;
		}

		protected virtual decimal Sconto2
		{
			get;
			set;
		}

		protected virtual decimal Sconto3
		{
			get;
			set;
		}

		protected virtual decimal Sconto4
		{
			get;
			set;
		}

		protected virtual decimal Sconto5
		{
			get;
			set;
		}

		public DettaglioPoliticaSconti()
		{
		}
	}
}