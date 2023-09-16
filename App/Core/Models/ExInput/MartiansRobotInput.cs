using martianRobots.Core.Models.Base;

namespace martianRobots.Core.Models.ExInput
{
    public class MartiansRobotInput
    {
        public ICoordinatesBase? LandLimits { get; set; }
        public List<MartianRobotInput> MartianRobots { get; set; } = new List<MartianRobotInput>();
    }
}
