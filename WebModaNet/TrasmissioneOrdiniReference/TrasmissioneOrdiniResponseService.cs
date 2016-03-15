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
	public class TrasmissioneOrdiniResponseService
	{
		private EsitoTrasmissioneService esitoField;

		private string messaggioField;

		private OrdineResponseService[] ordiniField;

		private ClienteResponseService[] clientiField;

		public ClienteResponseService[] Clienti
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

		public EsitoTrasmissioneService Esito
		{
			get
			{
				return this.esitoField;
			}
			set
			{
				this.esitoField = value;
			}
		}

		public string Messaggio
		{
			get
			{
				return this.messaggioField;
			}
			set
			{
				this.messaggioField = value;
			}
		}

		public OrdineResponseService[] Ordini
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

		public TrasmissioneOrdiniResponseService()
		{
		}
	}
}