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

        public T(ObservableCollection<BlockViewModel> blocks, int rotationState) : base(blocks, PieceType.T, rotationState) 
        { 
            // add blocks dummy
        }

        public override ObservableCollection<BlockViewModel> RotateClockwise()
        {
            ObservableCollection<BlockViewModel> result = new();
            
            if (RotationState == 0)
            {
                result.Add(new BlockViewModel(Blocks[0].BoardPosition + 11, Blocks[0].Brush));
                result.Add(new BlockViewModel(Blocks[1].BoardPosition, Blocks[1].Brush));
                result.Add(new BlockViewModel(Blocks[2].BoardPosition + 9, Blocks[2].Brush));
                result.Add(new BlockViewModel(Blocks[3].BoardPosition - 9, Blocks[3].Brush));
            }
            else if (RotationState == 1)
            {
                result.Add(new BlockViewModel(Blocks[0].BoardPosition + 9, Blocks[0].Brush));
                result.Add(new BlockViewModel(Blocks[1].BoardPosition, Blocks[1].Brush));
                result.Add(new BlockViewModel(Blocks[2].BoardPosition - 11, Blocks[2].Brush));
                result.Add(new BlockViewModel(Blocks[3].BoardPosition + 11, Blocks[3].Brush));
            }
            else if (RotationState == 2)
            {
                result.Add(new BlockViewModel(Blocks[0].BoardPosition - 11, Blocks[0].Brush));
                result.Add(new BlockViewModel(Blocks[1].BoardPosition, Blocks[1].Brush));
                result.Add(new BlockViewModel(Blocks[2].BoardPosition - 9, Blocks[2].Brush));
                result.Add(new BlockViewModel(Blocks[3].BoardPosition + 9, Blocks[3].Brush));
            }
            else
            {
                result.Add(new BlockViewModel(Blocks[0].BoardPosition - 9, Blocks[0].Brush));
                result.Add(new BlockViewModel(Blocks[1].BoardPosition, Blocks[1].Brush));
                result.Add(new BlockViewModel(Blocks[2].BoardPosition + 11, Blocks[2].Brush));
                result.Add(new BlockViewModel(Blocks[3].BoardPosition - 11, Blocks[3].Brush));
            }

            return result;
        }

        // Rotation 0:
        // 00100
        // 04230
        // 00000
        public override ObservableCollection<BlockViewModel> RotateCounterClockwise()
        {
            ObservableCollection<BlockViewModel> result = new();

            if (RotationState == 0)
            {
                result.Add(new BlockViewModel(Blocks[0].BoardPosition + 9, Blocks[0].Brush));
                result.Add(new BlockViewModel(Blocks[1].BoardPosition, Blocks[1].Brush));
                result.Add(new BlockViewModel(Blocks[2].BoardPosition - 11, Blocks[2].Brush));
                result.Add(new BlockViewModel(Blocks[3].BoardPosition + 11, Blocks[3].Brush));
            }
            else if (RotationState == 1)
            {
                result.Add(new BlockViewModel(Blocks[0].BoardPosition + 11, Blocks[0].Brush));
                result.Add(new BlockViewModel(Blocks[1].BoardPosition, Blocks[1].Brush));
                result.Add(new BlockViewModel(Blocks[2].BoardPosition + 9, Blocks[2].Brush));
                result.Add(new BlockViewModel(Blocks[3].BoardPosition - 9, Blocks[3].Brush));
            }
            else if (RotationState == 2)
            {
                result.Add(new BlockViewModel(Blocks[0].BoardPosition - 9, Blocks[0].Brush));
                result.Add(new BlockViewModel(Blocks[1].BoardPosition, Blocks[1].Brush));
                result.Add(new BlockViewModel(Blocks[2].BoardPosition + 11, Blocks[2].Brush));
                result.Add(new BlockViewModel(Blocks[3].BoardPosition - 11, Blocks[3].Brush));
            }
            else
            {
                result.Add(new BlockViewModel(Blocks[0].BoardPosition - 11, Blocks[0].Brush));
                result.Add(new BlockViewModel(Blocks[1].BoardPosition, Blocks[1].Brush));
                result.Add(new BlockViewModel(Blocks[2].BoardPosition - 9, Blocks[2].Brush));
                result.Add(new BlockViewModel(Blocks[3].BoardPosition + 9, Blocks[3].Brush));
            }

            return result;
        }
    }
}
