using GameSol.Pieces;
using System;
using System.Text;
using static System.Console;
using static System.Environment;

namespace GameSol
{
    internal class Tetris
    {
        private Piece _CurrentPiece;
        private Piece _NextPiece;
        private ConsoleKeyInfo _Key;
        private bool _IsKeyPressed;
        private static int _framelastTick;
        private static int _dropTimer;
        private static int _lastFrameRate;
        private static int _frameRate;

        public int[,] Board { get; } = new int[20, 10];

        public Tetris()
        {
            TitleScreen();
        }

        public void TitleScreen()
        {
            while (_Key.Key != ConsoleKey.Enter)
            {
                GetKeyPress();
                PrintTitleScreen();
            }
            _dropTimer = TickCount;
            _CurrentPiece = Piece.NewPiece();
            _NextPiece = Piece.NewPiece();
            Start();
        }

        public void Start()
        {
            while (true)
            {
                GetKeyPress();

                if (_CurrentPiece.IsDropping)
                {
                    Board[_CurrentPiece.One.X, _CurrentPiece.One.Y] = 2;
                    Board[_CurrentPiece.Two.X, _CurrentPiece.Two.Y] = 2;
                    Board[_CurrentPiece.Three.X, _CurrentPiece.Three.Y] = 2;
                    Board[_CurrentPiece.Four.X, _CurrentPiece.Four.Y] = 2;
                }

                PrintGameGUI();

                if (TickCount - _dropTimer >= 1000 - 50 * ScoreAndStatistics.Instance.Level)
                {
                    _CurrentPiece.ClearPositionFromAMove(Board);
                    _CurrentPiece.MoveDown(Board);
                    _dropTimer = TickCount;
                }
                else
                {
                    if (_CurrentPiece.IsDropping)
                    {
                        CheckMove();
                    }
                    else
                    {
                        CheckLineClears();
                        DropPiece();
                    }
                }
            }
        }

        public void GetKeyPress()
        {
            if (KeyAvailable)
            {
                _Key = ReadKey();
                _IsKeyPressed = true;
            }
            else _IsKeyPressed = false;
        }

        public void GameOver()
        {
            while (_Key.Key != ConsoleKey.Enter)
            {
                GetKeyPress();
                PrintGameOver();
            }
        }

        public void CheckMove()
        {
            _CurrentPiece.ClearPositionFromAMove(Board);
            switch (_Key.Key)
            {
                case ConsoleKey.J when _IsKeyPressed:
                    _CurrentPiece.RotateLeft(Board);
                    break;
                case ConsoleKey.K when _IsKeyPressed:
                    _CurrentPiece.RotateRight(Board);
                    break;
                case ConsoleKey.A when _IsKeyPressed:
                    _CurrentPiece.MoveLeft(Board);
                    break;
                case ConsoleKey.S when _IsKeyPressed:
                    _CurrentPiece.MoveDown(Board);
                    break;
                case ConsoleKey.D when _IsKeyPressed:
                    _CurrentPiece.MoveRight(Board);
                    break;
            }
        }

        /// <summary>
        /// Handles dropping Pieces and calls for the creation of a new piece
        /// </summary>
        public void DropPiece()
        {
            _CurrentPiece = _NextPiece;
            _NextPiece = Piece.NewPiece();
            if (Board[_CurrentPiece.One.X, _CurrentPiece.One.Y] != 0 || 
                Board[_CurrentPiece.Two.X, _CurrentPiece.Two.Y] != 0 || 
                Board[_CurrentPiece.Three.X, _CurrentPiece.Three.Y] != 0 || 
                Board[_CurrentPiece.Four.X, _CurrentPiece.Four.Y] != 0)
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
            var sb = new StringBuilder();
            var arr = new string[20];
            for (var i = 0; i < 20; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    if (Board[i, j] == 0)
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
                    if (isClear && Board[i, j] != 1) isClear = false;
                }

                if (!isClear) continue;
                linesCleared++;
                ClearLine(i);
                i++;
            }
            ScoreAndStatistics.Instance.UpdateScoreOnLinesCleared(linesCleared);
        }

        public void ClearLine(int lineNumber)
        {
            // shifts the board starting at the line number down by one.
            for (var i = lineNumber; i >= 1; i--)
            {
                for (var j = 9; j >= 0; j--)
                {
                    Board[i, j] = Board[i - 1, j];
                }
            }
            for (var j = 0; j < 9; j++) Board[0, j] = 0; // inserts blank row at top of the board.
        }

        public void PrintGameGUI()
        {
            var boardAsString = BoardToStringArr();
            SetCursorPosition(0, 0);
            Write(
$@"||||||||||||||||||||||||||||||||||||||||||
||||||||||||||||**TETRIS**||||||||||||||||
|||||SCORE:|||||----------|| NEXT PIECE ||
||||||||||||||||{boardAsString[0]}||||||||||||||||
|||||{ScoreAndStatistics.Instance.Score:000000}|||||{boardAsString[1]}||            ||
||||||||||||||||{boardAsString[2]}||            ||
|| STATISTICS ||{boardAsString[3]}||     {_NextPiece.PieceLetter}      ||
||||||||||||||||{boardAsString[4]}||            ||
||| L - {ScoreAndStatistics.Instance.L:0000} |||{boardAsString[5]}||            ||
||||||||||||||||{boardAsString[6]}||            ||
||| J - {ScoreAndStatistics.Instance.J:0000} |||{boardAsString[7]}||||||||||||||||
||||||||||||||||{boardAsString[8]}|||LVL - {ScoreAndStatistics.Instance.Level:0000}|||
||| S - {ScoreAndStatistics.Instance.S:0000} |||{boardAsString[9]}||||||||||||||||
||||||||||||||||{boardAsString[10]}|||LINES:{ScoreAndStatistics.Instance.Lines:0000}|||
||| Z - {ScoreAndStatistics.Instance.Z:0000} |||{boardAsString[11]}||||||||||||||||
||||||||||||||||{boardAsString[12]}||||||||||||||||
||| I - {ScoreAndStatistics.Instance.I:0000} |||{boardAsString[13]}||||||||||||||||
||||||||||||||||{boardAsString[14]}||||||||||||||||
||| U - {ScoreAndStatistics.Instance.U:0000} |||{boardAsString[15]}||||||||||||||||
||||||||||||||||{boardAsString[16]}||||||||||||||||
||| T - {ScoreAndStatistics.Instance.T:0000} |||{boardAsString[17]}||||||FPS:||||||
||||||||||||||||{boardAsString[18]}||{CalculateFrameRate():000000000000}||
||||||||||||||||{boardAsString[19]}||||||||||||||||
||||||||||||||||||||||||||||||||||||||||||");
        }

        public void PrintGameOver()
        {
            SetCursorPosition(0, 0);
            Write(
$@"||||||||||||||||||||||||||||||||||||||||||
||||||||||||||||**TETRIS**||||||||||||||||
|||||SCORE:|||||----------|| NEXT PIECE ||
||||||||||||||||XXXXXXXXXX||||||||||||||||
|||||{ScoreAndStatistics.Instance.Score:000000}|||||XXXXXXXXXX||            ||
||||||||||||||||XXXXXXXXXX||            ||
|| STATISTICS ||XXXXXXXXXX||     {_NextPiece.PieceLetter}      ||
||||||||||||||||XXXXXXXXXX||            ||
||| L - {ScoreAndStatistics.Instance.L:0000} |||XXXXXXXXXX||            ||
||||||||||||||||XXXXXXXXXX||            ||
||| J - {ScoreAndStatistics.Instance.J:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||| S - {ScoreAndStatistics.Instance.S:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||GAME__OVER||||||||||||||||
||| Z - {ScoreAndStatistics.Instance.Z:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||| I - {ScoreAndStatistics.Instance.I:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||| U - {ScoreAndStatistics.Instance.U:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||| T - {ScoreAndStatistics.Instance.T:0000} |||XXXXXXXXXX||||||FPS:||||||
||||||||||||||||XXXXXXXXXX||{CalculateFrameRate():000000000000}||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||||||||||||||||||||||||||||||||||||||||||");
            ReadKey();
            Exit(1);
        }

        public void PrintTitleScreen()
        {
            SetCursorPosition(0, 0);
            Write(
$@"||||||||||||||||||||||||||||||||||||||||||
||||||||||||||||**TETRIS**||||||||||||||||
|||||SCORE:|||||----------|| NEXT PIECE ||
||||||||||||||||XXXXXXXXXX||||||||||||||||
|||||{ScoreAndStatistics.Instance.Score:000000}|||||XXXXXXXXXX||            ||
||||||||||||||||XXXXXXXXXX||            ||
|| STATISTICS ||XXXXXXXXXX||     X      ||
||||||||||||||||XXXXXXXXXX||            ||
||| L - {ScoreAndStatistics.Instance.L:0000} |||XXXXXXXXXX||            ||
||||||||||||||||XXXXXXXXXX||            ||
||| J - {ScoreAndStatistics.Instance.J:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||| S - {ScoreAndStatistics.Instance.S:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||PressEnter||||||||||||||||
||| Z - {ScoreAndStatistics.Instance.Z:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||| I - {ScoreAndStatistics.Instance.I:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||| U - {ScoreAndStatistics.Instance.U:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||| T - {ScoreAndStatistics.Instance.T:0000} |||XXXXXXXXXX||||||FPS:||||||
||||||||||||||||XXXXXXXXXX||{CalculateFrameRate():000000000000}||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||||||||||||||||||||||||||||||||||||||||||");
        }

        public static int CalculateFrameRate()
        {
            if (TickCount - _framelastTick >= 1000)
            {
                _lastFrameRate = _frameRate;
                _frameRate = 0;
                _framelastTick = TickCount;
            }
            _frameRate++;
            return _lastFrameRate;
        }
    }
}