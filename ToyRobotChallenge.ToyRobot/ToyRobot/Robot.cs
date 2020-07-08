using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotChallenge.ToyRobot.DataObject;

namespace ToyRobotChallenge.ToyRobot
{
    public class Robot : IRobot
    {
        public PlaceOnBoard CurrentPlaceOnBoard { get; set; }
        
        public Robot()
        {
            CurrentPlaceOnBoard = new PlaceOnBoard();
        }

        public void Left()
        {
            switch (CurrentPlaceOnBoard.Direction)
            {
                case Direction.North:
                    CurrentPlaceOnBoard.Direction = Direction.West;
                    break;
                case Direction.West:
                    CurrentPlaceOnBoard.Direction = Direction.South;
                    break;
                case Direction.South:
                    CurrentPlaceOnBoard.Direction = Direction.East;
                    break;
                case Direction.East:
                    CurrentPlaceOnBoard.Direction = Direction.North;
                    break;

            }
        }

        public Position Move()
        {
            var newPosition = new Position(CurrentPlaceOnBoard.Position.X, CurrentPlaceOnBoard.Position.Y);

            switch (CurrentPlaceOnBoard.Direction)
            {
                case Direction.North:
                    newPosition.Y = newPosition.Y + 1;
                    break;
                case Direction.South:
                    newPosition.Y = newPosition.Y - 1;
                    break;
                case Direction.East:
                    newPosition.X = newPosition.X + 1;
                    break;
                case Direction.West:
                    newPosition.X = newPosition.X - 1;
                    break;
            }

            return newPosition;
        }

        public void Place(Position position, Direction direction)
        {
            CurrentPlaceOnBoard.Position = position;
            CurrentPlaceOnBoard.Direction = direction;
            CurrentPlaceOnBoard.IsPlaceSet = true;
        }

        public void Right()
        {
            switch (CurrentPlaceOnBoard.Direction)
            {
                case Direction.North:
                    CurrentPlaceOnBoard.Direction = Direction.East;
                    break;
                case Direction.East:
                    CurrentPlaceOnBoard.Direction = Direction.South;
                    break;
                case Direction.South:
                    CurrentPlaceOnBoard.Direction = Direction.West;
                    break;
                case Direction.West:
                    CurrentPlaceOnBoard.Direction = Direction.North;
                    break;

            }
        }

        public string GetReport()
        {
            return string.Format("Output: {0},{1},{2}", CurrentPlaceOnBoard.Position.X,
                CurrentPlaceOnBoard.Position.Y, CurrentPlaceOnBoard.Direction.ToString().ToUpper());
        }
    }
}
