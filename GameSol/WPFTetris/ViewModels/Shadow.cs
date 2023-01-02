using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTetris.ViewModels
{
    internal class Shadow : PieceViewModel
    {
        public Shadow(BoardViewModel board) : base(board, PieceType.Shadow)
        {
        }

        public override void RotateClockwise() { }
        public override void RotateCounterClockwise() { }
    }
}
