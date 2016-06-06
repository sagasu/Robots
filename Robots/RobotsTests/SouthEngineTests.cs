using NUnit.Framework;
using Robots;

namespace RobotsTests
{
    [TestFixture]
    public class SouthEngineTests
    {
        [TestCase(0,0,0,-1)]
        [TestCase(1,1,1,0)]
        [TestCase(2,3,2,2)]
        public void Forward_FromStartPositionMovingForward_ReturnsCorrectEndPosition(int startX, int startY, int endX, int endY)
        {
            var se = new SouthEngine();
            var startingPosition = new Position(startX, startY);

            var newPosition = se.Forward(startingPosition);

            Assert.AreEqual(new Position(endX, endY), newPosition);
        }
    }
}
