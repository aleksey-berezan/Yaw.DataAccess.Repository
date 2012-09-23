using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Yaw.DataAccess.Repository.Core.Interface
{
	public interface IQuery<TEntity> : IEnumerable<TEntity>
	{
		IQuery<TEntity> Include(Expression<Func<TEntity, object>> path);
		IQuery<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
	}
}