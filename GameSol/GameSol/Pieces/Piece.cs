using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSol
{
    abstract class Piece
    {
        public enum PieceType { L, J, I, U, S, Z, T };
        private Block _one;
        private Block _two;
        private Block _three;
        private Block _four;
        private PieceType _thisPiece;
        private string _pieceType;
        private int[,] board;
        private bool _isDropping = true;

        public abstract void RotateRight();
        public abstract void RotateLeft();

        public virtual void MoveLeft()
        {
            if
                (
                One.Y > 0 && Two.Y > 0 && Three.Y > 0 && Four.Y > 0 &&
                board[One.X, One.Y - 1] != 1 &&
                board[Two.X, Two.Y - 1] != 1 &&
                board[Three.X, Three.Y - 1] != 1 &&
                board[Four.X, Four.Y - 1] != 1
                )
            {
                One.Y--;
                Two.Y--;
                Three.Y--;
                Four.Y--;
            }
        }

        public virtual void MoveRight()
        {
            if
                (
                One.Y < 9 && Two.Y < 9 && Three.Y < 9 && Four.Y < 9 &&
                board[One.X, One.Y + 1] != 1 &&
                board[Two.X, Two.Y + 1] != 1 &&
                board[Three.X, Three.Y + 1] != 1 &&
                board[Four.X, Four.Y + 1] != 1
                )
            {
                One.Y++;
                Two.Y++;
                Three.Y++;
                Four.Y++;
            }
        }

        public virtual void ClearPositionFromAMove()
        {
            board[One.X, One.Y] = 0;
            board[Two.X, Two.Y] = 0;
            board[Three.X, Three.Y] = 0;
            board[Four.X, Four.Y] = 0;
        }

        public virtual void MoveDown()
        {
            if (
                    One.X < 19 && Two.X < 19 && Three.X < 19 && Four.X < 19 &&
                    board[One.X + 1, One.Y] != 1 &&
                    board[Two.X + 1, Two.Y] != 1 &&
                    board[Three.X + 1, Three.Y] != 1 &&
                    board[Four.X + 1, Four.Y] != 1
                    )
            {
                One.X++;
                Two.X++;
                Three.X++;
                Four.X++;

            }
            else
            {
                board[One.X, One.Y] = 1;
                board[Two.X, Two.Y] = 1;
                board[Three.X, Three.Y] = 1;
                board[Four.X, Four.Y] = 1;
                _isDropping = false;
            }
        }

        internal PieceType CurrPiece
        {
            get
            {
                return _thisPiece;
            }

            set
            {
                _thisPiece = value;
            }
        }

        internal Block One
        {
            get
            {
                return _one;
            }

            set
            {
                _one = value;
            }
        }

        internal Block Two
        {
            get
            {
                return _two;
            }

            set
            {
                _two = value;
            }
        }

        internal Block Three
        {
            get
            {
                return _three;
            }

            set
            {
                _three = value;
            }
        }

        internal Block Four
        {
            get
            {
                return _four;
            }

            set
            {
                _four = value;
            }
        }

        internal string Piece_Type
        {
            get
            {
                return _pieceType;
            }
            set
            {
                _pieceType = value;
            }
        }

        internal int[,] Board
        {
            get
            {
                return board;
            }
            set
            {
                board = value;
            }
        }

        internal bool IsDropping
        {
            get { return _isDropping; }
        }
    }

}

            
