using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotChallenge.Parser;
using ToyRobotChallenge.Processor;
using ToyRobotChallenge.ToyRobot;
using ToyRobotChallenge.ToyRobot.DataObject;
using ToyRobotChallenge.ToyRobotBoard;

namespace ToyRobotChallenge.Tests
{
    [TestClass]
    public class ProcessorTests
    {
        /// <summary>
        /// Test for valid place command processing
        /// </summary>
        [TestMethod]
        public void TestForValidPlaceCommandProcessing()
        {
           
            IBoard board = new Board(5, 5);
            InputParser inputParser = new InputParser();
            IRobot robot = new Robot();
            var processor = new CommandProcessor(robot, board, inputParser);

            processor.ProcessCommand("PLACE 1,4,EAST".Split(' '));

            Assert.AreEqual(1, robot.CurrentPlaceOnBoard.Position.X);
            Assert.AreEqual(4, robot.CurrentPlaceOnBoard.Position.Y);
            Assert.AreEqual(Direction.East, robot.CurrentPlaceOnBoard.Direction);
        }

        /// <summary>
        /// Test for invalid place command processing
        /// </summary>
        [TestMethod]
        public void TestForInvalidPlaceCommandProcessing()
        {
            IBoard board = new Board(5, 5);
            InputParser inputParser = new InputParser();
            IRobot robot = new Robot();
            var processor = new CommandProcessor(robot, board, inputParser);

            processor.ProcessCommand("PLACE 9,7,EAST".Split(' '));

            Assert.AreEqual(robot.CurrentPlaceOnBoard.IsPlaceSet,false);
        }

        /// <summary>
        /// Test for valid move command processing
        /// </summary>
        [TestMethod]
        public void TestForValidMoveCommandProcessing()
        {
            IBoard board = new Board(5, 5);
            InputParser inputParser = new InputParser();
            IRobot robot = new Robot();
            var processor = new CommandProcessor(robot, board, inputParser);
            
            // valid place command since it is required as first command by processor 
            processor.ProcessCommand("PLACE 3,2,SOUTH".Split(' '));
            processor.ProcessCommand("MOVE".Split(' '));

            Assert.AreEqual("Output: 3,1,SOUTH", robot.GetReport());
        }

        /// <summary>
        /// Test for invalid move command processing
        /// </summary>
        [TestMethod]
        public void TestForInvalidMoveCommandProcessing()
        {
            IBoard board = new Board(5, 5);
            InputParser inputParser = new InputParser();
            IRobot robot = new Robot();
            var processor = new CommandProcessor(robot, board, inputParser);

            processor.ProcessCommand("PLACE 2,2,NORTH".Split(' '));
            processor.ProcessCommand("MOVE".Split(' '));
            processor.ProcessCommand("MOVE".Split(' '));

            // if the command will make the robot go out of the board it is ignored
            processor.ProcessCommand("MOVE".Split(' '));

            Assert.AreEqual("Output: 2,4,NORTH", robot.GetReport());
        }

        /// <summary>
        /// Test for valid set of commands on the board and test report
        /// </summary>
        [TestMethod]
        public void TestForValidSetOfCommandsOnBoardAndThenReport()
        {
            IBoard board = new Board(5, 5);
            InputParser inputParser = new InputParser();
            IRobot robot = new Robot();
            var processor = new CommandProcessor(robot, board, inputParser);

            processor.ProcessCommand("PLACE 3,3,WEST".Split(' '));
            processor.ProcessCommand("MOVE".Split(' '));
            processor.ProcessCommand("MOVE".Split(' '));
            processor.ProcessCommand("LEFT".Split(' '));
            processor.ProcessCommand("MOVE".Split(' '));
            var output = processor.ProcessCommand("REPORT".Split(' '));

            Assert.AreEqual("Output: 1,2,SOUTH", output);
        }
    }
}
