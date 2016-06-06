using System.Collections.Generic;
using System.IO;

namespace RobotsTests
{
    public class FileHandler
    {
        public IEnumerable<string> GetAllLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}
