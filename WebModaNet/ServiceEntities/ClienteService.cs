using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class ClienteService
	{
		public int Abi
		{
			get;
			set;
		}

		public bool Attivo
		{
			get;
			set;
		}

		public string Banca
		{
			get;
			set;
		}

		public int Cab
		{
			get;
			set;
		}

		public string CapSedeLegale
		{
			get;
			set;
		}

		public string Cellulare
		{
			get;
			set;
		}

		public string CittaSedeLegale1
		{
			get;
			set;
		}

		public string CittaSedeLegale2
		{
			get;
			set;
		}

		public string Codice
		{
			get;
			set;
		}

		public int CodiceAgente
		{
			get;
			set;
		}

		public string CodiceCategoria
		{
			get;
			set;
		}

		public string CodiceFiscale
		{
			get;
			set;
		}

		public string CodiceListinoPredefinito
		{
			get;
			set;
		}

		public string CodiceMetodoPagamentoPredefinito
		{
			get;
			set;
		}

		public string CodicePoliticaSconti
		{
			get;
			set;
		}

		public string CodiceProvinciaSedeLegale
		{
			get;
			set;
		}

		public int CodiceSituazione
		{
			get;
			set;
		}

		public string CodiceStatoCliente
		{
			get;
			set;
		}

		public string CodiceTipologiaCommerciale
		{
			get;
			set;
		}

		public string CodiceUtente
		{
			get;
			set;
		}

		public string CodiceValutaPredefinita
		{
			get;
			set;
		}

		public string CodiceZona
		{
			get;
			set;
		}

		public string DescrizioneCommerciale
		{
			get;
			set;
		}

		public string Email
		{
			get;
			set;
		}

		public string EmailCommerciale
		{
			get;
			set;
		}

		public string Fax
		{
			get;
			set;
		}

		public string Iban
		{
			get;
			set;
		}

		public int IdCommerciale
		{
			get;
			set;
		}

		public int? IdPortoPredefinito
		{
			get;
			set;
		}

		public int? IdTrasportoPredefinito
		{
			get;
			set;
		}

		public int? IdVettorePredefinito
		{
			get;
			set;
		}

		public IndirizzoService[] Indirizzi
		{
			get;
			set;
		}

		public bool Insoluto
		{
			get;
			set;
		}

		public string NazioneSedeLegale
		{
			get;
			set;
		}

		public string PartitaIva
		{
			get;
			set;
		}

		public string RagioneSociale1
		{
			get;
			set;
		}

		public string RagioneSociale2
		{
			get;
			set;
		}

		public int Rating
		{
			get;
			set;
		}

		public string Referente
		{
			get;
			set;
		}

		public string TelCommerciale
		{
			get;
			set;
		}

		public string TelCommerciale2
		{
			get;
			set;
		}

		public string Telefono
		{
			get;
			set;
		}

		public string ViaSedeLegale1
		{
			get;
			set;
		}

		public string ViaSedeLegale2
		{
			get;
			set;
		}

		public ClienteService()
		{
		}
	}
}