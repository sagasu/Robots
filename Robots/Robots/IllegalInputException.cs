using System;

namespace Robots
{
    [Serializable]
    internal class IllegalInputException : Exception
    {
        public IllegalInputException(string message) : base(message) {}
    }
}