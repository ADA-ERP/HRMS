

using Ardalis.GuardClauses;
using Shared.Abstractions.Types;

namespace Core.Domains.Position
{
    public class JobGrade : BaseEntity
    {
        public string Name { get; private set; }
        public int FieldOfStudy { get; private set; }
        public double MinExperienceRequired { get; private set; }
        public double MaxExperienceRequired { get; private set; }

        private readonly List<JobPosition> _positions = new List<JobPosition>();
        public IEnumerable<JobPosition> Positions => _positions.AsReadOnly();

        public SalaryStructure SalaryStructure { get; private set; }
        protected JobGrade() { }
        public JobGrade(string name, int fieldOfStudy, double minExperienceRequired,
        double maxExperienceRequired, SalaryStructure salaryStructure)
        {
            Name = Guard.Against.NullOrEmpty(name);
            if (fieldOfStudy > 0)
                FieldOfStudy = fieldOfStudy;
            MinExperienceRequired = Guard.Against.Negative(minExperienceRequired);
            MaxExperienceRequired = Guard.Against.Negative(maxExperienceRequired);
            SalaryStructure = Guard.Against.Null(salaryStructure, "Valid salary structure should be assigned to grade");

        }
        public void UpdateJobGrade(string name, int fieldOfStudy,
        SalaryStructure salaryStructure,
         double minExperienceRequired, double maxExperienceRequired)
        {
            Name = Guard.Against.NullOrEmpty(name);
            if (fieldOfStudy > 0)
                FieldOfStudy = fieldOfStudy;
            MinExperienceRequired = Guard.Against.Negative(minExperienceRequired);
            MaxExperienceRequired = Guard.Against.Negative(maxExperienceRequired);
            SalaryStructure = Guard.Against.Null(salaryStructure, "Valid salary structure should be assigned to grade");
        }

        public void AddPosition(string code, string name, string description)
        {
            if (_positions.Any(p => p.PositionCode == code))
                throw new InvalidOperationException($"There is already job position with this {code} code!");

            JobPosition position = new JobPosition(code, name, description, Id);
            _positions.Add(position);

        }
        public void UpdatePosition(string code, string name, string description)
        {
            var position = _positions.Where(p => p.PositionCode == code).FirstOrDefault();

            if (position is null)
                throw new InvalidOperationException($"There is no job position with this {code} code!");

            _positions.Remove(position);
            position.UpdateInformation(name, description);
            _positions.Add(position);

        }
    }
}