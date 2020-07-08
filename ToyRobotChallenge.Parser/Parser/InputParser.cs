using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotChallenge.ToyRobot.DataObject;

namespace ToyRobotChallenge.Parser
{
    public class InputParser : ICommandParser, ICommandParameterParser
    {
        //Implements ICommandParser
        public Command ParseCommand(string[] input)
        {
            Command command;
            if (!Enum.TryParse(input[0], true, out command))
                throw new ArgumentException("Invalid command. Please enter a valid command in the format: " +
                    "PLACE X,Y,F (where X and Y are coordinates on x and y axis respectively and F is the direction i.e. NORTH|SOUTH|EAST|WEST) " +
                    "or MOVE or LEFT or RIGHT or REPORT");
            return command;
        }

        //Implements ICommandParameterParser
        public PlaceOnBoard ParseCommandParameters(string[] input)
        {
            Direction direction;
            Position position;

            var commandParameters = input[Constants.PlaceCommandParameterIndex].Split(Constants.PlaceCommandParameterSeparator);

            if (commandParameters.Length != Constants.PlaceCommandParameterCount)
            {
                throw new ArgumentException("Invalid command parameters. Please enter the PLACE command in the format: PLACE X,Y,F " +
                    "(where X and Y are coordinates on x and y axis respectively and F is the direction i.e. NORTH|SOUTH|EAST|WEST)");
            }

            if (!Enum.TryParse(commandParameters[Constants.PlaceCommandDirectionIndex], true, out direction))
                throw new ArgumentException("Invalid direction. Please enter direction as one of the following : NORTH|SOUTH|EAST|WEST");

            var x = Convert.ToInt32(commandParameters[Constants.PlaceCommandXIndex]);
            var y = Convert.ToInt32(commandParameters[Constants.PlaceCommandYIndex]);

            position = new Position(x, y);

            return new PlaceOnBoard(position, direction);
        }
    }
}
