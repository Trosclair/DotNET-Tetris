using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using WPFUtilities;
using WPFUtilities.Commands;
using WPFTetris.ViewModels.Game;

namespace WPFTetris.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        private GameViewModel? game = null;
        public static Stopwatch GlobalTimer = new();
        public GameViewModel? Game { get => game; set { game = value; OnPropertyChanged(nameof(Game)); } }
        //public SettingsViewModel Settings { get; }
        //public ParametersViewModel Parameters { get; }
        public RelayCommand CustomGameSetupCommand => new(CustomGameSetup);
        public RelayCommand QuickGameCommand => new(QuickGame);
        public RelayCommand OptionsCommand => new(Options);

        public MainViewModel()
        {
            GlobalTimer.Start();
            //Settings = new(new());      // TODO Deserialize settings here.
            //Parameters = new(new());    // IBID
            //QuickGame();
        }

        public void CustomGameSetup()
        {

        }

        public void QuickGame()
        {
            Game = new(new(new()), new(new()));
            CompositionTarget.Rendering +=  Game.Loop;
        }

        public void Options()
        {

        }
    }
}
