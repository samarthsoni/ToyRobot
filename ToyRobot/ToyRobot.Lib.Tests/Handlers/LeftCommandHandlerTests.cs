using ToyRobot.Lib.Handlers;
using ToyRobot.Lib.Models;

namespace ToyRobot.Lib.Tests.Handlers
{
    public class LeftCommandHandlerTests
    {
        private LeftCommandHandler leftCommandHandler;

        public LeftCommandHandlerTests()
        {
            leftCommandHandler = new LeftCommandHandler();
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
            var newPosition = leftCommandHandler.Handle(currentPosition, new Position());

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
                Direction = Direction.NORTH
            };

            // Act
            var newPosition = leftCommandHandler.Handle(currentPosition, new Position());

            // Assert
            Assert.Equal(currentPosition.X, newPosition.X);
            Assert.Equal(currentPosition.Y, newPosition.Y);
            Assert.Equal(Direction.WEST, newPosition.Direction);
        }
    }
}
