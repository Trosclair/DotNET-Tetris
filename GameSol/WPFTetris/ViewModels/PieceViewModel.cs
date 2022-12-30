using System.Collections.ObjectModel;

namespace WPFTetris.ViewModels
{
    public abstract class PieceViewModel
    {
        public PieceType PieceType { get; }
        public int RotationState { get; } = 0;
        public ObservableCollection<BlockViewModel> Blocks { get; } = new();

        public PieceViewModel(PieceType pieceType)
        {
            PieceType = pieceType;
        }

        public abstract void RotateClockwise();
        public abstract void RotateCounterClockwise();
        public void MoveDown()
        {
            Blocks[0].X++;
            Blocks[1].X++;
            Blocks[2].X++;
            Blocks[3].X++;

            if (PieceViewModelExtensions.IsOutOfBounds(this))
            {
                Blocks[0].X--;
                Blocks[1].X--;
                Blocks[2].X--;
                Blocks[3].X--;
            }
        }

        public void MoveRight()
        {
            Blocks[0].Y++;
            Blocks[1].Y++;
            Blocks[2].Y++;
            Blocks[3].Y++;

            if (PieceViewModelExtensions.IsOutOfBounds(this))
            {
                Blocks[0].Y--;
                Blocks[1].Y--;
                Blocks[2].Y--;
                Blocks[3].Y--;
            }
        }

        public void MoveLeft()
        {
            Blocks[0].Y--;
            Blocks[1].Y--;
            Blocks[2].Y--;
            Blocks[3].Y--;

            if (PieceViewModelExtensions.IsOutOfBounds(this))
            {
                Blocks[0].Y++;
                Blocks[1].Y++;
                Blocks[2].Y++;
                Blocks[3].Y++;
            }
        }
    }

    public static class PieceViewModelExtensions
    {
        public static bool IsOutOfBounds(this PieceViewModel me)
        {
            foreach (BlockViewModel block in me.Blocks)
            {
                if (block.IsOutOfBounds())
                    return true;
            }
            return false;
        }

        public static bool CollidesWith(this PieceViewModel me, PieceViewModel otherPiece)
        {
            foreach (BlockViewModel myBlock in me.Blocks)
            {
                foreach (BlockViewModel theirBlock in otherPiece.Blocks)
                {
                    if (myBlock.CollidesWith(theirBlock))
                        return true;
                }
            }
            return false;
        }
    }
}
