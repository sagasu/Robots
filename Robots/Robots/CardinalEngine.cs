using System.Collections.Generic;

namespace Robots
{
    public interface ICardinalEngine
    {
        Position Forward(Position position);
        ICardinalEngine GetLeftEngine();
        ICardinalEngine GetRightEngine();
        string CardinalDirection { get; }
    }

    public static class Cardinal
    {
        public static IEnumerable<ICardinalEngine> GetAllCardinalEngines()
        {
            yield return new NorthEngine();
            yield return new SouthEngine();
            yield return new EastEngine();
            yield return new WestEngine();
        }
    }

    public class NorthEngine : ICardinalEngine
    {
        public Position Forward(Position position)
        {
            return new Position(position.X, position.Y + 1);
        }

        public ICardinalEngine GetLeftEngine()
        {
            return new WestEngine();
        }

        public ICardinalEngine GetRightEngine()
        {
            return new EastEngine();
        }

        public string CardinalDirection => "N";
    }

    public class SouthEngine : ICardinalEngine
    {
        public Position Forward(Position position)
        {
            return new Position(position.X, position.Y - 1);
        }

        public ICardinalEngine GetLeftEngine()
        {
            return new EastEngine();
        }

        public ICardinalEngine GetRightEngine()
        {
            return new WestEngine();
        }

        public string CardinalDirection => "S";
    }

    public class WestEngine : ICardinalEngine
    {
        public Position Forward(Position position)
        {
            return new Position(position.X - 1, position.Y);
        }

        public ICardinalEngine GetLeftEngine()
        {
            return new SouthEngine();
        }

        public ICardinalEngine GetRightEngine()
        {
            return new NorthEngine();
        }

        public string CardinalDirection => "W";
    }

    public class EastEngine : ICardinalEngine
    {
        public Position Forward(Position position)
        {
            return new Position(position.X + 1, position.Y);
        }

        public ICardinalEngine GetLeftEngine()
        {
            return new NorthEngine();
        }

        public ICardinalEngine GetRightEngine()
        {
            return new SouthEngine();
        }

        public string CardinalDirection => "E";
    }


}
