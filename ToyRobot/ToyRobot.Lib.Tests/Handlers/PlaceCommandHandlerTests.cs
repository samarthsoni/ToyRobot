using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Lib.Handlers;
using ToyRobot.Lib.Models;

namespace ToyRobot.Lib.Tests.Handlers
{
    public class PlaceCommandHandlerTests
    {
        private PlaceCommandHandler placeCommandHandler;

        public PlaceCommandHandlerTests()
        {
            placeCommandHandler = new PlaceCommandHandler();
        }

        [Fact]
        public void Handle_When_Current_Direction_Not_Set()
        {
            // Arrange
            var currentPosition = new Position
            {
                X = 1,
                Y = 1,
                Direction = Direction.NORTH
            };
            var newPosition = new Position
            {
                X = 2,
                Y = 2
            };

            // Act
            var result = placeCommandHandler.Handle(currentPosition, newPosition);

            // Assert
            Assert.Equal(newPosition.X, result.X);
            Assert.Equal(newPosition.Y, result.Y);
            Assert.Equal(currentPosition.Direction, result.Direction);
        }

        [Fact]
        public void Handle_When_Current_Direction_Set()
        {
            // Arrange
            var newPosition = new Position
            {
                X = 1,
                Y = 1,
                Direction = Direction.EAST
            };

            // Act
            var result = placeCommandHandler.Handle(new Position(), newPosition);

            // Assert
            Assert.Equal(newPosition.X, result.X);
            Assert.Equal(newPosition.Y, result.Y);
            Assert.Equal(newPosition.Direction, result.Direction);
        }
    }
}
