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
                { "S", "O"},
                { "E", "S"},
                { "O", "N"},
            }
        },
        {
            "L",
            new Dictionary<string, string>()
            {
                { "N", "O"},
                { "S", "E"},
                { "E", "N"},
                { "O", "S"},
            }
        },
    };

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