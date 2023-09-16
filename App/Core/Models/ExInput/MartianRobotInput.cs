using martianRobots.Core.Models.Base;

namespace martianRobots.Core.Models.ExInput
{
    [Serializable]
    public class MartianRobotInput
    {
        public ICoordinatesBase? LandLimits { get; set; }
        public ICoordinatesBase? RobotCoordinates { get; set; }
        public string? Command { get; set; }
        public string? Orientation { get; set; }
    }
}
