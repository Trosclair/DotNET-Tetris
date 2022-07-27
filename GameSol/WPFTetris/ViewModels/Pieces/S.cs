namespace WPFTetris.ViewModels.Pieces
{
    public class S : Piece
    {
        public S() : base(PieceType.S, 'S')
        {
            One = new BlockViewModel(0, 5);
            Two = new BlockViewModel(0, 6);
            Three = new BlockViewModel(1, 5);
            Four = new BlockViewModel(1, 4);
        }

        ///*****
        ///**12*
        ///*43**
        ///*****

        public override void RotateLeft(BoardViewModel board)
        {
            if (One.X == Two.X)
            {
                if (One.X > 0)
                {
                    if (board[One.X - 1, One.Y] == 0 && board[Three.X, Two.Y] == 0)
                    {
                        if (Two.X != 0)
                        {
                            Two.X--;
                            Two.Y--;
                            Three.X--;
                            Three.Y++;
                            Four.Y += 2;
                        }
                    }
                }
            }
            else if (One.Y > 0)
            {
                if (board[One.X + 1, One.Y] == 0 && board[One.X + 1, One.Y - 1] == 0)
                {
                    if (Four.Y != 1)
                    {
                        Two.X++;
                        Two.Y++;
                        Three.X++;
                        Three.Y--;
                        Four.Y -= 2;
                    }
                }
            }
        }

        public override void RotateRight(BoardViewModel board)
        {
            RotateLeft(board);
        }
    }
}
