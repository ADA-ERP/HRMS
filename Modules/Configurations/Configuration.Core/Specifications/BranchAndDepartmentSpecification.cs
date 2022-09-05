using System.Linq.Expressions;
using Core.Domains.Configuration;
using Shared.Infrastructure.Specification;

namespace Core.Specifications
{
    public class BranchAndDepartmentSpecification : BaseSpecification<Branch>
    {
        public BranchAndDepartmentSpecification()
        {
            AddInclude(b=>b.Departments);
        }

        public BranchAndDepartmentSpecification(Expression<Func<Branch, bool>> criteria) : base(criteria)
        {
             AddInclude(b=>b.Departments);
        }
    }
    
}
