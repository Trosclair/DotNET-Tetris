using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netris.Models.Parameters
{
    public class Level
    {
        public string Name { get; set; } = string.Empty;
        public int LevelNumber { get; set; } = 0;
        public long FramesBeforeAutoDrop { get; set; } = 60;
        public long PointsForSingle { get; set; } = 100;
        public long PointsForDouble { get; set; } = 200;
        public long PointsForTriple { get; set; } = 400;
        public long PointsForTetris { get; set; } = 1000;
        public long PointsForTSpinSingle { get; set; } = 400;
        public long PointsForTSpinDouble { get; set; } = 1000;
        public long PointsForTSpinTriple { get; set; } = 1400;
        public long PointsForPerfectClear { get; set; } = 1600;
        public int LinesClearedRequirement { get; set; } = 0;
        public long ScoreRequirement { get; set; } = 0;
        public int PiecesGeneratedRequirement { get; set; } = 0;
        public long AfterTimeHasPassedRequirement { get; set; } = 0;
        public long BeforeTimeHasPassedRequirement { get; set; } = 0;
        public int SingleCountRequirement { get; set; } = 0;
        public int DoubleCountRequirement { get; set; } = 0;
        public int TripleCountRequirement { get; set; } = 0;
        public int TetrisCountRequirement { get; set; } = 0;
        public int TSpinSingleCountRequirement { get; set; } = 0;
        public int TSpinDoubleCountRequirement { get; set; } = 0;
        public int TSpinTripleCountRequirement { get; set; } = 0;
        public int PerfectClearsCountRequirement { get; set; } = 0;
        public Level? NextLevel { get; set; } = null;

        public Level() { }

    }
}
