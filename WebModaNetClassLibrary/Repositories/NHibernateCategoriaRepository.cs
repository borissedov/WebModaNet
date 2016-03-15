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
	public class NHibernateCategoriaRepository : NHibernateBaseRepository<Categoria, object>, ICategoriaRepository, IRepository<Categoria, object>
	{
		public NHibernateCategoriaRepository(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}

		public IList<Categoria> GetFromTipo(TipoCategoria tipoCategoria)
		{
			return (
				from c in base.CurrentSession.Query<Categoria>()
				where c.Tipo == tipoCategoria
				orderby c.Descrizione
				select c).Distinct<Categoria>().ToList<Categoria>();
		}

		public IList<Categoria> GetFromTipoAndStagione(TipoCategoria tipoCategoria, string codiceStagione)
		{
			return this.GetFromTipoAndStagione(tipoCategoria, codiceStagione, null);
		}

		public IList<Categoria> GetFromTipoAndStagione(TipoCategoria tipoCategoria, string codiceStagione, string codiceMarchio)
		{
			var categorie = 
				from c in base.CurrentSession.Query<Categoria>()
				join ac in base.CurrentSession.Query<ArticoloCategoria>() on c equals ac.Categoria
				select new { Categoria = c, Articolo = ac.Articolo } into o
				where o.Categoria.Tipo == tipoCategoria
				select o;
			if (!string.IsNullOrEmpty(codiceMarchio))
			{
				categorie = 
					from o in categorie
					where o.Articolo.Marchio.Codice == codiceMarchio
					select o;
			}
			if (!string.IsNullOrEmpty(codiceStagione))
			{
				categorie = 
					from o in categorie
					where o.Articolo.Stagione.Codice == codiceStagione
					select o;
			}
			return (
				from o in categorie
				select o.Categoria into c
				orderby c.Descrizione
				select c).Distinct<Categoria>().ToList<Categoria>();
		}

		public IList<Categoria> GetFromTipoAndStagioneAndLinea(TipoCategoria tipoCategoria, string codiceStagione, string codiceLinea)
		{
			return this.GetFromTipoAndStagioneAndLinea(tipoCategoria, codiceStagione, codiceLinea, null);
		}

		public IList<Categoria> GetFromTipoAndStagioneAndLinea(TipoCategoria tipoCategoria, string codiceStagione, string codiceLinea, string codiceMarchio)
		{
			var categorie = 
				from c in base.CurrentSession.Query<Categoria>()
				join ac in base.CurrentSession.Query<ArticoloCategoria>() on c equals ac.Categoria
				select new { Categoria = c, Articolo = ac.Articolo } into o
				where o.Categoria.Tipo == tipoCategoria
				select o;
			if (!string.IsNullOrEmpty(codiceMarchio))
			{
				categorie = 
					from o in categorie
					where o.Articolo.Marchio.Codice == codiceMarchio
					select o;
			}
			if (!string.IsNullOrEmpty(codiceStagione))
			{
				categorie = 
					from o in categorie
					where o.Articolo.Stagione.Codice == codiceStagione
					select o;
			}
			if (!string.IsNullOrEmpty(codiceLinea))
			{
				categorie = 
					from o in categorie
					where o.Articolo.Linea.Codice == codiceLinea
					select o;
			}
			return (
				from o in categorie
				select o.Categoria into c
				orderby c.Descrizione
				select c).Distinct<Categoria>().ToList<Categoria>();
		}

		public IList<Categoria> GetFromTipoAndStagioneAndLineaAndFamiglia(TipoCategoria tipoCategoria, string codiceStagione, string codiceLinea, string codiceFamiglia)
		{
			return this.GetFromTipoAndStagioneAndLineaAndFamiglia(tipoCategoria, codiceStagione, codiceLinea, codiceFamiglia, null);
		}

		public IList<Categoria> GetFromTipoAndStagioneAndLineaAndFamiglia(TipoCategoria tipoCategoria, string codiceStagione, string codiceLinea, string codiceFamiglia, string codiceMarchio)
		{
			var categorie = 
				from c in base.CurrentSession.Query<Categoria>()
				join ac in base.CurrentSession.Query<ArticoloCategoria>() on c equals ac.Categoria
				select new { Categoria = c, Articolo = ac.Articolo } into o
				where o.Categoria.Tipo == tipoCategoria
				select o;
			if (!string.IsNullOrEmpty(codiceMarchio))
			{
				categorie = 
					from o in categorie
					where o.Articolo.Marchio.Codice == codiceMarchio
					select o;
			}
			if (!string.IsNullOrEmpty(codiceStagione))
			{
				categorie = 
					from o in categorie
					where o.Articolo.Stagione.Codice == codiceStagione
					select o;
			}
			if (!string.IsNullOrEmpty(codiceLinea))
			{
				categorie = 
					from o in categorie
					where o.Articolo.Linea.Codice == codiceLinea
					select o;
			}
			if (!string.IsNullOrEmpty(codiceFamiglia))
			{
				categorie = 
					from o in categorie
					where o.Articolo.Famiglia.Codice == codiceFamiglia
					select o;
			}
			return (
				from o in categorie
				select o.Categoria into c
				orderby c.Descrizione
				select c).Distinct<Categoria>().ToList<Categoria>();
		}
	}
}