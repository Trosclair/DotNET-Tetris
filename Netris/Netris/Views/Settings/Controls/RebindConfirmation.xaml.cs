using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFUtilities.Extensions;

namespace Netris.Views.Settings.Controls
{
    /// <summary>
    /// Interaction logic for RebindConfirmation.xaml
    /// </summary>
    public partial class RebindConfirmation : Window
    {
        public RebindConfirmation()
        {
            InitializeComponent();

            double width = Application.Current.MainWindow.ActualWidth;
            double height = Application.Current.MainWindow.ActualHeight;

            double top = Application.Current.MainWindow.GetWindowTop() ?? 0;
            double left = Application.Current.MainWindow.GetWindowLeft() ?? 0;

            Width = width / 2;
            Height = height / 2;

            Top = top + (Height / 2);
            Left = left + (Width / 2);
        }
    }
}
