using NUnit.Framework;
using Robots;

namespace RobotsTests
{
    [TestFixture]
    class SimulatorTests
    {
        [TestCase(2,2)]
        [TestCase(3,4)]
        [TestCase(6,5)]
        public void Forward_WhenMoveIsLegal_ThenRobotIsAlive(int boardWidth, int boardHeight)
        {
            var simulator = new Simulator(boardWidth,boardHeight, new Robot(new NorthEngine()));

            var robotStatus = simulator.Forward();

            Assert.AreEqual(RobotStatus.Alive, robotStatus);
        }

        [TestCase(1, 1)]
        [TestCase(0, 0)]
        public void Forward_WhenMoveIsIllegal_ThenRobotIsLost(int boardWidth, int boardHeight)
        {
            var simulator = new Simulator(boardWidth, boardHeight, new Robot(new NorthEngine()));

            var robotStatus = simulator.Forward();

            Assert.AreEqual(RobotStatus.Lost, robotStatus);
        }

        [Test]
        public void Report_WhenCalledToPrintRobotPosition_ReturnsCorrectRobotPosition()
        {
            var simulator = new Simulator(2, 2, new Robot(new NorthEngine()));

            var robotPosition = simulator.Report();

            Assert.AreEqual("0 0 N", robotPosition);
        }

        [Test]
        public void SetRobot_WhenCalled_ChangesRobotInSimulator()
        {
            var firstRobot = new Robot(new NorthEngine());
            var simulator = new Simulator(2, 2, firstRobot);
            var secondRobot = new Robot(new EastEngine());

            simulator.SetRobot(secondRobot);

            Assert.AreEqual(new EastEngine().CardinalDirection, secondRobot.CardinalEngine.CardinalDirection);
        }

        [Test]
        public void Left_WhenTurnsLeft_ThenChangesCardinalEngineToLeftOne()
        {
            var simulator = new Simulator(2, 2, new Robot(new NorthEngine()));

            simulator.Left();

            Assert.AreEqual("0 0 W", simulator.Report());
        }

        [Test]
        public void Right_WhenTurnsRight_ThenChangesCardinalEngineToRightOne()
        {
            var simulator = new Simulator(2, 2, new Robot(new NorthEngine()));

            simulator.Right();

            Assert.AreEqual("0 0 E", simulator.Report());
        }

        [Test]
        public void Forward_WhenSecondRobotFindsScentOfLostRobot_ThenItIsPreventedToBeLostInThisSamePlace()
        {
            var simulator = new Simulator(2, 2, new Robot(new NorthEngine()));

            simulator.Forward();
            simulator.Forward(); // first robot is lost with this command
            simulator.SetRobot(new Robot(new NorthEngine()));
            simulator.Forward();
            simulator.Forward(); // second robot is prevented
            
            Assert.AreEqual("0 1 N", simulator.Report());
        }

        [Test]
        public void Forward_WhenRobotMovesOutisdeOfBoard_ThenItIsLost()
        {
            var simulator = new Simulator(2, 2, new Robot(new NorthEngine()));

            simulator.Forward();
            simulator.Forward();
            
            Assert.AreEqual("0 1 N LOST", simulator.Report());
        }
    }
}
