using DeviceDoctorTerminalSystem.Enumerations;
using DeviceDoctorTerminalSystem.Services;
using PointOfSaleTerminalSystem.ViewModels;
using System.Collections.ObjectModel;

namespace DeviceDoctorTerminalSystem.ViewModels
{
    public class DeviceDoctorViewModel : BaseViewModel
    {
        private readonly RepairService _repairService;

        public ObservableCollection<RepairActionViewModel> RepairActions { get; }

        public RepairViewModel SelectedRepair
        {
            get => Get<RepairViewModel>();
            set
            {
                Set(value);
                if (SelectedRepair == null)
                {
                    return;
                }
                Load();
            }
        }

        public ObservableCollection<RepairViewModel> Repairs { get; } = new();               
       
        public DeviceDoctorViewModel(RepairService repairService) : base("Device Doctor")
        {
            _repairService = repairService;

            RepairActions = new()
            {
                new RepairActionViewModel(RepairAction.RegisterNewRepair, RegisterNewRepair),
                new RepairActionViewModel(RepairAction.CancelRepair, CancelRepair),
                new RepairActionViewModel(RepairAction.SaveChangesToRepair, UpdateRepair),
                new RepairActionViewModel(RepairAction.DeleteRepair, DeleteRepair),
                new RepairActionViewModel(RepairAction.CompleteRepair, CompleteRepair)
            };
        }

        public override void Load()
        {
            LoadRepairs();
            RepairActions.ToList().ForEach(vm => vm.Load());
        }

        private void LoadRepairs()
        {
            Repairs.Clear();
            _repairService.GetRepairs().ForEach(repair => Repairs.Add(new RepairViewModel(repair)));
        }

        private void RegisterNewRepair()
        {
            SelectedRepair = new();
        }

        private async void UpdateRepair()
        {
            SelectedRepair.Update();
            await _repairService.UpdateRepair(SelectedRepair.Repair);
            Load();
        }

        private async void CompleteRepair()
        {
            SelectedRepair.Complete();
            await _repairService.UpdateRepair(SelectedRepair.Repair);
            Load();
        }
        private async void CancelRepair()
        {
            SelectedRepair.Cancel();
            await _repairService.UpdateRepair(SelectedRepair.Repair);
            Load();
        }
        
        private async void DeleteRepair()
        {
            await _repairService.DeleteRepair(SelectedRepair.Repair);
            Load();
        }
    }
}
