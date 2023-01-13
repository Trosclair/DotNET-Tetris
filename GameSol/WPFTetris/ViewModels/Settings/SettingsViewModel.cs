using WPFUtilities;
using Netris.Models.Settings;
using Netris.ViewModels.Settings.Controls;
using Netris.ViewModels.Settings.Gameplay;
using Netris.ViewModels.Settings.Video;

namespace Netris.ViewModels.Settings
{
    public class SettingsViewModel : ObservableObject
    {
        private SettingsModel model;

        public GameplaySettingsViewModel GameplaySettings { get; }
        public ControlsSettingsViewModel ControlSettings { get; }
        public VideoSettingsViewModel VideoSettings { get; }
        public SettingsViewModel(SettingsModel settings)
        {
            model = settings;

            VideoSettings = new(model.Video);
            GameplaySettings = new(model.Gameplay);
            ControlSettings = new(model.Controls);
        }
    }
}
