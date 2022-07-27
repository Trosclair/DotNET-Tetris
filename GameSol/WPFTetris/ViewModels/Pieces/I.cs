namespace WPFTetris.ViewModels.Pieces
{
    public class I : Piece
    {
        public I() : base(PieceType.I, 'I')
        {
            One = new BlockViewModel(0, 5);
            Two = new BlockViewModel(1, 5);
            Three = new BlockViewModel(2, 5);
            Four = new BlockViewModel(3, 5);
        }

        public override void RotateLeft(BoardViewModel board)
        {
            if (Three.Y + 1 == Four.Y)
            {
                if (Three.X == 19 || board[One.X - 2, One.Y + 2] == 1 || board[Two.X - 1, Two.Y + 1] == 1 ||
                    board[Four.X + 1, Four.Y - 1] == 1) return;
                Four.X++;
                Four.Y = Three.Y;
                Two.X--;
                Four.Y = Three.Y;
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

        public override void RotateRight(BoardViewModel board)
        {
            RotateLeft(board);
        }
    }
}
