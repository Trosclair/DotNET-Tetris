using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTetris.ViewModels.Pieces
{
    public class Empty : PieceViewModel
    {
        public Empty() : base(PieceType.Empty)
        {
        }

        public override void ResetPiecePosition()
        {
            throw new NotImplementedException();
        }

        public override void RotateClockwise()
        {
            throw new NotImplementedException();
        }

        public override void RotateCounterClockwise()
        {
            throw new NotImplementedException();
        }
    }
}
