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

        [JsonConstructor]
        public Parameters()
        {

        }
    }
}
