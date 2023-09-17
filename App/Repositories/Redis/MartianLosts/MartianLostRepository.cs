using martianRobots.Repositories.Redis.MartianLosts.Interfaces;
using StackExchange.Redis;
using System.Text.Json;
using models = martianRobots.Repositories.Redis.MartianLosts.Models;

namespace martianRobots.Repositories.Redis.MartianLosts
{
    public class MartianLostRepository : IMartianRobotLostRepository
    {
        private readonly IConfiguration _configuration;

        public MartianLostRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<models.MartianLosts?> GetMartianLosts(string key)
        {

            using (var redisConnection = GetConnection())
            {
                var result = await redisConnection.GetDatabase().StringGetAsync(key);
                if (!string.IsNullOrEmpty(result))
                    return JsonSerializer.Deserialize<models.MartianLosts>(result);

                return null;
            }
        }

        public async Task<bool> SetMartianLosts(models.MartianLosts martian)
        {
            using (var redisConnection = GetConnection())
            {
                return
                    await redisConnection
                        .GetDatabase()
                        .StringSetAsync(
                            martian.GetKey(),
                            JsonSerializer.Serialize(martian)
                            );
            }
        }

        private ConnectionMultiplexer GetConnection()
        {
            return
                ConnectionMultiplexer.Connect(
                    ConfigurationOptions.Parse(_configuration.GetValue<string>("redisConnection"))
                    );
        }
    }
}
