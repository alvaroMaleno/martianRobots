using martianRobots.Core.Models.Base;

namespace martianRobots.Core.Models;

public class TwoDCoordinates : ICoordinatesBase
{
    public int x { get; set; }
    public int y { get; set; }

    public TwoDCoordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}