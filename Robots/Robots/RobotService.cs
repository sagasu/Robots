using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Robots
{
    class RobotService
    {
        private readonly IDictionary<string, Expression<Func<Simulator, RobotStatus>>> _validOperations = new Dictionary
            <string, Expression<Func<Simulator,RobotStatus>>>();

        public RobotService()
        {
            _validOperations.Add("F", (simulator) => simulator.Forward());
            _validOperations.Add("L", (simulator) => Left(simulator));
            _validOperations.Add("R", (simulator) => Right(simulator));
        }

        private static RobotStatus Right(Simulator simulator)
        {
            simulator.Right();
            return RobotStatus.Alive;
        }

        private static RobotStatus Left(Simulator simulator)
        {
            simulator.Left();
            return RobotStatus.Alive;
        }

        public Robot BuildRobot(string command)
        {
            var robotParameters = command.Split(' ');
            var positionX = CoordinatesValidator.Parse(robotParameters[0]);
            var positionY = CoordinatesValidator.Parse(robotParameters[1]);
            var orientation = robotParameters[2];

            var cardinalEngine = Cardinal.GetAllCardinalEngines().FirstOrDefault(carEngine => carEngine.CardinalDirection == orientation);

            if (cardinalEngine == null)
                throw new IllegalInputException("Incorrect robot position command it should have following format: 1 2 N");

            return new Robot(new Position(positionX, positionY), cardinalEngine);
        }

        public void MoveRobot(string commands, Simulator simulator)
        {
            if (commands.Length >= 100)
                throw new IllegalInputException("Maximum number of commands must be less then 100.");

            foreach (var command in commands)
            {
                var robotStatus = _validOperations[command.ToString()].Compile().Invoke(simulator);
                if (robotStatus == RobotStatus.Lost)
                    return;
            }
        }

    }
}
