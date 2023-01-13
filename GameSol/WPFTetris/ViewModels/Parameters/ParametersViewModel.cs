using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTetris.Models.Parameters;

namespace WPFTetris.ViewModels.Parameters
{
    public class ParametersViewModel
    {
        private readonly Models.Parameters.Parameters model;
        public DASViewModel DAS { get; }

        public ParametersViewModel(Models.Parameters.Parameters parameters)
        {
            model = parameters;

            DAS = new(model.DAS);
        }
    }
}
