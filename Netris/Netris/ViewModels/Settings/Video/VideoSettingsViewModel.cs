using System.Collections.ObjectModel;
using Netris.Models.Settings.Video;
using WPFUtilities;

namespace Netris.ViewModels.Settings.Video
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
