using ToyRobot.Lib.Models;

namespace ToyRobot.Lib.Handlers
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly IServiceProvider serviceProvider;

        public CommandHandlerFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException();
        }

        public ICommandHandler GetHandler(RobotCommand command)
        {
            if (command == RobotCommand.PLACE)
                return (ICommandHandler)serviceProvider.GetService(typeof(PlaceCommandHandler));

            if (command == RobotCommand.MOVE)
                return (ICommandHandler)serviceProvider.GetService(typeof(MoveCommandHandler));

            if (command == RobotCommand.LEFT)
                return (ICommandHandler)serviceProvider.GetService(typeof(LeftCommandHandler));

            if (command == RobotCommand.RIGHT)
                return (ICommandHandler)serviceProvider.GetService(typeof(RightCommandHandler));

            return (ICommandHandler)serviceProvider.GetService(typeof(ReportCommandHandler));
        }
    }
}
