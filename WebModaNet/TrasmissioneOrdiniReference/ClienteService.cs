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
	public class ClienteService
	{
		private string codiceField;

		private string codiceUtenteField;

		private int codiceAgenteField;

		private string ragioneSociale1Field;

		private string ragioneSociale2Field;

		private string partitaIvaField;

		private string codiceFiscaleField;

		private bool attivoField;

		private string codiceStatoClienteField;

		private int ratingField;

		private bool insolutoField;

		private string telefonoField;

		private string cellulareField;

		private string faxField;

		private string emailField;

		private string referenteField;

		private string bancaField;

		private int abiField;

		private int cabField;

		private string ibanField;

		private string codiceMetodoPagamentoPredefinitoField;

		private string codiceValutaPredefinitaField;

		private int? idPortoPredefinitoField;

		private int? idTrasportoPredefinitoField;

		private int? idVettorePredefinitoField;

		private string codiceListinoPredefinitoField;

		private string codicePoliticaScontiField;

		private string codiceTipologiaCommercialeField;

		private string codiceCategoriaField;

		private string codiceZonaField;

		private string viaSedeLegale1Field;

		private string viaSedeLegale2Field;

		private string capSedeLegaleField;

		private string cittaSedeLegale1Field;

		private string cittaSedeLegale2Field;

		private string codiceProvinciaSedeLegaleField;

		private string nazioneSedeLegaleField;

		private int codiceSituazioneField;

		private IndirizzoService[] indirizziField;

		public int Abi
		{
			get
			{
				return this.abiField;
			}
			set
			{
				this.abiField = value;
			}
		}

		public bool Attivo
		{
			get
			{
				return this.attivoField;
			}
			set
			{
				this.attivoField = value;
			}
		}

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

		public int Cab
		{
			get
			{
				return this.cabField;
			}
			set
			{
				this.cabField = value;
			}
		}

		public string CapSedeLegale
		{
			get
			{
				return this.capSedeLegaleField;
			}
			set
			{
				this.capSedeLegaleField = value;
			}
		}

		public string Cellulare
		{
			get
			{
				return this.cellulareField;
			}
			set
			{
				this.cellulareField = value;
			}
		}

		public string CittaSedeLegale1
		{
			get
			{
				return this.cittaSedeLegale1Field;
			}
			set
			{
				this.cittaSedeLegale1Field = value;
			}
		}

		public string CittaSedeLegale2
		{
			get
			{
				return this.cittaSedeLegale2Field;
			}
			set
			{
				this.cittaSedeLegale2Field = value;
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

		public string CodiceCategoria
		{
			get
			{
				return this.codiceCategoriaField;
			}
			set
			{
				this.codiceCategoriaField = value;
			}
		}

		public string CodiceFiscale
		{
			get
			{
				return this.codiceFiscaleField;
			}
			set
			{
				this.codiceFiscaleField = value;
			}
		}

		public string CodiceListinoPredefinito
		{
			get
			{
				return this.codiceListinoPredefinitoField;
			}
			set
			{
				this.codiceListinoPredefinitoField = value;
			}
		}

		public string CodiceMetodoPagamentoPredefinito
		{
			get
			{
				return this.codiceMetodoPagamentoPredefinitoField;
			}
			set
			{
				this.codiceMetodoPagamentoPredefinitoField = value;
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

		public string CodiceProvinciaSedeLegale
		{
			get
			{
				return this.codiceProvinciaSedeLegaleField;
			}
			set
			{
				this.codiceProvinciaSedeLegaleField = value;
			}
		}

		public int CodiceSituazione
		{
			get
			{
				return this.codiceSituazioneField;
			}
			set
			{
				this.codiceSituazioneField = value;
			}
		}

		public string CodiceStatoCliente
		{
			get
			{
				return this.codiceStatoClienteField;
			}
			set
			{
				this.codiceStatoClienteField = value;
			}
		}

		public string CodiceTipologiaCommerciale
		{
			get
			{
				return this.codiceTipologiaCommercialeField;
			}
			set
			{
				this.codiceTipologiaCommercialeField = value;
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

		public string CodiceValutaPredefinita
		{
			get
			{
				return this.codiceValutaPredefinitaField;
			}
			set
			{
				this.codiceValutaPredefinitaField = value;
			}
		}

		public string CodiceZona
		{
			get
			{
				return this.codiceZonaField;
			}
			set
			{
				this.codiceZonaField = value;
			}
		}

		public string Email
		{
			get
			{
				return this.emailField;
			}
			set
			{
				this.emailField = value;
			}
		}

		public string Fax
		{
			get
			{
				return this.faxField;
			}
			set
			{
				this.faxField = value;
			}
		}

		public string Iban
		{
			get
			{
				return this.ibanField;
			}
			set
			{
				this.ibanField = value;
			}
		}

		[XmlElement(IsNullable=true)]
		public int? IdPortoPredefinito
		{
			get
			{
				return this.idPortoPredefinitoField;
			}
			set
			{
				this.idPortoPredefinitoField = value;
			}
		}

		[XmlElement(IsNullable=true)]
		public int? IdTrasportoPredefinito
		{
			get
			{
				return this.idTrasportoPredefinitoField;
			}
			set
			{
				this.idTrasportoPredefinitoField = value;
			}
		}

		[XmlElement(IsNullable=true)]
		public int? IdVettorePredefinito
		{
			get
			{
				return this.idVettorePredefinitoField;
			}
			set
			{
				this.idVettorePredefinitoField = value;
			}
		}

		public IndirizzoService[] Indirizzi
		{
			get
			{
				return this.indirizziField;
			}
			set
			{
				this.indirizziField = value;
			}
		}

		public bool Insoluto
		{
			get
			{
				return this.insolutoField;
			}
			set
			{
				this.insolutoField = value;
			}
		}

		public string NazioneSedeLegale
		{
			get
			{
				return this.nazioneSedeLegaleField;
			}
			set
			{
				this.nazioneSedeLegaleField = value;
			}
		}

		public string PartitaIva
		{
			get
			{
				return this.partitaIvaField;
			}
			set
			{
				this.partitaIvaField = value;
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

		public int Rating
		{
			get
			{
				return this.ratingField;
			}
			set
			{
				this.ratingField = value;
			}
		}

		public string Referente
		{
			get
			{
				return this.referenteField;
			}
			set
			{
				this.referenteField = value;
			}
		}

		public string Telefono
		{
			get
			{
				return this.telefonoField;
			}
			set
			{
				this.telefonoField = value;
			}
		}

		public string ViaSedeLegale1
		{
			get
			{
				return this.viaSedeLegale1Field;
			}
			set
			{
				this.viaSedeLegale1Field = value;
			}
		}

		public string ViaSedeLegale2
		{
			get
			{
				return this.viaSedeLegale2Field;
			}
			set
			{
				this.viaSedeLegale2Field = value;
			}
		}

		public ClienteService()
		{
		}
	}
}