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
        public int BoardPosition { get; }
        public int X { get; }
        public int Y { get; }
        public Brush Brush { get; }

        public BlockViewModel(int boardPosition, Brush brush)
        {
            X = boardPosition / 10;
            Y = boardPosition % 10;
            Brush = brush;
        }
    }
}
