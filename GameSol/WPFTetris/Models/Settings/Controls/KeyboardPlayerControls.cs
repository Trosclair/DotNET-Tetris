using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTetris.Models.Settings.Controls
{
    public class KeyboardPlayerControls
    {
        public Key MoveDown { get; set; } = Key.S;
        public Key MoveRight { get; set; } = Key.D;
        public Key MoveLeft { get; set; } = Key.A;
        public Key HardDrop { get; set; } = Key.W;
        public Key RotateClockwise { get; set; } = Key.K;
        public Key RotateCounterClockwise { get; set; } = Key.J;
        public Key Hold { get; set; } = Key.E;
        public Key Pause { get; set; } = Key.Enter;

        public KeyboardPlayerControls() { }
    }
}
