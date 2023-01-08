using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using WPFTetris.Utilities;
using WPFTetris.ViewModels.Pieces;

namespace WPFTetris.ViewModels
{
    public class RightSideBarViewModel : ObservableObject
    {
        private static readonly Random random = new();
        private bool hasHeld = false;
        public PiecePresenterViewModel Next { get; set; } = new(CreatePiece());
        public PiecePresenterViewModel Hold { get; set; } = new(new Empty());
        public PiecePresenterViewModel One { get; set; } = new(CreatePiece());
        public PiecePresenterViewModel Two { get; set; } = new(CreatePiece());
        public PiecePresenterViewModel Three { get; set; } = new(CreatePiece());
        public PiecePresenterViewModel Four { get; set; } = new(CreatePiece());

        public PieceViewModel Pop()
        {
            PieceViewModel result = Next.Piece;
            Next.Piece = One.Piece;
            One.Piece = Two.Piece;
            Two.Piece = Three.Piece;
            Three.Piece = Four.Piece;
            Four.Piece = CreatePiece();
            hasHeld = false;
            return result;
        }

        public PieceViewModel SwapHoldPiece(PieceViewModel currentPiece)
        {
            if (!hasHeld)
            {
                PieceViewModel result;

                currentPiece.ResetPiecePosition();

                if (Hold.Piece is Empty)
                {
                    Hold.Piece = currentPiece;
                    result = Pop();
                }
                else
                {
                    result = Hold.Piece;
                    Hold.Piece = currentPiece;
                }
                hasHeld = true;

                return result;
            }
            else
            {
                return currentPiece;
            }
        }

        private static PieceViewModel CreatePiece()
        {
            return (PieceType)random.Next(0, 7) switch
            {
                PieceType.I => new I(),
                PieceType.T => new T(),
                PieceType.S => new S(),
                PieceType.Z => new Z(),
                PieceType.L => new L(),
                PieceType.J => new J(),
                PieceType.U => new U(),
                _ => new Empty(),
            };
        }
    }
}
