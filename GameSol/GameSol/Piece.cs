using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSol
{
    public class Piece
    {
        public enum PieceType { L, J, I, U, S, Z, T };
        private Block _one;
        private Block _two;
        private Block _three;
        private Block _four;
        private PieceType _thisPiece;
        private string _pieceType;


        public Piece(int i)
        {
            _thisPiece = (PieceType)i;

            switch (i)
            {
                case 0:
                    _one = new Block(0, 5);
                    _two = new Block(1, 5);
                    _three = new Block(2, 5);
                    _four = new Block(2, 6);
                    _pieceType = "L";
                    break;
                case 1:
                    _one = new Block(0, 5);
                    _two = new Block(1, 5);
                    _three = new Block(2, 5);
                    _four = new Block(2, 4);
                    _pieceType = "J";
                    break;
                case 2:
                    _one = new Block(0, 5);
                    _two = new Block(1, 5);
                    _three = new Block(2, 5);
                    _four = new Block(3, 5);
                    _pieceType = "I";
                    break;
                case 3:
                    _one = new Block(0, 5);
                    _two = new Block(0, 4);
                    _three = new Block(1, 5);
                    _four = new Block(1, 4);
                    _pieceType = "U";
                    break;
                case 4:
                    _one = new Block(0, 5);
                    _two = new Block(0, 6);
                    _three = new Block(1, 5);
                    _four = new Block(1, 4);
                    _pieceType = "S";
                    break;
                case 5:
                    _one = new Block(0, 5);
                    _two = new Block(0, 4);
                    _three = new Block(1, 5);
                    _four = new Block(1, 6);
                    _pieceType = "Z";
                    break;
                case 6:
                    _one = new Block(0, 5);
                    _two = new Block(1, 5);
                    _three = new Block(1, 6);
                    _four = new Block(1, 4);
                    _pieceType = "T";
                    break;
                default:
                    throw new ArgumentException();
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
            get { return _pieceType; }
        }
    }

}

            
