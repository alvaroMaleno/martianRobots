using martianRobots.Core.Models;
using martianRobots.Core.Models.Base;
using martianRobots.Core.Movement.Interfaces;

namespace martianRobots.Core.Movement;

public class TwoDMovement : IMovement
{
    private readonly Dictionary<string, Dictionary<string, string>> _commandOrientationResult =
    new Dictionary<string, Dictionary<string, string>>()
    {
        {
            "R",
            new Dictionary<string, string>()
            {
                { "N", "E"},
                { "S", "W"},
                { "E", "S"},
                { "W", "N"},
            }
        },
        {
            "L",
            new Dictionary<string, string>()
            {
                { "N", "W"},
                { "S", "E"},
                { "E", "N"},
                { "W", "S"},
            }
        },
    };

    public TwoDMovement() { }

    public ICoordinatesBase GetForwardCoordinatesFromOrientation(char orientation)
    {
        switch (orientation) 
        {
            case 'E':
                return new TwoDCoordinates(1, 0);
            case 'W':
                return new TwoDCoordinates(-1, 0);
            case 'N':
                return new TwoDCoordinates(0, 1);
            case 'S':
                return new TwoDCoordinates(0, -1);
            default:
                return new TwoDCoordinates(0, 0);
        };
    }

    public string GetNewOrientation(string orientation, string command)
    {
        if (_commandOrientationResult.ContainsKey(command))
            if (_commandOrientationResult[command].ContainsKey(orientation))
                return _commandOrientationResult[command][orientation];
        return orientation;
    }

    ICoordinatesBase IMovement.GetNewCoordinates(ICoordinatesBase current, ICoordinatesBase addition)
    {
        return new TwoDCoordinates(current.x + addition.x, current.y + addition.y);
    }
}