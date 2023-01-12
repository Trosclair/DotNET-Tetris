using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTetris.ViewModels.Game.Pieces
{
    public class Empty : PieceViewModel
    {
        public Empty(BoardViewModel board) : base(PieceType.Empty, board)
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
