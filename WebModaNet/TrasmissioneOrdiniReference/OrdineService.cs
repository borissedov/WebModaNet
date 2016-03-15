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
	public class OrdineService
	{
		private string codiceField;

		private string codiceGestionaleField;

		private string codiceUtenteField;

		private int codiceAgenteField;

		private int numeroOrdineField;

		private DateTime dataField;

		private DateTime dataInserimentoField;

		private string codiceClienteField;

		private int idIndirizzoConsegnaField;

		private string codiceMarchioField;

		private int? idTipoOrdineField;

		private string codiceStagioneField;

		private string codiceLineaField;

		private string bancaField;

		private string codiceValutaField;

		private string codiceMetodoPagamentoField;

		private decimal scontoMetodoPagamentoField;

		private string codiceListinoField;

		private int numeroCapiField;

		private decimal totaleField;

		private int? idPortoField;

		private int? idTrasportoField;

		private int? idVettoreField;

		private string noteField;

		private string codiceStatoOrdineField;

		private bool onlineField;

		private DateTime dataConsegnaField;

		private DateTime dataUltimaConsegnaField;

		private DateTime dataDecorrenzaField;

		private string codicePoliticaScontiField;

		private DettaglioOrdineService[] dettagliField;

		public string Banca
		{
			get
			{
				return this.bancaField;
			}
			set
			{
				this.bancaField = value;
			}
		}

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

		public int CodiceAgente
		{
			get
			{
				return this.codiceAgenteField;
			}
			set
			{
				this.codiceAgenteField = value;
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

		public string CodiceLinea
		{
			get
			{
				return this.codiceLineaField;
			}
			set
			{
				this.codiceLineaField = value;
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

		public string CodiceMarchio
		{
			get
			{
				return this.codiceMarchioField;
			}
			set
			{
				this.codiceMarchioField = value;
			}
		}

		public string CodiceMetodoPagamento
		{
			get
			{
				return this.codiceMetodoPagamentoField;
			}
			set
			{
				this.codiceMetodoPagamentoField = value;
			}
		}

		public string CodicePoliticaSconti
		{
			get
			{
				return this.codicePoliticaScontiField;
			}
			set
			{
				this.codicePoliticaScontiField = value;
			}
		}

		public string CodiceStagione
		{
			get
			{
				return this.codiceStagioneField;
			}
			set
			{
				this.codiceStagioneField = value;
			}
		}

		public string CodiceStatoOrdine
		{
			get
			{
				return this.codiceStatoOrdineField;
			}
			set
			{
				this.codiceStatoOrdineField = value;
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

		public string CodiceValuta
		{
			get
			{
				return this.codiceValutaField;
			}
			set
			{
				this.codiceValutaField = value;
			}
		}

		public DateTime Data
		{
			get
			{
				return this.dataField;
			}
			set
			{
				this.dataField = value;
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

		public DateTime DataInserimento
		{
			get
			{
				return this.dataInserimentoField;
			}
			set
			{
				this.dataInserimentoField = value;
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

		public DettaglioOrdineService[] Dettagli
		{
			get
			{
				return this.dettagliField;
			}
			set
			{
				this.dettagliField = value;
			}
		}

		public int IdIndirizzoConsegna
		{
			get
			{
				return this.idIndirizzoConsegnaField;
			}
			set
			{
				this.idIndirizzoConsegnaField = value;
			}
		}

		[XmlElement(IsNullable=true)]
		public int? IdPorto
		{
			get
			{
				return this.idPortoField;
			}
			set
			{
				this.idPortoField = value;
			}
		}

		[XmlElement(IsNullable=true)]
		public int? IdTipoOrdine
		{
			get
			{
				return this.idTipoOrdineField;
			}
			set
			{
				this.idTipoOrdineField = value;
			}
		}

		[XmlElement(IsNullable=true)]
		public int? IdTrasporto
		{
			get
			{
				return this.idTrasportoField;
			}
			set
			{
				this.idTrasportoField = value;
			}
		}

		[XmlElement(IsNullable=true)]
		public int? IdVettore
		{
			get
			{
				return this.idVettoreField;
			}
			set
			{
				this.idVettoreField = value;
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

		public int NumeroOrdine
		{
			get
			{
				return this.numeroOrdineField;
			}
			set
			{
				this.numeroOrdineField = value;
			}
		}

		public bool Online
		{
			get
			{
				return this.onlineField;
			}
			set
			{
				this.onlineField = value;
			}
		}

		public decimal ScontoMetodoPagamento
		{
			get
			{
				return this.scontoMetodoPagamentoField;
			}
			set
			{
				this.scontoMetodoPagamentoField = value;
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

		public OrdineService()
		{
		}
	}
}