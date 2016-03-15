using EW.WebModaNet.Code;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Script.Serialization;

namespace EW.WebModaNet
{
	public class ArticoliHandler : IHttpHandler
	{
		private const string articoloQueryStringKey = "term";

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}

		public ArticoliHandler()
		{
		}

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "application/json";
			Dictionary<string, string> listaArticoli = new Dictionary<string, string>();
			string articolo = context.Request.QueryString["term"];
			if (!string.IsNullOrEmpty(articolo))
			{
				SqlConnection connection = new SqlConnection(WebConfigSettings.SqlConnectionString);
				SqlConnection sqlConnection = connection;
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand("SELECT Codice, Descrizione\r\n                                           FROM Articoli\r\n                                           WHERE Codice LIKE @articolo OR Descrizione LIKE @articolo", connection);
					command.Parameters.AddWithValue("articolo", string.Concat("%", articolo, "%"));
					SqlDataReader dataReader = command.ExecuteReader();
					SqlDataReader sqlDataReader = dataReader;
					try
					{
						while (dataReader.Read())
						{
							string cod = dataReader["Codice"].ToString();
							string descr = dataReader["Descrizione"].ToString();
							listaArticoli.Add(cod, string.Concat(cod, " - ", descr));
						}
					}
					finally
					{
						if (sqlDataReader != null)
						{
							((IDisposable)sqlDataReader).Dispose();
						}
					}
				}
				finally
				{
					if (sqlConnection != null)
					{
						((IDisposable)sqlConnection).Dispose();
					}
				}
			}
			JavaScriptSerializer serializer = new JavaScriptSerializer();
			context.Response.Write(serializer.Serialize(
				from c in listaArticoli
				select new ArticoloJson()
				{
					label = c.Value,
					@value = c.Key
				}));
		}
	}
}