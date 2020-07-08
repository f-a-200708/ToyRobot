using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotChallenge.ToyRobot.DataObject;
using ToyRobotChallenge.ToyRobotBoard;

namespace ToyRobotChallenge.Tests
{
    [TestClass]
    public class TestBoard
    {

        /// <summary>
        /// Try to put a position outside of the board
        /// </summary>
        [TestMethod]
        public void TestInvalidBoardPosition()
        {
            // arrange
            Board board = new Board(5, 5);
            Position position = new Position(6, 6);

            // act
            var result = board.IsValidPosition(position);

            // assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Test for valid positon 
        /// </summary>
        [TestMethod]
        public void TestValidBoardPosition()
        {
            // arrange
            Board board = new Board(5, 5);
            Position position = new Position(1, 4);

            // act
            var result = board.IsValidPosition(position);

            // assert
            Assert.IsTrue(result);
        }

    }
}
