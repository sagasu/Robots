using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Robots
{
    /// <summary>
    /// Controls Robot movement on a board.
    /// </summary>
    public class Simulator
    {
        private readonly Board _board;

        private readonly IList<string> _scent = new List<string>();

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

            if (_scent.Any(_ => _ == Report()))
                return RobotStatus.Alive;
            
            _scent.Add(Report());
            _robot.IsLost = true;
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

        public void ReportToCommandLine()
        {
            Console.WriteLine(_robot.ToString());
        }

        public string Report()
        {
            return _robot.ToString();
        }
    }
}
