using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet.Controls
{
	public class RiepilogoOrdineControl : UserControl
	{
		protected HtmlTableCell intestazioneOperazioni;

		protected Literal CodiciSegnataglieLiteral;

		protected Repeater IntestazioniTaglieRepeater;

		protected HtmlTableCell intestazionePrezzoAcquisto;

		protected Literal litValutaOrdinePR1;

		protected HtmlTableCell intestazioneSconto;

		protected HtmlTableCell intestazionePrezzoNetto;

		protected Literal litValutaOrdinePR2;

		protected HtmlTableCell intestazioneImporto;

		protected Literal litValutaOrdinePR3;

		protected Repeater DettagliRiepilogoRepeater;

		protected HtmlTableCell cellaTotale;

		protected Literal NumeroCapiLiteral;

		protected Literal litValutaOrdinePR4;

		protected Literal TotaleLiteral;

		protected HtmlTableRow rigaSconto;

		protected HtmlTableCell cellaSconto;

		protected Literal PercentualeScontoLiteral;

		protected Literal ImportoScontoLiteral;

		protected HtmlTableRow rigaTotaleNetto;

		protected HtmlTableCell cellaTotaleNetto;

		protected Literal litValutaOrdinePR5;

		protected Literal TotaleNettoLiteral;

		public bool ModalitaStampa
		{
			get
			{
				object item = this.ViewState["ModalitaStampa"];
				if (item == null)
				{
					item = false;
				}
				return (bool)item;
			}
			set
			{
				this.ViewState["ModalitaStampa"] = value;
			}
		}

		public RiepilogoOrdineControl()
		{
		}

		public void CaricaRiepilogoOrdine(Ordine ordine)
		{
			BasePage basePage = this.Page as BasePage;
			RiepilogoOrdine riepilogoOrdine = this.GetRiepilogoOrdine(ordine);
			if (this.ModalitaStampa)
			{
				this.intestazioneOperazioni.Visible = false;
			}
			this.CodiciSegnataglieLiteral.Text = riepilogoOrdine.CodiciSegnataglie;
			this.IntestazioniTaglieRepeater.DataSource = riepilogoOrdine.Taglie;
			this.IntestazioniTaglieRepeater.DataBind();
			this.DettagliRiepilogoRepeater.DataSource = riepilogoOrdine.DettagliRiepilogo;
			this.DettagliRiepilogoRepeater.DataBind();
			this.litValutaOrdinePR1.Text = string.Concat("(", ordine.Valuta.Descrizione, ")");
			this.litValutaOrdinePR2.Text = string.Concat("(", ordine.Valuta.Descrizione, ")");
			this.litValutaOrdinePR3.Text = string.Concat("(", ordine.Valuta.Descrizione, ")");
			this.litValutaOrdinePR4.Text = string.Concat("(", ordine.Valuta.Descrizione, ")");
			this.litValutaOrdinePR5.Text = string.Concat("(", ordine.Valuta.Descrizione, ")");
			int colspan = 4 + riepilogoOrdine.NumeroMassimoColonne;
			if (this.ModalitaStampa)
			{
				colspan = 3 + riepilogoOrdine.NumeroMassimoColonne;
			}
			this.cellaTotale.ColSpan = colspan;
			this.cellaSconto.ColSpan = colspan;
			this.cellaTotaleNetto.ColSpan = colspan;
			this.NumeroCapiLiteral.Text = riepilogoOrdine.NumeroCapi.ToString();
			this.TotaleLiteral.Text = Utils.FormatNumber(riepilogoOrdine.Totale, basePage.AgenteAutenticato);
			if (!(riepilogoOrdine.Sconto > new decimal(0)))
			{
				this.rigaSconto.Visible = false;
			}
			else
			{
				this.PercentualeScontoLiteral.Text = string.Format("{0:0}%", riepilogoOrdine.Sconto);
				this.ImportoScontoLiteral.Text = Utils.FormatNumber((riepilogoOrdine.Totale * riepilogoOrdine.Sconto) / new decimal(100), basePage.AgenteAutenticato);
			}
			this.TotaleNettoLiteral.Text = Utils.FormatNumber(riepilogoOrdine.TotaleScontato, basePage.AgenteAutenticato);
		}

		protected void DettagliRiepilogoRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			DettaglioOrdineRiepilogo dettaglioRiepilogo = item.DataItem as DettaglioOrdineRiepilogo;
			Repeater quantitaRepeater = item.FindControl("QuantitaRepeater") as Repeater;
			Literal prezzoAcquistoLiteral = item.FindControl("PrezzoAcquistoLiteral") as Literal;
			Literal prezzoNettoLiteral = item.FindControl("PrezzoNettoLiteral") as Literal;
			Literal importoLiteral = item.FindControl("ImportoLiteral") as Literal;
			if ((dettaglioRiepilogo == null || quantitaRepeater == null || prezzoAcquistoLiteral == null || prezzoNettoLiteral == null ? false : importoLiteral != null))
			{
				BasePage basePage = this.Page as BasePage;
				quantitaRepeater.DataSource = dettaglioRiepilogo.Quantita;
				quantitaRepeater.DataBind();
				prezzoAcquistoLiteral.Text = Utils.FormatNumber(dettaglioRiepilogo.PrezzoAcquistoSingolo, basePage.AgenteAutenticato);
				prezzoNettoLiteral.Text = Utils.FormatNumber(dettaglioRiepilogo.PrezzoNettoSingolo, basePage.AgenteAutenticato);
				importoLiteral.Text = Utils.FormatNumber(dettaglioRiepilogo.Totale, basePage.AgenteAutenticato);
			}
		}

		public RiepilogoOrdine GetRiepilogoOrdine(Ordine ordine)
		{
			Segnataglie segnataglie;
			bool[] taglieValide;
			int num;
			int j;
			string[] strArrays;
			BasePage basePage = this.Page as BasePage;
			RiepilogoOrdine riepilogoOrdine = new RiepilogoOrdine();
			IList<DettaglioOrdine> dettagliOrdine = basePage.DettaglioOrdineRepository.GetDettagliOrdineFromOrdine(ordine);
			Dictionary<string, string[]> mappaTaglie = new Dictionary<string, string[]>();
			foreach (DettaglioOrdine dettaglioOrdine in dettagliOrdine)
			{
				segnataglie = dettaglioOrdine.Segnataglie;
				string codiceSegnataglie = segnataglie.Codice;
				string[] taglieSegnataglie = segnataglie.Taglie;
				int numeroTaglie = (int)taglieSegnataglie.Length;
				try
				{
					taglieValide = dettaglioOrdine.Variante.Articolo.TaglieValide;
				}
				catch (ObjectNotFoundException objectNotFoundException)
				{
					continue;
				}
				if (!mappaTaglie.ContainsKey(codiceSegnataglie))
				{
					mappaTaglie.Add(codiceSegnataglie, new string[numeroTaglie]);
				}
				for (num = 0; num < numeroTaglie; num++)
				{
					if ((!taglieValide[num] ? false : !string.IsNullOrWhiteSpace(taglieSegnataglie[num])))
					{
						mappaTaglie[codiceSegnataglie][num] = taglieSegnataglie[num];
					}
				}
			}
			int numeroMassimoColonne = mappaTaglie.Max<KeyValuePair<string, string[]>>((KeyValuePair<string, string[]> d) => d.Value.Count<string>((string s) => !string.IsNullOrWhiteSpace(s)));
			riepilogoOrdine.NumeroMassimoColonne = numeroMassimoColonne;
			string[] taglieIntestazione = new string[riepilogoOrdine.NumeroMassimoColonne];
			IList<string[]> listaSegnataglie = (
				from d in mappaTaglie
				select d.Value).ToList<string[]>();
			foreach (string[] segnataglies in listaSegnataglie)
			{
				string[] taglieValides = (
					from s in segnataglies
					where !string.IsNullOrWhiteSpace(s)
					select s).ToArray<string>();
				for (num = 0; num < numeroMassimoColonne; num++)
				{
					if (num >= (int)taglieValides.Length)
					{
						string[] strArrays1 = taglieIntestazione;
						strArrays = strArrays1;
						strArrays1[num] = string.Concat(strArrays[num], "&nbsp;<br />");
					}
					else
					{
						string[] strArrays2 = taglieIntestazione;
						strArrays = strArrays2;
						strArrays2[num] = string.Concat(strArrays[num], taglieValides[num], "<br />");
					}
				}
			}
			taglieIntestazione = (
				from i in taglieIntestazione
				select Regex.Replace(i, "<br />$", string.Empty)).ToArray<string>();
			riepilogoOrdine.Taglie = taglieIntestazione;
			string str = (
				from i in basePage.AgenteAutenticato.ImpostazioniOrdine
				where (i.Marchio != ordine.Marchio ? false : i.TipoOrdine == ordine.Tipo)
				select i.CodiceListinoConsigliato).FirstOrDefault<string>();
			IList<Listino> listiniConsigliati = basePage.ListinoRepository.GetListiniConsigliatiFromOrdine(str, ordine);
			List<DettaglioOrdineRiepilogo> dettagliRiepilogo = new List<DettaglioOrdineRiepilogo>();
			foreach (DettaglioOrdine dettaglioOrdine1 in dettagliOrdine)
			{
				decimal[] prezzi = dettaglioOrdine1.Prezzi;
				decimal[] prezziDistinti = prezzi.Distinct<decimal>().ToArray<decimal>();
				int[] quantita = dettaglioOrdine1.Quantita;
				segnataglie = dettaglioOrdine1.Segnataglie;
				int numeroTaglieSegnataglie = (int)segnataglie.Taglie.Length;
				string[] taglieValideSegnataglie = new string[30];
				if (mappaTaglie.ContainsKey(segnataglie.Codice))
				{
					taglieValideSegnataglie = mappaTaglie[segnataglie.Codice];
				}
				decimal[] prezziConsigliati = new decimal[(int)prezzi.Length];
				Listino listinoConsigliato = null;
				try
				{
					listinoConsigliato = listiniConsigliati.FirstOrDefault<Listino>((Listino l) => l.Articolo == dettaglioOrdine1.Variante.Articolo);
				}
				catch (ObjectNotFoundException objectNotFoundException1)
				{
				}
				if (listinoConsigliato != null)
				{
					prezziConsigliati = listinoConsigliato.Prezzi;
				}
				for (num = 0; num < (int)prezziDistinti.Length; num++)
				{
					List<int> quantitaRiepilogo = new List<int>();
					int numeroCapi = 0;
					List<decimal> prezziConsigliatiRiepilogo = new List<decimal>();
					for (j = 0; j < numeroTaglieSegnataglie; j++)
					{
						if (!string.IsNullOrWhiteSpace(taglieValideSegnataglie[j]))
						{
							if (!(prezziDistinti[num] == prezzi[j]))
							{
								quantitaRiepilogo.Add(0);
							}
							else
							{
								quantitaRiepilogo.Add(quantita[j]);
								numeroCapi = numeroCapi + quantita[j];
								prezziConsigliatiRiepilogo.Add(prezziConsigliati[j]);
							}
						}
					}
					int numeroColonneQuantitaRiepilogo = quantitaRiepilogo.Count;
					if (numeroColonneQuantitaRiepilogo < numeroMassimoColonne)
					{
						for (j = 0; j < numeroMassimoColonne - numeroColonneQuantitaRiepilogo; j++)
						{
							quantitaRiepilogo.Add(0);
						}
					}
					if (numeroCapi > 0)
					{
						DettaglioOrdineRiepilogo dettaglioRiepilogo = new DettaglioOrdineRiepilogo();
						try
						{
							dettaglioRiepilogo.CodiceArticolo = dettaglioOrdine1.Variante.Articolo.Codice;
							dettaglioRiepilogo.DescrizioneArticolo = dettaglioOrdine1.Variante.Articolo.ToString();
							dettaglioRiepilogo.CodiceVariante = dettaglioOrdine1.Variante.Codice;
							dettaglioRiepilogo.DescrizioneVariante = dettaglioOrdine1.Variante.ToString();
							dettaglioRiepilogo.CodiceSegnataglie = segnataglie.Codice;
						}
						catch (ObjectNotFoundException objectNotFoundException2)
						{
						}
						dettaglioRiepilogo.Quantita = quantitaRiepilogo.ToArray();
						dettaglioRiepilogo.NumeroCapi = numeroCapi;
						dettaglioRiepilogo.PrezzoAcquistoSingolo = prezziDistinti[num];
						decimal frazionePrezzo = new decimal(1);
						for (j = 0; j < WebConfigSettings.NumeroMassimoScontiDettaglioOrdine; j++)
						{
							frazionePrezzo = frazionePrezzo * (new decimal(1) - (dettaglioOrdine1.Sconti[j] / new decimal(100)));
						}
						dettaglioRiepilogo.PrezzoNettoSingolo = dettaglioRiepilogo.PrezzoAcquistoSingolo * frazionePrezzo;
						dettaglioRiepilogo.Sconto = new decimal(1) - frazionePrezzo;
						dettaglioRiepilogo.PrezzoConsigliatoSingolo = prezziConsigliatiRiepilogo.FirstOrDefault<decimal>();
						if ((dettaglioRiepilogo.PrezzoConsigliatoSingolo <= new decimal(0) ? true : !(dettaglioRiepilogo.PrezzoAcquistoSingolo > new decimal(0))))
						{
							dettaglioRiepilogo.Markup = new decimal(0);
						}
						else
						{
							dettaglioRiepilogo.Markup = dettaglioRiepilogo.PrezzoConsigliatoSingolo / dettaglioRiepilogo.PrezzoAcquistoSingolo;
						}
						decimal totale = dettaglioRiepilogo.NumeroCapi * dettaglioRiepilogo.PrezzoAcquistoSingolo;
						for (j = 0; j < WebConfigSettings.NumeroMassimoScontiDettaglioOrdine; j++)
						{
							if (dettaglioOrdine1.Sconti[j] > new decimal(0))
							{
								totale = totale - ((totale * dettaglioOrdine1.Sconti[j]) / new decimal(100));
							}
						}
						dettaglioRiepilogo.Totale = Math.Round(totale, basePage.ImpostazioniGenerali.NumeroDecimali, MidpointRounding.AwayFromZero);
						dettaglioRiepilogo.TotaleConsigliato = dettaglioRiepilogo.NumeroCapi * dettaglioRiepilogo.PrezzoConsigliatoSingolo;
						dettaglioRiepilogo.IdDettaglio = dettaglioOrdine1.Id;
						dettagliRiepilogo.Add(dettaglioRiepilogo);
					}
				}
			}
			RiepilogoOrdine riepilogoOrdine1 = riepilogoOrdine;
			riepilogoOrdine1.CodiciSegnataglie = string.Concat(riepilogoOrdine1.CodiciSegnataglie, string.Join("<br />", (
				from d in dettagliRiepilogo
				select d.CodiceSegnataglie).Distinct<string>()));
			riepilogoOrdine.NumeroCapi = dettagliRiepilogo.Sum<DettaglioOrdineRiepilogo>((DettaglioOrdineRiepilogo d) => d.NumeroCapi);
			riepilogoOrdine.TotaleConsigliato = dettagliRiepilogo.Sum<DettaglioOrdineRiepilogo>((DettaglioOrdineRiepilogo d) => d.TotaleConsigliato);
			riepilogoOrdine.Totale = dettagliRiepilogo.Sum<DettaglioOrdineRiepilogo>((DettaglioOrdineRiepilogo d) => d.Totale);
			riepilogoOrdine.Sconto = ordine.ScontoMetodoPagamento;
			riepilogoOrdine.TotaleScontato = riepilogoOrdine.Totale - ((riepilogoOrdine.Totale * riepilogoOrdine.Sconto) / new decimal(100));
			riepilogoOrdine.DettagliRiepilogo = dettagliRiepilogo;
			try
			{
				riepilogoOrdine.MarkupMedio = (
					from d in riepilogoOrdine.DettagliRiepilogo
					where d.Markup > new decimal(0)
					select d).Average<DettaglioOrdineRiepilogo>((DettaglioOrdineRiepilogo d) => d.Markup);
			}
			catch (InvalidOperationException invalidOperationException)
			{
			}
			return riepilogoOrdine;
		}

		protected void Page_Load(object sender, EventArgs e)
		{
		}
	}
}