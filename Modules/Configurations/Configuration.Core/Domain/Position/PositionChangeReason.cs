

using Shared.Abstractions.Types;

namespace Core.Domains.Position
{
    public class PositionChangeReason : BaseEntity
    {
        public static PositionChangeReason Prombotion = new PositionChangeReason(1, "Promotion");
        public static PositionChangeReason Demotion = new PositionChangeReason(2, "Demotion");
        public static PositionChangeReason Correction = new PositionChangeReason(3, "Correction");
        public static PositionChangeReason Transfare = new PositionChangeReason(4, "Employment");
        public static PositionChangeReason Employment = new PositionChangeReason(4, "Employment");

        public string? Name { get; private set; }
        private PositionChangeReason()
        {

        }

        public PositionChangeReason(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
