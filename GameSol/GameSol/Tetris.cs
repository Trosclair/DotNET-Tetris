using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameSol
{
    class Tetris
    {
        public enum PieceType { L, J, I, U, S, Z, T };
        Piece currPiece;
        public int[,] board = new int[20, 10];
        Random r = new Random();
        public enum GameState { TitleScreen, Game, GameOver};
        public GameState _gameState = GameState.TitleScreen;
        public int score = 0;
        public Tetris()
        {
            
        }

        public void Start()
        {
            while (true)
            {                
                if (_gameState == GameState.TitleScreen)
                {
                    PrintTitle();
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Update();
                    }
                }

                //keyboard input
                if (Console.ReadKey().Key == ConsoleKey.RightArrow)
                {
                    
                }
            }
        }

        public void Update()
        {
            printGameGUI();
        }

        public void FillBoardWithZero()
        {
            Array.Clear(board, 0, board.Length);
        }

        /// <summary>
        /// prints board directly... Phase this out.
        /// </summary>
        public string[] boardToStringArr()
        {
            StringBuilder sb = new StringBuilder();
            string[] arr = new string[20];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sb.Append(board[i, j].ToString());
                }
                arr[i] = sb.ToString();
                sb.Clear();
            }
            return arr;
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
            for (int i = 19; i >= 0; i--)
            {
                isClear = true;
                for (int j = 9; j >= 0; j--)
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
            for (int i = 19; i >= 1; i--)
            {
                for (int j = 9; j >= 0; j--)
                {
                    board[i, j] = board[i - 1, j];
                }
            }
            for (int j = 0; j < 9; j++) board[0, j] = 0; // inserts blank row at top of the board.
        }

        public void NewPiece()
        {
            currPiece = new Piece(r.Next(1, 8));
        }

        public void PrintTitle()
        {
            Console.WriteLine("");
        }

        public void printGameGUI()
        {
            string[] BoardAsString = boardToStringArr();
            StringBuilder sb = new StringBuilder();
            sb.Append("||||||||||||||||||||||||||||||||||||||||||\n"
                + "||||||||||||||||**TETRIS**||||||||||||||||\n"
                + "|||||SCORE:|||||----------|| NEXT PIECE ||");
            Console.WriteLine("||||||||||||||||"+ BoardAsString[0] +"||||||||||||||||");
        }
    }
}

/*
||||||||||||||||||||||||||||||||||||||||||c
||||||||||||||||**TETRIS**||||||||||||||||c
|||||SCORE:|||||----------|| NEXT PIECE ||c
||||||||||||||||0000000000||||||||||||||||
|||||000000|||||0000000000||            ||
||||||||||||||||0000000000||            ||
|| STATISTICS ||0000000000||            ||
||||||||||||||||0000000000||            ||
||| L - 0000 |||0000000000||            ||
||||||||||||||||0000000000||            ||
||| ⅃ - 0000 |||0000000000||||||||||||||||
||||||||||||||||0000000000||||||||||||||||
||| S - 0000 |||0000000000||||||||||||||||
||||||||||||||||0000000000||||||||||||||||
||| Z - 0000 |||0000000000||||||||||||||||
||||||||||||||||0000000000||||||||||||||||
||| | - 0000 |||0000000000||||||||||||||||
||||||||||||||||0000000000||||||||||||||||
||| U - 0000 |||0000000000||||||||||||||||
||||||||||||||||0000000000||||||||||||||||
||| T - 0000 |||0000000000||||||||||||||||
||||||||||||||||0000000000||||||||||||||||
||||||||||||||||0000000000||||||||||||||||
||||||||||||||||||||||||||||||||||||||||||

*/


/* // Test Fillboard/PrintBoard/checkLineclears
FillBoardWithZero();
board[19, 0] = 1;
board[19, 1] = 1;
board[19, 2] = 1;
board[19, 3] = 1;
board[19, 4] = 1;
board[19, 5] = 1;
board[19, 6] = 1;
board[19, 7] = 1;
board[19, 8] = 1;
board[19, 9] = 1;
board[18, 0] = 1;
board[18, 2] = 1;
PrintBoard();
CheckLineClears();
PrintBoard();
Console.ReadLine();
*/
