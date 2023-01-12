using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTetris.Models.Settings.Controls
{
    public class ControlsSettings
    {
        public KeyboardPlayerControls PlayerOneKeyboard { get; } = new();
        public KeyboardPlayerControls PlayerTwoKeyboard { get; } = new();
        public KeyboardPlayerControls PlayerThreeKeyboard { get; } = new();
        public KeyboardPlayerControls PlayerFourKeyboard { get; } = new();

        [JsonConstructor]
        public ControlsSettings() { }
    }
}
