using martianRobots.Core.Models.ExInput;
using martianRobots.Services.MartianRobots.Models;

namespace martianRobots.Services.MartianRobots.Interfaces
{
    public interface IMartianRobotsService
    {
        public MartianRobotsResult SendRobotsToMars(MartianRobotInputs inputs);
    }
}
