using martianRobots.Core.Models.ExInput;
using martianRobots.Repositories.Redis.MartianData.Interfaces;
using martianRobots.Repositories.Redis.MartianData.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace martianRobots.Repositories.Redis.MartianData
{
    public class MartianDataRepository : IMartianDataRepository
    {
        private readonly string _connectionString;
        private const string MartianInputsKey = "martian_inputs";
        private const string MartianInputsResultKey = "martian_inputs_result";
        private const string MarsVisitedCoordinatesKey = "mars_coodinates_visited";

        public MartianDataRepository(IConfiguration configuration) 
        {
            _connectionString = configuration.GetValue<string>("redisConnection") ?? "localhost";
        }

        public async Task<List<MartianRobotInput>> GetMartianRobotInputs()
        {
            using (var redisConnection = GetConnection())
            {
                var result = await redisConnection.GetDatabase().StringGetAsync(MartianInputsKey);
                if (!string.IsNullOrEmpty(result))
                    return JsonSerializer.Deserialize<List<MartianRobotInput>>(result);

                return new List<MartianRobotInput>();
            }
        }

        public async Task<bool> SaveMartianRobotInput(MartianRobotInput martianRobotInput)
        {
            using (var redisConnection = GetConnection())
            {
                var inputs = new List<MartianRobotInput>();
                var result = await redisConnection.GetDatabase().StringGetAsync(MartianInputsKey);
                
                if (string.IsNullOrEmpty(result)) 
                {
                    inputs.Add(martianRobotInput);
                    return await Insert(MartianInputsKey, inputs, redisConnection);
                }

                inputs = JsonSerializer.Deserialize<List<MartianRobotInput>>(result);
                inputs.Add(martianRobotInput);

                return await Insert(MartianInputsKey, inputs, redisConnection);
            }
        }

        public async Task<List<MartianInputResultDto>> GetMartianRobotInputsWithResult()
        {
            using (var redisConnection = GetConnection())
            {
                var result = await redisConnection.GetDatabase().StringGetAsync(MartianInputsResultKey);
                if (!string.IsNullOrEmpty(result))
                    return JsonSerializer.Deserialize<List<MartianInputResultDto>>(result);

                return new List<MartianInputResultDto>();
            }
        }

        public async Task<bool> SaveMartianRobotInputWithResult(MartianRobotInput martianRobotInput, string result)
        {
            using (var redisConnection = GetConnection())
            {
                var inputs = new List<MartianInputResultDto>();
                var input = new MartianInputResultDto(martianRobotInput, result);
                var data = await redisConnection.GetDatabase().StringGetAsync(MartianInputsResultKey);

                if (string.IsNullOrEmpty(data))
                {
                    inputs.Add(input);
                    return await Insert(MartianInputsResultKey, inputs, redisConnection);
                }

                inputs = JsonSerializer.Deserialize<List<MartianInputResultDto>>(data);
                inputs.Add(input);

                return await Insert(MartianInputsResultKey, inputs, redisConnection);
            }
        }

        public async Task<List<string>> GetMarsVisitedCoordinates()
        {
            using (var redisConnection = GetConnection())
            {
                var result = await redisConnection.GetDatabase().StringGetAsync(MarsVisitedCoordinatesKey);
                if (!string.IsNullOrEmpty(result))
                    return JsonSerializer.Deserialize<List<string>>(result);

                return new List<string>();
            }
        }

        public async Task<bool> SaveMarsVisitedCoordinates(string coordinates)
        {
            using (var redisConnection = GetConnection())
            {
                var inputs = new List<string>();
                var data = await redisConnection.GetDatabase().StringGetAsync(MarsVisitedCoordinatesKey);

                if (string.IsNullOrEmpty(data))
                {
                    inputs.Add(coordinates);
                    return await Insert(MarsVisitedCoordinatesKey, inputs, redisConnection);
                }

                inputs = JsonSerializer.Deserialize<List<string>>(data);
                
                if (inputs.Any(x => x.Equals(coordinates)))
                    return false;

                inputs.Add(coordinates);

                return await Insert(MarsVisitedCoordinatesKey, inputs, redisConnection);
            }
        }

        private async Task<bool> Insert<T>(
            string key, 
            T inputs, 
            ConnectionMultiplexer redisConnection
            )
        {
            return await redisConnection
                        .GetDatabase()
                        .StringSetAsync(
                            key,
                            JsonSerializer.Serialize(inputs)
                            );
        }

        private ConnectionMultiplexer GetConnection()
        {
            return
                ConnectionMultiplexer.Connect(
                    ConfigurationOptions.Parse(_connectionString)
                    );
        }
    }
}
