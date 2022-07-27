using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TetrisLibrary;
using WPFTetris.Utilities;
using WPFTetris.ViewModels.Pieces;

namespace WPFTetris.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        private Piece? _CurrentPiece;
        private Piece? _NextPiece;
        private Stopwatch globalTimer = new();
        private long currentDropTime = 0;
        public BoardViewModel Board { get; } = new();
        public MainViewModel()
        {
            globalTimer.Start();
            Task.Run(Start);
        }

        public void Start()
        {
            while (true)
            {
                if (globalTimer.ElapsedMilliseconds > currentDropTime + 1000 - 50 * ScoreAndStatistics.Instance.Level)
                {
                    _CurrentPiece.ClearPositionFromAMove(Board);
                    _CurrentPiece.MoveDown(Board);
                    currentDropTime = globalTimer.ElapsedMilliseconds;
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


        public void CheckMove()
        {
            _CurrentPiece.ClearPositionFromAMove(Board);

            if (Keyboard.IsKeyDown(Key.J))
                _CurrentPiece.RotateLeft(Board);
            else if (Keyboard.IsKeyDown(Key.K))
                _CurrentPiece.RotateRight(Board);
            else if (Keyboard.IsKeyDown(Key.A))
                _CurrentPiece.MoveLeft(Board);
            else if (Keyboard.IsKeyDown(Key.S))
                _CurrentPiece.MoveDown(Board);
            else if (Keyboard.IsKeyDown(Key.D))
                _CurrentPiece.MoveRight(Board);
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
    }
}
