using CommonServiceLocator.NinjectAdapter;
using EW.WebModaNet.Code;
using EW.WebModaNet.Modules;
using EW.WebModaNetClassLibrary.Utils;
using log4net.Config;
using Microsoft.Practices.ServiceLocation;
using NHibernate;
using NHibernate.Context;
using Ninject;
using Ninject.Modules;
using Ninject.Web;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Routing;
using System.Web.SessionState;

namespace EW.WebModaNet
{
	public class Global : NinjectHttpApplication
	{
		public Global()
		{
		}

		private void Application_BeginRequest(object sender, EventArgs e)
		{
			CurrentSessionContext.Bind(NHibernateHelper.SessionFactory.OpenSession());
		}

		private void Application_EndRequest(object sender, EventArgs e)
		{
			CurrentSessionContext.Unbind(NHibernateHelper.SessionFactory).Dispose();
		}

		private void Application_Error(object sender, EventArgs e)
		{
			if ((WebConfigSettings.DebugMode ? false : base.Server.GetLastError() != null))
			{
				HttpException httpException = (HttpException)base.Server.GetLastError();
				if (httpException.ErrorCode == 404)
				{
					LogUtils.Warn("Pagina non trovata.", httpException);
				}
				else
				{
					LogUtils.Fatal("Errore fatale.", httpException);
				}
				if (httpException.GetBaseException() != null)
				{
					base.Session[WebConfigSettings.ApplicationErrorMessageSessionKey] = httpException.GetBaseException().Message;
				}
			}
		}

		private void ConfigureLog4Net()
		{
			XmlConfigurator.Configure();
		}

		protected override IKernel CreateKernel()
		{
			WebModule module = new WebModule(NHibernateHelper.SessionFactory);
			StandardKernel standardKernel = new StandardKernel(new INinjectModule[] { module });
			ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(standardKernel));
			return standardKernel;
		}

		protected override void OnApplicationEnded()
		{
			base.OnApplicationEnded();
		}

		protected override void OnApplicationStarted()
		{
			base.OnApplicationStarted();
			this.ConfigureLog4Net();
			try
			{
				NHibernateHelper.ValidateSchema();
			}
			catch
			{
				MigrationHelper.Init(NHibernateHelper.SessionFactory.OpenSession().Connection);
				LogUtils.Info(string.Format("Aggiornamento automatico del database terminato. Script eseguito: {0}", NHibernateHelper.UpdateSchema()));
			}
			this.RegisterRoutes(RouteTable.Routes);
		}

		private void RegisterRoutes(RouteCollection routes)
		{
			RouteValueDictionary routeValueDictionaries = new RouteValueDictionary()
			{
				{ "loginNeutro", true }
			};
			routes.MapPageRoute("LoginNeutro", "Accesso", "~/Login.aspx", false, routeValueDictionaries);
		}

		private void Session_End(object sender, EventArgs e)
		{
		}

		private void Session_Start(object sender, EventArgs e)
		{
		}
	}
}