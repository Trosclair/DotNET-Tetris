﻿using WPFUtilities;
using WPFTetris.Models.Settings.Gameplay;

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
