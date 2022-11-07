using ToyRobot.Lib.Models;

namespace ToyRobot.Lib.Handlers
{
    public class ReportCommandHandler : ICommandHandler
    {
        public Position Handle(Position currentPosition, Position newPosition)
        {
            Console.WriteLine($"Output: {currentPosition.X},{currentPosition.Y},{currentPosition.Direction}");
            return currentPosition;
        }
    }
}
