using martianRobots.Core.Models.Base;

namespace martianRobots.Core.Models.Land;

public interface ILand
{
    public CoordinatesBase NewCoordinates(CoordinatesBase coordinates);
    public bool IsCoordinateInLand(CoordinatesBase coordinates);
    public Task<Dictionary<string, List<CoordinatesBase>>> GetScent(string orientation);
    public Task AddScent(CoordinatesBase coordinates, CoordinatesBase instruction, string orientation);
    public bool IsInScents(string key, CoordinatesBase instruction, Dictionary<string, List<CoordinatesBase>> scents);
}