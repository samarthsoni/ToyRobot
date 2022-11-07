using ToyRobot.Lib.Models;

namespace ToyRobot.Lib.Handlers
{
    public interface ICommandHandler
    {
        Position Handle(Position currentPosition, Position newPosition);
    }
}
