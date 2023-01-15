using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Netris.Models.Settings.Video;
using WPFUtilities;

namespace Netris.ViewModels.Settings.Video
{
    public class VideoSettingsViewModel : ObservableObject
    {
        private readonly VideoSettings model;
        private ResolutionViewModel resolution;
        private ResolutionViewModel windowResolution;

        public ResolutionCollection Resolutions { get; private set; }
        public ResolutionViewModel Resolution { get => resolution; set { resolution = value; model.Resolution = value.Model; OnPropertyChanged(nameof(Resolution)); } }
        public ResolutionViewModel WindowResolution { get => windowResolution; set { windowResolution = value; model.WindowResolution = value.Model; OnPropertyChanged(nameof(WindowResolution)); } }
        public WindowState WindowState { get => model.WindowState; set { model.WindowState = value; OnPropertyChanged(nameof(WindowState)); } }
        public WindowStyle WindowStyle { get => model.WindowStyle; set { model.WindowStyle = value; OnPropertyChanged(nameof(WindowStyle)); } }
        public ResizeMode ResizeMode { get => model.ResizeMode; set { model.ResizeMode = value; OnPropertyChanged(nameof(ResizeMode)); } }
        public bool UseWindowedMode { get => model.UseWindowedMode; set { model.UseWindowedMode = value; ChangeWindowedModeSettings(); OnPropertyChanged(nameof(UseWindowedMode)); } }

        public VideoSettingsViewModel(VideoSettings videoSettings) 
        {
            model = videoSettings;

            int currentScreenWidth = Convert.ToInt32(SystemParameters.PrimaryScreenWidth);
            int currentScreenHeight = Convert.ToInt32(SystemParameters.PrimaryScreenHeight);

            Resolutions = new(currentScreenWidth, currentScreenHeight);

            if (Resolutions.FirstOrDefault(x => x.Width == currentScreenWidth && x.Height == currentScreenHeight) is ResolutionViewModel res)
            {
                resolution = res;
                windowResolution = res;
            }
            else
            {
                ResolutionViewModel newRes = new(new(currentScreenWidth, currentScreenHeight)); 
                resolution = newRes;
                windowResolution = newRes;
            }
        }

        private void ChangeWindowedModeSettings()
        {
            if (UseWindowedMode)
            {
                WindowState = WindowState.Normal;
                WindowStyle = WindowStyle.SingleBorderWindow;
                ResizeMode = ResizeMode.CanResize;
            }
            else
            {
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
                ResizeMode = ResizeMode.NoResize;
            }
        }
    }
}
