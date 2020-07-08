using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotChallenge.ToyRobot.DataObject;

namespace ToyRobotChallenge.Parser
{
    public interface ICommandParser
    {
        /// <summary>
        /// Parses the command to ensure it is valid
        /// </summary>
        /// <param name="input">takes string array as input</param>
        /// <returns>Command enum</returns>
        Command ParseCommand(string[] input);
    }
}
