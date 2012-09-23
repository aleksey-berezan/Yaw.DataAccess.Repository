using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading.Tasks;
using Yaw.DataAccess.Repository.Core.Interface;

namespace Yaw.DataAccess.Repository.Implementation.Testable
{
	public class TestableRepository<TEntity> : IRepository<TEntity>
	{
		public List<TEntity> Entities { get; private set; }
		public List<TEntity> DeletedEntities { get; private set; }
		public List<TEntity> AddedEntities { get; private set; }

		public TestableRepository()
			: this(new List<TEntity>())
		{
		}

		public TestableRepository(List<TEntity> entities)
		{
			Entities = entities;
			DeletedEntities = new List<TEntity>();
			AddedEntities = new List<TEntity>();
		}

		public virtual IQuery<TEntity> QueryOver()
		{
			return new TestableQuery<TEntity>(Entities);
		}

		public virtual void Add(TEntity entity)
		{
			Entities.Add(entity);
			AddedEntities.Add(entity);
		}

		public virtual void Delete(TEntity entity)
		{
			Entities.Remove(entity);
			DeletedEntities.Add(entity);
		}
	}
}