using martianRobots.Core.Models.Base;
using System.Text.Json;

namespace martianRobots.Core.Models.Land;

public class MarsLand : ILand
{

    private CoordinatesBase _coordinates;
    private Dictionary<string, List<CoordinatesBase>> _scents;

    public MarsLand()
    {
        _coordinates = new TwoDCoordinates();
        _scents = new Dictionary<string, List<CoordinatesBase>>();
    }

    public MarsLand(CoordinatesBase coordinates) 
    {
        _coordinates = coordinates;
        _scents = new Dictionary<string, List<CoordinatesBase>>();
    }

    public void AddScent(CoordinatesBase coordinates, CoordinatesBase instruction, string orientation)
    {
        var key = string.Concat(coordinates.x, coordinates.y, orientation);
        if (!IsInScents(key, instruction)) 
        {
            var toAdd = _scents.ContainsKey(key) ? _scents[key] : new List<CoordinatesBase>();
            toAdd.Add(instruction);
            _scents.Add(
                key,
                toAdd
                );
        }
            
    }

    public bool IsInScents(string key, CoordinatesBase instruction)
    {
        return 
            _scents.ContainsKey(key) && 
            _scents[key]
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