using FluentValidation;
using martianRobots.Core.Models;
using martianRobots.Core.Models.Base;
using martianRobots.Core.Models.ExInput;
using martianRobots.Core.Models.Land;
using martianRobots.Core.Movement;
using martianRobots.Core.Movement.Interfaces;
using martianRobots.Core.Robots;
using martianRobots.Core.Robots.Interfaces;
using martianRobots.Services.MartianRobots;
using martianRobots.Services.MartianRobots.Interfaces;
using martianRobots.Validators;

namespace martianRobots.ServicesInjection
{
    public static class ServicesInjection
    {
        public static IServiceCollection ConfigureServicesInjection (IServiceCollection services)
        {
            services.AddSingleton<CoordinatesBase, TwoDCoordinates>();
            services.AddSingleton<ILand, MarsLand>();
            services.AddSingleton<IMovement, TwoDMovement>();
            services.AddSingleton<IRobot, MartianRobot>();
            services.AddSingleton<IMartianRobotsService, MartianRobotsService>();
            services.AddScoped<IValidator<CoordinatesBase>, CoordinatesBaseValidator>();
            services.AddScoped<IValidator<MartianRobotInput>, MartianRobotInputValidator>();

            return services;
        }
    }
}
