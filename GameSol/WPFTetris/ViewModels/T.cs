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
        public T(ObservableCollection<BlockViewModel> blocks, int rotationState) : base(blocks, PieceType.T, rotationState) { }

        public override ObservableCollection<BlockViewModel> RotateClockwise()
        {
            throw new NotImplementedException();
        }

        public override ObservableCollection<BlockViewModel> RotateCounterClockwise()
        {
            throw new NotImplementedException();
        }
    }
}
