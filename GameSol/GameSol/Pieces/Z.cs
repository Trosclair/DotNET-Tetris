using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSol
{
    class Z : Piece
    {
        public Z(int[,] board)
        {
            One = new Block(0, 5);
            Two = new Block(0, 4);
            Three = new Block(1, 5);
            Four = new Block(1, 6);
            Piece_Type = "Z";
            Board = board;
        }

        public override void RotateLeft()
        {
            if (One.X == Two.X)
            {
                Two.X++;
                Two.Y++;
                Three.X--;
                Three.Y++;
                Four.X -= 2;
            }
            else if (One.Y == Two.Y)
            {
                Two.X--;
                Two.Y--;
                Three.X++;
                Three.Y--;
                Four.X += 2;
            }
        }

        public override void RotateRight()
        {
            RotateLeft();
        }
    }
}
