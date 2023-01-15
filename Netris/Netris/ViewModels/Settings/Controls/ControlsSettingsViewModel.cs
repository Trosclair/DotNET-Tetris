using Netris.Models.Settings.Controls;
using System.Collections.ObjectModel;
using WPFUtilities;

namespace Netris.ViewModels.Settings.Controls
{
    public class ControlsSettingsViewModel : ObservableObject
    {
        private readonly ControlsSettings model;
        public ObservableCollection<KeyboardPlayerControlsViewModel> KeyboardViewModels { get; } = new();

        public KeyboardPlayerControlsViewModel PlayerOneKeyboard { get => KeyboardViewModels[0]; set => KeyboardViewModels[0] = value; }
        public KeyboardPlayerControlsViewModel PlayerTwoKeyboard { get => KeyboardViewModels[1]; set => KeyboardViewModels[1] = value; }
        public KeyboardPlayerControlsViewModel PlayerThreeKeyboard { get => KeyboardViewModels[2]; set => KeyboardViewModels[2] = value; }
        public KeyboardPlayerControlsViewModel PlayerFourKeyboard { get => KeyboardViewModels[3]; set => KeyboardViewModels[3] = value; }

        public ControlsSettingsViewModel(ControlsSettings controlsSettings)
        {
            model = controlsSettings;

            KeyboardViewModels.Add(new(model.PlayerOneKeyboard, KeyboardViewModels));
            KeyboardViewModels.Add(new(model.PlayerTwoKeyboard, KeyboardViewModels));
            KeyboardViewModels.Add(new(model.PlayerThreeKeyboard, KeyboardViewModels));
            KeyboardViewModels.Add(new(model.PlayerFourKeyboard, KeyboardViewModels));
        }
    }
}
