using martianRobots.Core.Models.ExInput;
using martianRobots.Core.Robots.Interfaces;
using martianRobots.Repositories.Redis.MartianData.Interfaces;
using martianRobots.Services.MartianRobots.Interfaces;
using martianRobots.Services.MartianRobots.Models;

namespace martianRobots.Services.MartianRobots
{
    public class MartianRobotsService : IMartianRobotsService
    {
        private IRobot _robot;
        private readonly IMartianDataRepository _martianDataRepository;

        public MartianRobotsService(IRobot robot, IMartianDataRepository martianDataRepository) 
        {
            _robot = robot;
            _martianDataRepository = martianDataRepository;
        }

        public async Task<MartianRobotsResult> SendRobotsToMars(MartianRobotInputs inputs)
        {
            var result = new MartianRobotsResult();
            foreach (var input in inputs.MartianRobots) 
            {
                _robot.Start(input, inputs.LandLimits);
                await _robot.ExecuteMovementCommands();
                result.MartianRobotsResults.Add(_robot.ToString());
                _martianDataRepository.SaveMartianRobotInput(input);
                _martianDataRepository.SaveMartianRobotInputWithResult(input, _robot.ToString());
            }

            return result;
        }
    }
}
