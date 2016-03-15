using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class Variante
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

		public virtual string Descrizione
		{
			get;
			set;
		}

		public virtual string DescrizioneCompleta
		{
			get
			{
				return this.ToString();
			}
		}

		public virtual IList<Imballo> Imballi
		{
			get;
			set;
		}

		public virtual bool? InEsaurimento
		{
			get;
			set;
		}

		protected virtual string nota1
		{
			get;
			set;
		}

		protected virtual string nota10
		{
			get;
			set;
		}

		protected virtual string nota11
		{
			get;
			set;
		}

		protected virtual string nota12
		{
			get;
			set;
		}

		protected virtual string nota13
		{
			get;
			set;
		}

		protected virtual string nota14
		{
			get;
			set;
		}

		protected virtual string nota15
		{
			get;
			set;
		}

		protected virtual string nota16
		{
			get;
			set;
		}

		protected virtual string nota17
		{
			get;
			set;
		}

		protected virtual string nota18
		{
			get;
			set;
		}

		protected virtual string nota19
		{
			get;
			set;
		}

		protected virtual string nota2
		{
			get;
			set;
		}

		protected virtual string nota20
		{
			get;
			set;
		}

		protected virtual string nota21
		{
			get;
			set;
		}

		protected virtual string nota22
		{
			get;
			set;
		}

		protected virtual string nota23
		{
			get;
			set;
		}

		protected virtual string nota24
		{
			get;
			set;
		}

		protected virtual string nota25
		{
			get;
			set;
		}

		protected virtual string nota26
		{
			get;
			set;
		}

		protected virtual string nota27
		{
			get;
			set;
		}

		protected virtual string nota28
		{
			get;
			set;
		}

		protected virtual string nota29
		{
			get;
			set;
		}

		protected virtual string nota3
		{
			get;
			set;
		}

		protected virtual string nota30
		{
			get;
			set;
		}

		protected virtual string nota4
		{
			get;
			set;
		}

		protected virtual string nota5
		{
			get;
			set;
		}

		protected virtual string nota6
		{
			get;
			set;
		}

		protected virtual string nota7
		{
			get;
			set;
		}

		protected virtual string nota8
		{
			get;
			set;
		}

		protected virtual string nota9
		{
			get;
			set;
		}

		public virtual string[] Note
		{
			get
			{
				string[] strArrays = new string[] { this.nota1, this.nota2, this.nota3, this.nota4, this.nota5, this.nota6, this.nota7, this.nota8, this.nota9, this.nota10, this.nota11, this.nota12, this.nota13, this.nota14, this.nota15, this.nota16, this.nota17, this.nota18, this.nota19, this.nota20, this.nota21, this.nota22, this.nota23, this.nota24, this.nota25, this.nota26, this.nota27, this.nota28, this.nota29, this.nota30 };
				return strArrays;
			}
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

		public Variante()
		{
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			Variante variante = obj as Variante;
			if (variante == null)
			{
				return false;
			}
			if (this.Codice == variante.Codice && this.Articolo == variante.Articolo)
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
			return hash;
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
				if (i < (int)quantita.Length)
				{
					q[i] = quantita[i];
				}
				else
				{
					q[i] = 0;
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

		public override string ToString()
		{
			return string.Concat(this.Codice, " - ", this.Descrizione);
		}
	}
}