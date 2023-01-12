using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFTetris.Models.Settings.Controls;
using WPFTetris.Utilities;

namespace WPFTetris.ViewModels.Settings.Controls
{
    public class KeyboardPlayerControlsViewModel : ObservableObject
    {
        private KeyboardPlayerControls model;
        public Key MoveDown { get => model.MoveDown; set { model.MoveDown = value; OnPropertyChanged(nameof(MoveDown)); } }
        public Key MoveRight { get => model.MoveRight; set { model.MoveRight = value; OnPropertyChanged(nameof(MoveRight)); } }
        public Key MoveLeft { get => model.MoveLeft; set { model.MoveLeft = value; OnPropertyChanged(nameof(MoveLeft)); } }
        public Key HardDrop { get => model.HardDrop; set { model.HardDrop = value; OnPropertyChanged(nameof(HardDrop)); } }
        public Key RotateClockwise { get => model.RotateClockwise; set { model.RotateClockwise = value; OnPropertyChanged(nameof(RotateClockwise)); } }
        public Key RotateCounterClockwise { get => model.RotateCounterClockwise; set { model.RotateCounterClockwise = value; OnPropertyChanged(nameof(RotateCounterClockwise)); } }
        public Key Hold { get => model.Hold; set { model.Hold = value; OnPropertyChanged(nameof(Hold)); } }
        public Key Pause { get => model.Pause; set { model.Pause = value; OnPropertyChanged(nameof(Pause)); } }
        public KeyboardPlayerControlsViewModel(KeyboardPlayerControls keyboardPlayerControls) { model = keyboardPlayerControls; }
    }
}
