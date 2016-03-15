using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public interface IRepository<TEntity, TKey>
	{
		int CountAll(params Expression<Func<TEntity, bool>>[] predicates);

		void Create(TEntity entity);

		void Delete(TEntity entity);

		void Delete(IEnumerable<TEntity> entities);

		TEntity Find(object id);

		IList<TEntity> FindAll();

		IList<TEntity> FindAll(params Expression<Func<TEntity, bool>>[] predicates);

		IList<TEntity> FindAll(bool ascending, params Expression<Func<TEntity, object>>[] orderByClauses);

		IList<TEntity> FindAll(bool ascending, Expression<Func<TEntity, object>> orderByClause, params Expression<Func<TEntity, bool>>[] predicates);

		IList<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, bool ascending, params Expression<Func<TEntity, object>>[] orderByClauses);

		IList<TEntity> FindAll(Expression<Func<TEntity, bool>>[] predicates, bool ascending, Expression<Func<TEntity, object>>[] orderByClauses);

		IList<TEntity> GetAll();

		IList<TEntity> GetAll(params Expression<Func<TEntity, bool>>[] predicates);

		IList<TEntity> GetAll(params string[] sortFields);

		IList<TEntity> GetAll(Expression<Func<TEntity, bool>>[] predicates, string[] sortFields);

		IList<TEntity> GetAll(Expression<Func<TEntity, bool>>[] predicates, Expression<Func<TEntity, object>>[] sortFields, bool descending);

		TEntity GetById(TKey id);

		void Save(TEntity entity);

		void Save(IEnumerable<TEntity> entities);
	}
}