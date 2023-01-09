using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFTetris.ViewModels.Pieces
{
    public class Shadow : PieceViewModel
    {
        public Shadow() : base(PieceType.Shadow)
        {
            One = new(0, 0, Colors.White, Brushes.White);
            Two = new(0, 0, Colors.White, Brushes.White);
            Three = new(0, 0, Colors.White, Brushes.White);
            Four = new(0, 0, Colors.White, Brushes.White);
        }

        public override void ResetPiecePosition() { }
        public override void RotateClockwise() { }
        public override void RotateCounterClockwise() { }
    }
}
