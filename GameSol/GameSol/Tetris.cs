using System;
using System.Text;
using GameSol.Pieces;
using static System.Environment;

namespace GameSol
{
    internal class Tetris
    {
        public Piece currentPiece;
        public Piece nextPiece;
        public int[,] board = new int[20, 10];
        public ConsoleKeyInfo key;
        public bool isKeyPressed;
        public ScoreAndStatistics scoreAndStats = new ScoreAndStatistics();
        public Random r = new Random();
        public char letter = 'X';
        public int level;
        public int lines;

        public Tetris()
        {
            nextPiece = NewPiece();
            TitleScreen();
        }

        public void TitleScreen()
        {
            while (key.Key != ConsoleKey.Enter)
            {
                if (TickCount - lastTick < 60) continue;
                GetKeyPress();
                PrintTitleScreen();
                lastTick = TickCount;
            }
            DropPiece();
            dropTimer = TickCount;
            Start();
        }

        public void Start()
        {   
            while (true)
            {         
                GetKeyPress();
                if (currentPiece != null && currentPiece.IsDropping)
                {
                    CheckMove();
                }
                if (TickCount - dropTimer >= 1000 - (50 * level))
                {
                    currentPiece.ClearPositionFromAMove();
                    currentPiece.MoveDown();
                    dropTimer = TickCount;
                }
                if (TickCount - lastTick >= 60)
                {
                    if (!currentPiece.IsDropping)
                    {
                        CheckLineClears();
                        DropPiece();
                    }
                    board[currentPiece.One.X, currentPiece.One.Y] = 2;
                    board[currentPiece.Two.X, currentPiece.Two.Y] = 2;
                    board[currentPiece.Three.X, currentPiece.Three.Y] = 2;
                    board[currentPiece.Four.X, currentPiece.Four.Y] = 2;
                    PrintGameGui();
                    lastTick = TickCount;
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

        public void GameOver()
        {
            while (key.Key != ConsoleKey.Enter)
            {
                GetKeyPress();
                if (TickCount - lastTick < 60) continue;
                PrintGameOver();
            }
        }

        public void CheckMove()
        {
            var one = new Block(currentPiece.One.X, currentPiece.One.Y);
            var two = new Block(currentPiece.Two.X, currentPiece.Two.Y);
            var three = new Block(currentPiece.Three.X, currentPiece.Three.Y);
            var four = new Block(currentPiece.Four.X, currentPiece.Four.Y);
            try
            {
                currentPiece.ClearPositionFromAMove();
                if (key.Key == ConsoleKey.K && isKeyPressed)
                {
                    currentPiece.RotateLeft();
                }
                else if (key.Key == ConsoleKey.L && isKeyPressed)
                {
                    currentPiece.RotateRight();
                }
                else if (key.Key == ConsoleKey.LeftArrow && isKeyPressed)
                {
                    currentPiece.MoveLeft();
                }
                else if (key.Key == ConsoleKey.DownArrow && isKeyPressed)
                {
                    currentPiece.MoveDown();
                }
                else if (key.Key == ConsoleKey.RightArrow && isKeyPressed)
                {
                    currentPiece.MoveRight();
                }

                CheckOutOfBounds();
            }
            catch (IndexOutOfRangeException)
            {
                currentPiece.One = new Block(one);
                currentPiece.Two = new Block(two);
                currentPiece.Three = new Block(three);
                currentPiece.Four = new Block(four);
            }
        }

        public void CheckOutOfBounds()
        {
            if (currentPiece.One.X > 19 || currentPiece.One.X < 0 ||
                currentPiece.Two.X > 19 || currentPiece.Two.X < 0 ||
                currentPiece.Three.X > 19 || currentPiece.Three.X < 0 ||
                currentPiece.Four.X > 19 || currentPiece.Four.X < 0 ||
                currentPiece.One.Y > 9 || currentPiece.One.Y < 0 ||
                currentPiece.Two.Y > 9 || currentPiece.Two.Y < 0 ||
                currentPiece.Three.Y > 9 || currentPiece.Three.Y < 0 ||
                currentPiece.Four.Y > 9 || currentPiece.Four.Y < 0)
                throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Handles dropping Pieces and calls for the creation of a new piece
        /// </summary>
        public void DropPiece()
        {
            currentPiece = nextPiece;
            nextPiece = NewPiece();
            if (board[currentPiece.One.X, currentPiece.One.Y] != 0 || board[currentPiece.Two.X, currentPiece.Two.Y] != 0 || board[currentPiece.Three.X, currentPiece.Three.Y] != 0 || board[currentPiece.Four.X, currentPiece.Four.Y] != 0)
            {
                GameOver();
            }
        }

        /// <summary>
        /// creates a string array holding the board 
        /// returns a string arr with each row of the board as an element in the array
        /// </summary>
        public string[] BoardToStringArr()
        {
            StringBuilder sb = new StringBuilder();
            string[] arr = new string[20];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board[i, j] == 0)
                    {
                        sb.Append("-");
                    }
                    else
                    {
                        sb.Append('█');
                    }

                }
                arr[i] = sb.ToString();
                sb.Clear();
            }
            return arr;
        }

        /// <summary>
        /// checks board for clears of rows and returns the amount of lines cleared. Calls clear line to clear the lines manually
        /// able to be optimized by checking if the next three lines below the line being cleared are able to be cleared. instead of calling clear line 3 times.
        /// </summary>
        /// <returns></returns>
        public void CheckLineClears()
        {
            var linesCleared = 0;
            for (var i = 19; i >= 0; i--)
            {
                var isClear = true;
                for (var j = 0; j < 10; j++)
                {
                    if (isClear && board[i, j] != 1) isClear = false;
                }

                if (!isClear) continue;
                linesCleared++;
                ClearLine(i);
                i++;

            }
            UpdateScore(linesCleared);
        }

        public void UpdateScore(int linesCleared)
        {
            if (linesCleared == 1)
            {
                scoreAndStats.Score += 100*(level+1);
            }
            else if (linesCleared == 2)
            {
                scoreAndStats.Score += 300*(level+1);
            }
            else if (linesCleared == 3)
            {
                scoreAndStats.Score += 600*(level+1);
            }
            else if (linesCleared == 4)
            {
                scoreAndStats.Score += 1000*(level+1);
            }
            lines += linesCleared;
            if ((level * 10) + 10 <= lines)
            {
                level++;
            }
        }

        public void ClearLine(int lineNumber)
        {
            // shifts the board starting at the line number down by one.
            for (var i = lineNumber; i >= 1; i--)
            {
                for (var j = 9; j >= 0; j--)
                {
                    board[i, j] = board[i - 1, j];
                }
            }
            for (var j = 0; j < 9; j++) board[0, j] = 0; // inserts blank row at top of the board.
        }

        public Piece NewPiece()
        {
            switch ((r.Next(0, 7))) // add score and stats functionality 
            {
                case 0:
                    scoreAndStats.L++;
                    letter = 'L';
                    return new L(board);
                case 1:
                    scoreAndStats.J++;
                    letter = 'J';
                    return new J(board);             
                case 2:
                    scoreAndStats.I++;
                    letter = 'I';
                    return new I(board);
                case 3:
                    scoreAndStats.U++;
                    letter = 'U';
                    return new U(board);
                case 4:
                    scoreAndStats.S++;
                    letter = 'S';
                    return new S(board);
                case 5:
                    scoreAndStats.Z++;
                    letter = 'Z';
                    return new Z(board);
                case 6:
                    scoreAndStats.T++;
                    letter = 'T';
                    return new T(board);
                default:
                    throw new ArgumentException();
            }
        }

        public void PrintGameGui()
        {
            string[] boardAsString = BoardToStringArr();
            Console.Clear();
            Console.Write(
                "||||||||||||||||||||||||||||||||||||||||||\n"
                + "||||||||||||||||**TETRIS**||||||||||||||||\n"
                + "|||||SCORE:|||||----------|| NEXT PIECE ||\n"
                +"||||||||||||||||" + boardAsString[0] + "||||||||||||||||\n" +
                "|||||"+scoreAndStats.Score.ToString("000000")+ "|||||" + boardAsString[1] + "||            ||\n" +
                "||||||||||||||||" + boardAsString[2] + "||            ||\n" +
                "|| STATISTICS ||" + boardAsString[3] + "||     "+letter+"      ||\n" +
                "||||||||||||||||" + boardAsString[4] + "||            ||\n" +
                "||| L - "+scoreAndStats.L.ToString("0000")+" |||" + boardAsString[5] + "||            ||\n" +
                "||||||||||||||||" + boardAsString[6] + "||            ||\n" +
                "||| J - " + scoreAndStats.J.ToString("0000") + " |||" + boardAsString[7] + "||||||||||||||||\n" +
                "||||||||||||||||" + boardAsString[8] + "|||LVL - "+level.ToString("0000")+"|||\n" +
                "||| S - " + scoreAndStats.S.ToString("0000") + " |||" + boardAsString[9] + "||||||||||||||||\n" +
                "||||||||||||||||" + boardAsString[10] + "|||LINES:" + lines.ToString("0000") + "|||\n" +
                "||| Z - " + scoreAndStats.Z.ToString("0000") + " |||" + boardAsString[11] + "||||||||||||||||\n" +
                "||||||||||||||||" + boardAsString[12] + "||||||||||||||||\n" +
                "||| I - " + scoreAndStats.I.ToString("0000") + " |||" + boardAsString[13] + "||||||||||||||||\n" +
                "||||||||||||||||" + boardAsString[14] + "||||||||||||||||\n" +
                "||| U - " + scoreAndStats.U.ToString("0000") + " |||" + boardAsString[15] + "||||||||||||||||\n" +
                "||||||||||||||||" + boardAsString[16] + "||||||||||||||||\n" +
                "||| T - " + scoreAndStats.T.ToString("0000") + " |||" + boardAsString[17] + "||||||FPS:||||||\n" +
                "||||||||||||||||" + boardAsString[18] + "||"+ CalculateFrameRate().ToString("000000000000") +"||\n" +
                "||||||||||||||||" + boardAsString[19] + "||||||||||||||||\n" +
                "||||||||||||||||||||||||||||||||||||||||||"
                );
        }
        
        public void PrintGameOver()
        {
            Console.Clear();
            Console.Write(
                "||||||||||||||||||||||||||||||||||||||||||\n"
                + "||||||||||||||||**TETRIS**||||||||||||||||\n"
                + "|||||SCORE:|||||----------|| NEXT PIECE ||\n"
                + "||||||||||||||||XXXXXXXXXX||||||||||||||||\n" +
                "|||||" + scoreAndStats.Score.ToString("000000") + "|||||XXXXXXXXXX||            ||\n" +
                "||||||||||||||||XXXXXXXXXX||            ||\n" +
                "|| STATISTICS ||XXXXXXXXXX||     " + letter + "      ||\n" +
                "||||||||||||||||XXXXXXXXXX||            ||\n" +
                "||| L - " + scoreAndStats.L.ToString("0000") + " |||XXXXXXXXXX||            ||\n" +
                "||||||||||||||||XXXXXXXXXX||            ||\n" +
                "||| J - " + scoreAndStats.J.ToString("0000") + " |||XXXXXXXXXX||||||||||||||||\n" +
                "||||||||||||||||XXXXXXXXXX||||||||||||||||\n" +
                "||| S - " + scoreAndStats.S.ToString("0000") + " |||XXXXXXXXXX||||||||||||||||\n" +
                "||||||||||||||||GAME__OVER||||||||||||||||\n" +
                "||| Z - " + scoreAndStats.Z.ToString("0000") + " |||XXXXXXXXXX||||||||||||||||\n" +
                "||||||||||||||||XXXXXXXXXX||||||||||||||||\n" +
                "||| I - " + scoreAndStats.I.ToString("0000") + " |||XXXXXXXXXX||||||||||||||||\n" +
                "||||||||||||||||XXXXXXXXXX||||||||||||||||\n" +
                "||| U - " + scoreAndStats.U.ToString("0000") + " |||XXXXXXXXXX||||||||||||||||\n" +
                "||||||||||||||||XXXXXXXXXX||||||||||||||||\n" +
                "||| T - " + scoreAndStats.T.ToString("0000") + " |||XXXXXXXXXX||||||FPS:||||||\n" +
                "||||||||||||||||XXXXXXXXXX||" + CalculateFrameRate().ToString("000000000000") + "||\n" +
                "||||||||||||||||XXXXXXXXXX||||||||||||||||\n" +
                "||||||||||||||||||||||||||||||||||||||||||"
                );
            Console.ReadLine();
            Exit(1);
        }

        public void PrintTitleScreen()
        {
            Console.Clear();
            Console.Write(
                "||||||||||||||||||||||||||||||||||||||||||\n"
                + "||||||||||||||||**TETRIS**||||||||||||||||\n"
                + "|||||SCORE:|||||----------|| NEXT PIECE ||\n"
                + "||||||||||||||||XXXXXXXXXX||||||||||||||||\n" +
                "|||||" + scoreAndStats.Score.ToString("000000") + "|||||XXXXXXXXXX||            ||\n" +
                "||||||||||||||||XXXXXXXXXX||            ||\n" +
                "|| STATISTICS ||XXXXXXXXXX||     " + letter + "      ||\n" +
                "||||||||||||||||XXXXXXXXXX||            ||\n" +
                "||| L - " + scoreAndStats.L.ToString("0000") + " |||XXXXXXXXXX||            ||\n" +
                "||||||||||||||||XXXXXXXXXX||            ||\n" +
                "||| J - " + scoreAndStats.J.ToString("0000") + " |||XXXXXXXXXX||||||||||||||||\n" +
                "||||||||||||||||XXXXXXXXXX||||||||||||||||\n" +
                "||| S - " + scoreAndStats.S.ToString("0000") + " |||XXXXXXXXXX||||||||||||||||\n" +
                "||||||||||||||||PressEnter||||||||||||||||\n" +
                "||| Z - " + scoreAndStats.Z.ToString("0000") + " |||XXXXXXXXXX||||||||||||||||\n" +
                "||||||||||||||||XXXXXXXXXX||||||||||||||||\n" +
                "||| I - " + scoreAndStats.I.ToString("0000") + " |||XXXXXXXXXX||||||||||||||||\n" +
                "||||||||||||||||XXXXXXXXXX||||||||||||||||\n" +
                "||| U - " + scoreAndStats.U.ToString("0000") + " |||XXXXXXXXXX||||||||||||||||\n" +
                "||||||||||||||||XXXXXXXXXX||||||||||||||||\n" +
                "||| T - " + scoreAndStats.T.ToString("0000") + " |||XXXXXXXXXX||||||FPS:||||||\n" +
                "||||||||||||||||XXXXXXXXXX||" + CalculateFrameRate().ToString("000000000000") + "||\n" +
                "||||||||||||||||XXXXXXXXXX||||||||||||||||\n" +
                "||||||||||||||||||||||||||||||||||||||||||");
        }

        private static int lastTick;
        private static int _lastTick;
        private static int dropTimer;
        private static int lastFrameRate;
        private static int frameRate;

        public static int CalculateFrameRate()
        {
            if (TickCount - _lastTick >= 1000)
            {
                lastFrameRate = frameRate;
                frameRate = 0;
                _lastTick = TickCount;
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
