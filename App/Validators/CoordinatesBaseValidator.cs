using FluentValidation;
using martianRobots.Core.Models.Base;

namespace martianRobots.Validators
{
    public class CoordinatesBaseValidator : AbstractValidator<CoordinatesBase>
    {
        private const int MaxCoordinate = 50;

        public CoordinatesBaseValidator() 
        {
            RuleFor(coord => coord.x).LessThan(MaxCoordinate);
            RuleFor(coord => coord.y).LessThan(MaxCoordinate);
        }
    }
}
