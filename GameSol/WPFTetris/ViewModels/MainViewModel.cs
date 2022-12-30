using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFTetris.Utilities;

namespace WPFTetris.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        private ObservableCollection<PieceViewModel> board = new();
        private Stopwatch globalTimer = new();
        private long currentDropTime = 0;
        public BoardViewModel Board { get; } = new();
        public MainViewModel()
        {
            globalTimer.Start();
            Task.Run(Start);
        }

        public void Start()
        {

        }

        public void MapFunctionToPieceType(PieceViewModel piece, Func<ObservableCollection<PieceViewModel>> func)
        {
            switch (piece.PieceType)
            {
                case PieceType.I:
                    break;
                case PieceType.T:
                    break;
                case PieceType.S:
                    break;
                case PieceType.Z:
                    break;
                case PieceType.L:
                    break;
                case PieceType.J:
                    break;
                case PieceType.U:
                    break;
            }
        }
    }
}
