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
	public class ClienteResponseService
	{
		private string codiceField;

		private string codiceGestionaleField;

		private StatoTrasmissioneService statoField;

		public string Codice
		{
			get
			{
				return this.codiceField;
			}
			set
			{
				this.codiceField = value;
			}
		}

		public string CodiceGestionale
		{
			get
			{
				return this.codiceGestionaleField;
			}
			set
			{
				this.codiceGestionaleField = value;
			}
		}

		public StatoTrasmissioneService Stato
		{
			get
			{
				return this.statoField;
			}
			set
			{
				this.statoField = value;
			}
		}

		public ClienteResponseService()
		{
		}
	}
}