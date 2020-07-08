using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotChallenge.ToyRobot.DataObject
{
    public class PlaceOnBoard
    {
        public Direction Direction { get; set; }
        public Position Position { get; set; }

        /// <summary>
        /// Determines if Robot's Place has been set on the board or not. This is used to PLACE is the first command to execute. 
        /// </summary>
        public bool IsPlaceSet { get; set; }

        public PlaceOnBoard()
        {
            IsPlaceSet = false;
            this.Position = new Position();
            this.Direction = new Direction();
        }

        public PlaceOnBoard(Position position, Direction direction)
        {
            this.Position = position;
            this.Direction = direction;
        }
    }
}
