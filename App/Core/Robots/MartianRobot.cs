using martianRobots.Core.Models;
using martianRobots.Core.Models.Base;
using martianRobots.Core.Models.ExInput;
using martianRobots.Core.Models.Land;
using martianRobots.Core.Movement.Interfaces;
using martianRobots.Core.Robots.Interfaces;

namespace martianRobots.Core.Robots
{
    public class MartianRobot : IRobot
    {
        private ICoordinatesBase _coordinates;
        private IMovement _movement;
        private ILand _land;
        private MartianRobotInput? _input;
        private string _orientation = "N";

        public MartianRobot(
            ICoordinatesBase coordinates,
            IMovement movement,
            ILand land) 
        {
            _coordinates = coordinates;
            _movement = movement;   
            _land = land;
        }

        public void Start(MartianRobotInput input)
        {
            _input = input;
            
            _land.NewCoordinates(
                new TwoDCoordinates(
                    _input?.LandLimits?.x ?? 0, 
                    _input?.LandLimits?.y ?? 0
                    )
                );
            _coordinates = 
                new TwoDCoordinates(
                    _input?.RobotCoordinates?.x ?? 0,
                    _input?.RobotCoordinates?.y ?? 0
                    );

            _orientation = string.IsNullOrEmpty(_input?.Orientation) ? _orientation : _input.Orientation;
        }

        public void ExecuteMovementCommands()
        {
            foreach (char instruction in _input?.Command ?? string.Empty) 
            {
                if (instruction == 'F')
                    _coordinates = _movement.GetNewCoordinates(_coordinates, _movement.GetForwardCoordinatesFromOrientation(instruction));
                else
                    _orientation = _movement.GetNewOrientation(_orientation, instruction.ToString());
            }
        }

        public override string ToString() 
        {
            var lostMessage = _land.IsCoordinateInLand(_coordinates) ? string.Empty : "LOST";
            return $"{_coordinates.x } {_coordinates.y} {_orientation} {lostMessage}";
        }
    }
}
