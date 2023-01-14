using Netris.Models.Settings.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUtilities;

namespace Netris.ViewModels.Settings.Video
{
    public class ResolutionViewModel : ObservableObject
    {
        public Resolution Model { get; }
        private string displayName;

        public int Width { get => Model.Width; set { Model.Width = value; OnPropertyChanged(nameof(Width)); } }
        public int Height { get => Model.Height; set { Model.Height = value; OnPropertyChanged(nameof(Height)); } }
        public string DisplayName { get => displayName; set { displayName = value; OnPropertyChanged(nameof(DisplayName)); } }

        public ResolutionViewModel(Resolution resolution)
        {
            Model = resolution;
            displayName = ToString();
        }

        public ResolutionViewModel(int width, int height)
        {
            Model = new(width, height);
            displayName = ToString();
        }

        public override string ToString()
        {
            return Width + " x " + Height;
        }
    }
}
