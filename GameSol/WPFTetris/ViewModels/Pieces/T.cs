namespace WPFTetris.ViewModels.Pieces
{
    public class T : Piece
    {
        public T() : base( PieceType.T, 'T')
        {
            One = new BlockViewModel(0, 5);
            Two = new BlockViewModel(1, 5);
            Three = new BlockViewModel(1, 6);
            Four = new BlockViewModel(1, 4);
        }

        public override void RotateLeft(BoardViewModel board)
        {
            if (One.X == Two.X - 1 && Three.Y - 1 == Two.Y && Four.Y + 1 == Two.Y && Two.X != 19 && board[Two.X + 1, Two.Y] == 0)
            {
                // 00100
                // 04230
                // 00000
                Four.X++;
                Four.Y++;
                One.X++;
                One.Y--;
                Three.X--;
                Three.Y--;
            }
            else if (One.Y + 1 == Two.Y && Three.Y == Two.Y && Four.Y == Two.Y && Two.Y != 9 && board[Two.X, Two.Y + 1] == 0)
            {
                // 00300
                // 01200
                // 00400
                One.X++;
                One.Y++;
                Three.X++;
                Three.Y--;
                Four.X--;
                Four.Y++;
            }
            else if (One.X - 1 == Two.X && Three.X == Two.X && Four.X == Two.X && Two.X != 0 && board[Two.X - 1, Two.Y] == 0)
            {
                // 00000
                // 03240
                // 00100
                One.X--;
                One.Y++;
                Three.X++;
                Three.Y++;
                Four.X--;
                Four.Y--;
            }
            else if (One.Y - 1 == Two.Y && Three.Y == Two.Y && Four.Y == Two.Y && Two.Y != 0 && board[Two.X, Two.Y - 1] == 0)
            {
                // 00400
                // 00210
                // 00300
                One.X--;
                One.Y--;
                Three.X--;
                Three.Y++;
                Four.X++;
                Four.Y--;
            }
        }

        public override void RotateRight(BoardViewModel board)
        {
            if (One.X == Two.X - 1 && Three.Y - 1 == Two.Y && Four.Y + 1 == Two.Y && Two.X != 19 && board[Two.X + 1, Two.Y] == 0)
            {
                // 00100
                // 04230
                // 00000
                Four.X--;
                Four.Y++;
                One.X++;
                One.Y++;
                Three.X++;
                Three.Y--;
            }
            else if (One.Y + 1 == Two.Y && Three.Y == Two.Y && Four.Y == Two.Y && Two.Y != 9 && board[Two.X, Two.Y + 1] == 0)
            {
                // 00300
                // 01200
                // 00400
                One.X--;
                One.Y++;
                Three.X++;
                Three.Y++;
                Four.X--;
                Four.Y--;
            }
            else if (One.X - 1 == Two.X && Three.X == Two.X && Four.X == Two.X && Two.X != 0 && board[Two.X - 1, Two.Y] == 0)
            {
                // 00000
                // 03240
                // 00100
                One.X--;
                One.Y--;
                Three.X--;
                Three.Y++;
                Four.X++;
                Four.Y--;
            }
            else if (One.Y - 1 == Two.Y && Three.Y == Two.Y && Four.Y == Two.Y && Two.Y != 0 && board[Two.X, Two.Y - 1] == 0)
            {
                // 00400
                // 00210
                // 00300
                One.X++;
                One.Y--;
                Three.X--;
                Three.Y--;
                Four.X++;
                Four.Y++;
            }
        }
    }
}
