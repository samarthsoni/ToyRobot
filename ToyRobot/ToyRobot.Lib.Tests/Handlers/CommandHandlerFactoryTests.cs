using Moq;
using ToyRobot.Lib.Handlers;

namespace ToyRobot.Lib.Tests.Handlers
{
    public class CommandHandlerFactoryTests
    {
        private readonly Mock<IServiceProvider> _serviceProviderMock;
        private readonly Mock<PlaceCommandHandler> _placeCommandHandlerMock;
        private readonly Mock<MoveCommandHandler> _moveCommandHandlerMock;
        private readonly Mock<LeftCommandHandler> _leftCommandHandlerMock;
        private readonly Mock<RightCommandHandler> _rightCommandHandlerMock;
        private readonly Mock<ReportCommandHandler> _reportCommandHandlerMock;
        private CommandHandlerFactory commandHandlerFactory;

        public CommandHandlerFactoryTests()
        {
            _serviceProviderMock = new Mock<IServiceProvider>();
            _placeCommandHandlerMock = new Mock<PlaceCommandHandler>();
            _moveCommandHandlerMock = new Mock<MoveCommandHandler>();
            _leftCommandHandlerMock = new Mock<LeftCommandHandler>();
            _rightCommandHandlerMock = new Mock<RightCommandHandler>();
            _reportCommandHandlerMock = new Mock<ReportCommandHandler>();
            commandHandlerFactory = new CommandHandlerFactory(_serviceProviderMock.Object);
        }

        [Fact]
        public void Get_Handler_Returns_Correct_Handler()
        {
            // Arrange
            _serviceProviderMock.Setup(m => m.GetService(typeof(PlaceCommandHandler))).Returns(_placeCommandHandlerMock.Object);
            _serviceProviderMock.Setup(m => m.GetService(typeof(MoveCommandHandler))).Returns(_moveCommandHandlerMock.Object);
            _serviceProviderMock.Setup(m => m.GetService(typeof(LeftCommandHandler))).Returns(_leftCommandHandlerMock.Object);
            _serviceProviderMock.Setup(m => m.GetService(typeof(RightCommandHandler))).Returns(_rightCommandHandlerMock.Object);
            _serviceProviderMock.Setup(m => m.GetService(typeof(ReportCommandHandler))).Returns(_reportCommandHandlerMock.Object);

            // Act
            var commandHandler = commandHandlerFactory.GetHandler(Models.RobotCommand.PLACE);

            // Assert
            Assert.Equal(commandHandler, _placeCommandHandlerMock.Object);

            // Act
            commandHandler = commandHandlerFactory.GetHandler(Models.RobotCommand.MOVE);

            // Assert
            Assert.Equal(commandHandler, _moveCommandHandlerMock.Object);

            // Act
            commandHandler = commandHandlerFactory.GetHandler(Models.RobotCommand.LEFT);

            // Assert
            Assert.Equal(commandHandler, _leftCommandHandlerMock.Object);

            // Act
            commandHandler = commandHandlerFactory.GetHandler(Models.RobotCommand.RIGHT);

            // Assert
            Assert.Equal(commandHandler, _rightCommandHandlerMock.Object);

            // Act
            commandHandler = commandHandlerFactory.GetHandler(Models.RobotCommand.REPORT);

            // Assert
            Assert.Equal(commandHandler, _reportCommandHandlerMock.Object);
        }
    }
}
