using System;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	[Serializable]
	public class AgenteService
	{
		public bool Attivo
		{
			get;
			set;
		}

		public bool BloccoBanca
		{
			get;
			set;
		}

		public bool BloccoDataOrdine
		{
			get;
			set;
		}

		public bool BloccoDateConsegna
		{
			get;
			set;
		}

		public bool BloccoMetodoPagamento
		{
			get;
			set;
		}

		public bool BloccoPorto
		{
			get;
			set;
		}

		public bool BloccoTrasporto
		{
			get;
			set;
		}

		public bool BloccoValuta
		{
			get;
			set;
		}

		public bool BloccoVettore
		{
			get;
			set;
		}

		public int CodiceAgente
		{
			get;
			set;
		}

		public string CodiceLingua
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

		public string CodiceNazione
		{
			get;
			set;
		}

		public string CodicePoliticaSconti
		{
			get;
			set;
		}

		public string CodiceTipoAgente
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

		public DateTime? DataUltimaOperazione
		{
			get;
			set;
		}

		public DateTime? DataUltimoAccesso
		{
			get;
			set;
		}

		public bool MostraDisponibilitaIcona
		{
			get;
			set;
		}

		public int NumeroDecimali
		{
			get;
			set;
		}

		public bool Online
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

		public string RagioneSociale
		{
			get;
			set;
		}

		public bool UtilizzaOffline
		{
			get;
			set;
		}

		public AgenteService()
		{
		}
	}
}