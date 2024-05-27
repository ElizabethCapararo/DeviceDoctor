using DeviceDoctorTerminalSystem.Models;
using PointOfSaleTerminalSystem.ViewModels;

namespace DeviceDoctorTerminalSystem.ViewModels
{
    public class RepairDeviceViewModel : BaseViewModel
    {
        public Device? Device { get; }

        public RepairDeviceViewModel(Device device) : base()
        {
            Device = device;
        }
    }
}
