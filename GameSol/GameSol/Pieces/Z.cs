namespace GameSol.Pieces
{
    internal class Z : Piece
    {
        public Z(int[,] board) : base(board, PieceType.Z, 'Z')
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

        public override void RotateLeft()
        {
            if (One.X == Two.X)
            {
                if (Board[One.X, One.Y+1] == 0 && Board[One.X-1, One.Y+1] == 0)
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
            else if (One.Y == Two.Y)
            {
                if (Board[One.X, One.Y-1] == 0 && Board[One.X+1, One.Y+1] == 0)
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

        public override void RotateRight()
        {
            RotateLeft();
        }
    }
}
