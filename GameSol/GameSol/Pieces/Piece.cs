using System;

namespace ConsoleTetris.Pieces
{
    internal enum PieceType { L, J, I, U, S, Z, T }
    internal abstract class Piece
    {
        private static readonly Random random = new Random();

        internal Block One { get; set; }
        internal Block Two { get; set; }
        internal Block Three { get; set; }
        internal Block Four { get; set; }
        internal PieceType PieceType { get; set; }
        internal bool IsDropping { get; private set; } = true;
        internal char PieceLetter { get; }

        public Piece(PieceType pieceType, char pieceLetter)
        {
            PieceType = pieceType;
            PieceLetter = pieceLetter;
        }

        public abstract void RotateRight(int[,] board);
        public abstract void RotateLeft(int[,] board);

        public virtual void MoveLeft(int[,] board)
        {
            if (One.Y <= 0 || Two.Y <= 0 || Three.Y <= 0 || Four.Y <= 0 || board[One.X, One.Y - 1] == 1 ||
                board[Two.X, Two.Y - 1] == 1 || board[Three.X, Three.Y - 1] == 1 ||
                board[Four.X, Four.Y - 1] == 1) return;
            One.Y--;
            Two.Y--;
            Three.Y--;
            Four.Y--;
        }

        public virtual void MoveRight(int[,] board)
        {
            if (One.Y >= 9 || Two.Y >= 9 || Three.Y >= 9 || Four.Y >= 9 || board[One.X, One.Y + 1] == 1 ||
                board[Two.X, Two.Y + 1] == 1 || board[Three.X, Three.Y + 1] == 1 ||
                board[Four.X, Four.Y + 1] == 1) return;
            One.Y++;
            Two.Y++;
            Three.Y++;
            Four.Y++;
        }

        public virtual void ClearPositionFromAMove(int[,] board)
        {
            board[One.X, One.Y] = 0;
            board[Two.X, Two.Y] = 0;
            board[Three.X, Three.Y] = 0;
            board[Four.X, Four.Y] = 0;
        }

        public virtual void MoveDown(int[,] board)
        {
            if (One.X >= 19 || Two.X >= 19 || Three.X >= 19 || Four.X >= 19 || board[One.X + 1, One.Y] == 1 ||
                board[Two.X + 1, Two.Y] == 1 || board[Three.X + 1, Three.Y] == 1 || board[Four.X + 1, Four.Y] == 1)
            {
                board[One.X, One.Y] = 1;
                board[Two.X, Two.Y] = 1;
                board[Three.X, Three.Y] = 1;
                board[Four.X, Four.Y] = 1;
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

        public static Piece NewPiece()
        {
            switch (random.Next(0, 7))
            {
                case 0:
                    ScoreAndStatistics.Instance.L++;
                    return new L();
                case 1:
                    ScoreAndStatistics.Instance.J++;
                    return new J();
                case 2:
                    ScoreAndStatistics.Instance.I++;
                    return new I();
                case 3:
                    ScoreAndStatistics.Instance.U++;
                    return new U();
                case 4:
                    ScoreAndStatistics.Instance.S++;
                    return new S();
                case 5:
                    ScoreAndStatistics.Instance.Z++;
                    return new Z();
                case 6:
                    ScoreAndStatistics.Instance.T++;
                    return new T();
                default:
                    throw new ArgumentException();
            }
        }
    }
}


