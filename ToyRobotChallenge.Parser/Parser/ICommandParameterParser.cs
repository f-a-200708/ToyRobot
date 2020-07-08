using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotChallenge.ToyRobot.DataObject;

namespace ToyRobotChallenge.Parser
{
    public interface ICommandParameterParser
    {
        /// <summary>
        /// Parses the parameters of the command
        /// </summary>
        /// <param name="input">Takes string array as input</param>
        /// <returns>PlaceOnBoard</returns>
        PlaceOnBoard ParseCommandParameters(string[] input);
    }
}
