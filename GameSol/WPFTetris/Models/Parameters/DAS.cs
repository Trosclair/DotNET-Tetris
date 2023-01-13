using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netris.Models.Parameters
{
    /// <summary>
    /// Writing a DAS algorithm is a bitch, but parameterizing it is suffering incarnate...
    /// everything is in milliseconds except for acceleration which is in ms/s
    /// </summary>
    public class DAS
    {
        public int StartingDelay { get; set; } = 250;
        public int EndingDelay { get; set; } = 30;
        public int Acceleration { get; set; } = 100;
    }
}
