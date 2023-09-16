using martianRobots.Core.Models.Base;

namespace martianRobots.Core.Models;

[Serializable]
public class TwoDCoordinates : CoordinatesBase
{
    public TwoDCoordinates()
    {
        base.x = 0;
        base.y = 0;
    }

    public TwoDCoordinates(int x, int y)
    {
        base.x = x;
        base.y = y;
    }
}