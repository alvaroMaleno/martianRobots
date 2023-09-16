namespace martianRobots.Core.Models.Base;

public interface ICoordinatesBase
{
    public int x { get; set; }
    public int y { get; set; }

    public  bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is ICoordinatesBase)
        {
            var toCompare = (ICoordinatesBase)obj;
            return toCompare.x == x && toCompare.y == y;
        }
        return false;
    }
}