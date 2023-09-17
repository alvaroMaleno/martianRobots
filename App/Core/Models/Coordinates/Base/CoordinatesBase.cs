namespace martianRobots.Core.Models.Base;

[Serializable]
public class CoordinatesBase
{
    public int x { get; set; }
    public int y { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is CoordinatesBase)
        {
            var toCompare = (CoordinatesBase)obj;
            return toCompare.x == x && toCompare.y == y;
        }
        return false;
    }

    public override string ToString()
    {
        return string.Concat(x, " ", y);
    }
}
