using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Robots
{
    public class InputManager
    {
        private readonly IDictionary<string, Expression<Action>> _validOperations = new Dictionary
            <string, Expression<Action>>();

        private Simulator _simulator;

        public InputManager()
        {
            // closure on purpose 
            _validOperations.Add("F", () => _simulator.Forward());
            _validOperations.Add("L", () => _simulator.Left());
            _validOperations.Add("R", () => _simulator.Right());
        }

        public void Run(string path)
        {
            Run(new FileHandler().GetAllLines(path));
        }

        public void Run(IList<string> getAllLines)
        {
            var board = BuildBoard(getAllLines.First());
            var isRobotPositionCommand = true;

            foreach (var command in getAllLines.Skip(1))
            {
                if (isRobotPositionCommand)
                {
                    var robot = BuildRobot(command);
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

                MoveRobot(command);

            }
        }

        public string Report()
        {
            return _simulator.Report();
        }

        private void MoveRobot(string commands)
        {
            foreach (var command in commands)
            {
                _validOperations[command.ToString()].Compile().Invoke();
            }
        }


        private Robot BuildRobot(string command)
        {
            var robotParameters = command.Split(' ');
            var positionX = int.Parse(robotParameters[0]);
            var positionY = int.Parse(robotParameters[1]);
            var orientation = robotParameters[2];

            var cardinalEngine = Cardinal.GetAllCardinalEngines().FirstOrDefault(carEngine => carEngine.CardinalDirection == orientation);

            if (cardinalEngine == null)
            {
                Console.WriteLine("Incorrect robot position command it should have following format: 1 2 N");
            }

            return new Robot(new Position(positionX, positionY), cardinalEngine);
        }

        private Board BuildBoard(string command)
        {
            var boardParameters = command.Split(' ');
            var height = int.Parse(boardParameters[1]);
            var width = int.Parse(boardParameters[0]);

            return new Board(height, width);
        }
    }
}
