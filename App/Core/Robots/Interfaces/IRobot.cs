using martianRobots.Core.Models.Base;
using martianRobots.Core.Models.ExInput;
using martianRobots.Core.Models.Land;

namespace martianRobots.Core.Robots.Interfaces
{
    public interface IRobot
    {
        void Start(MartianRobotInput input);
        void ExecuteMovementCommands();
    }
}
