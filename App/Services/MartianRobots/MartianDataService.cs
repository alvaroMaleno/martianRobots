using martianRobots.Core.Models.ExInput;
using martianRobots.Repositories.Redis.MartianData.Interfaces;
using martianRobots.Repositories.Redis.MartianData.Models;
using martianRobots.Services.MartianRobots.Interfaces;

namespace martianRobots.Services.MartianRobots
{
    public class MartianDataService : IMartianDataService
    {
        private IMartianDataRepository _martianDataRepository;

        public MartianDataService(IMartianDataRepository martianDataRepository) 
        {
            _martianDataRepository = martianDataRepository;
        }

        public Task<List<string>> GetMarsVisitedCoordinates()
        {
            return _martianDataRepository.GetMarsVisitedCoordinates();
        }

        public Task<List<MartianRobotInput>> GetMartianRobotInputs()
        {
            return _martianDataRepository.GetMartianRobotInputs();
        }

        public Task<List<MartianInputResultDto>> GetMartianRobotInputsWithResult()
        {
            return _martianDataRepository.GetMartianRobotInputsWithResult();
        }

        public Task<bool> SaveMarsVisitedCoordinates(string coordinates)
        {
            return _martianDataRepository.SaveMarsVisitedCoordinates(coordinates);
        }

        public Task<bool> SaveMartianRobotInput(MartianRobotInput martianRobotInput)
        {
            return _martianDataRepository.SaveMartianRobotInput(martianRobotInput);
        }

        public Task<bool> SaveMartianRobotInputWithResult(MartianRobotInput martianRobotInput, string result)
        {
            return _martianDataRepository.SaveMartianRobotInputWithResult(martianRobotInput, result);
        }
    }
}
