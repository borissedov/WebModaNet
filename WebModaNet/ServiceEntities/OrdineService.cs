using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.ServiceEntities
{
	public class OrdineService
	{
		public string Allegato
		{
			get;
			set;
		}

		public string Banca
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

		public string CodiceCliente
		{
			get;
			set;
		}

		public string CodiceGestionale
		{
			get;
			set;
		}

		public string CodiceLinea
		{
			get;
			set;
		}

		public string CodiceListino
		{
			get;
			set;
		}

		public string CodiceMarchio
		{
			get;
			set;
		}

		public string CodiceMetodoPagamento
		{
			get;
			set;
		}

		public string CodicePoliticaSconti
		{
			get;
			set;
		}

		public string CodiceStagione
		{
			get;
			set;
		}

		public string CodiceStatoOrdine
		{
			get;
			set;
		}

		public string CodiceUtente
		{
			get;
			set;
		}

		public string CodiceValuta
		{
			get;
			set;
		}

		public DateTime Data
		{
			get;
			set;
		}

		public DateTime DataConsegna
		{
			get;
			set;
		}

		public DateTime DataDecorrenza
		{
			get;
			set;
		}

		public DateTime DataInserimento
		{
			get;
			set;
		}

		public DateTime DataUltimaConsegna
		{
			get;
			set;
		}

		public List<DettaglioOrdineService> Dettagli
		{
			get;
			set;
		}

		public int IdIndirizzoConsegna
		{
			get;
			set;
		}

		public int? IdPorto
		{
			get;
			set;
		}

		public int? IdTipoOrdine
		{
			get;
			set;
		}

		public int? IdTrasporto
		{
			get;
			set;
		}

		public int? IdVettore
		{
			get;
			set;
		}

		public string Note
		{
			get;
			set;
		}

		public int NumeroCapi
		{
			get;
			set;
		}

		public int NumeroOrdine
		{
			get;
			set;
		}

		public bool Online
		{
			get;
			set;
		}

		public decimal ScontoMetodoPagamento
		{
			get;
			set;
		}

		public decimal Totale
		{
			get;
			set;
		}

		public OrdineService()
		{
		}
	}
}