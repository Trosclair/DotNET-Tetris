using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTetris.ViewModels
{
    public abstract class PieceViewModel
    {
        public ObservableCollection<BlockViewModel> Blocks { get; }
        public PieceType PieceType { get; }
        public int RotationState { get; }

        public PieceViewModel(ObservableCollection<BlockViewModel> blocks, PieceType pieceType, int rotationState)
        {
            Blocks = blocks;
            PieceType = pieceType;
            RotationState = (rotationState + 4) % 4;
        }

        public abstract ObservableCollection<BlockViewModel> RotateClockwise();
        public abstract ObservableCollection<BlockViewModel> RotateCounterClockwise();
        public ObservableCollection<BlockViewModel> MoveDown()
        {
            return new(Blocks.Select(block => new BlockViewModel(block.BoardPosition + 10, block.Brush)));
        }

        public ObservableCollection<BlockViewModel> MoveRight()
        {
            return new(Blocks.Select(block => new BlockViewModel(block.BoardPosition + 1, block.Brush)));
        }

        public ObservableCollection<BlockViewModel> MoveLeft()
        {
            return new(Blocks.Select(block => new BlockViewModel(block.BoardPosition - 1, block.Brush)));
        }
    }
}
