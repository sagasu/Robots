using System.Collections.Generic;
using System.IO;

namespace Robots
{
    public class FileHandler
    {
        public IList<string> GetAllLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}
