using EW.WebModaNet.Code;
using EW.WebModaNet.Controls;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;
using NHibernate;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class Stampa : ProtectedPage
	{
		protected Literal TitleLiteral;

		protected HtmlForm form1;

		protected HtmlGenericControl ordineNonTrovato;

		protected Literal OrdineNonTrovatoLiteral;

		protected Panel StampaPanel;

		protected ImageButton StampaButton;

		protected Image LogoDittaImage;

		protected Label IndirizzoDittaLabel;

		protected Label TelefonoDittaLabel;

		protected Label FaxDittaLabel;

		protected Label PartitaIvaDittaLabel;

		protected Label SitoWebDittaLabel;

		protected Label EmailLabel;

		protected Literal ClienteLiteral;

		protected Literal DescrizioneClienteLiteral;

		protected Literal IndirizzoSedeLegaleLiteral;

		protected Literal IndirizzoConsegnaLiteral;

		protected Literal IDIndirizzoConsegnaLiteral;

		protected Literal DescrizioneIndirizzoConsegnaLiteral;

		protected Literal TitoloOrdineLiteral;

		protected HtmlGenericControl intestazione;

		protected Literal IntestazioneLiteral;

		protected Literal ValutaLiteral;

		protected Literal MetodoPagamentoLiteral;

		protected Literal PortoLiteral;

		protected Literal TrasportoLiteral;

		protected Literal VettoreLiteral;

		protected Literal RifordineLiteral;

		protected RiepilogoOrdineControl RiepilogoOrdineControl1;

		protected Repeater DateConsegnaRepeater;

		protected Literal CondizioniVenditaLiteral;

		protected Literal RiepilogoFirmaLiteral;

		protected Literal NumeroCapiFirmaLiteral;

		protected Literal litValutaOrdinePR1;

		protected Literal TotaleNettoFirmaLiteral;

		protected Literal PiedeStampaLiteral;

		public Stampa()
		{
		}

		private void CaricaDateConsegna(Ordine ordine)
		{
			List<DettaglioDateConsegna> dettagliDateConsegna = new List<DettaglioDateConsegna>();
			try
			{
				IEnumerable<IGrouping<Stagione, DettaglioOrdine>> gruppiStagione = 
					from d in ordine.Dettagli
					group d by d.Variante.Articolo.Stagione;
				foreach (IGrouping<Stagione, DettaglioOrdine> gruppoStagione in gruppiStagione)
				{
					DettaglioOrdine dettaglioOrdine = gruppoStagione.FirstOrDefault<DettaglioOrdine>();
					if (dettaglioOrdine != null)
					{
						DettaglioDateConsegna dettaglioDateConsegna = new DettaglioDateConsegna()
						{
							DescrizioneMarchio = ordine.Marchio.Descrizione,
							DescrizioneStagione = dettaglioOrdine.Variante.Articolo.Stagione.Descrizione,
							DataConsegna = dettaglioOrdine.DataConsegna,
							DataUltimaConsegna = dettaglioOrdine.DataUltimaConsegna,
							DataDecorrenza = dettaglioOrdine.DataDecorrenza
						};
						dettagliDateConsegna.Add(dettaglioDateConsegna);
					}
				}
			}
			catch (ObjectNotFoundException objectNotFoundException)
			{
			}
			this.DateConsegnaRepeater.DataSource = dettagliDateConsegna;
			this.DateConsegnaRepeater.DataBind();
		}

		private void CaricaStampaOrdine(Ordine ordine)
		{
			this.LogoDittaImage.ImageUrl = string.Concat(WebConfigSettings.LogoImageFolder, "/", base.ImpostazioniGenerali.LogoDitta);
			this.IndirizzoDittaLabel.Text = base.ImpostazioniGenerali.IndirizzoDitta;
			this.TelefonoDittaLabel.Text = base.ImpostazioniGenerali.TelefonoDitta;
			this.FaxDittaLabel.Text = base.ImpostazioniGenerali.FaxDitta;
			this.PartitaIvaDittaLabel.Text = string.Empty;
			this.SitoWebDittaLabel.Text = base.ImpostazioniGenerali.SitoWebDitta;
			this.EmailLabel.Text = base.ImpostazioniGenerali.EmailDitta;
			Cliente cliente = base.ClienteRepository.GetClientePerStampa(ordine);
			this.DescrizioneClienteLiteral.Text = cliente.ToString();
			this.IndirizzoSedeLegaleLiteral.Text = cliente.GetIndirizzoSedeLegale().ToString();
			int idIndirizzo = ordine.IdIndirizzoConsegna;
			if (idIndirizzo != 0)
			{
				Indirizzo indirizzo = base.IndirizzoRepository.GetIndirizzoForCliente(idIndirizzo, cliente);
				if (indirizzo != null)
				{
					this.IDIndirizzoConsegnaLiteral.Text = indirizzo.Id.ToString();
					this.DescrizioneIndirizzoConsegnaLiteral.Text = indirizzo.ToString();
				}
			}
			else
			{
				this.IDIndirizzoConsegnaLiteral.Text = cliente.GetIndirizzoSedeLegale().Id.ToString();
				this.DescrizioneIndirizzoConsegnaLiteral.Text = cliente.GetIndirizzoSedeLegale().ToString();
			}
			this.TitoloOrdineLiteral.Text = string.Format(Resources.PropostaOrdine, ordine.NumeroOrdineVisibile, ordine.Data);
			if (string.IsNullOrEmpty(base.ImpostazioniGenerali.IntestazioneStampa))
			{
				this.intestazione.Visible = false;
			}
			else
			{
				this.IntestazioneLiteral.Text = base.ImpostazioniGenerali.IntestazioneStampa;
			}
			this.ValutaLiteral.Text = ordine.Valuta.Descrizione;
			this.MetodoPagamentoLiteral.Text = ordine.MetodoPagamento.Descrizione;
			this.PortoLiteral.Text = ordine.Porto.Descrizione;
			this.TrasportoLiteral.Text = ordine.Trasporto.Descrizione;
			this.VettoreLiteral.Text = ordine.Vettore.Descrizione;
			this.RifordineLiteral.Text = ordine.RiferimentoOrdine;
			this.RiepilogoOrdineControl1.CaricaRiepilogoOrdine(ordine);
			this.CaricaDateConsegna(ordine);
			this.PiedeStampaLiteral.Text = base.ImpostazioniGenerali.PiedeStampa;
			this.RiepilogoFirmaLiteral.Text = string.Format(Resources.PropostaOrdine, ordine.NumeroOrdineVisibile, ordine.Data);
			this.NumeroCapiFirmaLiteral.Text = ordine.NumeroCapi.ToString();
			this.CondizioniVenditaLiteral.Text = base.ImpostazioniGenerali.CondizioniVendita;
			this.TotaleNettoFirmaLiteral.Text = Utils.FormatNumber(ordine.TotaleScontato, base.AgenteAutenticato);
			this.litValutaOrdinePR1.Text = string.Concat("(", ordine.Valuta.Descrizione, ")");
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			string codiceOrdine = base.Request.QueryString["codice"];
			Ordine ordine = null;
			if (!string.IsNullOrEmpty(codiceOrdine))
			{
				ordine = base.OrdineRepository.GetOrdineForAgente(codiceOrdine, base.AgenteAutenticato);
			}
			if (ordine != null)
			{
				this.StampaPanel.Visible = true;
				this.CaricaStampaOrdine(base.OrdineRepository.GetById(ordine.Codice));
			}
			else
			{
				this.ordineNonTrovato.Visible = true;
				this.OrdineNonTrovatoLiteral.Text = string.Format(Resources.ErroreOrdineNonTrovato, codiceOrdine);
			}
		}
	}
}