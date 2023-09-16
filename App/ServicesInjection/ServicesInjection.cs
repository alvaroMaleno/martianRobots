using martianRobots.Core.Models;
using martianRobots.Core.Models.Base;
using martianRobots.Core.Models.Land;

namespace martianRobots.ServicesInjection
{
    public static class ServicesInjection
    {
        public static IServiceCollection ConfigureServicesInjection (IServiceCollection services)
        {
            services.AddSingleton<ICoordinatesBase, TwoDCoordinates>();
            services.AddSingleton<ILand, MarsLand>();

            return services;
        }
    }
}
