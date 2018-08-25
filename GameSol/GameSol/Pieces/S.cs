using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSol
{
    class S : Piece
    {
        public S(int[,] board)
        {
            One = new Block(0, 5);
            Two = new Block(0, 6);
            Three = new Block(1, 5);
            Four = new Block(1, 4);
            Piece_Type = "S";
            Board = board;
        }

        public override void RotateLeft()
        {
            if (One.X == Two.X)
            {
                Two.X--;
                Two.Y--;
                Three.X--;
                Three.Y++;
                Four.Y += 2;
            }
            else
            {
                Two.X++;
                Two.Y++;
                Three.X++;
                Three.Y--;
                Four.Y -= 2;
            }
        }

        public override void RotateRight()
        {
            RotateLeft();
        }
    }
}
