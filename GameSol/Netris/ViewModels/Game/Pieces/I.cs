using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Netris.ViewModels.Game.Pieces
{
    internal class I : PieceViewModel
    {
        public I(BoardViewModel board) : base(PieceType.I, board)
        {
            One = new(0, 5, Colors.Aqua, Brushes.Aqua);
            Two = new(1, 5, Colors.Aqua, Brushes.Aqua);
            Three = new(2, 5, Colors.Aqua, Brushes.Aqua);
            Four = new(3, 5, Colors.Aqua, Brushes.Aqua);
        }

        public override void ResetPiecePosition()
        {
            One.X = 0;
            Two.X = 1;
            Three.X = 2;
            Four.X = 3;

            One.Y = Two.Y = Three.Y = Four.Y = 6;

            RotationState = 0;
        }

        public override void RotateClockwise()
        {
            int x1 = One.X, y1 = One.Y, x2 = Two.X, y2 = Two.Y, x4 = Four.X, y4 = Four.Y;

            Action makeMove;
            void revertMove()
            {
                One.X = x1;
                One.Y = y1;
                Two.X = x2;
                Two.Y = y2;
                Four.X = x4;
                Four.Y = y4;
            }

            if ((RotationState % 2) == 0)
            {
                makeMove = () =>
                {
                    One.X = Three.X;
                    One.Y -= 2;
                    Two.X = Three.X;
                    Two.Y--;
                    Four.Y++;
                    Four.X = Three.X;
                };
            }
            else
            {
                makeMove = () =>
                {
                    One.X -= 2;
                    One.Y = Three.Y;
                    Two.X--;
                    Two.Y = Three.Y;
                    Four.X++;
                    Four.Y = Three.Y;
                };
            }

            if (Board.MakeMoveIfValid(this, makeMove, revertMove))
            {
                UpdateRotationStateClockwise();
            }
        }

        public override void RotateCounterClockwise()
        {
            RotateClockwise();
        }
    }
}
