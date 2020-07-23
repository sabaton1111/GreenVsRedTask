using System;
using System.Collections.Generic;

namespace GreenVsRed
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<string> rows = new Queue<string>();

            Console.Write("x (width): ");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.Write("y (height): ");
            int height = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < height; i++)
            {
                Console.WriteLine("Enter row number {0}:", i+1);
                string row = Console.ReadLine();
                rows.Enqueue(row);
            }

            Console.Write("x1: ");
            int x1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("y1: ");
            int y1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Number of generations: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Game game = new Game(width, height, x1, y1, n);

            game.ReadRows(rows);
            Console.WriteLine("{0}", game.NGenerations());
        }
    }
}
