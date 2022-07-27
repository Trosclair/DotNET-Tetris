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
        private int x = 0, y = 0;
        private Color color = Colors.DarkGray;
        private Brush brush = Brushes.DarkGray;

        public int X { get => x; set { x = value; OnPropertyChanged(nameof(X)); } }
        public int Y { get => y; set { y = value; OnPropertyChanged(nameof(Y)); } }
        public Color Color { get => color; set { color = value; OnPropertyChanged(nameof(Color)); } }
        public Brush Brush { get => brush; set { brush = value; OnPropertyChanged(nameof(Brush)); } }

        public BlockViewModel(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
