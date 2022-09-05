using System.Linq.Expressions;
using Core.Domains.Position;
using Shared.Infrastructure.Specification;

namespace Core.Specifications
{
    public class JobGradeWithSalaryStructureSpecification : BaseSpecification<JobGrade>
    {
        public JobGradeWithSalaryStructureSpecification()
        {
           AddInclude(x=>x.SalaryStructure);
        }

        public JobGradeWithSalaryStructureSpecification(Expression<Func<JobGrade, bool>> criteria) : base(criteria)
        {
           AddInclude(x=>x.SalaryStructure);
            
        }
    }
    
}
