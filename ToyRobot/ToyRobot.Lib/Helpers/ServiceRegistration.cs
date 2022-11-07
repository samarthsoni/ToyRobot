using Microsoft.Extensions.DependencyInjection;
using ToyRobot.Lib.Handlers;

namespace ToyRobot.Lib.ServiceRegistrations
{
    public static class ServiceRegistrationHelper
    {
        public static ServiceCollection RegisterServices(ServiceCollection services)
        {
            services.AddSingleton<IRobotInvoker, RobotInvoker>();
            services.AddScoped<PlaceCommandHandler>()
                .AddScoped<ICommandHandler, PlaceCommandHandler>(s => s.GetService<PlaceCommandHandler>());
            services.AddScoped<MoveCommandHandler>()
                .AddScoped<ICommandHandler, MoveCommandHandler>(s => s.GetService<MoveCommandHandler>());
            services.AddScoped<LeftCommandHandler>()
                .AddScoped<ICommandHandler, LeftCommandHandler>(s => s.GetService<LeftCommandHandler>());
            services.AddScoped<RightCommandHandler>()
                .AddScoped<ICommandHandler, RightCommandHandler>(s => s.GetService<RightCommandHandler>());
            services.AddScoped<ReportCommandHandler>()
                .AddScoped<ICommandHandler, ReportCommandHandler>(s => s.GetService<ReportCommandHandler>());
            services.AddScoped<ICommandHandlerFactory, CommandHandlerFactory>();
            return services;;
        }
    }
}
