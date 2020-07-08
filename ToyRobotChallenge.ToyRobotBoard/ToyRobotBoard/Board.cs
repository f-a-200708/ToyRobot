using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotChallenge.ToyRobot.DataObject;

namespace ToyRobotChallenge.ToyRobotBoard
{
    public class Board : IBoard
    {
        public int Rows { get; private set; }

        public int Columns { get; private set; }

        public Board(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }

        public bool IsValidPosition(Position position)
        {
            return position.X >= 0 && position.X < this.Columns &&
                position.Y >= 0 && position.Y < this.Rows;
        }
    }
}
