using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Netris.ViewModels.Game.Pieces
{
    internal class Z : PieceViewModel
    {
        public Z(BoardViewModel board) : base(PieceType.Z, board)
        {
            One = new BlockViewModel(1, 5, Colors.Red, Brushes.Red);
            Two = new BlockViewModel(1, 4, Colors.Red, Brushes.Red);
            Three = new BlockViewModel(2, 5, Colors.Red, Brushes.Red);
            Four = new BlockViewModel(2, 6, Colors.Red, Brushes.Red);
        }

        public override void ResetPiecePosition()
        {
            One.X = Two.X = 1;
            Three.X = Four.X = 2;

            One.Y = Three.Y = 5;
            Two.Y = 4;
            Four.Y = 6;

            RotationState = 0;
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
