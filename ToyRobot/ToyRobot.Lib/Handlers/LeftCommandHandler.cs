using ToyRobot.Lib.Models;

namespace ToyRobot.Lib.Handlers
{
    public class LeftCommandHandler : ICommandHandler
    {
        public Position Handle(Position currentPosition, Position newPosition)
        {
            var currentDirection = currentPosition.Direction;
            if(currentDirection != null)
            {
                var newDirection = currentDirection == 0 ? currentDirection + 3 : currentDirection - 1;
                currentPosition.Direction = newDirection;
            }
            return currentPosition;
        }
    }
}
