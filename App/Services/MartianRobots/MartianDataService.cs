using martianRobots.Core.Models.ExInput;
using martianRobots.Repositories.Redis.MartianData.Interfaces;
using martianRobots.Repositories.Redis.MartianData.Models;
using martianRobots.Services.MartianRobots.Interfaces;
using martianRobots.Services.MartianRobots.Models;

namespace martianRobots.Services.MartianRobots
{
    public class MartianDataService : IMartianDataService
    {
        private IMartianDataRepository _martianDataRepository;

        public MartianDataService(IMartianDataRepository martianDataRepository) 
        {
            _martianDataRepository = martianDataRepository;
        }

        public async Task<List<string>> GetMarsVisitedCoordinates()
        {
            return await _martianDataRepository.GetMarsVisitedCoordinates();
        }

        public async Task<List<MartianRobotInput>> GetMartianRobotInputs()
        {
            return await _martianDataRepository.GetMartianRobotInputs();
        }

        public async Task<List<MartianInputResultDto>> GetMartianRobotInputsWithResult()
        {
            return await _martianDataRepository.GetMartianRobotInputsWithResult();
        }

        public async Task<bool> SaveMarsVisitedCoordinates(string coordinates)
        {
            return await _martianDataRepository.SaveMarsVisitedCoordinates(coordinates);
        }

        public async Task<bool> SaveMartianRobotInput(MartianRobotInput martianRobotInput)
        {
            return await _martianDataRepository.SaveMartianRobotInput(martianRobotInput);
        }

        public async Task<bool> SaveMartianRobotInputWithResult(MartianRobotInput martianRobotInput, string result)
        {
            return await _martianDataRepository.SaveMartianRobotInputWithResult(martianRobotInput, result);
        }

        public async Task<MartianDataStatsResult> GetStats() 
        {
            var stats = new MartianDataStatsResult();
            var inputsWithResult = await GetMartianRobotInputsWithResult();

            stats.TotalOks = inputsWithResult.Where(x => !x.Result.Contains("LOST")).Count();
            stats.TotalLosts = inputsWithResult.Where(x => x.Result.Contains("LOST")).Count();
            stats.TotalEnvies = inputsWithResult.Count();
            stats.OksPercentage = Math.Round(((double) stats.TotalOks / (double)stats.TotalEnvies) * 100, 2);
            stats.LostsPercentage = Math.Round(((double) stats.TotalLosts / (double) stats.TotalEnvies) * 100, 2);
            stats.TotalCoordinates = (await GetMarsVisitedCoordinates()).Count();

            return stats;
        }
    }
}
