using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace RobotsTests
{
    [TestFixture]
    class FileHandlerTests
    {

        [Test]
        public void GetAllLines_WhenCalledWithFilePath_ReadsCorrectlyFirstLine()
        {
            var fh = new FileHandler();
            var path = GetCurrentDirectoryPath();
            var lines = fh.GetAllLines($"{path}/robotCommands.txt");

            Assert.AreEqual("12 34", lines.First());
        }
        
        [Test]
        public void GetAllLines_WhenCalledWithFilePath_ReadsCorrectlyAllLines()
        {
            var fh = new FileHandler();
            var path = GetCurrentDirectoryPath();
            var lines = fh.GetAllLines($"{path}/robotCommands.txt");

            Assert.AreEqual("12 3456 78", string.Join(string.Empty, lines));
        }

        private static string GetCurrentDirectoryPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", string.Empty);
        }
    }
}
