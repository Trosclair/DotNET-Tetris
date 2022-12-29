using System.Collections.ObjectModel;

namespace WPFTetris.ViewModels
{
    public class U : PieceViewModel
    {
        public U(ObservableCollection<BlockViewModel> blocks, int rotationState) : base(blocks, PieceType.U, rotationState) { }
        public override ObservableCollection<BlockViewModel> RotateClockwise() => Blocks;
        public override ObservableCollection<BlockViewModel> RotateCounterClockwise() => Blocks;
    }
}
