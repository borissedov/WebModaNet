using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class Listino
	{
		public virtual EW.WebModaNetClassLibrary.Entities.Articolo Articolo
		{
			get;
			set;
		}

		public virtual string Codice
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

		public Listino()
		{
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			Listino listino = obj as Listino;
			if (listino == null)
			{
				return false;
			}
			if (this.Codice == listino.Codice && this.Articolo == listino.Articolo && this.DataInizioValidita == listino.DataInizioValidita && this.DataFineValidita == listino.DataFineValidita)
			{
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			int hash = 0;
			if (this.Codice != null)
			{
				hash = hash + this.Codice.GetHashCode();
			}
			if (this.Articolo != null)
			{
				hash = hash + this.Articolo.GetHashCode();
			}
			int hashCode = this.DataInizioValidita.GetHashCode();
			DateTime dataFineValidita = this.DataFineValidita;
			hash = hash + hashCode + dataFineValidita.GetHashCode();
			return hash;
		}

		public virtual void SetPrezzi(decimal[] prezzi)
		{
			if (prezzi == null)
			{
				throw new ArgumentNullException("prezzi");
			}
			decimal[] p = new decimal[(int)this.Prezzi.Length];
			for (int i = 0; i < (int)p.Length; i++)
			{
				if (i >= (int)prezzi.Length)
				{
					p[i] = new decimal(0);
				}
				else
				{
					p[i] = prezzi[i];
				}
			}
			this.Prezzo1 = p[0];
			this.Prezzo2 = p[1];
			this.Prezzo3 = p[2];
			this.Prezzo4 = p[3];
			this.Prezzo5 = p[4];
			this.Prezzo6 = p[5];
			this.Prezzo7 = p[6];
			this.Prezzo8 = p[7];
			this.Prezzo9 = p[8];
			this.Prezzo10 = p[9];
			this.Prezzo11 = p[10];
			this.Prezzo12 = p[11];
			this.Prezzo13 = p[12];
			this.Prezzo14 = p[13];
			this.Prezzo15 = p[14];
			this.Prezzo16 = p[15];
			this.Prezzo17 = p[16];
			this.Prezzo18 = p[17];
			this.Prezzo19 = p[18];
			this.Prezzo20 = p[19];
			this.Prezzo21 = p[20];
			this.Prezzo22 = p[21];
			this.Prezzo23 = p[22];
			this.Prezzo24 = p[23];
			this.Prezzo25 = p[24];
			this.Prezzo26 = p[25];
			this.Prezzo27 = p[26];
			this.Prezzo28 = p[27];
			this.Prezzo29 = p[28];
			this.Prezzo30 = p[29];
		}

		public virtual void SetSconti(decimal[] sconti)
		{
			if (sconti == null)
			{
				throw new ArgumentNullException("sconti");
			}
			decimal[] s = new decimal[(int)this.Sconti.Length];
			for (int i = 0; i < (int)s.Length; i++)
			{
				if (i >= (int)sconti.Length)
				{
					s[i] = new decimal(0);
				}
				else
				{
					s[i] = sconti[i];
				}
			}
			this.Sconto1 = s[0];
			this.Sconto2 = s[1];
			this.Sconto3 = s[2];
			this.Sconto4 = s[3];
			this.Sconto5 = s[4];
		}
	}
}