using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Netris.Models.Settings.Controls;
using Netris.Models.Settings.Gameplay;
using Netris.Models.Settings.Video;

namespace Netris.Models.Settings
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
