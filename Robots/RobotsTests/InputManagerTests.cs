﻿using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
        [TestCase("5 3","1 1 E","RFRFRFRF", "1 1 E")]
        public void Run_WhenOneRobotPostionAndRobotMovementProvided_RobotEndsInExpectedPlace(
            string firstLine, string secondLine, string thirdLine, string expectedPosition)
        {
            var im = new InputManager();
            var commands = new List<string> {firstLine, secondLine, thirdLine};

            im.Run(commands);

            Assert.AreEqual(expectedPosition, im.Report());
        }

        [TestCase("5 3","3 2 N","FRRFLLFFRRFLL", "3 3 N LOST")]
        public void Run_WhenOneRobotMovesOutOfBoard_RobotIsLostInRightPlace(
            string firstLine, string secondLine, string thirdLine, string expectedPosition)
        {
            var im = new InputManager();
            var commands = new List<string> {firstLine, secondLine, thirdLine};

            im.Run(commands);

            Assert.AreEqual(expectedPosition, im.Report());
        }

        [TestCase("1 50", "0 0 N", "R")]
        [TestCase("3 3", "50 0 N", "R")]
        [TestCase("4 55", "0 0 N", "R")]
        public void Run_WhenCoordinatesLargerThen50_ThenApplicationStopsWorkingAndReturnsMinusOneExitCode(string firstLine, string secondLine, string thirdLine)
        {
            var im = new InputManager();
            var commands = new List<string> { firstLine, secondLine, thirdLine };

            var returnCode = im.Run(commands);

            Assert.AreEqual(-1, returnCode);
        }

        [TestCase("5 5", "0 0 N", "RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR")]
        [TestCase("20 20", "3 3 N", "RFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRFRF")]
        [TestCase("20 20", "5 5 N", "LFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFFLFF")]
        public void Run_WhenMoreThen100Commands_ThenApplicationStopsWorkingAndReturnsMinusOneExitCode(string firstLine, string secondLine, string thirdLine)
        {
            var im = new InputManager();
            var commands = new List<string> { firstLine, secondLine, thirdLine };

            var returnCode = im.Run(commands);

            Assert.AreEqual(-1, returnCode);
        }

        [TestCase("5 5", "2 2 N", "FF")]
        [TestCase("5 5", "0 0 N", "FRF")]
        [TestCase("5 5", "0 0 E", "FF")]
        [TestCase("5 5", "2 2 N", "FFRFFRFF")]
        [TestCase("5 3", "1 1 E", "RFRFRFRF")]
        public void Run_WhenCoordinatesAreValid_ThenRunMethodReturns0ExitCode(string firstLine, string secondLine, string thirdLine)
        {
            var im = new InputManager();
            var commands = new List<string> { firstLine, secondLine, thirdLine };

            var returnCode = im.Run(commands);

            Assert.AreEqual(0, returnCode);
        }

        [Test]
        public void Run_WhenRobotFindsScentOfLostRobot_ThenItIsPreventedFromMovingForward()
        {
            var im = new InputManager();
            var commands = new List<string> { "5 3", "3 2 N", "FRRFLLFFRRFLL", "3 2 N", "FRRFLLFFRRFLL" };

            im.Run(commands);

            Assert.AreEqual("3 2 N", im.Report());
        }

        [Test]
        public void Run_WhenFileIsUsedToControlThreeRobots_ThenPositionOfRobotsIsPritedCorrectly()
        {
            var im = new InputManager();

            im.Run($"{GetCurrentDirectoryPath()}/threeRobots.txt");

            Assert.AreEqual("2 3 S", im.Report());
        }

        private static string GetCurrentDirectoryPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", string.Empty);
        }
    }
}
