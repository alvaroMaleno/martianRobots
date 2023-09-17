using martianRobots.Core.Models.Base;

namespace martianRobots.Core.Models.ExInput
{
    [Serializable]
    public class MartianRobotInput
    {
        public CoordinatesBase RobotCoordinates { get; set; } = new CoordinatesBase();
        public string Command { get; set; } = string.Empty;
        public string Orientation { get; set; } = string.Empty;
    }
}
