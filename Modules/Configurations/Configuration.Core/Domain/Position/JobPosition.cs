

using Ardalis.GuardClauses;
using Shared.Abstractions.Types;

namespace Core.Domains.Position
{
    public class JobPosition : BaseEntity
    {
        protected JobPosition() { }
        public JobPosition(string? positionCode, string? name, string? description,  int gradeId)
        {
            PositionCode = Guard.Against.NullOrWhiteSpace(positionCode);
            Name = Guard.Against.NullOrWhiteSpace(name);
            Description = Guard.Against.NullOrWhiteSpace(description);
            GradeId = Guard.Against.NegativeOrZero(gradeId);
            CreatedAt = DateTime.UtcNow;
        }

        public string? PositionCode { get; private set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }        
        public int GradeId { get; private set; }
        public DateTimeOffset? CreatedAt { get; private set; }
        public DateTimeOffset UpdatedAt { get; private set; }
       
        public void UpdateInformation(string name,string description)
        {
            Name = Guard.Against.NullOrWhiteSpace(name);
            Description = Guard.Against.NullOrWhiteSpace(description);        
            UpdatedAt = DateTimeOffset.UtcNow;
        }
    }
}
