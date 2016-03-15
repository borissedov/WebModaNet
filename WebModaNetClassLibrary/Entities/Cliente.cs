using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class Cliente
	{
		public virtual int Abi
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Agente Agente
		{
			get;
			set;
		}

		public virtual bool Attivo
		{
			get;
			set;
		}

		public virtual string Banca
		{
			get;
			set;
		}

		public virtual int Cab
		{
			get;
			set;
		}

		public virtual string CapSedeLegale
		{
			get;
			set;
		}

		public virtual string Cellulare
		{
			get;
			set;
		}

		public virtual string CittaSedeLegale1
		{
			get;
			set;
		}

		public virtual string CittaSedeLegale2
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

		public virtual string CodiceCategoria
		{
			get;
			set;
		}

		public virtual string CodiceFiscale
		{
			get;
			set;
		}

		public virtual string CodiceGestionale
		{
			get;
			set;
		}

		public virtual string CodiceListinoPredefinito
		{
			get;
			set;
		}

		public virtual string CodicePoliticaSconti
		{
			get;
			set;
		}

		public virtual int CodiceSituazione
		{
			get;
			set;
		}

		public virtual string CodiceTipologiaCommerciale
		{
			get;
			set;
		}

		public virtual string CodiceZona
		{
			get;
			set;
		}

		public virtual string Descrizione
		{
			get
			{
				return this.ToString();
			}
		}

		public virtual string DescrizioneCommerciale
		{
			get;
			set;
		}

		public virtual string Email
		{
			get;
			set;
		}

		public virtual string EmailCommerciale
		{
			get;
			set;
		}

		public virtual string Fax
		{
			get;
			set;
		}

		public virtual string Iban
		{
			get;
			set;
		}

		public virtual int IdCommerciale
		{
			get;
			set;
		}

		public virtual IList<Indirizzo> Indirizzi
		{
			get;
			set;
		}

		public virtual bool Insoluto
		{
			get;
			set;
		}

		public virtual MetodoPagamento MetodoPagamentoPredefinito
		{
			get;
			set;
		}

		public virtual Nazione NazioneSedeLegale
		{
			get;
			set;
		}

		public virtual string PartitaIva
		{
			get;
			set;
		}

		public virtual Porto PortoPredefinito
		{
			get;
			set;
		}

		public virtual Provincia ProvinciaSedeLegale
		{
			get;
			set;
		}

		public virtual string RagioneSociale
		{
			get
			{
				string ragioneSociale = this.RagioneSociale1;
				if (!string.IsNullOrEmpty(this.RagioneSociale2))
				{
					ragioneSociale = string.Concat(ragioneSociale, " ", this.RagioneSociale2);
				}
				return ragioneSociale;
			}
		}

		public virtual string RagioneSociale1
		{
			get;
			set;
		}

		public virtual string RagioneSociale2
		{
			get;
			set;
		}

		public virtual int Rating
		{
			get;
			set;
		}

		public virtual string Referente
		{
			get;
			set;
		}

		public virtual StatoCliente Stato
		{
			get;
			set;
		}

		public virtual string TelCommerciale
		{
			get;
			set;
		}

		public virtual string TelCommerciale2
		{
			get;
			set;
		}

		public virtual string Telefono
		{
			get;
			set;
		}

		public virtual Trasporto TrasportoPredefinito
		{
			get;
			set;
		}

		public virtual Valuta ValutaPredefinita
		{
			get;
			set;
		}

		public virtual Vettore VettorePredefinito
		{
			get;
			set;
		}

		public virtual string ViaSedeLegale1
		{
			get;
			set;
		}

		public virtual string ViaSedeLegale2
		{
			get;
			set;
		}

		public Cliente()
		{
		}

		public virtual Indirizzo GetIndirizzoPredefinito()
		{
			Indirizzo indirizzo = this.Indirizzi.FirstOrDefault<Indirizzo>((Indirizzo i) => i.Predefinito) ?? this.GetIndirizzoSedeLegale();
			return indirizzo;
		}

		public virtual Indirizzo GetIndirizzoSedeLegale()
		{
			Indirizzo indirizzo = new Indirizzo()
			{
				Id = 0,
				RagioneSociale1 = this.RagioneSociale1,
				RagioneSociale2 = this.RagioneSociale2,
				Via1 = this.ViaSedeLegale1,
				Via2 = this.ViaSedeLegale2,
				Cap = this.CapSedeLegale,
				Citta1 = this.CittaSedeLegale1,
				Citta2 = this.CittaSedeLegale2,
				Provincia = this.ProvinciaSedeLegale,
				Nazione = this.NazioneSedeLegale
			};
			return indirizzo;
		}

		public virtual bool IsBloccato()
		{
			if (this.CodiceSituazione == 1 || this.CodiceSituazione == 6)
			{
				return true;
			}
			return this.CodiceSituazione == 7;
		}

		public virtual void SetIndirizzoSedeLegale(Indirizzo indirizzo)
		{
			this.ViaSedeLegale1 = indirizzo.Via1;
			this.ViaSedeLegale2 = indirizzo.Via2;
			this.CapSedeLegale = indirizzo.Cap;
			this.CittaSedeLegale1 = indirizzo.Citta1;
			this.CittaSedeLegale2 = indirizzo.Citta2;
			this.ProvinciaSedeLegale = indirizzo.Provincia;
			this.NazioneSedeLegale = indirizzo.Nazione;
		}

		public override string ToString()
		{
			return string.Concat(this.Codice, " - ", this.RagioneSociale);
		}
	}
}