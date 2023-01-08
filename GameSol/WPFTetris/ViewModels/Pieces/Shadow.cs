using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTetris.ViewModels.Pieces
{
    internal class Shadow : PieceViewModel
    {
        public Shadow() : base(PieceType.Shadow)
        {
        }

        public override void ResetPiecePosition() { }
        public override void RotateClockwise() { }
        public override void RotateCounterClockwise() { }
    }
}
