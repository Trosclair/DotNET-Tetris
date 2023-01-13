using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netris.Models.Settings.Video
{
    public class VideoSettings
    {
        public Resolution Resolution { get; set; } = new(480, 600, Resolution.FourToThree);

        [JsonConstructor]
        public VideoSettings() { }
    }
}
