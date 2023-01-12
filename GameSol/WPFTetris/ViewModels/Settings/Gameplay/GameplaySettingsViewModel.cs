using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTetris.Models.Settings.Gameplay;
using WPFTetris.Utilities;

namespace WPFTetris.ViewModels.Settings.Gameplay
{
    public class GameplaySettingsViewModel : ObservableObject
    {
        private GameplaySettings model;

        public bool UseFocusMode { get => model.UseFocusMode; set { model.UseFocusMode = value; OnPropertyChanged(nameof(UseFocusMode)); } }
        public GameplaySettingsViewModel(GameplaySettings gameplaySettings)
        {
            model = gameplaySettings;
        }
    }
}
