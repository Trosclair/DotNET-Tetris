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
        //public enum PieceType { L, J, I, U, S, Z, T };
        Piece currPiece;
        public int[,] board = new int[20, 10];
        public enum GameState { TitleScreen, Game, GameOver};
        public GameState _gameState = GameState.TitleScreen;
        public ConsoleKeyInfo key;
        public struct ScoreAndStats
        {
            public int L;
            public int J;
            public int I;
            public int U;
            public int Z;
            public int S;
            public int T;
            public int Score;
        }
        public bool isDropping = false;
        public bool isKeyPressed;
        public ScoreAndStats _scoreAndStats;

        public struct Coordinates
        {
            public int X;
            public int Y;
        }

        public struct DroppedPiece
        {
            public Coordinates One;
            public Coordinates Two;
            public Coordinates Three;
            public Coordinates Four;
        }

        public DroppedPiece droppedPiece;


        public Tetris()
        {
            
        }

        public void Start()
        {
            ResetScoreAndStats();
            while (true)
            {
                GetKeyPress();
                
                if (
                    key.Key == ConsoleKey.Enter && 
                    isKeyPressed &&
                    _gameState != GameState.Game &&
                    _gameState != GameState.GameOver
                    )
                {
                    _gameState = GameState.Game;
                }
                if (isDropping)
                {
                    CheckMove();
                }

                if (System.Environment.TickCount - lastTick >= 60)
                {
                    Update();
                    if (_gameState == GameState.TitleScreen)
                    {
                        //if (Console.ReadKey().Key == ConsoleKey.Enter)
                        Update();
                    } // iskeypressed is used to indicate whether or not a key is still pressed since key var should always hold last key this avoids spamming.
                    lastTick = System.Environment.TickCount;
                }
            }
        }

        public void GetKeyPress()
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey();
                isKeyPressed = true;
            }
            else isKeyPressed = false;
        }

        public void Update()
        {
            if (_gameState == GameState.Game)
            {
                if (!isDropping)
                {
                    DropPiece();
                }
                board[droppedPiece.One.X, droppedPiece.One.Y] = 2;
                board[droppedPiece.Two.X, droppedPiece.Two.Y] = 2;
                board[droppedPiece.Three.X, droppedPiece.Three.Y] = 2;
                board[droppedPiece.Four.X, droppedPiece.Four.Y] = 2;
                printGameGUI();
            }
            
        }

        public void CheckMove()
        {
            if (key.Key == ConsoleKey.K && isKeyPressed)
            {
                TurnLeft();
            }
            else if (key.Key == ConsoleKey.L && isKeyPressed)
            {
                TurnRight();
            }
            else if (key.Key == ConsoleKey.A && isKeyPressed)
            {
                MoveLeft();
            }
            else if (key.Key == ConsoleKey.DownArrow && isKeyPressed)
            {
                MoveDown();
            }
            else if (key.Key == ConsoleKey.D && isKeyPressed)
            {
                MoveRight();
            }
        }

        public void TurnLeft()
        {

        }

        public void TurnRight()
        {

        }

        public void MoveLeft()
        {

        }

        public void MoveDown()
        {
            if (droppedPiece.One.X < 19 && droppedPiece.Two.X < 19 && droppedPiece.Three.X < 19 && droppedPiece.Four.X < 19)
            {
                if (
                    board[droppedPiece.One.X+1, droppedPiece.One.Y] != 1 &&
                    board[droppedPiece.Two.X+1, droppedPiece.Two.Y] != 1 &&
                    board[droppedPiece.Three.X+1, droppedPiece.Three.Y] != 1 &&
                    board[droppedPiece.Four.X+1, droppedPiece.Four.Y] != 1
                    )
                {
                    board[droppedPiece.One.X, droppedPiece.One.Y] = 0;
                    board[droppedPiece.Two.X, droppedPiece.Two.Y] = 0;
                    board[droppedPiece.Three.X, droppedPiece.Three.Y] = 0;
                    board[droppedPiece.Four.X, droppedPiece.Four.Y] = 0;
                    droppedPiece.One.X++;
                    droppedPiece.Two.X++;
                    droppedPiece.Three.X++;
                    droppedPiece.Four.X++;

                }
                else
                {
                    EndDrop();
                }
            }
            else
            {
                EndDrop();
            }
        }

        public void MoveRight()
        {

        }

        public void DropPiece()
        {
            isDropping = true;
            currPiece = NewPiece();

            switch (currPiece.CurrPiece) /// this switch can and needs to be merged with piece class. dropped piece could be used to create block objects vs struct.
            {
                case Piece.PieceType.L:
                    droppedPiece.One.X = 0;
                    droppedPiece.One.Y = 5;
                    droppedPiece.Two.X = 1;
                    droppedPiece.Two.Y = 5;
                    droppedPiece.Three.X = 2;
                    droppedPiece.Three.Y = 5;
                    droppedPiece.Four.X = 2;
                    droppedPiece.Four.Y = 6;
                    break;
                case Piece.PieceType.J:
                    droppedPiece.One.X = 0;
                    droppedPiece.One.Y = 5;
                    droppedPiece.Two.X = 1;
                    droppedPiece.Two.Y = 5;
                    droppedPiece.Three.X = 2;
                    droppedPiece.Three.Y = 5;
                    droppedPiece.Four.X = 2;
                    droppedPiece.Four.Y = 4;
                    break;
                case Piece.PieceType.S:
                    droppedPiece.One.X = 0;
                    droppedPiece.One.Y = 5;
                    droppedPiece.Two.X = 0;
                    droppedPiece.Two.Y = 6;
                    droppedPiece.Three.X = 1;
                    droppedPiece.Three.Y = 5;
                    droppedPiece.Four.X = 1;
                    droppedPiece.Four.Y = 4;
                    break;
                case Piece.PieceType.T:
                    droppedPiece.One.X = 0;
                    droppedPiece.One.Y = 5;
                    droppedPiece.Two.X = 1;
                    droppedPiece.Two.Y = 5;
                    droppedPiece.Three.X = 1;
                    droppedPiece.Three.Y = 6;
                    droppedPiece.Four.X = 1;
                    droppedPiece.Four.Y = 4;
                    break;
                case Piece.PieceType.Z:
                    droppedPiece.One.X = 0;
                    droppedPiece.One.Y = 5;
                    droppedPiece.Two.X = 0;
                    droppedPiece.Two.Y = 4;
                    droppedPiece.Three.X = 1;
                    droppedPiece.Three.Y = 5;
                    droppedPiece.Four.X = 1;
                    droppedPiece.Four.Y = 6;
                    break;
                case Piece.PieceType.U:
                    droppedPiece.One.X = 0;
                    droppedPiece.One.Y = 5;
                    droppedPiece.Two.X = 0;
                    droppedPiece.Two.Y = 4;
                    droppedPiece.Three.X = 1;
                    droppedPiece.Three.Y = 5;
                    droppedPiece.Four.X = 1;
                    droppedPiece.Four.Y = 4;
                    break;
                case Piece.PieceType.I:              
                    droppedPiece.One.X = 0;
                    droppedPiece.One.Y = 5;
                    droppedPiece.Two.X = 1;
                    droppedPiece.Two.Y = 5;
                    droppedPiece.Three.X = 2;
                    droppedPiece.Three.Y = 5;
                    droppedPiece.Four.X = 3;
                    droppedPiece.Four.Y = 5;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void EndDrop()
        {
            board[droppedPiece.One.X, droppedPiece.One.Y] = 1;
            board[droppedPiece.Two.X, droppedPiece.Two.Y] = 1;
            board[droppedPiece.Three.X, droppedPiece.Three.Y] = 1;
            board[droppedPiece.Four.X, droppedPiece.Four.Y] = 1;
            isDropping = false;
        }

        /// <summary>
        //  reset the board
        /// </summary>
        public void FillBoardWithZero()
        {
            Array.Clear(board, 0, board.Length);
        }

        /// <summary>
        /// creates a string array holding the board
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

        public Piece NewPiece()
        {
            Random r = new Random();
            return new Piece(r.Next(1, 8));
        }

        public void ResetScoreAndStats()
        {
            _scoreAndStats.L = 0;
            _scoreAndStats.I = 0;
            _scoreAndStats.S = 0;
            _scoreAndStats.T = 0;
            _scoreAndStats.Z = 0;
            _scoreAndStats.J = 0;
            _scoreAndStats.Score = 0;
        }

        public void printGameGUI()
        {
            string[] BoardAsString = boardToStringArr();
            StringBuilder sb = new StringBuilder();
            sb.Append(
                "||||||||||||||||||||||||||||||||||||||||||\n"
                + "||||||||||||||||**TETRIS**||||||||||||||||\n"
                + "|||||SCORE:|||||----------|| NEXT PIECE ||\n"
                +"||||||||||||||||" + BoardAsString[0] + "||||||||||||||||\n" +
                "|||||"+_scoreAndStats.Score.ToString("000000")+ "|||||" + BoardAsString[1] + "||            ||\n" +
                "||||||||||||||||" + BoardAsString[2] + "||            ||\n" +
                "|| STATISTICS ||" + BoardAsString[3] + "||            ||\n" +
                "||||||||||||||||" + BoardAsString[4] + "||            ||\n" +
                "||| L - "+_scoreAndStats.L.ToString("0000")+" |||" + BoardAsString[5] + "||            ||\n" +
                "||||||||||||||||" + BoardAsString[6] + "||            ||\n" +
                "||| J - " + _scoreAndStats.J.ToString("0000") + " |||" + BoardAsString[7] + "||||||||||||||||\n" +
                "||||||||||||||||" + BoardAsString[8] + "||||||||||||||||\n" +
                "||| S - " + _scoreAndStats.S.ToString("0000") + " |||" + BoardAsString[9] + "||||||||||||||||\n" +
                "||||||||||||||||" + BoardAsString[10] + "||||||||||||||||\n" +
                "||| Z - " + _scoreAndStats.Z.ToString("0000") + " |||" + BoardAsString[11] + "||||||||||||||||\n" +
                "||||||||||||||||" + BoardAsString[12] + "||||||||||||||||\n" +
                "||| I - " + _scoreAndStats.I.ToString("0000") + " |||" + BoardAsString[13] + "||||||||||||||||\n" +
                "||||||||||||||||" + BoardAsString[14] + "||||||||||||||||\n" +
                "||| U - " + _scoreAndStats.U.ToString("0000") + " |||" + BoardAsString[15] + "||||||||||||||||\n" +
                "||||||||||||||||" + BoardAsString[16] + "||||||||||||||||\n" +
                "||| T - " + _scoreAndStats.T.ToString("0000") + " |||" + BoardAsString[17] + "||||||FPS:||||||\n" +
                "||||||||||||||||" + BoardAsString[18] + "||"+ CalculateFrameRate().ToString("000000000000") +"||\n" +
                "||||||||||||||||" + BoardAsString[19] + "||||||||||||||||\n" +
                "||||||||||||||||||||||||||||||||||||||||||"
                );
            Console.Clear();
            Console.Write(sb.ToString());
        }

        private static int lastTick;
        private static int _lastTick;
        private static int lastFrameRate;
        private static int frameRate;

        public static int CalculateFrameRate()
        {
            if (System.Environment.TickCount - _lastTick >= 1000)
            {
                lastFrameRate = frameRate;
                frameRate = 0;
                _lastTick = System.Environment.TickCount;
            }
            frameRate++;
            return lastFrameRate;
        }
    }
}

/*
||||||||||||||||||||||||||||||||||||||||||c
||||||||||||||||**TETRIS**||||||||||||||||c
|||||SCORE:|||||----------|| NEXT PIECE ||c
||||||||||||||||0000000000||||||||||||||||c
|||||000000|||||0000000000||            ||c
||||||||||||||||0000000000||            ||c
|| STATISTICS ||0000000000||            ||c
||||||||||||||||0000000000||            ||c
||| L - 0000 |||0000000000||            ||c
||||||||||||||||0000000000||            ||c
||| ⅃ - 0000 |||0000000000||||||||||||||||c
||||||||||||||||0000000000||||||||||||||||c
||| S - 0000 |||0000000000||||||||||||||||c
||||||||||||||||0000000000||||||||||||||||c
||| Z - 0000 |||0000000000||||||||||||||||c
||||||||||||||||0000000000||||||||||||||||c
||| | - 0000 |||0000000000||||||||||||||||c
||||||||||||||||0000000000||||||||||||||||c
||| U - 0000 |||0000000000||||||||||||||||c
||||||||||||||||0000000000||||||||||||||||c
||| T - 0000 |||0000000000||||||||||||||||c
||||||||||||||||0000000000||||||||||||||||c
||||||||||||||||0000000000||||||||||||||||c
||||||||||||||||||||||||||||||||||||||||||c

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
