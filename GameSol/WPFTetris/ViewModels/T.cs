using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTetris.ViewModels
{
    public class T : PieceViewModel
    {
        // Rotation 0:
        // 00100
        // 04230
        // 00000

        public T() : base(PieceType.T) 
        { 
            // add blocks dummy
        }

        public override void RotateClockwise()
        {
        }

        public override void RotateCounterClockwise()
        {
        }
    }
}
