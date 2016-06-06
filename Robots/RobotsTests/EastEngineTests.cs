using NUnit.Framework;
using Robots;

namespace RobotsTests
{
    [TestFixture]
    public class EastEngineTests
    {
        [TestCase(0,0,1,0)]
        [TestCase(1,1,2,1)]
        [TestCase(2,3,3,3)]
        public void Forward_FromStartPositionMovingForward_ReturnsCorrectEndPosition(int startX, int startY, int endX, int endY)
        {
            var engine = new EastEngine();
            var startingPosition = new Position(startX, startY);

            var newPosition = engine.Forward(startingPosition);

            Assert.AreEqual(new Position(endX, endY), newPosition);
        }
    }
}
