using EW.WebModaNet.Code;
using System;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EW.WebModaNet
{
	public class Errore : BasePage
	{
		protected Literal TitoloErroreLiteral;

		protected Literal DescrizioneErroreLiteral;

		public Errore()
		{
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				HttpException exception = base.Server.GetLastError() as HttpException;
				if ((exception == null ? false : exception.GetBaseException() != null))
				{
					this.DescrizioneErroreLiteral.Text = exception.GetBaseException().Message;
				}
				if (this.Session[WebConfigSettings.ApplicationErrorMessageSessionKey] != null)
				{
					this.DescrizioneErroreLiteral.Text = this.Session[WebConfigSettings.ApplicationErrorMessageSessionKey].ToString();
					this.Session.Remove(WebConfigSettings.ApplicationErrorMessageSessionKey);
				}
			}
		}
	}
}