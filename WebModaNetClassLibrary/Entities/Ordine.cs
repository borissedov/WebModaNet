using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class Ordine
	{
		public virtual EW.WebModaNetClassLibrary.Entities.Agente Agente
		{
			get;
			set;
		}

		public virtual string Allegato
		{
			get;
			set;
		}

		public virtual string Banca
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Cliente Cliente
		{
			get;
			set;
		}

		public virtual string Codice
		{
			get;
			set;
		}

		public virtual int CodiceAgente
		{
			get;
			set;
		}

		public virtual string CodiceGestionale
		{
			get;
			set;
		}

		public virtual string CodiceListino
		{
			get;
			set;
		}

		public virtual string CodicePoliticaSconti
		{
			get;
			set;
		}

		public virtual DateTime Data
		{
			get;
			set;
		}

		public virtual DateTime DataConsegna
		{
			get;
			set;
		}

		public virtual DateTime? DataConsegnaManuale
		{
			get;
			set;
		}

		public virtual DateTime DataDecorrenza
		{
			get;
			set;
		}

		public virtual DateTime DataInserimento
		{
			get;
			set;
		}

		public virtual DateTime DataUltimaConsegna
		{
			get;
			set;
		}

		public virtual IList<DettaglioOrdine> Dettagli
		{
			get;
			set;
		}

		public virtual int IdIndirizzoConsegna
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Linea Linea
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Marchio Marchio
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.MetodoPagamento MetodoPagamento
		{
			get;
			set;
		}

		public virtual string NomeFileAllegato
		{
			get
			{
				if (string.IsNullOrEmpty(this.Allegato))
				{
					return null;
				}
				string estensione = string.Empty;
				int posizionePunto = this.Allegato.LastIndexOf(".");
				if (posizionePunto > 0)
				{
					estensione = this.Allegato.Substring(posizionePunto);
				}
				return string.Concat(this.Codice, estensione);
			}
		}

		public virtual string Note
		{
			get;
			set;
		}

		public virtual int NumeroCapi
		{
			get;
			set;
		}

		public virtual int NumeroOrdine
		{
			get;
			set;
		}

		public virtual string NumeroOrdineVisibile
		{
			get
			{
				if (this.Online)
				{
					return string.Concat("O-", this.NumeroOrdine.ToString());
				}
				return string.Concat("F-", this.NumeroOrdine.ToString());
			}
		}

		public virtual bool Online
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Porto Porto
		{
			get;
			set;
		}

		public virtual string RiferimentoOrdine
		{
			get;
			set;
		}

		public virtual decimal ScontoMetodoPagamento
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Stagione Stagione
		{
			get;
			set;
		}

		public virtual StatoOrdine Stato
		{
			get;
			set;
		}

		public virtual TipoOrdine Tipo
		{
			get;
			set;
		}

		public virtual decimal Totale
		{
			get;
			set;
		}

		public virtual decimal TotaleScontato
		{
			get
			{
				return this.Totale - ((this.Totale * this.ScontoMetodoPagamento) / new decimal(100));
			}
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Trasporto Trasporto
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Valuta Valuta
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Vettore Vettore
		{
			get;
			set;
		}

		public Ordine()
		{
		}
	}
}