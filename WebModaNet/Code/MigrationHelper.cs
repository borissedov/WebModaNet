using EW.WebModaNetClassLibrary.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Runtime.CompilerServices;

namespace EW.WebModaNet.Code
{
	public static class MigrationHelper
	{
		private static IDbConnection connection;

		private static bool AddCodiceGestionaleToClienti()
		{
			return MigrationHelper.CheckAndAddColumnToTable("Clienti", "CodiceGestionale", "[CodiceGestionale] [nvarchar](10) NULL");
		}

		private static bool AddCodiceSituazioneToClienti()
		{
			return MigrationHelper.CheckAndAddColumnToTable("Clienti", "CodiceSituazione", "[CodiceSituazione] [int] NULL");
		}

		private static void AddColumnToTable(string tableName, string columnDefinition)
		{
			string commandText = "ALTER TABLE {0}\r\n                                   ADD {1}";
			commandText = string.Format(commandText, tableName, columnDefinition);
			IDbCommand command = MigrationHelper.connection.CreateCommand();
			try
			{
				command.CommandType = CommandType.Text;
				command.CommandText = commandText;
				command.ExecuteNonQuery();
			}
			finally
			{
				if (command != null)
				{
					command.Dispose();
				}
			}
		}

		private static bool AddElaboratoToStatiCliente()
		{
			bool flag;
			string commandText = "SELECT COUNT(Codice)\r\n                                   FROM StatiCliente\r\n                                   WHERE Codice = 'ELA'";
			IDbCommand command = MigrationHelper.connection.CreateCommand();
			try
			{
				command.CommandType = CommandType.Text;
				command.CommandText = commandText;
				bool found = Convert.ToInt32(command.ExecuteScalar()) > 0;
				if (!found)
				{
					commandText = "INSERT INTO\r\n                                    StatiCliente VALUES ('ELA', 'Elaborato')";
					command.CommandText = commandText;
					command.ExecuteNonQuery();
				}
				flag = !found;
			}
			finally
			{
				if (command != null)
				{
					command.Dispose();
				}
			}
			return flag;
		}

		private static bool AddEliminatoToStatiOrdine()
		{
			bool flag;
			string commandText = "SELECT COUNT(Codice)\r\n                                   FROM StatiOrdine\r\n                                   WHERE Codice = 'ELM'";
			IDbCommand command = MigrationHelper.connection.CreateCommand();
			try
			{
				command.CommandType = CommandType.Text;
				command.CommandText = commandText;
				bool found = Convert.ToInt32(command.ExecuteScalar()) > 0;
				if (!found)
				{
					commandText = "INSERT INTO\r\n                                    StatiOrdine VALUES ('ELM', 'Eliminato')";
					command.CommandText = commandText;
					command.ExecuteNonQuery();
				}
				flag = !found;
			}
			finally
			{
				if (command != null)
				{
					command.Dispose();
				}
			}
			return flag;
		}

		private static bool AddExpertwebToAgenti()
		{
			bool flag;
			string commandText = "SELECT COUNT(CodiceUtente)\r\n                                   FROM Agenti\r\n                                   WHERE CodiceUtente = @codiceUtente\r\n                                   AND CodiceTipoAgente = @codiceTipoAgente";
			IDbCommand command = MigrationHelper.connection.CreateCommand();
			try
			{
				command.CommandType = CommandType.Text;
				command.CommandText = commandText;
				command.AddParameterWithValue("codiceUtente", "Expertweb");
				command.AddParameterWithValue("codiceTipoAgente", WebConfigSettings.CodiceTipoAgenteExpertweb);
				bool found = Convert.ToInt32(command.ExecuteScalar()) > 0;
				if (!found)
				{
					commandText = "INSERT INTO Agenti (CodiceUtente, CodiceAgente, RagioneSociale, Password, CodiceTipoAgente, Attivo, CodiceNazione, CodiceLingua)\r\n                                VALUES (@codiceUtente, @codiceAgente, @ragioneSociale, @password, @codiceTipoAgente, @attivo, @codiceNazione, @codiceLingua)";
					command.CommandText = commandText;
					command.Parameters.Clear();
					command.AddParameterWithValue("codiceUtente", "Expertweb");
					command.AddParameterWithValue("codiceAgente", 0);
					command.AddParameterWithValue("ragioneSociale", "Expertweb S.r.l.");
					command.AddParameterWithValue("password", "x32cbt");
					command.AddParameterWithValue("codiceTipoAgente", WebConfigSettings.CodiceTipoAgenteExpertweb);
					command.AddParameterWithValue("attivo", true);
					command.AddParameterWithValue("codiceNazione", WebConfigSettings.CodiceNazioneItalia);
					command.AddParameterWithValue("codiceLingua", WebConfigSettings.CodiceLinguaItaliano);
					command.ExecuteNonQuery();
				}
				flag = !found;
			}
			finally
			{
				if (command != null)
				{
					command.Dispose();
				}
			}
			return flag;
		}

		private static void AddMostraImmaginiNonTrovateToAgenti()
		{
			MigrationHelper.CheckAndAddColumnToTable("Agenti", "MostraImmaginiNonTrovate", "[MostraImmaginiNonTrovate] [bit] NULL");
		}

		private static void AddParameterWithValue(this IDbCommand command, string parameterName, object parameterValue)
		{
			IDbDataParameter parameter = command.CreateParameter();
			parameter.ParameterName = parameterName;
			parameter.Value = parameterValue;
			command.Parameters.Add(parameter);
		}

		private static bool AddTrasmessoToStatiCliente()
		{
			bool flag;
			string commandText = "SELECT COUNT(Codice)\r\n                                   FROM StatiCliente\r\n                                   WHERE Codice = 'TRA'";
			IDbCommand command = MigrationHelper.connection.CreateCommand();
			try
			{
				command.CommandType = CommandType.Text;
				command.CommandText = commandText;
				bool found = Convert.ToInt32(command.ExecuteScalar()) > 0;
				if (!found)
				{
					commandText = "INSERT INTO\r\n                                    StatiCliente VALUES ('TRA', 'Trasmesso')";
					command.CommandText = commandText;
					command.ExecuteNonQuery();
				}
				flag = !found;
			}
			finally
			{
				if (command != null)
				{
					command.Dispose();
				}
			}
			return flag;
		}

		private static bool AddUtilizzaOfflineToAgenti()
		{
			return MigrationHelper.CheckAndAddColumnToTable("Agenti", "UtilizzaOffline", "[UtilizzaOffline] [bit] NULL");
		}

		private static bool AddVarianteToListini()
		{
			bool flag;
			string commandText = "\r\n                select CONSTRAINT_NAME\r\n                from INFORMATION_SCHEMA.TABLE_CONSTRAINTS\r\n                where TABLE_NAME = 'Listini'\r\n                and CONSTRAINT_TYPE = 'PRIMARY KEY'";
			string pkName = null;
			IDbCommand command = MigrationHelper.connection.CreateCommand();
			try
			{
				command.CommandType = CommandType.Text;
				command.CommandText = commandText;
				try
				{
					pkName = command.ExecuteScalar().ToString();
				}
				catch
				{
					flag = false;
					return flag;
				}
			}
			finally
			{
				if (command != null)
				{
					command.Dispose();
				}
			}
			if (string.IsNullOrEmpty(pkName))
			{
				flag = false;
			}
			else
			{
				string sql = "\r\n                    alter table Listini\r\n                    add CodiceVariante NVARCHAR(50);\r\n\r\n                    alter table Listini\r\n                    DROP CONSTRAINT {0};\r\n\r\n                    alter table Listini\r\n                    ADD PRIMARY KEY (Codice, CodiceArticolo, CodiceVariante, DataInizioValidita, DataFineValidita)";
				sql = string.Format(sql, pkName);
				command = MigrationHelper.connection.CreateCommand();
				try
				{
					command.CommandType = CommandType.Text;
					command.CommandText = sql;
					try
					{
						command.ExecuteNonQuery();
						flag = true;
					}
					catch
					{
						flag = false;
					}
				}
				finally
				{
					if (command != null)
					{
						command.Dispose();
					}
				}
			}
			return flag;
		}

		private static bool AlterVariantiCodice()
		{
			bool flag;
			string commandText = "\r\n                ALTER TABLE Varianti\r\n                ALTER COLUMN Codice VARCHAR(50) NOT NULL";
			IDbCommand command = MigrationHelper.connection.CreateCommand();
			try
			{
				command.CommandType = CommandType.Text;
				command.CommandText = commandText;
				try
				{
					command.ExecuteNonQuery();
					flag = true;
				}
				catch (Exception exception)
				{
					LogUtils.Error(string.Concat("Errore AlterVariantiCodice: ", exception.Message));
					flag = false;
				}
			}
			finally
			{
				if (command != null)
				{
					command.Dispose();
				}
			}
			return flag;
		}

		private static bool CheckAndAddColumnToTable(string tableName, string columnName, string columnDefinition)
		{
			bool tableHasColumn = MigrationHelper.TableHasColumn(tableName, columnName);
			if (!tableHasColumn)
			{
				MigrationHelper.AddColumnToTable(tableName, columnDefinition);
			}
			return !tableHasColumn;
		}

		private static bool CheckAndDropArticoliImballiAndImballi()
		{
			string tableName = "ArticoliImballi";
			string columnName = "CodiceVariante";
			string commandText = "SELECT COUNT(*)\r\n                                   FROM ArticoliImballi";
			bool executed = false;
			IDbCommand command = MigrationHelper.connection.CreateCommand();
			try
			{
				command.CommandType = CommandType.Text;
				command.CommandText = commandText;
				if (Convert.ToInt32(command.ExecuteScalar()) == 0)
				{
					if (!MigrationHelper.TableHasColumn(tableName, columnName))
					{
						MigrationHelper.DropTable(tableName);
						MigrationHelper.DropTable("Imballi");
						executed = true;
					}
				}
			}
			finally
			{
				if (command != null)
				{
					command.Dispose();
				}
			}
			return executed;
		}

		private static bool DeleteAziendaFromTipiAgente()
		{
			bool flag;
			string commandText = "DELETE FROM TipiAgente\r\n                                   WHERE Codice = @codiceAzienda";
			IDbCommand command = MigrationHelper.connection.CreateCommand();
			try
			{
				command.CommandType = CommandType.Text;
				command.CommandText = commandText;
				command.AddParameterWithValue("codiceAzienda", "AZ");
				flag = command.ExecuteNonQuery() > 0;
			}
			finally
			{
				if (command != null)
				{
					command.Dispose();
				}
			}
			return flag;
		}

		private static bool DropConstraintArticoliImballi()
		{
			bool flag;
			string commandText = "ALTER TABLE ArticoliImballi\r\n                                   DROP CONSTRAINT FK495675BD91E2342C";
			IDbCommand command = MigrationHelper.connection.CreateCommand();
			try
			{
				command.CommandType = CommandType.Text;
				command.CommandText = commandText;
				try
				{
					command.ExecuteNonQuery();
					flag = true;
				}
				catch
				{
					flag = false;
				}
			}
			finally
			{
				if (command != null)
				{
					command.Dispose();
				}
			}
			return flag;
		}

		private static bool DropConstraintArticoliImballi2()
		{
			bool flag;
			string commandText = "ALTER TABLE ArticoliImballi\r\n                                   DROP CONSTRAINT FK495675BDD5ECBE23";
			IDbCommand command = MigrationHelper.connection.CreateCommand();
			try
			{
				command.CommandType = CommandType.Text;
				command.CommandText = commandText;
				try
				{
					command.ExecuteNonQuery();
					flag = true;
				}
				catch
				{
					flag = false;
				}
			}
			finally
			{
				if (command != null)
				{
					command.Dispose();
				}
			}
			return flag;
		}

		private static bool DropConstraintImballi()
		{
			bool flag;
			string commandText = "ALTER TABLE Imballi\r\n                                   DROP CONSTRAINT FK_ArticoliImballi_Segnataglie";
			IDbCommand command = MigrationHelper.connection.CreateCommand();
			try
			{
				command.CommandType = CommandType.Text;
				command.CommandText = commandText;
				try
				{
					command.ExecuteNonQuery();
					flag = true;
				}
				catch
				{
					flag = false;
				}
			}
			finally
			{
				if (command != null)
				{
					command.Dispose();
				}
			}
			return flag;
		}

		private static void DropTable(string tableName)
		{
			string commandText = "DROP TABLE {0}";
			commandText = string.Format(commandText, tableName);
			IDbCommand command = MigrationHelper.connection.CreateCommand();
			try
			{
				command.CommandType = CommandType.Text;
				command.CommandText = commandText;
				command.ExecuteNonQuery();
			}
			finally
			{
				if (command != null)
				{
					command.Dispose();
				}
			}
		}

		private static IList<string> GetColumnNames(IDataReader dataReader)
		{
			List<string> columnNames = new List<string>();
			foreach (DataRow row in dataReader.GetSchemaTable().Rows)
			{
				columnNames.Add(row[0].ToString());
			}
			return columnNames;
		}

		public static void Init(IDbConnection concreteConnection)
		{
			try
			{
				MigrationHelper.connection = concreteConnection;
				IDbConnection dbConnection = MigrationHelper.connection;
				try
				{
					int migrationCount = MigrationHelper.RunMigrations();
					LogUtils.Debug(string.Format("Migrazioni completate correttamente. Numero di migrazioni effettuate: {0}.", migrationCount));
				}
				finally
				{
					if (dbConnection != null)
					{
						dbConnection.Dispose();
					}
				}
			}
			catch (Exception exception)
			{
				LogUtils.Error("Errore durante l'esecuzione delle migrazioni.", exception);
			}
		}

		[Obsolete]
		public static void Init(string connectionString, DbConnectionType connectionType)
		{
			try
			{
				switch (connectionType)
				{
					case DbConnectionType.SqlServer:
					{
						MigrationHelper.connection = new SqlConnection(connectionString);
						break;
					}
					case DbConnectionType.SqlServerCe:
					{
						MigrationHelper.connection = new SqlCeConnection(connectionString);
						break;
					}
					default:
					{
						goto case DbConnectionType.SqlServer;
					}
				}
				IDbConnection dbConnection = MigrationHelper.connection;
				try
				{
					MigrationHelper.connection.Open();
					int migrationCount = MigrationHelper.RunMigrations();
					LogUtils.Debug(string.Format("Migrazioni completate correttamente. Numero di migrazioni effettuate: {0}.", migrationCount));
				}
				finally
				{
					if (dbConnection != null)
					{
						dbConnection.Dispose();
					}
				}
			}
			catch (Exception exception)
			{
				LogUtils.Error("Errore durante l'esecuzione delle migrazioni.", exception);
			}
		}

		private static int RunMigrations()
		{
			return 0 + (MigrationHelper.DeleteAziendaFromTipiAgente() ? 1 : 0) + (MigrationHelper.AddEliminatoToStatiOrdine() ? 1 : 0) + (MigrationHelper.AddExpertwebToAgenti() ? 1 : 0) + (MigrationHelper.AddCodiceSituazioneToClienti() ? 1 : 0) + (MigrationHelper.AddUtilizzaOfflineToAgenti() ? 1 : 0) + (MigrationHelper.AddCodiceGestionaleToClienti() ? 1 : 0) + (MigrationHelper.AddTrasmessoToStatiCliente() ? 1 : 0) + (MigrationHelper.AddElaboratoToStatiCliente() ? 1 : 0) + (MigrationHelper.CheckAndDropArticoliImballiAndImballi() ? 1 : 0) + (MigrationHelper.DropConstraintImballi() ? 1 : 0) + (MigrationHelper.DropConstraintArticoliImballi() ? 1 : 0) + (MigrationHelper.DropConstraintArticoliImballi2() ? 1 : 0) + (MigrationHelper.AddVarianteToListini() ? 1 : 0) + (MigrationHelper.AlterVariantiCodice() ? 1 : 0);
		}

		private static bool TableHasColumn(string tableName, string columnName)
		{
			bool flag;
			bool tableHasColumn = false;
			string commandText = string.Format("SELECT TOP 1 * FROM {0} WHERE 1 = 0", tableName);
			IDbCommand command = MigrationHelper.connection.CreateCommand();
			try
			{
				command.CommandType = CommandType.Text;
				command.CommandText = commandText;
				IDataReader dataReader = command.ExecuteReader();
				try
				{
					tableHasColumn = MigrationHelper.GetColumnNames(dataReader).Contains(columnName);
				}
				finally
				{
					if (dataReader != null)
					{
						dataReader.Dispose();
					}
				}
				flag = tableHasColumn;
			}
			finally
			{
				if (command != null)
				{
					command.Dispose();
				}
			}
			return flag;
		}
	}
}