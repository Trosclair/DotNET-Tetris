using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netris.Models
{
    public class Player
    {
        public int PlayerNumber { get; set; }
        public long Score { get; set; }
        public int LinesCleared { get; set; }
        public int PiecesGenerated { get; set; }
        public int Level { get; set; }
        public int ICount { get; set; }
        public int UCount { get; set; }
        public int TCount { get; set; }
        public int SCount { get; set; }
        public int ZCount { get; set; }
        public int LCount { get; set; }
        public int JCount { get; set; }
        public int SingleCount { get; set; }
        public int DoubleCount { get; set; }
        public int TripleCount { get; set; }
        public int TetrisCount { get; set; }
        public int TSpinSingleCount { get; set; }
        public int TSpinDoubleCount { get; set; }
        public int TSpinTripleCount { get; set; }
        public int PerfectClearsCount { get; set; }
        public long EndGameTime { get; set; }
        public Player()
        {

        }
    }
}
