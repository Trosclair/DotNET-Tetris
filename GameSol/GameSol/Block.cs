using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSol
{
    class Block
    {
        private int _X;
        private int _Y;

        public Block(int x, int y)
        {
            _X = x;
            _Y = y;
        }

        public int X
        {
            get
            {
                return _X;
            }

            set
            {
                _X = value;
            }
        }

        public int Y
        {
            get
            {
                return _Y;
            }

            set
            {
                _Y = value;
            }
        }
    }
}
