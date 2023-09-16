using martianRobots.Core.Models.Base;
using martianRobots.Core.Models.ExInput;

namespace martianRobots.Core.Robots.Interfaces
{
    public interface IRobot
    {
        void Start(MartianRobotInput input, ICoordinatesBase landLimits);
        void ExecuteMovementCommands();
    }
}
