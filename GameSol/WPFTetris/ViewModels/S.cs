using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFTetris.ViewModels
{
    internal class S : PieceViewModel
    {
        public S(BoardViewModel board) : base(board, PieceType.S)
        {
            One = new BlockViewModel(0, 5, Colors.DarkGreen, Brushes.DarkGreen);
            Two = new BlockViewModel(0, 6, Colors.DarkGreen, Brushes.DarkGreen);
            Three = new BlockViewModel(1, 5, Colors.DarkGreen, Brushes.DarkGreen);
            Four = new BlockViewModel(1, 4, Colors.DarkGreen, Brushes.DarkGreen);
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
