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
	public class IndirizzoService
	{
		private int idField;

		private string codiceClienteField;

		private string ragioneSociale1Field;

		private string ragioneSociale2Field;

		private string via1Field;

		private string via2Field;

		private string capField;

		private string citta1Field;

		private string citta2Field;

		private string codiceProvinciaField;

		private string codiceNazioneField;

		private bool predefinitoField;

		public string Cap
		{
			get
			{
				return this.capField;
			}
			set
			{
				this.capField = value;
			}
		}

		public string Citta1
		{
			get
			{
				return this.citta1Field;
			}
			set
			{
				this.citta1Field = value;
			}
		}

		public string Citta2
		{
			get
			{
				return this.citta2Field;
			}
			set
			{
				this.citta2Field = value;
			}
		}

		public string CodiceCliente
		{
			get
			{
				return this.codiceClienteField;
			}
			set
			{
				this.codiceClienteField = value;
			}
		}

		public string CodiceNazione
		{
			get
			{
				return this.codiceNazioneField;
			}
			set
			{
				this.codiceNazioneField = value;
			}
		}

		public string CodiceProvincia
		{
			get
			{
				return this.codiceProvinciaField;
			}
			set
			{
				this.codiceProvinciaField = value;
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

		public bool Predefinito
		{
			get
			{
				return this.predefinitoField;
			}
			set
			{
				this.predefinitoField = value;
			}
		}

		public string RagioneSociale1
		{
			get
			{
				return this.ragioneSociale1Field;
			}
			set
			{
				this.ragioneSociale1Field = value;
			}
		}

		public string RagioneSociale2
		{
			get
			{
				return this.ragioneSociale2Field;
			}
			set
			{
				this.ragioneSociale2Field = value;
			}
		}

		public string Via1
		{
			get
			{
				return this.via1Field;
			}
			set
			{
				this.via1Field = value;
			}
		}

		public string Via2
		{
			get
			{
				return this.via2Field;
			}
			set
			{
				this.via2Field = value;
			}
		}

		public IndirizzoService()
		{
		}
	}
}