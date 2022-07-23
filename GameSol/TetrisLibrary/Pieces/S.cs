namespace TetrisLibrary.Pieces
{
    public class S : Piece
    {
        public S() : base(PieceType.S, 'S')
        {
            One = new Block(0, 5);
            Two = new Block(0, 6);
            Three = new Block(1, 5);
            Four = new Block(1, 4);
        }

        ///*****
        ///**12*
        ///*43**
        ///*****

        public override void RotateLeft(int[,] board)
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

        public override void RotateRight(int[,] board)
        {
            RotateLeft(board);
        }
    }
}
