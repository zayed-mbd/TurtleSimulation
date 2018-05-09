using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurtleSim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Turtle Simulation");
            Console.WriteLine("---------");
            Console.WriteLine("");

            var driver = new TurtleDriver(new Turtle());

            while (true)
            {
                string command = PromptForCommand();
                if (command.ToUpper() == "EXIT" || command.ToUpper() == "QUIT")
                {
                    Environment.Exit(0);
                }
                Console.WriteLine(driver.Command(command));
            }
        }

        private static string PromptForCommand()
        {
            return Console.ReadLine();
        }


    }
}
