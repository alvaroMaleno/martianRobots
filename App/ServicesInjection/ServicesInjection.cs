using martianRobots.Core.Models;
using martianRobots.Core.Models.Base;
using martianRobots.Core.Models.Land;
using martianRobots.Core.Movement;
using martianRobots.Core.Movement.Interfaces;

namespace martianRobots.ServicesInjection
{
    public static class ServicesInjection
    {
        public static IServiceCollection ConfigureServicesInjection (IServiceCollection services)
        {
            services.AddSingleton<ICoordinatesBase, TwoDCoordinates>();
            services.AddSingleton<ILand, MarsLand>();
            services.AddSingleton<IMovement, TwoDMovement>();

            return services;
        }
    }
}
