using martianRobots.Core.Models.Base;

namespace martianRobots.Core.Models.Land;

public interface ILand
{
    public ICoordinatesBase NewCoordinates(ICoordinatesBase coordinates);
    public bool IsCoordinateInLand(ICoordinatesBase coordinates);
}