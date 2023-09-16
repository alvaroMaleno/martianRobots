using martianRobots.Core.Models.Base;
using martianRobots.Repositories.Redis.MartianLosts.Interfaces;
using martianRobots.Repositories.Redis.MartianLosts.Models;
using System.Text.Json;

namespace martianRobots.Core.Models.Land;

public class MarsLand : ILand
{

    private CoordinatesBase _coordinates;
    private IMartianRobotLostRepository _repository;

    public MarsLand(IMartianRobotLostRepository repository)
    {
        _coordinates = new TwoDCoordinates();
        _repository = repository;
    }

    public MarsLand(
        CoordinatesBase coordinates,
        IMartianRobotLostRepository repository) 
    {
        _coordinates = coordinates;
        _repository = repository;
    }

    public async Task<Dictionary<string, List<CoordinatesBase>>> GetScent(string orientation)
    {
        return (await GetMartianLosts(orientation)).Scents;
    }

    public async Task AddScent(CoordinatesBase coordinates, CoordinatesBase instruction, string orientation)
    {
        var martianLosts = await GetMartianLosts(orientation);
        var key = string.Concat(coordinates.x, coordinates.y, orientation);
        
        if (!IsInScents(key, instruction, martianLosts.Scents)) 
        {
            var toAdd = martianLosts.Scents.ContainsKey(key) ? martianLosts.Scents[key] : new List<CoordinatesBase>();
            toAdd.Add(instruction);
            martianLosts.Scents.Add(
                key,
                toAdd
                );

            await _repository.SetMartianLosts(martianLosts);
        }   
    }

    private async Task<MartianLosts> GetMartianLosts(string orientation) 
    {
        var martianLosts = new MartianLosts(orientation, _coordinates, new Dictionary<string, List<CoordinatesBase>>());
        var martianLostFromCache = await _repository.GetMartianLosts(martianLosts.GetKey());

        return martianLostFromCache is null ? martianLosts : martianLostFromCache;
    }

    public bool IsInScents(string key, CoordinatesBase instruction, Dictionary<string, List<CoordinatesBase>> scents)
    {
        return
            scents.ContainsKey(key) &&
            scents[key]
                .Any(coordinates => 
                    coordinates.x == instruction.x && 
                    coordinates.y == instruction.y
                    );
    }

    public bool IsCoordinateInLand(CoordinatesBase coordinates)
    {
        var result = false;

        if (_coordinates.x >= coordinates.x && _coordinates.y >= coordinates.y) 
            result = true;

        return result;
    }

    public CoordinatesBase NewCoordinates(CoordinatesBase coordinates)
    {
        _coordinates = coordinates ?? throw new ArgumentNullException(nameof(coordinates));
        return _coordinates;
    }

    public override string ToString() 
    {
        return JsonSerializer.Serialize(_coordinates);
    }
}