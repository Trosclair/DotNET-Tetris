using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Netris.Models.Parameters;

namespace Netris.ViewModels.Parameters
{
    public class ParametersViewModel
    {
        private readonly Models.Parameters.Parameters model;
        public DASViewModel DAS { get; }
        public PieceGenerationViewModel PieceGeneration { get; }

        public ParametersViewModel(Models.Parameters.Parameters parameters)
        {
            model = parameters;

            DAS = new(model.DAS);
            PieceGeneration = new(model.PieceGeneration);
        }
    }
}
