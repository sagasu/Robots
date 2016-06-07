using System;
using Robots;

namespace ToyRobots
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please provide a valid path to a file that you want to use.");
            }

            var path = args[0];
            new InputManager().Run(path);
        }
    }
}
