using martianRobots.Core.Models.ExInput;
using martianRobots.Services.MartianRobots.Models;

namespace martianRobots.Services.MartianRobots.Interfaces
{
    public interface IMartianRobotsService
    {
        public Task<MartianRobotsResult> SendRobotsToMars(MartianRobotInputs inputs);
    }
}
