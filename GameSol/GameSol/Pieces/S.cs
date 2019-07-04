namespace GameSol.Pieces
{
    internal class S : Piece
    {
        public S(int[,] board)
        {
            One = new Block(0, 5);
            Two = new Block(0, 6);
            Three = new Block(1, 5);
            Four = new Block(1, 4);
            StrPieceType = "S";
            Board = board;
        }

        ///*****
        ///**12*
        ///*43**
        ///*****

        public override void RotateLeft()
        {
            if (One.X == Two.X)
            {
                if (Board[One.X-1, One.Y] == 0 && Board[Three.X,Two.Y] == 0)
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
            else
            {
                if (Board[One.X+1,One.Y] == 0 && Board[One.X+1, One.Y-1] == 0)
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

        public override void RotateRight()
        {
            RotateLeft();
        }
    }
}
