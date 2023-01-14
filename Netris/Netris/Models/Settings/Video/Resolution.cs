using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netris.Models.Settings.Video
{
    public class Resolution
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Resolution(int width, int height) 
        { 
            Width = width;
            Height = height;
        }
    }
}
