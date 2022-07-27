namespace WPFTetris.ViewModels.Pieces
{
    public class Z : Piece
    {
        public Z() : base(PieceType.Z, 'Z')
        {
            One = new BlockViewModel(0, 5);
            Two = new BlockViewModel(0, 4);
            Three = new BlockViewModel(1, 5);
            Four = new BlockViewModel(1, 6);
        }

        ///*****
        ///*21**
        ///**34*
        ///*****
        ///*****

        public override void RotateLeft(BoardViewModel board)
        {
            if (One.X == Two.X)
            {
                if (One.X > 0)
                {
                    if (board[One.X, One.Y + 1] == 0 && board[One.X - 1, One.Y + 1] == 0)
                    {
                        if (Two.X != 0)
                        {
                            Two.X++;
                            Two.Y++;
                            Three.X--;
                            Three.Y++;
                            Four.X -= 2;
                        }
                    }
                }
            }
            else if (One.Y == Two.Y)
            {
                if (One.Y > 0)
                {
                    if (board[One.X, One.Y - 1] == 0 && board[One.X + 1, One.Y + 1] == 0)
                    {
                        if (Two.Y != 0)
                        {
                            Two.X--;
                            Two.Y--;
                            Three.X++;
                            Three.Y--;
                            Four.X += 2;
                        }
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
