using NUnit.Framework;
using Robots;

namespace RobotsTests
{
    [TestFixture()]
    class BoardTests
    {
        [TestCase(0,0,1,1)]
        [TestCase(3,4,5,5)]
        [TestCase(1,7,2,8)]
        public void IsValidPosition_WhenPositionInsideBord_ThenPositionIsValid(int positionX, int positionY, int boardWidth, int boardHeight)
        {
            var board = new Board(boardHeight, boardWidth);

            var isValidPosition = board.IsValidPosition(new Position(positionX, positionY));

            Assert.True(isValidPosition);
        }

        [TestCase(1,0,1,1)]
        [TestCase(0,1,1,1)]
        [TestCase(3,3,2,2)]
        [TestCase(-1,1,2,2)]
        public void IsValidPosition_WhenPositionOutsideBord_ThenPositionIsInvalid(int positionX, int positionY, int boardWidth, int boardHeight)
        {
            var board = new Board(boardHeight, boardWidth);

            var isValidPosition = board.IsValidPosition(new Position(positionX, positionY));

            Assert.False(isValidPosition);
        }
    }
}
