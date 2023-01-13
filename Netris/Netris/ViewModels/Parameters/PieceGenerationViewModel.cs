using Netris.Models.Parameters;
using WPFUtilities;

namespace Netris.ViewModels.Parameters
{
    public class PieceGenerationViewModel : ObservableObject
    {
        private readonly PieceGeneration model;

        public PieceGenerationType Type { get => model.Type; set { model.Type = value; OnPropertyChanged(nameof(Type)); } }
        public bool IsSynchronizedAcrossPlayers { get => model.IsSynchronizedAcrossPlayers; set { model.IsSynchronizedAcrossPlayers = value; OnPropertyChanged(nameof(IsSynchronizedAcrossPlayers)); } }

        public PieceGenerationViewModel(PieceGeneration pieceGeneration) 
        { 
            model = pieceGeneration;
        }
    }
}
