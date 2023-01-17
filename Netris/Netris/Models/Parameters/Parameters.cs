using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netris.Models.Parameters
{
    public class Parameters
    {
        public DAS DAS { get; set; } = new();
        public PieceGeneration PieceGeneration { get; set; } = new();
        public List<Level> Levels { get; set; } = new();
        public int StartingLevel { get; set; } = 0;

        [JsonConstructor]
        public Parameters()
        {

        }
    }
}
