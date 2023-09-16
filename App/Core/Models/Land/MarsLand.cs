using martianRobots.Core.Models.Base;
using System.Text.Json;

namespace martianRobots.Core.Models.Land;

public class MarsLand : ILand
{

    private ICoordinatesBase _coordinates;

    public MarsLand(ICoordinatesBase coordinates) 
    {
        _coordinates = coordinates;
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