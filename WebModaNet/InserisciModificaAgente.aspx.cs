using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class InserisciModificaAgente : AdminPage
	{
		protected Literal TitoloLiteral;

		protected HyperLink TornaIndietroLink;

		protected ValidationSummary MainValidationSummary;

		protected HtmlGenericControl messaggioSuccesso;

		protected Literal MessaggioSuccessoLiteral;

		protected HyperLink ImpostazioniGeneraliLiteralLink;

		protected HyperLink ImpostazioniPredefiniteLink;

		protected HyperLink BlocchiLink;

		protected HyperLink ImpostazioniOrdiniLink;

		protected Literal ImpostazioniGeneraliLiteral;

		protected Label NomeUtenteLabel;

		protected RequiredFieldValidator NomeUtenteValidator;

		protected CustomValidator NomeUtenteCustomValidator;

		protected TextBox NomeUtenteTextBox;

		protected Label RagioneSocialeLabel;

		protected RequiredFieldValidator RagioneSocialeValidator;

		protected TextBox RagioneSocialeTextBox;

		protected Label PasswordLabel;

		protected RequiredFieldValidator PasswordValidator;

		protected TextBox PasswordTextBox;

		protected Label CodiceAgenteLabel;

		protected RequiredFieldValidator CodiceAgenteValidator;

		protected RegularExpressionValidator CodiceAgenteRegexValidator;

		protected TextBox CodiceAgenteTextBox;

		protected Label NazioneLabel;

		protected RequiredFieldValidator NazioneValidator;

		protected DropDownList NazioniList;

		protected Label LinguaLabel;

		protected RequiredFieldValidator LinguaValidator;

		protected DropDownList LingueList;

		protected CheckBox AttivoCheckBox;

		protected Label NumeroDecimaliLabel;

		protected RequiredFieldValidator NumeroDecimaliValidator;

		protected RegularExpressionValidator NumeroDecimaliRegexValidator;

		protected TextBox NumeroDecimaliTextBox;

		protected Label TipoAgenteLabel;

		protected RequiredFieldValidator TipoAgenteValidator;

		protected RadioButtonList TipiAgenteRadio;

		protected CheckBox UtilizzaOfflineCheckBox;

		protected HtmlGenericControl divMostraDisponibilitaIcona;

		protected CheckBox MostraDisponibilitaIconaCheckBox;

		protected Literal ImpostazioniPredefiniteLiteral;

		protected Label ListinoDefaultLabel;

		protected DropDownList ListiniDefaultList;

		protected Label MetodoPagamentoDefaultLabel;

		protected DropDownList MetodiPagamentoDefaultList;

		protected Literal ImpostazioniListini;

		protected Repeater ListiniRepeater;

		protected Literal ImpostazioniValuteLiteral;

		protected Repeater ValuteRepeater;

		protected Literal ImpostazioniMetodiPagamentoLiteral;

		protected Repeater MetodiPagamentoRepeater;

		protected Literal ImpostazioniBlocchiLiteral;

		protected Literal DescrizioneBlocchiLiteral;

		protected CheckBox BloccoMetodoPagamentoCheckBox;

		protected CheckBox BloccoBancaCheckBox;

		protected CheckBox BloccoValutaCheckBox;

		protected CheckBox BloccoPortoCheckBox;

		protected CheckBox BloccoTrasportoCheckBox;

		protected CheckBox BloccoVettoreCheckBox;

		protected CheckBox BloccoDataOrdineCheckBox;

		protected CheckBox BloccoDateConsegnaCheckBox;

		protected Literal ImpostazioniOrdiniLiteral;

		protected Repeater ImpostazioniOrdiniRepeater;

		protected Literal ImpostazioniStagioniLiteral;

		protected Repeater StagioniRepeater;

		protected Button SalvaButton;

		private Agente agenteCorrente;

		private bool agenteRichiesto;

		private IList<TipoOrdine> listaTipiOrdine = new List<TipoOrdine>();

		private IList<Marchio> listaMarchi = new List<Marchio>();

		private IList<string> listaListini = new List<string>();

		private IList<Stagione> listaStagioni = new List<Stagione>();

		private IList<Valuta> listaValute = new List<Valuta>();

		private IList<MetodoPagamento> listaMetodiPagamento = new List<MetodoPagamento>();

		public InserisciModificaAgente()
		{
		}

		private void CaricaCodiciListinoDefault()
		{
			this.ListiniDefaultList.DataSource = base.ListinoRepository.GetCodiciListino();
			this.ListiniDefaultList.DataBind();
		}

		private void CaricaImpostazioniAgente(Agente agente)
		{
			this.CodiceAgenteTextBox.Text = agente.CodiceAgente.ToString();
			this.RagioneSocialeTextBox.Text = agente.RagioneSociale;
			this.NomeUtenteTextBox.Text = agente.CodiceUtente;
			this.NomeUtenteTextBox.Enabled = false;
			this.PasswordTextBox.Text = agente.Password;
			this.TipiAgenteRadio.SelectedValue = agente.Tipo.Codice;
			this.AttivoCheckBox.Checked = agente.Attivo;
			this.NumeroDecimaliTextBox.Text = agente.NumeroDecimali.ToString();
			this.UtilizzaOfflineCheckBox.Checked = agente.UtilizzaOffline;
			this.MostraDisponibilitaIconaCheckBox.Checked = agente.MostraDisponibilitaIcona;
			this.NazioniList.SelectedValue = agente.Nazione.Codice;
			this.LingueList.SelectedValue = agente.Lingua.Codice;
			if (!string.IsNullOrEmpty(agente.CodiceListinoPredefinito))
			{
				this.ListiniDefaultList.SelectedValue = agente.CodiceListinoPredefinito;
			}
			if (agente.MetodoPagamentoPredefinito != null)
			{
				this.MetodiPagamentoDefaultList.SelectedValue = agente.MetodoPagamentoPredefinito.Codice;
			}
			this.BloccoMetodoPagamentoCheckBox.Checked = agente.BloccoMetodoPagamento;
			this.BloccoBancaCheckBox.Checked = agente.BloccoBanca;
			this.BloccoValutaCheckBox.Checked = agente.BloccoValuta;
			this.BloccoPortoCheckBox.Checked = agente.BloccoPorto;
			this.BloccoTrasportoCheckBox.Checked = agente.BloccoTrasporto;
			this.BloccoVettoreCheckBox.Checked = agente.BloccoVettore;
			this.BloccoDataOrdineCheckBox.Checked = agente.BloccoDataOrdine;
			this.BloccoDateConsegnaCheckBox.Checked = agente.BloccoDateConsegna;
		}

		private void CaricaImpostazioniListini()
		{
			int i;
			List<string> listini = new List<string>();
			Agente agente = this.GetAgenteCorrente();
			if (agente != null)
			{
				IList<string> listiniAgente = agente.CodiciListino;
				for (i = 0; i < WebConfigSettings.NumeroImpostazioniListino; i++)
				{
					if (i >= listiniAgente.Count)
					{
						listini.Add(string.Empty);
					}
					else
					{
						listini.Add(listiniAgente[i]);
					}
				}
			}
			else
			{
				for (i = 0; i < WebConfigSettings.NumeroImpostazioniListino; i++)
				{
					listini.Add(string.Empty);
				}
			}
			this.listaListini = base.ListinoRepository.GetCodiciListino().ToList<string>();
			this.ListiniRepeater.DataSource = listini;
			this.ListiniRepeater.DataBind();
		}

		private void CaricaImpostazioniMetodiPagamento()
		{
			int i;
			List<MetodoPagamento> metodiPagamento = new List<MetodoPagamento>();
			Agente agente = this.GetAgenteCorrente();
			if (agente != null)
			{
				IList<MetodoPagamento> metodiPagamentoAgente = agente.MetodiPagamento;
				for (i = 0; i < WebConfigSettings.NumeroImpostazioniMetodoPagamento; i++)
				{
					if (i >= metodiPagamentoAgente.Count)
					{
						MetodoPagamento metodoPagamento = new MetodoPagamento()
						{
							Codice = string.Empty,
							Descrizione = string.Empty
						};
						metodiPagamento.Add(metodoPagamento);
					}
					else
					{
						metodiPagamento.Add(metodiPagamentoAgente[i]);
					}
				}
			}
			else
			{
				for (i = 0; i < WebConfigSettings.NumeroImpostazioniMetodoPagamento; i++)
				{
					MetodoPagamento metodoPagamento1 = new MetodoPagamento()
					{
						Codice = string.Empty,
						Descrizione = string.Empty
					};
					metodiPagamento.Add(metodoPagamento1);
				}
			}
			this.listaMetodiPagamento = base.MetodoPagamentoRepository.FindAll(true, (MetodoPagamento v) => v.Codice, new Expression<Func<MetodoPagamento, bool>>[0]);
			this.MetodiPagamentoRepeater.DataSource = metodiPagamento;
			this.MetodiPagamentoRepeater.DataBind();
		}

		private void CaricaImpostazioniOrdini()
		{
			int i;
			List<ImpostazioneOrdine> impostazioniOrdine = new List<ImpostazioneOrdine>();
			Agente agente = this.GetAgenteCorrente();
			if (agente != null)
			{
				IList<ImpostazioneOrdine> impostazioniAgente = agente.ImpostazioniOrdine;
				for (i = 0; i < WebConfigSettings.NumeroImpostazioniOrdine; i++)
				{
					if (i >= impostazioniAgente.Count)
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
					else
					{
						ImpostazioneOrdine impostazioneOrdine1 = new ImpostazioneOrdine()
						{
							TipoOrdine = impostazioniAgente[i].TipoOrdine,
							Marchio = impostazioniAgente[i].Marchio,
							ValoreMinimoOrdine = impostazioniAgente[i].ValoreMinimoOrdine,
							CodiceListinoConsigliato = impostazioniAgente[i].CodiceListinoConsigliato
						};
						impostazioniOrdine.Add(impostazioneOrdine1);
					}
				}
			}
			else
			{
				for (i = 0; i < WebConfigSettings.NumeroImpostazioniOrdine; i++)
				{
					ImpostazioneOrdine impostazioneOrdine2 = new ImpostazioneOrdine()
					{
						TipoOrdine = null,
						Marchio = null,
						ValoreMinimoOrdine = new decimal(0),
						CodiceListinoConsigliato = string.Empty
					};
					impostazioniOrdine.Add(impostazioneOrdine2);
				}
			}
			this.listaTipiOrdine = base.TipoOrdineRepository.FindAll(true, (TipoOrdine t) => t.Descrizione, new Expression<Func<TipoOrdine, bool>>[0]);
			this.listaMarchi = base.MarchioRepository.FindAll(true, (Marchio m) => m.Codice, new Expression<Func<Marchio, bool>>[0]);
			this.ImpostazioniOrdiniRepeater.DataSource = impostazioniOrdine;
			this.ImpostazioniOrdiniRepeater.DataBind();
		}

		private void CaricaImpostazioniStagioni()
		{
			int i;
			List<ImpostazioneStagione> impostazioniStagione = new List<ImpostazioneStagione>();
			Agente agente = this.GetAgenteCorrente();
			if (agente != null)
			{
				IList<ImpostazioneStagione> impostazioniAgente = agente.ImpostazioniStagione;
				for (i = 0; i < WebConfigSettings.NumeroImpostazioniStagione; i++)
				{
					if (i >= impostazioniAgente.Count)
					{
						ImpostazioneStagione impostazioneStagione = new ImpostazioneStagione()
						{
							Stagione = null,
							Disponibilita = false
						};
						impostazioniStagione.Add(impostazioneStagione);
					}
					else
					{
						ImpostazioneStagione impostazioneStagione1 = new ImpostazioneStagione()
						{
							Stagione = impostazioniAgente[i].Stagione,
							Disponibilita = impostazioniAgente[i].Disponibilita
						};
						impostazioniStagione.Add(impostazioneStagione1);
					}
				}
			}
			else
			{
				for (i = 0; i < WebConfigSettings.NumeroImpostazioniStagione; i++)
				{
					ImpostazioneStagione impostazioneStagione2 = new ImpostazioneStagione()
					{
						Stagione = null,
						Disponibilita = false
					};
					impostazioniStagione.Add(impostazioneStagione2);
				}
			}
			this.listaStagioni = base.StagioneRepository.FindAll(true, (Stagione s) => s.Codice, new Expression<Func<Stagione, bool>>[0]);
			this.StagioniRepeater.DataSource = impostazioniStagione;
			this.StagioniRepeater.DataBind();
		}

		private void CaricaImpostazioniValute()
		{
			int i;
			List<Valuta> valute = new List<Valuta>();
			Agente agente = this.GetAgenteCorrente();
			if (agente != null)
			{
				IList<Valuta> valuteAgente = agente.Valute;
				for (i = 0; i < WebConfigSettings.NumeroImpostazioniValuta; i++)
				{
					if (i >= valuteAgente.Count)
					{
						Valuta valutum = new Valuta()
						{
							Codice = string.Empty,
							Descrizione = string.Empty
						};
						valute.Add(valutum);
					}
					else
					{
						valute.Add(valuteAgente[i]);
					}
				}
			}
			else
			{
				for (i = 0; i < WebConfigSettings.NumeroImpostazioniValuta; i++)
				{
					Valuta valutum1 = new Valuta()
					{
						Codice = string.Empty,
						Descrizione = string.Empty
					};
					valute.Add(valutum1);
				}
			}
			this.listaValute = base.ValutaRepository.FindAll(true, (Valuta v) => v.Codice, new Expression<Func<Valuta, bool>>[0]);
			this.ValuteRepeater.DataSource = valute;
			this.ValuteRepeater.DataBind();
		}

		private void CaricaLingue()
		{
			this.LingueList.DataSource = base.LinguaRepository.FindAll(true, (Lingua l) => l.Codice, new Expression<Func<Lingua, bool>>[0]);
			this.LingueList.DataBind();
		}

		private void CaricaMetodiPagamentoDefault()
		{
			this.MetodiPagamentoDefaultList.DataSource = base.MetodoPagamentoRepository.FindAll(true, (MetodoPagamento m) => m.Codice, new Expression<Func<MetodoPagamento, bool>>[0]);
			this.MetodiPagamentoDefaultList.DataBind();
		}

		private void CaricaNazioni()
		{
			this.NazioniList.DataSource = base.NazioneRepository.FindAll(true, (Nazione n) => n.Descrizione, new Expression<Func<Nazione, bool>>[0]);
			this.NazioniList.DataBind();
		}

		private void CaricaTipiAgente()
		{
			IRepository<TipoAgente, string> tipoAgenteRepository = base.TipoAgenteRepository;
			ParameterExpression parameterExpression = Expression.Parameter(typeof(TipoAgente), "t");
			MemberExpression memberExpression = Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Codice").MethodHandle));
			ParameterExpression[] parameterExpressionArray = new ParameterExpression[] { parameterExpression };
			Expression<Func<TipoAgente, object>> expression = Expression.Lambda<Func<TipoAgente, object>>(memberExpression, parameterExpressionArray);
			Expression<Func<TipoAgente, bool>>[] expressionArray = new Expression<Func<TipoAgente, bool>>[1];
			parameterExpression = Expression.Parameter(typeof(TipoAgente), "t");
			BinaryExpression binaryExpression = Expression.NotEqual(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceTipoAgenteExpertweb").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Inequality", new Type[] { typeof(string), typeof(string) }).MethodHandle));
			parameterExpressionArray = new ParameterExpression[] { parameterExpression };
			expressionArray[0] = Expression.Lambda<Func<TipoAgente, bool>>(binaryExpression, parameterExpressionArray);
			IList<TipoAgente> tipiAgente = tipoAgenteRepository.FindAll(true, expression, expressionArray);
			this.TipiAgenteRadio.DataSource = tipiAgente;
			this.TipiAgenteRadio.DataBind();
		}

		private Agente GetAgenteCorrente()
		{
			Agente agente;
			if (!this.agenteRichiesto)
			{
				this.agenteRichiesto = true;
				string codiceAgente = base.Request.QueryString["codiceAgente"];
				if (!string.IsNullOrEmpty(codiceAgente))
				{
					this.agenteCorrente = base.AgenteRepository.GetById(codiceAgente);
					if (this.agenteCorrente == null)
					{
						throw new Exception(string.Format(Resources.ErroreAgenteNonTrovato, codiceAgente));
					}
					agente = this.agenteCorrente;
				}
				else
				{
					IAgenteRepository agenteRepository = base.AgenteRepository;
					Expression<Func<Agente, bool>>[] expressionArray = new Expression<Func<Agente, bool>>[1];
					ParameterExpression parameterExpression = Expression.Parameter(typeof(Agente), "a");
					BinaryExpression binaryExpression = Expression.OrElse(Expression.OrElse(Expression.OrElse(Expression.Equal(Expression.Property(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_Tipo").MethodHandle)), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceTipoAgenteAmministratore").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Equality", new Type[] { typeof(string), typeof(string) }).MethodHandle)), Expression.Equal(Expression.Property(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_Tipo").MethodHandle)), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceTipoAgenteAgente").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Equality", new Type[] { typeof(string), typeof(string) }).MethodHandle))), Expression.Equal(Expression.Property(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_Tipo").MethodHandle)), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceTipoAgenteCapoArea").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Equality", new Type[] { typeof(string), typeof(string) }).MethodHandle))), Expression.Equal(Expression.Property(Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(Agente).GetMethod("get_Tipo").MethodHandle)), (MethodInfo)MethodBase.GetMethodFromHandle(typeof(TipoAgente).GetMethod("get_Codice").MethodHandle)), Expression.Property(null, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(WebConfigSettings).GetMethod("get_CodiceTipoAgenteCliente").MethodHandle)), false, (MethodInfo)MethodBase.GetMethodFromHandle(typeof(string).GetMethod("op_Equality", new Type[] { typeof(string), typeof(string) }).MethodHandle)));
					ParameterExpression[] parameterExpressionArray = new ParameterExpression[] { parameterExpression };
					expressionArray[0] = Expression.Lambda<Func<Agente, bool>>(binaryExpression, parameterExpressionArray);
					if (agenteRepository.CountAll(expressionArray) >= base.ImpostazioniGenerali.NumeroMassimoUtenti)
					{
						throw new Exception(Resources.ErroreLicenze);
					}
					agente = null;
				}
			}
			else
			{
				agente = this.agenteCorrente;
			}
			return agente;
		}

		protected void ImpostazioniOrdiniRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			ImpostazioneOrdine impostazione = item.DataItem as ImpostazioneOrdine;
			HtmlTableRow row = item.FindControl("rigaImpostazioneOrdine") as HtmlTableRow;
			DropDownList tipiOrdine = item.FindControl("TipiOrdineList") as DropDownList;
			DropDownList marchi = item.FindControl("MarchiList") as DropDownList;
			DropDownList listini = item.FindControl("ListiniList") as DropDownList;
			if ((impostazione == null || row == null || tipiOrdine == null || marchi == null ? false : listini != null))
			{
				if (item.ItemIndex % 2 != 0)
				{
					row.Attributes["class"] = "alternate";
				}
				tipiOrdine.DataSource = this.listaTipiOrdine;
				tipiOrdine.DataBind();
				marchi.DataSource = this.listaMarchi;
				marchi.DataBind();
				listini.DataSource = this.listaListini;
				listini.DataBind();
				if ((impostazione.TipoOrdine == null || impostazione.Marchio == null ? false : !string.IsNullOrEmpty(impostazione.CodiceListinoConsigliato)))
				{
					tipiOrdine.SelectedValue = impostazione.TipoOrdine.Id.ToString();
					marchi.SelectedValue = impostazione.Marchio.Codice;
					listini.SelectedValue = impostazione.CodiceListinoConsigliato;
				}
			}
		}

		protected void ListiniRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			string codiceListino = item.DataItem as string;
			DropDownList listini = item.FindControl("ListiniDropDownList") as DropDownList;
			if (listini != null)
			{
				listini.DataSource = this.listaListini;
				listini.DataBind();
				if (!string.IsNullOrEmpty(codiceListino))
				{
					listini.SelectedValue = codiceListino;
				}
			}
		}

		protected void MetodiPagamentoRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			MetodoPagamento metodoPagamento = item.DataItem as MetodoPagamento;
			DropDownList metodiPagamento = item.FindControl("MetodiPagamentoDropDownList") as DropDownList;
			if ((metodoPagamento == null ? false : metodiPagamento != null))
			{
				metodiPagamento.DataSource = this.listaMetodiPagamento;
				metodiPagamento.DataBind();
				if (metodoPagamento != null)
				{
					metodiPagamento.SelectedValue = metodoPagamento.Codice;
				}
			}
		}

		protected void NomeUtenteCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
		{
			if (this.GetAgenteCorrente() == null)
			{
				string codiceUtente = this.NomeUtenteTextBox.Text;
				args.IsValid = base.AgenteRepository.GetById(codiceUtente) == null;
			}
			else
			{
				args.IsValid = true;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.SetValidationMessages();
				this.WriteSuccessMessage();
				this.divMostraDisponibilitaIcona.Visible = WebConfigSettings.OpzioneIconaDisponibilita;
				this.CaricaNazioni();
				this.CaricaLingue();
				this.CaricaTipiAgente();
				this.CaricaCodiciListinoDefault();
				this.CaricaMetodiPagamentoDefault();
				Agente agente = this.GetAgenteCorrente();
				if (agente != null)
				{
					Literal titoloLiteral = this.TitoloLiteral;
					string str = string.Format(Resources.ModificaAgenteCodice, agente.ToString());
					string str1 = str;
					base.Title = str;
					titoloLiteral.Text = str1;
					this.CaricaImpostazioniAgente(agente);
				}
				this.CaricaImpostazioniListini();
				this.CaricaImpostazioniValute();
				this.CaricaImpostazioniMetodiPagamento();
				this.CaricaImpostazioniOrdini();
				this.CaricaImpostazioniStagioni();
			}
		}

		private void SalvaAgente()
		{
			string codiceListino;
			RepeaterItem impostazioneItem = null;
			bool isAgenteNuovo = false;
			Agente agente = this.GetAgenteCorrente();
			if (agente == null)
			{
				isAgenteNuovo = true;
				agente = new Agente()
				{
					CodiceUtente = this.NomeUtenteTextBox.Text
				};
			}
			agente.CodiceAgente = Convert.ToInt32(this.CodiceAgenteTextBox.Text);
			agente.RagioneSociale = this.RagioneSocialeTextBox.Text;
			agente.Password = this.PasswordTextBox.Text;
			agente.Tipo = base.TipoAgenteRepository.GetById(this.TipiAgenteRadio.SelectedValue);
			agente.Attivo = this.AttivoCheckBox.Checked;
			agente.NumeroDecimali = Convert.ToInt32(this.NumeroDecimaliTextBox.Text);
			agente.UtilizzaOffline = this.UtilizzaOfflineCheckBox.Checked;
			agente.MostraDisponibilitaIcona = this.MostraDisponibilitaIconaCheckBox.Checked;
			agente.Nazione = base.NazioneRepository.GetById(this.NazioniList.SelectedValue);
			agente.Lingua = base.LinguaRepository.GetById(this.LingueList.SelectedValue);
			if (string.IsNullOrEmpty(this.ListiniDefaultList.SelectedValue))
			{
				agente.CodiceListinoPredefinito = null;
			}
			else
			{
				agente.CodiceListinoPredefinito = this.ListiniDefaultList.SelectedValue;
			}
			if (string.IsNullOrEmpty(this.MetodiPagamentoDefaultList.SelectedValue))
			{
				agente.MetodoPagamentoPredefinito = null;
			}
			else
			{
				MetodoPagamento metodoPagamentoPredefinito = base.MetodoPagamentoRepository.GetById(this.MetodiPagamentoDefaultList.SelectedValue);
				if (metodoPagamentoPredefinito != null)
				{
					agente.MetodoPagamentoPredefinito = metodoPagamentoPredefinito;
				}
			}
			List<string> codiciListino = new List<string>();
			foreach (RepeaterItem listinoItem in this.ListiniRepeater.Items)
			{
				DropDownList listiniList = listinoItem.FindControl("ListiniDropDownList") as DropDownList;
				if (listiniList != null)
				{
					codiceListino = listiniList.SelectedValue;
					if (!string.IsNullOrEmpty(codiceListino))
					{
						codiciListino.Add(codiceListino);
					}
				}
			}
			if (agente.CodiciListino == null)
			{
				agente.CodiciListino = new List<string>();
			}
			else
			{
				agente.CodiciListino.Clear();
			}
			foreach (string codiceListinoStr in codiciListino)
			{
				agente.CodiciListino.Add(codiceListinoStr);
			}
			List<Valuta> valute = new List<Valuta>();
			foreach (RepeaterItem valutaItem in this.ValuteRepeater.Items)
			{
				DropDownList valuteList = valutaItem.FindControl("ValuteDropDownList") as DropDownList;
				if (valuteList != null)
				{
					string codiceValuta = valuteList.SelectedValue;
					if (!string.IsNullOrEmpty(codiceValuta))
					{
						valute.Add(base.ValutaRepository.GetById(codiceValuta));
					}
				}
			}
			if (agente.Valute == null)
			{
				agente.Valute = new List<Valuta>();
			}
			else
			{
				agente.Valute.Clear();
			}
			foreach (Valuta valuta in valute)
			{
				agente.Valute.Add(valuta);
			}
			List<MetodoPagamento> metodiPagamento = new List<MetodoPagamento>();
			foreach (RepeaterItem metodoPagamentoItem in this.MetodiPagamentoRepeater.Items)
			{
				DropDownList metodiPagamentoList = metodoPagamentoItem.FindControl("MetodiPagamentoDropDownList") as DropDownList;
				if (metodiPagamentoList != null)
				{
					string codiceMetodoPagamento = metodiPagamentoList.SelectedValue;
					if (!string.IsNullOrEmpty(codiceMetodoPagamento))
					{
						metodiPagamento.Add(base.MetodoPagamentoRepository.GetById(codiceMetodoPagamento));
					}
				}
			}
			if (agente.MetodiPagamento == null)
			{
				agente.MetodiPagamento = new List<MetodoPagamento>();
			}
			else
			{
				agente.MetodiPagamento.Clear();
			}
			foreach (MetodoPagamento metodoPagamento in metodiPagamento)
			{
				agente.MetodiPagamento.Add(metodoPagamento);
			}
			List<ImpostazioneOrdine> impostazioniOrdine = new List<ImpostazioneOrdine>();
			foreach (RepeaterItem impostazioneItem1 in this.ImpostazioniOrdiniRepeater.Items)
			{
				DropDownList tipiOrdine = impostazioneItem1.FindControl("TipiOrdineList") as DropDownList;
				DropDownList marchi = impostazioneItem1.FindControl("MarchiList") as DropDownList;
				DropDownList listini = impostazioneItem1.FindControl("ListiniList") as DropDownList;
				TextBox valoreMinimoTextBox = impostazioneItem1.FindControl("ValoreMinimoTextBox") as TextBox;
				if ((tipiOrdine == null || marchi == null || listini == null ? false : valoreMinimoTextBox != null))
				{
					string codiceTipoOrdine = tipiOrdine.SelectedValue;
					string codiceMarchio = marchi.SelectedValue;
					codiceListino = listini.SelectedValue;
					decimal valoreMinimo = new decimal(0);
					decimal.TryParse(valoreMinimoTextBox.Text, out valoreMinimo);
					if ((string.IsNullOrEmpty(codiceTipoOrdine) || string.IsNullOrEmpty(codiceMarchio) ? false : !string.IsNullOrEmpty(codiceListino)))
					{
						ImpostazioneOrdine impostazioneOrdine1 = new ImpostazioneOrdine()
						{
							TipoOrdine = base.TipoOrdineRepository.GetById(Convert.ToInt32(codiceTipoOrdine)),
							Marchio = base.MarchioRepository.GetById(codiceMarchio),
							ValoreMinimoOrdine = valoreMinimo,
							CodiceListinoConsigliato = codiceListino
						};
						impostazioniOrdine.Add(impostazioneOrdine1);
					}
				}
			}
			if (agente.ImpostazioniOrdine == null)
			{
				agente.ImpostazioniOrdine = new List<ImpostazioneOrdine>();
			}
			else
			{
				agente.ImpostazioniOrdine.Clear();
			}
			foreach (ImpostazioneOrdine impostazioneOrdine in impostazioniOrdine)
			{
				agente.ImpostazioniOrdine.Add(impostazioneOrdine);
			}
			List<ImpostazioneStagione> impostazioniStagione = new List<ImpostazioneStagione>();
			foreach (RepeaterItem item in this.StagioniRepeater.Items)
			{
				DropDownList stagioni = item.FindControl("StagioniDropDownList") as DropDownList;
				CheckBox disponibilita = item.FindControl("DisponibilitaCheckBox") as CheckBox;
				if ((stagioni == null ? false : disponibilita != null))
				{
					string codiceStagione = stagioni.SelectedValue;
					if (!string.IsNullOrEmpty(codiceStagione))
					{
						ImpostazioneStagione impostazioneStagione1 = new ImpostazioneStagione()
						{
							Stagione = base.StagioneRepository.GetById(codiceStagione),
							Disponibilita = disponibilita.Checked
						};
						impostazioniStagione.Add(impostazioneStagione1);
					}
				}
			}
			if (agente.ImpostazioniStagione == null)
			{
				agente.ImpostazioniStagione = new List<ImpostazioneStagione>();
			}
			else
			{
				agente.ImpostazioniStagione.Clear();
			}
			foreach (ImpostazioneStagione impostazioneStagione in impostazioniStagione)
			{
				agente.ImpostazioniStagione.Add(impostazioneStagione);
			}
			agente.BloccoMetodoPagamento = this.BloccoMetodoPagamentoCheckBox.Checked;
			agente.BloccoBanca = this.BloccoBancaCheckBox.Checked;
			agente.BloccoValuta = this.BloccoValutaCheckBox.Checked;
			agente.BloccoPorto = this.BloccoPortoCheckBox.Checked;
			agente.BloccoTrasporto = this.BloccoTrasportoCheckBox.Checked;
			agente.BloccoVettore = this.BloccoVettoreCheckBox.Checked;
			agente.BloccoDataOrdine = this.BloccoDataOrdineCheckBox.Checked;
			agente.BloccoDateConsegna = this.BloccoDateConsegnaCheckBox.Checked;
			if (!isAgenteNuovo)
			{
				base.AgenteRepository.Save(agente);
			}
			else
			{
				base.AgenteRepository.Create(agente);
			}
			if (!isAgenteNuovo)
			{
				base.SuccessMessage = string.Format(Resources.AgenteModificatoCorrettamente, agente.CodiceUtente);
			}
			else
			{
				base.SuccessMessage = string.Format(Resources.AgenteInseritoCorrettamente, agente.CodiceUtente);
			}
			string url = string.Concat(base.Request.Url.AbsolutePath, "?codiceAgente=", base.Server.UrlEncode(agente.CodiceUtente));
			base.Response.Redirect(url);
		}

		protected void SalvaButton_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
				this.SalvaAgente();
			}
		}

		private void SetValidationMessages()
		{
			foreach (object validator in base.Validators)
			{
				RequiredFieldValidator requiredValidator = validator as RequiredFieldValidator;
				if (requiredValidator != null)
				{
					requiredValidator.ErrorMessage = ValidationUtils.Required(requiredValidator.ErrorMessage);
					requiredValidator.Text = "*";
				}
			}
			this.CodiceAgenteRegexValidator.ErrorMessage = ValidationUtils.Integer(this.CodiceAgenteLabel.Text);
			this.CodiceAgenteRegexValidator.Text = "*";
			this.NomeUtenteCustomValidator.Text = "*";
			this.NumeroDecimaliRegexValidator.ErrorMessage = ValidationUtils.Integer(this.NumeroDecimaliLabel.Text);
			this.NumeroDecimaliRegexValidator.Text = "*";
		}

		protected void StagioniRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			ImpostazioneStagione impostazione = item.DataItem as ImpostazioneStagione;
			DropDownList stagioni = item.FindControl("StagioniDropDownList") as DropDownList;
			CheckBox disponibilita = item.FindControl("DisponibilitaCheckBox") as CheckBox;
			if ((impostazione == null || stagioni == null ? false : disponibilita != null))
			{
				stagioni.DataSource = this.listaStagioni;
				stagioni.DataBind();
				if (impostazione.Stagione != null)
				{
					stagioni.SelectedValue = impostazione.Stagione.Codice;
				}
				disponibilita.Checked = impostazione.Disponibilita;
			}
		}

		protected void ValuteRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			RepeaterItem item = e.Item;
			Valuta valuta = item.DataItem as Valuta;
			DropDownList valute = item.FindControl("ValuteDropDownList") as DropDownList;
			if ((valuta == null ? false : valute != null))
			{
				valute.DataSource = this.listaValute;
				valute.DataBind();
				if (valuta != null)
				{
					valute.SelectedValue = valuta.Codice;
				}
			}
		}

		private void WriteSuccessMessage()
		{
			if (!string.IsNullOrEmpty(base.SuccessMessage))
			{
				this.messaggioSuccesso.Visible = true;
				this.MessaggioSuccessoLiteral.Text = base.SuccessMessage;
			}
		}
	}
}