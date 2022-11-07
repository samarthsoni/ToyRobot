using ToyRobot.Lib.Models;
using ToyRobot.Lib.Validators;

namespace ToyRobot.Lib.Handlers
{
    public class MoveCommandHandler : ICommandHandler
    {
        IDictionary<Direction, (int, int)> offset = new Dictionary<Direction, (int, int)>(){
                        {Direction.NORTH, (0, 1)},
                        {Direction.SOUTH, (0, -1)},
                        {Direction.EAST, (1, 0)},
                        {Direction.WEST, (-1, 0)}};

        public Position Handle(Position currentPosition, Position newPosition)
        {
            if(currentPosition.Direction != null)
            {
                offset.TryGetValue((Direction)currentPosition.Direction, out (int, int) delta);
                var newX = currentPosition.X + delta.Item1;
                var newY = currentPosition.Y + delta.Item2;
                if(CommandHelpers.IsValidPosition(newX, newY))
                {
                    currentPosition.X = newX;
                    currentPosition.Y = newY;
                    return currentPosition;
                }
            }
            return currentPosition;
        }
    }
}
