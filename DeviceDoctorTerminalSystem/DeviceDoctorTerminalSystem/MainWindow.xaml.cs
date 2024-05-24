using DeviceDoctorTerminalSystem.ViewModels;
using System.Windows;

namespace DeviceDoctorTerminalSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(DeviceDoctorViewModel mainViewModel)
        {             
            InitializeComponent();
            DataContext = mainViewModel;
        }
    }
}