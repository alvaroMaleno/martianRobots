using martianRobots.Core.Models.Base;

namespace martianRobots.Core.Models.Land;

public interface ILand
{
    public CoordinatesBase NewCoordinates(CoordinatesBase coordinates);
    public bool IsCoordinateInLand(CoordinatesBase coordinates);
    public void AddScent(CoordinatesBase coordinates, CoordinatesBase instruction, string orientation);
    public bool IsInScents(string key, CoordinatesBase instruction);
}