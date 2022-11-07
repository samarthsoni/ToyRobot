using ToyRobot.Lib.Models;
using ToyRobot.Lib.Validators;

namespace ToyRobot.Lib.Handlers
{
    public class RobotInvoker : IRobotInvoker
    {
        private bool isFirstCommand = true;
        private Position currentPosition;
        private Position newPosition;
        private readonly ICommandHandlerFactory commandHandlerFactory;

        public RobotInvoker(ICommandHandlerFactory commandHandlerFactory)
        {
            this.commandHandlerFactory = commandHandlerFactory;
            currentPosition = GetDefaultPosition();
            newPosition = GetDefaultPosition();
        }

        public void Action(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                Console.WriteLine("Command cannot be blank");
                command = string.Empty;
            }
            else if (!string.Equals(command, "q"))
            {
                var splitCommand = command.Split(' ');
                var robotCommandString = splitCommand?.FirstOrDefault();
                var commandParam = splitCommand?.Length >= 2 ? splitCommand[1] : string.Empty;
                if (!string.IsNullOrEmpty(robotCommandString) && !CommandHelpers.IsValidCommand(robotCommandString, isFirstCommand))
                {
                    Console.WriteLine("Invalid Command");
                    return;
                }
                if (string.Equals(robotCommandString, RobotCommand.PLACE.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (CommandHelpers.IsValidParam(commandParam, isFirstCommand))
                    {
                        newPosition = CommandHelpers.ParseCommandParams(commandParam);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Command Params");
                        return;
                    }
                }
                Enum.TryParse(robotCommandString, out RobotCommand robotCommand);
                var commandHandler = commandHandlerFactory.GetHandler(robotCommand);
                currentPosition = commandHandler.Handle(currentPosition, newPosition);
                isFirstCommand = false;
            }
        }

        private Position GetDefaultPosition()
        {
            return new Position
            {
                X = -1,
                Y = -1
            };
        }
    }

}
