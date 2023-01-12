using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WPFTetris.ViewModels;

namespace WPFTetris.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel = new MainViewModel();
        }
    }
}
