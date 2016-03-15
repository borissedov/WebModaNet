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
	public class TrasmissioneOrdiniRequestService
	{
		private string codiceUtenteField;

		private string hashField;

		private OrdineService[] ordiniField;

		private ClienteService[] clientiField;

		public ClienteService[] Clienti
		{
			get
			{
				return this.clientiField;
			}
			set
			{
				this.clientiField = value;
			}
		}

		public string CodiceUtente
		{
			get
			{
				return this.codiceUtenteField;
			}
			set
			{
				this.codiceUtenteField = value;
			}
		}

		public string Hash
		{
			get
			{
				return this.hashField;
			}
			set
			{
				this.hashField = value;
			}
		}

		public OrdineService[] Ordini
		{
			get
			{
				return this.ordiniField;
			}
			set
			{
				this.ordiniField = value;
			}
		}

		public TrasmissioneOrdiniRequestService()
		{
		}
	}
}