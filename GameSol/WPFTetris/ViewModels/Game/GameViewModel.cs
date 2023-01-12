using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFTetris.Models;
using WPFTetris.Utilities;
using WPFTetris.ViewModels.Settings;

namespace WPFTetris.ViewModels.Game
{
    public class GameViewModel : ObservableObject
    {
        private int playerCount;
        private long frameRateTime = 0;
        private int frameRate = 0;
        private static Stopwatch globalTimer;

        public ObservableCollection<BoardViewModel> Boards { init; get; } = new();
        public BoardViewModel BoardOne { get => Boards[0]; set => Boards[0] = value; }
        public BoardViewModel BoardTwo { get => Boards[1]; set => Boards[1] = value; }
        public BoardViewModel BoardThree { get => Boards[2]; set => Boards[2] = value; }
        public BoardViewModel BoardFour { get => Boards[3]; set => Boards[3] = value;  }
        public int FrameRate { get => frameRate; set { frameRate = value; OnPropertyChanged(nameof(FrameRate)); } }

        public int PlayerCount { get => playerCount; set { playerCount = value; OnPropertyChanged(nameof(PlayerCount)); } }
        public SettingsViewModel Settings { init; get; }

        public GameViewModel(SettingsViewModel settings, int playerCount = 1)
        {
            Settings = settings;
            PlayerCount = playerCount;
            globalTimer = MainViewModel.GlobalTimer;

            for (int i = 0; i < playerCount; i++)
            {
                Boards.Add(new(Settings, i));
            }
        }

        public void Loop()
        {
            if (globalTimer.ElapsedMilliseconds > frameRateTime + 1000)
            {
                FrameRate = frameRate;
                frameRate = 0;
                frameRateTime = globalTimer.ElapsedMilliseconds;
            }
            frameRate++;
            BoardOne.CheckForInput();
        }
        

        //public void HandleUserInput(Key key)
        //{
        //    switch (key)
        //    {
        //        case Key.A:
        //            currentPiece.MoveLeft();
        //            break;
        //        case Key.D:
        //            currentPiece.MoveRight();
        //            break;
        //        case Key.S:
        //            if (!currentPiece.MoveDown())
        //            {
        //                BoardOne.CheckBoardForLineClears();
        //                currentPiece = RightSideBar.Pop();
        //                BoardOne.AddPieceToBoard(currentPiece);
        //            }
        //            autoDropTime = globalTimer.ElapsedMilliseconds;
        //            break;
        //        case Key.E:
        //            BoardOne.RemovePieceFromBoard(currentPiece);
        //            currentPiece = RightSideBar.SwapHoldPiece(currentPiece);
        //            BoardOne.AddPieceToBoard(currentPiece);
        //            break;
        //        case Key.J:
        //            currentPiece.RotateCounterClockwise();
        //            break;
        //        case Key.K:
        //            currentPiece.RotateClockwise();
        //            break;
        //        case Key.W:
        //            currentPiece.HardDrop();
        //            BoardOne.CheckBoardForLineClears();
        //            currentPiece = RightSideBar.Pop();
        //            BoardOne.AddPieceToBoard(currentPiece);
        //            break;
        //        default:
        //            break;
        //    }
        //}
    }
}
