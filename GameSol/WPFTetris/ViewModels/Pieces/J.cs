using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFTetris.ViewModels.Pieces
{
    internal class J : PieceViewModel
    {
        public J() : base(PieceType.J)
        {
            One = new BlockViewModel(0, 6, Colors.Blue, Brushes.Blue);
            Two = new BlockViewModel(1, 6, Colors.Blue, Brushes.Blue);
            Three = new BlockViewModel(2, 6, Colors.Blue, Brushes.Blue);
            Four = new BlockViewModel(2, 5, Colors.Blue, Brushes.Blue);
        }

        public override void ResetPiecePosition()
        {
            One.X = 0;
            Two.X = 1;
            Three.X = 2;
            Four.X = 2;

            One.Y = Two.Y = Three.Y = 5;
            Four.Y = 4;

            RotationState = 0;
        }

        public override void RotateClockwise()
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
                    Four.X -= 2;
                    Three.X--;
                    Three.Y--;
                    One.X++;
                    One.Y++;
                };
            }
            else if (RotationState == 1)
            {
                makeMove = () =>
                {
                    Four.Y += 2;
                    Three.X--;
                    Three.Y++;
                    One.X++;
                    One.Y--;
                };
            }
            else if (RotationState == 2)
            {
                makeMove = () =>
                {
                    Four.X += 2;
                    Three.X++;
                    Three.Y++;
                    One.X--;
                    One.Y--;
                };
            }
            else
            {
                makeMove = () =>
                {
                    Four.Y -= 2;
                    Three.X++;
                    Three.Y--;
                    One.X--;
                    One.Y++;
                };
            }

            if (MainViewModel.Board.MakeMoveIfValid(this, makeMove, revertMove))
            {
                UpdateRotationStateClockwise();
            }
        }

        public override void RotateCounterClockwise()
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
                    Four.Y += 2;
                    Three.X--;
                    Three.Y++;
                    One.X++;
                    One.Y--;
                };
            }
            else if (RotationState == 1)
            {
                makeMove = () =>
                {
                    Four.X += 2;
                    Three.X++;
                    Three.Y++;
                    One.X--;
                    One.Y--;
                };
            }
            else if (RotationState == 2)
            {
                makeMove = () =>
                {
                    Four.Y -= 2;
                    Three.X++;
                    Three.Y--;
                    One.X--;
                    One.Y++;
                };
            }
            else
            {
                makeMove = () =>
                {
                    Four.X -= 2;
                    Three.X--;
                    Three.Y--;
                    One.X++;
                    One.Y++;
                };
            }

            if (MainViewModel.Board.MakeMoveIfValid(this, makeMove, revertMove))
            {
                UpdateRotationStateCounterClockwise();
            }
        }
    }
}
