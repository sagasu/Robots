using System.Collections.Generic;
using NUnit.Framework;
using Robots;


namespace RobotsTests
{
    [TestFixture]
    class InputManagerTests
    {
        [TestCase("5 5","2 2 N","FF", "2 4 N")]
        [TestCase("5 5","0 0 N","FRF", "1 1 E")]
        [TestCase("5 5","0 0 E","FF", "2 0 E")]
        [TestCase("5 5","2 2 N","FFRFFRFF", "4 2 S")]
        public void Run_WhenOneRobotPostionAndRobotMovementProvided_RobotEndsInExpectedPlace(
            string firstLine, string secondLine, string thirdLine, string expectedPosition)
        {
            var im = new InputManager();
            var commands = new List<string> {firstLine, secondLine, thirdLine};

            im.Run(commands);

            Assert.AreEqual(expectedPosition, im.Report());
        }
    }
}
