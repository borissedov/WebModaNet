using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace EW.WebModaNet.TrasmissioneOrdiniReference
{
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("System.Xml", "4.0.30319.18408")]
	[Serializable]
	[XmlType(Namespace="http://webmodanet.expertweb.info/")]
	public class DettaglioOrdineService
	{
		private int idField;

		private int progressivoField;

		private string codiceOrdineField;

		private string codiceVarianteField;

		private string codiceArticoloField;

		private string codiceSegnataglieField;

		private int[] quantitaField;

		private decimal[] prezziField;

		private decimal[] scontiField;

		private string codiceListinoField;

		private int numeroCapiField;

		private decimal totaleField;

		private string noteField;

		private DateTime dataConsegnaField;

		private DateTime dataUltimaConsegnaField;

		private DateTime dataDecorrenzaField;

		private string codiceImballoField;

		private int numeroImballiField;

		private string unitaMisuraField;

		public string CodiceArticolo
		{
			get
			{
				return this.codiceArticoloField;
			}
			set
			{
				this.codiceArticoloField = value;
			}
		}

		public string CodiceImballo
		{
			get
			{
				return this.codiceImballoField;
			}
			set
			{
				this.codiceImballoField = value;
			}
		}

		public string CodiceListino
		{
			get
			{
				return this.codiceListinoField;
			}
			set
			{
				this.codiceListinoField = value;
			}
		}

		public string CodiceOrdine
		{
			get
			{
				return this.codiceOrdineField;
			}
			set
			{
				this.codiceOrdineField = value;
			}
		}

		public string CodiceSegnataglie
		{
			get
			{
				return this.codiceSegnataglieField;
			}
			set
			{
				this.codiceSegnataglieField = value;
			}
		}

		public string CodiceVariante
		{
			get
			{
				return this.codiceVarianteField;
			}
			set
			{
				this.codiceVarianteField = value;
			}
		}

		public DateTime DataConsegna
		{
			get
			{
				return this.dataConsegnaField;
			}
			set
			{
				this.dataConsegnaField = value;
			}
		}

		public DateTime DataDecorrenza
		{
			get
			{
				return this.dataDecorrenzaField;
			}
			set
			{
				this.dataDecorrenzaField = value;
			}
		}

		public DateTime DataUltimaConsegna
		{
			get
			{
				return this.dataUltimaConsegnaField;
			}
			set
			{
				this.dataUltimaConsegnaField = value;
			}
		}

		public int Id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		public string Note
		{
			get
			{
				return this.noteField;
			}
			set
			{
				this.noteField = value;
			}
		}

		public int NumeroCapi
		{
			get
			{
				return this.numeroCapiField;
			}
			set
			{
				this.numeroCapiField = value;
			}
		}

		public int NumeroImballi
		{
			get
			{
				return this.numeroImballiField;
			}
			set
			{
				this.numeroImballiField = value;
			}
		}

		public decimal[] Prezzi
		{
			get
			{
				return this.prezziField;
			}
			set
			{
				this.prezziField = value;
			}
		}

		public int Progressivo
		{
			get
			{
				return this.progressivoField;
			}
			set
			{
				this.progressivoField = value;
			}
		}

		public int[] Quantita
		{
			get
			{
				return this.quantitaField;
			}
			set
			{
				this.quantitaField = value;
			}
		}

		public decimal[] Sconti
		{
			get
			{
				return this.scontiField;
			}
			set
			{
				this.scontiField = value;
			}
		}

		public decimal Totale
		{
			get
			{
				return this.totaleField;
			}
			set
			{
				this.totaleField = value;
			}
		}

		public string UnitaMisura
		{
			get
			{
				return this.unitaMisuraField;
			}
			set
			{
				this.unitaMisuraField = value;
			}
		}

		public DettaglioOrdineService()
		{
		}
	}
}