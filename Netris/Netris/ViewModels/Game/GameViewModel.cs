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
using Netris.ViewModels.Game.Pieces;
using WPFUtilities.Utilities;

namespace Netris.ViewModels.Game
{
    public class GameViewModel : ObservableObject
    {
        private int playerCount;
        private bool isPaused;

        public ObservableCollection<PlayerViewModel> Boards { init; get; } = new();
        public bool IsPaused { get => isPaused; set { isPaused = value; OnPropertyChanged(nameof(IsPaused)); } }
        public int PlayerCount { get => playerCount; set { playerCount = value; OnPropertyChanged(nameof(PlayerCount)); } }

        public SettingsViewModel Settings { init; get; }
        public ParametersViewModel Parameters { init; get; }

        public RelayCommand ResumeGameCommand => new(ResumeGame);
        public RelayCommand OptionsCommand => new(Options);

        public GameViewModel(SettingsViewModel settings, ParametersViewModel parameters, int playerCount = 4)
        {
            Settings = settings;
            Parameters = parameters;
            PlayerCount = playerCount;

            PieceFactory pieceFactory = new(parameters, true);

            for (int i = 0; i < playerCount; i++)
            {
                Boards.Add(new(Settings, Parameters, pieceFactory, PauseGame, i));
            }
        }

        public void GameLoop()
        {
            for (int i = 0; i < Boards.Count && !IsPaused; i++)
            {
                Boards[i].CheckForInput();
            }
        }

        public void PauseGame()
        {
            IsPaused = true;
        }


        private void Options()
        {

        }

        private void ResumeGame()
        {
            IsPaused = false;
        }
    }
}
