using martianRobots.Core.Models.ExInput;
using martianRobots.Repositories.Redis.MartianData.Models;

namespace martianRobots.Repositories.Redis.MartianData.Interfaces
{
    public interface IMartianDataRepository
    {
        public Task<List<MartianRobotInput>> GetMartianRobotInputs();
        public Task<bool> SaveMartianRobotInput(MartianRobotInput martianRobotInput);
        public Task<bool> SaveMartianRobotInputWithResult(MartianRobotInput martianRobotInput, string result);
        public Task<List<MartianInputResultDto>> GetMartianRobotInputsWithResult();
        public Task<List<string>> GetMarsVisitedCoordinates();
        public Task<bool> SaveMarsVisitedCoordinates(string coordinates);
    }
}
