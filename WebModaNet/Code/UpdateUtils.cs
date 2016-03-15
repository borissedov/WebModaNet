using EW.WebModaNet.ServiceEntities;
using EW.WebModaNetClassLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.Code
{
	public static class UpdateUtils
	{
		public static void AggiornaDB(AggiornamentoDatabaseService aggiornamentoDatabase, string offlineConnectionString)
		{
			SqlCeConnection connection = new SqlCeConnection(offlineConnectionString);
			try
			{
				connection.Open();
				SqlCeTransaction transaction = connection.BeginTransaction();
				try
				{
					try
					{
						LogUtils.Info("Avvio dell'aggiornamento del database locale.");
						UpdateUtils.ProcessUpdate(connection, transaction, aggiornamentoDatabase);
						transaction.Commit();
						LogUtils.Info("Aggiornamento del database locale completato correttamente.");
					}
					catch (Exception exception)
					{
						Exception e = exception;
						transaction.Rollback();
						LogUtils.Fatal("Errore durante l'aggiornamento del database locale.", e);
						throw;
					}
				}
				finally
				{
					if (transaction != null)
					{
						((IDisposable)transaction).Dispose();
					}
				}
			}
			finally
			{
				if (connection != null)
				{
					((IDisposable)connection).Dispose();
				}
			}
		}

		private static int InsertIntoTable(SqlCeConnection connection, SqlCeTransaction transaction, string tableName, object entityList, params string[] skippedProperties)
		{
			Type entityListType = entityList.GetType();
			Type entityType = entityListType.GetGenericArguments()[0];
			PropertyInfo[] entityProperties = entityType.GetProperties();
			int count = (int)entityListType.GetProperty("Count").GetValue(entityList, null);
			int recordCount = 0;
			for (int i = 0; i < count; i++)
			{
				string insSql = "INSERT INTO {0} ({1})\r\n                                  VALUES ({2})";
				Dictionary<string, object> values = new Dictionary<string, object>();
				PropertyInfo property = entityListType.GetProperty("Item");
				object[] objArray = new object[] { i };
				object currEntity = property.GetValue(entityList, objArray);
				PropertyInfo[] propertyInfoArray = entityProperties;
				for (int j = 0; j < (int)propertyInfoArray.Length; j++)
				{
					PropertyInfo entityProperty = propertyInfoArray[j];
					if (!skippedProperties.Contains<string>(entityProperty.Name, StringComparer.OrdinalIgnoreCase))
					{
						values.Add(entityProperty.Name, entityType.GetProperty(entityProperty.Name).GetValue(currEntity, null));
					}
				}
				string columns = string.Join(", ", 
					from p in values
					select p.Key);
				string parameters = string.Join(", ", 
					from p in values
					select string.Concat("@", p.Key));
				insSql = string.Format(insSql, tableName, columns, parameters);
				SqlCeCommand insCommand = new SqlCeCommand(insSql, connection, transaction);
				foreach (KeyValuePair<string, object> pair in values)
				{
					SqlCeParameterCollection sqlCeParameterCollection = insCommand.Parameters;
					string key = pair.Key;
					object value = pair.Value;
					if (value == null)
					{
						value = DBNull.Value;
					}
					sqlCeParameterCollection.AddWithValue(key, value);
				}
				recordCount = recordCount + insCommand.ExecuteNonQuery();
			}
			return recordCount;
		}

		private static void ProcessUpdate(SqlCeConnection connection, SqlCeTransaction transaction, AggiornamentoDatabaseService aggiornamentoDatabase)
		{
			PropertyInfo[] properties = aggiornamentoDatabase.GetType().GetProperties();
			(
				from p in (IEnumerable<PropertyInfo>)properties
				select p.Name).ToArray<string>();
			int recordCount = 0;
			PropertyInfo[] propertyInfoArray = properties;
			for (int i = 0; i < (int)propertyInfoArray.Length; i++)
			{
				PropertyInfo property = propertyInfoArray[i];
				recordCount = recordCount + UpdateUtils.UpdateTable(connection, transaction, property.Name, property.GetValue(aggiornamentoDatabase, null));
			}
			recordCount = recordCount + UpdateUtils.UpdateClientiAndIndirizziTables(connection, transaction, aggiornamentoDatabase.Clienti, aggiornamentoDatabase.Indirizzi);
			LogUtils.Debug(string.Format("Totale {0} record inseriti all'interno del database locale.", recordCount));
		}

		private static int UpdateClientiAndIndirizziTables(SqlCeConnection connection, SqlCeTransaction transaction, List<ClienteService> clienti, List<IndirizzoService> indirizzi)
		{
			SqlCeCommand delCliCommand;
			int recordCount = 0;
			LogUtils.Debug("Processamento della tabella \"Clienti\" e della tabella \"Indirizzi\".");
			SqlCeCommand delCommand = new SqlCeCommand("DELETE\r\n                              FROM Indirizzi\r\n                              WHERE EXISTS (\r\n                                  SELECT * FROM Clienti B\r\n                                  WHERE Indirizzi.CodiceCliente = B.Codice\r\n                                  AND (B.CodiceStatoCliente = 'GES'\r\n                                      OR B.CodiceStatoCliente IS NULL\r\n                                  )\r\n                              )", connection, transaction);
			delCommand.ExecuteNonQuery();
			delCommand.CommandText = "DELETE\r\n                       FROM Clienti\r\n                       WHERE CodiceStatoCliente = 'GES'\r\n                       OR CodiceStatoCliente IS NULL";
			delCommand.ExecuteNonQuery();
			LogUtils.Debug("Cancellati i record provenienti del gestionale dalla tabella \"Clienti\" e dalla tabella \"Indirizzi\".");
			List<ClienteService> clientiElaborati = (
				from c in clienti
				where c.CodiceStatoCliente == WebConfigSettings.CodiceStatoClienteElaborato
				select c).ToList<ClienteService>();
			foreach (ClienteService clienteService in clientiElaborati)
			{
				delCliCommand = new SqlCeCommand("DELETE\r\n                                     FROM Clienti\r\n                                     WHERE Codice = @codice", connection, transaction);
				delCliCommand.Parameters.AddWithValue("codice", clienteService.Codice);
				delCliCommand.ExecuteNonQuery();
			}
			List<IndirizzoService> indirizziElaborati = (
				from i in indirizzi
				join c in clienti on i.CodiceCliente equals c.Codice
				select new { Indirizzo = i, Cliente = c } into o
				where o.Cliente.CodiceStatoCliente == WebConfigSettings.CodiceStatoClienteElaborato
				select o.Indirizzo).ToList<IndirizzoService>();
			foreach (IndirizzoService indirizzoService in indirizziElaborati)
			{
				delCliCommand = new SqlCeCommand("DELETE\r\n                                     FROM Indirizzi\r\n                                     WHERE ID = @id\r\n                                     AND CodiceCliente = @codiceCliente", connection, transaction);
				delCliCommand.Parameters.AddWithValue("id", indirizzoService.Id);
				delCliCommand.Parameters.AddWithValue("codiceCliente", indirizzoService.CodiceCliente);
				delCliCommand.ExecuteNonQuery();
			}
			List<ClienteService> clientiDaInserire = (
				from c in clienti
				where (c.CodiceStatoCliente == WebConfigSettings.CodiceStatoClienteElaborato || c.CodiceStatoCliente == WebConfigSettings.CodiceStatoClienteGestionale ? true : string.IsNullOrEmpty(c.CodiceStatoCliente))
				select c).ToList<ClienteService>();
			string[] strArrays = new string[] { "Indirizzi" };
			recordCount = recordCount + UpdateUtils.InsertIntoTable(connection, transaction, "Clienti", clientiDaInserire, strArrays);
			List<IndirizzoService> indirizziDaInserire = (
				from i in indirizzi
				join c in clienti on i.CodiceCliente equals c.Codice
				select new { Indirizzo = i, Cliente = c } into o
				where (o.Cliente.CodiceStatoCliente == WebConfigSettings.CodiceStatoClienteElaborato || o.Cliente.CodiceStatoCliente == WebConfigSettings.CodiceStatoClienteGestionale ? true : string.IsNullOrEmpty(o.Cliente.CodiceStatoCliente))
				select o.Indirizzo).ToList<IndirizzoService>();
			recordCount = recordCount + UpdateUtils.InsertIntoTable(connection, transaction, "Indirizzi", indirizziDaInserire, new string[0]);
			LogUtils.Debug(string.Format("{0} record inseriti all'interno della tabella \"Clienti\" e dalla tabella \"Indirizzi\".", recordCount));
			return recordCount;
		}

		private static int UpdateTable(SqlCeConnection connection, SqlCeTransaction transaction, string tableName, object entityList)
		{
			string ideSql;
			int num;
			if (!WebConfigSettings.SkippedTables.Contains<string>(tableName, StringComparer.OrdinalIgnoreCase))
			{
				LogUtils.Debug(string.Format("Processamento della tabella \"{0}\".", tableName));
				string delSql = string.Format("DELETE\r\n                              FROM {0}", tableName);
				(new SqlCeCommand(delSql, connection, transaction)).ExecuteNonQuery();
				LogUtils.Debug(string.Format("Cancellati i record dalla tabella \"{0}\".", tableName));
				if (WebConfigSettings.IdentityTables.Contains<string>(tableName))
				{
					LogUtils.Debug(string.Format("Abilitato l'inserimento di valori per le colonne di tipo identity nella tabella \"{0}\".", tableName));
					ideSql = string.Format("SET IDENTITY_INSERT {0} ON", tableName);
					(new SqlCeCommand(ideSql, connection, transaction)).ExecuteNonQuery();
				}
				int recordCount = UpdateUtils.InsertIntoTable(connection, transaction, tableName, entityList, new string[0]);
				if (WebConfigSettings.IdentityTables.Contains<string>(tableName))
				{
					ideSql = string.Format("SET IDENTITY_INSERT {0} OFF", tableName);
					(new SqlCeCommand(ideSql, connection, transaction)).ExecuteNonQuery();
				}
				LogUtils.Debug(string.Format("{0} record inseriti all'interno della tabella \"{1}\".", recordCount, tableName));
				num = recordCount;
			}
			else
			{
				num = 0;
			}
			return num;
		}
	}
}