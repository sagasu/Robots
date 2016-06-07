using System;
using System.Collections.Generic;
using System.Linq;

namespace Robots
{
    public class InputManager
    {
        private Simulator _simulator;
        private readonly RobotService _robotService;

        public InputManager()
        {
            _robotService = new RobotService();
        }

        public void Run(string path)
        {
            Run(new FileHandler().GetAllLines(path));
        }

        public int Run(IList<string> getAllLines)
        {
            try
            {
                TryRun(getAllLines);
            }
            catch (IllegalInputException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            return 0;

        }

        private void TryRun(IList<string> getAllLines)
        {
            var board = BuildBoard(getAllLines.First());
            var isRobotPositionCommand = true;

            foreach (var command in getAllLines.Skip(1))
            {
                if (isRobotPositionCommand)
                {
                    var robot = _robotService.BuildRobot(command);
                    if (_simulator == null)
                    {
                        _simulator = new Simulator(board, robot);
                    }
                    else
                    {
                        _simulator.SetRobot(robot);
                    }

                    isRobotPositionCommand = false;
                    continue;
                }

                _robotService.MoveRobot(command, _simulator);
                isRobotPositionCommand = true;
                _simulator.ReportToCommandLine();
            }
        }

        public string Report()
        {
            return _simulator.Report();
        }
        
        private Board BuildBoard(string command)
        {
            var boardParameters = command.Split(' ');
            var height = CoordinatesValidator.Parse(boardParameters[1]) + 1;
            var width = CoordinatesValidator.Parse(boardParameters[0]) + 1;

            return new Board(height, width);
        }
    }
}
