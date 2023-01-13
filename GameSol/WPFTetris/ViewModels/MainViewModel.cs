using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using WPFTetris.Models;
using WPFTetris.Utilities;
using WPFTetris.ViewModels.Game;
using WPFTetris.ViewModels.Game.Pieces;
using WPFTetris.ViewModels.Parameters;
using WPFTetris.ViewModels.Settings;
using WPFTetris.Views;

namespace WPFTetris.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        public static Stopwatch GlobalTimer { get; } = new();
        public static Dictionary<Key, (bool, long)> IsKeyPressed { get; } = new();
        public GameViewModel Game { get; }
        public SettingsViewModel Settings { get; }
        public ParametersViewModel Parameters { get; }
        public RelayCommand CustomGameSetupCommand => new(CustomGameSetup);
        public RelayCommand QuickGameCommand => new(QuickGame);
        public RelayCommand OptionsCommand => new(Options);

        public MainViewModel()
        {
            GlobalTimer.Start();
            Settings = new(new());      // TODO Deserialize settings here.
            Parameters = new(new());    // IBID
            Game = new(Settings, Parameters);
            QuickGame();
        }

        public void CustomGameSetup()
        {

        }

        public void QuickGame()
        {
            CompositionTarget.Rendering += (_1, _2) => Game.Loop();
        }

        public void Options()
        {

        }
    }
}
