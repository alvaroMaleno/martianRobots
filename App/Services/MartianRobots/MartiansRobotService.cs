using martianRobots.Core.Models.ExInput;
using martianRobots.Core.Robots.Interfaces;
using martianRobots.Services.MartianRobots.Interfaces;
using martianRobots.Services.MartianRobots.Models;

namespace martianRobots.Services.MartianRobots
{
    public class MartianRobotsService : IMartianRobotsService
    {
        private IRobot _robot;
        private readonly IMartianDataService _martianDataService;

        public MartianRobotsService(IRobot robot, IMartianDataService martianDataService) 
        {
            _robot = robot;
            _martianDataService = martianDataService;
        }

        public async Task<MartianRobotsResult> SendRobotsToMars(MartianRobotInputs inputs)
        {
            var result = new MartianRobotsResult();
            foreach (var input in inputs.MartianRobots) 
            {
                _robot.Start(input, inputs.LandLimits);
                await _robot.ExecuteMovementCommands();
                result.MartianRobotsResults.Add(_robot.ToString());
                _martianDataService.SaveMartianRobotInput(input);
                _martianDataService.SaveMartianRobotInputWithResult(input, _robot.ToString());
            }

            return result;
        }
    }
}
