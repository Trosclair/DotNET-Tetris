﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using WPFUtilities;
using WPFUtilities.Commands;
using Netris.ViewModels.Game;
using System.Windows;
using System;
using WPFUtilities.Utilities;
using Netris.ViewModels.Settings;

namespace Netris.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        private GameViewModel? game = null;
        private bool isSettingsOpen = false;
        public static Stopwatch GlobalTimer = new();

        public GameViewModel? Game { get => game; set { game = value; OnPropertyChanged(nameof(Game)); } }
        public bool IsSettingsOpen { get => isSettingsOpen; set { isSettingsOpen = value; OnPropertyChanged(nameof(IsSettingsOpen)); } }
        public SettingsViewModel Settings { get; }
        //public ParametersViewModel Parameters { get; }
        public static FPSCounter FPSCounter { get; } = new();
        public RelayCommand CustomGameSetupCommand => new(CustomGameSetup);
        public RelayCommand QuickGameCommand => new(QuickGame);
        public RelayCommand OptionsCommand => new(Options);
        public RelayCommand QuitGameCommand => new(QuitGame);

        public MainViewModel()
        {
            GlobalTimer.Start();
            CompositionTarget.Rendering += RenderingLoop;
            Settings = new(new());      // TODO Deserialize settings here.
            //Parameters = new(new());    // IBID
        }

        private void RenderingLoop(object? sender, EventArgs e)
        {
            FPSCounter.UpdateFPS();

            Game?.GameLoop();
        }

        private void CustomGameSetup()
        {

        }

        private void QuickGame()
        {
            Game = new(new(new()), new(new()));
        }

        private void Options()
        {
            IsSettingsOpen ^= true;
        }

        private void QuitGame()
        {
            if (Game is not null)
            {
                Game.PauseMenuVisibility = Visibility.Collapsed;
                Game = null;
            }
        }
    }
}