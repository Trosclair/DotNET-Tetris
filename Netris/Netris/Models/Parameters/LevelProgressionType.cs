using System;

namespace Netris.Models.Parameters
{
    [Flags]
    public enum LevelProgressionType
    {
        LinesCleared = 0,
        Score = 1,
        Pieces = 2,
        AfterTimePassed = 3,
        BeforeTimePassed = 8,
        SingleCount = 16,
        DoubleCount = 32,
        TripleCount = 64,
        TSpinSingleCount = 128,
        TSpinDoubleCount = 256,
        TetrisCount = 512,
    }
}
