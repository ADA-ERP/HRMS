

using Microsoft.EntityFrameworkCore;
using Shared.Abstractions.DataAccess;
using Shared.Abstractions.Types;
using Shared.Infrastructure.Specification;

namespace Shared.Infrastructure.Data
{
    public class GenericRepository<TEntity,T> : IRepository<TEntity> where  TEntity : BaseEntity where T:DbContext
    {
        private readonly T context;
        public GenericRepository(T context)
        {
            this.context = context;

        }
        public async Task Save(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
           return await this.context.Set<TEntity>().FindAsync(id);
        }
        public async Task Update(TEntity entity, int id)
        {
            this.context.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<TEntity>> GetAllBySpecification(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllListAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetBySpecificationAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return SpecificationEvaluator<TEntity>.GetQuery(this.context.Set<TEntity>().AsQueryable(), spec);
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        void IRepository<TEntity>.Update(TEntity entity, int id)
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        
    }
}
