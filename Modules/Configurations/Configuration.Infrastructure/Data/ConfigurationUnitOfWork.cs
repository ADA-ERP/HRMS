using System.Collections;
using Shared.Abstractions.DataAccess;
using Shared.Abstractions.Types;

namespace Configuration.Infrastructure.Data
{
    public class ConfigurationUnitOfWork : IUnitOfWork
    {
        private readonly HRMDBContext context;
        private Hashtable repositories;
        public ConfigurationUnitOfWork(HRMDBContext Context)
        {
            context = Context;
        }
        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (repositories is null) repositories = new Hashtable();
            var type = typeof(TEntity).Name;
            if (!repositories.Contains(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)),
                    context);
                repositories.Add(type, repositoryInstance);
            }

            return (IRepository<TEntity>)repositories[type];
        }
    }
}