using martianRobots.Core.Models.ExInput;
using martianRobots.Core.Robots;
using martianRobots.Core.Robots.Interfaces;
using martianRobots.Services.MartianRobots.Interfaces;
using martianRobots.Services.MartianRobots.Models;

namespace martianRobots.Services.MartianRobots
{
    public class MartianRobotsService : IMartianRobotsService
    {
        private IRobot _robot;

        public MartianRobotsService(IRobot robot) 
        {
            _robot = robot;
        }

        public MartianRobotsResult SendRobotsToMars(MartianRobotInputs inputs)
        {
            var result = new MartianRobotsResult();
            foreach (var input in inputs.MartianRobots) 
            {
                _robot.Start(input, inputs.LandLimits);
                _robot.ExecuteMovementCommands();
                result.MartianRobotsResults.Add(_robot.ToString());
            }

            return result;
        }
    }
}
