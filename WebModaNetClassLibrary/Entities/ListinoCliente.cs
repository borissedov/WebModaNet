using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class ListinoCliente
	{
		public virtual EW.WebModaNetClassLibrary.Entities.Articolo Articolo
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Cliente Cliente
		{
			get;
			set;
		}

		public virtual string CodiceVariante
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

		public virtual int Id
		{
			get;
			set;
		}

		public virtual decimal[] Prezzi
		{
			get
			{
				decimal[] prezzo1 = new decimal[] { this.Prezzo1, this.Prezzo2, this.Prezzo3, this.Prezzo4, this.Prezzo5, this.Prezzo6, this.Prezzo7, this.Prezzo8, this.Prezzo9, this.Prezzo10, this.Prezzo11, this.Prezzo12, this.Prezzo13, this.Prezzo14, this.Prezzo15, this.Prezzo16, this.Prezzo17, this.Prezzo18, this.Prezzo19, this.Prezzo20, this.Prezzo21, this.Prezzo22, this.Prezzo23, this.Prezzo24, this.Prezzo25, this.Prezzo26, this.Prezzo27, this.Prezzo28, this.Prezzo29, this.Prezzo30 };
				return prezzo1;
			}
		}

		protected virtual decimal Prezzo1
		{
			get;
			set;
		}

		protected virtual decimal Prezzo10
		{
			get;
			set;
		}

		protected virtual decimal Prezzo11
		{
			get;
			set;
		}

		protected virtual decimal Prezzo12
		{
			get;
			set;
		}

		protected virtual decimal Prezzo13
		{
			get;
			set;
		}

		protected virtual decimal Prezzo14
		{
			get;
			set;
		}

		protected virtual decimal Prezzo15
		{
			get;
			set;
		}

		protected virtual decimal Prezzo16
		{
			get;
			set;
		}

		protected virtual decimal Prezzo17
		{
			get;
			set;
		}

		protected virtual decimal Prezzo18
		{
			get;
			set;
		}

		protected virtual decimal Prezzo19
		{
			get;
			set;
		}

		protected virtual decimal Prezzo2
		{
			get;
			set;
		}

		protected virtual decimal Prezzo20
		{
			get;
			set;
		}

		protected virtual decimal Prezzo21
		{
			get;
			set;
		}

		protected virtual decimal Prezzo22
		{
			get;
			set;
		}

		protected virtual decimal Prezzo23
		{
			get;
			set;
		}

		protected virtual decimal Prezzo24
		{
			get;
			set;
		}

		protected virtual decimal Prezzo25
		{
			get;
			set;
		}

		protected virtual decimal Prezzo26
		{
			get;
			set;
		}

		protected virtual decimal Prezzo27
		{
			get;
			set;
		}

		protected virtual decimal Prezzo28
		{
			get;
			set;
		}

		protected virtual decimal Prezzo29
		{
			get;
			set;
		}

		protected virtual decimal Prezzo3
		{
			get;
			set;
		}

		protected virtual decimal Prezzo30
		{
			get;
			set;
		}

		protected virtual decimal Prezzo4
		{
			get;
			set;
		}

		protected virtual decimal Prezzo5
		{
			get;
			set;
		}

		protected virtual decimal Prezzo6
		{
			get;
			set;
		}

		protected virtual decimal Prezzo7
		{
			get;
			set;
		}

		protected virtual decimal Prezzo8
		{
			get;
			set;
		}

		protected virtual decimal Prezzo9
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

		public ListinoCliente()
		{
		}
	}
}