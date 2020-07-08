using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotChallenge.ToyRobot.DataObject;

namespace ToyRobotChallenge.ToyRobot
{
    public interface IRobot
    {
        PlaceOnBoard CurrentPlaceOnBoard { get; set; }

        // Sets the new position and direction of toy robot.
        void Place(Position position, Direction direction);

        // Rotates the direction of the toy robot 90 degrees to the left.
        void Left();

        // Rotates the direction of the toy robot 90 degrees to the right.
        void Right();

        // Returns the new position of the toy robot moving it by 1 unit in the direction it faces.      
        Position Move();

        // Gives the current position and direction i.e. place of the toy robot on the board. 
        string GetReport();
    }
}
