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
            throw new NotImplementedException();
        }

        public override void RotateRight()
        {
            throw new NotImplementedException();
        }
    }
}
