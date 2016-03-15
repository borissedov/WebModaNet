using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace EW.WebModaNet.Code
{
	public static class NHibernateHelper
	{
		private const string configurationFile = "configuration.serialized";

		private readonly static Configuration configuration;

		private readonly static ISessionFactory sessionFactory;

		private static string configurationPath
		{
			get
			{
				Assembly assembly = Assembly.GetExecutingAssembly();
				string directory = Path.GetDirectoryName((new Uri(assembly.CodeBase)).LocalPath);
				return string.Concat(directory, Path.DirectorySeparatorChar, "configuration.serialized");
			}
		}

		public static ISessionFactory SessionFactory
		{
			get
			{
				return NHibernateHelper.sessionFactory;
			}
		}

		static NHibernateHelper()
		{
			NHibernateHelper.configuration = (new Configuration()).Configure();
			NHibernateHelper.sessionFactory = NHibernateHelper.configuration.BuildSessionFactory();
		}

		public static void CreateSchema()
		{
			(new SchemaExport(NHibernateHelper.configuration)).Create(false, true);
		}

		public static void DropSchema()
		{
			(new SchemaExport(NHibernateHelper.configuration)).Drop(false, true);
		}

		private static bool IsConfigurationFileValid()
		{
			bool flag;
			if (File.Exists(NHibernateHelper.configurationPath))
			{
				FileInfo configurationInfo = new FileInfo("configuration.serialized");
				Assembly assembly = Assembly.GetExecutingAssembly();
				if (string.IsNullOrEmpty(assembly.Location))
				{
					flag = false;
				}
				else if (!((new FileInfo(assembly.Location)).LastWriteTime > configurationInfo.LastWriteTime))
				{
					string appConfigFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
					flag = (!((new FileInfo("configuration.serialized")).LastWriteTime > configurationInfo.LastWriteTime) ? true : false);
				}
				else
				{
					flag = false;
				}
			}
			else
			{
				flag = false;
			}
			return flag;
		}

		private static Configuration LoadConfigurationFromFile()
		{
			Configuration configuration;
			if (NHibernateHelper.IsConfigurationFileValid())
			{
				try
				{
					FileStream fileStream = File.OpenRead(NHibernateHelper.configurationPath);
					try
					{
						configuration = (new BinaryFormatter()).Deserialize(fileStream) as Configuration;
					}
					finally
					{
						if (fileStream != null)
						{
							((IDisposable)fileStream).Dispose();
						}
					}
				}
				catch (Exception exception)
				{
					configuration = null;
				}
			}
			else
			{
				configuration = null;
			}
			return configuration;
		}

		private static void SaveConfigurationToFile(Configuration configuration)
		{
			FileStream fileStream = File.Open(NHibernateHelper.configurationPath, FileMode.Create);
			try
			{
				(new BinaryFormatter()).Serialize(fileStream, configuration);
			}
			finally
			{
				if (fileStream != null)
				{
					((IDisposable)fileStream).Dispose();
				}
			}
		}

		public static string UpdateSchema()
		{
			SchemaUpdate schema = new SchemaUpdate(NHibernateHelper.configuration);
			StringBuilder stringBuilder = new StringBuilder();
			schema.Execute((string script) => stringBuilder.Append(script), true);
			return stringBuilder.ToString();
		}

		public static void ValidateSchema()
		{
			(new SchemaValidator(NHibernateHelper.configuration)).Validate();
		}
	}
}