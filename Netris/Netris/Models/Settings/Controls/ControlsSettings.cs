using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Netris.Models.Settings.Controls
{
    public class ControlsSettings
    {
        public KeyboardPlayerControls PlayerOneKeyboard { get; } = new(Key.S, Key.D, Key.A, Key.W, Key.E, Key.Q, Key.Z, Key.Escape, 1);
        public KeyboardPlayerControls PlayerTwoKeyboard { get; } = new(Key.G, Key.H, Key.F, Key.T, Key.Y, Key.R, Key.V, Key.Escape, 2);
        public KeyboardPlayerControls PlayerThreeKeyboard { get; } = new(Key.K, Key.L, Key.J, Key.I, Key.O, Key.U, Key.M, Key.Escape, 3);
        public KeyboardPlayerControls PlayerFourKeyboard { get; } = new(Key.NumPad5, Key.NumPad6, Key.NumPad4, Key.NumPad8, Key.NumPad9, Key.NumPad7, Key.NumPad1, Key.Escape, 4);

        [JsonConstructor]
        public ControlsSettings() { }
    }
}
