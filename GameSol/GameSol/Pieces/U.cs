namespace GameSol.Pieces
{
    internal class U : Piece
    {
        public U(int[,] board)
        {
            One = new Block(0, 5);
            Two = new Block(0, 4);
            Three = new Block(1, 5);
            Four = new Block(1, 4);
            PieceType = PieceType.U;
            Board = board;
        }

        public override void RotateLeft(){}

        public override void RotateRight(){}
    }
}
