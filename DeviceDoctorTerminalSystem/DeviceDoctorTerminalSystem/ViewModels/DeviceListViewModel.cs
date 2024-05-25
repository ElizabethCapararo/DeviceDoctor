using DeviceDoctorTerminalSystem.Models;
using Microsoft.Toolkit.Mvvm.Input;
using PointOfSaleTerminalSystem.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DeviceDoctorTerminalSystem.ViewModels
{
    public class DeviceListViewModel : ViewModelBase
    {        
        public ObservableCollection<Device> Devices { get; } = new();

        public ICommand ViewCommand { get; }

        public Device SelectedDevice
        {
            get => Get<Device>();
            set => Set(value);
        }

        public DeviceListViewModel(string title, List<Device> devices) : base(title)
        {
            devices.ForEach(Devices.Add);
            ViewCommand = new RelayCommand(View);
        }

        private void View()
        {

        }
    }
}
