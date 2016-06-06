namespace Robots
{
    public class Board
    {
        private readonly int _boardHeight;
        private readonly int _boardWidth;

        public Board(int height, int width)
        {
            _boardWidth = width;
            _boardHeight = height;
        }

        public bool IsValidPosition(Position position)
        {
            return position.X >= 0 && position.X < _boardWidth&&
                   position.Y >= 0 && position.Y < _boardHeight;
        }
    }
}
