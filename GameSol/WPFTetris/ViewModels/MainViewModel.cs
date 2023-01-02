using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFTetris.Utilities;

namespace WPFTetris.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        private Random random = new();
        private Stopwatch globalTimer = new();
        private long autoDropTime = 0;
        private long currentDropTime = 0;
        private PieceViewModel pieceViewModel;
        private bool gameOver = false;
        public BoardViewModel Board { get; } = new();
        public MainViewModel()
        {
            pieceViewModel = CreatePiece();
            Board.AddPieceToBoard(pieceViewModel);
            globalTimer.Start();
            Task.Run(Start);
        }

        private void Start()
        {
            while (!gameOver)
            {

            }
        }

        public void HandleUserInput(Key key)
        {
            switch (key)
            {
                case Key.A:
                    pieceViewModel.MoveLeft();
                    break;
                case Key.D:
                    pieceViewModel.MoveRight();
                    break;
                case Key.S:
                    if (!pieceViewModel.MoveDown())
                    {
                        pieceViewModel = CreatePiece();
                        Board.AddPieceToBoard(pieceViewModel);
                    }
                    autoDropTime = globalTimer.ElapsedMilliseconds;
                    break;
                case Key.J:
                    pieceViewModel.RotateCounterClockwise();
                    break;
                case Key.K:
                    pieceViewModel.RotateClockwise();
                    break;
                case Key.W:
                    pieceViewModel.HardDrop();
                    pieceViewModel = CreatePiece();
                    Board.AddPieceToBoard(pieceViewModel);
                    break;
                default:
                    break;
            }
        }

        private PieceViewModel CreatePiece()
        {
            return (PieceType)random.Next(0, 7) switch
            {
                PieceType.I => new I(Board),
                PieceType.T => new T(Board),
                PieceType.S => new S(Board),
                PieceType.Z => new Z(Board),
                PieceType.L => new L(Board),
                PieceType.J => new J(Board),
                PieceType.U => new U(Board),
                _ => throw new ArgumentException(),
            };
        }
    }
}
