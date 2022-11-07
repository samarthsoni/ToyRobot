using Microsoft.Extensions.DependencyInjection;
using ToyRobot.Lib.ServiceRegistrations;

namespace ToyRobot.AppStart
{
    internal static class ServiceRegistration
    {
        public static IServiceCollection Initialize()
        {
            var services = new ServiceCollection();

            // Register services
            ServiceRegistrationHelper.RegisterServices(services);

            // Register the app runner
            services.AddSingleton<IRunner, Runner>();

            return services;
        }
    }
}
