using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class GestioneGeneraleImpostazioniOrdini : AdminPage
	{
		protected Literal TitoloLiteral;

		protected Literal MessaggioGestioneGeneraleImpostazioniOrdiniLiteral;

		protected HtmlGenericControl messaggioSuccesso;

		protected Literal MessaggioSuccessoLiteral;

		protected HtmlGenericControl messaggioErrore;

		protected Literal MessaggioErroreLiteral;

		protected HyperLink SelezioneAgentiLink;

		protected HyperLink ImpostazioniOrdiniLink;

		protected HyperLink ImpostazioniStagioniLink;

		protected HyperLink ImpostazioniBlocchiLink;

		protected Literal SelezioneAgentiLiteral;

		protected Literal SelezioneAgentiInfoLiteral;

		protected Label TipoAgenteLabel;

		protected DropDownList TipiAgenteList;

		protected Label MarchioLabel;

		protected DropDownList MarchiList;

		protected HtmlGenericControl nessunAgenteTrovato;

		protected Literal NessunAgenteTrovatoLiteral;

		protected GridView AgentiGridView;

		protected Literal ImpostazioniOrdiniLiteral;

		protected Repeater ImpostazioniOrdiniRepeater;

		protected Button SalvaImpostazioniOrdiniButton;

		protected Literal ImpostazioniStagioniLiteral;

		protected Repeater ImpostazioniStagioniRepeater;

		protected Button SalvaImpostazioniStagioniButton;

		protected Literal ImpostazioniBlocchiLiteral;

		protected CheckBox BloccoMetodoPagamentoCheckBox;

		protected CheckBox BloccoBancaCheckBox;

		protected CheckBox BloccoValutaCheckBox;

		protected CheckBox BloccoPortoCheckBox;

		protected CheckBox BloccoTrasportoCheckBox;

		protected CheckBox BloccoVettoreCheckBox;

		protected CheckBox BloccoDataOrdineCheckBox;

		protected CheckBox BloccoDateConsegnaCheckBox;

		protected Button Button1;

		protected IList<Marchio> marchiLista = new List<Marchio>();

		protected IList<TipoOrdine> tipiOrdineLista = new List<TipoOrdine>();

		protected IList<string> codiciListinoLista = new List<string>();

		protected IList<Stagione> stagioniLista = new List<Stagione>();

		public GestioneGeneraleImpostazioniOrdini()
		{
		}

		private void CaricaAgenti()
		{
			string selectedValue = this.TipiAgenteList.SelectedValue;
			string str = this.MarchiList.SelectedValue;
			List<Expression<Func<Agente, bool>>> filtriAgenti = new List<Expression<Func<Agente, bool>>>();
			if (!string.IsNullOrEmpty(selectedValue))
			{
				filtriAgenti.Add((Agente a) => a.Tipo.Codice == selectedValue);
			}
			filtriAgenti.Add((Agente a) => a.Tipo.Codice != WebConfigSettings.CodiceTipoAgenteExpertweb);
			string ordinamento = string.Empty;
			IList<Agente> agenti = base.AgenteRepository.GetAll(filtriAgenti.ToArray());
			if (!string.IsNullOrEmpty(str))
			{
				agenti = (
					from a in agenti
					where a.ImpostazioniOrdine.Any<ImpostazioneOrdine>((ImpostazioneOrdine i) => i.Marchio.Codice == str)
					select a).ToList<Agente>();
			}
			if (agenti.Count <= 0)
			{
				this.AgentiGridView.Visible = false;
				this.nessunAgenteTrovato.Visible = true;
			}
			else
			{
				this.AgentiGridView.Visible = true;
				this.AgentiGridView.DataSource = agenti;
				this.AgentiGridView.DataBind();
			}
		}

		private void CaricaDatiDropDownList()
		{
			IRepository<Marchio, string> marchioRepository = base.MarchioRepository;
			string[] strArrays = new string[] { "Codice" };
			this.marchiLista = marchioRepository.GetAll(strArrays);
			IRepository<TipoOrdine, int> tipoOrdineRepository = base.TipoOrdineRepository;
			strArrays = new string[] { "Descrizione" };
			this.tipiOrdineLista = tipoOrdineRepository.GetAll(strArrays);
			this.codiciListinoLista = (
				from l in base.ListinoRepository.GetCodiciListino()
				orderby l
				select l).ToList<string>();
			IStagioneRepository stagioneRepository = base.StagioneRepository;
			strArrays = new string[] { "Codice" };
			this.stagioniLista = stagioneRepository.GetAll(strArrays);
		}

		private void CaricaImpostazioniOrdini()
		{
			List<ImpostazioneOrdine> impostazioniOrdine = new List<ImpostazioneOrdine>();
			for (int i = 0; i < WebConfigSettings.NumeroImpostazioniOrdine; i++)
			{
				ImpostazioneOrdine impostazioneOrdine = new ImpostazioneOrdine()
				{
					TipoOrdine = null,
					Marchio = null,
					ValoreMinimoOrdine = new decimal(0),
					CodiceListinoConsigliato = string.Empty
				};
				impostazioniOrdine.Add(impostazioneOrdine);
			}
			this.ImpostazioniOrdiniRepeater.DataSource = impostazioniOrdine;
			this.ImpostazioniOrdiniRepeater.DataBind();
		}

		private void CaricaImpostazioniStagioni()
		{
			List<ImpostazioneStagione> impostazioniStagione = new List<ImpostazioneStagione>();
			for (int i = 0; i < WebConfigSettings.NumeroImpostazioniStagione; i++)
			{
				ImpostazioneStagione impostazioneStagione = new ImpostazioneStagione()
				{
					Stagione = null,
					Disponibilita = false
				};
				impostazioniStagione.Add(impostazioneStagione);
			}
			this.ImpostazioniStagioniRepeater.DataSource = impostazioniStagione;
			this.ImpostazioniStagioniRepeater.DataBind();
		}

		private void CaricaMarchi()
		{
			DropDownList marchiList = this.MarchiList;
			IRepository<Marchio, string> marchioRepository = base.MarchioRepository;
			string[] strArrays = new string[] { "Codice" };
			marchiList.DataSource = marchioRepository.GetAll(strArrays);
			this.MarchiList.DataBind();
		}

		private void CaricaTipiAgente()
		{
			List<Expression<Func<TipoAgente, bool>>> filtriTipiAgente = new List<Expression<Func<TipoAgente, bool>>>()
			{
				(TipoAgente t) => t.Codice != WebConfigSettings.CodiceTipoAgenteExpertweb
			};
			DropDownList tipiAgenteList = this.TipiAgenteList;
			IRepository<TipoAgente, string> tipoAgenteRepository = base.TipoAgenteRepository;
			Expression<Func<TipoAgente, bool>>[] array = filtriTipiAgente.ToArray();
			string[] strArrays = new string[] { "Descrizione" };
			tipiAgenteList.DataSource = tipoAgenteRepository.GetAll(array, strArrays);
			this.TipiAgenteList.DataBind();
		}

		private IList<Agente> GetAgentiSelezionati()
		{
			List<Agente> agentiSelezionati = new List<Agente>();
			foreach (GridViewRow row in this.AgentiGridView.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					CheckBox selezionaAgenteCheckBox = row.FindControl("SelezionaAgenteCheckBox") as CheckBox;
					Literal codiceUtenteLiteral = row.FindControl("CodiceUtenteLiteral") as Literal;
					if ((selezionaAgenteCheckBox == null ? false : codiceUtenteLiteral != null))
					{
						if (selezionaAgenteCheckBox.Checked)
						{
							Agente agente = base.AgenteRepository.GetById(codiceUtenteLiteral.Text);
							if (agente != null)
							{
								agentiSelezionati.Add(agente);
							}
						}
					}
				}
			}
			return agentiSelezionati;
		}

		private IList<ImpostazioneOrdine> GetImpostazioniOrdine()
		{
			List<ImpostazioneOrdine> impostazioniOrdine = new List<ImpostazioneOrdine>();
			foreach (RepeaterItem item in this.ImpostazioniOrdiniRepeater.Items)
			{
				DropDownList marchiList = item.FindControl("MarchiList") as DropDownList;
				DropDownList tipiOrdineList = item.FindControl("TipiOrdineList") as DropDownList;
				DropDownList listiniList = item.FindControl("ListiniList") as DropDownList;
				TextBox valoreMinimoTextBox = item.FindControl("ValoreMinimoTextBox") as TextBox;
				if ((marchiList == null || tipiOrdineList == null || listiniList == null ? false : valoreMinimoTextBox != null))
				{
					string codiceTipoOrdine = tipiOrdineList.SelectedValue;
					string codiceMarchio = marchiList.SelectedValue;
					string codiceListino = listiniList.SelectedValue;
					decimal valoreMinimo = new decimal(0);
					decimal.TryParse(valoreMinimoTextBox.Text, out valoreMinimo);
					if ((string.IsNullOrEmpty(codiceTipoOrdine) || string.IsNullOrEmpty(codiceMarchio) ? false : !string.IsNullOrEmpty(codiceListino)))
					{
						ImpostazioneOrdine impostazioneOrdine = new ImpostazioneOrdine()
						{
							TipoOrdine = base.TipoOrdineRepository.GetById(Convert.ToInt32(codiceTipoOrdine)),
							Marchio = base.MarchioRepository.GetById(codiceMarchio),
							ValoreMinimoOrdine = valoreMinimo,
							CodiceListinoConsigliato = codiceListino
						};
						impostazioniOrdine.Add(impostazioneOrdine);
					}
				}
			}
			return impostazioniOrdine;
		}

		private IList<ImpostazioneStagione> GetImpostazioniStagione()
		{
			List<ImpostazioneStagione> impostazioniStagione = new List<ImpostazioneStagione>();
			foreach (RepeaterItem item in this.ImpostazioniStagioniRepeater.Items)
			{
				DropDownList stagioniDropDownList = item.FindControl("StagioniDropDownList") as DropDownList;
				CheckBox disponibilitaCheckBox = item.FindControl("DisponibilitaCheckBox") as CheckBox;
				if ((stagioniDropDownList == null ? false : disponibilitaCheckBox != null))
				{
					string codiceStagione = stagioniDropDownList.SelectedValue;
					if (!string.IsNullOrEmpty(codiceStagione))
					{
						ImpostazioneStagione impostazioneStagione = new ImpostazioneStagione()
						{
							Stagione = base.StagioneRepository.GetById(codiceStagione),
							Disponibilita = disponibilitaCheckBox.Checked
						};
						impostazioniStagione.Add(impostazioneStagione);
					}
				}
			}
			return impostazioniStagione;
		}

		protected void ImpostazioniOrdiniRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			ImpostazioneOrdine impostazioneOrdine = item.DataItem as ImpostazioneOrdine;
			DropDownList tipiOrdineDropDownList = item.FindControl("TipiOrdineList") as DropDownList;
			DropDownList marchiDropDownList = item.FindControl("MarchiList") as DropDownList;
			DropDownList listiniDropDownList = item.FindControl("ListiniList") as DropDownList;
			if ((impostazioneOrdine == null || tipiOrdineDropDownList == null || marchiDropDownList == null ? false : listiniDropDownList != null))
			{
				tipiOrdineDropDownList.DataSource = this.tipiOrdineLista;
				tipiOrdineDropDownList.DataBind();
				marchiDropDownList.DataSource = this.marchiLista;
				marchiDropDownList.DataBind();
				listiniDropDownList.DataSource = this.codiciListinoLista;
				listiniDropDownList.DataBind();
			}
		}

		protected void ImpostazioniStagioniRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			ImpostazioneStagione impostazioneStagione = item.DataItem as ImpostazioneStagione;
			DropDownList stagioniDropDownList = item.FindControl("StagioniDropDownList") as DropDownList;
			CheckBox disponibilitaCheckBox = item.FindControl("DisponibilitaCheckBox") as CheckBox;
			if ((impostazioneStagione == null || stagioniDropDownList == null ? false : disponibilitaCheckBox != null))
			{
				stagioniDropDownList.DataSource = this.stagioniLista;
				stagioniDropDownList.DataBind();
			}
		}

		protected void MarchiList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CaricaAgenti();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.CaricaDatiDropDownList();
				this.CaricaTipiAgente();
				this.CaricaMarchi();
				this.CaricaAgenti();
				this.CaricaImpostazioniOrdini();
				this.CaricaImpostazioniStagioni();
			}
		}

		protected void SalvaImpostazioniBlocchiButton_Click(object sender, EventArgs e)
		{
			IList<Agente> agentiSelezionati = this.GetAgentiSelezionati();
			if (agentiSelezionati.Count <= 0)
			{
				this.messaggioErrore.Visible = true;
				this.MessaggioErroreLiteral.Text = Resources.NessunAgenteSelezionato;
			}
			else
			{
				foreach (Agente agenteSelezionato in agentiSelezionati)
				{
					agenteSelezionato.BloccoMetodoPagamento = this.BloccoMetodoPagamentoCheckBox.Checked;
					agenteSelezionato.BloccoBanca = this.BloccoBancaCheckBox.Checked;
					agenteSelezionato.BloccoValuta = this.BloccoValutaCheckBox.Checked;
					agenteSelezionato.BloccoPorto = this.BloccoPortoCheckBox.Checked;
					agenteSelezionato.BloccoTrasporto = this.BloccoTrasportoCheckBox.Checked;
					agenteSelezionato.BloccoVettore = this.BloccoVettoreCheckBox.Checked;
					agenteSelezionato.BloccoDataOrdine = this.BloccoDataOrdineCheckBox.Checked;
					agenteSelezionato.BloccoDateConsegna = this.BloccoDateConsegnaCheckBox.Checked;
					base.AgenteRepository.Save(agenteSelezionato);
				}
				this.messaggioSuccesso.Visible = true;
				this.MessaggioSuccessoLiteral.Text = Resources.MessaggioImpostazioniSalvate;
			}
		}

		protected void SalvaImpostazioniOrdiniButton_Click(object sender, EventArgs e)
		{
			IList<Agente> agentiSelezionati = this.GetAgentiSelezionati();
			if (agentiSelezionati.Count <= 0)
			{
				this.messaggioErrore.Visible = true;
				this.MessaggioErroreLiteral.Text = Resources.NessunAgenteSelezionato;
			}
			else
			{
				IList<ImpostazioneOrdine> impostazioniOrdine = this.GetImpostazioniOrdine();
				foreach (Agente agenteSelezionato in agentiSelezionati)
				{
					agenteSelezionato.ImpostazioniOrdine.Clear();
					foreach (ImpostazioneOrdine impostazioneOrdine in impostazioniOrdine)
					{
						IList<ImpostazioneOrdine> impostazioneOrdines = agenteSelezionato.ImpostazioniOrdine;
						ImpostazioneOrdine impostazioneOrdine1 = new ImpostazioneOrdine()
						{
							TipoOrdine = impostazioneOrdine.TipoOrdine,
							Marchio = impostazioneOrdine.Marchio,
							ValoreMinimoOrdine = impostazioneOrdine.ValoreMinimoOrdine,
							CodiceListinoConsigliato = impostazioneOrdine.CodiceListinoConsigliato
						};
						impostazioneOrdines.Add(impostazioneOrdine1);
					}
					base.AgenteRepository.Save(agenteSelezionato);
					this.messaggioSuccesso.Visible = true;
					this.MessaggioSuccessoLiteral.Text = Resources.MessaggioImpostazioniSalvate;
				}
			}
		}

		protected void SalvaImpostazioniStagioniButton_Click(object sender, EventArgs e)
		{
			IList<Agente> agentiSelezionati = this.GetAgentiSelezionati();
			if (agentiSelezionati.Count <= 0)
			{
				this.messaggioErrore.Visible = true;
				this.MessaggioErroreLiteral.Text = Resources.NessunAgenteSelezionato;
			}
			else
			{
				IList<ImpostazioneStagione> impostazioniStagione = this.GetImpostazioniStagione();
				foreach (Agente agenteSelezionato in agentiSelezionati)
				{
					agenteSelezionato.ImpostazioniStagione.Clear();
					foreach (ImpostazioneStagione impostazioneStagione in impostazioniStagione)
					{
						IList<ImpostazioneStagione> impostazioneStagiones = agenteSelezionato.ImpostazioniStagione;
						ImpostazioneStagione impostazioneStagione1 = new ImpostazioneStagione()
						{
							Stagione = impostazioneStagione.Stagione,
							Disponibilita = impostazioneStagione.Disponibilita
						};
						impostazioneStagiones.Add(impostazioneStagione1);
					}
					base.AgenteRepository.Save(agenteSelezionato);
				}
				this.messaggioSuccesso.Visible = true;
				this.MessaggioSuccessoLiteral.Text = Resources.MessaggioImpostazioniSalvate;
			}
		}

		protected void TipiAgenteList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CaricaAgenti();
		}
	}
}