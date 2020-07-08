using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotChallenge.ToyRobot.DataObject;

namespace ToyRobotChallenge.ToyRobotBoard
{
    public interface IBoard
    {
        int Rows { get; }
        int Columns { get; }

        /// <summary>
        /// Checks if a position is valid as per the dimensions of the board.
        /// </summary>
        /// <param name="position"></param>
        /// <returns>boolean</returns>
        bool IsValidPosition(Position position);
    }
}
