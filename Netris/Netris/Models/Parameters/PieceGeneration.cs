using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netris.Models.Parameters
{
    public class PieceGeneration
    {
        public PieceGenerationType Type { get; set; } = PieceGenerationType.Random;
        public bool IsSynchronizedAcrossPlayers { get; set; } = true;
        public PieceGeneration() { }
    }
}
