using DeviceDoctorTerminalSystem.Support;

namespace PointOfSaleTerminalSystem.ViewModels
{
    public class ViewModelBase : NotifyPropertyChanged
    {
        public string Title { get; }

        public ViewModelBase(string title)
        {
            Title = title;
        }
    }
}
