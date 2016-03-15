using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class Indirizzo
	{
		public virtual string Cap
		{
			get;
			set;
		}

		public virtual string Citta
		{
			get
			{
				string citta = this.Citta1;
				if (!string.IsNullOrEmpty(this.Citta2))
				{
					citta = string.Concat(citta, " ", this.Citta2);
				}
				return citta;
			}
		}

		public virtual string Citta1
		{
			get;
			set;
		}

		public virtual string Citta2
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Cliente Cliente
		{
			get;
			set;
		}

		public virtual string Descrizione
		{
			get
			{
				return this.ToString();
			}
		}

		public virtual int Id
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Nazione Nazione
		{
			get;
			set;
		}

		public virtual bool? Nuovo
		{
			get;
			set;
		}

		public virtual bool Predefinito
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Provincia Provincia
		{
			get;
			set;
		}

		public virtual string RagioneSociale1
		{
			get;
			set;
		}

		public virtual string RagioneSociale2
		{
			get;
			set;
		}

		public virtual string Via
		{
			get
			{
				string via = this.Via1;
				if (!string.IsNullOrEmpty(this.Via2))
				{
					via = string.Concat(via, " ", this.Via2);
				}
				return via;
			}
		}

		public virtual string Via1
		{
			get;
			set;
		}

		public virtual string Via2
		{
			get;
			set;
		}

		public Indirizzo()
		{
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			Indirizzo indirizzo = obj as Indirizzo;
			if (indirizzo == null)
			{
				return false;
			}
			if (this.Id == indirizzo.Id && this.Cliente == indirizzo.Cliente)
			{
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			int hashCode = this.Id.GetHashCode();
			if (this.Cliente != null)
			{
				hashCode = this.Cliente.GetHashCode();
			}
			return hashCode;
		}

		public override string ToString()
		{
			string provincia = (this.Provincia != null ? this.Provincia.Descrizione : string.Empty);
			string[] ragioneSociale1 = new string[] { this.RagioneSociale1, " ", this.RagioneSociale2, " ", this.Via1, " ", this.Via2, " - ", this.Cap, " ", this.Citta, " (", provincia, ")" };
			return string.Concat(ragioneSociale1);
		}
	}
}