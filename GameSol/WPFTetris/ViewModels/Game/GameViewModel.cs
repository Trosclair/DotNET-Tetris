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
using WPFTetris.ViewModels.Parameters;
using WPFTetris.ViewModels.Settings;

namespace WPFTetris.ViewModels.Game
{
    public class GameViewModel : ObservableObject
    {
        private int playerCount;
        private long frameRateTime = 0;
        private int frameRate = 0;
        private bool isPaused;
        private static Stopwatch globalTimer = MainViewModel.GlobalTimer;
        private Visibility pauseMenuVisibility = Visibility.Collapsed;

        public ObservableCollection<BoardViewModel> Boards { init; get; } = new();
        public BoardViewModel BoardOne { get => Boards[0]; set => Boards[0] = value; }
        public BoardViewModel BoardTwo { get => Boards[1]; set => Boards[1] = value; }
        public BoardViewModel BoardThree { get => Boards[2]; set => Boards[2] = value; }
        public BoardViewModel BoardFour { get => Boards[3]; set => Boards[3] = value;  }
        public int FrameRate { get => frameRate; set { frameRate = value; OnPropertyChanged(nameof(FrameRate)); } }
        public bool IsPaused { get => isPaused; set { isPaused = value; } }
        public int PlayerCount { get => playerCount; set { playerCount = value; OnPropertyChanged(nameof(PlayerCount)); } }
        public Visibility PauseMenuVisibility { get => pauseMenuVisibility; set { pauseMenuVisibility = value; OnPropertyChanged(nameof(PauseMenuVisibility)); } }

        public SettingsViewModel Settings { init; get; }
        public ParametersViewModel Parameters { init; get; }

        public GameViewModel(SettingsViewModel settings, ParametersViewModel parameters, int playerCount = 1)
        {
            Settings = settings;
            Parameters = parameters;
            PlayerCount = playerCount;

            for (int i = 0; i < playerCount; i++)
            {
                Boards.Add(new(Settings, Parameters, Pause, i));
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
            
            if (!isPaused)
            {
                for (int i = 0; i < Boards.Count(); i++)
                {
                    Boards[i].CheckForInput();

                    if (isPaused)
                    {
                        break;
                    }
                }
            }
        }

        public void Pause()
        {
            IsPaused = true;
            PauseMenuVisibility = Visibility.Visible;
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
