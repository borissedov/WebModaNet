using EW.WebModaNet.Code;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class InserisciNomeUtente : BasePage
	{
		protected Literal InserisciNomeUtenteLiteral;

		protected Literal IstruzioniInserisciNomeUtenteLiteral;

		protected Literal DatiUtenteLiteral;

		protected Label NomeUtenteLiteral;

		protected RequiredFieldValidator NomeUtenteValidator;

		protected TextBox NomeUtenteTextBox;

		protected Button ConfermaButton;

		public InserisciNomeUtente()
		{
		}

		protected void ConfermaButton_Click(object sender, EventArgs e)
		{
			if (this.Page.IsValid)
			{
				Utils.SetCodiceUtenteDefault(this.NomeUtenteTextBox.Text);
				base.Response.Redirect("~");
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				if (WebConfigSettings.IsOnline)
				{
					base.Response.Redirect("~");
				}
				string codiceUtente = Utils.GetCodiceUtenteDefault();
				if (!string.IsNullOrEmpty(codiceUtente))
				{
					this.NomeUtenteTextBox.Text = codiceUtente;
				}
			}
		}
	}
}