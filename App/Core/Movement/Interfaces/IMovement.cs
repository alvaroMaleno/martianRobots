using martianRobots.Core.Models.Base;

namespace martianRobots.Core.Movement.Interfaces;

public interface IMovement
{
    CoordinatesBase GetNewCoordinates(CoordinatesBase current, CoordinatesBase addition);
    string GetNewOrientation(string orientation, string command);
    CoordinatesBase GetForwardCoordinatesFromOrientation(char orientation);
}