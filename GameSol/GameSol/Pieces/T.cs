namespace GameSol.Pieces
{
    internal class T : Piece
    {
        public T(int[,] board)
        {
            One = new Block(0, 5);
            Two = new Block(1, 5);
            Three = new Block(1, 6);
            Four = new Block(1, 4);
            StrPieceType = "T";
            Board = board;
        }

        public override void RotateLeft()
        {
            if (One.X == Two.X - 1 && Three.Y - 1 == Two.Y && Four.Y + 1 == Two.Y && Two.X != 19 && Board[Two.X+1, Two.Y] == 0)
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
            else if (One.Y + 1 == Two.Y && Three.Y == Two.Y && Four.Y == Two.Y && Two.Y != 9 && Board[Two.X, Two.Y+1] == 0)
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
            else if (One.X - 1 == Two.X && Three.X == Two.X && Four.X == Two.X && Two.X != 0 && Board[Two.X-1, Two.Y] == 0)
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
            else if (One.Y - 1 == Two.Y && Three.Y == Two.Y && Four.Y == Two.Y && Two.Y != 0 && Board[Two.X, Two.Y-1] == 0)
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

        public override void RotateRight()
        {
            if (One.X == Two.X - 1 && Three.Y - 1 == Two.Y && Four.Y + 1 == Two.Y && Two.X != 19 && Board[Two.X+1, Two.Y] == 0)
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
            else if (One.Y + 1 == Two.Y && Three.Y == Two.Y && Four.Y == Two.Y && Two.Y != 9 && Board[Two.X, Two.Y+1] == 0)
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
            else if (One.X - 1 == Two.X && Three.X == Two.X && Four.X == Two.X && Two.X != 0 && Board[Two.X-1, Two.Y] == 0)
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
            else if (One.Y - 1 == Two.Y && Three.Y == Two.Y && Four.Y == Two.Y && Two.Y != 0 && Board[Two.X, Two.Y-1] == 0)
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
