using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using Yaw.DataAccess.Repository.Core.Interface;

namespace Yaw.DataAccess.Repository.Implementation.Ef
{
	public class EfQuery<TEntity> : IQuery<TEntity>
		where TEntity : class
	{
		private readonly IDbSet<TEntity> _dbSet;

		public EfQuery(IDbSet<TEntity> dbSet)
		{
			_dbSet = dbSet;
		}

		public IEnumerable<TEntity> List()
		{
			return _dbSet.AsEnumerable();
		}

		public IQuery<TEntity> Include(Expression<Func<TEntity, object>> path)
		{
			Contract.Requires(path != null);

			_dbSet.Include(path);
			return this;
		}

		public IQuery<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
		{
			Contract.Requires(predicate != null);
			_dbSet.Where(predicate);

			return this;
		}

		public IEnumerator<TEntity> GetEnumerator()
		{
			return _dbSet.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}