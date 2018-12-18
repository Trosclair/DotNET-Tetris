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
        public Piece currPiece = null;
        public int[,] board = new int[20, 10];
        public enum GameState { TitleScreen, Game, GameOver};
        public GameState _gameState = GameState.TitleScreen;
        public ConsoleKeyInfo key;
        public bool isKeyPressed;
        public ScoreAndStatistics _scoreAndStats = new ScoreAndStatistics();
        public Random r = new Random();

        public Tetris() { }

        public void Start()
        {   
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
                if (currPiece != null && currPiece.IsDropping)
                {
                    CheckMove();
                }

                if (System.Environment.TickCount - lastTick >= 60)
                {
                    Update();
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
                if (currPiece == null || !currPiece.IsDropping)
                {
                    CheckLineClears();
                    DropPiece();
                }
                board[currPiece.One.X, currPiece.One.Y] = 2;
                board[currPiece.Two.X, currPiece.Two.Y] = 2;
                board[currPiece.Three.X, currPiece.Three.Y] = 2;
                board[currPiece.Four.X, currPiece.Four.Y] = 2;
                printGameGUI();
            }
            
        }

        public void CheckMove()
        {
            Block one = new Block(currPiece.One.X, currPiece.One.Y);
            Block two = new Block(currPiece.Two.X, currPiece.Two.Y);
            Block three = new Block(currPiece.Three.X, currPiece.Three.Y);
            Block four = new Block(currPiece.Four.X, currPiece.Four.Y);
            try
            {
                currPiece.ClearPositionFromAMove();
                if (key.Key == ConsoleKey.K && isKeyPressed)
                {
                    currPiece.RotateLeft();
                }
                else if (key.Key == ConsoleKey.L && isKeyPressed)
                {
                    currPiece.RotateRight();
                }
                else if (key.Key == ConsoleKey.LeftArrow && isKeyPressed)
                {
                    currPiece.MoveLeft();
                }
                else if (key.Key == ConsoleKey.DownArrow && isKeyPressed)
                {
                    currPiece.MoveDown();
                }
                else if (key.Key == ConsoleKey.RightArrow && isKeyPressed)
                {
                    currPiece.MoveRight();
                }
                bool a = board[currPiece.One.X, currPiece.One.Y] == 0 ||
                board[currPiece.Two.X, currPiece.Two.Y] == 0 ||
                board[currPiece.Three.X, currPiece.Three.Y] == 0 ||
                board[currPiece.Four.X, currPiece.Four.Y] == 0;
            }
            catch (IndexOutOfRangeException)
            {
                currPiece.One = new Block(one);
                currPiece.Two = new Block(two);
                currPiece.Three = new Block(three);
                currPiece.Four = new Block(four);
                
            }
        }

        /// <summary>
        /// Handles dropping Pieces and calls for the creation of a new piece
        /// </summary>
        public void DropPiece()
        {
            currPiece = NewPiece();
        }

        /// <summary>
        /// creates a string array holding the board 
        /// returns a string arr with each row of the board as an element in the array
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
        public void CheckLineClears()
        {
            int linesCleared = 0;
            bool isClear;
            for (int i = 19; i >= 0; i--)
            {
                isClear = true;
                for (int j = 0; j < 10; j++)
                {
                    if (isClear && board[i, j] != 1) isClear = false;
                }
                if (isClear)
                {
                    linesCleared++;
                    ClearLine(i);
                    i++;
                }
                
            }
            if (linesCleared == 1)
            {
                _scoreAndStats.Score += 100;
            }
            else if (linesCleared == 2)
            {
                _scoreAndStats.Score += 300;
            }
            else if (linesCleared == 3)
            {
                _scoreAndStats.Score += 600;
            }
            else if (linesCleared == 4)
            {
                _scoreAndStats.Score += 1000;
            }
        }

        public void ClearLine(int lineNumber)
        {
            // shifts the board starting at the line number down by one.
            for (int i = lineNumber; i >= 1; i--)
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
            switch ((r.Next(0, 7))) /// add score and stats functionallity 
            {
                case 0:
                    _scoreAndStats.L++;
                    return new L(board);
                case 1:
                    _scoreAndStats.J++;
                    return new J(board);             
                case 2:
                    _scoreAndStats.I++;
                    return new I(board);
                case 3:
                    _scoreAndStats.U++;
                    return new U(board);
                case 4:
                    _scoreAndStats.S++;
                    return new S(board);
                case 5:
                    _scoreAndStats.Z++;
                    return new Z(board);
                case 6:
                    _scoreAndStats.T++;
                    return new T(board);
                default:
                    throw new ArgumentException();
            }
        }

        public void printGameGUI()
        {
            string[] BoardAsString = boardToStringArr();
            Console.Clear();
            Console.Write(
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
