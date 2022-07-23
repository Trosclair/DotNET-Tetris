namespace TetrisLibrary.Pieces
{
    public class Z : Piece
    {
        public Z() : base(PieceType.Z, 'Z')
        {
            One = new Block(0, 5);
            Two = new Block(0, 4);
            Three = new Block(1, 5);
            Four = new Block(1, 6);
        }

        ///*****
        ///*21**
        ///**34*
        ///*****
        ///*****

        public override void RotateLeft(int[,] board)
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

        public override void RotateRight(int[,] board)
        {
            RotateLeft(board);
        }
    }
}
