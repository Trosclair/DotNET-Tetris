namespace TetrisLibrary.Pieces
{
    public class U : Piece
    {
        public U() : base(PieceType.U, 'U')
        {
            One = new Block(0, 5);
            Two = new Block(0, 4);
            Three = new Block(1, 5);
            Four = new Block(1, 4);
        }

        public override void RotateLeft(int[,] board) { }

        public override void RotateRight(int[,] board) { }
    }
}
