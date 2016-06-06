using NUnit.Framework;
using Robots;

namespace RobotsTests
{
    [TestFixture]
    public class NorthEngineTests
    {
        [TestCase(0,0,0,1)]
        [TestCase(1,1,1,2)]
        [TestCase(2,3,2,4)]
        public void Forward_FromStartPositionMovingForward_ReturnsCorrectEndPosition(int startX, int startY, int endX, int endY)
        {
            var ne = new NorthEngine();
            var startingPosition = new Position(startX, startY);

            var newPosition = ne.Forward(startingPosition);

            Assert.AreEqual(new Position(endX, endY), newPosition);
        }
    }
}
