using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotChallenge.ToyRobotSimulator;

namespace ToyRobotChallenge
{
    class Program
    {
        static void Main(string[] args)
        {

            Simulator simulator = new Simulator();

            // run simulator to start processing user input commands from console
            simulator.Run();
        }
    }
}
