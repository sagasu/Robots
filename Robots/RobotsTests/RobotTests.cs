using NUnit.Framework;
using Robots;

namespace RobotsTests
{
    [TestFixture]
    class RobotTests
    {
        public void Forward_WhenCardinalEngineIsSetAndGoesForward_ReturnsCorrectPosition()
        {
            var engine = new NorthEngine();
            var robot = new Robot(engine);

            robot.Forward();

            Assert.AreEqual(new Position(0,1), robot.Position);
        }

        [Test]
        public void Forward_WhenCardinalEngineIsSetAndGoesForward_DoesntChangeOrientation()
        {
            var engine = new NorthEngine();
            var robot = new Robot(engine);

            robot.Forward();

            Assert.AreEqual(engine, robot.CardinalEngine);
        }

        [Test]
        public void TurnLeft_WhenCardinalEngineIsSetAndTurnsLeft_DoesntChangePosition()
        {
            var engine = new NorthEngine();
            var robot = new Robot(engine);

            robot.TurnLeft();

            Assert.AreEqual(new Position(0, 0), robot.Position);
        }

        [Test]
        public void TurnRight_WhenCardinalEngineIsSetAndTurnsRight_DoesntChangePosition()
        {
            var engine = new NorthEngine();
            var robot = new Robot(engine);

            robot.TurnRight();

            Assert.AreEqual(new Position(0, 0), robot.Position);
        }

        [Test]
        public void TurnRight_WhenCardinalEngineIsSetAndTurnsRight_ShouldChangeEngineToRightOne()
        {
            var engine = new NorthEngine();
            var robot = new Robot(engine);

            robot.TurnRight();

            Assert.AreEqual(new EastEngine().CardinalDirection, robot.CardinalEngine.CardinalDirection);
        }

        [Test]
        public void TurnLeft_WhenCardinalEngineIsSetAndTurnsLeft_ShouldChangeEngineToLeftOne()
        {
            var engine = new NorthEngine();
            var robot = new Robot(engine);

            robot.TurnLeft();

            Assert.AreEqual(new WestEngine().CardinalDirection, robot.CardinalEngine.CardinalDirection);
        }

        [Test]
        public void GetForwardProjection_WhenAskedForProjection_ReturnsChangedPosition()
        {
            var engine = new NorthEngine();
            var robot = new Robot(engine);

            var newPosition = robot.GetForwardProjection();

            Assert.AreEqual(new Position(0, 1), newPosition);
        }

        [Test]
        public void GetForwardProjection_WhenAskedForProjection_DoesntChangeThePositionOfRobot()
        {
            var engine = new NorthEngine();
            var robot = new Robot(engine);

            robot.GetForwardProjection();

            Assert.AreEqual(new Position(0, 0), robot.Position);
        }

        [Test]
        public void ToString_WhenAskedForRobotPosition_ReturnsPrettyPrintedPositionAndCardinalOrientation()
        {
            var engine = new NorthEngine();
            var robot = new Robot(engine);

            var prettyPrint = robot.ToString();

            Assert.AreEqual("0 0 N", prettyPrint);
        }
    }
}
