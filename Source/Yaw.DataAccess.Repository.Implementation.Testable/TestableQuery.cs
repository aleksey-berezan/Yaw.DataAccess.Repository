using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Yaw.DataAccess.Repository.Core.Interface;

namespace Yaw.DataAccess.Repository.Implementation.Testable
{
	public class TestableQuery<TEntity> : IQuery<TEntity>
	{
		private readonly List<TEntity> _allEntities;
		private List<TEntity> _entitiesToReturn;

		public List<string> IncludedMembers { get; private set; }

		public TestableQuery(List<TEntity> allEntities)
		{
			_allEntities = allEntities;
			_entitiesToReturn = _allEntities.ToList();
			IncludedMembers = new List<string>();
		}

		public virtual IEnumerator<TEntity> GetEnumerator()
		{
			return _allEntities.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public virtual IQuery<TEntity> Include(Expression<Func<TEntity, object>> path)
		{
			var expression = (MemberExpression)path.Body;
			string memberName = expression.Member.Name;
			IncludedMembers.Add(memberName);

			return this;
		}

		public virtual IQuery<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
		{
			var compiledPredicate = predicate.Compile();
			_entitiesToReturn = _entitiesToReturn.Where(compiledPredicate).ToList();
			return this;
		}
	}
}