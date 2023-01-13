using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using WPFUtilities;
using WPFUtilities.Commands;
using Netris.ViewModels.Parameters;
using Netris.ViewModels.Settings;

namespace Netris.ViewModels.Game
{
    public class GameViewModel : ObservableObject
    {
        private int playerCount;
        private long frameRateTime = 0;
        private int frameRate = 0;
        private bool isPaused;
        private static Stopwatch globalTimer = MainViewModel.GlobalTimer;
        private Visibility pauseMenuVisibility = Visibility.Collapsed;

        public ObservableCollection<PlayerViewModel> Boards { init; get; } = new();
        public PlayerViewModel BoardOne { get => Boards[0]; set => Boards[0] = value; }
        public PlayerViewModel BoardTwo { get => Boards[1]; set => Boards[1] = value; }
        public PlayerViewModel BoardThree { get => Boards[2]; set => Boards[2] = value; }
        public PlayerViewModel BoardFour { get => Boards[3]; set => Boards[3] = value;  }
        public int FrameRate { get => frameRate; set { frameRate = value; OnPropertyChanged(nameof(FrameRate)); } }
        public bool IsPaused { get => isPaused; set { isPaused = value; } }
        public int PlayerCount { get => playerCount; set { playerCount = value; OnPropertyChanged(nameof(PlayerCount)); } }
        public Visibility PauseMenuVisibility { get => pauseMenuVisibility; set { pauseMenuVisibility = value; OnPropertyChanged(nameof(PauseMenuVisibility)); } }

        public SettingsViewModel Settings { init; get; }
        public ParametersViewModel Parameters { init; get; }

        public RelayCommand QuitGameCommand => new(QuitGame);
        public RelayCommand ResumeGameCommand => new(ResumeGame);
        public RelayCommand OptionsCommand => new(Options);

        public GameViewModel(SettingsViewModel settings, ParametersViewModel parameters, int playerCount = 1)
        {
            Settings = settings;
            Parameters = parameters;
            PlayerCount = playerCount;

            for (int i = 0; i < playerCount; i++)
            {
                Boards.Add(new(Settings, Parameters, PauseGame, i));
            }
        }

        public void Loop(object? sender, EventArgs e)
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

        public void PauseGame()
        {
            IsPaused = true;
            PauseMenuVisibility = Visibility.Visible;
        }

        private void QuitGame()
        {
            CompositionTarget.Rendering -= Loop;
        }

        private void Options()
        {

        }

        private void ResumeGame()
        {
            PauseMenuVisibility = Visibility.Collapsed;
            IsPaused = false;
        }
    }
}
