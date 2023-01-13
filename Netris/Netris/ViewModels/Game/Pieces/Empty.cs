using System;

namespace Netris.ViewModels.Game.Pieces
{
    public class Empty : PieceViewModel
    {
        public Empty(PlayerViewModel board) : base(PieceType.Empty, board)
        {
            // I bet y'all are wondering why I gathered you all here today...
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
