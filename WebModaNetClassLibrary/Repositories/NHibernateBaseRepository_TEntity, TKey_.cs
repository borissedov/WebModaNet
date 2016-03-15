using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace EW.WebModaNetClassLibrary.Repositories
{
	public abstract class NHibernateBaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
	{
		protected readonly ISessionFactory SessionFactory;

		protected ISession CurrentSession
		{
			get
			{
				return this.SessionFactory.GetCurrentSession();
			}
		}

		public NHibernateBaseRepository(ISessionFactory sessionFactory)
		{
			this.SessionFactory = sessionFactory;
		}

		public int CountAll(params Expression<Func<TEntity, bool>>[] predicates)
		{
			int num;
			using (ITransaction transaction = this.CurrentSession.BeginTransaction())
			{
				IQueryable<TEntity> entities = this.CurrentSession.Query<TEntity>();
				if (predicates != null && (int)predicates.Length > 0)
				{
					Expression<Func<TEntity, bool>>[] expressionArray = predicates;
					for (int i = 0; i < (int)expressionArray.Length; i++)
					{
						entities = entities.Where<TEntity>(expressionArray[i]);
					}
				}
				transaction.Commit();
				num = entities.Count<TEntity>();
			}
			return num;
		}

		public virtual void Create(TEntity entity)
		{
			using (ITransaction transaction = this.CurrentSession.BeginTransaction())
			{
				this.CurrentSession.Save(entity);
				transaction.Commit();
			}
		}

		public virtual void Delete(TEntity entity)
		{
			using (ITransaction transaction = this.CurrentSession.BeginTransaction())
			{
				this.CurrentSession.Delete(entity);
				transaction.Commit();
			}
		}

		public virtual void Delete(IEnumerable<TEntity> entities)
		{
			using (ITransaction transaction = this.CurrentSession.BeginTransaction())
			{
				foreach (TEntity entity in entities)
				{
					this.CurrentSession.Delete(entity);
				}
				transaction.Commit();
			}
		}

		public TEntity Find(object id)
		{
			TEntity tEntity;
			using (ITransaction transaction = this.CurrentSession.BeginTransaction())
			{
				TEntity entity = this.CurrentSession.Get<TEntity>(id);
				transaction.Commit();
				tEntity = entity;
			}
			return tEntity;
		}

		public IList<TEntity> FindAll()
		{
			return this.FindAll(new Expression<Func<TEntity, bool>>[0]);
		}

		public IList<TEntity> FindAll(params Expression<Func<TEntity, bool>>[] predicates)
		{
			IList<TEntity> list;
			using (ITransaction transaction = this.CurrentSession.BeginTransaction())
			{
				IQueryable<TEntity> entities = this.CurrentSession.Query<TEntity>();
				if (predicates != null && (int)predicates.Length > 0)
				{
					Expression<Func<TEntity, bool>>[] expressionArray = predicates;
					for (int i = 0; i < (int)expressionArray.Length; i++)
					{
						entities = entities.Where<TEntity>(expressionArray[i]);
					}
				}
				transaction.Commit();
				list = entities.ToList<TEntity>();
			}
			return list;
		}

		public IList<TEntity> FindAll(bool ascending, params Expression<Func<TEntity, object>>[] orderByClauses)
		{
			return this.FindAll((Expression<Func<TEntity, bool>>[])null, ascending, orderByClauses);
		}

		public IList<TEntity> FindAll(bool ascending, Expression<Func<TEntity, object>> orderByClause, params Expression<Func<TEntity, bool>>[] predicates)
		{
			Expression<Func<TEntity, object>>[] expressionArray = new Expression<Func<TEntity, object>>[] { orderByClause };
			return this.FindAll(predicates, ascending, expressionArray);
		}

		public IList<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, bool ascending, params Expression<Func<TEntity, object>>[] orderByClauses)
		{
			Expression<Func<TEntity, bool>>[] expressionArray = new Expression<Func<TEntity, bool>>[] { predicate };
			return this.FindAll(expressionArray, ascending, orderByClauses);
		}

		public IList<TEntity> FindAll(Expression<Func<TEntity, bool>>[] predicates, bool ascending, Expression<Func<TEntity, object>>[] orderByClauses)
		{
			IList<TEntity> list;
			using (ITransaction transaction = this.CurrentSession.BeginTransaction())
			{
				IQueryable<TEntity> entities = this.CurrentSession.Query<TEntity>();
				if (predicates != null && (int)predicates.Length > 0)
				{
					for (int i = 0; i < (int)predicates.Length; i++)
					{
						entities = entities.Where<TEntity>(predicates[i]);
					}
				}
				if (orderByClauses != null && (int)orderByClauses.Length > 0)
				{
					for (int i = 0; i < (int)orderByClauses.Length; i++)
					{
						Expression<Func<TEntity, object>> clause = orderByClauses[i];
						if (i != 0)
						{
							entities = (!ascending ? ((IOrderedQueryable<TEntity>)entities).ThenByDescending<TEntity, object>(clause) : ((IOrderedQueryable<TEntity>)entities).ThenBy<TEntity, object>(clause));
						}
						else
						{
							entities = (!ascending ? entities.OrderByDescending<TEntity, object>(clause) : entities.OrderBy<TEntity, object>(clause));
						}
					}
				}
				transaction.Commit();
				list = entities.ToList<TEntity>();
			}
			return list;
		}

		public virtual IList<TEntity> GetAll()
		{
			return this.GetAll(new Expression<Func<TEntity, bool>>[0], new string[0]);
		}

		public virtual IList<TEntity> GetAll(params Expression<Func<TEntity, bool>>[] predicates)
		{
			return this.GetAll(predicates, new string[0]);
		}

		public virtual IList<TEntity> GetAll(params string[] sortFields)
		{
			return this.GetAll(new Expression<Func<TEntity, bool>>[0], sortFields);
		}

		public virtual IList<TEntity> GetAll(Expression<Func<TEntity, bool>>[] predicates, string[] sortFields)
		{
			IList<TEntity> list;
			using (ITransaction transaction = this.CurrentSession.BeginTransaction())
			{
				IQueryable<TEntity> entities = this.CurrentSession.Query<TEntity>();
				if (predicates != null)
				{
					Expression<Func<TEntity, bool>>[] expressionArray = predicates;
					for (int i = 0; i < (int)expressionArray.Length; i++)
					{
						entities = entities.Where<TEntity>(expressionArray[i]);
					}
				}
				if (sortFields != null)
				{
					string[] strArrays = sortFields;
					for (int j = 0; j < (int)strArrays.Length; j++)
					{
						string sortField = strArrays[j];
						string[] elements = sortField.Split(new char[] { ' ' });
						string field = elements[0];
						bool descending = false;
						if ((int)elements.Length >= 2)
						{
							descending = elements[1].Equals("desc", StringComparison.OrdinalIgnoreCase);
						}
						if (typeof(TEntity).GetProperty(field) != null)
						{
							ParameterExpression parameter = Expression.Parameter(typeof(TEntity), field);
							UnaryExpression body = Expression.Convert(Expression.Property(parameter, field), typeof(object));
							ParameterExpression[] parameterExpressionArray = new ParameterExpression[] { parameter };
							Expression<Func<TEntity, object>> lambda = Expression.Lambda<Func<TEntity, object>>(body, parameterExpressionArray);
							entities = (!descending ? entities.OrderBy<TEntity, object>(lambda) : entities.OrderByDescending<TEntity, object>(lambda));
						}
					}
				}
				transaction.Commit();
				list = entities.ToList<TEntity>();
			}
			return list;
		}

		public IList<TEntity> GetAll(Expression<Func<TEntity, bool>>[] predicates, Expression<Func<TEntity, object>>[] sortFields, bool descending)
		{
			IList<TEntity> list;
			using (ITransaction transaction = this.CurrentSession.BeginTransaction())
			{
				IQueryable<TEntity> entities = this.CurrentSession.Query<TEntity>();
				if (predicates != null)
				{
					Expression<Func<TEntity, bool>>[] expressionArray = predicates;
					for (int i = 0; i < (int)expressionArray.Length; i++)
					{
						Expression<Func<TEntity, bool>> predicate = expressionArray[i];
						if (predicate != null)
						{
							entities = entities.Where<TEntity>(predicate);
						}
					}
				}
				if (sortFields != null)
				{
					Expression<Func<TEntity, object>>[] expressionArray1 = sortFields;
					for (int j = 0; j < (int)expressionArray1.Length; j++)
					{
						Expression<Func<TEntity, object>> sortField = expressionArray1[j];
						if (sortField != null)
						{
							entities = (!descending ? entities.OrderBy<TEntity, object>(sortField) : entities.OrderByDescending<TEntity, object>(sortField));
						}
					}
				}
				transaction.Commit();
				list = entities.ToList<TEntity>();
			}
			return list;
		}

		public IList<TEntity> GetAll(params Expression<Func<TEntity, object>>[] sortFields)
		{
			throw new NotImplementedException();
		}

		public virtual TEntity GetById(TKey id)
		{
			TEntity tEntity;
			using (ITransaction transaction = this.CurrentSession.BeginTransaction())
			{
				TEntity entity = this.CurrentSession.Get<TEntity>(id);
				transaction.Commit();
				tEntity = entity;
			}
			return tEntity;
		}

		public virtual void Save(TEntity entity)
		{
			using (ITransaction transaction = this.CurrentSession.BeginTransaction())
			{
				this.CurrentSession.SaveOrUpdate(entity);
				transaction.Commit();
			}
		}

		public void Save(IEnumerable<TEntity> entities)
		{
			using (ITransaction transaction = this.CurrentSession.BeginTransaction())
			{
				foreach (TEntity entity in entities)
				{
					this.CurrentSession.SaveOrUpdate(entity);
				}
				transaction.Commit();
			}
		}
	}
}