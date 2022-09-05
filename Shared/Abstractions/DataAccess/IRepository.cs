


using Shared.Abstractions.Types;
using Shared.Infrastructure.Specification;

namespace Shared.Abstractions.DataAccess
{
    public interface IRepository<T> where T : BaseEntity
    {

        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllListAsync();
        Task<T> GetBySpecificationAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllBySpecification(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        void Add(T entity);
        void Update(T entity, int id);
        void Delete(T entity);
    }
}
