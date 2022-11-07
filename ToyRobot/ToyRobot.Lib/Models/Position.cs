namespace ToyRobot.Lib.Models
{
    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction? Direction { get; set; }
    }
}
