using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Yaw.DataAccess.Repository.Core.Interface;

namespace Yaw.DataAccess.Repository.Implementation.Ef
{
	public abstract class EfRepository<TEntity> : IRepository<TEntity>
		where TEntity : class
	{
		private readonly IDbSet<TEntity> _dbSet;

		public EfRepository(DbContext dbContext)
		{
			_dbSet = dbContext.Set<TEntity>();
		}

		public IQuery<TEntity> QueryOver()
		{
			return new EfQuery<TEntity>(_dbSet);
		}

		public void Add(TEntity entity)
		{
			_dbSet.Add(entity);
		}

		public void Delete(TEntity entity)
		{
			_dbSet.Remove(entity);
		}
	}
}
