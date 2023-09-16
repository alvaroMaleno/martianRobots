using martianRobots.Core.Models.Base;

namespace martianRobots.Core.Movement.Interfaces;

public interface IMovement
{
    ICoordinatesBase GetNewCoordinates(ICoordinatesBase current, ICoordinatesBase addition);
    string GetNewOrientation(string orientation, string command);
    ICoordinatesBase GetForwardCoordinatesFromOrientation(char orientation);
}