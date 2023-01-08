using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFTetris.Utilities;
using WPFTetris.ViewModels.Pieces;

namespace WPFTetris.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        private Stopwatch globalTimer = new();
        private long autoDropTime = 0;
        private long currentDropTime = 0;
        private PieceViewModel currentPiece;
        private bool gameOver = false;
        public static BoardViewModel Board { get; } = new();
        public static RightSideBarViewModel RightSideBar { get; } = new();
        public MainViewModel()
        {
            currentPiece = RightSideBar.Pop();
            Board.AddPieceToBoard(currentPiece);
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
                    currentPiece.MoveLeft();
                    break;
                case Key.D:
                    currentPiece.MoveRight();
                    break;
                case Key.S:
                    if (!currentPiece.MoveDown())
                    {
                        Board.CheckBoardForLineClears();
                        currentPiece = RightSideBar.Pop();
                        Board.AddPieceToBoard(currentPiece);
                    }
                    autoDropTime = globalTimer.ElapsedMilliseconds;
                    break;
                case Key.E:
                    Board.RemovePieceFromBoard(currentPiece);
                    currentPiece = RightSideBar.SwapHoldPiece(currentPiece);
                    Board.AddPieceToBoard(currentPiece);
                    break;
                case Key.J:
                    currentPiece.RotateCounterClockwise();
                    break;
                case Key.K:
                    currentPiece.RotateClockwise();
                    break;
                case Key.W:
                    currentPiece.HardDrop();
                    Board.CheckBoardForLineClears();
                    currentPiece = RightSideBar.Pop();
                    Board.AddPieceToBoard(currentPiece);
                    break;
                default:
                    break;
            }
        }

    }
}
