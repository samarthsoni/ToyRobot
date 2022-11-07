using ToyRobot.Lib.Handlers;

namespace ToyRobot.AppStart
{
    internal class Runner : IRunner
    {
        private readonly IRobotInvoker robotInvoker;

        public Runner(IRobotInvoker robotInvoker)
        {
            this.robotInvoker = robotInvoker;
        }

        public void Run()
        {
            string command;
            Console.WriteLine("..........................Welcome to Toy Robot.........................");
            Console.WriteLine("Please enter one of the following commands:");
            Console.WriteLine("PLACE");
            Console.WriteLine("MOVE");
            Console.WriteLine("LEFT");
            Console.WriteLine("RIGHT");
            Console.WriteLine("REPORT");
            Console.WriteLine("(OR Enter 'q' to quit)");
            do
            {
                command = Console.ReadLine() ?? string.Empty;
                robotInvoker.Action(command);
                Console.WriteLine();
            }
            while (!command.Equals("q", StringComparison.InvariantCultureIgnoreCase));
        }

        
    }
}
