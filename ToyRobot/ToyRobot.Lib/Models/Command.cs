namespace ToyRobot.Lib.Models
{
    public enum RobotCommand
    {
        PLACE,
        MOVE,
        LEFT,
        RIGHT,
        REPORT
    }

    public class Command
    {
        public RobotCommand RobotCommand { get; set; }
        public Position CurrentPosition { get; set; }
    }
}
