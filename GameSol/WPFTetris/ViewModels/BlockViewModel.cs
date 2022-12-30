using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPFTetris.Utilities;

namespace WPFTetris.ViewModels
{
    public class BlockViewModel : ObservableObject
    {
        private const int tileSize = 40;
        private int x, y;
        public int X { get => x; set { x = value * tileSize; OnPropertyChanged(nameof(X)); } }
        public int Y { get => y; set { y = value * tileSize; OnPropertyChanged(nameof(Y)); } }
        public Brush Brush { get; }
        public Color Color { get; }

        public BlockViewModel(int x, int y, Color color, Brush brush)
        {
            X = x;
            Y = y;
            Color = color;
            Brush = brush;
        }
    }

    public static class BlockViewModelExtensions
    {
        public static bool IsOutOfBounds(this BlockViewModel me)
        {
            return me.X > 19 || me.X < 0 || me.Y > 9 || me.Y < 0;
        }

        public static bool CollidesWith(this BlockViewModel me, BlockViewModel otherBlock)
        {
            return me.X == otherBlock.X || me.Y == otherBlock.Y;
        }
    }
}
