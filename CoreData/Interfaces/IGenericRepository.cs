
using CoreData.Entities;

namespace CoreData.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
		void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}