using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Netris.Models.Settings.Video
{
    public class VideoSettings
    {
        public Resolution Resolution { get; set; } = new(1920, 1080);
        public WindowState WindowState { get; set; } = WindowState.Maximized;
        public WindowStyle WindowStyle { get; set; } = WindowStyle.None;
        public ResizeMode ResizeMode { get; set; } = ResizeMode.NoResize;
        public SizeToContent SizeToContent { get; set; } = SizeToContent.WidthAndHeight;
        public bool KeepWindowOnTop { get; set; } = false;
        public bool UseWindowedMode { get; set; } = false;

        [JsonConstructor]
        public VideoSettings() { }
    }
}
