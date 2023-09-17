using models = martianRobots.Repositories.Redis.MartianLosts.Models;

namespace martianRobots.Repositories.Redis.MartianLosts.Interfaces
{
    public interface IMartianRobotLostRepository
    {
        public Task<models.MartianLosts?> GetMartianLosts(string key);
        public Task<bool> SetMartianLosts(models.MartianLosts martian);
    }
}
