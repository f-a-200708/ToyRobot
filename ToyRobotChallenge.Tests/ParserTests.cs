using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotChallenge.Parser;
using ToyRobotChallenge.ToyRobot.DataObject;

namespace ToyRobotChallenge.Tests
{
    [TestClass]
    public class TestConsoleChecker
    {
        /// <summary>
        /// Test for place command's validity
        /// </summary>
        [TestMethod]
        public void TestForAValidPlaceCommand()
        {
            
            var inputParser = new InputParser();
            string[] rawInput = "PLACE".Split(' ');

            
            var command = inputParser.ParseCommand(rawInput);

           
            Assert.AreEqual(Command.PLACE, command);
        }

        /// <summary>
        /// Test an invalid place command
        /// </summary>
        [TestMethod]
        public void TestForAnInvalidPlaceCommand()
        {
            
            var inputParser = new InputParser();
            string[] input = "PLACETOY".Split(' ');
            
            var exception = Assert.ThrowsException<ArgumentException>(delegate { inputParser.ParseCommand(input); });
            Assert.AreEqual(exception.Message, "Invalid command. Please enter a valid command in the format: " +
                    "PLACE X,Y,F (where X and Y are coordinates on x and y axis respectively and F is the direction i.e. NORTH|SOUTH|EAST|WEST) " +
                    "or MOVE or LEFT or RIGHT or REPORT");
        }

        /// <summary>
        /// Test for place command with valid parameters and check success
        /// </summary>
        [TestMethod]
        public void TestForValidPlaceCommandAndParametersAndCheckSuccess()
        {
            
            var inputParser = new InputParser();
            string[] input = "PLACE 4,3,WEST".Split(' ');
           
            var placeOnBoard = inputParser.ParseCommandParameters(input);
            
            Assert.AreEqual(4, placeOnBoard.Position.X);
            Assert.AreEqual(3, placeOnBoard.Position.Y);
            Assert.AreEqual(Direction.West, placeOnBoard.Direction);
        }

        /// <summary>
        /// Test for place command with missing direction parameter
        /// </summary>
        [TestMethod]
        public void TestForPlaceCommandWithMissingDirectionParameter()
        {
            var inputParser = new InputParser();
            string[] input = "PLACE 3,1".Split(' ');

            var exception = Assert.ThrowsException<ArgumentException>(delegate
            { var placeCommandParameter = inputParser.ParseCommandParameters(input); });
            Assert.AreEqual(exception.Message, "Invalid command parameters. Please enter the PLACE command in the format: PLACE X,Y,F " +
                    "(where X and Y are coordinates on x and y axis respectively and F is the direction i.e. NORTH|SOUTH|EAST|WEST)");
        }

        /// <summary>
        /// Test for place command with an invalid direction parameter
        /// </summary>
        [TestMethod]
        public void TestForInvalidPlaceDirectionParameter()
        {
  
            var inputParser = new InputParser();
            string[] input = "PLACE 2,4,OneDirection".Split(' ');

            // act and assert
            var exception = Assert.ThrowsException<ArgumentException>(delegate { inputParser.ParseCommandParameters(input); });
            Assert.AreEqual(exception.Message, "Invalid direction. Please enter direction as one of the following : NORTH|SOUTH|EAST|WEST");
        }


    }
}
