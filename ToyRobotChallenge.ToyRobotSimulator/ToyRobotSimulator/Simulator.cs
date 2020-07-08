using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotChallenge.Parser;
using ToyRobotChallenge.Processor;
using ToyRobotChallenge.ToyRobot;
using ToyRobotChallenge.ToyRobotBoard;

namespace ToyRobotChallenge.ToyRobotSimulator
{
    public class Simulator
    {
        public void Run()
        {
            IBoard board = new Board(5, 5);         
            IRobot robot = new Robot();
            InputParser inputParser = new InputParser();
            var processor = new CommandProcessor(robot, board, inputParser);

            var runApplication = true;

            Console.WriteLine("");
            Console.WriteLine("******** Toy Robot Challenge ********");
            Console.WriteLine("Please enter commands in the below format : ");
            Console.WriteLine("LEFT|RIGHT|MOVE|REPORT|PLACE X,Y,F (where X and Y are coordinates on x and y axis and F is the direction i.e. NORTH|SOUTH|EAST|WEST)");
            Console.WriteLine("Commands are not case sensitive.");
            Console.WriteLine("To exit enter 'EXIT'");


            while (runApplication)
            {
                var command = Console.ReadLine();
                if (command == null) continue;

                if (command.ToUpper().Equals("EXIT"))
                    runApplication = false;
                else
                {
                    try
                    {
                        var output = processor.ProcessCommand(command.Split(' '));

                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }
        }
    }
}
