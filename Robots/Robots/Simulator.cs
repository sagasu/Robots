using System;

namespace Robots
{
    /// <summary>
    /// Controls Robot movement on a board.
    /// </summary>
    public class Simulator
    {
        private readonly Board _board;

        private Robot _robot;

        public Simulator(int boardWidth, int boardHeight, Robot robot) : this(new Board(boardHeight, boardWidth), robot) { }

        public Simulator(Board board, Robot robot)
        {
            _board = board;
            _robot = robot;
        }

        public RobotStatus Forward()
        {
            if (_board.IsValidPosition(_robot.GetForwardProjection()))
            {
                _robot.Forward();
                return RobotStatus.Alive;
            }
            
            return RobotStatus.Lost;
        }

        public void Left()
        {
            _robot.TurnLeft();
        }

        public void Right()
        {
            _robot.TurnRight();
        }

        public void SetRobot(Robot robot)
        {
            _robot = robot;
        }

        public string Report()
        {
            var positionReport = _robot.ToString();
            Console.WriteLine(positionReport);
            return positionReport;
        }
    }
}
