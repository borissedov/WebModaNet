using EW.WebModaNet.Code;
using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Web;

namespace EW.WebModaNet
{
	public class UpdateHandler : IHttpHandler
	{
		public bool IsReusable
		{
			get
			{
				return false;
			}
		}

		public UpdateHandler()
		{
		}

		public void ProcessRequest(HttpContext context)
		{
			string action = context.Request.QueryString["action"];
			string codice = context.Request.QueryString["codice"];
			if ((string.IsNullOrEmpty(action) ? false : !string.IsNullOrEmpty(codice)))
			{
				Agente agente = ServiceLocator.Current.GetInstance<IAgenteRepository>().Find(codice);
				if (agente != null)
				{
					string str = action;
					if (str != null)
					{
						if (str == "app")
						{
							this.ReturnAggiornamentoApplicazione(context);
						}
						else if (str == "db")
						{
							this.ReturnAggiornamentoDatabase(agente, context);
						}
						else if (str == "img")
						{
							this.ReturnAggiornamentoImmagini(context);
						}
					}
				}
			}
			throw new HttpException(403, "Forbidden");
		}

		private void ReturnAggiornamentoApplicazione(HttpContext context)
		{
			if (!File.Exists(Path.Combine(context.Server.MapPath(WebConfigSettings.ServerUpdateDirectory), WebConfigSettings.UpdateAppZipFileName)))
			{
				throw new HttpException(404, "Not Found");
			}
			string appUrl = string.Concat(WebConfigSettings.ServerUpdateDirectory, "/", WebConfigSettings.UpdateAppZipFileName);
			context.Response.Redirect(appUrl);
		}

		private void ReturnAggiornamentoDatabase(Agente agente, HttpContext context)
		{
			string zipFileName = string.Format(WebConfigSettings.UpdateDBZipFileName, HttpUtility.UrlEncode(agente.CodiceUtente));
			if (!File.Exists(Path.Combine(context.Server.MapPath(WebConfigSettings.ServerUpdateDirectory), zipFileName)))
			{
				throw new HttpException(404, "Not Found");
			}
			context.Response.Redirect(string.Concat(WebConfigSettings.ServerUpdateDirectory, "/", zipFileName));
		}

		private void ReturnAggiornamentoImmagini(HttpContext context)
		{
			if (!File.Exists(Path.Combine(context.Server.MapPath(WebConfigSettings.ServerUpdateDirectory), WebConfigSettings.UpdateImgZipFileName)))
			{
				throw new HttpException(404, "Not Found");
			}
			string appUrl = string.Concat(WebConfigSettings.ServerUpdateDirectory, "/", WebConfigSettings.UpdateImgZipFileName);
			context.Response.Redirect(appUrl);
		}
	}
}