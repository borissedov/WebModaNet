using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class Segnataglie
	{
		public virtual string Codice
		{
			get;
			set;
		}

		public virtual string Taglia1
		{
			get;
			set;
		}

		public virtual string Taglia10
		{
			get;
			set;
		}

		public virtual string Taglia11
		{
			get;
			set;
		}

		public virtual string Taglia12
		{
			get;
			set;
		}

		public virtual string Taglia13
		{
			get;
			set;
		}

		public virtual string Taglia14
		{
			get;
			set;
		}

		public virtual string Taglia15
		{
			get;
			set;
		}

		public virtual string Taglia16
		{
			get;
			set;
		}

		public virtual string Taglia17
		{
			get;
			set;
		}

		public virtual string Taglia18
		{
			get;
			set;
		}

		public virtual string Taglia19
		{
			get;
			set;
		}

		public virtual string Taglia2
		{
			get;
			set;
		}

		public virtual string Taglia20
		{
			get;
			set;
		}

		public virtual string Taglia21
		{
			get;
			set;
		}

		public virtual string Taglia22
		{
			get;
			set;
		}

		public virtual string Taglia23
		{
			get;
			set;
		}

		public virtual string Taglia24
		{
			get;
			set;
		}

		public virtual string Taglia25
		{
			get;
			set;
		}

		public virtual string Taglia26
		{
			get;
			set;
		}

		public virtual string Taglia27
		{
			get;
			set;
		}

		public virtual string Taglia28
		{
			get;
			set;
		}

		public virtual string Taglia29
		{
			get;
			set;
		}

		public virtual string Taglia3
		{
			get;
			set;
		}

		public virtual string Taglia30
		{
			get;
			set;
		}

		public virtual string Taglia4
		{
			get;
			set;
		}

		public virtual string Taglia5
		{
			get;
			set;
		}

		public virtual string Taglia6
		{
			get;
			set;
		}

		public virtual string Taglia7
		{
			get;
			set;
		}

		public virtual string Taglia8
		{
			get;
			set;
		}

		public virtual string Taglia9
		{
			get;
			set;
		}

		public virtual string[] Taglie
		{
			get
			{
				string[] taglia1 = new string[] { this.Taglia1, this.Taglia2, this.Taglia3, this.Taglia4, this.Taglia5, this.Taglia6, this.Taglia7, this.Taglia8, this.Taglia9, this.Taglia10, this.Taglia11, this.Taglia12, this.Taglia13, this.Taglia14, this.Taglia15, this.Taglia16, this.Taglia17, this.Taglia18, this.Taglia19, this.Taglia20, this.Taglia21, this.Taglia22, this.Taglia23, this.Taglia24, this.Taglia25, this.Taglia26, this.Taglia27, this.Taglia28, this.Taglia29, this.Taglia30 };
				return taglia1;
			}
		}

		public Segnataglie()
		{
		}

		public virtual void SetTaglie(string[] taglie)
		{
			if (taglie == null)
			{
				throw new ArgumentNullException("taglie");
			}
			string[] t = new string[(int)this.Taglie.Length];
			for (int i = 0; i < (int)t.Length; i++)
			{
				if (i >= (int)taglie.Length)
				{
					t[i] = null;
				}
				else
				{
					t[i] = taglie[i];
				}
			}
			this.Taglia1 = t[0];
			this.Taglia2 = t[1];
			this.Taglia3 = t[2];
			this.Taglia4 = t[3];
			this.Taglia5 = t[4];
			this.Taglia6 = t[5];
			this.Taglia7 = t[6];
			this.Taglia8 = t[7];
			this.Taglia9 = t[8];
			this.Taglia10 = t[9];
			this.Taglia11 = t[10];
			this.Taglia12 = t[11];
			this.Taglia13 = t[12];
			this.Taglia14 = t[13];
			this.Taglia15 = t[14];
			this.Taglia16 = t[15];
			this.Taglia17 = t[16];
			this.Taglia18 = t[17];
			this.Taglia19 = t[18];
			this.Taglia20 = t[19];
			this.Taglia21 = t[20];
			this.Taglia22 = t[21];
			this.Taglia23 = t[22];
			this.Taglia24 = t[23];
			this.Taglia25 = t[24];
			this.Taglia26 = t[25];
			this.Taglia27 = t[26];
			this.Taglia28 = t[27];
			this.Taglia29 = t[28];
			this.Taglia30 = t[29];
		}
	}
}