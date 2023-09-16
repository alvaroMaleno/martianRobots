using martianRobots.Core.Models.Base;
using System.Text.Json;

namespace martianRobots.Core.Models.Land;

public class MarsLand : ILand
{

    private ICoordinatesBase _coordinates;
    private Dictionary<string, List<ICoordinatesBase>> _scents;

    public MarsLand()
    {
        _coordinates = new TwoDCoordinates();
        _scents = new Dictionary<string, List<ICoordinatesBase>>();
    }

    public MarsLand(ICoordinatesBase coordinates) 
    {
        _coordinates = coordinates;
        _scents = new Dictionary<string, List<ICoordinatesBase>>();
    }

    public void AddScent(ICoordinatesBase coordinates, ICoordinatesBase instruction, string orientation)
    {
        var key = string.Concat(coordinates.x, coordinates.y, orientation);
        if (!IsInScents(key, instruction)) 
        {
            var toAdd = _scents.ContainsKey(key) ? _scents[key] : new List<ICoordinatesBase>();
            toAdd.Add(instruction);
            _scents.Add(
                key,
                toAdd
                );
        }
            
    }

    public bool IsInScents(string key, ICoordinatesBase instruction)
    {
        return 
            _scents.ContainsKey(key) && 
            _scents[key]
                .Any(coordinates => 
                    coordinates.x == instruction.x && 
                    coordinates.y == instruction.y
                    );
    }

    public bool IsCoordinateInLand(ICoordinatesBase coordinates)
    {
        var result = false;

        if (_coordinates.x >= coordinates.x && _coordinates.y >= coordinates.y) 
            result = true;

        return result;
    }

    public ICoordinatesBase NewCoordinates(ICoordinatesBase coordinates)
    {
        _coordinates = coordinates ?? throw new ArgumentNullException(nameof(coordinates));
        return _coordinates;
    }

    public override string ToString() 
    {
        return JsonSerializer.Serialize(_coordinates);
    }
}