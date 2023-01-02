using System.Collections.ObjectModel;
using System.Windows.Media;

namespace WPFTetris.ViewModels
{
    public class U : PieceViewModel
    {
        public U(BoardViewModel board) : base(board, PieceType.U)
        {
            One = new BlockViewModel(0, 5, Colors.Yellow, Brushes.Yellow);
            Two = new BlockViewModel(0, 4, Colors.Yellow, Brushes.Yellow);
            Three = new BlockViewModel(1, 5, Colors.Yellow, Brushes.Yellow);
            Four = new BlockViewModel(1, 4, Colors.Yellow, Brushes.Yellow);
        }

        public override void RotateClockwise() { }
        public override void RotateCounterClockwise() { }
    }
}
