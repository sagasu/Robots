namespace Robots
{
    class ToyRobots
    {
        public static void Main(string[] args)
        {
            var path = args[0];
            new InputManager().Run(path);
        }
    }
}
