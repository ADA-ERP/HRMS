
using Ardalis.GuardClauses;
using Shared.Abstractions.Types;

namespace Domains.Configuration
{
    public class Department : BaseEntity
    {
        private Department() { }
        public Department(string code, string description, string? parentCode, int branchId)
        {
            Code = Guard.Against.NullOrWhiteSpace(code);
            Description = Guard.Against.NullOrWhiteSpace(description);
            ParentCode = parentCode;
            BranchId = Guard.Against.NegativeOrZero(branchId);
            CreatedAt = DateTimeOffset.UtcNow;
        }

        public string Code { get; private set; }
        public string Description { get; private set; }
        public string? ParentCode { get; private set; }
        public int BranchId { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdateAt { get; private set; }

        public void updateDescription(string description)
        {

            Description = Guard.Against.NullOrWhiteSpace(description);
            UpdateAt = DateTimeOffset.UtcNow;
        }
        public void updateBranch(int branchId)
        {
            BranchId = Guard.Against.NegativeOrZero(branchId);
        }
        public void UpdateParentCode(string? parentCode)
        {
            ParentCode = parentCode;
            UpdateAt = DateTimeOffset.UtcNow;

        }
    }
}