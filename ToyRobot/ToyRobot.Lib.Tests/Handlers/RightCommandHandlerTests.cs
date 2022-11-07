using ToyRobot.Lib.Handlers;
using ToyRobot.Lib.Models;

namespace ToyRobot.Lib.Tests.Handlers
{
    public class RightCommandHandlerTests
    {
        private RightCommandHandler rightCommandHandler;

        public RightCommandHandlerTests()
        {
            rightCommandHandler = new RightCommandHandler();
        }

        [Fact]
        public void Handle_When_Current_Direction_Not_Set()
        {
            // Arrange
            var currentPosition = new Position
            {
                X = 1,
                Y = 1
            };

            // Act
            var newPosition = rightCommandHandler.Handle(currentPosition, new Position());

            // Assert
            Assert.Equal(currentPosition.X, newPosition.X);
            Assert.Equal(currentPosition.Y, newPosition.Y);
            Assert.Null(newPosition.Direction);
        }

        [Fact]
        public void Handle_When_Current_Direction_Set()
        {
            // Arrange
            var currentPosition = new Position
            {
                X = 1,
                Y = 1,
                Direction = Direction.WEST
            };

            // Act
            var newPosition = rightCommandHandler.Handle(currentPosition, new Position());

            // Assert
            Assert.Equal(currentPosition.X, newPosition.X);
            Assert.Equal(currentPosition.Y, newPosition.Y);
            Assert.Equal(Direction.NORTH, newPosition.Direction);
        }
    }
}
