using System;

namespace GameSol
{
    internal class Program
    {
        private static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetWindowSize(43, 25);
            new Tetris();
        }
    }
}
