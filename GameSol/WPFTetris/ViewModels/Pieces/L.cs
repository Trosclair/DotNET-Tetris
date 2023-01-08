using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFTetris.ViewModels.Pieces
{
    internal class L : PieceViewModel
    {
        public L() : base(PieceType.L)
        {
            One = new BlockViewModel(0, 5, Colors.Orange, Brushes.Orange);
            Two = new BlockViewModel(1, 5, Colors.Orange, Brushes.Orange);
            Three = new BlockViewModel(2, 5, Colors.Orange, Brushes.Orange);
            Four = new BlockViewModel(2, 6, Colors.Orange, Brushes.Orange);
        }

        public override void ResetPiecePosition()
        {
            One.X = 0;
            Two.X = 1;
            Three.X = 2;
            Four.X = 2;

            One.Y = Two.Y = Three.Y = 4;
            Four.Y = 5;

            RotationState = 0;
        }

        public override void RotateClockwise()
        {
            int x1 = One.X, y1 = One.Y, x3 = Three.X, y3 = Three.Y, y4 = Four.Y;

            Action makeMove;
            void revertMove()
            {
                One.X = x1;
                One.Y = y1;
                Three.X = x3;
                Three.X = y3;
                Four.Y = y4;
            }

            if (RotationState == 0)
            {
                makeMove = () =>
                {
                    One.X++;
                    One.Y++;
                    Three.X--;
                    Three.Y--;
                    Four.Y -= 2;
                };
            }
            else if (RotationState == 1)
            {
                makeMove = () =>
                {
                    One.X++;
                    One.Y--;
                    Three.X--;
                    Three.Y++;
                    Four.X -= 2;
                };
            }
            else if (RotationState == 2)
            {
                makeMove = () =>
                {
                    One.X--;
                    One.Y--;
                    Three.X++;
                    Three.Y++;
                    Four.Y += 2;
                };
            }
            else
            {
                makeMove = () =>
                {
                    One.X--;
                    One.Y++;
                    Three.X++;
                    Three.Y--;
                    Four.X += 2;
                };
            }

            if (MainViewModel.Board.MakeMoveIfValid(this, makeMove, revertMove))
            {
                UpdateRotationStateClockwise();
            }
        }

        public override void RotateCounterClockwise()
        {
            int x1 = One.X, y1 = One.Y, x3 = Three.X, y3 = Three.Y, x4 = Four.X;

            Action makeMove;
            void revertMove()
            {
                One.X = x1;
                One.Y = y1;
                Three.X = x3;
                Three.X = y3;
                Four.X = x4;
            }

            if (RotationState == 0)
            {
                makeMove = () =>
                {
                    One.X++;
                    One.Y--;
                    Three.X--;
                    Three.Y++;
                    Four.X -= 2;
                };
            }
            else if (RotationState == 1)
            {
                makeMove = () =>
                {
                    One.X--;
                    One.Y--;
                    Three.X++;
                    Three.Y++;
                    Four.Y += 2;
                };
            }
            else if (RotationState == 2)
            {
                makeMove = () =>
                {
                    One.X--;
                    One.Y++;
                    Three.X++;
                    Three.Y--;
                    Four.X += 2;
                };
            }
            else
            {
                makeMove = () =>
                {
                    One.X++;
                    One.Y++;
                    Three.X--;
                    Three.Y--;
                    Four.Y -= 2;
                };
            }

            if (MainViewModel.Board.MakeMoveIfValid(this, makeMove, revertMove))
            {
                UpdateRotationStateCounterClockwise();
            }
        }
    }
}
