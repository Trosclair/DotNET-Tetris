namespace GameSol.Pieces
{
    internal enum PieceType { L, J, I, U, S, Z, T }
    internal abstract class Piece
    {
        public Piece(int[,] board, PieceType pieceType, char pieceLetter)
        {
            Board = board;
            PieceType = pieceType;
            PieceLetter = pieceLetter;
        }

        public abstract void RotateRight();
        public abstract void RotateLeft();

        public virtual void MoveLeft()
        {
            if (One.Y <= 0 || Two.Y <= 0 || Three.Y <= 0 || Four.Y <= 0 || Board[One.X, One.Y - 1] == 1 ||
                Board[Two.X, Two.Y - 1] == 1 || Board[Three.X, Three.Y - 1] == 1 ||
                Board[Four.X, Four.Y - 1] == 1) return;
            One.Y--;
            Two.Y--;
            Three.Y--;
            Four.Y--;
        }

        public virtual void MoveRight()
        {
            if (One.Y >= 9 || Two.Y >= 9 || Three.Y >= 9 || Four.Y >= 9 || Board[One.X, One.Y + 1] == 1 ||
                Board[Two.X, Two.Y + 1] == 1 || Board[Three.X, Three.Y + 1] == 1 ||
                Board[Four.X, Four.Y + 1] == 1) return;
            One.Y++;
            Two.Y++;
            Three.Y++;
            Four.Y++;
        }

        public virtual void ClearPositionFromAMove()
        {
            Board[One.X, One.Y] = 0;
            Board[Two.X, Two.Y] = 0;
            Board[Three.X, Three.Y] = 0;
            Board[Four.X, Four.Y] = 0;
        }

        public virtual void MoveDown()
        {
            if (One.X >= 19 || Two.X >= 19 || Three.X >= 19 || Four.X >= 19 || Board[One.X + 1, One.Y] == 1 ||
                Board[Two.X + 1, Two.Y] == 1 || Board[Three.X + 1, Three.Y] == 1 || Board[Four.X + 1, Four.Y] == 1)
            {
                Board[One.X, One.Y] = 1;
                Board[Two.X, Two.Y] = 1;
                Board[Three.X, Three.Y] = 1;
                Board[Four.X, Four.Y] = 1;
                IsDropping = false;
            }
            else
            {
                One.X++;
                Two.X++;
                Three.X++;
                Four.X++;
            }
        }

        internal Block One { get; set; }
        internal Block Two { get; set; }
        internal Block Three { get; set; }
        internal Block Four { get; set; }
        internal PieceType PieceType { get; set; }
        internal int[,] Board { get; set; }
        internal bool IsDropping { get; private set; } = true;
        internal char PieceLetter { get; }
    }
}

            
