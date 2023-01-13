using WPFUtilities;
using WPFTetris.Models.Settings;
using WPFTetris.ViewModels.Settings.Controls;
using WPFTetris.ViewModels.Settings.Gameplay;
using WPFTetris.ViewModels.Settings.Video;

namespace WPFTetris.ViewModels.Settings
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
