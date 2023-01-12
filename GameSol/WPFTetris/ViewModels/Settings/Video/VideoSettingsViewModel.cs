using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTetris.Models.Settings.Video;
using WPFTetris.Utilities;

namespace WPFTetris.ViewModels.Settings.Video
{
    public class VideoSettingsViewModel : ObservableObject
    {
        private VideoSettings model;
        public static ObservableCollection<Resolution> Resolutions { get; } = new()
        {
            new(1920, 1080, Resolution.SixteenToNine),
            new(3840, 2160, Resolution.SixteenToNine)
        };

        public Resolution Resolution { get => model.Resolution; set { model.Resolution = value; OnPropertyChanged(nameof(Resolution)); } }

        public VideoSettingsViewModel(VideoSettings videoSettings) { model = videoSettings; }
    }
}
