using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFTetris.ViewModels
{
    internal class Z : PieceViewModel
    {
        public Z(BoardViewModel board) : base(board, PieceType.Z)
        {
            One = new BlockViewModel(0, 5, Colors.Red, Brushes.Red);
            Two = new BlockViewModel(0, 4, Colors.Red, Brushes.Red);
            Three = new BlockViewModel(1, 5, Colors.Red, Brushes.Red);
            Four = new BlockViewModel(1, 6, Colors.Red, Brushes.Red);
        }

        public override void RotateClockwise()
        {
            int x2 = Two.X, y2 = Two.Y, x3 = Three.X, y3 = Three.Y, x4 = Four.X;

            Action makeMove;
            void revertMove()
            {
                Two.X = x2;
                Two.Y = y2;
                Three.X = x3;
                Three.Y = y3;
                Four.X = x4;
            }

            if ((RotationState % 2) == 0)
            {
                makeMove = () =>
                {
                    Two.X++;
                    Two.Y++;
                    Three.X--;
                    Three.Y++;
                    Four.X -= 2;
                };
            }
            else
            {
                makeMove = () =>
                {
                    Two.X--;
                    Two.Y--;
                    Three.X++;
                    Three.Y--;
                    Four.X += 2;
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
