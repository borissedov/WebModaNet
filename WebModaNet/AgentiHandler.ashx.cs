using EW.WebModaNet.Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization.Json;
using System.Web;

namespace EW.WebModaNet
{
	public class AgentiHandler : IHttpHandler
	{
		private const string codiceAgenteQueryStringKey = "term";

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}

		public AgentiHandler()
		{
		}

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";
			List<string> codiciAgente = new List<string>();
			string codiceAgente = context.Request.QueryString["term"];
			if (!string.IsNullOrEmpty(codiceAgente))
			{
				SqlConnection connection = new SqlConnection(WebConfigSettings.SqlConnectionString);
				SqlConnection sqlConnection = connection;
				try
				{
					connection.Open();
					SqlCommand command = new SqlCommand("SELECT CodiceUtente as Codice\r\n                                           FROM Agenti\r\n                                           WHERE CodiceUtente LIKE @codice", connection);
					command.Parameters.AddWithValue("codice", string.Concat("%", codiceAgente, "%"));
					SqlDataReader dataReader = command.ExecuteReader();
					SqlDataReader sqlDataReader = dataReader;
					try
					{
						while (dataReader.Read())
						{
							codiciAgente.Add(dataReader["Codice"].ToString());
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
			(new DataContractJsonSerializer(typeof(List<string>))).WriteObject(context.Response.OutputStream, codiciAgente);
		}
	}
}