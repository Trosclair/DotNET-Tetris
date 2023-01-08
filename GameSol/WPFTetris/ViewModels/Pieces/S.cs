using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFTetris.ViewModels.Pieces
{
    internal class S : PieceViewModel
    {
        public S() : base(PieceType.S)
        {
            One = new BlockViewModel(1, 5, Colors.DarkGreen, Brushes.DarkGreen);
            Two = new BlockViewModel(1, 6, Colors.DarkGreen, Brushes.DarkGreen);
            Three = new BlockViewModel(2, 5, Colors.DarkGreen, Brushes.DarkGreen);
            Four = new BlockViewModel(2, 4, Colors.DarkGreen, Brushes.DarkGreen);
        }

        public override void ResetPiecePosition()
        {
            One.X = Two.X = 1;
            Three.X = Four.X = 2;

            One.Y = Three.Y = 5;
            Two.Y = 6;
            Four.Y = 4;

            RotationState = 0;
        }

        public override void RotateClockwise()
        {
            int x2 = Two.X, y2 = Two.Y, x3 = Three.X, y3 = Three.Y, y4 = Four.Y;

            Action makeMove;
            void revertMove()
            {
                Two.X = x2;
                Two.Y = y2;
                Three.X = x3;
                Three.Y = y3;
                Four.Y = y4;
            }

            if ((RotationState % 2) == 0)
            {
                makeMove = () =>
                {
                    Two.X--;
                    Two.Y--;
                    Three.X--;
                    Three.Y++;
                    Four.Y += 2;
                };
            }
            else
            {
                makeMove = () =>
                {
                    Two.X++;
                    Two.Y++;
                    Three.X++;
                    Three.Y--;
                    Four.Y -= 2;
                };
            }

            if (MainViewModel.Board.MakeMoveIfValid(this, makeMove, revertMove))
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
