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
        private char _Letter = 'X';
        private readonly int[,] _Board = new int[20, 10];
        private readonly Random _R = new Random();
        private static int _lastTick;
        private static int _framelastTick;
        private static int _dropTimer;
        private static int _lastFrameRate;
        private static int _frameRate;

        public Tetris()
        {
            TitleScreen();
        }

        public void TitleScreen()
        {
            while (_Key.Key != ConsoleKey.Enter)
            {
                if (TickCount - _lastTick < 60) continue;
                GetKeyPress();
                PrintTitleScreen();
                _lastTick = TickCount;
            }
            _dropTimer = TickCount;
            ScoreAndStatistics.SetScoreAndStats();
            _CurrentPiece = NewPiece();
            _NextPiece = NewPiece();
            Start();
        }

        public void Start()
        {
            while (true)
            {         
                GetKeyPress();
                if (_CurrentPiece == null) continue;
                if (TickCount - _lastTick >= 60)
                {
                    _Board[_CurrentPiece.One.X, _CurrentPiece.One.Y] = 2;
                    _Board[_CurrentPiece.Two.X, _CurrentPiece.Two.Y] = 2;
                    _Board[_CurrentPiece.Three.X, _CurrentPiece.Three.Y] = 2;
                    _Board[_CurrentPiece.Four.X, _CurrentPiece.Four.Y] = 2;
                    PrintGameGui();
                    _lastTick = TickCount;
                }
                if (TickCount - _dropTimer >= 1000 - 50 * ScoreAndStatistics.Level)
                {
                    _CurrentPiece.ClearPositionFromAMove();
                    _CurrentPiece.MoveDown();
                    _dropTimer = TickCount;
                }
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
                if (TickCount - _lastTick < 60) continue;
                PrintGameOver();
            }
        }

        public void CheckMove()
        {
            var one = new Block(_CurrentPiece.One.X, _CurrentPiece.One.Y);
            var two = new Block(_CurrentPiece.Two.X, _CurrentPiece.Two.Y);
            var three = new Block(_CurrentPiece.Three.X, _CurrentPiece.Three.Y);
            var four = new Block(_CurrentPiece.Four.X, _CurrentPiece.Four.Y);
            try
            {
                _CurrentPiece.ClearPositionFromAMove();
                switch (_Key.Key)
                {
                    case ConsoleKey.K when _IsKeyPressed:
                        _CurrentPiece.RotateLeft();
                        break;
                    case ConsoleKey.L when _IsKeyPressed:
                        _CurrentPiece.RotateRight();
                        break;
                    case ConsoleKey.LeftArrow when _IsKeyPressed:
                        _CurrentPiece.MoveLeft();
                        break;
                    case ConsoleKey.DownArrow when _IsKeyPressed:
                        _CurrentPiece.MoveDown();
                        break;
                    case ConsoleKey.RightArrow when _IsKeyPressed:
                        _CurrentPiece.MoveRight();
                        break;
                }

                CheckOutOfBounds();

            }
            catch (IndexOutOfRangeException)
            {
                _CurrentPiece.One = new Block(one);
                _CurrentPiece.Two = new Block(two);
                _CurrentPiece.Three = new Block(three);
                _CurrentPiece.Four = new Block(four);
            }
        }

        public void CheckOutOfBounds()
        {
            if (_CurrentPiece.One.X > 19 || _CurrentPiece.One.X < 0 ||
                _CurrentPiece.Two.X > 19 || _CurrentPiece.Two.X < 0 ||
                _CurrentPiece.Three.X > 19 || _CurrentPiece.Three.X < 0 ||
                _CurrentPiece.Four.X > 19 || _CurrentPiece.Four.X < 0 ||
                _CurrentPiece.One.Y > 9 || _CurrentPiece.One.Y < 0 ||
                _CurrentPiece.Two.Y > 9 || _CurrentPiece.Two.Y < 0 ||
                _CurrentPiece.Three.Y > 9 || _CurrentPiece.Three.Y < 0 ||
                _CurrentPiece.Four.Y > 9 || _CurrentPiece.Four.Y < 0)
                throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Handles dropping Pieces and calls for the creation of a new piece
        /// </summary>
        public void DropPiece()
        {
            _CurrentPiece = _NextPiece;
            _NextPiece = NewPiece();
            if (_Board[_CurrentPiece.One.X, _CurrentPiece.One.Y] != 0 || _Board[_CurrentPiece.Two.X, _CurrentPiece.Two.Y] != 0 || _Board[_CurrentPiece.Three.X, _CurrentPiece.Three.Y] != 0 || _Board[_CurrentPiece.Four.X, _CurrentPiece.Four.Y] != 0)
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
                    if (_Board[i, j] == 0)
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
                    if (isClear && _Board[i, j] != 1) isClear = false;
                }

                if (!isClear) continue;
                linesCleared++;
                ClearLine(i);
                i++;
            }
            ScoreAndStatistics.UpdateScore(linesCleared);
        }

        public void ClearLine(int lineNumber)
        {
            // shifts the board starting at the line number down by one.
            for (var i = lineNumber; i >= 1; i--)
            {
                for (var j = 9; j >= 0; j--)
                {
                    _Board[i, j] = _Board[i - 1, j];
                }
            }
            for (var j = 0; j < 9; j++) _Board[0, j] = 0; // inserts blank row at top of the board.
        }

        public Piece NewPiece()
        {
            switch (_R.Next(0, 7))
            {
                case 0:
                    ScoreAndStatistics.L++;
                    _Letter = 'L';
                    return new L(_Board);
                case 1:
                    ScoreAndStatistics.J++;
                    _Letter = 'J';
                    return new J(_Board);             
                case 2:
                    ScoreAndStatistics.I++;
                    _Letter = 'I';
                    return new I(_Board);
                case 3:
                    ScoreAndStatistics.U++;
                    _Letter = 'U';
                    return new U(_Board);
                case 4:
                    ScoreAndStatistics.S++;
                    _Letter = 'S';
                    return new S(_Board);
                case 5:
                    ScoreAndStatistics.Z++;
                    _Letter = 'Z';
                    return new Z(_Board);
                case 6:
                    ScoreAndStatistics.T++;
                    _Letter = 'T';
                    return new T(_Board);
                default:
                    throw new ArgumentException();
            }
        }

        public void PrintGameGui()
        {
            var boardAsString = BoardToStringArr();
            Clear();
            Write(
$@"||||||||||||||||||||||||||||||||||||||||||
||||||||||||||||**TETRIS**||||||||||||||||
|||||SCORE:|||||----------|| NEXT PIECE ||
||||||||||||||||{boardAsString[0]}||||||||||||||||
|||||{ScoreAndStatistics.Score:000000}|||||{boardAsString[1]}||            ||
||||||||||||||||{boardAsString[2]}||            ||
|| STATISTICS ||{boardAsString[3]}||     {_Letter}      ||
||||||||||||||||{boardAsString[4]}||            ||
||| L - {ScoreAndStatistics.L:0000} |||{boardAsString[5]}||            ||
||||||||||||||||{boardAsString[6]}||            ||
||| J - {ScoreAndStatistics.J:0000} |||{boardAsString[7]}||||||||||||||||
||||||||||||||||{boardAsString[8]}|||LVL - {ScoreAndStatistics.Level:0000}|||
||| S - {ScoreAndStatistics.S:0000} |||{boardAsString[9]}||||||||||||||||
||||||||||||||||{boardAsString[10]}|||LINES:{ScoreAndStatistics.Lines:0000}|||
||| Z - {ScoreAndStatistics.Z:0000} |||{boardAsString[11]}||||||||||||||||
||||||||||||||||{boardAsString[12]}||||||||||||||||
||| I - {ScoreAndStatistics.I:0000} |||{boardAsString[13]}||||||||||||||||
||||||||||||||||{boardAsString[14]}||||||||||||||||
||| U - {ScoreAndStatistics.U:0000} |||{boardAsString[15]}||||||||||||||||
||||||||||||||||{boardAsString[16]}||||||||||||||||
||| T - {ScoreAndStatistics.T:0000} |||{boardAsString[17]}||||||FPS:||||||
||||||||||||||||{boardAsString[18]}||{CalculateFrameRate():000000000000}||
||||||||||||||||{boardAsString[19]}||||||||||||||||
||||||||||||||||||||||||||||||||||||||||||");
        }
        
        public void PrintGameOver()
        {
            Clear();
            Write(
$@"||||||||||||||||||||||||||||||||||||||||||
||||||||||||||||**TETRIS**||||||||||||||||
|||||SCORE:|||||----------|| NEXT PIECE ||
||||||||||||||||XXXXXXXXXX||||||||||||||||
|||||{ScoreAndStatistics.Score:000000}|||||XXXXXXXXXX||            ||
||||||||||||||||XXXXXXXXXX||            ||
|| STATISTICS ||XXXXXXXXXX||     {_Letter}      ||
||||||||||||||||XXXXXXXXXX||            ||
||| L - {ScoreAndStatistics.L:0000} |||XXXXXXXXXX||            ||
||||||||||||||||XXXXXXXXXX||            ||
||| J - {ScoreAndStatistics.J:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||| S - {ScoreAndStatistics.S:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||GAME__OVER||||||||||||||||
||| Z - {ScoreAndStatistics.Z:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||| I - {ScoreAndStatistics.I:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||| U - {ScoreAndStatistics.U:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||| T - {ScoreAndStatistics.T:0000} |||XXXXXXXXXX||||||FPS:||||||
||||||||||||||||XXXXXXXXXX||{CalculateFrameRate():000000000000}||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||||||||||||||||||||||||||||||||||||||||||");
            ReadLine();
            Exit(1);
        }

        public void PrintTitleScreen()
        {
            Clear();
            Write(
$@"||||||||||||||||||||||||||||||||||||||||||
||||||||||||||||**TETRIS**||||||||||||||||
|||||SCORE:|||||----------|| NEXT PIECE ||
||||||||||||||||XXXXXXXXXX||||||||||||||||
|||||{ScoreAndStatistics.Score:000000}|||||XXXXXXXXXX||            ||
||||||||||||||||XXXXXXXXXX||            ||
|| STATISTICS ||XXXXXXXXXX||     {_Letter}      ||
||||||||||||||||XXXXXXXXXX||            ||
||| L - {ScoreAndStatistics.L:0000} |||XXXXXXXXXX||            ||
||||||||||||||||XXXXXXXXXX||            ||
||| J - {ScoreAndStatistics.J:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||| S - {ScoreAndStatistics.S:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||PressEnter||||||||||||||||
||| Z - {ScoreAndStatistics.Z:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||| I - {ScoreAndStatistics.I:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||| U - {ScoreAndStatistics.U:0000} |||XXXXXXXXXX||||||||||||||||
||||||||||||||||XXXXXXXXXX||||||||||||||||
||| T - {ScoreAndStatistics.T:0000} |||XXXXXXXXXX||||||FPS:||||||
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