using EW.WebModaNet.Code;
using NHibernate;
using NHibernate.Stat;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EW.WebModaNet.Controls
{
	public class Footer : UserControl
	{
		protected Label StatoLabel;

		protected HyperLink ModificaNomeUtenteLink;

		protected Literal SeparatorLiteral1;

		protected Label DatiDittaLabel;

		protected HyperLink SitoWebDittaLink;

		protected Label StatisticsLabel;

		protected HtmlAnchor showAdvancedStats;

		protected Literal SeparatorLiteral2;

		protected HtmlAnchor showTrace;

		public Footer()
		{
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			this.ShowStatistics();
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.StatoLabel.Text = (WebConfigSettings.IsOnline ? "Online" : "Offline");
				if (this.Page is BasePage)
				{
					BasePage myPage = this.Page as BasePage;
					Label datiDittaLabel = this.DatiDittaLabel;
					string[] ragioneSocialeDitta = new string[] { myPage.ImpostazioniGenerali.RagioneSocialeDitta, " - ", myPage.ImpostazioniGenerali.IndirizzoDitta, " ", myPage.ImpostazioniGenerali.CapDitta, " ", myPage.ImpostazioniGenerali.CittaDitta };
					datiDittaLabel.Text = string.Concat(ragioneSocialeDitta);
					if (!string.IsNullOrEmpty(myPage.ImpostazioniGenerali.TelefonoDitta))
					{
						Label label = this.DatiDittaLabel;
						label.Text = string.Concat(label.Text, " Tel. ", myPage.ImpostazioniGenerali.TelefonoDitta, " ");
					}
					if (!string.IsNullOrEmpty(myPage.ImpostazioniGenerali.PartitaIVADitta))
					{
						Label datiDittaLabel1 = this.DatiDittaLabel;
						datiDittaLabel1.Text = string.Concat(datiDittaLabel1.Text, " P.IVA ", myPage.ImpostazioniGenerali.PartitaIVADitta, " ");
					}
					if (string.IsNullOrEmpty(myPage.ImpostazioniGenerali.SitoWebDitta))
					{
						this.SitoWebDittaLink.Visible = false;
					}
					else
					{
						this.SitoWebDittaLink.Visible = true;
						this.SitoWebDittaLink.NavigateUrl = myPage.ImpostazioniGenerali.SitoWebDitta;
						this.SitoWebDittaLink.Text = myPage.ImpostazioniGenerali.SitoWebDitta.Replace("http://", "");
					}
				}
				if (WebConfigSettings.IsOnline)
				{
					this.ModificaNomeUtenteLink.Visible = false;
					this.SeparatorLiteral1.Visible = false;
				}
				else
				{
					this.ModificaNomeUtenteLink.Visible = true;
					this.ModificaNomeUtenteLink.Text = Resources.ModificaNomeUtente;
					this.SeparatorLiteral1.Visible = true;
				}
			}
		}

		private void ShowAdvancedStatistics(IStatistics statistics)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string rawStats = Regex.Replace(statistics.ToString(), "\\w+\\[(.*)\\]", "$1");
			char[] chrArray = new char[] { ',' };
			string[] strArrays = rawStats.Split(chrArray);
			for (int i = 0; i < (int)strArrays.Length; i++)
			{
				string stat = strArrays[i];
				chrArray = new char[] { '=' };
				string[] p = stat.Split(chrArray);
				stringBuilder.AppendFormat("<strong>{0}:</strong> {1}<br />", p[0], p[1]);
			}
			Panel statsPanel = this.Page.Master.FindControl("AdvancedStatisticsPanel") as Panel;
			if (statsPanel != null)
			{
				Literal statsLiteral = statsPanel.FindControl("AdvancedStatisticsLiteral") as Literal;
				statsPanel.Visible = true;
				statsLiteral.Text = stringBuilder.ToString();
				this.StatisticsLabel.Text = string.Concat(this.StatisticsLabel.Text, " - ");
				this.showAdvancedStats.Visible = true;
				if (base.Trace.IsEnabled)
				{
					this.SeparatorLiteral2.Visible = true;
					this.showTrace.Visible = base.Trace.IsEnabled;
				}
			}
		}

		private void ShowSimpleStatistics(IStatistics statistics)
		{
			string pattern = "- {0} query, {1} entità";
			this.StatisticsLabel.Visible = true;
			this.StatisticsLabel.Text = string.Format(pattern, statistics.QueryExecutionCount, statistics.EntityLoadCount);
		}

		private void ShowStatistics()
		{
			if (WebConfigSettings.DebugMode)
			{
				IStatistics statistics = NHibernateHelper.SessionFactory.Statistics;
				if (statistics.IsStatisticsEnabled)
				{
					this.ShowSimpleStatistics(statistics);
					if (WebConfigSettings.ShowAdvancedStatistics)
					{
						this.ShowAdvancedStatistics(statistics);
					}
					statistics.Clear();
				}
			}
		}
	}
}