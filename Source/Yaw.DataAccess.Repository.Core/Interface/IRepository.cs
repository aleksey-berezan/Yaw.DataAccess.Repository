namespace Yaw.DataAccess.Repository.Core.Interface
{
	public interface IRepository<TEntity>
	{
		IQuery<TEntity> QueryOver();

		void Add(TEntity entity);
		void Delete(TEntity entity);
	}
}