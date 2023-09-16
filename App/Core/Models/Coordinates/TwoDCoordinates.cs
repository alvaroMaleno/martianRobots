using martianRobots.Core.Models.Base;

namespace martianRobots.Core.Models;

[Serializable]
public class TwoDCoordinates : ICoordinatesBase
{
    public int x { get; set; }
    public int y { get; set; }

    public TwoDCoordinates()
    {
        this.x = 0;
        this.y = 0;
    }

    public TwoDCoordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}