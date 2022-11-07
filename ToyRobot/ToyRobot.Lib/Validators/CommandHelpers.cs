using ToyRobot.Lib.Models;

namespace ToyRobot.Lib.Validators
{
    public static class CommandHelpers
    {
        public static bool IsValidCommand(string command, bool isFirstCommand)
        {
            return isFirstCommand ? Equals(command, RobotCommand.PLACE.ToString()):  Enum.IsDefined(typeof(RobotCommand), command);
        }

        public static bool IsValidParam(string parameters, bool isFirstCommand)
        {
            if (string.IsNullOrEmpty(parameters))
                return false;
            var splitParameters = parameters.Split(',');
            if (!(splitParameters.Length >= 2 && splitParameters.Length <= 3))
                return false;
            if (isFirstCommand && splitParameters.Length != 3)
                return false;
            if (!int.TryParse(splitParameters[0], out int x) || !int.TryParse(splitParameters[1], out int y))
                return false;
            if ((x > 5 || x < 0) || (y > 5 || y < 0))
                return false;
            if (splitParameters.Length == 3 && !Enum.IsDefined(typeof(Direction), splitParameters[2]))
                return false;
            return true;
        }

        public static bool IsValidPosition(int x, int y)
        {
            return (x < 0 || x > 5 || y > 5 || y < 0) ? false : true; 
        }

        public static Position ParseCommandParams(string parameters)
        {
            var splitParameters = parameters.Split(',');
            Direction? direction = null;
            int.TryParse(splitParameters[0], out var x);
            int.TryParse(splitParameters[1], out var y);
            if(splitParameters.Length == 3)
            {
                Enum.TryParse(splitParameters[2], out Direction parsedDirection);
                direction = parsedDirection;
            }
            return new Position
            {
                X = x,
                Y = y,
                Direction = direction
            };
        }
    }
}
