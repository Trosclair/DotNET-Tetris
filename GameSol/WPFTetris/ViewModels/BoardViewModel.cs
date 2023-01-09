using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using WPFTetris.ViewModels.Pieces;

namespace WPFTetris.ViewModels
{
    public class BoardViewModel : ObservableCollection<BlockViewModel>
    {
        private Shadow shadow = new();
        public BlockViewModel this[int i, int j] { get => this[(i * 10) + j]; set => this[(i * 10) + j] = value; }
        public BlockViewModel this[BlockViewModel block] { get => this[block.X, block.Y]; set => this[block.X, block.Y] = value; }

        public BoardViewModel()
        {
            for (int i = 0; i < 200; i++)
                Add(new BlockViewModel(i / 10, i % 10, Colors.Transparent, Brushes.Transparent));
        }


        public bool MakeMoveIfValid(PieceViewModel piece, Action makeMove, Action revertMove)
        {
            bool isMoveValid;

            RemovePieceFromBoard(piece);

            makeMove();

            isMoveValid = !PieceViewModelExtensions.IsOutOfBounds(piece);

            if (isMoveValid)
            {
                foreach (BlockViewModel block in piece.Blocks)
                {
                    if (!this[block.X, block.Y].IsEmpty)
                    {
                        isMoveValid = false;
                        revertMove();
                        break;
                    }
                }
            }
            else
            {
                revertMove();
            }

            AddPieceToBoard(piece);

            return isMoveValid;
        }

        public void AddPieceToBoard(PieceViewModel piece)
        {
            UpdateShadow(piece);

            foreach (BlockViewModel block in piece.Blocks)
            {
                this[block.X, block.Y].Color = piece.One.Color;
                this[block.X, block.Y].Brush = piece.One.Brush;
            }
        }

        public void RemovePieceFromBoard(PieceViewModel piece)
        {
            foreach (BlockViewModel block in piece.Blocks)
            {
                this[block.X, block.Y].Color = Colors.Transparent;
                this[block.X, block.Y].Brush = Brushes.Transparent;
            }
        }

        public int CheckBoardForLineClears()
        {
            int linesCleared = 0;

            for (int i = 19; i >= 0; i--)
            {
                bool isClear = true;

                for (int j = 0; j < 10; j++)
                {
                    isClear &= !this[i, j].IsEmpty;
                }

                if (isClear)
                {
                    linesCleared++;
                    ClearLine(i);
                    i++;
                }
            }

            return linesCleared;
        }

        private void UpdateShadow(PieceViewModel piece)
        {
            foreach (BlockViewModel block in shadow.Blocks)
            {
                if (this[block].Brush == Brushes.White)
                {
                    this[block].Brush = Brushes.Transparent;
                    this[block].Color = Colors.Transparent;
                }
            }

            shadow.One = new(piece.One.X, piece.One.Y, Colors.White, Brushes.White);
            shadow.Two = new(piece.Two.X, piece.Two.Y, Colors.White, Brushes.White);
            shadow.Three = new(piece.Three.X, piece.Three.Y, Colors.White, Brushes.White);
            shadow.Four = new(piece.Four.X, piece.Four.Y, Colors.White, Brushes.White);

            do
            {
                shadow.One.X++;
                shadow.Two.X++;
                shadow.Three.X++;
                shadow.Four.X++;
            }
            while (!shadow.IsOutOfBounds() && this[shadow.One].IsEmpty && this[shadow.Two].IsEmpty && this[shadow.Three].IsEmpty && this[shadow.Four].IsEmpty);

            shadow.One.X--;
            shadow.Two.X--;
            shadow.Three.X--;
            shadow.Four.X--;

            foreach (BlockViewModel block in shadow.Blocks)
            {
                this[block].Color = shadow.One.Color;
                this[block].Brush = shadow.One.Brush;
            }
        }

        private void ClearLine(int rowToClear)
        {
            for (int i = rowToClear; i >= 1; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    this[i, j].Color = this[i - 1, j].Color;
                    this[i, j].Brush = this[i - 1, j].Brush;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                this[0, i].Color = Colors.Transparent;
                this[0, i].Brush = Brushes.Transparent;
            }
        }
    }
}
