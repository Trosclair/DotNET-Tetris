using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WPFUtilities.Extensions;

namespace Netris.ViewModels.Settings.Video
{
    public class ResolutionCollection : ObservableCollection<ResolutionViewModel>
    {
        public ResolutionCollection(int width, int height)
        {
            this.AddRange(new List<ResolutionViewModel>()
            {
                new(640, 480),
                new(720, 400),
                new(720, 480),
                new(800, 600),
                new(832, 624),
                new(1024, 768),
                new(1128, 634),
                new(1152, 872),
                new(1280, 720),
                new(1280, 960),
                new(1280, 1024),
                new(1366, 768),
                new(1400, 1050),
                new(1440, 900),
                new(1600, 900),
                new(1600, 1200),
                new(1680, 1050),
                new(1760, 990),
                new(1920, 1080),
            }.Where(x => x.Height <= height && x.Width <= width));
        }
    }
}
