using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTetris.Models.Settings.Controls;
using WPFTetris.Models.Settings.Gameplay;
using WPFTetris.Models.Settings.Video;

namespace WPFTetris.Models.Settings
{
    public class SettingsModel
    {
        public VideoSettings Video { get; } = new();
        public GameplaySettings Gameplay { get; } = new();
        public ControlsSettings Controls { get; } = new();

        [JsonConstructor]
        public SettingsModel() { }
    }
}
