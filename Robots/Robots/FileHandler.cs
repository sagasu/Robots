using System.Collections.Generic;
using System.IO;

namespace RobotsTests
{
    public class FileHandler
    {
        public IEnumerable<string> GetAllLines(string filePath = "robotCommands.txt")
        {
            return File.ReadAllLines(filePath);
        }
    }
}
