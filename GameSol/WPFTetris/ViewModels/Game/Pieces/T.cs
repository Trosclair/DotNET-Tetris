using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Netris.ViewModels.Game.Pieces
{
    public class T : PieceViewModel
    {
        // Rotation 0:
        // 00100
        // 04230
        // 00000

        public T(BoardViewModel board) : base(PieceType.T, board)
        {
            One = new BlockViewModel(0, 5, Colors.Purple, Brushes.Purple);
            Two = new BlockViewModel(1, 5, Colors.Purple, Brushes.Purple);
            Three = new BlockViewModel(1, 6, Colors.Purple, Brushes.Purple);
            Four = new BlockViewModel(1, 4, Colors.Purple, Brushes.Purple);
        }

        public override void ResetPiecePosition()
        {
            One.X = 0;
            Two.X = Three.X = Four.X = 1;

            One.Y = Two.Y = 5;
            Three.Y = 6;
            Four.Y = 4;

            RotationState = 0;
        }

        public override void RotateClockwise()
        {
            int x1 = One.X, y1 = One.Y, x3 = Three.X, y3 = Three.Y, x4 = Four.X, y4 = Four.Y;

            Action makeMove;
            void revertMove()
            {
                One.X = x1;
                One.Y = y1;
                Three.X = x3;
                Three.Y = y3;
                Four.X = x4;
                Four.Y = y4;
            }

            if (RotationState == 0)
            {
                // 00100
                // 04230
                // 00000
                makeMove = () =>
                {
                    Four.X--;
                    Four.Y++;
                    One.X++;
                    One.Y++;
                    Three.X++;
                    Three.Y--;
                };
            }
            else if (RotationState == 1)
            {
                // 00400
                // 00210
                // 00300
                makeMove = () =>
                {
                    One.X++;
                    One.Y--;
                    Three.X--;
                    Three.Y--;
                    Four.X++;
                    Four.Y++;
                };
            }
            else if (RotationState == 2)
            {
                // 00000
                // 03240
                // 00100
                makeMove = () =>
                {
                    One.X--;
                    One.Y--;
                    Three.X--;
                    Three.Y++;
                    Four.X++;
                    Four.Y--;
                };
            }
            else
            {
                // 00300
                // 01200
                // 00400
                makeMove = () =>
                {
                    One.X--;
                    One.Y++;
                    Three.X++;
                    Three.Y++;
                    Four.X--;
                    Four.Y--;
                };
            }

            if (Board.MakeMoveIfValid(this, makeMove, revertMove))
            {
                UpdateRotationStateClockwise();
            }
        }

        public override void RotateCounterClockwise()
        {
            int x1 = One.X, y1 = One.Y, x3 = Three.X, y3 = Three.Y, x4 = Four.X, y4 = Four.Y;

            Action makeMove;
            void revertMove()
            {
                One.X = x1;
                One.Y = y1;
                Three.X = x3;
                Three.Y = y3;
                Four.X = x4;
                Four.Y = y4;
            }

            if (RotationState == 0)
            {
                // 00100
                // 04230
                // 00000
                makeMove = () =>
                {
                    Four.X++;
                    Four.Y++;
                    One.X++;
                    One.Y--;
                    Three.X--;
                    Three.Y--;
                };
            }
            else if (RotationState == 1)
            {
                // 00300
                // 01200
                // 00400
                makeMove = () =>
                {
                    One.X--;
                    One.Y--;
                    Three.X--;
                    Three.Y++;
                    Four.X++;
                    Four.Y--;
                };
            }
            else if (RotationState == 2)
            {
                // 00000
                // 03240
                // 00100
                makeMove = () =>
                {
                    One.X--;
                    One.Y++;
                    Three.X++;
                    Three.Y++;
                    Four.X--;
                    Four.Y--;
                };
            }
            else
            {
                // 00400
                // 00210
                // 00300
                makeMove = () =>
                {
                    One.X++;
                    One.Y++;
                    Three.X++;
                    Three.Y--;
                    Four.X--;
                    Four.Y++;
                };
            }

            if (Board.MakeMoveIfValid(this, makeMove, revertMove))
            {
                UpdateRotationStateCounterClockwise();
            }
        }
    }
}
