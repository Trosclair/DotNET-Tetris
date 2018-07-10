using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSol
{
    class Program
    {
        public enum PieceType { L, J, I, U, S, Z, T };
        Piece currPiece;
        int[,] board = new int[20, 10];

        static void Main(string[] args)
        {
            Tetris();
        }

        public static void Tetris()
        {
            while (true)
            {
                Console.ReadLine();
            }
        }

        public static void Update()
        {

        }

        /// <summary>
        /// checks board for clears of rows and returns the amount of lines cleared. Calls clearline to clear the lines manually
        /// 
        /// optimizable by checking if the next three lines below the line being cleared are clearable. instead of calling clear line 3 times.
        /// </summary>
        /// <returns></returns>
        public int CheckLineClears()
        {
            int linesCleared = 0;
            bool isClear;
            for (int i = 0; i < 19; i++)
            {
                isClear = true;
                for (int j = 0; j < 9; j++)
                {
                    if (isClear && board[i, j] != 1) isClear = false;  
                }
                if (isClear)
                {
                    linesCleared++;
                    ClearLine(i);
                }
            }
            return linesCleared;
        }

        public void ClearLine(int lineNumber)
        {
            // shifts the board starting at the line number down by one.
            for (int i = lineNumber; i < 18; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = board[i + 1, j];
                }
            }
            for (int j = 0; j < 9; j++) board[19, j] = 0; // inserts blank row at top of the board.
        }

        public void NewPiece()
        {
            Random r = new Random();
            currPiece = new Piece(r.Next(1, 8));
        }
    }
}
