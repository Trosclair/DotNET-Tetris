using Netris.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUtilities;

namespace Netris.ViewModels.Parameters
{
    public class LevelViewModel : ObservableObject
    {
        private readonly Level model;

        public string Name { get => model.Name; set { model.Name = value; OnPropertyChanged(nameof(Name)); } }
        public int LevelNumber { get => model.LevelNumber; set { model.LevelNumber = value; OnPropertyChanged(nameof(LevelNumber)); } }
        public long FramesBeforeAutoDrop  { get => model.FramesBeforeAutoDrop; set { model.FramesBeforeAutoDrop = value; OnPropertyChanged(nameof(FramesBeforeAutoDrop)); } }
        public long PointsForSingle  { get => model.PointsForSingle; set { model.PointsForSingle = value; OnPropertyChanged(nameof(PointsForSingle)); } }
        public long PointsForDouble  { get => model.PointsForDouble; set { model.PointsForDouble = value; OnPropertyChanged(nameof(PointsForDouble)); } }
        public long PointsForTriple  { get => model.PointsForTriple; set { model.PointsForTriple = value; OnPropertyChanged(nameof(PointsForTriple)); } }
        public long PointsForTetris  { get => model.PointsForTetris; set { model.PointsForTetris = value; OnPropertyChanged(nameof(PointsForTetris)); } }
        public long PointsForTSpinSingle  { get => model.PointsForTSpinSingle; set { model.PointsForTSpinSingle = value; OnPropertyChanged(nameof(PointsForTSpinSingle)); } } 
        public long PointsForTSpinDouble  { get => model.PointsForTSpinDouble; set { model.PointsForTSpinDouble = value; OnPropertyChanged(nameof(PointsForTSpinDouble)); } } 
        public long PointsForTSpinTriple  { get => model.PointsForTSpinTriple; set { model.PointsForTSpinTriple = value; OnPropertyChanged(nameof(PointsForTSpinTriple)); } } 
        public long PointsForPerfectClear  { get => model.PointsForPerfectClear; set { model.PointsForPerfectClear = value; OnPropertyChanged(nameof(PointsForPerfectClear)); } }
        public int LinesClearedRequirement  { get => model.LinesClearedRequirement; set { model.LinesClearedRequirement = value; OnPropertyChanged(nameof(LinesClearedRequirement)); } }
        public long ScoreRequirement  { get => model.ScoreRequirement; set { model.ScoreRequirement = value; OnPropertyChanged(nameof(ScoreRequirement)); } }
        public int PiecesGeneratedRequirement  { get => model.PiecesGeneratedRequirement; set { model.PiecesGeneratedRequirement = value; OnPropertyChanged(nameof(PiecesGeneratedRequirement)); } }
        public long AfterTimeHasPassedRequirement  { get => model.AfterTimeHasPassedRequirement; set { model.AfterTimeHasPassedRequirement = value; OnPropertyChanged(nameof(AfterTimeHasPassedRequirement)); } }
        public long BeforeTimeHasPassedRequirement  { get => model.BeforeTimeHasPassedRequirement; set { model.BeforeTimeHasPassedRequirement = value; OnPropertyChanged(nameof(BeforeTimeHasPassedRequirement)); } }
        public int SingleCountRequirement  { get => model.SingleCountRequirement; set { model.SingleCountRequirement = value; OnPropertyChanged(nameof(SingleCountRequirement)); } }
        public int DoubleCountRequirement  { get => model.DoubleCountRequirement; set { model.DoubleCountRequirement = value; OnPropertyChanged(nameof(DoubleCountRequirement)); } }
        public int TripleCountRequirement  { get => model.TripleCountRequirement; set { model.TripleCountRequirement = value; OnPropertyChanged(nameof(TripleCountRequirement)); } }
        public int TetrisCountRequirement  { get => model.TetrisCountRequirement; set { model.TetrisCountRequirement = value; OnPropertyChanged(nameof(TetrisCountRequirement)); } }
        public int TSpinSingleCountRequirement  { get => model.TSpinSingleCountRequirement; set { model.TSpinSingleCountRequirement = value; OnPropertyChanged(nameof(TSpinSingleCountRequirement)); } }
        public int TSpinDoubleCountRequirement  { get => model.TSpinDoubleCountRequirement; set { model.TSpinDoubleCountRequirement = value; OnPropertyChanged(nameof(TSpinDoubleCountRequirement)); } }
        public int TSpinTripleCountRequirement  { get => model.TSpinTripleCountRequirement; set { model.TSpinTripleCountRequirement = value; OnPropertyChanged(nameof(TSpinTripleCountRequirement)); } }
        public int PerfectClearsCountRequirement { get => model.PerfectClearsCountRequirement; set { model.PerfectClearsCountRequirement = value; OnPropertyChanged(nameof(PerfectClearsCountRequirement)); } }
        public Level? NextLevel  { get => model.NextLevel; set { model.NextLevel = value; OnPropertyChanged(nameof(NextLevel)); } }

        public LevelViewModel(Level level)
        {
            model = level;
        }
    }
}
