using DeviceDoctorTerminalSystem.Enumerations;
using DeviceDoctorTerminalSystem.Models;
using DeviceDoctorTerminalSystem.Services;
using PointOfSaleTerminalSystem.ViewModels;
using System.Collections.ObjectModel;

namespace DeviceDoctorTerminalSystem.ViewModels
{
    public class DeviceDoctorViewModel : ViewModelBase
    {
        private readonly RepairService repairService;

        public bool CanUpdateRepair => SelectedRepair != null;

        public Repair SelectedRepair
        {
            get => Get<Repair>();
            set
            {
                Set(value);
                NotifyChanged(nameof(CanUpdateRepair));
            }
        }

        public ObservableCollection<Repair> Repairs { get; } = new();               
        public ObservableCollection<RepairActionViewModel> RepairActions { get; } 

        public DeviceDoctorViewModel(RepairService repairService) : base("Device Doctor")
        {
            this.repairService = repairService;
            RepairActions = new()
            {
                new RepairActionViewModel(RepairAction.RegisterNewRepair, RegisterNewRepair),
                new RepairActionViewModel(RepairAction.CancelRepair, CancelRepair),
                new RepairActionViewModel(RepairAction.SaveChangesToRepair, UpdateRepair),
                new RepairActionViewModel(RepairAction.DeleteRepair, DeleteRepair),
                new RepairActionViewModel(RepairAction.CompleteRepair, CompleteRepair)                              
            };
        }

        public override Task OnLoad()
        {
            RefreshRepairs();
            return Task.CompletedTask;
        }

        private void RefreshRepairs()
        {
            Repairs.Clear();
            repairService.GetRepairs().ForEach(Repairs.Add);
        }

        private void RegisterNewRepair()
        {
            SelectedRepair = Repair.Create();
        }

        private void UpdateRepair()
        {
            repairService.UpdateRepair(SelectedRepair);
            RefreshRepairs();
        }

        private async void CompleteRepair()
        {
            await repairService.CompleteRepair(SelectedRepair);
            RefreshRepairs();
        }
        private void CancelRepair() => 
            SelectedRepair = Repair.Create();
        
        private void DeleteRepair()
        {
            repairService.DeleteRepair(SelectedRepair);
            RefreshRepairs();
        }
    }
}
