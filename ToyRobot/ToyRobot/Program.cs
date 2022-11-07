using ToyRobot.AppStart;
using Microsoft.Extensions.DependencyInjection;

namespace ToyRobot
{
    class Program
    {
        private static Task Main(string[] args)
        {
            try
            {
                var services =  ServiceRegistration.Initialize();

                // Bootstrap the application
                var serviceProvider = services.BuildServiceProvider();
                var runner = (IRunner)serviceProvider.GetService(typeof(IRunner));
                runner.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
                Console.ReadKey();
            }

            return Task.CompletedTask;
        }
    }
}