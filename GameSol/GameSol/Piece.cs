using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSol
{
    public class Piece
    {
        private int[,] _board = new int[10, 20];
        enum PieceType { L, J, I, U, S, Z, T };
        PieceType thisPiece;
        public Piece(int i)
        {
            switch (i)
            {
                case 1:
                    thisPiece = PieceType.L;
                    _board[0, 5] = 1;
                    _board[1, 5] = 1;
                    _board[2, 5] = 1;
                    _board[2, 6] = 1;
                    break;
                case 2:
                    thisPiece = PieceType.J;
                    _board[0, 5] = 1;
                    _board[1, 5] = 1;
                    _board[2, 5] = 1;
                    _board[2, 4] = 1;
                    break;
                case 3:
                    thisPiece = PieceType.S;
                    _board[0, 5] = 1;
                    _board[0, 6] = 1;
                    _board[1, 5] = 1;
                    _board[1, 4] = 1;
                    break;
                case 4:
                    thisPiece = PieceType.T;
                    _board[0, 5] = 1;
                    _board[1, 5] = 1;
                    _board[1, 6] = 1;
                    _board[1, 4] = 1;
                    break;
                case 5:
                    thisPiece = PieceType.Z;
                    _board[0, 5] = 1;
                    _board[0, 4] = 1;
                    _board[1, 5] = 1;
                    _board[1, 6] = 1;
                    break;
                case 6:
                    thisPiece = PieceType.U;
                    _board[0, 5] = 1;
                    _board[0, 4] = 1;
                    _board[1, 5] = 1;
                    _board[1, 4] = 1;
                    break;
                case 7:
                    thisPiece = PieceType.I;
                    _board[0, 5] = 1;
                    _board[1, 5] = 1;
                    _board[2, 5] = 1;
                    _board[3, 5] = 1;
                    break;
                default:
                    throw new ArgumentException();
            }

        }
    }

}
