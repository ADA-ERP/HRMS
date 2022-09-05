

using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shared.Abstractions.DataAccess;
using Shared.Abstractions.Types;
using Shared.Infrastructure.Data;
using Shared.Infrastructure.Specification;

namespace Configuration.Infrastructure.Data
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly HRMDBContext context;
        public GenericRepository(HRMDBContext context)
        {
            this.context = context;

        }
        public async Task Save(T entity)
        {
            this.context.Set<T>().Add(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
           return await this.context.Set<T>().FindAsync(id);
        }
        public async Task Update(T entity, int id)
        {
            this.context.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllBySpecification(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllListAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetBySpecificationAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(this.context.Set<T>().AsQueryable(), spec);
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        void IRepository<T>.Update(T entity, int id)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

       
    }
}
