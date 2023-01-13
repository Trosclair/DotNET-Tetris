using System.Windows.Media;
using WPFUtilities;

namespace WPFTetris.ViewModels.Game.Pieces
{
    public class BlockViewModel : ObservableObject
    {
        private const int tileSize = 40;
        private int x, y, pixelX, pixelY;
        private Color color = Colors.Transparent;
        private Brush brush = Brushes.Transparent;

        public int X { get => x; set { x = value; PixelX = x * tileSize; OnPropertyChanged(nameof(X)); } }
        public int Y { get => y; set { y = value; PixelY = y * tileSize; OnPropertyChanged(nameof(Y)); } }
        public int PixelX { get => pixelX; set { pixelX = value; OnPropertyChanged(nameof(PixelX)); } }
        public int PixelY { get => pixelY; set { pixelY = value; OnPropertyChanged(nameof(PixelY)); } }
        public Brush Brush { get => brush; internal set { brush = value; OnPropertyChanged(nameof(Brush)); } }
        public Color Color { get => color; internal set { color = value; OnPropertyChanged(nameof(Color)); } }
        public bool IsEmpty => color == Colors.White || color == Colors.Transparent;

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
