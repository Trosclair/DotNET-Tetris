using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPFTetris.ViewModels;

namespace WPFTetris.ViewModels
{
    public class BoardViewModel : ObservableCollection<BlockViewModel>
    {
        public BlockViewModel this[int i, int j] { get => this[(i * 10) + j]; set => this[(i * 10) + j] = value; }

        public BoardViewModel()
        {
            for (int i = 0; i < 200; i++)
                Add(new BlockViewModel(i / 10, i % 10, Colors.Transparent, Brushes.Transparent));


        }
    }

    public static class BoardViewModelExtensions
    {
        public static bool MakeMoveIfValid(this BoardViewModel board, PieceViewModel piece, Action makeMove, Action revertMove)
        {
            bool isMoveValid;

            board.RemovePieceToBoard(piece);

            makeMove();

            isMoveValid = !PieceViewModelExtensions.IsOutOfBounds(piece);

            if (isMoveValid)
            {
                foreach (BlockViewModel block in piece.Blocks)
                {
                    if (board[block.X, block.Y].Color != Colors.Transparent && board[block.X, block.Y].Color != Colors.White)
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

            board.AddPieceToBoard(piece);

            return isMoveValid;
        }

        public static void AddPieceToBoard(this BoardViewModel board, PieceViewModel piece)
        {
            foreach (BlockViewModel block in piece.Blocks)
            {
                board[block.X, block.Y].Color = piece.One.Color;
                board[block.X, block.Y].Brush = piece.One.Brush;
            }
        }

        public static void RemovePieceToBoard(this BoardViewModel board, PieceViewModel piece)
        {
            foreach (BlockViewModel block in piece.Blocks)
            {
                board[block.X, block.Y].Color = Colors.Transparent;
                board[block.X, block.Y].Brush = Brushes.Transparent;
            }
        }
    }
}
