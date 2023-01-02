namespace TetrisLibrary.Pieces
{
    public class I : Piece
    {
        public I() : base(PieceType.I, 'I')
        {
            One = new Block(0, 5);
            Two = new Block(1, 5);
            Three = new Block(2, 5);
            Four = new Block(3, 5);
        }

        public override void RotateLeft(int[,] board)
        {
            if (Three.Y + 1 == Four.Y)
            {
                if (Three.X == 19 || board[One.X - 2, One.Y + 2] == 1 || board[Two.X - 1, Two.Y + 1] == 1 ||
                    board[Four.X + 1, Four.Y - 1] == 1) return;
                Four.X++;
                Four.Y = Three.Y;
                Two.X--;
                One.X -= 2;
                One.Y = Three.Y;
                Two.Y = Three.Y;
            }
            else if (Three.X + 1 == Four.X && Four.Y != 0 && Four.Y != 1 && Four.Y != 9)
            {
                if (board[One.X + 2, One.Y - 2] == 1 || board[Two.X + 1, Two.Y - 1] == 1 ||
                    board[Four.X - 1, Four.Y + 1] == 1) return;
                Four.X = Three.X;
                Two.X = Three.X;
                One.X = Three.X;
                Four.Y++;
                Two.Y--;
                One.Y -= 2;
            }
        }

        public override void RotateRight(int[,] board)
        {
            RotateLeft(board);
        }
    }
}
