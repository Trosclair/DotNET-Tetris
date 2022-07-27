namespace WPFTetris.ViewModels.Pieces
{
    public class U : Piece
    {
        public U() : base(PieceType.U, 'U')
        {
            One = new BlockViewModel(0, 5);
            Two = new BlockViewModel(0, 4);
            Three = new BlockViewModel(1, 5);
            Four = new BlockViewModel(1, 4);
        }

        public override void RotateLeft(BoardViewModel board) { }

        public override void RotateRight(BoardViewModel board) { }
    }
}
