using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSol
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(43,25);
            Tetris Game = new Tetris();
            Game.Start();
        }  
    }
}
