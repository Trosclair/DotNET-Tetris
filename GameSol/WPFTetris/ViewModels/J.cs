using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFTetris.ViewModels
{
    internal class J : PieceViewModel
    {
        public J(BoardViewModel board) : base(board, PieceType.J)
        {
            One = new BlockViewModel(0, 5, Colors.Blue, Brushes.Blue);
            Two = new BlockViewModel(1, 5, Colors.Blue, Brushes.Blue);
            Three = new BlockViewModel(2, 5, Colors.Blue, Brushes.Blue);
            Four = new BlockViewModel(2, 4, Colors.Blue, Brushes.Blue);
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

            if (Board.MakeMoveIfValid(this, makeMove, revertMove))
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

            if (Board.MakeMoveIfValid(this, makeMove, revertMove))
            {
                UpdateRotationStateCounterClockwise();
            }
        }
    }
}
