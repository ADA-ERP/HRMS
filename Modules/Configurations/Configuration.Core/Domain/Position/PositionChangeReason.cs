

using Shared.Abstractions.Types;

namespace Core.Domains.Position
{
    public class PositionChangeReason : BaseEntity
    {
        public static PositionChangeReason Promotion = new PositionChangeReason("Promotion");
        public static PositionChangeReason Demotion = new PositionChangeReason("Demotion");
        public static PositionChangeReason Correction = new PositionChangeReason("Correction");
        public static PositionChangeReason Transfer = new PositionChangeReason("Transfer");
        public static PositionChangeReason Employment = new PositionChangeReason("Employment");
        public static PositionChangeReason Other = new PositionChangeReason("Other");

        public string? Name { get; private set; }
        private PositionChangeReason()
        {

        }

        public PositionChangeReason(string name)
        {
            Name = name;
        }
    }
}
