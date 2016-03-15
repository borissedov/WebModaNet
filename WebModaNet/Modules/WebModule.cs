using EW.WebModaNetClassLibrary.Entities;
using EW.WebModaNetClassLibrary.Repositories;
using NHibernate;
using Ninject.Modules;
using Ninject.Syntax;
using System;

namespace EW.WebModaNet.Modules
{
	public class WebModule : NinjectModule
	{
		private readonly ISessionFactory sessionFactory;

		public WebModule(ISessionFactory sessionFactory)
		{
			this.sessionFactory = sessionFactory;
		}

		public override void Load()
		{
			base.Bind<ISessionFactory>().ToConstant(this.sessionFactory);
			base.Bind<IClienteRepository>().To<NHibernateClienteRepository>();
			base.Bind<IAgenteRepository>().To<NHibernateAgenteRepository>();
			base.Bind<IStagioneRepository>().To<NHibernateStagioneRepository>();
			base.Bind<IRepository<TipoAgente, string>>().To<NHibernateGenericRepository<TipoAgente, string>>();
			base.Bind<IListinoRepository>().To<NHibernateListinoRepository>();
			base.Bind<IRepository<Marchio, string>>().To<NHibernateGenericRepository<Marchio, string>>();
			base.Bind<IRepository<Nazione, string>>().To<NHibernateGenericRepository<Nazione, string>>();
			base.Bind<IRepository<Lingua, string>>().To<NHibernateGenericRepository<Lingua, string>>();
			base.Bind<IRepository<TipoOrdine, int>>().To<NHibernateGenericRepository<TipoOrdine, int>>();
			base.Bind<IOrdineRepository>().To<NHibernateOrdineRepository>();
			base.Bind<IRepository<MetodoPagamento, string>>().To<NHibernateGenericRepository<MetodoPagamento, string>>();
			base.Bind<IArticoloRepository>().To<NHibernateArticoloRepository>();
			base.Bind<ILineaRepository>().To<NHibernateLineaRepository>();
			base.Bind<IRepository<Provincia, string>>().To<NHibernateGenericRepository<Provincia, string>>();
			base.Bind<IRepository<Porto, int>>().To<NHibernateGenericRepository<Porto, int>>();
			base.Bind<IRepository<Trasporto, int>>().To<NHibernateGenericRepository<Trasporto, int>>();
			base.Bind<IRepository<Vettore, int>>().To<NHibernateGenericRepository<Vettore, int>>();
			base.Bind<IRepository<StatoOrdine, string>>().To<NHibernateGenericRepository<StatoOrdine, string>>();
			base.Bind<IIndirizzoRepository>().To<NHibernateIndirizzoRepository>();
			base.Bind<IRepository<Valuta, string>>().To<NHibernateGenericRepository<Valuta, string>>();
			base.Bind<IRepository<Variante, object>>().To<NHibernateGenericRepository<Variante, object>>();
			base.Bind<IImpostazioneApplicazioneRepository>().To<NHibernateImpostazioneApplicazioneRepository>();
			base.Bind<IDettaglioOrdineRepository>().To<NHibernateDettaglioOrdineRepository>();
			base.Bind<IRepository<CodiceABarre, string>>().To<NHibernateGenericRepository<CodiceABarre, string>>();
			base.Bind<IDataConsegnaOrdineRepository>().To<NHibernateDataConsegnaOrdineRepository>();
			base.Bind<ICondizioneCommercialeRepository>().To<NHibernateCondizioneCommercialeRepository>();
			base.Bind<IFamigliaRepository>().To<NHibernateFamigliaRepository>();
			base.Bind<IRepository<ListinoCliente, int>>().To<NHibernateGenericRepository<ListinoCliente, int>>();
			base.Bind<IRepository<PoliticaSconti, int>>().To<NHibernateGenericRepository<PoliticaSconti, int>>();
			base.Bind<IRepository<DettaglioPoliticaSconti, int>>().To<NHibernateGenericRepository<DettaglioPoliticaSconti, int>>();
			base.Bind<IRepository<Segnataglie, string>>().To<NHibernateGenericRepository<Segnataglie, string>>();
			base.Bind<IRepository<StatoCliente, string>>().To<NHibernateGenericRepository<StatoCliente, string>>();
			base.Bind<ICategoriaRepository>().To<NHibernateCategoriaRepository>();
			base.Bind<IRepository<TipoCategoria, int>>().To<NHibernateGenericRepository<TipoCategoria, int>>();
			base.Bind<IRepository<ArticoloCategoria, object>>().To<NHibernateGenericRepository<ArticoloCategoria, object>>();
			base.Bind<IAggiornamentoDatabaseRepository>().To<NHibernateAggiornamentoDatabaseRepository>();
			base.Bind<IRepository<Imballo, string>>().To<NHibernateGenericRepository<Imballo, string>>();
			base.Bind<IRepository<VisibilitaCliente, object>>().To<NHibernateGenericRepository<VisibilitaCliente, object>>();
			base.Bind<IImballoRepository>().To<NHibernateImballoRepository>();
			base.Bind<IPromozioneRepository>().To<NHibernatePromozioneRepository>();
			base.Bind<IDocumentoRepository>().To<NHibernateDocumentoRepository>();
		}
	}
}