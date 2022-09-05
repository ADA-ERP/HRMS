
using Shared.Abstractions.Types;

namespace Shared.Abstractions.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();

    }
}