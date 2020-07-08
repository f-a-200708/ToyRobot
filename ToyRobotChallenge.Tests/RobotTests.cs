using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotChallenge.ToyRobot;
using ToyRobotChallenge.ToyRobot.DataObject;

namespace ToyRobotChallenge.Tests
{
    [TestClass]
    public class RobotTests
    {
        /// <summary>
        /// Test robot for rotate left command
        /// </summary>
        [TestMethod]
        public void RotateRobotLeftAndCheckForSuccess()
        {
           
            var robot = new Robot();
            robot.CurrentPlaceOnBoard.Direction = Direction.West;
            robot.CurrentPlaceOnBoard.Position = new Position(2, 2);

            
            robot.Left();

            
            Assert.AreEqual(Direction.South, robot.CurrentPlaceOnBoard.Direction);
        }

        /// <summary>
        /// Test robot for rotate right command
        /// </summary>
        [TestMethod]
        public void RotateRobotRightAndCheckForSuccess()
        {
            
            var robot = new Robot();
            robot.CurrentPlaceOnBoard.Direction = Direction.West;
            robot.CurrentPlaceOnBoard.Position = new Position(2, 2);

            
            robot.Right();

            
            Assert.AreEqual(Direction.North, robot.CurrentPlaceOnBoard.Direction);
        }


        /// <summary>
        /// Test robot for move command
        /// </summary>
        [TestMethod]
        public void MoveRobotAndCheckForSuccess()
        {
            
            var robot = new Robot();
            robot.CurrentPlaceOnBoard.Direction = Direction.East;
            robot.CurrentPlaceOnBoard.Position = new Position(2, 2);

            
            var nextPosition = robot.Move();

            
            Assert.AreEqual(3, nextPosition.X);
            Assert.AreEqual(2, nextPosition.Y);
        }

        /// <summary>
        /// Test robot for place command
        /// </summary>
        [TestMethod]
        public void PlaceRobotByPositionAndDirectionAndCheckForSuccess()
        {
            
            var position = new Position(3, 3);
            var robot = new Robot();
                        
            robot.Place(position, Direction.North);

            
            Assert.AreEqual(3, robot.CurrentPlaceOnBoard.Position.X);
            Assert.AreEqual(3, robot.CurrentPlaceOnBoard.Position.Y);
            Assert.AreEqual(Direction.North, robot.CurrentPlaceOnBoard.Direction);
        }
    }
}
