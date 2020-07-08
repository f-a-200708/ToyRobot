using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotChallenge.ToyRobot.DataObject
{
    public class Position
    {
        /// <summary>
        /// x-coordinate to move the robot horizontally on the board  
        /// </summary>
        public int X { get; set; }
        
        /// <summary>
        /// y-coordinate to move the robot vertically on the board 
        /// </summary>
        public int Y { get; set; }

        public Position()
        {

        }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
