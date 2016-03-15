using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace EW.WebModaNetClassLibrary.Entities
{
	public class OrderByClause<T>
	{
		public bool Ascending
		{
			get;
			set;
		}

		public Expression<Func<object, T>> SortExpression
		{
			get;
			set;
		}

		public OrderByClause(Expression<Func<object, T>> sortExpression, bool ascending)
		{
			this.SortExpression = sortExpression;
			this.Ascending = ascending;
		}

		public OrderByClause(Expression<Func<object, T>> sortExpression)
		{
			this.SortExpression = sortExpression;
			this.Ascending = true;
		}
	}
}