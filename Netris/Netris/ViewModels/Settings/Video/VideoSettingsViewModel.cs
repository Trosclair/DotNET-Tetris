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

        public ResolutionCollection Resolutions { get; private set; }
        public ResolutionViewModel Resolution { get => resolution; set { resolution = value; model.Resolution = value.Model; OnPropertyChanged(nameof(Resolution)); } }
        public WindowState WindowState { get => model.WindowState; set { model.WindowState = value; OnPropertyChanged(nameof(WindowState)); } }
        public WindowStyle WindowStyle { get => model.WindowStyle; set { model.WindowStyle = value; OnPropertyChanged(nameof(WindowStyle)); } }
        public ResizeMode ResizeMode { get => model.ResizeMode; set { model.ResizeMode = value; OnPropertyChanged(nameof(ResizeMode)); } }
        public SizeToContent SizeToContent { get => model.SizeToContent; set { model.SizeToContent = value; OnPropertyChanged(nameof(SizeToContent)); } }
        public bool KeepWindowOnTop { get => model.KeepWindowOnTop; set { model.KeepWindowOnTop = value; OnPropertyChanged(nameof(KeepWindowOnTop)); } }
        public bool UseWindowedMode { get => model.UseWindowedMode; set { model.UseWindowedMode = value; OnPropertyChanged(nameof(UseWindowedMode)); } }

        public VideoSettingsViewModel(VideoSettings videoSettings) 
        {
            model = videoSettings;

            int currentScreenWidth = Convert.ToInt32(SystemParameters.PrimaryScreenWidth);
            int currentScreenHeight = Convert.ToInt32(SystemParameters.PrimaryScreenHeight);

            Resolutions = new(currentScreenWidth, currentScreenHeight);

            if (Resolutions.FirstOrDefault(x => x.Width == currentScreenWidth && x.Height == currentScreenHeight) is ResolutionViewModel res)
            {
                resolution = res;
            }
            else
            {
                ResolutionViewModel newRes = new(new(currentScreenWidth, currentScreenHeight)); 
                resolution = newRes;
            }
        }
    }
}
