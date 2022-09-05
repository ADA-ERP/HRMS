using System.Linq.Expressions;
using Core.Domains.Position;
using Shared.Infrastructure.Specification;

namespace Core.Specifications
{
    public class JobGradeWithPositionAndSalaryStructureSpecification : BaseSpecification<JobGrade>
    {
        public JobGradeWithPositionAndSalaryStructureSpecification()
        {
           AddInclude(x=>x.Positions);
           AddInclude(x=>x.SalaryStructure);
        }

        public JobGradeWithPositionAndSalaryStructureSpecification(Expression<Func<JobGrade, bool>> criteria) : base(criteria)
        {
           AddInclude(x=>x.Positions);
           AddInclude(x=>x.SalaryStructure);
            
        }
    }
    
}
