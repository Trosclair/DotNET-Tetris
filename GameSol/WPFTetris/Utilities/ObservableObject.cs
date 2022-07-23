using System.ComponentModel;

namespace WPFTetris.Utilities
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
