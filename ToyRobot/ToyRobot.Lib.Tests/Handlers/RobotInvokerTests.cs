using Moq;
using ToyRobot.Lib.Handlers;
using ToyRobot.Lib.Models;

namespace ToyRobot.Lib.Tests.Handlers
{
    public class RobotInvokerTests
    {
        private readonly Mock<ICommandHandlerFactory> _commandHandlerFactoryMock;
        private readonly Mock<ICommandHandler> _commandHandlerMock;
        private RobotInvoker robotInvoker;

        public RobotInvokerTests()
        {
            _commandHandlerFactoryMock = new Mock<ICommandHandlerFactory>();
            _commandHandlerMock = new Mock<ICommandHandler>();
            robotInvoker = new RobotInvoker(_commandHandlerFactoryMock.Object);
        }

        [Fact]
        public void Action_Does_Nothing_When_Invalid_Command()
        {
            // Act
            robotInvoker.Action("SWING");

            // Assert
            _commandHandlerFactoryMock.Verify(m => m.GetHandler(It.IsAny<RobotCommand>()), Times.Never);
        }

        [Fact]
        public void Action_Does_Nothing_When_Other_Command_Sent_Before_Place()
        {
            // Act
            robotInvoker.Action("MOVE");

            // Assert
            _commandHandlerFactoryMock.Verify(m => m.GetHandler(RobotCommand.MOVE), Times.Never);
        }

        [Fact]
        public void Action_Does_Nothing_When_Params_Are_Wrong()
        {
            // Act
            robotInvoker.Action("PLACE X,Y,ZOO");

            // Assert
            _commandHandlerFactoryMock.Verify(m => m.GetHandler(RobotCommand.MOVE), Times.Never);
        }

        [Fact]
        public void Action_Processes_Other_Commands_After_Robot_Is_Placed()
        {
            // Arrange
            _commandHandlerFactoryMock.Setup(m => m.GetHandler(It.IsAny<RobotCommand>())).Returns(_commandHandlerMock.Object);

            // Act
            robotInvoker.Action("PLACE 1,2,NORTH");

            // Assert
            _commandHandlerFactoryMock.Verify(m => m.GetHandler(RobotCommand.PLACE), Times.Once);

            // Act
            robotInvoker.Action("MOVE");

            // Assert
            _commandHandlerFactoryMock.Verify(m => m.GetHandler(RobotCommand.MOVE), Times.Once);
        }
    }
}
