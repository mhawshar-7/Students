using CoreData.Entities;

namespace CoreData.Interfaces
{
	public interface IUnitOfWork
	{
		IGenericRepository<TEntity> Repository<TEntity>() where TEntity: BaseEntity;
		Task<int> Complete();
	}
}
