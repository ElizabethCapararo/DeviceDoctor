using DeviceDoctorTerminalSystem.Enumerations;
using DeviceDoctorTerminalSystem.Models;
using DeviceDoctorTerminalSystem.Services;
using DeviceDoctorTerminalSystem.Utilities;
using Microsoft.Toolkit.Mvvm.Input;
using PointOfSaleTerminalSystem.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DeviceDoctorTerminalSystem.ViewModels
{
    public class DeviceDoctorViewModel : ViewModelBase
    {
        private readonly DeviceService deviceService;

        public ObservableCollection<DeviceListViewModel> DeviceLists { get; } = new();       

        public DeviceDoctorViewModel(DeviceService service) : base("Device Doctor")
        {
            deviceService = service;            
        }

        protected override async Task OnLoad()
        {            
            var devices = await deviceService.GetDevices();

            DeviceLists.Clear();
            Enum.GetValues<Status>()
                .ToList()
                .ForEach(status =>
                    DeviceLists.Add(new DeviceListViewModel(
                        status.Description(),
                        devices.Where(device => device.Status == status).ToList())));
        }
    }
}
