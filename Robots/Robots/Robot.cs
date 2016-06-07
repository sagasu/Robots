namespace Robots
{
    public class Robot
    {
        public Position Position { get; set; }
        public ICardinalEngine CardinalEngine { get; set; }
        public bool IsLost { get; set; }

        public Robot(ICardinalEngine cardinalEngine)
        {
            CardinalEngine = cardinalEngine;
            Position = new Position(x: 0, y: 0);
        }

        public Robot(Position position, ICardinalEngine cardinalEngine)
        {
            Position = position;
            CardinalEngine = cardinalEngine;
        }

        public Position GetForwardProjection()
        {
            return CardinalEngine.Forward(Position);
        }

        public void Forward()
        {
            Position = CardinalEngine.Forward(Position);
        }

        public void TurnLeft()
        {
            CardinalEngine = CardinalEngine.GetLeftEngine();
        }

        public void TurnRight()
        {
            CardinalEngine = CardinalEngine.GetRightEngine();
        }

        public override string ToString()
        {
            var isLostAdditionalInfo = IsLost ? " LOST" : string.Empty;
            return $"{Position.X} {Position.Y} {CardinalEngine.CardinalDirection}{isLostAdditionalInfo}";
        }
    }
}
