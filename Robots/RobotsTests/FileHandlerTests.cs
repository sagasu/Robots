using System;
using System.Linq;
using NUnit.Framework;

namespace RobotsTests
{
    [TestFixture]
    class FileHandlerTests
    {
        [Test]
        public void GetAllLines_WhenCalledWithoutFilePath_ReadsAllLinesFromDefaultFileLocation()
        {
            var fh = new FileHandler();
            var lines = fh.GetAllLines();

            Assert.AreEqual("00 11", lines.First());
        }

        [Test]
        public void GetAllLines_WhenCalledWithCustomFilePath_ReadsAllLinesFromSelectedFile()
        {
            var fh = new FileHandler();
            var lines = fh.GetAllLines("customRobotCommands.txt");

            Assert.AreEqual("12 34", lines.First());
        }
    }
}
