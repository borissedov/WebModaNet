using EW.WebModaNetClassLibrary.Entities;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public class NHibernateStagioneRepository : NHibernateBaseRepository<Stagione, string>, IStagioneRepository, IRepository<Stagione, string>
	{
		public NHibernateStagioneRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public IList<Stagione> GetAll(Agente agente, Marchio marchio, TipoOrdine tipoOrdine, DateTime dataOrdine)
		{
			IQueryable<ImpostazioneStagione> impostazioniOrdine = base.CurrentSession.Query<ImpostazioneStagione>();
			IQueryable<DataConsegnaOrdine> dateConsegnaOrdine = base.CurrentSession.Query<DataConsegnaOrdine>();
			var stagioniAgente = 
				from s in base.CurrentSession.Query<Stagione>()
				join i in impostazioniOrdine on s equals i.Stagione
				select new { Stagione = s, ImpostazioneOrdine = i } into o
				where o.ImpostazioneOrdine.Agente == agente
				select o;
			var stagioniAgenteDateConsegna = 
				from o in stagioniAgente
				join d in dateConsegnaOrdine on o.Stagione equals d.Stagione
				select new { Stagione = o.Stagione, ImpostazioneOrdine = o.ImpostazioneOrdine, DataConsegnaOrdine = d } into o
				where o.DataConsegnaOrdine.TipoOrdine == tipoOrdine && (o.DataConsegnaOrdine.DataInizioOrdine <= dataOrdine) && (o.DataConsegnaOrdine.DataFineOrdine >= dataOrdine)
				select o;
			return (
				from o in stagioniAgenteDateConsegna
				select o.Stagione into s
				orderby s.Codice descending
				select s).Distinct<Stagione>().ToList<Stagione>();
		}
	}
}