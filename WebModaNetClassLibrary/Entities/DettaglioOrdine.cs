using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class DettaglioOrdine
	{
		public virtual string CodiceListino
		{
			get;
			set;
		}

		public virtual DateTime DataConsegna
		{
			get;
			set;
		}

		public virtual DateTime DataDecorrenza
		{
			get;
			set;
		}

		public virtual DateTime DataUltimaConsegna
		{
			get;
			set;
		}

		public virtual int Id
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Imballo Imballo
		{
			get;
			set;
		}

		public virtual string Note
		{
			get;
			set;
		}

		public virtual int NumeroCapi
		{
			get;
			set;
		}

		public virtual int NumeroImballi
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Ordine Ordine
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

		public virtual int Progressivo
		{
			get;
			set;
		}

		public virtual int[] Quantita
		{
			get
			{
				int[] quantita1 = new int[] { this.Quantita1, this.Quantita2, this.Quantita3, this.Quantita4, this.Quantita5, this.Quantita6, this.Quantita7, this.Quantita8, this.Quantita9, this.Quantita10, this.Quantita11, this.Quantita12, this.Quantita13, this.Quantita14, this.Quantita15, this.Quantita16, this.Quantita17, this.Quantita18, this.Quantita19, this.Quantita20, this.Quantita21, this.Quantita22, this.Quantita23, this.Quantita24, this.Quantita25, this.Quantita26, this.Quantita27, this.Quantita28, this.Quantita29, this.Quantita30 };
				return quantita1;
			}
		}

		protected virtual int Quantita1
		{
			get;
			set;
		}

		protected virtual int Quantita10
		{
			get;
			set;
		}

		protected virtual int Quantita11
		{
			get;
			set;
		}

		protected virtual int Quantita12
		{
			get;
			set;
		}

		protected virtual int Quantita13
		{
			get;
			set;
		}

		protected virtual int Quantita14
		{
			get;
			set;
		}

		protected virtual int Quantita15
		{
			get;
			set;
		}

		protected virtual int Quantita16
		{
			get;
			set;
		}

		protected virtual int Quantita17
		{
			get;
			set;
		}

		protected virtual int Quantita18
		{
			get;
			set;
		}

		protected virtual int Quantita19
		{
			get;
			set;
		}

		protected virtual int Quantita2
		{
			get;
			set;
		}

		protected virtual int Quantita20
		{
			get;
			set;
		}

		protected virtual int Quantita21
		{
			get;
			set;
		}

		protected virtual int Quantita22
		{
			get;
			set;
		}

		protected virtual int Quantita23
		{
			get;
			set;
		}

		protected virtual int Quantita24
		{
			get;
			set;
		}

		protected virtual int Quantita25
		{
			get;
			set;
		}

		protected virtual int Quantita26
		{
			get;
			set;
		}

		protected virtual int Quantita27
		{
			get;
			set;
		}

		protected virtual int Quantita28
		{
			get;
			set;
		}

		protected virtual int Quantita29
		{
			get;
			set;
		}

		protected virtual int Quantita3
		{
			get;
			set;
		}

		protected virtual int Quantita30
		{
			get;
			set;
		}

		protected virtual int Quantita4
		{
			get;
			set;
		}

		protected virtual int Quantita5
		{
			get;
			set;
		}

		protected virtual int Quantita6
		{
			get;
			set;
		}

		protected virtual int Quantita7
		{
			get;
			set;
		}

		protected virtual int Quantita8
		{
			get;
			set;
		}

		protected virtual int Quantita9
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

		public virtual decimal Sconto1
		{
			get;
			set;
		}

		public virtual decimal Sconto2
		{
			get;
			set;
		}

		public virtual decimal Sconto3
		{
			get;
			set;
		}

		public virtual decimal Sconto4
		{
			get;
			set;
		}

		public virtual decimal Sconto5
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Segnataglie Segnataglie
		{
			get;
			set;
		}

		public virtual decimal Totale
		{
			get;
			set;
		}

		public virtual string UnitaMisura
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Variante Variante
		{
			get;
			set;
		}

		public DettaglioOrdine()
		{
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

		public virtual void SetQuantita(int[] quantita)
		{
			if (quantita == null)
			{
				throw new ArgumentNullException("quantita");
			}
			int[] q = new int[(int)this.Quantita.Length];
			for (int i = 0; i < (int)q.Length; i++)
			{
				if (i >= (int)quantita.Length)
				{
					q[i] = 0;
				}
				else
				{
					q[i] = quantita[i];
				}
			}
			this.Quantita1 = q[0];
			this.Quantita2 = q[1];
			this.Quantita3 = q[2];
			this.Quantita4 = q[3];
			this.Quantita5 = q[4];
			this.Quantita6 = q[5];
			this.Quantita7 = q[6];
			this.Quantita8 = q[7];
			this.Quantita9 = q[8];
			this.Quantita10 = q[9];
			this.Quantita11 = q[10];
			this.Quantita12 = q[11];
			this.Quantita13 = q[12];
			this.Quantita14 = q[13];
			this.Quantita15 = q[14];
			this.Quantita16 = q[15];
			this.Quantita17 = q[16];
			this.Quantita18 = q[17];
			this.Quantita19 = q[18];
			this.Quantita20 = q[19];
			this.Quantita21 = q[20];
			this.Quantita22 = q[21];
			this.Quantita23 = q[22];
			this.Quantita24 = q[23];
			this.Quantita25 = q[24];
			this.Quantita26 = q[25];
			this.Quantita27 = q[26];
			this.Quantita28 = q[27];
			this.Quantita29 = q[28];
			this.Quantita30 = q[29];
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
		}

		public virtual void SetSconti(IList<decimal> scontiVariante, IList<decimal> scontiPolitiche, int max)
		{
			decimal[] s = new decimal[5];
			int i = 0;
			foreach (decimal d in scontiVariante)
			{
				if (i >= max)
				{
					continue;
				}
				int num = i;
				i = num + 1;
				s[num] = d;
			}
			foreach (decimal d in scontiPolitiche)
			{
				if (i >= max)
				{
					continue;
				}
				int num1 = i;
				i = num1 + 1;
				s[num1] = d;
			}
			this.Sconto1 = s[0];
			this.Sconto2 = s[1];
			this.Sconto3 = s[2];
			this.Sconto4 = s[3];
			this.Sconto5 = s[4];
		}
	}
}