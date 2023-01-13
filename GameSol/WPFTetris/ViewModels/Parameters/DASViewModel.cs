using WPFUtilities;
using WPFTetris.Models.Parameters;

namespace WPFTetris.ViewModels.Parameters
{
    public class DASViewModel : ObservableObject
    {
        private readonly DAS model;

        public int StartingDelay { get => model.StartingDelay; set { model.StartingDelay = value; OnPropertyChanged(nameof(StartingDelay)); } }
        public int EndingDelay { get => model.EndingDelay; set { model.EndingDelay = value; OnPropertyChanged(nameof(EndingDelay)); } }
        public int Acceleration { get => model.Acceleration; set { model.Acceleration = value; OnPropertyChanged(nameof(Acceleration)); } }

        public DASViewModel(DAS das)
        {
            model = das;
        }
    }
}
