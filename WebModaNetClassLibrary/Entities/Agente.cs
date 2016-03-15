using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class Agente
	{
		public virtual bool Attivo
		{
			get;
			set;
		}

		public virtual bool BloccoBanca
		{
			get;
			set;
		}

		public virtual bool BloccoDataOrdine
		{
			get;
			set;
		}

		public virtual bool BloccoDateConsegna
		{
			get;
			set;
		}

		public virtual bool BloccoMetodoPagamento
		{
			get;
			set;
		}

		public virtual bool BloccoPorto
		{
			get;
			set;
		}

		public virtual bool BloccoTrasporto
		{
			get;
			set;
		}

		public virtual bool BloccoValuta
		{
			get;
			set;
		}

		public virtual bool BloccoVettore
		{
			get;
			set;
		}

		public virtual int CodiceAgente
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

		public virtual string CodiceUtente
		{
			get;
			set;
		}

		public virtual IList<string> CodiciListino
		{
			get;
			set;
		}

		public virtual DateTime? DataUltimaOperazione
		{
			get;
			set;
		}

		public virtual DateTime? DataUltimoAccesso
		{
			get;
			set;
		}

		public virtual IList<ImpostazioneOrdine> ImpostazioniOrdine
		{
			get;
			set;
		}

		public virtual IList<ImpostazioneStagione> ImpostazioniStagione
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Lingua Lingua
		{
			get;
			set;
		}

		public virtual IList<MetodoPagamento> MetodiPagamento
		{
			get;
			set;
		}

		public virtual MetodoPagamento MetodoPagamentoPredefinito
		{
			get;
			set;
		}

		public virtual bool MostraDisponibilitaIcona
		{
			get;
			set;
		}

		public virtual EW.WebModaNetClassLibrary.Entities.Nazione Nazione
		{
			get;
			set;
		}

		public virtual int NumeroDecimali
		{
			get;
			set;
		}

		public virtual bool Online
		{
			get;
			set;
		}

		public virtual IList<Ordine> Ordini
		{
			get;
			set;
		}

		public virtual string Password
		{
			get;
			set;
		}

		public virtual string RagioneSociale
		{
			get;
			set;
		}

		public virtual TipoAgente Tipo
		{
			get;
			set;
		}

		public virtual bool UtilizzaOffline
		{
			get;
			set;
		}

		public virtual Valuta ValutaPredefinita
		{
			get;
			set;
		}

		public virtual IList<Valuta> Valute
		{
			get;
			set;
		}

		public virtual IList<EW.WebModaNetClassLibrary.Entities.VisibilitaCliente> VisibilitaCliente
		{
			get;
			set;
		}

		public Agente()
		{
		}

		public virtual IList<Marchio> GetMarchi()
		{
			return (
				from m in (
					from i in this.ImpostazioniOrdine
					select i.Marchio).Distinct<Marchio>()
				orderby m.Codice
				select m).ToList<Marchio>();
		}

		public virtual IList<Stagione> GetStagioni()
		{
			return (
				from s in (
					from i in this.ImpostazioniStagione
					select i.Stagione).Distinct<Stagione>()
				orderby s.Codice descending
				select s).ToList<Stagione>();
		}

		public virtual IList<TipoOrdine> GetTipiOrdine()
		{
			return (
				from t in (
					from i in this.ImpostazioniOrdine
					select i.TipoOrdine).Distinct<TipoOrdine>()
				orderby t.Descrizione
				select t).ToList<TipoOrdine>();
		}

		public virtual IList<TipoOrdine> GetTipiOrdine(Marchio marchio)
		{
			return (
				from t in (
					from i in this.ImpostazioniOrdine
					where i.Marchio == marchio
					select i.TipoOrdine).Distinct<TipoOrdine>()
				orderby t.Id
				select t).ToList<TipoOrdine>();
		}

		public virtual bool IsAmministratore(string[] codiciAmministratori)
		{
			return codiciAmministratori.Contains<string>(this.Tipo.Codice);
		}

		public virtual bool IsCliente(string codiceCliente)
		{
			return this.Tipo.Codice.Equals(codiceCliente, StringComparison.OrdinalIgnoreCase);
		}

		public virtual bool IsExpertweb(string codiceExpertweb)
		{
			return this.Tipo.Codice.Equals(codiceExpertweb, StringComparison.OrdinalIgnoreCase);
		}

		public override string ToString()
		{
			return string.Concat(this.CodiceUtente, " - ", this.RagioneSociale);
		}
	}
}