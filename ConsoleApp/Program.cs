using System;

namespace ConsoleApp
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please type the upper right coordinates of the plato with spaces between them.");

            string[] p = Console.ReadLine().Split(" ");

            int xmax = int.Parse(p[0]);

            int ymax = int.Parse(p[1]);

            var plateau = new Plateau(xmax, ymax);

            Console.WriteLine("Please type the deployment positon commands for the first rover, with spaces between them.");

            Rover rover1 = new Rover(plateau, Console.ReadLine());

            Console.WriteLine("Please type the instructions to explore the plateau for the first rover, without spaces between them.");

            rover1.ExecuteInstructions(Console.ReadLine());

            Console.WriteLine("Please type the deployment positon commands for the second rover, with spaces between them.");

            Rover rover2 = new Rover(plateau, Console.ReadLine());

            Console.WriteLine("Please type the instructions to explore the plateau for the first rover, without spaces between them.");

            rover2.ExecuteInstructions(Console.ReadLine());

            Console.WriteLine($"Firt Rover Position: {rover1.PositionResult()}");

            Console.WriteLine($"Second Rover Position: {rover2.PositionResult()}");

            Console.ReadKey();
        }
    }
}
