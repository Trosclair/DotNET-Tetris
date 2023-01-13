using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Netris.ViewModels.Game.Pieces
{
    public class U : PieceViewModel
    {
        public U(PlayerViewModel board) : base(PieceType.U, board)
        {
            One = new BlockViewModel(0, 5, Colors.Yellow, Brushes.Yellow);
            Two = new BlockViewModel(0, 4, Colors.Yellow, Brushes.Yellow);
            Three = new BlockViewModel(1, 5, Colors.Yellow, Brushes.Yellow);
            Four = new BlockViewModel(1, 4, Colors.Yellow, Brushes.Yellow);
        }

        public override void ResetPiecePosition()
        {
            One.X = Two.X = 0;
            Three.X = Four.X = 1;

            One.Y = Three.Y = 5;
            Two.Y = Four.Y = 4;

            RotationState = 0;
        }

        public override void RotateClockwise() { }
        public override void RotateCounterClockwise() { }
    }
}
