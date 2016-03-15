using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class AreaDocumentale : ProtectedPage
	{
		protected Literal TitoloLiteral;

		protected Panel FiltriRicercaPanel;

		protected Literal RicercaDocumentiLiteral;

		protected Label ClienteLabel;

		protected DropDownList ClientiList;

		protected Label TipoDocumentoLabel;

		protected DropDownList TipiDocumentoList;

		protected Label StagioneLabel;

		protected DropDownList StagioniList;

		protected Label LineaLabel;

		protected DropDownList LineeList;

		protected Label DescrizioneLabel;

		protected TextBox DescrizioneTextBox;

		protected CheckBox ScadutiCheckBox;

		protected Button CercaButton;

		protected UpdateProgress DocumentiUpdateProgress;

		protected UpdatePanel DocumentiUpdatePanel;

		protected HtmlGenericControl nessunDocumentoTrovato;

		protected Literal NessunDocumentoTrovatoLiteral;

		protected GridView DocumentiGridView;

		protected bool Descending
		{
			get
			{
				object item = this.ViewState["Descending"];
				if (item == null)
				{
					item = false;
				}
				return (bool)item;
			}
			set
			{
				this.ViewState["Descending"] = value;
			}
		}

		protected string SortExpression
		{
			get
			{
				return this.ViewState["SortExpression"] as string ?? "NumeroOrdine";
			}
			set
			{
				this.ViewState["SortExpression"] = value;
			}
		}

		public AreaDocumentale()
		{
		}

		private void CaricaDocumenti()
		{
			IList<Documento> documenti;
			List<Expression<Func<Documento, bool>>> predicates = new List<Expression<Func<Documento, bool>>>();
			if (!string.IsNullOrEmpty(this.ClientiList.SelectedValue))
			{
				predicates.Add((Documento a) => a.Cliente.Codice == this.ClientiList.SelectedValue);
			}
			if (!string.IsNullOrEmpty(this.TipiDocumentoList.SelectedValue))
			{
				predicates.Add((Documento a) => a.Tipo == this.TipiDocumentoList.SelectedValue);
			}
			if (!string.IsNullOrEmpty(this.StagioniList.SelectedValue))
			{
				predicates.Add((Documento a) => a.Stagione.Codice == this.StagioniList.SelectedValue);
			}
			if (!string.IsNullOrEmpty(this.LineeList.SelectedValue))
			{
				predicates.Add((Documento a) => a.Linea.Codice == this.LineeList.SelectedValue);
			}
			if (!string.IsNullOrEmpty(this.DescrizioneTextBox.Text))
			{
				predicates.Add((Documento a) => a.Descrizione.Contains(this.DescrizioneTextBox.Text));
			}
			DateTime today = DateTime.Today;
			if (!this.ScadutiCheckBox.Checked)
			{
				predicates.Add((Documento a) => (a.DataScadenza == (DateTime?)null) || (a.DataScadenza >= (DateTime?)today));
			}
			else
			{
				predicates.Add((Documento a) => (a.DataScadenza != (DateTime?)null) && (a.DataScadenza < (DateTime?)today));
			}
			Expression<Func<Documento, object>> keySelector = null;
			string sortExpression = this.SortExpression;
			if (sortExpression != null)
			{
				switch (sortExpression)
				{
					case "Cliente":
					{
						keySelector = (Documento o) => o.Cliente.RagioneSociale1;
						break;
					}
					case "Tipo":
					{
						keySelector = (Documento o) => o.Tipo;
						break;
					}
					case "Stagione":
					{
						keySelector = (Documento o) => o.Stagione;
						break;
					}
					case "Linea":
					{
						keySelector = (Documento o) => o.Linea;
						break;
					}
					case "Descrizione":
					{
						keySelector = (Documento o) => o.Descrizione;
						break;
					}
					case "DataScadenza":
					{
						keySelector = (Documento o) => (object)o.DataScadenza;
						break;
					}
					case "Titolo":
					{
						keySelector = (Documento o) => o.Titolo;
						documenti = base.DocumentoRepository.FindAll(this.Descending, keySelector, predicates.ToArray());
						if (documenti.Count <= 0)
						{
							this.DocumentiGridView.Visible = false;
							this.nessunDocumentoTrovato.Visible = true;
						}
						else
						{
							this.DocumentiGridView.Visible = true;
							this.DocumentiGridView.DataSource = documenti;
							this.DocumentiGridView.DataBind();
						}
						return;
					}
					default:
					{
						keySelector = (Documento o) => o.Titolo;
						documenti = base.DocumentoRepository.FindAll(this.Descending, keySelector, predicates.ToArray());
						if (documenti.Count <= 0)
						{
							this.DocumentiGridView.Visible = false;
							this.nessunDocumentoTrovato.Visible = true;
						}
						else
						{
							this.DocumentiGridView.Visible = true;
							this.DocumentiGridView.DataSource = documenti;
							this.DocumentiGridView.DataBind();
						}
						return;
					}
				}
			}
			else
			{
				keySelector = (Documento o) => o.Titolo;
				documenti = base.DocumentoRepository.FindAll(this.Descending, keySelector, predicates.ToArray());
				if (documenti.Count <= 0)
				{
					this.DocumentiGridView.Visible = false;
					this.nessunDocumentoTrovato.Visible = true;
				}
				else
				{
					this.DocumentiGridView.Visible = true;
					this.DocumentiGridView.DataSource = documenti;
					this.DocumentiGridView.DataBind();
				}
				return;
			}
			documenti = base.DocumentoRepository.FindAll(this.Descending, keySelector, predicates.ToArray());
			if (documenti.Count <= 0)
			{
				this.DocumentiGridView.Visible = false;
				this.nessunDocumentoTrovato.Visible = true;
			}
			else
			{
				this.DocumentiGridView.Visible = true;
				this.DocumentiGridView.DataSource = documenti;
				this.DocumentiGridView.DataBind();
			}
		}

		private void CaricaLinee()
		{
			string codiceStagione = this.StagioniList.SelectedValue;
			IList<Linea> linee = base.LineaRepository.GetFromStagione(codiceStagione);
			this.LineeList.ClearSelection();
			this.LineeList.Items.Clear();
			this.LineeList.Items.Add(new ListItem(Resources.TutteLista, string.Empty));
			this.LineeList.DataSource = linee;
			this.LineeList.DataBind();
		}

		protected void CercaButton_Click(object sender, EventArgs e)
		{
			this.CaricaDocumenti();
		}

		protected void DocumentiGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			this.DocumentiGridView.PageIndex = e.NewPageIndex;
			this.CaricaDocumenti();
		}

		protected void DocumentiGridView_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				Documento documento = e.Row.DataItem as Documento;
				HyperLink titoloLink = e.Row.FindControl("TitoloLink") as HyperLink;
				string virtualDirPath = base.ImpostazioniGenerali.CartellaDocumentiPdf.TrimEnd(new char[] { '/' });
				string physicalDirPath = base.Server.MapPath(virtualDirPath);
				string fileName = string.Concat(base.AgenteAutenticato.CodiceUtente, "/", documento.NomeFile);
				string virtualFilePath = string.Concat(virtualDirPath, "/", fileName);
				if (File.Exists(Path.Combine(physicalDirPath, fileName)))
				{
					titoloLink.Text = documento.Titolo;
					titoloLink.NavigateUrl = virtualFilePath;
					titoloLink.Target = "_blank";
				}
				else
				{
					titoloLink.Text = documento.Titolo;
					titoloLink.NavigateUrl = "javascript:void(0)";
					string resolvedUrl = base.ResolveUrl(virtualFilePath);
					string errorMessage = string.Format(Resources.DocumentoNonTrovato, documento.Titolo, resolvedUrl);
					titoloLink.Attributes["onclick"] = string.Format("alert('{0}');", HttpUtility.JavaScriptStringEncode(errorMessage));
				}
			}
		}

		protected void DocumentiGridView_Sorting(object sender, GridViewSortEventArgs e)
		{
			this.Descending = !this.Descending;
			this.SortExpression = e.SortExpression;
			this.CaricaDocumenti();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.ImpostazioniGenerali.AttivaAreaDocumentale)
			{
				base.Response.Redirect("~/Errors/AccessoNegato.aspx");
			}
			if (!base.IsPostBack)
			{
				this.PopolaListe();
				this.CaricaDocumenti();
			}
		}

		private void PopolaListe()
		{
			this.ClientiList.DataSource = base.ClienteRepository.GetClientiAttiviForAgente(base.AgenteAutenticato, (Cliente c) => c.RagioneSociale1, false, false);
			this.ClientiList.DataBind();
			this.TipiDocumentoList.DataSource = base.DocumentoRepository.GetTipiDocumento();
			this.TipiDocumentoList.DataBind();
			this.StagioniList.DataSource = 
				from s in base.AgenteAutenticato.GetStagioni()
				orderby s.Codice
				select s;
			this.StagioniList.DataBind();
			this.CaricaLinee();
		}

		protected void StagioniList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CaricaLinee();
		}
	}
}