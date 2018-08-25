using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSol
{
    class J : Piece
    {
        public J(int[,] board)
        {
            One = new Block(0, 5);
            Two = new Block(1, 5);
            Three = new Block(2, 5);
            Four = new Block(2, 4);
            Piece_Type = "J";
            Board = board;
        }

        public override void RotateLeft()
        {
            if (Four.Y + 1 == Three.Y)
            {
                Four.Y += 2;
                Three.X--;
                Three.Y++;
                One.X++;
                One.Y--;
            }
            else if (Four.X + 1 == Three.X)
            {
                Four.X += 2;
                Three.X++;
                Three.Y++;
                One.X--;
                One.Y--;
            }
            else if (Three.Y + 1 == Four.Y)
            {
                Four.Y -= 2;
                Three.X++;
                Three.Y--;
                One.X--;
                One.Y++;
            }
            else
            {
                Four.X -= 2;
                Three.X--;
                Three.Y--;
                One.X++;
                One.Y++;
            }
        }

        public override void RotateRight()
        {
            if (Four.Y + 1 == Three.Y)
            {
                Four.X -= 2;
                Three.X--;
                Three.Y--;
                One.X++;
                One.Y++;
            }
            else if (Four.X + 1 == Three.X)
            {
                Four.Y += 2;
                Three.X--;
                Three.Y++;
                One.X++;
                One.Y--;
            }
            else if (Three.Y + 1 == Four.Y)
            {
                Four.X += 2;
                Three.X++;
                Three.Y++;
                One.X--;
                One.Y--;
            }
            else
            {
                Four.Y -= 2;
                Three.X++;
                Three.Y--;
                One.X--;
                One.Y++;
            }
        }
    }
}
