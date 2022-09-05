

using Ardalis.GuardClauses;
using Domains.Configuration;
using Shared.Abstractions.Types;

namespace Core.Domains.Configuration
{
    public class Branch : BaseEntity
    {
        public string Name { get; set; }
        private readonly List<Department> departments = new List<Department>();
        public IReadOnlyCollection<Department> Departments => departments.AsReadOnly();

        public void AddDepartment(string code, string? parentCode, string description)
        {
            if (parentCode is not null && !string.IsNullOrEmpty(parentCode) && !Departments.Where(d => d.Code == parentCode).Any())
                throw new InvalidOperationException($"Parent department doesn't exist {parentCode}");
            Guard.Against.NullOrWhiteSpace(code);
            Guard.Against.NullOrWhiteSpace(description);
            departments.Add(new Department(code, description, parentCode, Id));
        }
    }
}
