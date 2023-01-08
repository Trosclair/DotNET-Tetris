using WPFTetris.Utilities;
using WPFTetris.ViewModels.Pieces;

namespace WPFTetris.ViewModels
{
    public class PiecePresenterViewModel : ObservableObject
    {
        private PieceViewModel piece;
        public PieceViewModel Piece { get => piece; set { piece = value; OnPropertyChanged(nameof(Piece)); } }

        public PiecePresenterViewModel(PieceViewModel piece)
        {
            this.piece = piece;
        }
    }
}
