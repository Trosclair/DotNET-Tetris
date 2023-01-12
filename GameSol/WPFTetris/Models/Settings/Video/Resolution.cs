using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTetris.Models.Settings.Video
{
    public class Resolution
    {
        public const string SixteenToNine = "16:9";
        public const string FourToThree = "4:3";

        public int Width { get; }
        public int Height { get; }
        public string AspectRatio { get; }

        public Resolution(int width, int height, string aspectRatio) 
        { 
            Width = width;
            Height = height;
            AspectRatio = aspectRatio;
        }

        public override string ToString()
        {
            return Width + "x" + Height + " (" + AspectRatio + ")";
        }
    }
}
