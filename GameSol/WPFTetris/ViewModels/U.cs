using System.Collections.ObjectModel;

namespace WPFTetris.ViewModels
{
    public class U : PieceViewModel
    {
        public U() : base(PieceType.U) { }
        public override void RotateClockwise() { }
        public override void RotateCounterClockwise() { }
    }
}
