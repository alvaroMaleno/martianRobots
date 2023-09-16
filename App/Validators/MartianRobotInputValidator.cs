using FluentValidation;
using martianRobots.Core.Models.ExInput;

namespace martianRobots.Validators
{
    public class MartianRobotInputValidator : AbstractValidator<MartianRobotInput>
    {
        private const int MaxCommandLength = 100;

        public MartianRobotInputValidator() 
        {
            RuleFor(input => input.Command).NotNull().NotEmpty();
            RuleFor(input => input.Command.Length).LessThan(MaxCommandLength);
            RuleFor(input => input.RobotCoordinates).SetValidator(new CoordinatesBaseValidator());
        }
    }
}
