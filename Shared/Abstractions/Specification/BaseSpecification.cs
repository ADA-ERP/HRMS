using System.Linq.Expressions;
using Shared.Infrastructure.Specification;

namespace Shared.Infrastructure.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
   {
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            if(criteria is null) throw new ArgumentNullException();
            Criteria = criteria;
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria, List<Expression<Func<T, object>>> includes) : this(criteria)
        {
            Includes = includes;
        }



        public void AddInclude(Expression<Func<T, object>> include)
        {
            this.Includes.Add(include);
        }

        public void AddOrderBy(Expression<Func<T, object>> orderByExrpression)
        {
            OrderBy = orderByExrpression;
        }

        public void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExrpression)
        {
            OrderByDescending = orderByDescendingExrpression;
        }
        public void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}
