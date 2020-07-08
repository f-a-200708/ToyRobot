using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotChallenge.ToyRobotBoard;
using ToyRobotChallenge.ToyRobot;
using ToyRobotChallenge.Parser;
using ToyRobotChallenge.ToyRobot.DataObject;

namespace ToyRobotChallenge.Processor
{
    public class CommandProcessor
    {
        public IRobot Robot { get; private set; }
        public IBoard Board { get; private set; }
        public InputParser InputParser { get; private set; }
        public CommandProcessor(IRobot robot, IBoard board, InputParser inputParser)
        {
            this.Robot = robot;
            this.Board = board;
            this.InputParser = inputParser;
        }

        /// <summary>
        /// Processes the command for the toy robot entered by user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ProcessCommand(string[] input)
        {
            var command = InputParser.ParseCommand(input);
            if (command != Command.PLACE && !Robot.CurrentPlaceOnBoard.IsPlaceSet) 
                return string.Empty;

            switch (command)
            {
                case Command.PLACE:
                    var placeOnBoard = InputParser.ParseCommandParameters(input);
                    if (Board.IsValidPosition(placeOnBoard.Position))
                        Robot.Place(placeOnBoard.Position, placeOnBoard.Direction);
                    break;
                case Command.LEFT:
                    Robot.Left();
                    break;
                case Command.RIGHT:
                    Robot.Right();
                    break;
                case Command.MOVE:
                    var newPosition = Robot.Move();
                    if (Board.IsValidPosition(newPosition))
                        Robot.CurrentPlaceOnBoard.Position = newPosition;
                    break;
                case Command.REPORT:
                    return Robot.GetReport();
            }
            return string.Empty;
        }
    }
}
