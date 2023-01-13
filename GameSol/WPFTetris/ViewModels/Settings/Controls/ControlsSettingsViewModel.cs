using Netris.Models.Settings.Controls;
using WPFUtilities;

namespace Netris.ViewModels.Settings.Controls
{
    public class ControlsSettingsViewModel : ObservableObject
    {
        private ControlsSettings model;
        public KeyboardPlayerControlsViewModel[] KeyboardViewModels { get; } = new KeyboardPlayerControlsViewModel[4];

        public KeyboardPlayerControlsViewModel PlayerOneKeyboard { get => KeyboardViewModels[0]; set => KeyboardViewModels[0] = value; }
        public KeyboardPlayerControlsViewModel PlayerTwoKeyboard { get => KeyboardViewModels[1]; set => KeyboardViewModels[1] = value; }
        public KeyboardPlayerControlsViewModel PlayerThreeKeyboard { get => KeyboardViewModels[2]; set => KeyboardViewModels[2] = value; }
        public KeyboardPlayerControlsViewModel PlayerFourKeyboard { get => KeyboardViewModels[3]; set => KeyboardViewModels[3] = value; }

        public ControlsSettingsViewModel(ControlsSettings controlsSettings)
        {
            model = controlsSettings;

            PlayerOneKeyboard = new(controlsSettings.PlayerOneKeyboard);
            PlayerTwoKeyboard = new(controlsSettings.PlayerTwoKeyboard);
            PlayerThreeKeyboard = new(controlsSettings.PlayerThreeKeyboard);
            PlayerFourKeyboard = new(controlsSettings.PlayerFourKeyboard);
        }
    }
}
