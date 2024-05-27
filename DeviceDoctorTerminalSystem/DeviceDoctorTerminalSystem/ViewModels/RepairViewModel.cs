using DeviceDoctorTerminalSystem.Enumerations;
using DeviceDoctorTerminalSystem.Models;
using DeviceDoctorTerminalSystem.Utilities;
using PointOfSaleTerminalSystem.ViewModels;

namespace DeviceDoctorTerminalSystem.ViewModels
{
    public class RepairViewModel : BaseViewModel
    {
        public Repair Repair { get; init; }

        public RepairCustomerViewModel Customer { get; } 
        public RepairDeviceViewModel Device { get; } 
        public RepairHistoryViewModel History { get; } 
        public RepairIssueViewModel Issue { get; } 

        public RepairViewModel() : this(new()) { }

        public RepairViewModel(Repair repair) : base()
        {
            Repair = repair;

            Customer = new RepairCustomerViewModel(Repair.Customer);
            Device = new RepairDeviceViewModel(Repair.Device);
            History = new RepairHistoryViewModel(Repair.Updates);
            Issue = new RepairIssueViewModel(Repair.IssueDescription);
        }

        public void StartProgress() => Update(Status.InProgress);

        public void Complete() => Update(Status.Completed);

        public void Cancel() => Update(Status.Cancelled);

        private void Update(Status status)
        {
            Repair.Status = status;
            Update(status.Description());
        }

        public void Update(string message = "")
        {
            var logText = string.IsNullOrEmpty(message) ? " details updated" : message;
            Repair.Log($"Repair {logText}");
            Repair.LastModifiedDate = DateTime.Now;
        }
    }
}
