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
	public class NHibernateFamigliaRepository : NHibernateBaseRepository<Famiglia, string>, IFamigliaRepository, IRepository<Famiglia, string>
	{
		public NHibernateFamigliaRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public IList<Famiglia> GetFromStagione(string codiceStagione)
		{
			var famiglie = 
				from f in base.CurrentSession.Query<Famiglia>()
				join a in base.CurrentSession.Query<Articolo>() on f equals a.Famiglia
				select new { Famiglia = f, Articolo = a };
			if (!string.IsNullOrEmpty(codiceStagione))
			{
				famiglie = 
					from o in famiglie
					where o.Articolo.Stagione.Codice == codiceStagione
					select o;
			}
			return (
				from o in famiglie
				select o.Famiglia into f
				orderby f.Descrizione
				select f).Distinct<Famiglia>().ToList<Famiglia>();
		}

		public IList<Famiglia> GetFromStagioneAndLineaAndGruppo(string codiceStagione, string codiceLinea, string codiceGruppo, TipoCategoria tipoGruppo)
		{
			return this.GetFromStagioneAndLineaAndGruppo(codiceStagione, codiceLinea, codiceGruppo, tipoGruppo, null);
		}

		public IList<Famiglia> GetFromStagioneAndLineaAndGruppo(string codiceStagione, string codiceLinea, string codiceGruppo, TipoCategoria tipoGruppo, string codiceMarchio)
		{
			var famiglie = 
				from f in base.CurrentSession.Query<Famiglia>()
				join a in base.CurrentSession.Query<Articolo>() on f equals a.Famiglia
				select new { Famiglia = f, Articolo = a };
			if (!string.IsNullOrEmpty(codiceMarchio))
			{
				famiglie = 
					from o in famiglie
					where o.Articolo.Marchio.Codice == codiceMarchio
					select o;
			}
			if (!string.IsNullOrEmpty(codiceStagione))
			{
				famiglie = 
					from o in famiglie
					where o.Articolo.Stagione.Codice == codiceStagione
					select o;
			}
			if (!string.IsNullOrEmpty(codiceLinea))
			{
				famiglie = 
					from o in famiglie
					where o.Articolo.Linea.Codice == codiceLinea
					select o;
			}
			if (!string.IsNullOrEmpty(codiceGruppo))
			{
				famiglie = 
					from o in famiglie
					join ac in base.CurrentSession.Query<ArticoloCategoria>() on o.Articolo equals ac.Articolo
					select new { Famiglia = o.Famiglia, Articolo = o.Articolo, Categoria = ac.Categoria } into o2
					where (o2.Categoria.Codice == codiceGruppo) && o2.Categoria.Tipo == tipoGruppo
					select new { Famiglia = o2.Famiglia, Articolo = o2.Articolo };
			}
			return (
				from o in famiglie
				select o.Famiglia into f
				orderby f.Descrizione
				select f).Distinct<Famiglia>().ToList<Famiglia>();
		}
	}
}