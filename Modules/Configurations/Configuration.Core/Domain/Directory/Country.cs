

using Shared.Abstractions.Types;

namespace Domains.Directory
{
    public class Country : BaseEntity
    {
        public string? Name { get; set; }
        public string AreaCode { get; set; }
        public string ISOCode { get; set; }
    }
}
