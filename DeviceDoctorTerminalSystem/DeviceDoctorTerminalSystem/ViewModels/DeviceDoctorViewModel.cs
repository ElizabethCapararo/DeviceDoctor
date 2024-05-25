using DeviceDoctorTerminalSystem.Enumerations;
using DeviceDoctorTerminalSystem.Models;
using DeviceDoctorTerminalSystem.Services;
using PointOfSaleTerminalSystem.ViewModels;
using System.Collections.ObjectModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DeviceDoctorTerminalSystem.ViewModels
{
    public class DeviceDoctorViewModel : ViewModelBase
    {
        private readonly RepairService repairService;

        public Repair SelectedRepair
        {
            get => Get<Repair>();
            set => Set(value);
        }

        public ObservableCollection<Repair> Repairs { get; } = new();           
        public ObservableCollection<RepairActionViewModel> RepairActions { get; } 

        public DeviceDoctorViewModel(RepairService service) : base("Device Doctor")
        {
            repairService = service;
            RepairActions = new()
            {
                new RepairActionViewModel(RepairAction.RegisterNewRepair, () => Task.CompletedTask)
            };
        }

        public override async Task OnLoad()
        {
            Repairs.Clear();
            (await repairService.GetRepairs()).ForEach(Repairs.Add);
        }
    }
}
