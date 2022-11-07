using ToyRobot.Lib.Models;

namespace ToyRobot.Lib.Handlers
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler GetHandler(RobotCommand command);
    }
}
