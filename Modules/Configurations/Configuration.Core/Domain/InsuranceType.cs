

using Shared.Abstractions.Types;

namespace Core.Domains
{
    public class InsuranceType : BaseEntity
    {
        public string? Name { get; set; }
        public double Percentage { get; set; }
    }
}
