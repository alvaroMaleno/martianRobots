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
        private CoordinatesBase _coordinates;
        private IMovement _movement;
        private ILand _land;
        private MartianRobotInput? _input;
        private string _orientation = "N";
        private bool _isLost = false;

        public MartianRobot(
            CoordinatesBase coordinates,
            IMovement movement,
            ILand land) 
        {
            _coordinates = coordinates;
            _movement = movement;   
            _land = land;
        }

        public void Start(MartianRobotInput input, CoordinatesBase landLimits)
        {
            _isLost = false;
            _input = input;
            
            _land.NewCoordinates(
                new TwoDCoordinates(
                    landLimits?.x ?? 0,
                    landLimits?.y ?? 0
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
                if (_isLost)
                    return;

                if (IsMovementForward(instruction))
                {
                    var coordinatesToFollow = _movement.GetForwardCoordinatesFromOrientation(char.Parse(_orientation));
                    var newCoordinates =
                        _movement.GetNewCoordinates(
                            _coordinates,
                            coordinatesToFollow
                        );

                    if (IsLost(newCoordinates)) 
                    {
                        var keyPos = string.Concat(_coordinates.x, _coordinates.y, _orientation);
                        _isLost = _land.IsInScents(keyPos, coordinatesToFollow) ? _isLost : true;
                        _land.AddScent(_coordinates, coordinatesToFollow, _orientation);
                        continue;
                    }

                    _coordinates = newCoordinates;
                }
                else 
                {
                    _orientation = _movement.GetNewOrientation(_orientation, instruction.ToString());
                }
            }
        }

        private bool IsLost(CoordinatesBase newCoordinates)
        {
            return !_land.IsCoordinateInLand(newCoordinates);
        }

        private bool IsMovementForward(char instruction)
        {
            return instruction == 'F';
        }

        public override string ToString() 
        {
            var lostMessage = _isLost ? "LOST" : string.Empty;
            return $"{_coordinates.x } {_coordinates.y} {_orientation} {lostMessage}".Trim();
        }
    }
}
