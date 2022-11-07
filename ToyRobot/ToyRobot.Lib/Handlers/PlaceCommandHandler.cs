using ToyRobot.Lib.Models;

namespace ToyRobot.Lib.Handlers
{
    public class PlaceCommandHandler : ICommandHandler
    {
        public Position Handle(Position currentPosition, Position newPosition)
        {
            if (newPosition.Direction != null)
                return newPosition;
            newPosition.Direction = currentPosition.Direction;
            return newPosition;
        }
    }
}
