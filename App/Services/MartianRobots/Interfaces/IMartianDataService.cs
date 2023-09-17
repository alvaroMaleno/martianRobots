using martianRobots.Core.Models.ExInput;
using martianRobots.Repositories.Redis.MartianData.Models;
using martianRobots.Services.MartianRobots.Models;

namespace martianRobots.Services.MartianRobots.Interfaces
{
    public interface IMartianDataService
    {
        public Task<List<MartianRobotInput>> GetMartianRobotInputs();
        public Task<bool> SaveMartianRobotInput(MartianRobotInput martianRobotInput);
        public Task<bool> SaveMartianRobotInputWithResult(MartianRobotInput martianRobotInput, string result);
        public Task<List<MartianInputResultDto>> GetMartianRobotInputsWithResult();
        public Task<List<string>> GetMarsVisitedCoordinates();
        public Task<bool> SaveMarsVisitedCoordinates(string coordinates);
        public Task<MartianDataStatsResult> GetStats();
    }
}
