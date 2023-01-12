using System;
using System.Collections.ObjectModel;

namespace WPFTetris.ViewModels.Game.Pieces
{
    public abstract class PieceViewModel
    {
        public PieceType PieceType { get; }
        public int RotationState { get; protected set; } = 0;
        protected BoardViewModel Board { get; }
        public BlockViewModel[] Blocks { get; } = new BlockViewModel[4];
        public BlockViewModel One { get => Blocks[0]; set => Blocks[0] = value; }
        public BlockViewModel Two { get => Blocks[1]; set => Blocks[1] = value; }
        public BlockViewModel Three { get => Blocks[2]; set => Blocks[2] = value; }
        public BlockViewModel Four { get => Blocks[3]; set => Blocks[3] = value; }

        public PieceViewModel(PieceType pieceType, BoardViewModel board)
        {
            PieceType = pieceType;
            Board = board;
        }

        public abstract void ResetPiecePosition();
        public abstract void RotateClockwise();
        public abstract void RotateCounterClockwise();

        public bool MoveDown()
        {
            Action makeMove;
            Action revertMove;

            makeMove = () =>
            {
                One.X++;
                Two.X++;
                Three.X++;
                Four.X++;
            };
            revertMove = () =>
            {
                One.X--;
                Two.X--;
                Three.X--;
                Four.X--;
            };

            return Board.MakeMoveIfValid(this, makeMove, revertMove);
        }

        public void HardDrop()
        {
            Action makeMove;
            Action revertMove;

            makeMove = () =>
            {
                One.X++;
                Two.X++;
                Three.X++;
                Four.X++;
            };
            revertMove = () =>
            {
                One.X--;
                Two.X--;
                Three.X--;
                Four.X--;
            };

            while (Board.MakeMoveIfValid(this, makeMove, revertMove)) ;
        }

        public void MoveRight()
        {
            Action makeMove;
            Action revertMove;

            makeMove = () =>
            {
                One.Y++;
                Two.Y++;
                Three.Y++;
                Four.Y++;
            };
            revertMove = () =>
            {
                One.Y--;
                Two.Y--;
                Three.Y--;
                Four.Y--;
            };

            Board.MakeMoveIfValid(this, makeMove, revertMove);
        }

        public void MoveLeft()
        {
            Action makeMove;
            Action revertMove;

            makeMove = () =>
            {
                One.Y--;
                Two.Y--;
                Three.Y--;
                Four.Y--;
            };
            revertMove = () =>
            {
                One.Y++;
                Two.Y++;
                Three.Y++;
                Four.Y++;
            };

            Board.MakeMoveIfValid(this, makeMove, revertMove);
        }

        public void UpdateRotationStateClockwise()
        {
            RotationState = (RotationState + 1) % 4;
        }

        public void UpdateRotationStateCounterClockwise()
        {
            RotationState = (RotationState + 3) % 4;
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
